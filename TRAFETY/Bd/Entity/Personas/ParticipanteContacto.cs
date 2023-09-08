using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(ParticipanteId), nameof(PersonaId), Name = "ParticipanteContacto_ParticipanteId_PersonaId_UQ", IsUnique = true)]
    public class ParticipanteContacto : EntidadBase
    {
        [Required(ErrorMessage = "El participante es obligatoria.")]
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }

        [Required(ErrorMessage = "La persona que es contacto es obligatoria.")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        [Required(ErrorMessage = "Tipo de contacto incorrecto.")]
        public int TContactoId { get; set; }
        public TContacto TContacto { get; set; }
    }
}
