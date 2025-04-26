using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public static class DatabaseHelper
    {
        private static string connectionString = "server=localhost;database=StudentDB;uid=root;pwd=tiger;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
