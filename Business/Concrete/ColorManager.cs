using Business.Abstract;
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
        public void Add(Colour entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Colour entity)
        {
            throw new NotImplementedException();
        }

        public Colour Get(Expression<Func<Colour, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Colour entity)
        {
            throw new NotImplementedException();
        }
    }
}
