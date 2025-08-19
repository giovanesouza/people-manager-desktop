using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.Globalization;
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

        private void LanguageComboBoxSelectionChanged(object _, SelectionChangedEventArgs __)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var languageTag = selectedItem.Tag?.ToString();
                if (!string.IsNullOrEmpty(languageTag))
                {
                    ApplicationLanguages.PrimaryLanguageOverride = languageTag;
                    // Shows a Dialog after changing the language


                    // Optional: Restart the app to apply the change
                    // System.Diagnostics.Process.Start(Environment.ProcessPath);
                    // Application.Current.Exit();
                }
            }
        }
    }
}
