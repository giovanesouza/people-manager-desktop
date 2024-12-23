using Microsoft.UI.Xaml.Controls;
using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.ViewModels;
using Prism.Events;
using System.Collections.ObjectModel;
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
        }

        private void SortPeopleBy(string sortBy)
        {
            ObservableCollection<Person> allPeople = viewModel.People;

            _ = sortBy switch
            {
                "Por Nome" => dataGridPeopleList.ItemsSource = allPeople.OrderBy(p => p.Name).ToList(),
                "Por Sobrenome" => dataGridPeopleList.ItemsSource = allPeople.OrderBy(p => p.Surname).ToList(),
                _ => dataGridPeopleList.ItemsSource = allPeople.OrderBy(p => p.Id).ToList()
            };
        }
    }
}
