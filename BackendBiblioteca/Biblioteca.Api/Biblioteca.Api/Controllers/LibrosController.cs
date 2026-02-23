using Biblioteca.BL.Interfaces;
using Biblioteca.Entitites.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibrosController(ILibroService service)
        {
            _service = service;
        }

        /// <summary>
        /// Registrar un nuevo libro
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] LibroDto dto)
        {
            await _service.RegistrarLibroAsync(dto);
            return StatusCode(201, "Libro registrado correctamente");
        }

        /// <summary>
        /// Obtener todos los libros
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var libros = await _service.ObtenerLibrosAsync();
            return Ok(libros);
        }
    }
}