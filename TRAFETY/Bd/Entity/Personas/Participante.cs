using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Salidas;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(PersonaId), Name = "ParticipantePersona_UQ", IsUnique = true)]
    public class Participante : EntidadBase
    {
        [Required(ErrorMessage = "Faltan datos del participante.")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        public List<ParticipanteContacto> ParticipanteContactos { get; set; }

        public List<ParticipanteDoc> ParticipanteDocs { get; set; }

        public List<ParticipanteFicha> ParticipanteFichas { get; set; }

        public List<SalidaProgramadaParticipante> SalidaProgramadaParticipantes { get; set; }

        public List<SalidaProgramadaParticipanteDoc> SalidaProgramadaParticipanteDocs { get; set; }

        public List<SalidaProgramadaParticipanteFicha> SalidaProgramadaParticipanteFichas { get; set; }
    }
}
