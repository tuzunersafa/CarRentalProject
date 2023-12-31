﻿using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1, DailyPrice = 180, ModelYear = 2005 },
                new Car{Id = 2,BrandId = 2,ColorId = 2, DailyPrice = 250, ModelYear = 2012 },
                new Car{Id = 3,BrandId = 1,ColorId = 4, DailyPrice = 300, ModelYear = 2017 },
                new Car{Id = 4,BrandId = 3,ColorId = 2, DailyPrice = 180, ModelYear = 2008 },
                new Car{Id = 5,BrandId = 4,ColorId = 1, DailyPrice = 180, ModelYear = 2000 }
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.FirstOrDefault(c  => c.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList(); ;
        }

        public CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
