using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class SupplierRepository : IDisposable
    {
        readonly DbConnect _connection = new DbConnect();

        public List<Supplier> GatherSuppliers(string name)
        {
            var suppliers = new List<Supplier>();

            string query;

            if (string.IsNullOrEmpty(name))
            {
                query = "SELECT * FROM supplier";
            }
            else
            {
                query = "SELECT * FROM supplier WHERE Name LIKE @name";
            }

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        if (!string.IsNullOrEmpty(name))
                        {
                            command.Parameters.AddWithValue("@name", "%" + name + "%");
                        }

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
                                    State = reader.GetString("Estado"),
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
                Console.WriteLine($"Erro ao recuperar fornecedores: {ex.Message}");
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
                                    State = reader.GetString("Estado"),
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
                Console.WriteLine($"Erro ao recuperar fornecedor: {ex.Message}");
            }

            return supplier;
        }

        public void AddSupplier(Supplier supplier)
        {
            var query =
                "INSERT INTO supplier (Name, Street, Number, Complement, Neighborhood, City, Estado, CEP, Phone, Email) VALUES (@name, @street, @number, @complement, @neighborhood, @city, @estado, @cep, @phone, @email)";

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
                        command.Parameters.AddWithValue("@estado", supplier.State);
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
                Console.WriteLine($"Erro ao adicionar fornecedor: {ex.Message}");
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var query =
                "UPDATE supplier SET Name = @name, Street = @street, Number = @number, Complement = @complement, Neighborhood = @neighborhood, City = @city, Estado = @estado, CEP = @cep, Phone = @phone, Email = @email WHERE Id = @id";

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
                        command.Parameters.AddWithValue("@estado", supplier.State);
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
                Console.WriteLine($"Erro ao atualizar fornecedor: {ex.Message}");
            }
        }

        public void DeleteSupplier(int id)
        {
            var query = "DELETE FROM supplier WHERE Id = @id";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir fornecedor: {ex.Message}");
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
                Console.WriteLine($"Erro ao desconectar: {ex.Message}");
            }
        }
    }
}
