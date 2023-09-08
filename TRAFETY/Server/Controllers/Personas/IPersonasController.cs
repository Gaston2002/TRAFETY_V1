using Microsoft.AspNetCore.Mvc;
using TRAFETY.Shared.DTO.Personas;

namespace TRAFETY.Server.Controllers.Actores
{
    public interface IPersonasController
    {
        Task<ActionResult> Baja(int id);
        Task<ActionResult<PersonaDTO>> Get(int id);
        Task<ActionResult<List<PersonaDTO>>> GetActivos();
        Task<ActionResult<List<PersonaDTO>>> GetFull();
        Task<ActionResult<int>> Post(PersonaDTO dto);
        Task<ActionResult<bool>> Put(PersonaDTO dto, int id);
    }
}