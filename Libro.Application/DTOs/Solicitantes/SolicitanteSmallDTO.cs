using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Solicitantes
{
    public class SolicitanteSmallDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
