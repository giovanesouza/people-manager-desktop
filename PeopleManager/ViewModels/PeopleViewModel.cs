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
using System.Runtime.CompilerServices;
using PeopleManager.Views;
using Microsoft.UI.Xaml.Controls;


namespace PeopleManager.ViewModels
{
    public class PeopleViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _cpf;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Person> People { get; private set; } = new ObservableCollection<Person>();
        
        public ICommand RegisterCommand { get; }
        public ICommand DeleteCommand { get; }
        //public ICommand EditPersonCommand { get; set; }



        private bool canRegister; // Used to enable or disable the registration button 

        public PeopleViewModel()
        {
            People = PersonManager.GetPeople(); // Populate the list with initial data
            RegisterCommand = new RelayCommand<object>(RegisterPerson, CanExecuteRegister);
            DeleteCommand = new RelayCommand<Person>(DeletePerson, CanExecuteDeletePerson);
            //EditPersonCommand = new RelayCommand<Person>(EditPerson, CanEditPerson);
        }

        /*
        private void EditPerson(Person person)
        {

            var editView = new UpdatePersonView(person.Clone());
            editView.Activate();
        }

        private bool CanEditPerson(Person person)
        {
            return person != null;
        }
        */

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                ValidateInputs();
            }
        }
 
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
                ValidateInputs();
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                _cpf = value;
                OnPropertyChanged(nameof(Cpf));
                ValidateInputs();
            }
        }


        public void RegisterPerson(object obj)
        {
            int id = People.Count + 1;
            Person newPerson = new Person(id, Name, Surname, Cpf);
            PersonManager.CreatePerson(newPerson);
            ClearFields();
        }

        public void DeletePerson(Person person)
        {
            PersonManager.DeletePerson(person.Id);
        }

        private bool CanExecuteRegister(object parameter)
        {
            return CanRegister;
        }

        public bool CanRegister
        {
            get => canRegister;
            private set
            {
                canRegister = value;
                OnPropertyChanged();
                ((RelayCommand<object>)RegisterCommand).RaiseCanExecuteChanged();
            }
        }

        private bool CanExecuteDeletePerson(Person person)
        {
            return person != null;
        }


        private void ValidateInputs()
        {
            // Validates if all required fields are filled
            CanRegister = !string.IsNullOrWhiteSpace(Name) &&
                !string.IsNullOrWhiteSpace(Surname) &&
                !string.IsNullOrWhiteSpace(Cpf) && Cpf.Length > 10;
        }

        public void ClearFields()
        {
            Name = "";
            Surname = "";
            Cpf = "";
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
