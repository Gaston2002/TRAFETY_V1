using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAFETY.Shared.DTO.TTipo
{
    public class TBaseDTO
    {
        [Required(ErrorMessage = "El código es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El código tiene como máximo {1} caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatorio.")]
        [MaxLength(100, ErrorMessage = "La descripción tiene como máximo {1} caracteres.")]
        public string Descripcion { get; set; }
    }
}
