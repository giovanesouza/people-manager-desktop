using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace PeopleManager.Common.Converter
{
    public partial class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool v && v) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.Equals(Visibility.Visible);
        }
    }
}
