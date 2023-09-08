using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(SalidaProgramadaId), nameof(ParticipanteId), Name = "SalidaParticipante_SalidaProgramadaId_ParticipanteId_UQ", IsUnique = true)]
    public class SalidaProgramadaParticipante : EntidadBase
    {
        [Required(ErrorMessage = "La salida que participa es obligatoria.")]
        public int SalidaProgramadaId { get; set; }
        public SalidaProgramada SalidaProgramada { get; set; }

        [Required(ErrorMessage = "El pariticipante es obligatorio.")]
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }

        public List<SalidaProgramadaParticipanteDoc> SalidaProgramadaParticipanteDocs { get; set; }

        public List<SalidaProgramadaParticipanteFicha> SalidaProgramadaParticipanteFichas { get; set; }
    }
}
