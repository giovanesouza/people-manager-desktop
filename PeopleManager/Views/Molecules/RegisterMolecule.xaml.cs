using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PeopleManager.Models;
using PeopleManager.Utils;
using PeopleManager.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PeopleManager.Views.Molecules
{
    public sealed partial class RegisterMolecule : UserControl
    {
        public RegisterMolecule()
        {
            this.InitializeComponent();
        }
        
        private void FormatCpf(object sender, KeyRoutedEventArgs e)
        {
            txtbCpf.Text = FormatData.FormatCpf(txtbCpf.Text);
        }

    }
}
