using PeopleManager.Abstracts;
using PeopleManager.Models;
using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace PeopleManager.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ObservableCollection<Person> GetAll()
        {
            var people = new ObservableCollection<Person>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Name, Surname, Fullname, Cpf, RegisteredAt FROM People";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            people.Add(new Person
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Fullname = reader["Fullname"].ToString(),
                                Cpf = reader["Cpf"].ToString(),
                                RegisteredAt = reader["RegisteredAt"].ToString()
                            });
                        }
                    }
                }
                connection.Close();
            }

            return people;
        }

        public void Create(Person person)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO People (Name, Surname, Fullname, Cpf, RegisteredAt) VALUES (@Name, @Surname, @Fullname, @Cpf, @RegisteredAt)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", person.Name);
                    command.Parameters.AddWithValue("@Surname", person.Surname);
                    command.Parameters.AddWithValue("@Fullname", person.Fullname);
                    command.Parameters.AddWithValue("@Cpf", person.Cpf);
                    command.Parameters.AddWithValue("@RegisteredAt", person.RegisteredAt);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(Person person)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE People SET Name = @Name, Surname = @Surname, Cpf = @Cpf WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", person.Id);
                    command.Parameters.AddWithValue("@Name", person.Name);
                    command.Parameters.AddWithValue("@Surname", person.Surname);
                    command.Parameters.AddWithValue("@Cpf", person.Cpf);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM People WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
