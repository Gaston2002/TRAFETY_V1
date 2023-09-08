using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Usuario;
using TRAFETY.Server.Repositorios.Personas;
using TRAFETY.Shared.DTO.Usuario;
using TRAFETY.Shared.Enum;

namespace TRAFETY.Server.Controllers.Usuario
{
    [ApiController]
    [Route("tsapi/usuarios")]
    public class UserController : BaseController
    {
        const double minexpiracion = 60; //minutos para que expire el token
        private readonly Context context;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<User> signInManager;
        private readonly IPersonaRepositorio reposPersona;
        private readonly IMapper mapper;

        public UserController(Context context,
                              UserManager<User> userManager,
                              IConfiguration configuration,
                              SignInManager<User> signInManager,
                              IPersonaRepositorio reposPersona,
                              IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.reposPersona = reposPersona;
            this.mapper = mapper;
        }

        #region EndPoints
        [HttpPost("registrar")]
        public async Task<ActionResult<TokenDTO>> Registrar(UserRegistrarDTO credencial)
        {
            // Busco Persona mediante id y empiezo a dar de alta los datos de Usuario
            var persona = await reposPersona.GetById(credencial.IdPersona);

            var usuario = new User
            {
                UserName = persona.Email,
                Email = persona.Email,
                PersonaId = persona.Id,
            };

            var resultado = await userManager.CreateAsync(usuario, credencial.Contraseña);

            if (resultado.Succeeded)
            {
                //CREA CLAIM EMAIL Y ROL
                await userManager.AddClaimAsync(usuario, new Claim("Email", usuario.Email));
                await userManager.AddClaimAsync(usuario, new Claim(ClaimTypes.Role, credencial.Rol.ToString()));

                return await ConstruirToken(usuario.Email);
            }
            else return BadRequest(resultado.Errors);
        }

        [HttpPost("registrarconpersona")]
        public async Task<ActionResult<TokenDTO>> RegistrarConPersona(UserPersonaRegistrarDTO credencial)
        {
            credencial.Email = credencial.Email.Trim().ToLower();

            var usuario = new User()
            {
                UserName = credencial.Email,
                Email= credencial.Email
            };

            var resultado = await userManager.CreateAsync(usuario, credencial.Contraseña);

            if (resultado.Succeeded)
            {
                //CREA CLAIM EMAIL Y ROL
                try
                {
                    await userManager.AddClaimAsync(usuario, new Claim("Email", usuario.Email!));
                }
                catch (Exception e)
                {

                    throw;
                }

                if (credencial.Rol == "") { credencial.Rol = "participante"; }
                UserRolDTO rol = new()
                {
                    Email = credencial.Email,
                    Rol = credencial.Rol
                };
                await AddRolUser(rol);

                Persona? persona = await reposPersona.GetByEmail(credencial.Email);

                if (persona != null)
                {
                    var id = persona.Id;
                    var idcrea = persona.IdCrea;
                    var fechacrea = persona.FechaCrea;
                    persona = mapper.Map<Persona>(credencial);
                    persona.Id = id;
                    persona.IdCrea = idcrea;
                    persona.FechaCrea = fechacrea;

                    if (!(await reposPersona.Update(persona, persona.Id)))
                    {
                        return BadRequest("Datos incorrectos (2)");
                    }
                }
                else
                {
                    persona = mapper.Map<Persona>(credencial);
                    persona.IdCrea = usuario.Id;
                    persona.FechaCrea = DateTime.UtcNow;
                    persona.IdModif = usuario.Id;
                    persona.FechaModif = DateTime.UtcNow;
                    var resp = await reposPersona.Insert(persona);
                }

                usuario.PersonaId = persona.Id;

                resultado = await userManager.UpdateAsync(usuario);

                return await ConstruirToken(usuario.Email!);
            }
            else
            {
                return BadRequest(resultado.Errors + " (1)");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login(UserCredencialDTO credencial)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencial.Email,
                                                                    credencial.Psw,
                                                                    isPersistent: false,
                                                                    lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return await ConstruirToken(credencial.Email);
            }
            else
            {
                return BadRequest("Usuario o Pasword Incorrecto...");
            }
        }

