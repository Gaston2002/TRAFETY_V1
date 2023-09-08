using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(SalidaProgramadaId), nameof(GuiaId), Name = "SalidaStaff_SalidaProgramadaId_GuiaId_UQ", IsUnique = true)]
    public class SalidaStaff : EntidadBase
    {
        [Required(ErrorMessage = "La salida planificada es obligatoria.")]
        public int SalidaProgramadaId { get; set; }
        public SalidaProgramada SalidaProgramada { get; set; }

        [Required(ErrorMessage = "El staff es obligatorio.")]
        public int GuiaId { get; set; }
        public Guia Guia { get; set; }

        [Required(ErrorMessage = "Tipo de Staff incorrecto.")]
        public int TStaffId { get; set; }
        public TStaff TStaff { get; set; }

        public List<SalidaStaffDoc> SalidaStaffDocs { get; set; }

        public List<SalidaStaffFicha> SalidaStaffFichas { get; set; }
    }
}
