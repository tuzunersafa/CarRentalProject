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
        public string SaveImageFileAndReturnFileName(IFormFile imageFile)
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

            return fileName;
        }
    }
}
