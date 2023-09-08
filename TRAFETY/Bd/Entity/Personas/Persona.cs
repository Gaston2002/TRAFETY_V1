using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(Email), Name = "PersonaEmail_UQ", IsUnique = true)]
    public class Persona : ActorBase
    {
        [Required(ErrorMessage = "El apellido de la persona es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El apellido de la persona tiene como máximo {1} caracteres.")]
        public string Apellido { get; set; }
    }
}
