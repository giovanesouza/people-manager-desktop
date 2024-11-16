using PeopleManager.Models;
using PeopleManager.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace PeopleManager.ViewModels
{
    public partial class PeopleViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _cpf;
        private bool _canRegisterButton;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public ObservableCollection<Person> People { get; private set; } = new ObservableCollection<Person>();
        public ICommand RegisterPersonCommand { get; }
  
        #region Constructor
        public PeopleViewModel()
        {
            People = PersonManager.GetPeople(); // Populate the list with initial data
            RegisterPersonCommand = new RelayCommand(RegisterPerson);
        }
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                if(OnPropertyChanged(ref _name, value)) ValidateInputs();
            }
        }
 
        public string Surname
        {
            get => _surname;
            set
            {
                if(OnPropertyChanged(ref _surname, value)) ValidateInputs();
            }
        }

        public string Cpf
        {
            get => _cpf;
            set 
            {
                if(OnPropertyChanged(ref _cpf, value)) ValidateInputs();
            }
        }

        public bool CanRegisterButton
        {
            get => _canRegisterButton;
            set
            {
                if(OnPropertyChanged(ref _canRegisterButton, value)) ValidateInputs();
            }
        }
        #endregion

        public void RegisterPerson(object obj)
        {
            int id = People.Count + 1;
            if(CanRegisterButton)
            {
                Person newPerson = new(id, Name, Surname, Cpf);
                PersonManager.CreatePerson(newPerson);
                ClearFields();
            }
        }

        public void ValidateInputs()
        {
            CanRegisterButton = !string.IsNullOrEmpty(Name) && 
                !string.IsNullOrEmpty(Surname) && 
                !string.IsNullOrEmpty(Cpf);
        }

         public void ClearFields()
         {
            Name = "";
            Surname = "";
            Cpf = "";
         }

        protected bool OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null) 
        { 
            if (!EqualityComparer<T>.Default.Equals(field, value)) 
            { 
                field = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true; 
            } 
            return false; 
        }

        /*
        protected void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        */
    }
}