using PeopleManager.Abstracts;
using PeopleManager.Common;
using PeopleManager.Events;
using PeopleManager.Models;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PeopleManager.ViewModels
{
    public partial class PeopleListItemViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILocalizationService _localizationService;
        private IDialogService _dialogService;
        private Person _personInfo;

        public ICommand DeleteCommand { get; }

        public PeopleListItemViewModel(IEventAggregator eventAggregator, ILocalizationService localizationService, IDialogService dialogService)
        {
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _localizationService = localizationService;
            DeleteCommand = new RelayCommand<Person>(async person => await DeletePersonAsync(person));
        }

        public Person PersonInfo
        {
            get => _personInfo;
            set => OnPropertyChanged(ref _personInfo, value);
        }

        public async Task DeletePersonAsync(Person person)
        {
            bool confirmed = await _dialogService.ShowConfirmationDialogAsync(_localizationService.GetString("DeleteDialogTitle"),
                $"{person.Fullname} - {person.Cpf}", _localizationService.GetString("DeleteButton"), "ButtonDeleteStyle");

            if (confirmed) _eventAggregator.GetEvent<DeletePersonEvent>().Publish(person.Id);
        }
    }
}
