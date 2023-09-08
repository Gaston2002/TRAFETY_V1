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
    [Index(nameof(NomDoc), Name = "ParticipanteDoc_NomDoc_UQ", IsUnique = true)]
    public class ParticipanteDoc : DocBase
    {
        [Required(ErrorMessage = "El participante al que pertenece el documento es obligatorio.")]
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }
    }
}
