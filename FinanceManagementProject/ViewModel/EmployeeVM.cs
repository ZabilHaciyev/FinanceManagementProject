using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using FinanceManagementProject.Repo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace FinanceManagementProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class EmployeeVM : ViewModelBase
    {
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand AddBtnCommand { get; set; }
        public RelayCommand RemoveBtnClick { get; set; }
        public Messenger Messenger { get; set; }

        public ObservableCollection<Employee> employees { get; set; }
        public User User { get; set; } = App.user;

        private void RemoveBtn(object obj)
        {
            if (obj is Employee employee)
            {
                employees.Remove(employee);
                App.user.Companies[0].Employees.Remove(employee);
                App.Context.SaveChanges();
            }
        }


        public void LoadMetod()
        {
           employees = new ObservableCollection<Employee>(User.Companies[0].Employees);        
        }

        private void AddBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<AddEmployeeVM>() });
        }

        private void BackBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<FirstIconVM>() });
        }

        public EmployeeVM(Messenger messenger)
        {

            //AppilicationContext appilicationContext = new AppilicationContext();


            //employees = new ObservableCollection<Employee>(App.user.companies[0].employees);

            //employees = App.Container.GetInstance<FirstIconVM>().employee;
            //var tempEmployee = new Employee() { FirstName = "Cavad", LastName = "Xan", Email = "Cavad@gmail.com", Expense = 3000, Mobile = "123-45-56" };
            //employees.Add(tempEmployee);
            //App.Container.GetInstance<FirstIconVM>().employee.Add(tempEmployee);
            //App.Container.GetInstance<FirstIconVM>().SumOfExpense();
            // MessageBox.Show($"{App.Container.GetInstance<FirstIconVM>().employee.Count}");




          
            AddBtnCommand = new RelayCommand(AddBtn);
            BackBtnCommand = new RelayCommand(BackBtn);
            RemoveBtnClick = new RelayCommand(RemoveBtn);



            Messenger = messenger;
        }
    }
}