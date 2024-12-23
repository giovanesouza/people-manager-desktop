using Microsoft.UI.Xaml.Controls;
using PeopleManager.ViewModels;

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
        }
    }
}
