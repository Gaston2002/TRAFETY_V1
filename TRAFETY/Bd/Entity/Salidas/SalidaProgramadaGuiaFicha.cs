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
    [Index(nameof(Codigo), Name = "SalidaProgramadaGuiaFicha_Codigo_UQ", IsUnique = true)]
    public class SalidaProgramadaGuiaFicha : FichaBase
    {
        [Required(ErrorMessage = "La salida programada al que pertenece el documento es obligatorio.")]
        public int SalidaProgramadaId { get; set; }
        public SalidaProgramada SalidaProgramada { get; set; }

        [Required(ErrorMessage = "El Guía al que pertenece la ficha es obligatorio.")]
        public int SalidaGuiaId { get; set; }
        public SalidaGuia SalidaGuia { get; set; }
    }
}
