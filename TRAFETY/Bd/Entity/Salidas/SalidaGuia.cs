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
    [Index(nameof(SalidaId), nameof(GuiaId), Name = "SalidaGuia_SalidaId_GuiaId_UQ", IsUnique = true)]
    public class SalidaGuia : EntidadBase
    {
        [Required(ErrorMessage = "Salida incorrecta.")]
        public int SalidaId { get; set; }
        public Salida Salida { get; set; }

        [Required(ErrorMessage = "Guía incorrecto.")]
        public int? GuiaId { get; set; }
        public Guia Guia { get; set; }

    }
}
