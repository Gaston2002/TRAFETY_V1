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
    [Index(nameof(NomDoc), Name = "SalidaProgramadaParticipanteDoc_NomDoc_UQ", IsUnique = true)]
    public class SalidaProgramadaParticipanteDoc : DocBase
    {
        [Required(ErrorMessage = "El participante al que pertenece el documento es obligatorio.")]
        public int SalidaProgramadaParticipanteId { get; set; }
        public SalidaProgramadaParticipante SalidaProgramadaParticipante { get; set; }

        [Required(ErrorMessage = "Definir la validez del documento es obligatorio.")]
        public DateTime FechaVencimiento { get; set; }
    }
}
