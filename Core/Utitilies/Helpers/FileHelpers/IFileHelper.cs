using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utitilies.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        public  IResult Delete(string imagePath);
        public IDataResult<string> SaveImageFileAndReturnFileName(IFormFile imageFile);

    }
}
