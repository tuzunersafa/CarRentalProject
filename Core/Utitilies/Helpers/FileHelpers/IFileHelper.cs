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
        public string SaveImageFileAndReturnFileName(IFormFile imageFile);
    }
}
