using Microsoft.UI.Xaml.Controls;
using PeopleManager.Models;
using PeopleManager.ViewModels;

namespace PeopleManager.Views.Organisms
{
    public partial class OrderPeople : UserControl
    {
        public OrderPeople()
        {
            this.InitializeComponent();
        }

        private void RegisterOrdination_Changed(object sender, SelectionChangedEventArgs e)
        {
            var cbb = ComboBoxOrdination.SelectedValue as ComboBoxItem; // Cast
            var selectedItem = cbb.Content.ToString();

              switch (selectedItem)
            {
                case "Por Nome":
                    PersonManager.OrderByName();
                    //viewModel.SortPeopleBy();
                    //var p = viewModel.People.ToArray();
                    //_viewModel.People.;
                    //_viewModel.People.SetSortedPeople(peopl .OrderBy(p => p.Name).ToList());
                    break;
                case "Por Sobrenome":
                    //peopleListControl.SetSortedPeople(peopleListControl.People.OrderBy(p => p.Surname).ToList());
                    break;
                case "Padrão":
                    //peopleListControl.SetSortedPeople(peopleListControl.People.OrderBy(p => p.Id).ToList());
                    break;
            }

        }
    }
}