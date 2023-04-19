using Tax_Calculator.Interface;

namespace Tax_Calculator.Models
{

    public class User : IUserMethods
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Income { get; set; }
        public float Investments { get; set; }
        public float Loan { get; set; }
        public float NonTaxableAmount { get; set; }
        public float TaxableAmount { get; set; }
        public float PayableTax { get; set; }


        public int GetAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now < dateOfBirth.AddYears(age))
            {
                age--;
            }
            return age;
        }
        public float GetHomeLoanExemption()
        {
            float HomeLoanDeduction = (float)(Loan * 0.8);
            return HomeLoanDeduction;
        }

        public float GetIncomeExemption()
        {
            float StandardDeduction = (float)(Income * 0.2);
            return StandardDeduction;
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
            else if (Gender == "Male")
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
    }
}
