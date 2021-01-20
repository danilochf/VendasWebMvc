using System;

namespace VendasWebMvc.Servicos.Exceptions
{
    public class DbConcurrencyException : ApplicationException 
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
