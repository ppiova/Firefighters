using Firefighters.Web.Data.Entities;
using Firefighters.Web.Models;
using System.Threading.Tasks;

namespace Firefighters.Web.Helpers
{
    public interface IConverterHelper
    {
        //convert ElementoVM to Elemento
        Task<Elemento> ToElementoAsync(ElementoViewModel view, bool isNew);
        //convert Elemento to ElementoVM
        ElementoViewModel ToElementoViewModel(Elemento elemento);

        //convert SiniestroVM to Siniestro
        Task<Siniestro> ToSiniestroAsync(SiniestroViewModel view, bool isNew);

    }
}