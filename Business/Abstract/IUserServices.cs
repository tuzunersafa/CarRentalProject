using Core.Entites.Concrete;
using Core.Utitilies.Result.Data_Result;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserServices : IEntityServices<User>
    {
        public IDataResult<List<OperationClaim>> GetClaimsOfUser(User user);
    }
}
