using ConsoleValidationDemo_FullValidator.Model;
using ConsoleValidationDemo_FullValidator.Exception;
using ConsoleValidationDemo_FullValidator.Common;

namespace ConsoleValidationDemo_FullValidator.Validator
{
    public static class CustomerValidator
    {
        public static void Validate(Customer customer)
        {
            if (customer == null)
                throw new ValidationException(ErrorMessages.ObjectNull);

            Validate(customer.Name, customer.Email, customer.Amount);
        }

        public static void Validate(string name, string email, decimal amount)
        {
            NameValidator.ValidateName(name);
            EmailValidator.ValidateEmail(email);
            AmountValidator.ValidateAmount(amount);
        }
    }
}
