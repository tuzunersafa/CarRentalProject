using Core.Utitilies.Result.Void_Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Result.Data_Result
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
