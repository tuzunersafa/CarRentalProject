using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using DataAccess.Abstract;
using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class RentalManager : IRentalServices
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }





        public IResult Add(Rental entity)
        {
            //var context = new ValidationContext<Rental>(entity);
            //RentalValidator rentalValidator = new RentalValidator();
            //var result = rentalValidator.Validate(context);

            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            ValidationTool.Validate(new RentalValidator(), entity);


            _rentalDal.Add(entity);
            return new Result(true, Messages.Added);
        }




        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter), Messages.Listed);
        }

        public IResult Rent(Rental entity)              //Daha önce aynı CarId'ye sahip ve teslim edilmemiş(ReturnDate'i default) aracı kontrol edip veritabanına ekleme yapan metod.
        {
            var rental = _rentalDal.Get(r=> r.CarId == entity.CarId && r.ReturnDate == default); 

            if (rental == null)
            {
                _rentalDal.Add(entity);  
                return new SuccessResult(Messages.Rented); ;
            }
            else
            {
               
                return new ErrorResult(rental.CarId + " ID'li araba gelmemiş"); ;
            }

        }

        public IResult Return(int rentalId, DateTime returnDate)
        {
            var rental = _rentalDal.Get(r => r.Id == rentalId && r.ReturnDate == default);

            if(rental != null)
            {
                rental.ReturnDate = returnDate;
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Returned);
            }
            else
            {
                return new ErrorResult("Hatalı araç bilgileri");
            }



        }


        public IResult Update(Rental entity)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult("23:00 ile 23:59 arası güncelleme yapılamaz");
            }
            else
            {
                _rentalDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }

        }
    }
}
