using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Models
{
    // INotifyPropertyChanged - Identifica as mudanças no modelo
    public class Person : INotifyPropertyChanged
    //public class Person
    {
        /*
        private int Id;
        private string Name;
        private string Surname;
        private string Fullname;
        private string Cpf;
        private string RegisteredAt;

        public Person() { }

        public Person(int id, string name, string surname, string cpf)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Fullname = $"{name} {surname}";
            Cpf = cpf;
            RegisteredAt = string.Format("{0:d} às {0:t}", DateTime.Now);
        }

        public List<Person> GetPeople()
        {
            List<Person> peopleList = new List<Person>()
            {
                new Person(1, "Giovane", "Souza", "123.456.789-84"),
                new Person(2, "Maria", "Joana", "123.456.789-84"),
            };
            return peopleList;
        }
        */

        private int id;
        private string name;
        private string surname;
        private string fullname;
        private string cpf;
        private string registeredAt;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                    Fullname = $"{name} {Surname}";
                }
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged(nameof(Surname));
                    Fullname = $"{Name} {surname}";
                }
            }
        }

        public string Fullname
        {
            get { return fullname; }
            set
            {
                if (fullname != value)
                {
                    fullname = value;
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }

        public string Cpf
        {
            get { return cpf; }
            set
            {
                if (cpf != value)
                {
                    cpf = value;
                    OnPropertyChanged(nameof(Cpf));
                }
            }
        }

        public string RegisteredAt
        {
            get { return registeredAt; }
            set
            {
                if (registeredAt != value)
                {
                    registeredAt = value;
                    OnPropertyChanged(nameof(RegisteredAt));
                }
            }
        }

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