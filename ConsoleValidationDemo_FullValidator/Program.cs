using System;
using ConsoleValidationDemo_FullValidator.Model;
using ConsoleValidationDemo_FullValidator.Common;
using ConsoleValidationDemo_FullValidator.MyException;

namespace ConsoleValidationDemo_FullValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer validCustomer1 = new Customer("Kiss Béla", "bela.kiss@example.com", 1500m);
            Customer invalidCustomer1 = new Customer();
            Customer invalidCustomer2 = new Customer();
            try
            {
                invalidCustomer1 = new Customer("B", "invalidCustomer1@", -10m);
                invalidCustomer2 = new Customer("Nagy Anna-Mária", "email@vassvari.org", 1.23m);
            }
            catch (ValidationException vEx)
            {
                Console.WriteLine("Érvénytelen felhasználó: " + invalidCustomer1);
                Console.WriteLine($"❌ Validációs hiba: {invalidCustomer1} " + vEx.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("IndexOutOfRangeException hiba: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
            }
            Console.WriteLine("✅ Felhasználók:\n" + validCustomer1 + "\n" + invalidCustomer1 + "\n" + invalidCustomer1);
            Console.WriteLine("\nProgram vége. Nyomj egy Entert...");
            Console.ReadLine();
        }
    }
}
