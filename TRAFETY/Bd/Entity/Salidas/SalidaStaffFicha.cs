using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(Codigo), Name = "SalidaStaffFicha_Codigo_UQ", IsUnique = true)]
    public class SalidaStaffFicha : FichaBase
    {
        [Required(ErrorMessage = "El staff de la salida al que pertenece la ficha es obligatorio.")]
        public int SalidaStaffId { get; set; }
        public SalidaStaff SalidaStaff { get; set; }
    }
}
