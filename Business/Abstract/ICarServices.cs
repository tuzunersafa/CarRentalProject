using Core.Utitilies.Result.Data_Result;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarServices : IEntityServices<Car>
    {
        //public List<Car> GetById(int id);
        //public List<Car> GetAll();
        //void Add(Car car);
        //void Delete(Car car);
        //void Update();
        public IDataResult<List<CarDetailDto>> GetCarsDetails();
        public IDataResult<CarDetailDto> GetCarDetailsById(int id);

        IDataResult<CarDetailDto> GetSingleCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}
