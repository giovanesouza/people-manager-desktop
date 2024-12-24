using Microsoft.UI.Xaml.Controls;
using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.ViewModels;
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

            if (!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(SurName) || !string.IsNullOrWhiteSpace(CPF))
            {
                var filteredPerson = peopleList.Where(p => 
                (string.IsNullOrWhiteSpace(Name) || p.Name.StartsWith(Name, StringComparison.CurrentCultureIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(SurName) || p.Surname.StartsWith(SurName, StringComparison.CurrentCultureIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(CPF) || p.Cpf.StartsWith(CPF)));
                
                if (filteredPerson != null)
                    dataGridPeopleList.ItemsSource = filteredPerson;
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
    }
}
