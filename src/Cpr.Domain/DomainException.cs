using System;

namespace Cpr.Domain
{
    public class DomainException : Exception 
    {
        public DomainException(string error) : base(error)
        {

        }
        public static void when (bool hasError, string error)
        {
            if(hasError)
                throw new DomainException(error);
        }
    }
}