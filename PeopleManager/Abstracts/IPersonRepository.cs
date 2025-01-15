using PeopleManager.Models;
using System.Collections.ObjectModel;

namespace PeopleManager.Abstracts
{
    public interface IPersonRepository
    {
        ObservableCollection<Person> GetAll();
        void Create(Person person);
        void Update(Person person);
        void Delete(string id);
    }
}
