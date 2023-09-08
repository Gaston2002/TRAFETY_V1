using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TRAFETY.Bd.Entity.TTipo;
using TRAFETY.Server.Controllers.Contexto;
using TRAFETY.Server.Repositorios.TTipo;
using TRAFETY.Shared.DTO.TTipo;

namespace TRAFETY.Server.Controllers.TTipo
{
    [ApiController]
    [Route("/tsapi/tcontactos")]
    public class TContactoController : TSControllerBase
    {
        private readonly ITContactoRepositorio repositorio;
        private readonly IMapper mapper;

        public TContactoController(ITContactoRepositorio repositorio,
                                    IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet("getActivos")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        public async Task<ActionResult<List<TContactoDTO>>> GetActivos()
        {
            try
            {
                List<TContacto> lista = await repositorio.GetActivos();

                List<TContactoDTO> result = mapper.Map<List<TContactoDTO>>(lista);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("getfull")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        public async Task<ActionResult<List<TContactoDTO>>> GetFull() //CON INCLUDE
        {
            try
            {
                List<TContacto> lista = await repositorio.GetFull();

                List<TContactoDTO> result = mapper.Map<List<TContactoDTO>>(lista);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        public async Task<ActionResult<TContactoDTO>> Get(int id) //CON INCLUDE
        {
            try
            {
                var res = await repositorio.GetById(id);
                if (res == null) return NotFound();

                TContactoDTO result = mapper.Map<TContactoDTO>(res);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        Roles = "Admin, Organizador")]
        public async Task<ActionResult<int>> Post(TContactoDTO dto)
        {
            try
            {
                if (dto == null) return BadRequest("Datos incorrectos");

                TContacto entidad = mapper.Map<TContacto>(dto);

                #region Actualiza idcrea entidad
                ActualizaEntidadBase<TContacto>(entidad);
                #endregion

                var resp = await repositorio.Insert(entidad);
                if (resp > 0) return Ok(resp);
                else return BadRequest("No se pudo agregar el tipo");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        public async Task<ActionResult<bool>> Put(TContactoDTO dto, int id)
        {
            try
            {
                TContacto entidad = mapper.Map<TContacto>(dto);

                #region Actualiza idmodif entidad
                ActualizaEntidadBase<TContacto>(entidad);
                #endregion

                var resp = await repositorio.Update(entidad, id);
                if (resp)
                {
                    return Ok(resp);
                }
                else
                {
                    return BadRequest("Datos incorrectos");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut("baja/{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        public async Task<ActionResult> Baja(int id)
        {
            try
            {
                if (await repositorio.Baja(id, ObtenerUserId()))
                {
                    return Ok($"Registro dado de baja del sistema");
                }
                return NotFound("El Registro a dar de baja no a sido encontrado");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //[HttpDelete("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //Roles = "Admin")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        if (await repositorio.Delete(id))
        //        {
        //            return Ok($"El registro ha sido beorrado");
        //        }
        //        return NotFound("El registro que desea borrar no a sido encontrado");
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}
    }
}
