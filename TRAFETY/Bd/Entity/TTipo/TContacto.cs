using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Bd.Entity.TTipo
{
    [Index(nameof(Codigo), Name = "TContacto_Codigo_UQ", IsUnique = true)]
    public class TContacto : TBase
    {
        public List<ParticipanteContacto> ParticipanteContactos { get; set; }
    }
}
