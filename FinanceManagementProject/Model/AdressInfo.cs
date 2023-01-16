using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class AdressInfo:DomainObject
    {   
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
