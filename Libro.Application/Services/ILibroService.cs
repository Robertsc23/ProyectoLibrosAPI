using Proyecto.Application.DTOs.Libros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services
{
   public interface ILibroService
    {
        Task<IReadOnlyList<LibroSmallDTO>> FindAllAsync();
        Task<LibroDTO> FindByIdAsync(int id);
        Task<IReadOnlyList<LibroSmallDTO>> FindByAutorAsync(string autor);

        Task<IReadOnlyList<LibroSmallDTO>> FindByEditorialIdAsync(int editorialId);
        Task<LibroDTO> CreateAsync(LibroBodyDTO dto);
        Task<LibroDTO> UpdateAsync(int id, LibroBodyDTO dto);
        
        Task<bool> DeleteAsync(int id);
    }
}
