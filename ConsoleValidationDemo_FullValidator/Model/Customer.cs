using ConsoleValidationDemo_FullValidator.Validator;

namespace ConsoleValidationDemo_FullValidator.Model
{
    public sealed class Customer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public decimal Amount { get; private set; }

        public Customer()
        {
            Name = "Ismeretlen felhaszn�l�";
            Email = "Ismeretlen felhaszn�l�";
            Amount = 0m;
        }
        public Customer(string name, string email, decimal amount)
        {
            Name = name.Trim();
            Email = email.Trim();
            Amount = amount;

            Console.WriteLine(ToString() + " valid�l�sa...");
            CustomerValidator.Validate(name, email, amount);
        }

        public override string ToString() => $"{Name} <{Email}> (Egyenleg: {Amount} Ft)";
    }
}
