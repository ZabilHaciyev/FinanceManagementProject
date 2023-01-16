using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using FinanceManagementProject.Repo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementProject.ViewModel
{
    public class MainWindowMolel : ViewModelBase, INotifyPropertyChanged
    {
        #region Username&password
        public RelayCommand SubmitButton { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        #endregion
        public Messenger Messenger { get; set; }

        public MainWindowMolel(Messenger mesenger)
        {
            SubmitButton = new RelayCommand(SubmitBtn);
            Messenger = mesenger;
        }
        private void SubmitBtn(object obj)
        {
            #region Checking
            var passwordBox = obj as PasswordBox;
            Password = passwordBox.Password;
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                User user = App.Context.Users.Include(u => u.AddressInfo).SingleOrDefault(u => u.Username == Username && u.Password == Password);
                if (user == null)
                {
                    MessageBox.Show("You must input something!!!", "Fatal error!!!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                App.user = user;
                Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<FirstIconVM>() });
            }
            else
            {
                MessageBox.Show("Usarname or password is wrong!", "Waring!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            #endregion
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}