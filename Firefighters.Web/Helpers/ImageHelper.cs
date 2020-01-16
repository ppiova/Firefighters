using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
       

        public async Task<string> UploadImageAsync(IFormFile imageFile, int idElemento)
        {
            var name = "elemento";
            var id = idElemento.ToString();
            var datetime = DateTime.Now.ToString("ddMMyyyy-Hmm");

            var file = $"{datetime+"-"+id+"-"+name}.jpg";

            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot\\images\\Elementos",
                file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/Elementos/{file}";
        }
    }
}
