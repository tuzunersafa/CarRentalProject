using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Result.Void_Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true)
        {
            
        }
        public SuccessResult() : base(true)
        {
            
        }
    }
}
