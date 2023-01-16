using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FinanceManagementProject.Helper
{
    public class LoadMetods
    {


        public static string GetLoadMetod(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadMetodProperty);
        }

        public static void SetLoadMetod(DependencyObject obj, string value)
        {
            obj.SetValue(LoadMetodProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadMetod.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadMetodProperty =
            DependencyProperty.RegisterAttached("LoadMetod", typeof(string), typeof(LoadMetods), new PropertyMetadata(null, OnLoadMetodNameChanged));

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