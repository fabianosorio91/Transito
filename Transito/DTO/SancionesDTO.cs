namespace Transito.DTO
{
    public class SancionesDTO
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; } = null!;
        public string? Observacion { get; set; }
        public decimal Valor { get; set; }
        public int ConductoresId { get; set; }
    }
}
