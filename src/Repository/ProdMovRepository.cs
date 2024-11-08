using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class ProdMovRepository
    {
        // Database connection object
        private readonly DbConnect _connection;

        // Constructor to initialize the database connection
        public ProdMovRepository(DbConnect connect)
        {
            _connection = connect;
        }

        // Method to retrieve all product movements from the database
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
                        command.CommandText = "SELECT Id, Supplier_Id, movement_type_Id, Date FROM movement";

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
                                    Type = new MovementType
                                    {
                                        Id = Convert.ToInt32(reader["movement_type_Id"])
                                    },
                                    Date = Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy")
                                };

                                movements.Add(movement);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving product movements: {ex.Message}", ex);
            }
            return movements;
        }

        // Method to retrieve product movements by movement ID
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
                        command.CommandText = "SELECT Id, Supplier_Id, movement_type_Id, Date FROM movement WHERE Id = @IdMovement";
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
                                    Type = new MovementType
                                    {
                                        Id = Convert.ToInt32(reader["movement_type_Id"])
                                    },
                                    Date = Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy")
                                };
                                movements.Add(movement);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving product movements by ID: {ex.Message}", ex);
            }
            return movements;
        }

        // Method to add a new product movement to the database and return its ID
        public int AddMovement(ProductMovement productMovement)
        {
            if (productMovement == null)
                throw new ArgumentNullException(nameof(productMovement));

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
                            "INSERT INTO movement (movement_type_Id, Date, Supplier_Id) VALUES (@Type, STR_TO_DATE(@Date, '%d/%m/%Y'), @Supplier_Id); SELECT LAST_INSERT_ID();";
                        command.Parameters.Add("@Type", MySqlDbType.Int32).Value = productMovement.Type.Id;
                        command.Parameters.Add("@Date", MySqlDbType.VarChar).Value = productMovement.Date;
                        command.Parameters.Add("@Supplier_Id", MySqlDbType.Int32).Value = productMovement.Supplier.Id;

                        id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error adding product movement: {ex.Message}", ex);
            }
            return id;
        }
    }
}
