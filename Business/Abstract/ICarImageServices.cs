using Core.Utitilies.Result.Void_Result;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageServices : IEntityServices<CarImage>
    {
        public IResult Add2(IFormFile imageFile, int carId);
    }
}
