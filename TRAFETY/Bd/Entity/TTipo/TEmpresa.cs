using Microsoft.EntityFrameworkCore;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Bd.Entity.TTipo
{
    [Index(nameof(Codigo), Name = "TEmpresa_Codigo_UQ", IsUnique = true)]
    public class TEmpresa : TBase
    {
        public List<Empresa> Empresas { get; set; }
    }
}
