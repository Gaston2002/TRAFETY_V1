using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Salidas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Empresas
{
    [Index(nameof(Licencia), Name = "EmpresaLicencia_UQ", IsUnique = true)]

    public class Empresa : ActorBase
    {
        [Required(ErrorMessage = "La licencia es obligatoria.")]
        [MaxLength(50, ErrorMessage = "La licencia tiene como máximo {1} caracteres.")]
        public string Licencia { get; set; }

        [Required(ErrorMessage = "Tipo de empresa incorrecto.")]
        public int TEmpresaId { get; set; }
        public TEmpresa TEmpresa { get; set; }

        public List<EmpresaGuia> EmpresaGuias { get; set; }

        public List<EmpresaStaff> EmpresaStaff { get; set; }

        public List<Salida> Salidas { get; set; }
    }
}
