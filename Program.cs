using System.Globalization;
using Tax_Calculator.Models;

namespace Tax_Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Answer;
            do
            {
                User user = new User();
                user.Display();
                user.NonTaxableAmount = user.GetExemption();
                user.TaxableAmount = user.GetTaxableAmount();
                user.DisplayFinalTaxes();
                while (true)
                {
                    Console.WriteLine("Do you want to Continue [Y/N]");
                    Answer = Console.ReadLine();
                    if (Answer.Equals("Y", StringComparison.OrdinalIgnoreCase) || Answer.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid character (Y/N).");
                    }
                }
            } while (Answer.Equals("Y", StringComparison.OrdinalIgnoreCase));
        }

    }
}