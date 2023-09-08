using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Empresas
{
    [Index(nameof(EmpresaId), nameof(PersonaId), Name = "EmpresaStaff_EmpresaId_PersonaId_UQ", IsUnique = true)]
    public class EmpresaStaff : EntidadBase
    {
        [Required(ErrorMessage = "La Empresa es obligatoria.")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "La persona que es de la empresa es obligatoria.")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        [Required(ErrorMessage = "Tipo de contacto incorrecto.")]
        public int TStaffId { get; set; }
        public TStaff TStaff { get; set; }
    }
}
