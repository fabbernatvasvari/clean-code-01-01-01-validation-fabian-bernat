using ConsoleValidationDemo_FullValidator.Common;
using System.ComponentModel.DataAnnotations;


namespace ConsoleValidationDemo_FullValidator.Validator
{
    public static class EmailValidator
    {
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException(ErrorMessages.EmailEmptyOrNull);

            // Készítsen ide még más validálási szabályokat

        }
    }
}
