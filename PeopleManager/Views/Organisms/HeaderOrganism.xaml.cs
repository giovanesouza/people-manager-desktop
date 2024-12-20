using Microsoft.UI.Xaml.Controls;
using PeopleManager.ViewModels;

namespace PeopleManager.Views.Organisms
{
    public sealed partial class HeaderOrganism : UserControl
    {
        public HeaderOrganism()
        {
            this.InitializeComponent();
            DataContext = new HeaderOrganismViewModel();
        }
    }
}
