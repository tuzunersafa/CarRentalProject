using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.Id
                             join c in context.Colours on car.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Description = car.Description,
                                 Id = car.Id,
                                 DailyPrice = car.DailyPrice
                                 
                             };
                return result.ToList();           
                
            }
        }
    }
}
