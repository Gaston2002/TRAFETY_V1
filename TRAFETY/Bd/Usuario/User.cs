using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Bd.Usuario
{
    public class User : IdentityUser
    {
        public int? PersonaId { get; set; }
        public Persona? Persona { get; set; }

    }
}
