using ConsoleValidationDemo_FullValidator.Common;
using ConsoleValidationDemo_FullValidator.Exception;

namespace ConsoleValidationDemo_FullValidator.Validator
{
    public static class AmountValidator
    {
        public static void ValidateAmount(decimal amount)
        {
            if (amount < 0)
                throw new ValidationException(ErrorMessages.AmountNegative);

            if (amount > 1_000_000m)
                throw new ValidationException(ErrorMessages.AmountTooLarge);

            // Készítsen ide még más validálási szabályokat
        }
    }
}
