using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarServices

    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }















        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult("Araba adı en az 2 karakter olmalı");
            }

        }

        public IResult Delete(Car car)
        {
            //Sorgulama komutları
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_carDal.Get(filter), Messages.Listed);
        }



        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            //if (DateTime.Now.Hour == 1)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>("23:00 - 24:00 sattleri arasında işlem yapılamaz");
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        public IResult Update(Car entity)
        {
            //Sorgulama komutları
            _carDal.Update(entity);
            return new SuccessResult();
        }
        public IDataResult<CarDetailDto> GetCarDetailsById(int id )
        {
           return new SuccessDataResult<CarDetailDto> (_carDal.GetCarDetailsById(id),Messages.Listed);
        }

        public IDataResult<CarDetailDto> GetSingleCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            var result = _carDal.GetCarDetails(filter);


            if (result != null)
            {
                return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(filter), Messages.Listed);
            }
            return new ErrorDataResult<CarDetailDto>(Messages.Error);
            
        }
    }
}
