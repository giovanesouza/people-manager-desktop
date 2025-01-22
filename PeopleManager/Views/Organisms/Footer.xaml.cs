using Microsoft.UI.Xaml.Controls;
using PeopleManager.ViewModels;
using System.Diagnostics;
using Windows.ApplicationModel.Resources;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using System.Windows;
using Windows.UI;

namespace PeopleManager.Views.Organisms
{
    public sealed partial class Footer : UserControl
    {
        private readonly FooterViewModel viewModel;
        private readonly ResourceLoader resourceLoader;
        public Footer()
        {
            this.InitializeComponent();
            viewModel = App.GetService<FooterViewModel>();
            DataContext = viewModel;
            resourceLoader = ResourceLoader.GetForViewIndependentUse("Resources");
        }

        private void HyperlinkButton_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs _)
        {
            if (sender is HyperlinkButton hyperlink)
            {
                //hyperlink.Background = new SolidColorBrush(Colors.Black);
                hyperlink.Opacity = 0.8;
            }
        }

        private void HyperlinkButton_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs _)
        {
            if (sender is HyperlinkButton hyperlink)
            {
                hyperlink.Opacity = 1.0;
            }
        }
    }
}
