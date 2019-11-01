using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Firefighters.Web.Helpers
{
    public class ComprobanteHelper : IComprobanteHelper
    {
        public async Task<string> UploadComprobanteAsync(IFormFile comprobanteFile)
        {
            var nombre = comprobanteFile.FileName.ToString();
            //var guid = Guid.NewGuid().ToString();
            var file = nombre;
            //var file = $"{nombre}.pdf";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot\\files\\Comprobantes",
                file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await comprobanteFile.CopyToAsync(stream);
            }

            return $"/files/Comprobantes/{file}";
        }
    }
}
