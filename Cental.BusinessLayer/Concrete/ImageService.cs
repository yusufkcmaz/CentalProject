using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (extension!= ".jpg" && extension!= "Jpeg" && extension!=".png")
            {
                throw new ValidationException("Dosya Formatı Resim Olmalıdır.");

            }
            var imageName = Guid.NewGuid() + extension;
            var imagefolder = Path.Combine(currentDirectory, "wwwroot/images");
            if (!Directory.Exists(imagefolder))
            {
                Directory.CreateDirectory(imagefolder);

            }

            var saveLocation = Path.Combine(imagefolder, imageName);
            var stream = new FileStream(saveLocation, FileMode.Create);
            await file.CopyToAsync(stream);
            return "/images/" + imageName;
        }
    }
}
