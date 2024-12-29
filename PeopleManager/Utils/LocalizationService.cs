using Windows.ApplicationModel.Resources;

namespace PeopleManager.Utils
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse("Resources");

        public string GetString(string key)
        {
            return _resourceLoader.GetString(key);
        }
    }
}
