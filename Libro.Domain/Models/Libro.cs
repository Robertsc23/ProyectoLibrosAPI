using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Isbn { get; set; } = default!;
        public string Titulo { get; set; } = default!;
        public string Autores { get; set; } = default!;
        public string Edicion { get; set; } = default!;
        public int Anio { get; set; }
        public int IdEditorial { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

       
        public virtual Editorial? Editorial { get; set; }
        
    }
}
