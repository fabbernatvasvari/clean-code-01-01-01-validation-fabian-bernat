using ConsoleValidationDemo_FullValidator.Common;
using ConsoleValidationDemo_FullValidator.MyException;

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

            if (int.Parse(amount.ToString()) == 0 && amount.ToString().Length > 0)
                throw new ValidationException("Az egyenleg csak egész szám lehet.");
        }
    }
}
