using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Shared.Enum;

namespace TRAFETY.Bd.Contexto
{
    public class EntidadBase : IEntidadBase
    {
        public int Id { get; set; }
        public string Observacion { get; set; } = "";
        public string IdCrea { get; set; } = "";
        public DateTime FechaCrea { get; set; } = DateTime.Now;
        public string? IdModif { get; set; } = null;
        public DateTime? FechaModif { get; set; } = null;
        public string? IdBaja { get; set; } = null;
        public DateTime? FechaBaja { get; set; } = null;
        public EnumEstadoRegistro EstadoRegistro { get; set; } = EnumEstadoRegistro.inactivo;
    }
}
