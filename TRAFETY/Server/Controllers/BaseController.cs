using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Usuario;
using TRAFETY.Server.Repositorios;
using TRAFETY.Shared.Enum;

namespace TRAFETY.Server.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string ObtenerUserId()
        {
            if(HttpContext.User.Claims
                            .Where(claim => claim.Type == "Id")
                            .FirstOrDefault() == null)
            {
                return "";
            }
            else
            {
                return HttpContext.User.Claims
                            .Where(claim => claim.Type == "Id")
                            .FirstOrDefault().Value;
            }
        }

        protected User ObtenerUserTrackSafety(UserManager<User> userManager)
        {
            return userManager.FindByIdAsync(ObtenerUserId()).Result;
        }

        protected Persona ObtenerPersona<T>(IRepositorio<T> repositorio,
                                            UserManager<User> userManager)
                                            where T : class, IEntidadBase
        {
            User usr = ObtenerUserTrackSafety(userManager);
            Persona res = repositorio.Context
                          .Set<Persona>()
                          .FirstOrDefault(e => e.Id == usr.PersonaId);

            if (res == null) return null;
            return res;
        }
        protected string ObtenerRol()
        {
            return HttpContext.User.Claims
                            .Where(claim => claim.Type == ClaimTypes.Role)
                            .FirstOrDefault().Value;
        }
 
        protected void ActualizaEntidadBase<T>(T entidad) where T : class, IEntidadBase
        {
            string usuarioId = ObtenerUserId();

            if (entidad.Id == 0)
            {
                entidad.IdCrea = usuarioId;
                entidad.FechaCrea = DateTime.UtcNow;
                entidad.IdModif = usuarioId;
                entidad.FechaModif = DateTime.UtcNow;
            }
            else if (entidad.Id != 0
                     && entidad.EstadoRegistro != EnumEstadoRegistro.borrado)
            {
                if (string.IsNullOrEmpty( entidad.IdCrea) )
                {
                    entidad.IdCrea = usuarioId;
                    entidad.FechaCrea = DateTime.UtcNow;
                }
                entidad.IdModif = usuarioId;
                entidad.FechaModif = DateTime.UtcNow;
            }
            else if (entidad.Id != 0
                     && entidad.EstadoRegistro == EnumEstadoRegistro.borrado)
            {
                entidad.IdBaja = usuarioId;
                entidad.FechaBaja = DateTime.UtcNow;
            }
        }

    }
}
