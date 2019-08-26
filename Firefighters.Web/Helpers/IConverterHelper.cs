using Firefighters.Web.Data.Entities;
using Firefighters.Web.Models;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Elemento> ToElementoAsync(ElementoViewModel view);

        ElementoViewModel ToElementoViewModel(Elemento elemento);

    }
}