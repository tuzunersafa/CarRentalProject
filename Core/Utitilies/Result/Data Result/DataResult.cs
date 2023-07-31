using Core.Utitilies.Result.Void_Result;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Result.Data_Result
{
    public class DataResult<T> : Core.Utitilies.Result.Void_Result.Result, IDataResult<T>
    {
        public DataResult(T data, bool success,string message) : base(success,message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success) 
        {
            Data = data;
        }


        public T Data { get; }
    }
}
