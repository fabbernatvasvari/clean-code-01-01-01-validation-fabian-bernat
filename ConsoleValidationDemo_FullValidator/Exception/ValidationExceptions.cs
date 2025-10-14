using System;

namespace ConsoleValidationDemo_FullValidator.Exception
{
    public sealed class ValidationExceptions : System.Exception
    {
        public ValidationExceptions(string message) : base(message) { }
    }
}
