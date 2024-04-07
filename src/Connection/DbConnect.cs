using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Connection
{
    public class DbConnect
    {
        public MySqlConnection conectDb = new MySqlConnection(
            "Server=localhost;Database=gerenciador_estoque;Uid=root;Pwd=1234;"
        );

        public void conectar()
        {
            conectDb.Open();
        }

        public void desconectar()
        {
            conectDb.Close();
        }
    }
}
