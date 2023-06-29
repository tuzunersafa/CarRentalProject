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
    public class CarManager : ICarServices
       
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >=2)
            {
                _carDal.Add(car);
            }
            
        }

        public void Delete(Car car)
        {
            //Sorgulama komutları
            _carDal.Delete(car);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _carDal.Get(filter);
        }

       

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll(filter);
        }

        public void Update(Car entity)
        {
            //Sorgulama komutları
            _carDal.Update(entity);
        }
    }
}
