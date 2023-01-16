using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class Employee : Person, Expenses
    {
        public decimal Expense { get; set; }

        public virtual Company Company { get; set; }


        public override string ToString()
        {
            return $"{Image}  {FullName}   {Expense}";
        }
    }
}

