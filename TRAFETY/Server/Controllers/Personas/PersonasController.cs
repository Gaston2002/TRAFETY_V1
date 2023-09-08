using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Server.Repositorios.Personas;
using TRAFETY.Shared.DTO.Personas;

namespace TRAFETY.Server.Controllers.Personas
{
    [ApiController]
    [Route("/tsapi/personas")]
    public class PersonasController : BaseController
    {
        private readonly IPersonaRepositorio repositorio;
        private readonly IMapper mapper;

        public PersonasController(IPersonaRepositorio repositorio,
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, 
        //    Roles = "Admin")]
        [HttpGet("getfull")]
        public async Task<ActionResult<List<PersonaDTO>>> GetFull()
        {
            try
            {
                List<Persona> lista = await repositorio.GetFull();
                List<PersonaDTO> result = mapper.Map<List<PersonaDTO>>(lista);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //    Roles = "Admin")]
        [HttpGet("getactivos")]
        public async Task<ActionResult<List<PersonaDTO>>> GetActivos()
        {
            try
            {
                List<Persona> lista = await repositorio.GetActivos();
                List<PersonaDTO> result = mapper.Map<List<PersonaDTO>>(lista);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //    Roles = "Admin")]
        public async Task<ActionResult<PersonaDTO>> Get(int id)
        {
            try
            {
                var res = await repositorio.GetById(id);
                if (res == null) return NotFound();

                PersonaDTO result = mapper.Map<PersonaDTO>(res);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //    Roles = "Admin")]
        public async Task<ActionResult<int>> Post(PersonaDTO dto)
        {
            try
            {
                if (dto == null) return BadRequest("Datos incorrectos");

                Persona entidad = mapper.Map<Persona>(dto);
                entidad.Email = entidad.Email.Trim().ToLower();

                #region Actualiza idcrear entidad
                ActualizaEntidadBase<Persona>(entidad);
                #endregion

                var resp = await repositorio.Insert(entidad);
                if (resp > 0) return Ok(resp);
                else return BadRequest("No se pudo agregar el tipo de estado");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //    Roles = "Admin")]
        public async Task<ActionResult<bool>> Put(PersonaDTO dto, int id)
        {
            try
            {
                Persona entidad = mapper.Map<Persona>(dto);

                #region Actualiza idcrear entidad
                ActualizaEntidadBase<Persona>(entidad);
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("baja/{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
        //    Roles = "Admin")]
        public async Task<ActionResult> Baja(int id)
        {
            try
            {
                if (await repositorio.Baja(id, ObtenerUserId()))
                {
                    return Ok($"La persona ha sido dada de baja del sistema");
                }
                return NotFound("La persona a dar de baja no a sido encontrada");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
