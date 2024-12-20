using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using PeopleManager.Utils;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

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
