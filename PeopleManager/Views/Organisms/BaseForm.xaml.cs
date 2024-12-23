using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Windows.Input;

namespace PeopleManager.Views.Organisms
{
    public sealed partial class BaseForm : UserControl
    {
        public BaseForm()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty FormTitleProperty =
            DependencyProperty.Register("FormTitle", typeof(string), typeof(BaseForm), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty FormButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(string), typeof(BaseForm), new PropertyMetadata(default(string)));
        
        public static readonly DependencyProperty NameFieldProperty =
            DependencyProperty.Register("NameField", typeof(string), typeof(BaseForm), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty SurnameFieldProperty = 
            DependencyProperty.Register("SurnameField", typeof(string), typeof(BaseForm), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty CpfFieldProperty = 
            DependencyProperty.Register("CpfField", typeof(string), typeof(BaseForm), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ButtonCommandProperty = 
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(BaseForm), new PropertyMetadata(default(Nullable)));

        public string FormTitle
        {
            get => (string)GetValue(FormTitleProperty);
            set => SetValue(FormTitleProperty, value);
        }

        public string ButtonContent
        {
            get => (string)GetValue(FormButtonContentProperty);
            set => SetValue(FormButtonContentProperty, value);
        }

        public string NameField
        {
            get => (string)GetValue(NameFieldProperty);
            set => SetValue(NameFieldProperty, value);
        }

        public string SurnameField
        {
            get => (string)GetValue(SurnameFieldProperty);
            set => SetValue(SurnameFieldProperty, value);
        }

        public string CpfField
        {
            get => (string)GetValue(CpfFieldProperty);
            set => SetValue(CpfFieldProperty, value);
        }

        public ICommand ButtonCommand
        {
            get => (ICommand)GetValue(ButtonCommandProperty); 
            set => SetValue(ButtonCommandProperty, value); 
        }

    }
}
