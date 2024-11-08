using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class MovementTypeRepository : IDisposable
    {
        // Database connection object
        readonly DbConnect _connection;

        // Constructor to initialize the database connection
        public MovementTypeRepository(DbConnect connect)
        {
            _connection = connect;
        }

        // Method to retrieve all types from the database
        public List<MovementType> GatherMovementTypes()
        {
            var types = new List<MovementType>();
            var query = "SELECT * FROM movement_type";

            try
            {
                // Using the database connection to execute the query
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        connectDb.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MovementType type = new MovementType
                                {
                                    
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name")
                                };


                                types.Add(type);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // It's better to throw the exception or log it rather than using MessageBox
                throw new Exception($"Error retrieving types: {ex.Message}", ex);
            }

            return types;
        }

        // Method to retrieve a single type by its ID
        public MovementType GetOneMovementType(int id)
        {
            MovementType type = null;
            var query = "SELECT * FROM movement_type WHERE Id = @id";
            try
            {
                // Using the database connection to execute the query
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        connectDb.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                type = new MovementType
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // It's better to throw the exception or log it rather than using MessageBox
                throw new Exception($"Error retrieving type: {ex.Message}", ex);
            }

            return type;
        }

        // Method to dispose the connection and clean up resources
        public void Dispose()
        {
            // Ensure the connection is initialized before attempting to disconnect
            try
            {
                _connection.Disconect();
            }
            catch (Exception ex)
            {
                // It's better to throw the exception or log it rather than using MessageBox
                throw new Exception($"Error disconnecting: {ex.Message}", ex);
            }
        }
    }
}
