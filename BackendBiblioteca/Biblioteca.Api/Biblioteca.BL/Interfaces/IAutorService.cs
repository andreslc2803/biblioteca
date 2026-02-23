using Biblioteca.Entitites.DTOs;

namespace Biblioteca.BL.Interfaces
{
    public interface IAutorService
    {
        Task RegistrarAutorAsync(AutorDto dto);
        Task<List<AutorDto>> ObtenerAutoresAsync();
        Task<AutorDto?> ObtenerPorIdAsync(int id);
    }
}
