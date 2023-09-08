using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(Codigo), Name = "ParticipanteFicha_Codigo_UQ", IsUnique = true)]
    public class ParticipanteFicha : FichaBase
    {
        [Required(ErrorMessage = "El participante al que pertenece la ficha es obligatorio.")]
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }
    }
}
