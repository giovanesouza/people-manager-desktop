using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.Services;
using Prism.Events;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PeopleManager.ViewModels
{
    public partial class HeaderOrganismViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IEventAggregator _eventAggregator;
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

        public HeaderOrganismViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            RegisterPersonCommand = new RelayCommand(RegisterPerson);
            FilterPersonCommand = new RelayCommand(FilterPerson);
            ClearFilterButtonCommand = new RelayCommand(ClearFilterFields);
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


        public void RegisterPerson(object obj)
        {
            UpdateCanRegister();
            if (CanRegister)
            {
                int id = PersonManager.GetPeople().Count + 1;
                Person newPerson = new(id, RegisterName, RegisterSurname, RegisterCpf);
                _eventAggregator.GetEvent<PersonAddedEvent>().Publish(newPerson);
                _eventAggregator.GetEvent<PeopleSortedEvent>().Publish("Padrão");
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
            _eventAggregator.GetEvent<FilterPeopleEvent>().Publish(filterPeople);
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
            _eventAggregator.GetEvent<FilterPeopleEvent>().Publish(new FilterPeople { Name = "", SurName = "", CPF = "" });
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

        protected bool OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
}
