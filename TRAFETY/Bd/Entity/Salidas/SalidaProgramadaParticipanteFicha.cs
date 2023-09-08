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
    [Index(nameof(Codigo), Name = "SalidaProgramadaParticipanteFicha_Codigo_UQ", IsUnique = true)]
    public class SalidaProgramadaParticipanteFicha : FichaBase
    {
        [Required(ErrorMessage = "El participante al que pertenece la ficha es obligatorio.")]
        public int SalidaProgramadaParticipanteId { get; set; }
        public SalidaProgramadaParticipante SalidaProgramadaParticipante { get; set; }
    }
}
