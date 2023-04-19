﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax_Calculator.Models;

namespace Tax_Calculator.Interface
{
    public interface IUserMethods
    {
        public int GetAge(DateTime dateOfBirth);
        public float GetTax();
        public float GetExemption();
        public float GetTaxableAmount();

    }
}
