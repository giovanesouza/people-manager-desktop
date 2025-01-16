using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.Abstracts;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace PeopleManager.Common
{
    public class DialogService : IDialogService
    {
        private readonly ResourceLoader resourceLoader;

        public DialogService()
        {
            resourceLoader = ResourceLoader.GetForViewIndependentUse("Resources");
        }

        public async Task<bool> ShowConfirmationDialogAsync(string title, string message, string primaryButtonText, string primaryButtonStyle)
        {
            var dialog = new ContentDialog
            {
                XamlRoot = App.MainWindow.Content.XamlRoot,
                Title = title,
                Content = message,
                PrimaryButtonText = primaryButtonText,
                CloseButtonText = !string.IsNullOrEmpty(primaryButtonText) ? resourceLoader.GetString("CancelButton") : "OK",
                PrimaryButtonStyle = (Style)Application.Current.Resources[primaryButtonStyle],
                CloseButtonStyle = (Style)Application.Current.Resources["ButtonCloseCancelStyle"],
                Style = (Style)Application.Current.Resources["DialogStyle"],
                RequestedTheme = ThemeSettings.LoadUserPreferredTheme() == "Dark" ? ElementTheme.Dark : ElementTheme.Light
            };

            var result = await dialog.ShowAsync();
            return result == ContentDialogResult.Primary;
        }
    }
}
