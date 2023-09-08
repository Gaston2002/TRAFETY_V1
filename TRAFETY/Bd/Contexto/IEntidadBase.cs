using TRAFETY.Shared.Enum;

namespace TRAFETY.Bd.Contexto
{
    public interface IEntidadBase
    {
        EnumEstadoRegistro EstadoRegistro { get; set; }
        DateTime? FechaBaja { get; set; }
        DateTime FechaCrea { get; set; }
        DateTime? FechaModif { get; set; }
        int Id { get; set; }
        string IdBaja { get; set; }
        string IdCrea { get; set; }
        string IdModif { get; set; }
        string Observacion { get; set; }
    }
}