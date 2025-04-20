using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.DTOs.Solicitantes;
using Proyecto.Application.Services;

namespace Proyecto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitanteController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;

        public SolicitanteController(ISolicitanteService solicitanteService)
        {
            _solicitanteService = solicitanteService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitanteSmallDTO>>> Get()
        {
            var solicitantes = await _solicitanteService.FindAllAsync();
            return Ok(solicitantes);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitanteDTO>> GetById(int id)
        {
            var solicitante = await _solicitanteService.FindByIdAsync(id);
            return Ok(solicitante);
        }

        
        [HttpPost]
        public async Task<ActionResult<SolicitanteDTO>> Create([FromBody] SolicitanteBodyDTO solicitanteBodyDTO)
        {
            var solicitante = await _solicitanteService.CreateAsync(solicitanteBodyDTO);
            return CreatedAtAction(nameof(GetById), new { id = solicitante.Id }, solicitante);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<SolicitanteDTO>> Update(int id, [FromBody] SolicitanteBodyDTO solicitanteBodyDTO)
        {
            var solicitante = await _solicitanteService.UpdateAsync(id, solicitanteBodyDTO);
            return Ok(solicitante);
        }

        [HttpGet("{id}/prestamos")]
        public async Task<IActionResult> GetPrestamosBySolicitanteId(int id)
        {
            var prestamos = await _solicitanteService.FindPrestamosBySolicitanteIdAsync(id);

            return Ok(prestamos);
        }
    }
}
