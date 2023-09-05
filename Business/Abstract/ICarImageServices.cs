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
        public IResult Upload(IFormFile imageFile, int carId);
    }
}
