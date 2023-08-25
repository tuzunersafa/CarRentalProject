using Business.Abstract;
using Core.Utitilies.BusinessRules;
using Core.Utitilies.Helpers.FileHelpers;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        public IResult Add(CarImage entity)
        {
            var errorResult = BusinessRules.Check
                (
                CheckIfFiveImageForCar(entity.CarId),
                CheckIfDateEntered(entity)
                );

            if (errorResult.IsSuccess)
            {
                _carImageDal.Add(entity);
                return new SuccessResult();
            }

            return errorResult;


        }


        public IResult Add2(IFormFile imageFile, int carId)
        {
            var errorResult = BusinessRules.Check(
                CheckIfExtensionSupported(imageFile),
                CheckIfFiveImageForCar(carId));

            if (!errorResult.IsSuccess)
            {
                return new ErrorResult();
            }


            string imagePath = _fileHelper.SaveImageFileAndReturnFileName(imageFile).Data; //bu metot oluşturduğu dosya ismini döndürür

            var carImage = new CarImage
            {
                CarId = carId,
                ImagePath = imagePath,
                Date = DateTime.Now
            };

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }


        public IResult Delete(CarImage entity)
        {
            _fileHelper.Delete(entity.ImagePath);
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



        //private string SaveImageFile(IFormFile imageFile)
        //{
        //    string fileExtension = Path.GetExtension(imageFile.FileName);
        //    Guid guid = Guid.NewGuid();
        //    string fileName = $"{guid}{fileExtension}";
        //    string filePath = Path.Combine("wwwroot/images", fileName);

        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        imageFile.CopyTo(fileStream);
        //    }

        //    return fileName;
        //}



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

        private IResult CheckIfExtensionSupported(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName);

            string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (supportedExtensions.Contains(extension))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Hatalı uzantı");
        }
    }
}
