using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax_Calculator.Models;

namespace Tax_Calculator.Interface
{
    public interface IUserMethods
    {
        public float GetTax();
        public float GetExemption();
        public float GetTaxableAmount();
        public void Display();
        public void GetDOB();
        public void GetGender();
        public void GetIncome();
        public void GetInvestments();
        public void GetLoans();
        public void DisplayFinalTaxes();
        public void Displayfooter();
    }
}
