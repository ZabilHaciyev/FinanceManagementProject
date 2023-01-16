using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FinanceManagementProject.Model
{
    public class User : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}   
//user
//company

