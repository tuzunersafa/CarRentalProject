using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //Sorgulama komutları
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            //Sorgulama komutları
            _carDal.Delete(car);

        }

        public List<Car> GetAll()
        {
            //Sorgulama komutları
            return _carDal.GetAll();
            
        }

        public List<Car> GetById(int id)
        {
            //Sorgulama komutları
            return _carDal.GetById(id);
        }

        public void Update()
        {
            //Sorgulama komutları
            _carDal.Update();
        }
    }
}
