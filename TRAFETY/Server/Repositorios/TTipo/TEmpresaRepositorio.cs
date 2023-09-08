using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Server.Repositorios.TTipo
{
    public class TEmpresaRepositorio : Repositorio<TEmpresa>, ITEmpresaRepositorio
    {
        private readonly Context context;

        public TEmpresaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
