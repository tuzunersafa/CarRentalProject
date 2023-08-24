using Core.Utitilies.Result.Void_Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.BusinessRules
{
    public class BusinessRules
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.IsSuccess)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
    }
}
