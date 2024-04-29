using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Connection;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repository
{
    internal class Mov_Has_ProdRepository
    {
        private readonly DbConnect _connection;

        public Mov_Has_ProdRepository()
        {
            _connection = new DbConnect();
        }

        public int GetMovedAmount(int idMovement, int idProduct)
        {
            int movedAmount = 0;
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
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
                MessageBox.Show($"Erro ao obter quantidade movida: {ex.Message}");
            }
            return movedAmount;
        }

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
                MessageBox.Show($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }

        public void UpdateMovedAmount(int idMovement, int idProduct, int newMovedAmount)
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
                MessageBox.Show($"Erro ao atualizar quantidade movida: {ex.Message}");
            }
        }
    }
}
