using System;
using Gerenciador_de_estoque.src.Connection;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repository
{
    public class Mov_Has_ProdRepository
    {
        // Database connection object
        private readonly DbConnect _connection;

        // Constructor to initialize the database connection
        public Mov_Has_ProdRepository(DbConnect connect)
        {
            _connection = connect;
        }

        // Virtual method to create MySqlConnection, allowing it to be overridden in tests
        protected virtual MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connection.conectDb.ConnectionString);
        }

        // Virtual method to create MySqlCommand, allowing it to be overridden in tests
        protected virtual MySqlCommand CreateCommand(MySqlConnection connection)
        {
            return connection.CreateCommand();
        }

        // Method to retrieve the moved amount of a specific product in a specific movement
        public int GetMovedAmount(int idMovement, int idProduct)
        {
            int movedAmount = 0;
            try
            {
                using (var connectDb = CreateConnection())
                {
                    connectDb.Open();

                    using (var command = CreateCommand(connectDb))
                    {
                        command.CommandText =
                            "SELECT MovedAmount FROM movement_has_product WHERE movement_Id = @IdMovement AND product_Id = @IdProduct";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);
                        command.Parameters.AddWithValue("@IdProduct", idProduct);

                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            movedAmount = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving moved amount: {ex.Message}");
            }
            return movedAmount;
        }

        // Method to add a new movement-product relationship to the database
        public void AddMov_has_Prod(int idMovement, int idProduct, int movedAmount)
        {
            try
            {
                using (var connectDb = CreateConnection())
                {
                    connectDb.Open();

                    using (var command = CreateCommand(connectDb))
                    {
                        command.CommandText =
                            "INSERT INTO movement_has_product (movement_Id, product_Id, MovedAmount) VALUES (@IdMovement, @IdProduct, @MovedAmount)";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);
                        command.Parameters.AddWithValue("@IdProduct", idProduct);
                        command.Parameters.AddWithValue("@MovedAmount", movedAmount);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding product movement: {ex.Message}");
            }
        }

        // Method to update the moved amount of a product in a specific movement
        public void UpdateMovedAmount(int idMovement, int idProduct, int newMovedAmount)
        {
            try
            {
                using (var connectDb = CreateConnection())
                {
                    connectDb.Open();

                    using (var command = CreateCommand(connectDb))
                    {
                        command.CommandText =
                            "UPDATE movement_has_product SET MovedAmount = @MovedAmount WHERE movement_Id = @IdMovement AND product_Id = @IdProduct";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);
                        command.Parameters.AddWithValue("@IdProduct", idProduct);
                        command.Parameters.AddWithValue("@MovedAmount", newMovedAmount);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating moved amount: {ex.Message}");
            }
        }
    }
}