        [HttpGet("RenovarToken")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<TokenDTO>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "Email").FirstOrDefault();
            var email = emailClaim.Value;

            return await ConstruirToken(email);
        }

        [HttpPost("nuevacontraseña")]
        public async Task<bool> CambiarContraseña(UserCredencialDTO credencial)
        {
            var user = await userManager.FindByEmailAsync(credencial.Email);

            if (user != null)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, credencial.Psw);
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return true;
                else return false;
            }
            else return false;
        }

        //ROLES

        [HttpGet("roles")]
        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            return await context.Roles.Select(x => new RolDTO { Rol = x.Name! }).ToListAsync();
        }


        [HttpGet("Usuario")]
        public async Task<ActionResult<List<PersonaRolDTO>>> GetPersonaRol()
        {
            return await context.Roles.Select(x => new PersonaRolDTO { Rol = x.Name! }).ToListAsync();
        }


        [HttpPost("CargarRol")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> CargarRol(UserRolDTO rol)
        {
            var result = await AddRolUser(rol);
            if(!Convert.ToBoolean( result))
            {
                return BadRequest("Usuario no existe");
            }
            return NoContent();
        }

        [HttpPost("BorrarRol")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> BorrarRol(UserRolDTO rol)
        {
            var usuario = await ObtenerUsuario(rol.Email);
            if (usuario is null)
            {
                return BadRequest("Usuario no existe");
            }
            await userManager.RemoveFromRoleAsync(usuario, rol.Rol);
            return NoContent();
        }

        [HttpGet("UsersRoles")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<PersonaRolDTO>> GetUser()
        {
            List<PersonaRolDTO> Listpersonas = new();
            var personas = await reposPersona.GetActivos();
            foreach (var p in personas)
            {
                PersonaRolDTO persona = new();
                var usuario = await ObtenerUsuario(p.Email);
                persona.Id = p.Id;
                persona.Nombre = p.Nombre;
                persona.Apellido = p.Apellido;
                persona.Email = p.Email;
                persona.Telefono = p.Telefono;
                if (usuario != null)
                {
                    IList<Claim> claims = await userManager.GetClaimsAsync(usuario);
                    persona.Rol = claims.Where(claim => claim.Type == ClaimTypes.Role).FirstOrDefault().Value;
                }
                else
                {
                    persona.Rol = null;
                }
                Listpersonas.Add(persona);
            }

            return Ok(Listpersonas);
        }

        [HttpGet("ObtenerRoles/{email}")]
        public async Task<ActionResult<List<string>>> ObtenerRoles(string email)
        {
            UserRolDTO rol = new()
            {
                Email = email
            };

            var usuario = await ObtenerUsuario(rol.Email);
            if (usuario == null)
            {
                return BadRequest("Usuario no existe");
            }

            IList<string> roles = await userManager.GetRolesAsync(usuario);

            if (roles == null)
            {
                return BadRequest("Usuario in Roles");
            }

            return roles.ToList();
        }

        [HttpGet("ExisteUsuario/{email}")]
        public async Task<bool> ExisteUsuario(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
                return true;
            else
                return false;
        }

        #endregion

        #region Metodos
        private async Task<User?> ObtenerUsuario(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        private async Task<TokenDTO> ConstruirToken(string email)
        {
            var expiracion = DateTime.UtcNow;
            User? usuario = await ObtenerUsuario(email);
            var claims = new List<Claim>();

            if (usuario != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, email));
                var roles = await userManager.GetRolesAsync(usuario!);
                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
                expiracion = DateTime.UtcNow.AddMinutes(minexpiracion);
            }

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtkey:llave"]!));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);


            var securityToken = new JwtSecurityToken(issuer: null,
                                                     audience: null,
                                                     claims: claims,
                                                     expires: expiracion,
                                                     signingCredentials: creds);

            return new TokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expira = expiracion
            };
        }

        private async Task<bool> AddRolUser(UserRolDTO rol)
        {
            var usuario = await ObtenerUsuario(rol.Email);
            if (usuario is null)
            {
                return false;
            }
            await userManager.AddToRoleAsync(usuario, rol.Rol);
            return true;
        }
        #endregion
    }
}
