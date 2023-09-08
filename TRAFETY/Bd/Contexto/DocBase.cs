using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Personas;

namespace TRAFETY.Bd.Contexto
{
    public class DocBase : EntidadBase
    {
        [Required(ErrorMessage = "Definir la fecha del documento del documento es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [MaxLength(800, ErrorMessage = "Longitud Maxima de la descripción del documento es de {1} caracteres")]
        public string Descripcion { get; set; } = "";

        [Required(ErrorMessage = "El Nombre del Documento es obligatorio.")]
        [MaxLength(300, ErrorMessage = "Longitud Maxima del Nombre del Documento es de {1} caracteres")]
        public string NomDoc { get; set; } = "";

        [Required(ErrorMessage = "El Path del docuemnto es obligatorio.")]
        [MaxLength(800, ErrorMessage = "Longitud Maxima del path es de {1} caracteres")]
        public string PathDoc { get; set; }

        public string Obs { get; set; } = "";
    }
}
