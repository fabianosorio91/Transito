using System;
using System.Collections.Generic;

namespace Transito.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Conductores = new HashSet<Conductore>();
        }

        public int Id { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Conductore> Conductores { get; set; }
    }
}
