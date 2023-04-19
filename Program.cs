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
                Console.WriteLine("=======================================");
                Console.WriteLine("Tax Calculator");
                Console.WriteLine("=======================================");
                Console.WriteLine("");
                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine();
                Console.WriteLine("=======================================");
                DateTime dateOfBirth;
                while (true)
                {
                    Console.WriteLine("Enter your date of birth (dd/mm/yyyy): ");
                    string dateOfBirthString = Console.ReadLine();
                    if (DateTime.TryParseExact(dateOfBirthString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
                    {
                        if (dateOfBirth < DateTime.Now)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid date of birth.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid date in the format dd/mm/yyyy.");
                    }
                }
                Console.WriteLine("=======================================");
                string gender;
                while (true)
                {
                    Console.WriteLine("Enter Your Gender (M/F)");
                    gender = Console.ReadLine();
                    if (gender.Equals("M", StringComparison.OrdinalIgnoreCase) || gender.Equals("F", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid gender (M/F).");
                    }
                }
                Console.WriteLine("=======================================");
                int income;
                while (true)
                {
                    Console.WriteLine("What is your Income");
                    string incomeString = Console.ReadLine();
                    if (int.TryParse(incomeString, out income))
                    {
                        if (income >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid income greater than or equal to zero.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer value for income.");
                    }
                }
                Console.WriteLine("=======================================");
                int investments;
                while (true)
                {
                    Console.WriteLine("What are total your Investments");
                    string investmentsString = Console.ReadLine();
                    if (int.TryParse(investmentsString, out investments))
                    {
                        if (investments >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid investment amount greater than or equal to zero.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer value for investments.");
                    }
                }

                Console.WriteLine("=======================================");
                int loans;
                while (true)
                {
                    Console.WriteLine("Enter Loan Amount if any");
                    string loansString = Console.ReadLine();
                    if (int.TryParse(loansString, out loans))
                    {
                        if (loans >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid loan amount greater than or equal to zero.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer value for loans.");
                    }
                }
                Console.WriteLine("=======================================");
                //DateTime dateOfBirth = DateTime.ParseExact(dateOfBirthString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                User user = new User();
                user.Name = name;
                user.DateOfBirth = dateOfBirth;
                user.Income = income;
                user.Investments = investments;
                user.Age = user.GetAge(user.DateOfBirth);
                user.Loan = loans;
                Console.WriteLine("Your age is: " + user.Age);
                if (gender == "m" || gender == "M")
                {
                    user.Gender = "Male";
                }
                else
                {
                    user.Gender = "Female";
                }
                if (user.Loan > 0)
                {
                    float HomeLoanExemption = user.GetHomeLoanExemption();
                    float IncomeExemption = user.GetIncomeExemption();
                    if (HomeLoanExemption > IncomeExemption)
                    {
                        user.NonTaxableAmount = IncomeExemption;
                    }
                    else
                    {
                        user.NonTaxableAmount = HomeLoanExemption;
                    }
                }
                if (user.Investments >= 100000)
                {
                    user.TaxableAmount = user.Income - user.NonTaxableAmount - 100000;
                }
                else
                {
                    user.TaxableAmount = user.Income - user.Investments - user.NonTaxableAmount;
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("Your Taxable Income is: " + user.TaxableAmount);
                user.PayableTax = user.GetTax();
                Console.WriteLine("=======================================");
                Console.WriteLine("Your Payable Tax is: " + user.PayableTax);
                Console.WriteLine("=======================================");
                Console.WriteLine("Do you want to Continue [Y/N]");
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
            } while (Answer == "y" || Answer == "Y");
        }

    }
}