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
        public ObservableCollection<Person> People { get; private set; } = new ObservableCollection<Person>();

        public PeopleViewModel()
        {
            People = PersonManager.GetPeople(); // Populate the list with initial data
        }



    }
}
