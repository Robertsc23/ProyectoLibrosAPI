using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Libros
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Isbn { get; set; }  = default!;
        public string Titulo { get; set; } = default!;
        public string Autores { get; set; } = default!;
    }
}
