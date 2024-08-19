using ABI.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using PeopleManager.Services;
using PeopleManager.Utils;

namespace PeopleManager.Models
{
    public static class PersonManager
    {
        private const string URL = "https://gerador-nomes.wolan.net/";
        private static readonly ApiClient _apiClient = new ApiClient(URL);
        private static readonly int totalNames = 5;

        public static ObservableCollection<Person> DatabasePeople { get; private set; } 
            = new ObservableCollection<Person>();


        // Generates random people
        private static async Task RandomRegistrationPeople()
        {
            try
            {
                List<string> names = await _apiClient.GetNames(totalNames);
                List<string> surnames = await _apiClient.GetSurname(totalNames);

                for (int i = 0; i < totalNames; i++)
                {
                    var person = new Person(i + 1, names[i], surnames[i], GenerateCpf.Create());
                    CreatePerson(person);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }


        // Returns all People
        public static ObservableCollection<Person> GetPeople()
        {
            if (DatabasePeople.Count == 0)
            {
                // Preenche a lista se ainda não estiver preenchida
                _ = RandomRegistrationPeople();
            }
            return DatabasePeople;
        }

       
        public static void CreatePerson(Person person)
        {
            DatabasePeople.Add(person);
        }

    }
}
