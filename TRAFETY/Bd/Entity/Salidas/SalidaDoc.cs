using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(NomDoc), Name = "SalidaDoc_NomDoc_UQ", IsUnique = true)]
    public class SalidaDoc : DocBase
    {
        [Required(ErrorMessage = "La salida al que pertenece el documento es obligatorio.")]
        public int SalidaId { get; set; }
        public Salida Salida { get; set; }
    }
}
