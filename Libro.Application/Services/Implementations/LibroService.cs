using AutoMapper;
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
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LibroSmallDTO>> FindAllAsync()
        {
            var libros = await _repository.FindAllAsync(
             predicate: x => x.Estado == 1 );
            return _mapper.Map<IReadOnlyList<LibroSmallDTO>>(libros);
        }

        public async Task<LibroDTO> FindByIdAsync(int id)
        {
            var libro = await _repository.FindFirstOrDefaultAsync(
            predicate: x => x.Id == id && x.Estado == 1 
            );
            if (libro == null)
            {
                return null;
            }
            return _mapper.Map<LibroDTO>(libro);
        }
        public async Task<IReadOnlyList<LibroSmallDTO>> FindLibrosByEditorialIdAsync(int editorialId)
        {
            var libros = await _repository.FindAllAsync(
                predicate: x => x.IdEditorial == editorialId && x.Estado == 1
            );

            return _mapper.Map<IReadOnlyList<LibroSmallDTO>>(libros);
        }
        public async Task<IReadOnlyList<LibroSmallDTO>> FindByAutorAsync(string autor)
        {
            var libros = await _repository.FindAllAsync(
                predicate: x => x.Estado == 1 && x.Autores.ToLower().Contains(autor.ToLower())
            );

            return _mapper.Map<IReadOnlyList<LibroSmallDTO>>(libros);
        }
        public async Task<IReadOnlyList<LibroSmallDTO>> FindByEditorialIdAsync(int editorialId)
        {
            var libros = await _repository.FindAllAsync(
                predicate: x => x.IdEditorial == editorialId && x.Estado == 1
            );

            return _mapper.Map<IReadOnlyList<LibroSmallDTO>>(libros);
        }

        public async Task<LibroDTO> CreateAsync(LibroBodyDTO dto)
        {
            var libro = _mapper.Map<Libro>(dto);
            libro.FechaRegistro = DateTime.Now;
            libro.Estado = 1;
            var entity = await _repository.SaveAsync(libro);
            return _mapper.Map<LibroDTO>(entity);
        }
        public async Task<LibroDTO> UpdateAsync(int id, LibroBodyDTO dto)
        {
            var existing = await _repository.FindByIdAsync(id);
            if (existing == null) throw new Exception("Libro no encontrado");

            var entity = _mapper.Map(dto, existing);
            var updated = await _repository.SaveAsync(entity);

            return _mapper.Map<LibroDTO>(updated);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var libro = await _repository.FindByIdAsync(id);

            if (libro == null)
                return false;

            libro.Estado = 0;
            libro.FechaRegistro = DateTime.Now;

            await _repository.SaveAsync(libro);

            return true;
        }
    }
}
