using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.DTOs.Prestamos;
using Proyecto.Application.Services;

namespace Proyecto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoSmallDTO>>> Get()
        {
            var prestamos = await _prestamoService.FindAllAsync();
            return Ok(prestamos);
        }

        
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<PrestamoSmallDTO>>> GetPrestamosActivos()
        {
            var prestamos = await _prestamoService.FindPrestamosActivosAsync();
            return Ok(prestamos);
        }

        
        [HttpGet("vencidos")]
        public async Task<ActionResult<IEnumerable<PrestamoSmallDTO>>> GetPrestamosVencidos()
        {
            var prestamos = await _prestamoService.FindPrestamosVencidosAsync();
            return Ok(prestamos);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoDTO>> GetById(int id)
        {
            var prestamo = await _prestamoService.FindByIdAsync(id);
            return Ok(prestamo);
        }

        
        [HttpPost]
        public async Task<ActionResult<PrestamoDTO>> Create([FromBody] PrestamoBodyDTO prestamoBodyDTO)
        {
            var prestamo = await _prestamoService.CreateAsync(prestamoBodyDTO);
            return CreatedAtAction(nameof(GetById), new { id = prestamo.Id }, prestamo);
        }

        // PUT: api/prestamos/5/devolver
        [HttpPut("{id}/devolver")]
        public async Task<ActionResult> Devolver(int id)
        {
            await _prestamoService.MarcarDevolucionAsync(id);
            return NoContent();
        }

  
        [HttpPut("{id}/extender")]
        public async Task<ActionResult> Extender(int id, [FromQuery] DateTime nuevaFecha)
        {
            await _prestamoService.ExtenderDevolucionAsync(id, nuevaFecha);
            return Ok(new { message = "fecha de devolución extendido correctamente." });
        }
    }
}
