using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
namespace FinanceManagementProject.Model
{
    public class Company : DomainObject
    {
        public string Name { get; set; }
        public virtual AdressInfo Location { get; set; }
        public decimal Budjet { get; set; }
        public string Description { get; set; }
        public virtual User user { get; set; }


        public virtual List<Tax> Taxes{ get; set; }
        public virtual List<Employee> Employees{ get; set; }
        public virtual List<CompunalExpenses>  CompunalExpenses{ get; set; }
        public virtual List<OtherExpences> OtherExpences{ get; set; }
        public virtual List<Income> Incomes{ get; set; }
        


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}