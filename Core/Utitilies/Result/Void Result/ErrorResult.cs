﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Result.Void_Result
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false,message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
