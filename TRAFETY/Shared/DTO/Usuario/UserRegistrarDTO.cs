using System.ComponentModel.DataAnnotations;

namespace TRAFETY.Shared.DTO.Usuario
{
    public class UserRegistrarDTO
    {
        [Required(ErrorMessage = "La Persona es obligatoria.")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La Contraseña debe tener como mínimo {1} caracteres.")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio.")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "Repita la contraseña.")]
        [MinLength(8, ErrorMessage = "La Contraseña debe tener como mínimo {1} caracteres.")]
        public string ContraseñaRepetida { get; set; }
    }
}
