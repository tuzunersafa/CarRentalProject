using Business.Abstract;
using Business.Constants;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
