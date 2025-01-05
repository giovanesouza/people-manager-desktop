using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using PeopleManager.Common;

namespace PeopleManager.Views.Molecules
{
    public partial class RegisterForm : UserControl
    {
        public RegisterForm()
        {
            this.InitializeComponent();
        }
        
        private void FormatCpf(object sender, KeyRoutedEventArgs e)
        {
            CpfRegister.Text = FormatData.FormatCpf(CpfRegister.Text);
        }
    }
}
