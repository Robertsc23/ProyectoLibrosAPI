using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Models
{
    public class Solicitante
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = default!;
        public string DocumentoIdentidad { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Telefono { get; set; } = default!;
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        
        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
