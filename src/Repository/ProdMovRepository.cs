using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repository
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
                            "INSERT INTO ProductMovement (IdMovement, IdSupplier, Type, Data) VALUES (@IdMovement, @IdSupplier, @Type, @Data); SELECT LAST_INSERT_ID();";
                        command.Parameters.AddWithValue("@IdMovement", productMovement.IdMovement);
                        command.Parameters.AddWithValue("@IdSupplier", productMovement.IdSupplier);
                        command.Parameters.AddWithValue("@Type", productMovement.Type);
                        command.Parameters.AddWithValue("@Data", productMovement.Date);

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
                            "SELECT * FROM ProductMovement WHERE IdMovement = @IdMovement";
                        command.Parameters.AddWithValue("@IdMovement", idMovement);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var movement = new ProductMovement
                                {
                                    IdMovement = Convert.ToInt32(reader["IdMovement"]),
                                    IdSupplier = Convert.ToInt32(reader["IdSupplier"]),
                                    Type = Convert.ToString(reader["Type"]),
                                    Date = Convert.ToString(reader["Data"])
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
                            "SELECT * FROM ProductMovement";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var movement = new ProductMovement
                                {
                                    IdMovement = Convert.ToInt32(reader["IdMovement"]),
                                    IdSupplier = Convert.ToInt32(reader["IdSupplier"]),
                                    Type = Convert.ToString(reader["Type"]),
                                    Date = Convert.ToString(reader["Data"])
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
