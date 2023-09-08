using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Server.Repositorios.TTipo
{
    public class TOrganizacionRepositorio : Repositorio<TOrganizacion>, ITOrganizacionRepositorio
    {
        private readonly Context context;

        public TOrganizacionRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
