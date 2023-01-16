using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FinanceManagementProject.Helper
{
    class FirstIconBehaviors
    {
        public static string GetSumOfEmployeeExpenseMetodName(DependencyObject obj)
        {
            return (string)obj.GetValue(SumOfEmployeeExpenseMetodNameProperty);
        }

        public static void SetSumOfEmployeeExpenseMetodName(DependencyObject obj, string value)
        {
            obj.SetValue(SumOfEmployeeExpenseMetodNameProperty, value);
        }

        public static readonly DependencyProperty SumOfEmployeeExpenseMetodNameProperty =
            DependencyProperty.RegisterAttached("SumOfEmployeeExpenseMetodName", typeof(string), typeof(FirstIconBehaviors), new PropertyMetadata(null,OnLoadMetodNameChanged));

        private static void OnLoadMetodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement uiElement))
                return;

            uiElement.Loaded += (sender, args) =>
            {
                var viewModel = uiElement.DataContext;

                if (viewModel == null)
                    return;

                var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());

                if (methodInfo == null)
                    return;
                methodInfo.Invoke(viewModel, null);
            };
        }
    }
}