using Microsoft.UI.Xaml;
using PeopleManager.Views.Organisms.ControlPages;
using System;

namespace PeopleManager.Utils
{
    public static class DialogTemplate
    {

        public static async void ShowDialog(XamlRoot xamlRoot, string message)
        {
            var dialog = new ContentDialogContent
            {
                XamlRoot = xamlRoot,
                MessageText = message,
                CloseButtonText = "OK",
                CloseButtonStyle = (Style)Application.Current.Resources["ButtonCloseCancelStyle"],
                Style = (Style)Application.Current.Resources["DialogStyle"]
            };

            dialog.RequestedTheme = ThemeSettings.LoadUserPreferredTheme() == "Dark" ? ElementTheme.Dark : ElementTheme.Light;

            await dialog.ShowAsync();
            
            /*
            var showDialogTask = dialog.ShowAsync();
            int displayTime = 2000;

            await Task.Delay(displayTime);

            if (dialog.IsLoaded)
            {
                dialog.Hide();
            }

            await showDialogTask;
            */
        }
    }
}
