using System;
using Gerenciador_de_estoque.src.Connection;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repository
{
    internal class Mov_Has_ProdRepository
    {
        private readonly DbConnect _connection = new DbConnect();

        public void AddMov_has_Prod(int idMovement, int idProduct, int movedAmount)
        {
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText =
                            "INSERT INTO movement_has_product (IdMovement, IdProduct, MovedAmount) VALUES (@IdMovement, @IdProduct, @MovedAmount)";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);
                        command.Parameters.AddWithValue("@IdProduct", idProduct);
                        command.Parameters.AddWithValue("@MovedAmount", movedAmount);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }

        public void DeleteMov_has_Prod(int idMovement, int idProduct)
        {
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText =
                            "DELETE FROM movement_has_product WHERE IdMovement = @IdMovement AND IdProduct = @IdProduct";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);
                        command.Parameters.AddWithValue("@IdProduct", idProduct);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar movimento de produto: {ex.Message}");
            }
        }
    }
}
