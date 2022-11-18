namespace Transito.DTO
{
    public class ConductorDTO
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool? Activo { get; set; }
        public int? MatriculaId { get; set; }
    }
}
