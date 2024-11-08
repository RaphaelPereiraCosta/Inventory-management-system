using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Connection
{
    public class DbConnect
    {
        // Creates an instance of the MySqlConnection class to connect to the database
        public MySqlConnection conectDb = new MySqlConnection(
            // Defines the connection string with the server, database, user, and password parameters
            "Server=localhost;Database=gerenciador_estoque;Uid=root;Pwd=1234;"
        );

        // Method to open the database connection
        public void Conect()
        {
            conectDb.Open();  // Opens the connection to the database
        }

        // Method to close the database connection
        public void Disconect()
        {
            conectDb.Close();  // Closes the connection to the database
        }
    }
}
