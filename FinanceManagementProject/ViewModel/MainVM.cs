using FinanceManagementProject.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManagementProject.ViewModel
{
    [AddINotifyPropertyChangedInterface]


    public class MainVM : ViewModelBase
    {
        public ViewModelBase CurrentVM { get; set; }

        public MainVM()
        {
            CurrentVM = App.Container.GetInstance<MainWindowMolel>();
            var messenger = App.Container.GetInstance<Messenger>();
            messenger.Register<Navigation>(this, message =>
             {
                 CurrentVM = message.ViewModel;
             });
        }
    }
}