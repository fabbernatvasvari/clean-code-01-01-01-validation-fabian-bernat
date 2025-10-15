using System;

namespace ConsoleValidationDemo_FullValidator.Exception
{
    public sealed class ValidationException : System.Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
