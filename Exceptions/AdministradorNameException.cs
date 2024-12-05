using System;

namespace CajemesFoodAlejandro_Aimara.Exceptions
{
    public class AdministradorNameException : Exception
    {
        public string Administradornombre { get; set; }


        public AdministradorNameException()
        {

        }

        public AdministradorNameException(string message) : base(message)
        {

        }

        public AdministradorNameException(string message, Exception inner) : base(message, inner)
        {

        }

        public AdministradorNameException(string message, string administradornombre) : this(message)
        {
            Administradornombre = administradornombre;
        }
    }
}
