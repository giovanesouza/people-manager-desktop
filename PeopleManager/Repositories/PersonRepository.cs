using PeopleManager.Abstracts;
using PeopleManager.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PeopleManager.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ObservableCollection<Person> _people = [];

        public ObservableCollection<Person> GetAll() => _people;

        public void Create(Person person)
        {
            _people.Add(person);
        }

        public void Update(Person person)
        {
            var foundPerson = _people.FirstOrDefault(p => p.Id == person.Id);
            if (foundPerson != null)
            {
                foundPerson.Name = person.Name;
                foundPerson.Surname = person.Surname;
                foundPerson.Cpf = person.Cpf;
            }
        }

        public void Delete(string id)
        {
            var foundPerson = _people.FirstOrDefault(p => p.Id == id);
            if (foundPerson != null) _people.Remove(foundPerson);
        }
    }
}
