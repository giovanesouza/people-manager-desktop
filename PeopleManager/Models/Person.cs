using System;
using System.ComponentModel;

namespace PeopleManager.Models
{
    // INotifyPropertyChanged - Identifica as mudanças no modelo
    public partial class Person : INotifyPropertyChanged
    {
        #region Fields
        private int _id;
        private string _name;
        private string _surname;
        private string _fullname;
        private string _cpf;
        private string _registeredAt;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    Fullname = $"{_name} {Surname}";
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                    Fullname = $"{Name} {_surname}";
                }
            }
        }

        public string Fullname
        {
            get { return _fullname; }
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }

        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (_cpf != value)
                {
                    _cpf = value;
                    OnPropertyChanged(nameof(Cpf));
                }
            }
        }

        public string RegisteredAt
        {
            get { return _registeredAt; }
            set
            {
                if (_registeredAt != value)
                {
                    _registeredAt = value;
                    OnPropertyChanged(nameof(RegisteredAt));
                }
            }
        }
        #endregion

        public Person(int id, string name, string surname, string cpf)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Fullname = $"{name} {surname}";
            Cpf = cpf;
            RegisteredAt = string.Format("{0:d} às {0:t}", DateTime.Now);
        }


        public Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}