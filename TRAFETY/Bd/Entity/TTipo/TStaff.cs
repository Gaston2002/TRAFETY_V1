using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Salidas;

namespace TRAFETY.Bd.Entity.TTipo
{
    [Index(nameof(Codigo), Name = "TStaff_Codigo_UQ", IsUnique = true)]
    public class TStaff : TBase
    { 
        public List<EmpresaStaff> EmpresaStaffs { get; set; }
        public List<SalidaStaff> SalidaStaffs { get; set; }
    }
}
