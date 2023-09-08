using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRAFETY.Bd.Contexto;

namespace TRAFETY.Bd.Entity.Personas
{
    [Index(nameof(NomDoc), Name = "GuiaDoc_NomDoc_UQ", IsUnique = true)]
    public class GuiaDoc : DocBase
    {
        [Required(ErrorMessage = "El guía al que pertenece el documento es obligatorio.")]
        public int GuiaId { get; set; }
        public Guia Guia { get; set; }
    }
}
