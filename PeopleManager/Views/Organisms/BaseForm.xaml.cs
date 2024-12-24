using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.Utils;
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

        public static readonly DependencyProperty ButtonRightCommandProperty = 
            DependencyProperty.Register("ButtonRightCommand", typeof(ICommand), typeof(BaseForm), new PropertyMetadata(default(Nullable)));

        public static readonly DependencyProperty ButtonLeftCommandProperty =
            DependencyProperty.Register("ButtonLeftCommand", typeof(ICommand), typeof(BaseForm), new PropertyMetadata(default(Nullable)));
        
        public static readonly DependencyProperty ButtonLeftVisibilityProperty =
            DependencyProperty.Register("ButtonLeftVisibility", typeof(Visibility), typeof(BaseForm), new PropertyMetadata(default(Visibility)));

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

        public ICommand ButtonRightCommand
        {
            get => (ICommand)GetValue(ButtonRightCommandProperty); 
            set => SetValue(ButtonRightCommandProperty, value); 
        }
        
        public ICommand ButtonLeftCommand
        {
            get => (ICommand)GetValue(ButtonLeftCommandProperty); 
            set => SetValue(ButtonLeftCommandProperty, value); 
        }
        
        public Visibility ButtonLeftVisibility
        {
            get => (Visibility)GetValue(ButtonLeftVisibilityProperty); 
            set => SetValue(ButtonLeftVisibilityProperty, value); 
        }

        private void FormatCpf_KeyUp(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (sender is TextBox textBox) textBox.Text = FormatData.FormatCpf(textBox.Text);
        }
    }
}
