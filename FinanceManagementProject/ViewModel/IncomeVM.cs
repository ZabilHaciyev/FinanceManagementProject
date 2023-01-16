using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FinanceManagementProject.ViewModel
{
    class IncomeVM:ViewModelBase
    {

        public Messenger Messenger { get; set; }
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand AddBtnClick { get; set; }
        public RelayCommand RemoveBtnClick { get; set; }
        public ObservableCollection<Income> Incomes { get; set; }
        public User User { get; set; } = App.user;

        private void RemoveBtn(object obj)
        {

            if (obj is Income income)
            {


                Incomes.Remove(income);
                App.Context.Incomes.Remove(income);
                App.Context.SaveChanges();

            }
        }
        public void LoadMetodIncome()
        {
            Incomes = new ObservableCollection<Income>(User.Companies[0].Incomes);
        }

        private void AddBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<AddIncomeVM>() });
        }
        private void BackBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<FirstIconVM>() });
        }
        public IncomeVM(Messenger messenger)
        {



            BackBtnCommand = new RelayCommand(BackBtn);
            AddBtnClick = new RelayCommand(AddBtn);

            RemoveBtnClick = new RelayCommand(RemoveBtn);
            Messenger = messenger;
        }



    }
}
