using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class FornecedorRepository : IDisposable
    {
        readonly DbConnect _connection = new DbConnect();

        public List<Supplier> GatherFornecedores(string nome)
        {
            var fornecedores = new List<Supplier>();

            string query;

            if (string.IsNullOrEmpty(nome))
            {
                query = "SELECT * FROM Fornecedor";
            }
            else
            {
                query = "SELECT * FROM Fornecedor WHERE Nome LIKE @nome";
            }

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        if (!string.IsNullOrEmpty(nome))
                        {
                            command.Parameters.AddWithValue("@nome", "%" + nome + "%");
                        }

                        connectDb.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var fornecedor = new Supplier
                                {
                                    IdSupplier = reader.GetInt32("IdFornecedor"),
                                    Name = reader.GetString("NomeFornecedor"),
                                    Street = reader.GetString("Rua"),
                                    Number = reader.GetString("Numero"),
                                    Complement = reader.GetString("Complemento"),
                                    Neighborhood = reader.GetString("Bairro"),
                                    City = reader.GetString("Cidade"),
                                    State = reader.GetString("Estado"),
                                    CEP = reader.GetString("CEP"),
                                    Phone = reader.GetString("Telefone"),
                                    Email = reader.GetString("Email")
                                };

                                fornecedores.Add(fornecedor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar fornecedores: {ex.Message}");
            }

            return fornecedores;
        }

        public Supplier GetOneFornecedor(int id)
        {
            Supplier fornecedor = null;
            var query = $"SELECT * FROM Fornecedor WHERE IdFornecedor = @id";

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
                                fornecedor = new Supplier
                                {
                                    IdSupplier = reader.GetInt32("IdFornecedor"),
                                    Name = reader.GetString("NomeFornecedor"),
                                    Street = reader.GetString("Rua"),
                                    Number = reader.GetString("Numero"),
                                    Complement = reader.GetString("Complemento"),
                                    Neighborhood = reader.GetString("Bairro"),
                                    City = reader.GetString("Cidade"),
                                    State = reader.GetString("Estado"),
                                    CEP = reader.GetString("CEP"),
                                    Phone = reader.GetString("Telefone"),
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

            return fornecedor;
        }

        public void AddFornecedor(Supplier fornecedor)
        {
            var query =
                "INSERT INTO Fornecedor (NomeFornecedor, Rua, Numero, Complemento, Bairro, Cidade, Estado, CEP, Email, Telefone) VALUES (@nomeFornecedor, @rua, @numero, @complemento, @bairro, @cidade, @estado, @cep, @email)";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@nomeFornecedor", fornecedor.Name);
                        command.Parameters.AddWithValue("@rua", fornecedor.Street);
                        command.Parameters.AddWithValue("@numero", fornecedor.Number);
                        command.Parameters.AddWithValue("@complemento", fornecedor.Complement);
                        command.Parameters.AddWithValue("@bairro", fornecedor.Neighborhood);
                        command.Parameters.AddWithValue("@cidade", fornecedor.City);
                        command.Parameters.AddWithValue("@estado", fornecedor.State);
                        command.Parameters.AddWithValue("@cep", fornecedor.CEP);
                        command.Parameters.AddWithValue("@email", fornecedor.Email);
                        command.Parameters.AddWithValue("@telefone", fornecedor.Phone);

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

        public void UpdateFornecedor(Supplier fornecedor)
        {
            var query =
                "UPDATE Fornecedor SET NomeFornecedor = @nomeFornecedor, Rua = @rua, Numero = @numero, Complemento = @complemento, Bairro = @bairro, Cidade = @cidade, Estado = @estado, CEP = @cep, Email = @email, Telefone = @telefone WHERE IdFornecedor = @idFornecedor";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@nomeFornecedor", fornecedor.Name);
                        command.Parameters.AddWithValue("@rua", fornecedor.Street);
                        command.Parameters.AddWithValue("@numero", fornecedor.Number);
                        command.Parameters.AddWithValue("@complemento", fornecedor.Complement);
                        command.Parameters.AddWithValue("@bairro", fornecedor.Neighborhood);
                        command.Parameters.AddWithValue("@cidade", fornecedor.Street);
                        command.Parameters.AddWithValue("@estado", fornecedor.State);
                        command.Parameters.AddWithValue("@cep", fornecedor.CEP);
                        command.Parameters.AddWithValue("@email", fornecedor.Email);
                        command.Parameters.AddWithValue("@telefone", fornecedor.Phone);
                        command.Parameters.AddWithValue("@idFornecedor", fornecedor.IdSupplier);

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

        public void DeleteFornecedor(int id)
        {
            var query = "DELETE FROM Fornecedor WHERE IdFornecedor = @id";

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
