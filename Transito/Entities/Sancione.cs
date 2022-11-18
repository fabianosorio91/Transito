using System;
using System.Collections.Generic;

namespace Transito.Entities
{
    public partial class Sancione
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; } = null!;
        public string? Observacion { get; set; }
        public decimal Valor { get; set; }
        public int ConductoresId { get; set; }

        public virtual Conductore Conductores { get; set; } = null!;
    }
}
