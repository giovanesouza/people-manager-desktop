using Microsoft.UI.Xaml.Controls;

namespace PeopleManager.Views.Organisms.ControlPages
{
    public sealed partial class ContentDialogContent : ContentDialog
    {
        public ContentDialogContent()
        {
            this.InitializeComponent();
        }

        public string MessageText
        {
            get => MessageTextBlock.Text;
            set => MessageTextBlock.Text = value;
        }
    }
}
