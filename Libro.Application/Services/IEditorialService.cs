using Proyecto.Application.DTOs.Editoriales;
using Proyecto.Application.DTOs.Libros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services
{
    public interface IEditorialService
    {
        Task<IReadOnlyList<EditorialDTO>> FindAllAsync();
        Task<EditorialDTO> FindByIdAsync(int id);
        Task<EditorialDTO> CreateAsync(EditorialBodyDTO editorialBodyDTO);
       
        Task<EditorialDTO> UpdateAsync(int id, EditorialBodyDTO editorialBodyDTO);
        Task<bool> DeleteAsync(int id);
        Task<IReadOnlyList<LibroSmallDTO>> FindLibrosByEditorialIdAsync(int editorialId);
    }
}
