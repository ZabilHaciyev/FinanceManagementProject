using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class Repor : DomainObject,Expenses
    {
        public decimal Expense { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}

