using PeopleManager.Abstracts;
using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.Services;
using Prism.Events;
using System.Collections.ObjectModel;

namespace PeopleManager.ViewModels
{
    public partial class PeopleListViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly PersonService _personService;
        private readonly ISortService _sortService;
        private ObservableCollection<Person> _people;

        public PeopleListViewModel(IEventAggregator eventAggregator, ISortService sortService, PersonService personService)
        {
            _eventAggregator = eventAggregator;
            _sortService = sortService;
            _personService = personService;

            _eventAggregator.GetEvent<PersonAddedEvent>().Subscribe(AddPerson);
            _eventAggregator.GetEvent<DeletePersonEvent>().Subscribe(RemovePerson);
            _eventAggregator.GetEvent<UpdatePersonEvent>().Subscribe(UpdatePerson);

            People = _personService.GetPeople();
        }

        public ObservableCollection<Person> People
        {
            get => _people;
            set => OnPropertyChanged(ref _people, value);
        }

        private void AddPerson(Person person)
        {
            _personService.CreatePerson(person);
            UpdatePeopleList();
            _sortService.SortPeopleBy = _sortService.SortPeopleBy;
        }

        private void RemovePerson(int id)
        {
            _personService.DeletePerson(id);
            UpdatePeopleList();
            _sortService.SortPeopleBy = _sortService.SortPeopleBy;
        }

        private void UpdatePerson(Person person)
        {
            if (person != null)
            {
                _personService.UpdatePerson(person);
                UpdatePeopleList();
                _sortService.SortPeopleBy = _sortService.SortPeopleBy;
            }
        }

        private void UpdatePeopleList() => People = _personService.GetPeople();
    }
}
