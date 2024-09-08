using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PeopleManager.Utils;
using PeopleManager.Models;
using PeopleManager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PeopleManager.Views
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdatePersonView : Window
    {
        public UpdatePersonView(Person person)
        {
            this.InitializeComponent();
            //updateView.DataContext = person;
            updateView.DataContext = new UpdatePersonViewModel(person);

        }

        private void FormatCpf(object sender, KeyRoutedEventArgs e)
        {
            txtbCpf.Text = FormatData.FormatCpf(txtbCpf.Text);
        }

        private void CloseUpdateView(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
