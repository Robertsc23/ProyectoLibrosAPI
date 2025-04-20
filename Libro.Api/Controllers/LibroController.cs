using Microsoft.AspNetCore.Mvc;
using Proyecto.Application.DTOs.Libros;
using Proyecto.Application.Services;

namespace Proyecto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroSmallDTO>>> Get()
        {
            var libros = await _libroService.FindAllAsync();
            return Ok(libros);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var libro = await _libroService.FindByIdAsync(id);
            if (libro == null)
            {
                return NotFound(new { message = $"libro con Id {id} no encontrado o ha sido eliminado" });
            }
            return Ok(libro);
        }

        [HttpGet("editorial/{editorialId}")]
        public async Task<IActionResult> GetByEditorialId(int editorialId)
        {
            var libros = await _libroService.FindByEditorialIdAsync(editorialId);

            if (libros == null || libros.Count == 0)
            {
                return NotFound(new { message = $"no se encontraron libros para la editorial con ID {editorialId}" });
            }

            return Ok(libros);

        }
        [HttpGet("autor/{autor}")]
        public async Task<IActionResult> GetByAutor(string autor)
        {
            var libros = await _libroService.FindByAutorAsync(autor);

            if (libros == null || libros.Count == 0)
            {
                return NotFound(new { message = $"no se encontraron libros para el autor '{autor}'" });
            }

            return Ok(libros);
        }


        
        [HttpPost]
        public async Task<ActionResult<LibroDTO>> Create([FromBody] LibroBodyDTO libroBodyDTO)
        {
            var libro = await _libroService.CreateAsync(libroBodyDTO);
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<LibroDTO>> Update(int id, [FromBody] LibroBodyDTO libroBodyDTO)
        {
            var libro = await _libroService.UpdateAsync(id, libroBodyDTO);
            return Ok(libro);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _libroService.DeleteAsync(id);
            return NoContent();
        }
       

    }
}
