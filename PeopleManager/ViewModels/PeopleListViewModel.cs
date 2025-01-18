using PeopleManager.Events;
using PeopleManager.Models;
using PeopleManager.Services;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace PeopleManager.ViewModels
{
    public class PeopleListViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly PersonService _personService;
        private ObservableCollection<Person> _people;

        public PeopleListViewModel(IEventAggregator eventAggregator, PersonService personService)
        {
            _eventAggregator = eventAggregator;
            _personService = personService;

            _eventAggregator.GetEvent<PersonAddedEvent>().Subscribe(AddPersonToList);
            _eventAggregator.GetEvent<DeletePersonEvent>().Subscribe(RemovePersonFromList);
            _eventAggregator.GetEvent<UpdatePersonEvent>().Subscribe(UpdatePerson);

            People = _personService.GetPeople();
        }

        //public ObservableCollection<Person> People { get; }

        public ObservableCollection<Person> People
        {
            get => _people;
            set => OnPropertyChanged(ref _people, value);
        }

        private void AddPersonToList(Person person) => _personService.CreatePerson(person);

        private void RemovePersonFromList(string id) => _personService.DeletePerson(id);

        private void UpdatePerson(Person person)
        {
            if (person != null) _personService.UpdatePerson(person);
        }
    }
}
