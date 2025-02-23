using PeopleManager.Abstracts;
using PeopleManager.Common;
using PeopleManager.Events;
using PeopleManager.Models;
using Prism.Events;

namespace PeopleManager.ViewModels
{
    public partial class HeaderOrganismViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILocalizationService _localizationService;
        private readonly IDialogService _dialogService;
        private string _registerName;
        private string _registerSurname;
        private string _registerCpf;
        private string _filterName;
        private string _filterSurname;
        private string _filterCpf;
        private bool _canRegisterButton;

        public ICommand RegisterPersonCommand { get; }
        public ICommand FilterPersonCommand { get; }
        public ICommand ClearFilterButtonCommand { get; }

        public HeaderOrganismViewModel(IEventAggregator eventAggregator, ILocalizationService localizationService, IDialogService dialogService)
        {
            _eventAggregator = eventAggregator;
            _localizationService = localizationService;
            _dialogService = dialogService;
            RegisterPersonCommand = new RelayCommand<Person>(RegisterPerson);
            FilterPersonCommand = new RelayCommand<Person>(FilterPerson);
            ClearFilterButtonCommand = new RelayCommand<Person>(ClearFilterFields);
        }

        #region Properties
        public string RegisterName
        {
            get => _registerName;
            set => OnPropertyChanged(ref _registerName, value);
        }

        public string RegisterSurname
        {
            get => _registerSurname;
            set => OnPropertyChanged(ref _registerSurname, value);
        }

        public string RegisterCpf
        {
            get => _registerCpf;
            set => OnPropertyChanged(ref _registerCpf, value);
        }

        public string FilterName
        {
            get => _filterName;
            set => OnPropertyChanged(ref _filterName, value);
        }

        public string FilterSurname
        {
            get => _filterSurname;
            set => OnPropertyChanged(ref _filterSurname, value);
        }

        public string FilterCpf
        {
            get => _filterCpf;
            set => OnPropertyChanged(ref _filterCpf, value);
        }

        public bool CanRegister
        {
            get => _canRegisterButton;
            set => OnPropertyChanged(ref _canRegisterButton, value);
        }
        #endregion


        public async Task RegisterPerson(object obj)
        {
            UpdateCanRegister();

            if (!CanRegister)
                await _dialogService.ShowConfirmationDialogAsync("", _localizationService.GetString("RegisterDialogErrorMessage"), "", "ButtonDeleteStyle");

            if (CanRegister)
            {
                //int id = PersonManager.GetPeople().Count + 1;
                string id = IdGenerator.GenerateId();
                Person newPerson = new(id, RegisterName, RegisterSurname, RegisterCpf);
                _eventAggregator.GetEvent<PersonAddedEvent>().Publish(newPerson);
                ClearBaseFormFields("RegisterForm");
                CanRegister = false;
            }
        }

        public void FilterPerson(object obj)
        {
            var filterPeople = new FilterPeople
            {
                Name = FilterName,
                SurName = FilterSurname,
                CPF = FilterCpf
            };

            if (!string.IsNullOrEmpty(FilterName) || !string.IsNullOrEmpty(FilterSurname) || !string.IsNullOrEmpty(FilterCpf))
                _eventAggregator.GetEvent<FilterPeopleEvent>().Publish(filterPeople);
            else
                _eventAggregator.GetEvent<FilterPeopleEvent>().Publish(new FilterPeople { Name = "", SurName = "", CPF = "" });
        }

        public void UpdateCanRegister()
        {
            CanRegister = !string.IsNullOrEmpty(RegisterName) &&
                !string.IsNullOrEmpty(RegisterSurname) &&
                (!string.IsNullOrEmpty(RegisterCpf) && RegisterCpf.Length == 14);
        }

        public void ClearFilterFields(object obj)
        {
            ClearBaseFormFields("FilterForm");
        }

        public void ClearBaseFormFields(string baseFormName)
        {
            if (baseFormName == "RegisterForm")
            {
                RegisterName = string.Empty;
                RegisterSurname = string.Empty;
                RegisterCpf = string.Empty;
            }
            else
            {
                FilterName = string.Empty;
                FilterSurname = string.Empty;
                FilterCpf = string.Empty;
            }
        }
    }
}
