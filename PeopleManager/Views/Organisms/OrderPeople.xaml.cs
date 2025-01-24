using Microsoft.UI.Xaml.Controls;
using PeopleManager.Common;

namespace PeopleManager.Views.Organisms
{
    public partial class OrderPeople : UserControl
    {
        private readonly SortService _sortService = new();
        public OrderPeople()
        {
            this.InitializeComponent();
        }

        private void Ordination_Changed(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = ComboBoxOrdination.SelectedValue as ComboBoxItem; // Cast
            _sortService.SortPeopleBy = comboBoxItem.Content.ToString();
        }
    }
}