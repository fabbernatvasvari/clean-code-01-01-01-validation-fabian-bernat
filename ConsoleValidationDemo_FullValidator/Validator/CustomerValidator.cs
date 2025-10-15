using ConsoleValidationDemo_FullValidator.Model;
using ConsoleValidationDemo_FullValidator.MyException;
using ConsoleValidationDemo_FullValidator.Common;

namespace ConsoleValidationDemo_FullValidator.Validator
{
    public static class CustomerValidator
    {
        public static void Validate(Customer customer)
        {
            if (customer == null)
                throw new ValidationException("null felhasználót kaptunk =( :" + ErrorMessages.ObjectNull);

            Validate(customer.Name, customer.Email, customer.Amount);
        }

        public static void Validate(string name, string email, decimal amount)
        {
            NameValidator.ValidateName(name);
            EmailValidator.ValidateEmail(email);
            try
            {
            AmountValidator.ValidateAmount(amount);
            } catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + name + " " + email + " " + amount + " " + ex.Message);
            }
        }
    }
}
