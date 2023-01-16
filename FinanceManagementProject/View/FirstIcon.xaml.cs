using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceManagementProject.View
{
    /// <summary>
    /// Interaction logic for FirstIcon.xaml
    /// </summary>
    public partial class FirstIcon : UserControl
    {


     
        public FirstIcon()
        {
            InitializeComponent();
            if (BudjetTxtBlck.Text.StartsWith('-'))
            {
                BudjetTxtBlck.Foreground = Brushes.Red;
            }
            else if (BudjetTxtBlck.Text == "0")
            {
                BudjetTxtBlck.Foreground = Brushes.Yellow;

            }
            else
            {
                BudjetTxtBlck.Foreground = Brushes.Green;
            }

        }


    }
}
