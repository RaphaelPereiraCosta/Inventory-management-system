using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class StateRepository : IDisposable
    {
        // Database connection object
        readonly DbConnect _connection;

        // Constructor to initialize the database connection
        public StateRepository(DbConnect connect)
        {
            _connection = connect;
        }

        // Method to retrieve all states from the database
        public List<State> GatherStates()
        {
            var states = new List<State>();
            var query = "SELECT * FROM state";

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
                                var state = new State
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name")
                                };

                                states.Add(state);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving states: {ex.Message}");
            }

            return states;
        }

        // Method to retrieve a single state by its ID
        public State GetOneState(int id)
        {
            State state = null;
            var query = "SELECT * FROM state WHERE Id = @id";
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
                                state = new State
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
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving state: {ex.Message}");
            }

            return state;
        }

        // Method to dispose the connection and clean up resources
        public void Dispose()
        {
            try
            {
                _connection.Disconect();
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error disconnecting: {ex.Message}");
            }
        }
    }
}