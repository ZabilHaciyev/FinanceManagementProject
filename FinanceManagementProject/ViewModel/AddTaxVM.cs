using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class AddTaxVM : ViewModelBase
    {


        Messenger Messenger;
        public RelayCommand CancelBtnClick { get; set; }
        public RelayCommand OkBtnClick { get; set; }

        public string Type { get; set; }
        public decimal Expence{ get; set; }

        public TaxVM tax { get; set; }
        public Tax tax1 { get; set; } = new Tax();
        private void CancelBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<TaxVM>() });
        }
        private void OkBtn(object obj)
        {
            App.user.Companies[0].Taxes.Add(tax1);
            App.Context.SaveChanges();
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<TaxVM>() });
        }
        public AddTaxVM(Messenger messenger)
        {
            OkBtnClick = new RelayCommand(OkBtn);
            CancelBtnClick = new RelayCommand(CancelBtn);
            Messenger = messenger;
        }
    }
}