using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Desktop
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached("PlaceholderText", typeof(string),
                typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsPasswordEmptyProperty =
            DependencyProperty.RegisterAttached("IsPasswordEmpty", typeof(bool),
                typeof(PasswordBoxHelper), new PropertyMetadata(true));

        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceholderTextProperty, value);
        }

        public static bool GetIsPasswordEmpty(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPasswordEmptyProperty);
        }

        public static void SetIsPasswordEmpty(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPasswordEmptyProperty, value);
        }

        static PasswordBoxHelper()
        {
            EventManager.RegisterClassHandler(typeof(PasswordBox),
                PasswordBox.PasswordChangedEvent,
                new RoutedEventHandler(OnPasswordChanged));
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetIsPasswordEmpty(passwordBox, string.IsNullOrEmpty(passwordBox.Password));
            }
        }
    }
}
