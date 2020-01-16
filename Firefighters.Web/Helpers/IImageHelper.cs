using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, int idElemento);
    }
}
