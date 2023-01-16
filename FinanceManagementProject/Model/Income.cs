using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class Income : DomainObject
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}