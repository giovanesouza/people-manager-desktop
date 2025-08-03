using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace PeopleManager.Database
{
    public class DBConnection
    {

        private static readonly string DatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "DBSQLite.db");
        private static readonly string strConnection = $"Data Source={DatabasePath};Version=3;";

        //static DBConnection()
        //{
        //    InitializeDatabase();
        //}

        public static void InitializeDatabase()
        {
            EnsureDatabaseDirectoryExists();
            if (!File.Exists(DatabasePath))
            {
                SQLiteConnection.CreateFile(DatabasePath);
            }

            SQLiteConnection connection = new(strConnection);
            try
            {
                connection.Open();

                string tableCommand = @"
                CREATE TABLE IF NOT EXISTS People (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Surname TEXT NOT NULL,
                    Fullname TEXT NOT NULL,
                    Cpf TEXT UNIQUE NOT NULL,
                    RegisteredAt TEXT NOT NULL
                );";

                using (SQLiteCommand command = new(tableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }

                Debug.WriteLine("Connected database!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error connecting to database.:\n {ex}");
            }
            finally
            {
                connection.Close();
            }
        }

        private static void EnsureDatabaseDirectoryExists()
        {
            string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db");
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data Source={DatabasePath};");
        }

    }
}
