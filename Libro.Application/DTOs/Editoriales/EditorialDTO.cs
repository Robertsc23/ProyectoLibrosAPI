using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Editoriales
{
    public class EditorialDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
    }
}
