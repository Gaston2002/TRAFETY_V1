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
    [Index(nameof(NomDoc), Name = "SalidaStaffDoc_NomDoc_UQ", IsUnique = true)]
    public class SalidaStaffDoc : DocBase
    {
        [Required(ErrorMessage = "El sataff de la salida al que pertenece el documento es obligatorio.")]
        public int SalidaStaffId { get; set; }
        public SalidaStaff SalidaStaff { get; set; }
    }
}
