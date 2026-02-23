using Biblioteca.Entitites.Entidades;

namespace Biblioteca.DAL.Repositorios.Interfaces
{
    public interface IAutorRepositorio
    {
        Task AddAsync(Autores autor);
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<Autores?> GetByIdAsync(int id);
        Task<List<Autores>> GetAllAsync();
    }
}
