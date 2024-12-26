using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.Utils;

namespace PeopleManager.Views.Atoms
{
    public sealed partial class ThemeToggle : UserControl
    {
        const string Dark = "Dark";
        const string Light = "Light";

        public ThemeToggle()
        {
            this.InitializeComponent();
        }

        private void ThemeToggle_Toggled(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            bool isDarkMode = ThemeToggleControl.IsOn;
            string selectedTheme = isDarkMode ? Dark : Light;
            ThemeSettings.SaveUserPreferredTheme(selectedTheme);

            if (App.MainWindow.Content is FrameworkElement rootElement)
                rootElement.RequestedTheme = isDarkMode ? ElementTheme.Dark : ElementTheme.Light;
        }

        private void ChangeToggleIsOn_Loaded(object sender, RoutedEventArgs e)
        {
            ThemeToggleControl.IsOn = ThemeSettings.LoadUserPreferredTheme() == Dark;
        }
    }
}
