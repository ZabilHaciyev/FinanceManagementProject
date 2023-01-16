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
    class AddIncomeVM : ViewModelBase
    {
        Messenger Messenger;
        public RelayCommand CancelBtnClick { get; set; }
        public RelayCommand OkBtnClick { get; set; }
        public Income Income { get; set; } = new Income();
        private void CancelBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<IncomeVM>() });
        }
        private void OkBtn(object obj)
        {
            App.user.Companies[0].Incomes.Add(Income);
            App.Context.SaveChanges();
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<IncomeVM>() });
            MessageBox.Show("ok");
        }
        public AddIncomeVM(Messenger messenger)
        {
            OkBtnClick = new RelayCommand(OkBtn);
            CancelBtnClick = new RelayCommand(CancelBtn);
            Messenger = messenger;
        }
    }
}
