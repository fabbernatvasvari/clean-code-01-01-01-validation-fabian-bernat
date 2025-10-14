using ConsoleValidationDemo_FullValidator.Validator;

namespace ConsoleValidationDemo_FullValidator.Model
{
    public sealed class Customer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public decimal Amount { get; private set; }

        public Customer(string name, string email, decimal amount)
        {
            CustomerValidator.Validate(name, email, amount);
            Name = name.Trim();
            Email = email.Trim();
            Amount = amount;
        }

        public override string ToString() => $"{Name} <{Email}> (Egyenleg: {Amount} Ft)";
    }
}
