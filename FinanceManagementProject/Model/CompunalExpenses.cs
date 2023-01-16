using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class CompunalExpenses : DomainObject, Expenses
    {
        public string Type { get; set; }
        public decimal Expense { get; set; }
        public virtual Company Company { get; set; }



        public override string ToString()
        {
            return $"{Type} {Expense}";
        }
    }
}
