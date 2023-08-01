using Entites.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails();
        CarDetailDto GetCarDetailsById(int id);
        CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
 
    }
}
