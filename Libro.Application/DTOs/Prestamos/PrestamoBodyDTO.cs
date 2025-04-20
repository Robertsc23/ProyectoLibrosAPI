using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Prestamos
{
    public class PrestamoBodyDTO
    {
        public int IdSolicitante { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
