using Windows.Storage;

namespace PeopleManager.Common
{
    public static class ThemeSettings
    {
        public static void SaveUserPreferredTheme(string theme)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["UserPreferredTheme"] = theme;
        }

        public static string LoadUserPreferredTheme()
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey("UserPreferredTheme"))
            {
                return localSettings.Values["UserPreferredTheme"].ToString();
            }

            return "Light";
        }
    }
}
