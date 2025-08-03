using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using PeopleManager.Common;
using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.ViewModels;
using Prism.Events;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.System;

namespace PeopleManager.Views.Organisms
{
    public sealed partial class PeopleList : UserControl
    {
        private readonly PeopleListViewModel viewModel;
        private readonly ResourceLoader resourceLoader;
        private bool filteredItems = false;

        public PeopleList()
        {
            this.InitializeComponent();
            viewModel = App.GetService<PeopleListViewModel>();
            DataContext = viewModel;
            resourceLoader = ResourceLoader.GetForViewIndependentUse("Resources");
            EventAggregator.Current.GetEvent<PeopleSortedEvent>().Subscribe(SortPeopleBy);
            EventAggregator.Current.GetEvent<FilterPeopleEvent>().Subscribe(FilterPeopleToList);
        }

        private void FilterPeopleToList(FilterPeople filterPeople)
        {
            string Name = filterPeople.Name?.Trim();
            string SurName = filterPeople.SurName?.Trim();
            string CPF = filterPeople.CPF?.Trim();

            var peopleList = viewModel.People;

            if ((string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(SurName) && string.IsNullOrEmpty(CPF)) && !filteredItems)
            {
                DialogTemplate.ShowDialog(this.XamlRoot, resourceLoader.GetString("EmptyFieldsDialogMessage"));
                return;
            }

            if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(SurName) || !string.IsNullOrEmpty(CPF))
            {
                var filteredPerson = peopleList.Where(p =>
                (string.IsNullOrWhiteSpace(Name) || p.Name.StartsWith(Name, StringComparison.CurrentCultureIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(SurName) || p.Surname.StartsWith(SurName, StringComparison.CurrentCultureIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(CPF) || p.Cpf.StartsWith(CPF)));

                if (filteredPerson != null)
                {
                    ListViewPeople.ItemsSource = filteredPerson;
                }
                filteredItems = true;
            }
            else
            {
                filteredItems = false;
                ListViewPeople.ItemsSource = viewModel.People;
            }
        }

        private void SortPeopleBy(string sortBy)
        {
            var allPeople = viewModel.People;

            if (sortBy == resourceLoader.GetString("PlaceholderName"))
                ListViewPeople.ItemsSource = allPeople.OrderBy(p => p.Name).ToList();
            else if (sortBy == resourceLoader.GetString("PlaceholderLastName"))
                ListViewPeople.ItemsSource = allPeople.OrderBy(p => p.Surname).ToList();
            else
                ListViewPeople.ItemsSource = allPeople.OrderBy(p => p.Id).ToList();

            /*
            _ = sortBy switch
            {
                "Por Nome" => ListViewPeople.ItemsSource = allPeople.OrderBy(p => p.Name).ToList(),
                "Por Sobrenome" => ListViewPeople.ItemsSource = allPeople.OrderBy(p => p.Surname).ToList(),
                _ => ListViewPeople.ItemsSource = allPeople.OrderBy(p => p.Id).ToList()
            };
            */
        }

        private void ListViewPeople_Loaded(object _, Microsoft.UI.Xaml.RoutedEventArgs __)
        {
            if (ListViewPeople.ContainerFromIndex(0) is ListViewItem item)
            {
                item.Focus(FocusState.Keyboard);
            }
            //if (ListViewPeople.Items.Count > 0)
            //{
            //    var item = ListViewPeople.ContainerFromIndex(0) as ListViewItem;
            //    item?.Focus(FocusState.Keyboard);
            //}
        }

        private void ListViewPeople_PreviewKeyDown(object _, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Tab)
            {
                // Aguardando a navegação para o próximo item
                if (ListViewPeople.SelectedItem is ListViewItem item)
                {
                    item.Focus(FocusState.Keyboard);
                }

                //if (ListViewPeople.Items.Count > 0)
                //{
                //    if (ListViewPeople.SelectedItem is ListViewItem item)
                //    {
                //        item.Focus(FocusState.Keyboard);
                //    }
                //    //var item = ListViewPeople.ContainerFromIndex(0) as ListViewItem;
                //    //item?.Focus(FocusState.Keyboard);
                //}

            }
        }

        //private void ListViewPeople_GettingFocus(object _, Microsoft.UI.Xaml.Input.GettingFocusEventArgs e)
        //{
        //    if (e.NewFocusedElement is ListViewItem newItem)
        //    {
        //        newItem.Focus(FocusState.Keyboard);
        //    }
        //}
    }
}
