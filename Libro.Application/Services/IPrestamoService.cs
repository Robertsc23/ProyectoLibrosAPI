using Proyecto.Application.DTOs.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services
{
    public  interface IPrestamoService
    {
        Task<IReadOnlyList<PrestamoSmallDTO>> FindAllAsync();
        Task<IReadOnlyList<PrestamoSmallDTO>> FindPrestamosActivosAsync();
        Task<IReadOnlyList<PrestamoSmallDTO>> FindPrestamosVencidosAsync();
        Task<PrestamoDTO> FindByIdAsync(int id);
        Task<PrestamoDTO> CreateAsync(PrestamoBodyDTO prestamoBodyDTO);
        Task<bool> MarcarDevolucionAsync(int id);
        Task<bool> ExtenderDevolucionAsync(int id, DateTime nuevaFecha);
    }
}
