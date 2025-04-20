using AutoMapper;
using Proyecto.Application.DTOs.Editoriales;
using Proyecto.Application.DTOs.Libros;
using Proyecto.Domain.Models;
using Proyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services.Implementations
{
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository _editorialRepository;
        private readonly IMapper _mapper;
        private readonly ILibroRepository _libroRepository;


        public EditorialService(IEditorialRepository editorialRepository, IMapper mapper, ILibroRepository libroRepository)
        {
            _editorialRepository = editorialRepository;
            _mapper = mapper;
            _libroRepository = libroRepository;
        }

        public async Task<IReadOnlyList<EditorialDTO>> FindAllAsync()
        {
            var editorials = await _editorialRepository.FindAllAsync(
             predicate: x => x.Estado == 1   );
            return _mapper.Map<IReadOnlyList<EditorialDTO>>(editorials);
        }

        public async Task<EditorialDTO> FindByIdAsync(int id)
        {
            var editorial = await _editorialRepository.FindFirstOrDefaultAsync(
               predicate: x=> x.Id ==id && x.Estado ==1);
            if (editorial == null) return null;

            return _mapper.Map<EditorialDTO>(editorial);
        }

        public async Task<EditorialDTO> CreateAsync(EditorialBodyDTO editorialBodyDTO)
        {
            var editorial = _mapper.Map<Editorial>(editorialBodyDTO);
            editorial.FechaRegistro = DateTime.Now;
            editorial.Estado = 1;
            var result = await _editorialRepository.SaveAsync(editorial);
            return _mapper.Map<EditorialDTO>(result);
        }

        public async Task<EditorialDTO> UpdateAsync(int id, EditorialBodyDTO editorialBodyDTO)
        {
            var editorial = await _editorialRepository.FindByIdAsync(id);
            if (editorial == null) throw new Exception("Editorial not found");

            _mapper.Map(editorialBodyDTO, editorial);
            var result = await _editorialRepository.SaveAsync(editorial);

            return _mapper.Map<EditorialDTO>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var editorial = await _editorialRepository.FindByIdAsync(id);

            if (editorial == null)
                return false;

            var librosAsociados = await _libroRepository.FindAllAsync(
                predicate: x => x.IdEditorial == id && x.Estado == 1
            );

            if (librosAsociados != null && librosAsociados.Count > 0)
            {
                throw new Exception("No se puede eliminar la editorial porque tiene libros asociados.");
            }          
            editorial.Estado = 0;
            editorial.FechaRegistro = DateTime.Now;

            await _editorialRepository.SaveAsync(editorial);

            return true;
        }

        public async Task<IReadOnlyList<LibroSmallDTO>> FindLibrosByEditorialIdAsync(int editorialId)
        {
            var libros = await _libroRepository.FindAllAsync(
                predicate: x => x.IdEditorial == editorialId && x.Estado == 1
            );

            return _mapper.Map<IReadOnlyList<LibroSmallDTO>>(libros);
        }
    }
}
