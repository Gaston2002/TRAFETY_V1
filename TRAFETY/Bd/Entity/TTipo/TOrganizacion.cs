using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Salidas;

namespace TRAFETY.Bd.Entity.TTipo
{
    [Index(nameof(Codigo), Name = "TOrganizacion_Codigo_UQ", IsUnique = true)]
    public class TOrganizacion : TBase
    {
        public List<Salida> Salidas { get; set; }
    }
}
