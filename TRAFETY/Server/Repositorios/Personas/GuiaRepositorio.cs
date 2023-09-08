using Microsoft.EntityFrameworkCore;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Server.Repositorios.Personas
{
    public class GuiaRepositorio : Repositorio<Guia>, IGuiaRepositorio
    {
        private readonly Context context;

        public GuiaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
