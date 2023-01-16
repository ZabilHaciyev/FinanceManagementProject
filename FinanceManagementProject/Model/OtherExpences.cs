using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class OtherExpences : DomainObject
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Expence { get; set; }
        public virtual Company Company { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name} {Expence}";
        }
    }
}