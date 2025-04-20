using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.DTOs.Editoriales;
using Proyecto.Application.Services;

namespace Proyecto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;

        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditorialDTO>>> Get()
        {
            var editoriales = await _editorialService.FindAllAsync();
            return Ok(editoriales);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<EditorialDTO>> GetById(int id)
        {
            var editorial = await _editorialService.FindByIdAsync(id);
            if(editorial == null)
            {
                return NotFound(new { message = $"editorial con Id {id} no encontrado o ha sido eliminado" });

            }
            return Ok(editorial);
        }

        
        [HttpPost]
        public async Task<ActionResult<EditorialDTO>> Create([FromBody] EditorialBodyDTO editorialBodyDTO)
        {
            var editorial = await _editorialService.CreateAsync(editorialBodyDTO);
            return CreatedAtAction(nameof(GetById), new { id = editorial.Id }, editorial);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<EditorialDTO>> Update(int id, [FromBody] EditorialBodyDTO editorialBodyDTO)
        {
            var editorial = await _editorialService.UpdateAsync(id, editorialBodyDTO);
            return Ok(editorial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _editorialService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new { message = $"Editorial con ID {id} no encontrada." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}/libros")]
        public async Task<IActionResult> GetLibrosByEditorialId(int id)
        {
            var libros = await _editorialService.FindLibrosByEditorialIdAsync(id);

            if (libros == null || libros.Count == 0)
            {
                return NotFound(new { message = $"no se encontraron libros para la editorial con ID {id}." });
            }

            return Ok(libros);
        }


    }
}
