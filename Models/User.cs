using System.Globalization;
using Tax_Calculator.Interface;

namespace Tax_Calculator.Models
{

    public class User : IUserMethods
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public enum GenderType
        {
            Male,
            Female
        }
        public GenderType Gender { get; set; }
        public float Income { get; set; }
        public float Investments { get; set; }
        public float Loan { get; set; }
        public float NonTaxableAmount { get; set; }
        public float TaxableAmount { get; set; }
        public float PayableTax { get; set; }


        public void GetDOB()
        {
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
            DateOfBirth = dateOfBirth;
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now < dateOfBirth.AddYears(age))
            {
                age--;
            }
            Age = age;
        }

        public float GetExemption()
        {
            float StandardDeduction = (float)(Income * 0.2);
            float HomeLoanDeduction;
            if (Loan > 0)
            {
                HomeLoanDeduction = (float)(Loan * 0.8);
            }
            else
            {
                HomeLoanDeduction = 0;
            }
            if (HomeLoanDeduction > StandardDeduction)
            {
                return StandardDeduction;
            }
            else
            {
                return HomeLoanDeduction;
            }
        }

        public void GetGender()
        {
            string gender;
            while (true)
            {
                Console.WriteLine("Enter Your Gender (M/F)");
                gender = Console.ReadLine();
                try
                {
                    if (gender.Equals("M", StringComparison.OrdinalIgnoreCase) || gender.Equals("F", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid gender (M/F).");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                }
            }
            if (gender == "m" || gender == "M")
            {
                Gender = GenderType.Male;
            }
            else
            {
                Gender = GenderType.Female;
            }
        }

        public void GetIncome()
        {
            int income;
            while (true)
            {
                Console.WriteLine("What is your Income");
                string incomeString = Console.ReadLine();
                try
                { 
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                }
            }
            Income = income;
        }

        public void GetInvestments()
        {
            int investments;
            while (true)
            {
                Console.WriteLine("What are total your Investments");
                string investmentsString = Console.ReadLine();
                try
                {
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                }
            }
            Investments = investments;
        }

        public void GetLoans()
        {
            int loans;
            while (true)
            {
                Console.WriteLine("Enter Loan Amount if any");
                string loansString = Console.ReadLine();
                try
                {
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                }   
            }
            Loan = loans;
        }

        public float GetTax()
        {
            if (Age >= 60)
            {
                if (TaxableAmount >= 0 && TaxableAmount <= 240000)
                {
                    return 0;
                }
                else if (TaxableAmount >= 240001 && TaxableAmount <= 300000)
                {
                    float tax = (float)((TaxableAmount - 240000) * 0.1);
                    return tax;
                }
                else if (TaxableAmount >= 300001 && TaxableAmount <= 500000)
                {
                    float tax = (float)((TaxableAmount - 300000) * 0.2 + 6000);
                    return tax;
                }
                else
                {
                    float tax = (float)((TaxableAmount - 500000) * 0.3 + 46000);
                    return tax;
                }
            }
            else if (Gender == GenderType.Male)
            {
                if (TaxableAmount >= 0 && TaxableAmount <= 160000)
                {
                    return 0;
                }
                else if (TaxableAmount >= 160001 && TaxableAmount <= 300000)
                {
                    float tax = (float)((TaxableAmount - 160000) * 0.1);
                    return tax;
                }
                else if (TaxableAmount >= 300001 && TaxableAmount <= 500000)
                {
                    float tax = (float)((TaxableAmount - 300000) * 0.2 + 14000);
                    return tax;
                }
                else
                {
                    float tax = (float)((TaxableAmount - 500000) * 0.3 + 54000);
                    return tax;
                }
            }
            else
            {
                if (TaxableAmount >= 0 && TaxableAmount <= 190000)
                {
                    return 0;
                }
                else if (TaxableAmount >= 190001 && TaxableAmount <= 300000)
                {
                    float tax = (float)((TaxableAmount - 190000) * 0.1);
                    return tax;
                }
                else if (TaxableAmount >= 300001 && TaxableAmount <= 500000)
                {
                    float tax = (float)((TaxableAmount - 300000) * 0.2 + 11000);
                    return tax;
                }
                else
                {
                    float tax = (float)((TaxableAmount - 500000) * 0.3 + 51000);
                    return tax;
                }
            }
        }

        public float GetTaxableAmount()
        {
            if (Investments >= 100000)
            {
                float Taxes = Income;
                Taxes = Taxes - NonTaxableAmount - 100000;
                return Taxes;
            }
            else
            {
                float Taxes = Income;
                Taxes = Taxes - NonTaxableAmount - Investments;
                return Taxes;
            }
        }

        public void Display()
        {
            Displayfooter();
            Console.WriteLine("Tax Calculator");
            Displayfooter();
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Enter your name:");
                string nameString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nameString))
                {
                    Console.WriteLine("Name can't be Empty");
                }
                else
                {
                    Name = nameString;
                    break;
                }

            }
            Displayfooter();
            GetDOB();
            Displayfooter();
            GetGender();
            Displayfooter();
            GetIncome();
            Displayfooter();
            GetInvestments();
            Displayfooter();
            GetLoans();
            Displayfooter();
            Console.WriteLine("Your age is: " + Age);
        }

        public void DisplayFinalTaxes()
        {
            Displayfooter();
            Console.WriteLine("Your Taxable Income is: " + TaxableAmount);
            PayableTax = GetTax();
            Displayfooter();
            Console.WriteLine("Your Payable Tax is: " + PayableTax);
            Displayfooter();
        }

        public void Displayfooter()
        {
            Console.WriteLine("=======================================");
        }
    }
}
