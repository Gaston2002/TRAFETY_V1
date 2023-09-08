using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Server.Repositorios.Personas
{
    public interface IPersonaRepositorio : IRepositorio<Persona>
    {
        Task<bool> ExisteMail(string email);
        Task<Persona> GetByEmail(string email);
    }
}