using AutoMapper;
using Proyecto.Application.DTOs.Prestamos;
using Proyecto.Application.Helpers;
using Proyecto.Domain.Models;
using Proyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services.Implementations
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMapper _mapper;

        public PrestamoService(IPrestamoRepository prestamoRepository, IMapper mapper)
        {
            _prestamoRepository = prestamoRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PrestamoSmallDTO>> FindAllAsync()
        {
            var prestamos = await _prestamoRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PrestamoSmallDTO>>(prestamos);
        }

        public async Task<IReadOnlyList<PrestamoSmallDTO>> FindPrestamosActivosAsync()
        {
            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: x => x.EstadoPrestamo == 0
            );
            return _mapper.Map<IReadOnlyList<PrestamoSmallDTO>>(prestamos);
        }

        public async Task<IReadOnlyList<PrestamoSmallDTO>> FindPrestamosVencidosAsync()
        {
            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: x => x.FechaDevolucion < DateTime.Now && x.EstadoPrestamo == 0
            );
            return _mapper.Map<IReadOnlyList<PrestamoSmallDTO>>(prestamos);
        }

        public async Task<PrestamoDTO> FindByIdAsync(int id)
        {
            var prestamo = await _prestamoRepository.FindByIdAsync(id);
            if (prestamo == null) throw new Exception("Préstamo no encontrado");

            return _mapper.Map<PrestamoDTO>(prestamo);
        }

        public async Task<PrestamoDTO> CreateAsync(PrestamoBodyDTO prestamoBodyDTO)
        {

            var prestamo = _mapper.Map<Prestamo>(prestamoBodyDTO);

            
            prestamo.FechaPrestamo = DateTimeHelper.Normalize(DateTime.Now); // Fecha actual
            prestamo.FechaDevolucion = DateTimeHelper.Normalize(prestamo.FechaDevolucion);
            prestamo.FechaRegistro = DateTimeHelper.Normalize(DateTime.Now);

            prestamo.EstadoPrestamo = 0; // Prestado
            prestamo.Estado = 1;         // Activo

            var entity = await _prestamoRepository.SaveAsync(prestamo);

            return _mapper.Map<PrestamoDTO>(entity);

        }


        public async Task<bool> MarcarDevolucionAsync(int id)
        {
            var prestamo = await _prestamoRepository.FindByIdAsync(id);
            if (prestamo == null) return false;

            prestamo.EstadoPrestamo = 1;
            await _prestamoRepository.SaveAsync(prestamo);

            return true;
        }

        public async Task<bool> ExtenderDevolucionAsync(int id, DateTime nuevaFecha)
        {
            var prestamo = await _prestamoRepository.FindByIdAsync(id);
            if (prestamo == null) return false;

            prestamo.FechaDevolucion = nuevaFecha;
            await _prestamoRepository.SaveAsync(prestamo);

            return true;
        }
    }
}
