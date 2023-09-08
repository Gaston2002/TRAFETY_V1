using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAFETY.Shared.DTO.Personas
{
    public class PersonaDTO
    {
        [EmailAddress(ErrorMessage = "Formato incorrecto de mail")]
        [MaxLength(300, ErrorMessage = "El Mail puede tener como máximo {1} caracteres.")]
        public string Email { get; set; } = "";

        [MaxLength(200, ErrorMessage = "El Nombre de la Persona tiene como máximo {1} caracteres.")]
        public string NombreOrganizacion { get; set; }

        [Required(ErrorMessage = "El Nombre de la Persona es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El Nombre de la Persona tiene como máximo {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Nombre de la Persona es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El Nombre de la Persona tiene como máximo {1} caracteres.")]
        public string Apellido { get; set; }

        [Phone(ErrorMessage = "Formato incorrecto de numeración de telefono")]
        [MaxLength(20, ErrorMessage = "El Número de Teléfono/celular puede tener como máximo {1} caracteres.")]
        [MinLength(0)]
        public string Telefono { get; set; } = "";
    }
}

