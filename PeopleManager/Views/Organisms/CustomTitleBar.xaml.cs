using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PeopleManager.Views.Organisms
{
    public sealed partial class CustomTitleBar : UserControl
    {
        public CustomTitleBar()
        {
            this.InitializeComponent();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            MainWindow.Current.Close();
        }
        //private void CloseButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
