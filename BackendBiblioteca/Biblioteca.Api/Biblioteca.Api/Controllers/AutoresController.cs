using Biblioteca.BL.Interfaces;
using Biblioteca.Entitites.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _service;

        public AutoresController(IAutorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Registrar un nuevo autor
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] AutorDto dto)
        {
            await _service.RegistrarAutorAsync(dto);
            return StatusCode(201, "Autor registrado correctamente");
        }

        /// <summary>
        /// Obtener todos los autores
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var autores = await _service.ObtenerAutoresAsync();
            return Ok(autores);
        }

        /// <summary>
        /// Obtener autor por Id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var autor = await _service.ObtenerPorIdAsync(id);

            if (autor == null)
                return NotFound("Autor no encontrado");

            return Ok(autor);
        }
    }
}