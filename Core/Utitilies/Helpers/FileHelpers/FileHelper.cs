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
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string imagePath)
        {
            File.Delete(Path.Combine("wwwroot/images",imagePath));
            return new SuccessResult();
        }

        public IDataResult<string> SaveImageFileAndReturnFileName(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentNullException("imageFile","Dosya bulunamadı"); //Validasyon taşınacak
            }

            string fileExtension = Path.GetExtension(imageFile.FileName);

            var guid = Guid.NewGuid();

            string fileName = $"{guid}{fileExtension}";
            string filePath = Path.Combine("wwwroot/images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }
            var toReturn = new SuccessDataResult<string>(fileName,"Görsel klasöre kaydedildi");
            return toReturn;
        }
    }
}
