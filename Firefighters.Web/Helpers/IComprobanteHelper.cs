using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public interface IComprobanteHelper
    {
        Task<string> UploadComprobanteAsync(IFormFile imageFile);
    }
}
