using TRAFETY.Shared.DTO.Usuario;

namespace TRAFETY.ClientService.Autorizacion
{
    public interface ILoginService
    {
        Task Login(TokenDTO tokenDTO);
        Task Logout();
        Task ManejarRenovacionToken();
    }
}
