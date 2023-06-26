using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        public List<Car> GetById(int id);
        public List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update();


    }
}
