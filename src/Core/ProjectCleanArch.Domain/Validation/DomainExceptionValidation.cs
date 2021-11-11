using System;

namespace ProjectCleanArch.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation() { }
        public DomainExceptionValidation(string message) : base(message) { }
        public DomainExceptionValidation(string message, Exception exception) : base(message, exception) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
