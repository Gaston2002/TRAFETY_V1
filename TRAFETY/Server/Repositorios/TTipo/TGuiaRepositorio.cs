using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Server.Repositorios.TTipo
{
    public class TGuiaRepositorio : Repositorio<TGuia>, ITGuiaRepositorio
    {
        private readonly Context context;

        public TGuiaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
