using Firefighters.Web.Data.Entities;
using Firefighters.Web.Models;

namespace Firefighters.Web.Helpers
{
    public interface IConverterHelper
    {
        ElementoViewModel ToElementoViewModel(Elemento elemento);
    }
}