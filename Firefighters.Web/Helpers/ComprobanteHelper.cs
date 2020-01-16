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
        public async Task<string> UploadComprobanteAsync(IFormFile comprobanteFile, int idElemento)
        {
            var name = comprobanteFile.ToString();
            var id = idElemento.ToString();
            var datetime = DateTime.Now.ToString();
            var file = $"{id + datetime + name}.pdf";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot\\files\\ElementosDocs",
                file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await comprobanteFile.CopyToAsync(stream);
            }

            return $"/files/ElementosDocs/{file}";
        }
    }
}
