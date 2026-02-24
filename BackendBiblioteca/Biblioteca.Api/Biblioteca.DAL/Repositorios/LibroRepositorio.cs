using Biblioteca.DAL.Data;
using Biblioteca.DAL.Repositorios.Interfaces;
using Biblioteca.Entitites.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.DAL.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly BibliotecaContext _context;

        public LibroRepositorio(BibliotecaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega un nuevo libro a la base de datos
        /// </summary>
        public async Task AddAsync(Libros libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retorna la cantidad total de libros registrados
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await _context.Libros.CountAsync();
        }

        /// <summary>
        /// Valida si el autor existe
        /// </summary>
        public async Task<bool> AutorExisteAsync(int autorId)
        {
            return await _context.Autores
                .AnyAsync(a => a.Id == autorId);
        }

        /// <summary>
        /// Obtiene todos los libros con su autor
        /// </summary>
        public async Task<List<Libros>> GetAllAsync()
        {
            return await _context.Libros
                .Include(l => l.Autor)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}