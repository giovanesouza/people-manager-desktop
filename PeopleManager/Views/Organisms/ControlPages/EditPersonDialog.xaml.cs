using Microsoft.UI.Xaml.Controls;
using PeopleManager.Utils;

namespace PeopleManager.Views.Organisms.ControlPages
{
    public sealed partial class EditPersonDialog : ContentDialog
    {
        public EditPersonDialog()
        {
            this.InitializeComponent();
        }

        public string PersonName 
        { 
            get => EditName.Text; 
            set => EditName.Text = value; 
        }
        public string PersonSurname 
        { 
            get => EditSurname.Text; 
            set => EditSurname.Text = value; 
        }
        public string PersonCpf 
        { 
            get => EditCpf.Text; 
            set => EditCpf.Text = value; 
        }

        private void FormatCpf_KeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (sender is TextBox textBox) textBox.Text = FormatData.FormatCpf(textBox.Text);
        }
    }
}
