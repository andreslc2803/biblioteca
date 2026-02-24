using Biblioteca.BL.Excepciones;
using Biblioteca.BL.Interfaces;
using Biblioteca.DAL.Repositorios.Interfaces;
using Biblioteca.Entitites.DTOs;
using Biblioteca.Entitites.Entidades;

namespace Biblioteca.BL.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepositorio _repo;

        public AutorService(IAutorRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<AutorDto> RegistrarAutorAsync(AutorDto dto)
        {
            if (await _repo.ExistsByEmailAsync(dto.CorreoElectronico))
                throw new CorreoException();

            var autor = new Autores
            {
                NombreCompleto = dto.NombreCompleto,
                FechaNacimiento = dto.FechaNacimiento,
                CiudadProcedencia = dto.CiudadProcedencia,
                CorreoElectronico = dto.CorreoElectronico
            };

            await _repo.AddAsync(autor);

            // Retornar DTO actualizado con Id generado
            dto.Id = autor.Id;
            return dto;
        }

        public async Task<List<AutorDto>> ObtenerAutoresAsync()
        {
            var autores = await _repo.GetAllAsync();

            return autores.Select(a => new AutorDto
            {
                Id = a.Id,
                NombreCompleto = a.NombreCompleto,
                FechaNacimiento = a.FechaNacimiento,
                CiudadProcedencia = a.CiudadProcedencia,
                CorreoElectronico = a.CorreoElectronico
            }).ToList();
        }

        public async Task<AutorDto?> ObtenerPorIdAsync(int id)
        {
            var autor = await _repo.GetByIdAsync(id);

            if (autor == null)
                return null;

            return new AutorDto
            {
                Id = autor.Id,
                NombreCompleto = autor.NombreCompleto,
                FechaNacimiento = autor.FechaNacimiento,
                CiudadProcedencia = autor.CiudadProcedencia,
                CorreoElectronico = autor.CorreoElectronico
            };
        }
    }
}