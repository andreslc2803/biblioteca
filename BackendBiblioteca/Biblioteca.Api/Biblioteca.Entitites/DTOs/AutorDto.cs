using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entitites.DTOs
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
    }
}
