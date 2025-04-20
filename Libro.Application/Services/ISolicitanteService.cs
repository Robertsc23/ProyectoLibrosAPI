using Proyecto.Application.DTOs.Prestamos;
using Proyecto.Application.DTOs.Solicitantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services
{
    public interface ISolicitanteService
    {
        Task<IReadOnlyList<SolicitanteSmallDTO>> FindAllAsync();
        Task<SolicitanteDTO> FindByIdAsync(int id);
        Task<SolicitanteDTO> CreateAsync(SolicitanteBodyDTO solicitanteBodyDTO);
        Task<SolicitanteDTO> UpdateAsync(int id, SolicitanteBodyDTO solicitanteBodyDTO);
        Task<IReadOnlyList<PrestamoDTO>> FindPrestamosBySolicitanteIdAsync(int solicitanteId);

        
    }
}
