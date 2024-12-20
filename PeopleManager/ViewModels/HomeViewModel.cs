using PeopleManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace PeopleManager.ViewModels
{
    public partial class HomeViewModel
    {
        #region Fields
        #endregion

        public ObservableCollection<Person> People { get; set; }

        #region Constructor
        public HomeViewModel()
        {
            People = PersonManager.GetPeople(); // Populate the list with initial data
        }
        #endregion


        public void FilterPerson(object obj)
        {
            throw new NotImplementedException("Método não implementado... Sorry for that");
        }


    }
}