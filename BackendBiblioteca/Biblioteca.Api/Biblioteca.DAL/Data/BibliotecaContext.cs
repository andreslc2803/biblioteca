using Biblioteca.Entitites.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.DAL.Data
{
    public class BibliotecaContext : DbContext
    {

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        public DbSet<Autores> Autores { get; set; }
        public DbSet<Libros> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>()
                .HasIndex(a => a.CorreoElectronico)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }

}
