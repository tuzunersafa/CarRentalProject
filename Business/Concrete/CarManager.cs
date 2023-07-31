using Business.Abstract;
using Business.Constants;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
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
















        public IResult Add(Car car)
        {
            if (car.Description.Length >=2)
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
            return new SuccessDataResult<Car> (_carDal.Get(filter),Messages.Listed);
        }

       

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(filter),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>("23:00 - 24:00 sattleri arasında işlem yapılamaz");
            }
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails());
        }

        public IResult Update(Car entity)
        {
            //Sorgulama komutları
            _carDal.Update(entity);
            return new SuccessResult();
        }
    }
}
