using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.Models;
using PeopleManager.Views.Dialogs;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PeopleManager.Views
{
    public sealed partial class PeopleView : UserControl
    {
        public PeopleView()
        {
            this.InitializeComponent();
        }

        private async void PersonEdit(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var person = button?.Tag as Person;

                if (person != null) 
                { 
                    var editDialog = new EditDialog(person.Clone())
                    {
                        XamlRoot = this.XamlRoot
                    };

                    var result = await editDialog.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        person.Name = editDialog.EditablePerson.Name;
                        person.Surname = editDialog.EditablePerson.Surname;
                        person.Cpf = editDialog.EditablePerson.Cpf;
                    }
                    else
                    {
                        Console.WriteLine("Atualização cancelada!");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write("Error", ex.Message);
            }

        }
        

    }
}
