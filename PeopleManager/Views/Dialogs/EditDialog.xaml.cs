using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using PeopleManager.Models;
using PeopleManager.Utils;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PeopleManager.Views.Dialogs
{
    public sealed partial class EditDialog : ContentDialog
    {
        public Person EditablePerson { get; set; }

        public EditDialog(Person person)
        {
            this.InitializeComponent();
            EditablePerson = person.Clone();
            DataContext = EditablePerson;
        }

        private void FormatCpf(object sender, KeyRoutedEventArgs e)
        {
            txtbCpf.Text = FormatData.FormatCpf(txtbCpf.Text);
        }
    }
}
