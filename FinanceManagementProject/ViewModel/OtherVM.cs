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
   public class OtherView : ViewModelBase
    {


        public Messenger Messenger { get; set; }
        public RelayCommand BackBtnCommand { get; set; }
        public RelayCommand AddBtnClick { get; set; }
        public RelayCommand RemoveBtnClick { get; set; }
        public ObservableCollection<OtherExpences> others{get;set;}
        public User user { get; set; } = App.user;
        public void LoadOtherExpences() {
            others = new ObservableCollection<OtherExpences>(user.Companies[0].OtherExpences);
        }
        private void AddBtn(object obj)
        {

            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<AddOtherVM>() });
        }
        private void BackBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<FirstIconVM>() });

        }

        private void RemoveBtn(object obj)
        {
            if (obj is OtherExpences other)
            {
                others.Remove(other);
                App.Context.Remove(other);
                App.user.Companies[0].OtherExpences.Remove(other);
                App.Context.SaveChanges();
            }
        }

        public OtherView(Messenger messenger)
        {


            RemoveBtnClick = new RelayCommand(RemoveBtn);
            BackBtnCommand = new RelayCommand(BackBtn);
            AddBtnClick = new RelayCommand(AddBtn);

            Messenger = messenger;
        }


    }
}
