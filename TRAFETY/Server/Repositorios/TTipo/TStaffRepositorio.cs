using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Server.Repositorios.TTipo
{
    public class TStaffRepositorio : Repositorio<TStaff>, ITStaffRepositorio
    {
        private readonly Context context;

        public TStaffRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
