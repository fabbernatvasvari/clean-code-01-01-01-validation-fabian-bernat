using System;
using ConsoleValidationDemo_FullValidator.Model;
using ConsoleValidationDemo_FullValidator.Common;
using ConsoleValidationDemo_FullValidator.Exception;

namespace ConsoleValidationDemo_FullValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer validCustomer = new Customer("Kiss Béla", "bela.kiss@example.com", 1500m);
            Console.WriteLine("✅ Sikeres felhasználő létrehozás: " + validCustomer);
            Customer invalidCustomer = null;
            try
            {
                invalidCustomer = new Customer("B", "invalidCustomer@", -10m);
            }
            catch (ValidationException vEx)
            {
                Console.WriteLine("Érvénytelen felhasználó: " + invalidCustomer);
                Console.WriteLine($"❌ Validációs hiba: {invalidCustomer} " + vEx.Message);
            }

            Console.WriteLine("\nProgram vége. Nyomj egy Entert...");
            Console.ReadLine();
        }
    }
}
