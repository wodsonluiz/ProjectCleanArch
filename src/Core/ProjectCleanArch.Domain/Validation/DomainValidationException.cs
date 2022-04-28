using System;

namespace ProjectCleanArch.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException() { }
        public DomainValidationException(string message) : base(message) { }
        public DomainValidationException(string message, Exception exception) : base(message, exception) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidationException(error);
        }
    }
}
