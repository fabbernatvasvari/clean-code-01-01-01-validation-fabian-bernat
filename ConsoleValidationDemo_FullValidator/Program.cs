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
                var ok = new Customer("Kiss Béla", "bela.kiss@example.com", 1500m);
                Console.WriteLine("✅ Sikeres példány: " + ok);

                var hibas = new Customer("B", "hibas@", -10m);
                Console.WriteLine("Ezt nem fogjuk látni: " + hibas);
            }
            catch (ValidationExceptions ex)
            {
                Console.WriteLine("❌ Validációs hiba: " + ex.Message);
            }

            Console.WriteLine("\nProgram vége. Nyomj egy Entert...");
            Console.ReadLine();
        }
    }
}
