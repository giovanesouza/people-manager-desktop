using PeopleManager.Services;
using PeopleManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManager.Models
{
    public static class PersonManager
    {
        private const string URL = "https://gerador-nomes.wolan.net/";
        private static readonly ApiClient _apiClient = new ApiClient(URL);
        private static readonly int totalNames = 5;

        public static ObservableCollection<Person> DatabasePeople { get; private set; } = new();

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


        public static ObservableCollection<Person> GetPeople()
        {
            if (DatabasePeople.Count == 0)
            {
                _ = RandomRegistrationPeople(); // Fill the list if it is not already filled
            }
            return DatabasePeople;
        }

       
        public static void CreatePerson(Person person)
        {
            DatabasePeople.Add(person);
        }
    }
}
