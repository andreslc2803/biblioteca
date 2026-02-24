namespace Biblioteca.BL.Exceptions
{
    public class AutorNoExisteException : Exception
    {
        public AutorNoExisteException()
            : base("El autor no está registrado")
        {
        }
    }
}