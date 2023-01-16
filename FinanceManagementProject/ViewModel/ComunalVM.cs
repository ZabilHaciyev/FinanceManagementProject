using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using FinanceManagementProject.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FinanceManagementProject.ViewModel
{
    class ComunalVM : ViewModelBase
    {
        public Messenger Messenger { get; set; }
        public RelayCommand RemoveBtnClick { get; set; }
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand AddBtnClick { get; set; }
        public ObservableCollection<CompunalExpenses> comunals { get; set; }
        public User User { get; set; } = App.user;

        private void RemoveBtn(object obj)
        {
            if (obj is CompunalExpenses comunal)
            {
                comunals.Remove(comunal);
                App.user.Companies[0].CompunalExpenses.Remove(comunal);
                App.Context.SaveChanges();
            }
        }
        private void AddBtn(object obj) {

            
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<AddComunalVM>() });
        }

        private void BackBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<FirstIconVM>() });
        }

        public void LoadComunalExpences() {
            comunals = new ObservableCollection<CompunalExpenses>(User.Companies[0].CompunalExpenses);
        }
        public ComunalVM(Messenger messenger)
        {
            RemoveBtnClick = new RelayCommand(RemoveBtn);
            BackBtnCommand = new RelayCommand(BackBtn);
            AddBtnClick = new RelayCommand(AddBtn);
            Messenger = messenger;
        }
    }
}