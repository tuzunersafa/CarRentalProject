using Core.Utitilies.Result.Void_Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Result.Data_Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }
        public SuccessDataResult(T data) : base(data, true)
        {
        }
        public SuccessDataResult() : base(default,true)
        {
            
        }
        public SuccessDataResult(string message) : base(default,true,message)
        {
            
        }
    }
}
