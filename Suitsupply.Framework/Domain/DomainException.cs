using System;

namespace Suitsupply.Framework.Domain
{
    public class DomainException : ApplicationException
    {
        protected DomainException()
        {
        }

        protected DomainException(string message) : base(message)
        {
        }

        protected DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}