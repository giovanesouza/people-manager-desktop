using Microsoft.UI.Xaml.Markup;
using System;
using Windows.ApplicationModel.Resources;

namespace PeopleManager.Common
{
    public partial class ResourceExtension : MarkupExtension
    {
        public string Key { get; set; }

        protected override object ProvideValue()
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException("Key must be set");
            }
            var resourceLoader = ResourceLoader.GetForViewIndependentUse("Resources");
            return resourceLoader.GetString(Key);
        }
    }
}
