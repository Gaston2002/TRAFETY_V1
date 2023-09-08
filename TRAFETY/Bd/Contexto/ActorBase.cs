using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Contexto
{
    public class ActorBase : EntidadBase
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

        public Point? Ubicacion { get; set; }
    }
}
