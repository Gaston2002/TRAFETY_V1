using System.ComponentModel.DataAnnotations;

namespace TRAFETY.Shared.DTO.Usuario
{
    public class UserRolDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}
