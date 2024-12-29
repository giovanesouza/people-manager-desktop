using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.Utils;
using PeopleManager.ViewModels;
using PeopleManager.Views.Organisms.ControlPages;
using Prism.Events;
using System;
using System.Linq;

namespace PeopleManager.Views.Organisms
{
    public sealed partial class PeopleList : UserControl
    {
        private readonly PeopleListViewModel viewModel;
        public PeopleList()
        {
            this.InitializeComponent();
            viewModel = App.GetService<PeopleListViewModel>();
            DataContext = viewModel;
            EventAggregator.Current.GetEvent<PeopleSortedEvent>().Subscribe(SortPeopleBy);
            EventAggregator.Current.GetEvent<FilterPeopleEvent>().Subscribe(FilterPeopleToList);
        }

        private void FilterPeopleToList(FilterPeople filterPeople)
        {
            string Name = filterPeople.Name?.Trim();
            string SurName = filterPeople.SurName?.Trim();
            string CPF = filterPeople.CPF?.Trim();

            var peopleList = viewModel.People;

            if(string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(SurName) && string.IsNullOrEmpty(CPF))
            {
                DialogTemplate.ShowDialog(this.XamlRoot, "Preencha pelo menos um dos campos para filtrar registros.");
            } 
            else if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(SurName) || !string.IsNullOrEmpty(CPF))
            {
                var filteredPerson = peopleList.Where(p =>
                (string.IsNullOrWhiteSpace(Name) || p.Name.StartsWith(Name, StringComparison.CurrentCultureIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(SurName) || p.Surname.StartsWith(SurName, StringComparison.CurrentCultureIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(CPF) || p.Cpf.StartsWith(CPF)));

                if (filteredPerson != null)
                    dataGridPeopleList.ItemsSource = filteredPerson;
                //else
                //{
                //    dataGridPeopleList.ItemsSource = viewModel.People;
                //    DialogTemplate.ShowDialog(this.XamlRoot, "Nenhum registro localizado.");
                //}
            }
            else dataGridPeopleList.ItemsSource = viewModel.People;
        }

        private void SortPeopleBy(string sortBy)
        {
            var allPeople = viewModel.People;

            _ = sortBy switch
            {
                "Por Nome" => dataGridPeopleList.ItemsSource = allPeople.OrderBy(p => p.Name).ToList(),
                "Por Sobrenome" => dataGridPeopleList.ItemsSource = allPeople.OrderBy(p => p.Surname).ToList(),
                _ => dataGridPeopleList.ItemsSource = allPeople.OrderBy(p => p.Id).ToList()
            };
        }

        private async void DeletePerson_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Person person)
            {
                var dialog = new ContentDialogContent
                {
                    XamlRoot = this.XamlRoot,
                    Title = "Voc� tem certeza que deseja excluir este cadastro?",
                    Content = new TextBlock { Text = $"{person.Fullname} - {person.Cpf}" },
                    PrimaryButtonText = "EXCLUIR",
                    CloseButtonText = "CANCELAR",
                    PrimaryButtonStyle = (Style)Application.Current.Resources["ButtonDeleteStyle"],
                    CloseButtonStyle = (Style)Application.Current.Resources["ButtonCloseCancelStyle"],
                    Style = (Style)Application.Current.Resources["DialogStyle"]
                };

                dialog.RequestedTheme = ThemeSettings.LoadUserPreferredTheme() == "Dark" ? ElementTheme.Dark : ElementTheme.Light;

                var result = await dialog.ShowAsync();
                
                if(result == ContentDialogResult.Primary)
                    EventAggregator.Current.GetEvent<DeletePersonEvent>().Publish(person.Id);
            }
        }

        private async void EditPerson_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var person = sender is Button button ? button.Tag : null;
            Person p = (Person)person;

            EditPersonDialog editDialog = new()
            {
                XamlRoot = this.XamlRoot,
                PersonName = p.Name,
                PersonSurname = p.Surname,
                PersonCpf = p.Cpf,
                PrimaryButtonStyle = (Style)Application.Current.Resources["ButtonConfirmStyle"],
                CloseButtonStyle = (Style)Application.Current.Resources["ButtonCloseCancelStyle"],
                Style = (Style)Application.Current.Resources["DialogStyle"]
            };

            editDialog.RequestedTheme = ThemeSettings.LoadUserPreferredTheme() == "Dark" ? ElementTheme.Dark : ElementTheme.Light;

            var result = await editDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Person editedPerson = new(p.Id, editDialog.PersonName, editDialog.PersonSurname, editDialog.PersonCpf);

                if (p != editedPerson)
                    EventAggregator.Current.GetEvent<UpdatePersonEvent>().Publish(editedPerson);
            }
        }

    }
}
