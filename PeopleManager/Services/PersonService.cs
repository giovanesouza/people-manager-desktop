using PeopleManager.Abstracts;
using PeopleManager.Database;
using PeopleManager.Models;
using System.Collections.ObjectModel;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository repository)
        {
            _personRepository = repository;
            DBConnection.InitializeDatabase();
        }

        public ObservableCollection<Person> GetPeople() => _personRepository.GetAll();

        public void CreatePerson(Person person) => _personRepository.Create(person);

        public void DeletePerson(int id) => _personRepository.Delete(id);

        public void UpdatePerson(Person person) => _personRepository.Update(person);

    }
}
