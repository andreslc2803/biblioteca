using Biblioteca.DAL.Data;
using Biblioteca.DAL.Repositorios.Interfaces;
using Biblioteca.Entitites.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.DAL.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly BibliotecaContext _context;

        public AutorRepositorio(BibliotecaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega un nuevo autor
        /// </summary>
        public async Task AddAsync(Autores autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Valida si existe un autor por Id
        /// </summary>
        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context.Autores
                .AnyAsync(a => a.Id == id);
        }

        /// <summary>
        /// Valida si existe un autor por correo electrónico
        /// </summary>
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Autores
                .AnyAsync(a => a.CorreoElectronico == email);
        }

        /// <summary>
        /// Obtiene un autor por Id
        /// </summary>
        public async Task<Autores?> GetByIdAsync(int id)
        {
            return await _context.Autores
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        /// Obtiene todos los autores
        /// </summary>
        public async Task<List<Autores>> GetAllAsync()
        {
            return await _context.Autores
                .AsNoTracking()
                .ToListAsync();
        }
    }
}