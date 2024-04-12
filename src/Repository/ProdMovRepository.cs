using System;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repository
{
    internal class ProdMovRepository
    {
        readonly DbConnect _connection = new DbConnect();

        public void Add(ProductMovement productMovement)
        {
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText = "INSERT INTO ProductMovement (IdMovement, IdSupplier, Type, Data) VALUES (@IdMovement, @IdSupplier, @Type, @Data)";
                        command.Parameters.AddWithValue("@IdMovement", productMovement.IdMovement);
                        command.Parameters.AddWithValue("@IdSupplier", productMovement.IdSupplier);
                        command.Parameters.AddWithValue("@Type", productMovement.Type);
                        command.Parameters.AddWithValue("@Data", productMovement.Data);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }

        public void AddMovementHasProduct(int idMovement, int idProduct, int movedAmount)
        {
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText = "INSERT INTO movement_has_product (IdMovement, IdProduct, MovedAmount) VALUES (@IdMovement, @IdProduct, @MovedAmount)";
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
    }
}
