using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.DTOs.Solicitantes
{
    public class SolicitanteDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = default!;
        public string DocumentoIdentidad { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Telefono { get; set; } = default!;
    }
}
