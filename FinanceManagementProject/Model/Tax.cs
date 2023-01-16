using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class Tax : DomainObject, Expenses
    {
        public string Type { get; set; }
        public decimal Expense { get; set; }
        public virtual Company Company { get; set; }
    }
}