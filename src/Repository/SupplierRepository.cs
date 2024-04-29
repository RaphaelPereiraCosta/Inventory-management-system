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
        readonly DbConnect _connection;

        public SupplierRepository()
        {
            _connection = new DbConnect();
        }

        public List<Supplier> GatherSuppliers()
        {
            var suppliers = new List<Supplier>();

            string query;

            query = "SELECT * FROM supplier";

            try
            {
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
                                    State = reader.GetString("State"),
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
                MessageBox.Show($"Erro ao recuperar fornecedores: {ex.Message}");
            }

            return suppliers;
        }

        public Supplier GetOneSupplier(int id)
        {
            Supplier supplier = null;
            var query = $"SELECT * FROM supplier WHERE Id = @id";

            try
            {
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
                                    State = reader.GetString("State"),
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
                MessageBox.Show($"Erro ao recuperar fornecedor: {ex.Message}");
            }

            return supplier;
        }

        public void AddSupplier(Supplier supplier)
        {
            var query =
                "INSERT INTO supplier (Name, Street, Number, Complement, Neighborhood, City, State, CEP, Phone, Email) VALUES (@name, @street, @number, @complement, @neighborhood, @city, @estado, @cep, @phone, @email)";

            try
            {
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
                        command.Parameters.AddWithValue("@state", supplier.State);
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
                MessageBox.Show($"Erro ao adicionar fornecedor: {ex.Message}");
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var query =
                "UPDATE supplier SET Name = @name, Street = @street, Number = @number, Complement = @complement, Neighborhood = @neighborhood, City = @city, State = @state, CEP = @cep, Phone = @phone, Email = @email WHERE Id = @id";

            try
            {
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
                        command.Parameters.AddWithValue("@state", supplier.State);
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
                MessageBox.Show($"Erro ao atualizar fornecedor: {ex.Message}");
            }
        }

        public void Dispose()
        {
            try
            {
                _connection.desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao desconectar: {ex.Message}");
            }
        }
    }
}
