namespace Transito.DTO
{
    public class MatriculaDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool? Activo { get; set; }
    }
}
