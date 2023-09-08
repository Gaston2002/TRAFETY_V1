using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Usuario;
using TRAFETY.Server.Repositorios;
using TRAFETY.Shared.Enum;

namespace TRAFETY.Server.Controllers.Contexto
{
    public class TSControllerBase : ControllerBase
    {
        protected string ObtenerUserId()
        {
            string userId;
            if (HttpContext.User.Claims == null)
            {
                userId = "";
            }
            else
            {
                userId = HttpContext.User.Claims
                                .Where(claim => claim.Type == "usuarioId")
                                .FirstOrDefault().Value;
            }

            return userId;
        }

        protected User ObtenerTracksSafetyIUser(UserManager<User> userManager)
        {
            return userManager.FindByIdAsync(ObtenerUserId()).Result;
        }
        protected Persona ObtenerPersona<T>(IRepositorio<T> repositorio,
                                            UserManager<User> userManager)
                                            where T : class, IEntidadBase
        {
            User usr = ObtenerTracksSafetyIUser(userManager);
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
                entidad.IdModif = usuarioId;
                entidad.FechaModif = DateTime.UtcNow;
            }
            else if (entidad.Id != 0
                     && entidad.EstadoRegistro == Shared.Enum.EnumEstadoRegistro.borrado)
            {
                entidad.IdBaja = usuarioId;
                entidad.FechaBaja = DateTime.UtcNow;
            }
        }
    }

}
