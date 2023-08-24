using Business.Abstract;
using Core.Utitilies.BusinessRules;
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
    public class CarImageManager : ICarImageServices
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(CarImage entity)
        {
            var errorResult = BusinessRules.Check
                (
                CheckIfFiveImageForCar(entity.CarId),
                CheckIfDateEntered(entity)
                );

            if ( errorResult.IsSuccess)
            {
                _carImageDal.Add(entity);
                return new SuccessResult();
            }

            return errorResult;
            

        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(filter));
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }

        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult();
        }




        //RULES

        private IResult CheckIfFiveImageForCar(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Bir araç için 5'ten fazla görsel olamaz.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfDateEntered(CarImage carImage)
        {
            if (carImage.Date == default)
            {
                carImage.Date = DateTime.Now;
                return new SuccessResult();
            }
            return new ErrorResult("Görsel ekleme tarihleri otomatik atanır. Görsel tarihi boş bırakılmalıdır.");
        }
    }
}
