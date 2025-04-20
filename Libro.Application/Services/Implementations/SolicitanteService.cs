using AutoMapper;
using Proyecto.Application.DTOs.Prestamos;
using Proyecto.Application.DTOs.Solicitantes;
using Proyecto.Domain.Models;
using Proyecto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Services.Implementations
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _solicitanteRepository;
        private readonly IMapper _mapper;
        private readonly IPrestamoRepository _prestamoRepository;


        public SolicitanteService(ISolicitanteRepository solicitanteRepository, IMapper mapper, IPrestamoRepository prestamoRepository)
        {
            _solicitanteRepository = solicitanteRepository;
            _mapper = mapper;
            _prestamoRepository = prestamoRepository;
        }

        public async Task<IReadOnlyList<SolicitanteSmallDTO>> FindAllAsync()
        {
            var solicitantes = await _solicitanteRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<SolicitanteSmallDTO>>(solicitantes);
        }

        public async Task<SolicitanteDTO> FindByIdAsync(int id)
        {
            var solicitante = await _solicitanteRepository.FindByIdAsync(id);
            if (solicitante == null) throw new Exception("Solicitante no encontrado");

            return _mapper.Map<SolicitanteDTO>(solicitante);
        }

        public async Task<SolicitanteDTO> CreateAsync(SolicitanteBodyDTO solicitanteBodyDTO)
        {
            var solicitante = _mapper.Map<Solicitante>(solicitanteBodyDTO);

            
            solicitante.FechaRegistro = DateTime.Now;
            solicitante.Estado = 1; // Si manejas Estado = 1 para activo

            var entity = await _solicitanteRepository.SaveAsync(solicitante);

            return _mapper.Map<SolicitanteDTO>(entity);
        }

        public async Task<SolicitanteDTO> UpdateAsync(int id, SolicitanteBodyDTO solicitanteBodyDTO)
        {
            var solicitante = await _solicitanteRepository.FindByIdAsync(id);
            if (solicitante == null) throw new Exception("Solicitante no encontrado");

            _mapper.Map(solicitanteBodyDTO, solicitante);
            var result = await _solicitanteRepository.SaveAsync(solicitante);

            return _mapper.Map<SolicitanteDTO>(result);
        }

       
        public async Task<IReadOnlyList<PrestamoDTO>> FindPrestamosBySolicitanteIdAsync(int solicitanteId)
        {
            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: x => x.IdSolicitante == solicitanteId
            );

            return _mapper.Map<IReadOnlyList<PrestamoDTO>>(prestamos);
        }
    }
}
