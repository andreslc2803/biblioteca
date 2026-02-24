using Biblioteca.Entitites.DTOs;

namespace Biblioteca.BL.Interfaces
{
    public interface ILibroService
    {
        Task RegistrarLibroAsync(LibroDto dto);
        Task<List<LibroDto>> ObtenerLibrosAsync();
    }
}
