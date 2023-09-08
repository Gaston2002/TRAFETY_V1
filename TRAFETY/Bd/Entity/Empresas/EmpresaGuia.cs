using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Empresas
{
    [Index(nameof(EmpresaId), nameof(GuiaId), Name = "EmpresaContacto_EmpresaId_GuiaId_UQ", IsUnique = true)]
    public class EmpresaGuia : EntidadBase
    {
        [Required(ErrorMessage = "La Empresa es obligatoria.")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "La persona que es guía de la empresa es obligatoria.")]
        public int GuiaId { get; set; }
        public Guia Guia { get; set; }
    }
}
