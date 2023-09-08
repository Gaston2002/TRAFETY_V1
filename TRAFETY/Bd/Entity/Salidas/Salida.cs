using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.TTipo;

namespace TRAFETY.Bd.Entity.Salidas
{
    [Index(nameof(Codigo), Name = "OrgSalida_Codigo_UQ", IsUnique = true)]
    public class Salida : ActorBase
    {
        [Required(ErrorMessage = "El código es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El código tiene como máximo {1} caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Falta datos del responsable de organizar la salida.")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        public Point? PuntoSalida { get; set; }
        public Point? PuntoLlegada { get; set; }

        [Required(ErrorMessage = "Tipo de organización incorrecto.")]
        public int TOrganizacionId { get; set; }
        public TOrganizacion TOrganizacion { get; set; }

        [Required(ErrorMessage = "Actividad incorrecta.")]
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }

        public int? GuiaId { get; set; }
        public Guia Guia { get; set; }

        [Required(ErrorMessage = "Guía incorrecto.")]
        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public List<SalidaGuia> SalidaGuias { get; set; }

        public List<SalidaDoc> SalidaDocs { get; set; }

        public List<SalidaProgramada> SalidaProgramadas { get; set; }

        public List<SalidaStaff> SalidaStaffs { get; set; }
    }
}
