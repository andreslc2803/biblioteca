using Biblioteca.BL.Exceptions;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Repositorios.Interfaces;
using Biblioteca.Entitites.DTOs;
using Biblioteca.Entitites.Entidades;
using Biblioteca.Entitites.Constantes;

namespace Biblioteca.BL.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepositorio _repo;

        public LibroService(ILibroRepositorio repo)
        {
            _repo = repo;
        }

        public async Task RegistrarLibroAsync(LibroDto dto)
        {
            // Regla 1: Validar autor
            if (!await _repo.AutorExisteAsync(dto.AutorId))
                throw new AutorNoExisteException();

            // Regla 2: Controlar máximo permitido
            var totalLibros = await _repo.CountAsync();

            if (totalLibros >= Parametros.MAX_LIBROS)
                throw new MaximoLibrosException();

            var libro = new Libros
            {
                Titulo = dto.Titulo,
                Anio = dto.Anio,
                Genero = dto.Genero,
                NumeroPaginas = dto.NumeroPaginas,
                AutorId = dto.AutorId
            };

            await _repo.AddAsync(libro);
        }

        public async Task<List<LibroDto>> ObtenerLibrosAsync()
        {
            var libros = await _repo.GetAllAsync();

            return libros.Select(l => new LibroDto
            {
                Titulo = l.Titulo,
                Anio = l.Anio,
                Genero = l.Genero,
                NumeroPaginas = l.NumeroPaginas,
                AutorId = l.AutorId
            }).ToList();
        }
    }
}