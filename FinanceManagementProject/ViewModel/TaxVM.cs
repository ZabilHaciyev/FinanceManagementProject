using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using FinanceManagementProject.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FinanceManagementProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class TaxVM : ViewModelBase
    {
        public Messenger Messenger { get; set; }
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand AddBtnClick { get; set; }
        public RelayCommand RemoveBtnClick { get; set; }
        public ObservableCollection<Tax> taxes { get; set; }
        public User User { get; set; } = App.user;

        private void RemoveBtn(object obj)
        {
            
            if (obj is Tax tax)
            {
       
                
                taxes.Remove(tax);
                App.Context.Taxes.Remove(tax);
                App.Context.SaveChanges();
            
            }
        }

        public void LoadMetodTax()
        {
            taxes = new ObservableCollection<Tax>(User.Companies[0].Taxes);
        }



        private void AddBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<AddTaxVM>() });
        }
        private void BackBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<FirstIconVM>() });
        }
        public TaxVM(Messenger messenger)
        {



            BackBtnCommand = new RelayCommand(BackBtn);
            AddBtnClick = new RelayCommand(AddBtn);

            RemoveBtnClick = new RelayCommand(RemoveBtn);
            Messenger = messenger;
        }
    }
}
