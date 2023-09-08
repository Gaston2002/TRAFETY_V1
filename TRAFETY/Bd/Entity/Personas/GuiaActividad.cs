using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Salidas;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(GuiaId), nameof(ActividadId), Name = "GuiaActividad_GuiaId_ActividadId_UQ", IsUnique = true)]
    public class GuiaActividad : EntidadBase
    {
        [Required(ErrorMessage = "Guía incorrecto.")]
        public int? GuiaId { get; set; }
        public Guia Guia { get; set; }

        [Required(ErrorMessage = "Actividad incorrecta.")]
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }

    }
}
