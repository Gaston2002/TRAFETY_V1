using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Salidas
{
    public class SalidaProgramada : EntidadBase
    {
        [Required(ErrorMessage = "La salida es incorrecta.")]
        public int SalidaId { get; set; }
        public Salida Salida { get; set; }

        public DateTimeOffset FechaSalida { get; set; }
        public DateTimeOffset FechaRegreso { get; set; }

        public List<SalidaProgramadaDoc> SalidaProgramadaDocs { get; set; }

        public List<SalidaProgramadaParticipante> SalidaProgramadaParticipantes { get; set; }

        public List<SalidaProgramadaGuiaDoc> SalidaProgramadaGuiaDocs { get; set; }

        public List<SalidaProgramadaGuiaFicha> SalidaProgramadaGuiaFichas { get; set; }
    }
}
