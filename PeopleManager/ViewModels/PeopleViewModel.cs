using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Services;
using PeopleManager.Models;
using System.Collections.ObjectModel;
using PeopleManager.Utils;
using Microsoft.UI.Xaml;
using System.Text.RegularExpressions;
using System.Windows.Input;


namespace PeopleManager.ViewModels
{
    public class PeopleViewModel 
    {
        private readonly ApiClient _apiClient;
        private const string URL = "https://gerador-nomes.wolan.net/";
        private readonly int totalNames = 2;


        public ObservableCollection<Person> People { get; set; }

    
        public PeopleViewModel()
        {
            _apiClient = new ApiClient(URL);
            People = new ObservableCollection<Person>();
            RandomRegistrationPeople();
        }
        

        
        public async void RandomRegistrationPeople()
        {
            List<string> names = await _apiClient.GetNames(totalNames);
            List<string> surnames = await _apiClient.GetSurname(totalNames);

            for (int i = 0; i < totalNames; i++)
            {
                Person p = new Person(i + 1, names[i], surnames[i], GenerateCpf.Create());
                People.Add(p);
            }

        }
        
        
        public void AddPerson(Person person)
        {
            People.Add(person);
        }
       

    }
}
