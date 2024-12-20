using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PeopleManager.ViewModels
{
    public class BaseFormViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _cpf;
        private bool _canRegisterButton;
        public event PropertyChangedEventHandler PropertyChanged;


        public BaseFormViewModel()
        {
        }

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                if (OnPropertyChanged(ref _name, value)) ValidateInputs();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (OnPropertyChanged(ref _surname, value)) ValidateInputs();
            }
        }

        public string Cpf
        {
            get => _cpf;
            set
            {
                if (OnPropertyChanged(ref _cpf, value)) ValidateInputs();
            }
        }

        public bool CanRegisterButton
        {
            get => _canRegisterButton;
            set
            {
                if (OnPropertyChanged(ref _canRegisterButton, value)) ValidateInputs();
            }
        }

        #endregion


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


    }
}
