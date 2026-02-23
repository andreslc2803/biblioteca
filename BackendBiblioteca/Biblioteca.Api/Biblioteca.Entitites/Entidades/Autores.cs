using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entitites.Entidades
{
    public class Autores
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;

        public ICollection<Libros> Libros { get; set; } = new List<Libros>();
    }
}
