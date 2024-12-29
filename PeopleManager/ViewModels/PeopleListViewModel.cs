using PeopleManager.Events;
using PeopleManager.Models;
using Prism.Events;
using System.Collections.ObjectModel;

namespace PeopleManager.ViewModels
{
    public class PeopleListViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        public ObservableCollection<Person> People { get; private set; }

        public PeopleListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PersonAddedEvent>().Subscribe(AddPersonToList);
            _eventAggregator.GetEvent<DeletePersonEvent>().Subscribe(RemovePersonFromList);
            _eventAggregator.GetEvent<UpdatePersonEvent>().Subscribe(UpdatePerson);
            People = PersonManager.GetPeople();
        }

        private void AddPersonToList(Person person)
        {
            PersonManager.CreatePerson(person);
        }

        private void RemovePersonFromList(string id)
        {
            PersonManager.DeletePerson(id);
        }

        private void UpdatePerson(Person person)
        {
            if (person != null) PersonManager.UpdatePerson(person);
        }

    }
}
