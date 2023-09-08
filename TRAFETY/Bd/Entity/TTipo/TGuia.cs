using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Bd.Entity.TTipo
{
    [Index(nameof(Codigo), Name = "TGuia_Codigo_UQ", IsUnique = true)]
    public class TGuia : TBase
    {
        public List<Guia> Guias { get; set; }
    }
}
