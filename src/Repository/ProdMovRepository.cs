using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    internal class ProdMovRepository
    {
        private readonly DbConnect _connection = new DbConnect();

        public int AddMovement(ProductMovement productMovement)
        {
            int id = 0;
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText =
                            "INSERT INTO movement (Type, Date, Supplier_Id) VALUES (@Type, STR_TO_DATE(@Date, '%d/%m/%Y'), @Supplier_ID); SELECT LAST_INSERT_ID();";
                        command.Parameters.Add("@Type", MySqlDbType.VarChar).Value =
                            productMovement.Type;
                        command.Parameters.Add("@Date", MySqlDbType.VarChar).Value =
                            productMovement.Date;
                        command.Parameters.Add("@Supplier_ID", MySqlDbType.Int32).Value =
                            productMovement.Supplier.Id;

                        id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao adicionar movimento de produto: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return id;
        }

        public List<ProductMovement> GetByMovementId(int idMovement)
        {
            var movements = new List<ProductMovement>();
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText =
                            "SELECT *, DATE_FORMAT(Date, '%d/%m/%Y') AS FormattedDate FROM movement WHERE Id = @IdMovement";
                        command.Parameters.Add("@IdMovement", MySqlDbType.Int32).Value = idMovement;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var movement = new ProductMovement
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Supplier = new Supplier
                                    {
                                        Id = Convert.ToInt32(reader["Supplier_Id"])
                                    },
                                    Type = Convert.ToString(reader["Type"]),
                                    Date = Convert.ToString(reader["FormattedDate"])
                                };
                                movements.Add(movement);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao obter movimentos de produto: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return movements;
        }

        public List<ProductMovement> GatherMovement()
        {
            var movements = new List<ProductMovement>();
            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    connectDb.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connectDb;
                        command.CommandText =
                            "SELECT *, DATE_FORMAT(Date, '%d/%m/%Y') AS FormattedDate FROM movement";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var movement = new ProductMovement
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Supplier = new Supplier
                                    {
                                        Id = Convert.ToInt32(reader["Supplier_Id"])
                                    },
                                    Type = Convert.ToString(reader["Type"]),
                                    Date = Convert.ToString(reader["FormattedDate"])
                                };

                                movements.Add(movement);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao obter movimentos de produto: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return movements;
        }
    }
}
