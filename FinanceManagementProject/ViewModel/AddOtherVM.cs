using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FinanceManagementProject.ViewModel
{
    class AddOtherVM : ViewModelBase
    {
        Messenger Messenger;
      public  RelayCommand AddBtnClick { get; set; }
        public RelayCommand CancelBtnClick { get; set; }
        public OtherExpences other { get; set; } = new OtherExpences();




        void AddBtn(object obj)
        {
            App.user.Companies[0].OtherExpences.Add(other);
            App.Context.SaveChanges();
            MessageBox.Show($"Your object has been added!","Information",MessageBoxButton.OK,MessageBoxImage.Information);
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<OtherView>() });
        }
        void CancelBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<OtherView>() });
        }
        public AddOtherVM(Messenger message)
        {


            AddBtnClick = new RelayCommand(AddBtn);
            CancelBtnClick = new RelayCommand(CancelBtn);

            Messenger = message;
        }

    }
}
