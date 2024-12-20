using Microsoft.UI.Xaml.Controls;
using PeopleManager.ViewModels;
using PeopleManager.Views.Organisms;

namespace PeopleManager.Views
{
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
