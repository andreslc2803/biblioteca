using Biblioteca.Entitites.Entidades;

namespace Biblioteca.DAL.Repositorios.Interfaces
{
    public interface ILibroRepositorio
    {
        Task AddAsync(Libros libro);
        Task<int> CountAsync();
        Task<bool> AutorExisteAsync(int autorId);
        Task<List<Libros>> GetAllAsync();
    }
}
