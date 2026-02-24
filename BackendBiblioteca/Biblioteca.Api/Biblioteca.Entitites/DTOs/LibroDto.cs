using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entitites.DTOs
{
    public class LibroDto
    {
        public string Titulo { get; set; } = null!;
        public int Anio { get; set; }
        public string Genero { get; set; } = null!;
        public int NumeroPaginas { get; set; }
        public int AutorId { get; set; }
    }
}
