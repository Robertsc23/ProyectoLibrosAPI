using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Domain.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int EstadoPrestamo { get; set; }
        public int IdSolicitante { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

       
        public virtual Solicitante? Solicitante { get; set; }
      
    }
}
