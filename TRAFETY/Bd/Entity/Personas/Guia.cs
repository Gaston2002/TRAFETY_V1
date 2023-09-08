using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Salidas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(PersonaId), Name = "GuiaPersona_UQ", IsUnique = true)]
    public class Guia: EntidadBase
    {
        [Required(ErrorMessage = "Faltan datos del guía.")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        [Required(ErrorMessage = "Faltan Categorizar el Guía.")]
        public int TGuiaId { get; set; }
        public TGuia TGuia { get; set; }

        public List<Salida> Salidas { get; set; }

        public List<EmpresaGuia> EmpresaGuias { get; set; }

        public List<GuiaActividad> GuiaActividades { get; set; }

        public List<GuiaDoc> GuiaDocs { get; set; }

        public List<GuiaFicha> GuiaFichas { get; set; }

        public List<SalidaGuia> SalidaGuias { get; set; }
    }
}
