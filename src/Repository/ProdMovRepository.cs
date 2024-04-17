using System;
using System.Collections.Generic;
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
                            "INSERT INTO movement (Type, Date, Supplier_ID) VALUES (@Type, @Date, @Supplier_ID); SELECT LAST_INSERT_ID();";
                        command.Parameters.AddWithValue("@Type", productMovement.Type);
                        command.Parameters.AddWithValue("@Date", productMovement.Date);
                        command.Parameters.AddWithValue("@Supplier_ID", productMovement.Supplier.IdSupplier);

                        id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
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
                            "SELECT * FROM movement WHERE Id = @IdMovement";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var movement = new ProductMovement
                                {
                                    IdMovement = Convert.ToInt32(reader["Id"]),
                                    Supplier = new Supplier { IdSupplier = Convert.ToInt32(reader["Supplier_ID"]) },
                                    Type = Convert.ToString(reader["Type"]),
                                    Date = Convert.ToString(reader["Date"])
                                };
                                movements.Add(movement);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter movimentos de produto: {ex.Message}");
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
                            "SELECT * FROM movement";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var movement = new ProductMovement
                                {
                                    IdMovement = Convert.ToInt32(reader["Id"]),
                                    Supplier = new Supplier { IdSupplier = Convert.ToInt32(reader["Supplier_ID"]) },
                                    Type = Convert.ToString(reader["Type"]),
                                    Date = Convert.ToString(reader["Date"])
                                };

                                movements.Add(movement);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter movimentos de produto: {ex.Message}");
            }
            return movements;
        }
    }
}
