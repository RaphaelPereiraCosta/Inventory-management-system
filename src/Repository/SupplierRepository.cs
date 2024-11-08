using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class SupplierRepository : IDisposable
    {
        // Database connection object
        readonly DbConnect _connection;

        // Constructor to initialize the database connection
        public SupplierRepository(DbConnect connect)
        {
            _connection = connect;
        }

        // Method to retrieve all suppliers from the database
        public List<Supplier> GatherSuppliers()
        {
            var suppliers = new List<Supplier>();
            var query = "SELECT * FROM supplier";

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
                                var supplier = new Supplier
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Street = reader.GetString("Street"),
                                    Number = reader.GetString("Number"),
                                    Complement = reader.GetString("Complement"),
                                    Neighborhood = reader.GetString("Neighborhood"),
                                    City = reader.GetString("City"),
                                    state = new State
                                    {
                                        Id = reader.GetInt32("State_Id")
                                    },
                                    CEP = reader.GetString("CEP"),
                                    Phone = reader.GetString("Phone"),
                                    Email = reader.GetString("Email")
                                };

                                suppliers.Add(supplier);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving suppliers: {ex.Message}");
            }

            return suppliers;
        }

        // Method to retrieve a single supplier by its ID
        public Supplier GetOneSupplier(int id)
        {
            Supplier supplier = null;
            var query = "SELECT * FROM supplier WHERE Id = @id";

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
                                supplier = new Supplier
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Street = reader.GetString("Street"),
                                    Number = reader.GetString("Number"),
                                    Complement = reader.GetString("Complement"),
                                    Neighborhood = reader.GetString("Neighborhood"),
                                    City = reader.GetString("City"),
                                    state = new State
                                    {
                                        Id = reader.GetInt32("State_Id")
                                    },
                                    CEP = reader.GetString("CEP"),
                                    Phone = reader.GetString("Phone"),
                                    Email = reader.GetString("Email")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving supplier: {ex.Message}");
            }

            return supplier;
        }

        // Method to add a new supplier to the database
        public void AddSupplier(Supplier supplier)
        {
            var query =
                "INSERT INTO supplier (Name, Street, Number, Complement, Neighborhood, City, State_Id, CEP, Phone, Email) VALUES (@name, @street, @number, @complement, @neighborhood, @city, @stateId, @cep, @phone, @email)";

            try
            {
                // Using the database connection to execute the query
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@name", supplier.Name);
                        command.Parameters.AddWithValue("@street", supplier.Street);
                        command.Parameters.AddWithValue("@number", supplier.Number);
                        command.Parameters.AddWithValue("@complement", supplier.Complement);
                        command.Parameters.AddWithValue("@neighborhood", supplier.Neighborhood);
                        command.Parameters.AddWithValue("@city", supplier.City);
                        command.Parameters.AddWithValue("@stateId", supplier.state.Id);
                        command.Parameters.AddWithValue("@cep", supplier.CEP);
                        command.Parameters.AddWithValue("@phone", supplier.Phone);
                        command.Parameters.AddWithValue("@email", supplier.Email);

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error adding supplier: {ex.Message}");
            }
        }

        // Method to update an existing supplier's information in the database
        public void UpdateSupplier(Supplier supplier)
        {
            var query =
                "UPDATE supplier SET Name = @name, Street = @street, Number = @number, Complement = @complement, Neighborhood = @neighborhood, City = @city, State_Id = @stateId, CEP = @cep, Phone = @phone, Email = @email WHERE Id = @id";

            try
            {
                // Using the database connection to execute the query
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@name", supplier.Name);
                        command.Parameters.AddWithValue("@street", supplier.Street);
                        command.Parameters.AddWithValue("@number", supplier.Number);
                        command.Parameters.AddWithValue("@complement", supplier.Complement);
                        command.Parameters.AddWithValue("@neighborhood", supplier.Neighborhood);
                        command.Parameters.AddWithValue("@city", supplier.City);
                        command.Parameters.AddWithValue("@stateId", supplier.state.Id);
                        command.Parameters.AddWithValue("@cep", supplier.CEP);
                        command.Parameters.AddWithValue("@phone", supplier.Phone);
                        command.Parameters.AddWithValue("@email", supplier.Email);
                        command.Parameters.AddWithValue("@id", supplier.Id);

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error updating supplier: {ex.Message}");
            }
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
