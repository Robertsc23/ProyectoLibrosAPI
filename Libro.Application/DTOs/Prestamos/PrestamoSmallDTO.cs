using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Prestamos
{
    public class PrestamoSmallDTO
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public string NombreSolicitante { get; set; } = default!;
    }
}
