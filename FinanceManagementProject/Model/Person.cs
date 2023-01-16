using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class Person : DomainObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + ' ' + LastName;
        public string Email { get; set; }
        public string Mobile { get; set; }
        public byte[] Image { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual AdressInfo AddressInfo { get; set; }
    }
}


