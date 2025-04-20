using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

      
        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
