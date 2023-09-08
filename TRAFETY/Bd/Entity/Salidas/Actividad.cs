using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(Codigo), Name = "Actividad_Codigo_UQ", IsUnique = true)]
    public class Actividad : TBase
    {
        public int? ActividadId { get; set; }

        public Actividad ActividadPadre { get; set; }

        public List<Salida> Salidas { get; set; }

    }
}
