using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using FinanceManagementProject.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.ViewModel
{
    class AddComunalVM : ViewModelBase
    {
        Messenger Messenger;
        public RelayCommand CancelBtnClick { get; set; }
        public RelayCommand OkBtnClick { get; set; }
        public CompunalExpenses communal { get; set; } = new CompunalExpenses();
        
        private void CancelBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<ComunalVM>() });
        }
        private void OkBtn(object obj)
        {
            App.user.Companies[0].CompunalExpenses.Add(communal);
            App.Context.SaveChanges();
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<ComunalVM>() });
        }
        public AddComunalVM(Messenger messenger)
        {
            OkBtnClick = new RelayCommand(OkBtn);
            CancelBtnClick = new RelayCommand(CancelBtn);
            Messenger = messenger;
        }
    }
}
