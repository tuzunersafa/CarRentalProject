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
    public class BrandManager : IBrandServices
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }





        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new Result(true,Messages.Added);
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            return new SuccessDataResult<Brand> (_brandDal.Get(filter),Messages.Listed);
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return new SuccessDataResult<List<Brand>> (_brandDal.GetAll(filter),Messages.Listed);
        }

        

        public IResult Update(Brand entity)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult("23:00 ile 23:59 arası güncelleme yapılamaz");
            }
            else
            {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }
             
        }
    }
}
