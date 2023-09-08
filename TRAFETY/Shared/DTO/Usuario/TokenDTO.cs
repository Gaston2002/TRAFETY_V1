using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAFETY.Shared.DTO.Usuario
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime Expira { get; set; }
    }
}
