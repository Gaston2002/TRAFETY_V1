using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAFETY.Shared.DTO.Usuario
{
    public class PersonaRolDTO : BaseDTO
    {
        public string Email { get; set; } = "";
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; } = "";
        public string Rol { get; set; }
    }
}
