using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Server.Repositorios.TTipo
{
    public class TContactoRepositorio : Repositorio<TContacto>, ITContactoRepositorio
    {
        private readonly Context context;

        public TContactoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
