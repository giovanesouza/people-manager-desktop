using PeopleManager.Abstracts;
using PeopleManager.Common;
using PeopleManager.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private const string URL = "https://gerador-nomes.wolan.net/";
        private readonly ApiClient _apiClient;
        private readonly IPersonRepository _personRepository;
        private readonly int _totalRegistration = 5;

        public PersonService(IPersonRepository repository)
        {
            _personRepository = repository;
            _apiClient = new ApiClient(URL);
        }

        public ObservableCollection<Person> GetPeople()
        {
            if (_personRepository.GetAll().Count == 0)
            {
                _ = RandomRegistrationPeople();
            }
            return _personRepository.GetAll();
        }

        public void CreatePerson(Person person)
        {
            _personRepository.Create(person);
        }

        public void DeletePerson(string id)
        {
            _personRepository.Delete(id);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.Update(person);
        }

        private async Task RandomRegistrationPeople()
        {
            try
            {
                var names = await _apiClient.GetNames(_totalRegistration);
                var surnames = await _apiClient.GetSurname(_totalRegistration);

                for (int i = 0; i < _totalRegistration; i++)
                {
                    var person = new Person(IdGenerator.GenerateId(), names[i], surnames[i], GenerateCpf.Create());
                    _personRepository.Create(person);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Error during Random Registration: {ex.Message}");
            }
        }
    }
}
