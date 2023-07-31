﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Result.Data_Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(default, false, message)
        {
        }
        public ErrorDataResult(T data) : base(default, false)
        {
        }
        public ErrorDataResult(string message) : base(default,false,message) 
        {
            
        }
        public ErrorDataResult() : base(default,false)
        {
            
        }
    }
}
