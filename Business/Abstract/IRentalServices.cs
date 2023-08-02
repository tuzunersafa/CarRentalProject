using Core.Utitilies.Result.Void_Result;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalServices : IEntityServices<Rental>
    {
        public IResult Rent(Rental entity);

    }
}
