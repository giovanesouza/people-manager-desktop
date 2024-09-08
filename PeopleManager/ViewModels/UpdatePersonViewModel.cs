using Microsoft.UI.Xaml;
using PeopleManager.Models;
using PeopleManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PeopleManager.ViewModels
{
    public class UpdatePersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _surname;
        private string _cpf;
        private bool canUpdate; // Used to enable or disable the update button

        public ICommand UpdatePersonCommand { get; set; }

        private Person EditablePerson { get; set; }

        public UpdatePersonViewModel(Person person) 
        {
            EditablePerson = person;
            UpdatePersonCommand = new RelayCommand<Person>(UpdatePerson, CanExecuteUpdate);
        }


        private void UpdatePerson(Person p)
        {
            try
            {
                var n = p.Name;
                var n1 = EditablePerson.Name;
                PersonManager.UpdatePerson(p.Id, p.Name, p.Surname, p.Cpf);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
            
            
        }

        private bool CanExecuteUpdate(object obj)
        {
            return canUpdate;
            //return true;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                ValidateInputs();
            }

            //get => EditablePerson.Name;
            //set
            //{
            //    EditablePerson.Name = value;
            //    OnPropertyChanged(nameof(Name));
            //    ValidateInputs();
            //}
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

            //get => EditablePerson.Surname;
            //set
            //{
            //    EditablePerson.Surname = value;
            //    OnPropertyChanged(nameof(Surname));
            //    ValidateInputs();
            //}

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

            //get => EditablePerson.Cpf;
            //set
            //{
            //    EditablePerson.Cpf = value;
            //    OnPropertyChanged(nameof(Cpf));
            //    ValidateInputs();
            //}

        }


        public bool CanUpdate
        {
            get => canUpdate;
            private set
            {
                canUpdate = value;
                OnPropertyChanged();
                /*((RelayCommand<Person>)UpdatePersonCommand).RaiseCanExecuteChanged()*/;
            }
        }


        private void ValidateInputs()
        {
            //Validates if all required fields are filled
            CanUpdate = string.IsNullOrWhiteSpace(Name) &&
                string.IsNullOrWhiteSpace(Surname) &&
                string.IsNullOrWhiteSpace(Cpf) && Cpf.Length > 10;

            
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

}