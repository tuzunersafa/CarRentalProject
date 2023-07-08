using Business.Abstract;
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

        public void Add(Colour entity)
        {
            _colourDal.Add(entity);
        }

        public void Delete(Colour entity)
        {
            _colourDal.Delete(entity);
        }

        public Colour Get(Expression<Func<Colour, bool>> filter)
        {
            return _colourDal.Get(filter);
        }

        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            return _colourDal.GetAll(filter);
        }

        public void Update(Colour entity)
        {
            _colourDal.Update(entity);
        }
    }
}
