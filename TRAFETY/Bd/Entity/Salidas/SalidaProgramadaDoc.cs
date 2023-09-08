using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(NomDoc), Name = "SalidaProgramadaDoc_NomDoc_UQ", IsUnique = true)]
    public class SalidaProgramadaDoc : DocBase
    {
        [Required(ErrorMessage = "La salida programada al que pertenece el documento es obligatorio.")]
        public int SalidaProgramadaId { get; set; }
        public SalidaProgramada SalidaProgramada { get; set; }
    }
}
