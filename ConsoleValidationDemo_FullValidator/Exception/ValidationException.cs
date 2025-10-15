using System;

namespace ConsoleValidationDemo_FullValidator.MyException
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
