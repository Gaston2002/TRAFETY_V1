using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAFETY.Bd.Contexto
{
    public class FichaBase : EntidadBase
    {
        [Required(ErrorMessage = "Definir la fecha del documento del documento es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Definir la validez del documento es obligatorio.")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El Código de la ficha es obligatorio.")]
        [MaxLength(10, ErrorMessage = "Longitud maxima del Código de la ficha es de {1} caracteres")]
        public string Codigo { get; set; } = "";
    }
}
