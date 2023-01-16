using Microsoft.Azure.Amqp.Framing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FinanceManagementProject.ViewModel
{
    class ForAddObject : INotifyPropertyChanged
    {
        private string _name;

        public string NameOf
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(); }
        }

        private decimal _outcome;

        public decimal Outcome
        {
            get { return _outcome; }
            set { _outcome = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}