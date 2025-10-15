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
            try
            {
                Customer validCustomer = new Customer("Kiss Béla", "bela.kiss@example.com", 1500m);
                Console.WriteLine("✅ Sikeres felhasználő létrehozás: " + validCustomer);

                Customer invalidCustomer = new Customer("B", "invalidCustomer@", -10m);
                Console.WriteLine("Ezt nem fogjuk látni: " + invalidCustomer);
            }
            catch (ValidationException vEx)
            {
                Console.WriteLine("❌ Validációs hiba: " + vEx.Message);
            }

            Console.WriteLine("\nProgram vége. Nyomj egy Entert...");
            Console.ReadLine();
        }
    }
}
