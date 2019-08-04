using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firefighters.Web.Data.Entities
{
    public class EnumAuxiliares
    {
        public enum Estados
        {
            SinEstado = 1,
            Bueno = 2,
            Malo = 3,
            MuyBueno = 4,
            Regular = 5,
            SinUso = 6

        }

        public enum Titular
        {
            S = 1,
            F = 2,
            PC = 3
          

        }
    }
}
