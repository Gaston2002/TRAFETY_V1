using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Server.Repositorios.Personas
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        private readonly Context context;

        public PersonaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteMail(string email)
        {
            try
            {
                email = email.Trim().ToLower();
                var persona = await Context.Set<Persona>()
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(i => i.Email == email);
                if (persona == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e) { throw; }
        }
        
        //var persona = Context.Set<Persona>()
        //                           .AsNoTracking()
        //                           .FirstOrDefaultAsync(i => i.Email == email).GetAwaiter().GetResult();

        public async Task<Persona?> GetByEmail(string email)
        {
            email = email.Trim().ToLower();
            return await Context.Set<Persona>()
                                .AsNoTracking()
                                .FirstOrDefaultAsync(i => i.Email == email);
        }

    }
}
