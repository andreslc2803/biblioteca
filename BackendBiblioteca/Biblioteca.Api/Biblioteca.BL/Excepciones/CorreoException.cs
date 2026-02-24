using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BL.Excepciones
{
    public class CorreoException : Exception
    {
        public CorreoException() 
            : base("El correo registrado ya existe, pruebe con otro")
        {
        }
    }
}
