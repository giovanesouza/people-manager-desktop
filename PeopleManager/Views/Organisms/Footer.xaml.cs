using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.ViewModels;
using Windows.ApplicationModel.Resources;

namespace PeopleManager.Views.Organisms
{
    // It defines a customized button with a different mouse cursor
    //public partial class CustomBtn : HyperlinkButton
    //{
    //    public CustomBtn()
    //    {
    //        this.DefaultStyleKey = typeof(HyperlinkButton);
    //        this.ProtectedCursor = InputSystemCursor.Create(InputSystemCursorShape.Arrow);
    //    }
    //}
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
