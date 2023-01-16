using FinanceManagementProject.Command;
using FinanceManagementProject.Messaging;
using FinanceManagementProject.Model;
using FinanceManagementProject.Repo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;

namespace FinanceManagementProject.ViewModel
{
    class AddEmployeeVM : ViewModelBase
    {
        Messenger Messenger;
        public RelayCommand CancelBtnClick { get; set; }
        public RelayCommand OkBtnClick { get; set; }
        public Employee employee { get; set; } = new Employee();
        public AdressInfo AdressInfo { get; set; } = new AdressInfo();
        public RelayCommand AddImageBtnClick { get; set; }
        public RelayCommand AddImageClick { get; set; }


        private void AddPicture(object parameter)
        {
            var imagePath = GetFilePath();

            if (string.IsNullOrWhiteSpace(imagePath))
            {
                return;
            }

            var imageAsBytes = GetImageBytes(imagePath);

            employee.Image = imageAsBytes ?? null;
        }

        
        
        private string GetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }




        private byte[] GetImageBytes(string imagePath)
        {
            return File.ReadAllBytes(imagePath);
            

            //Image image = Image.FromFile(imagePath);

            //using (var ms = new MemoryStream())
            //{
            //    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //    return ms.ToArray();
            //}
        }



        private void CancelBtn(object obj)
        {
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<EmployeeVM>() });
        }
        private void OkBtn(object obj)
        {

            //datas
            //AppilicationContext appilicationContext = new AppilicationContext();
            employee.AddressInfo = AdressInfo;
            App.user.Companies[0].Employees.Add(employee);
            App.Context.SaveChanges();
            Messenger.Send(new Navigation() { ViewModel = App.Container.GetInstance<EmployeeVM>() });
            MessageBox.Show("ok");
        }
        public AddEmployeeVM(Messenger messenger)
        {
            OkBtnClick = new RelayCommand(OkBtn);
            CancelBtnClick = new RelayCommand(CancelBtn);
            AddImageBtnClick = new RelayCommand(AddPicture);
            Messenger = messenger;
        }
    }
}