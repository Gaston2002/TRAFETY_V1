using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAFETY.Shared.DTO.Personas
{
    public class GuiaDTO
    {
        [EmailAddress(ErrorMessage = "Formato incorrecto de mail")]
        [MaxLength(300, ErrorMessage = "El Mail puede tener como máximo {1} caracteres.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El nombre tiene como máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Phone(ErrorMessage = "Formato incorrecto de numeración de telefono")]
        [MaxLength(20, ErrorMessage = "El Número de Teléfono/celular puede tener como máximo {1} caracteres.")]
        public string? Telefono { get; set; } = "";

        [Required(ErrorMessage = "El código de tipo de Guia es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El código tiene como máximo {1} caracteres.")]
        public string Codigo { get; set; }


        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
