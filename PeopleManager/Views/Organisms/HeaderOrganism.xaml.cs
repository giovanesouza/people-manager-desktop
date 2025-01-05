using Microsoft.UI.Xaml.Controls;
using PeopleManager.Events;
using PeopleManager.ViewModels;
using Prism.Events;

namespace PeopleManager.Views.Organisms
{
    public sealed partial class HeaderOrganism : UserControl
    {
        private readonly HeaderOrganismViewModel viewModel;
        public HeaderOrganism()
        {
            this.InitializeComponent();
            viewModel = App.GetService<HeaderOrganismViewModel>();
            DataContext = viewModel;
            EventAggregator.Current.GetEvent<ResizeComponents>().Subscribe(ResizeHeader);
        }

        private void ResizeHeader(Dimensions dimensions)
        {
            switch(dimensions.Size)
            {
                case Sizes.Infinity:
                    SortAndToggleStackPanel.Orientation = Orientation.Horizontal;
                    break;
                case Sizes.ExtraLarge:
                    SortAndToggleStackPanel.Orientation = Orientation.Vertical;
                    break;
                default:
                    break;
            }
        }
    }
}
