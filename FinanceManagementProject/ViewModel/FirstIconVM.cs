using FinanceManagementProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FinanceManagementProject;
using FinanceManagementProject.ViewModel;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.View;
using PropertyChanged;
using FinanceManagementProject.Repo;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]

    public class FirstIconVM : ViewModelBase, INotifyPropertyChanged
    {
        #region Objects
        public Messenger Messenger { get; set; }
        public SeriesCollection seriesCollection { get; set; } = new SeriesCollection();
        public List<Employee> employee { get; set; }
        public ObservableCollection<Tax> tax { get; set; }
        public ObservableCollection<Repor> repor { get; set; }
        public ObservableCollection<CompunalExpenses> compunalExpenses { get; set; }
        public RelayCommand ExitBtnClick { get; set; }
        public RelayCommand EmployeeBtnClick { get; set; }
        public RelayCommand TaxBtnClick { get; set; }
        public RelayCommand CommunalBtnClick { get; set; }
        public RelayCommand OtherBtnClick { get; set; }
        public RelayCommand IncomeBtnClick { get; set; }
        public Company Company { get; set; }
        public User User { get; set; } = App.user;
        #endregion
        #region ValuesForSum
        private decimal sumOfEmployeeExpence = 0;
        public decimal SumOfEmployeeExpence { get => sumOfEmployeeExpence; set { sumOfEmployeeExpence = value; OnPropertyChanged(); } }

        private decimal _sumOfTax = 0;
        public decimal SumOfTaxExpence { get => _sumOfTax; set { _sumOfTax = value; OnPropertyChanged(); } }

        private decimal _sumOfCommunalExpencies = 0;
        public decimal SumOfCommunalExpencies { get => _sumOfCommunalExpencies; set { _sumOfCommunalExpencies = value; OnPropertyChanged(); } }

        private decimal _sumOfOthers = 0;
        public decimal SumOfOthers { get => _sumOfOthers; set { _sumOfOthers = value; OnPropertyChanged(); } }
        
        private decimal _sumOfIncome= 0;
        public decimal SumOfIncome { get => _sumOfIncome; set { _sumOfIncome = value; OnPropertyChanged(); } }
        
        private decimal _sumOfAll= 0;
        public decimal SumOfAll { get => _sumOfAll; set { _sumOfAll = value; OnPropertyChanged(); } }

        private decimal _sumOfOutcome= 0;
        public decimal SumOfOutcome { get => _sumOfOutcome; set { _sumOfOutcome = value; OnPropertyChanged(); } }
        #endregion
        private void ExitBtn(object obj) { 
        
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<MainWindowMolel>() });
        }
        private void AddEmployeeListToDataGrid(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<EmployeeVM>() });
        }
        private void TaxClick(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<TaxVM>() });
        }
        private void ComunalClick(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<ComunalVM>() });
        }
        private void OtherClick(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<OtherView>() });
        }
        private void IncomeClick(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<IncomeVM>() });
        }
        public void SumOfExpense()
        {
            var employees = User.Companies[0].Employees;
            #region sum of EmployeeExpence
            foreach (var item in employees)
            {
                SumOfEmployeeExpence += item.Expense;
            }
            #endregion
            var taxes = User.Companies[0].Taxes;
            #region SumOfTax
            foreach (var item in taxes)
            {
                SumOfTaxExpence += item.Expense;
            }
            #endregion
            var communals = User.Companies[0].CompunalExpenses;
            #region SumOfCommunal
            foreach (var item in communals)
            {
                SumOfCommunalExpencies += item.Expense;
            }
            #endregion
            var Others = User.Companies[0].OtherExpences;
            foreach (var item in Others)
            {
                SumOfOthers += item.Expence;
            }
            #region SumOfIncomes
              var Incomes= User.Companies[0].Incomes;
            foreach (var item in Incomes)
            {
                SumOfIncome += item.Price;
            }
            #endregion
            #region series collection
            seriesCollection = new SeriesCollection() {
              new PieSeries
                    {
                        Title = "1. Employee",
                        Values = new ChartValues<decimal> { SumOfEmployeeExpence},
                        DataLabels = true
                    },
                new PieSeries
                    {
                        Title = "2. Tax",
                        Values = new ChartValues<decimal> { SumOfTaxExpence},
                        DataLabels = true
                    },
                new PieSeries
                    {
                        Title = "3. Compunal expenses",
                        Values = new ChartValues<decimal> { SumOfCommunalExpencies},
                        DataLabels = true
                    },
                new PieSeries
                    {
                        Title = "4. Other",
                        Values = new ChartValues<decimal> { SumOfOthers},
                        DataLabels = true
                    }
            };
            #endregion

            SumOfAll += +SumOfIncome - SumOfTaxExpence - SumOfOthers - SumOfEmployeeExpence - SumOfCommunalExpencies;
        }

        public FirstIconVM(Messenger messenger)
        {
            #region
            ExitBtnClick = new RelayCommand(ExitBtn);
            EmployeeBtnClick = new RelayCommand(AddEmployeeListToDataGrid);
            TaxBtnClick = new RelayCommand(TaxClick);
            CommunalBtnClick = new RelayCommand(ComunalClick);
            OtherBtnClick = new RelayCommand(OtherClick);
            IncomeBtnClick = new RelayCommand(IncomeClick);
            Messenger = messenger;
            #endregion
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}