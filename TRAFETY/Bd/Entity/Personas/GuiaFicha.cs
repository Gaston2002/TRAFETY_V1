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
    [Index(nameof(Codigo), Name = "GuiaFicha_Codigo_UQ", IsUnique = true)]
    public class GuiaFicha : FichaBase
    {
        [Required(ErrorMessage = "El guía al que pertenece la ficha es obligatorio.")]
        public int GuiaId { get; set; }
        public Guia Guia { get; set; }
    }
}
