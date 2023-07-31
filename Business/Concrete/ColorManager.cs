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
    internal class ColorManager : IColourServices
    {
        IColourDal _colourDal;

        public ColorManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }







        public IResult Add(Colour entity)
        {
            _colourDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Colour entity)
        {
            _colourDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Colour> Get(Expression<Func<Colour, bool>> filter)
        {
            return new SuccessDataResult<Colour> (_colourDal.Get(filter),Messages.Listed);
            
        }

        public IDataResult<List<Colour>> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            return new SuccessDataResult<List<Colour>> (_colourDal.GetAll(filter), Messages.Listed);
        }

        public IResult Update(Colour entity)
        {
            _colourDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
