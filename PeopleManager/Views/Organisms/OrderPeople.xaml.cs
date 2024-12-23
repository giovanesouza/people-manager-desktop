using Microsoft.UI.Xaml.Controls;
using PeopleManager.Events;
using Prism.Events;

namespace PeopleManager.Views.Organisms
{
    public partial class OrderPeople : UserControl
    {
        public OrderPeople()
        {
            this.InitializeComponent();
        }

        private void Ordination_Changed(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxItem = ComboBoxOrdination.SelectedValue as ComboBoxItem; // Cast
            var sortBy = comboBoxItem.Content.ToString();
            EventAggregator.Current.GetEvent<PeopleSortedEvent>().Publish(sortBy);
        }

    }
}