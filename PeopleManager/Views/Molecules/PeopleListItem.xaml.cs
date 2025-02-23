using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PeopleManager.Common;
using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.ViewModels;
using PeopleManager.Views.Organisms.ControlPages;
using Prism.Events;

namespace PeopleManager.Views.Molecules
{
    public sealed partial class PeopleListItem : UserControl
    {
        private readonly PeopleListItemViewModel _viewModel;
        public PeopleListItem()
        {
            this.InitializeComponent();
            _viewModel = App.GetService<PeopleListItemViewModel>();
            DataContext = _viewModel;
            EventAggregator.Current.GetEvent<ResizeComponents>().Subscribe(AdjustButtonVisibilityBasedOnSize);
        }

        public static readonly DependencyProperty PersonInfoProperty =
            DependencyProperty.Register("FileInfo", typeof(Person), typeof(PeopleListItem), new PropertyMetadata(null, OnPersonInfoPropertyChanged));

        public Person PersonInfo
        {
            get { return (Person)GetValue(PersonInfoProperty); }
            set { SetValue(PersonInfoProperty, value); }
        }

        private static void OnPersonInfoPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var component = d as PeopleListItem;
            if (component.DataContext is PeopleListItemViewModel viewModel && e.NewValue is Person model)
            {
                viewModel.PersonInfo = model;
            }
        }

        private async void EditPerson_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var person = sender is Button button ? button.Tag : null;
            Person p = (Person)person;

            EditPersonDialog editDialog = new()
            {
                XamlRoot = this.XamlRoot,
                PersonName = p.Name,
                PersonSurname = p.Surname,
                PersonCpf = p.Cpf,
                PrimaryButtonStyle = (Style)Application.Current.Resources["ButtonConfirmStyle"],
                CloseButtonStyle = (Style)Application.Current.Resources["ButtonCloseCancelStyle"],
                Style = (Style)Application.Current.Resources["DialogStyle"],
                RequestedTheme = ThemeSettings.LoadUserPreferredTheme() == "Dark" ? ElementTheme.Dark : ElementTheme.Light
            };

            var result = await editDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Person editedPerson = new(p.Id, editDialog.PersonName, editDialog.PersonSurname, editDialog.PersonCpf);

                if (p != editedPerson)
                    EventAggregator.Current.GetEvent<UpdatePersonEvent>().Publish(editedPerson);
            }
        }

        private void AdjustButtonVisibilityBasedOnSize(Dimensions dimensions)
        {
            switch (dimensions.Size)
            {
                case Sizes.Infinity:
                    ButtonTextActionsVisibility(true);
                    break;
                case Sizes.ExtraLarge:
                    ButtonTextActionsVisibility(false);
                    break;
                default:
                    break;
            }
        }

        private void ButtonTextActionsVisibility(bool isVisible)
        {
            DispatcherQueue.TryEnqueue(DispatcherQueuePriority.Low, () =>
            {
                EditPersonText.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
                DeletePersonText.Visibility = isVisible ? Visibility.Visible : Visibility.Collapsed;
            });
        }
    }
}
