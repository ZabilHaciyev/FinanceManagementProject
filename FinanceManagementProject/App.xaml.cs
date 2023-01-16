using FinanceManagementProject.Model;
using FinanceManagementProject.Repo;
using FinanceManagementProject.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace FinanceManagementProject
{
    public partial class App : Application
    {

        public static Container Container { get; set; }
        public static User user { get; set; }
       
        public static AppilicationContext Context { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            //Context.Employees.Add(new Employee());

            ////Context.SaveChanges();

            Context = new AppilicationContext();
            Container = new Container();
           
            Container.RegisterSingleton<MainVM>();
            Container.RegisterSingleton<Messenger>();
            Container.Register<MainWindow>();
            Container.Register<FirstIconVM>();
            Container.Register<MainWindowMolel>();
            Container.Register<EmployeeVM>();
            Container.Register<TaxVM>();
            Container.Register<ComunalVM>();
            Container.Register<OtherView>();
            Container.Register<IncomeVM>();
            Container.Register<AddIncomeVM>();


          
            Container.Register<AddComunalVM>();
            Container.Register<AddOtherVM>();
            Container.Register<AddTaxVM>();
            Container.Register<AddEmployeeVM>();
            






          

            base.OnStartup(e);
        }
    }
}