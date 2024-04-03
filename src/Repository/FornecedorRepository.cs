using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.Connection;
using Gerenciador_de_estoque.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.Repositories
{
    public class FornecedorRepository : IDisposable
    {
        DbConnect _connection = new DbConnect();

        public List<Fornecedor> GatherFornecedores(string nome)
        {
            var fornecedores = new List<Fornecedor>();

            string query;

            if (string.IsNullOrEmpty(nome))
            {
                query = "SELECT * FROM Fornecedor";
            }
            else
            {
                query = "SELECT * FROM Fornecedor WHERE NomeFornecedor LIKE @nome";
            }

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
                            var fornecedor = new Fornecedor
                            {
                                IdFornecedor = reader.GetInt32("IdFornecedor"),
                                NomeFornecedor = reader.GetString("NomeFornecedor"),
                                Rua = reader.GetString("Rua"),
                                Numero = reader.GetString("Numero"),
                                Complemento = reader.GetString("Complemento"),
                                Bairro = reader.GetString("Bairro"),
                                Cidade = reader.GetString("Cidade"),
                                Estado = reader.GetString("Estado"),
                                CEP = reader.GetString("CEP"),
                                Telefone = reader.GetString("Telefone"),
                                Email = reader.GetString("Email")
                            };

                            fornecedores.Add(fornecedor);
                        }
                    }
                }
            }

            return fornecedores;
        }

        public Fornecedor GetOneFornecedor(int id)
        {
            Fornecedor fornecedor = null;
            var query = $"SELECT * FROM Fornecedor WHERE IdFornecedor = @id";

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
                            fornecedor = new Fornecedor
                            {
                                IdFornecedor = reader.GetInt32("IdFornecedor"),
                                NomeFornecedor = reader.GetString("NomeFornecedor"),
                                Rua = reader.GetString("Rua"),
                                Numero = reader.GetString("Numero"),
                                Complemento = reader.GetString("Complemento"),
                                Bairro = reader.GetString("Bairro"),
                                Cidade = reader.GetString("Cidade"),
                                Estado = reader.GetString("Estado"),
                                CEP = reader.GetString("CEP"),
                                Telefone = reader.GetString("Telefone"),
                                Email = reader.GetString("Email")
                            };
                        }
                    }
                }
            }

            return fornecedor;
        }

        public void AddFornecedor(Fornecedor fornecedor)
        {
            var query =
                "INSERT INTO Fornecedor (NomeFornecedor, Rua, Numero, Complemento, Bairro, Cidade, Estado, CEP, Telefone, Email) VALUES (@nomeFornecedor, @rua, @numero, @complemento, @bairro, @cidade, @estado, @cep, @telefone, @email)";

            using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
            {
                using (var command = new MySqlCommand(query, connectDb))
                {
                    command.Parameters.AddWithValue("@nomeFornecedor", fornecedor.NomeFornecedor);
                    command.Parameters.AddWithValue("@rua", fornecedor.Rua);
                    command.Parameters.AddWithValue("@numero", fornecedor.Numero);
                    command.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                    command.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                    command.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                    command.Parameters.AddWithValue("@estado", fornecedor.Estado);
                    command.Parameters.AddWithValue("@cep", fornecedor.CEP);
                    command.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                    command.Parameters.AddWithValue("@email", fornecedor.Email);

                    connectDb.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            var query =
                "UPDATE Fornecedor SET NomeFornecedor = @nomeFornecedor, Rua = @rua, Numero = @numero, Complemento = @complemento, Bairro = @bairro, Cidade = @cidade, Estado = @estado, CEP = @cep, Telefone = @telefone, Email = @email WHERE IdFornecedor = @idFornecedor";

            using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
            {
                using (var command = new MySqlCommand(query, connectDb))
                {
                    command.Parameters.AddWithValue("@nomeFornecedor", fornecedor.NomeFornecedor);
                    command.Parameters.AddWithValue("@rua", fornecedor.Rua);
                    command.Parameters.AddWithValue("@numero", fornecedor.Numero);
                    command.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                    command.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                    command.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                    command.Parameters.AddWithValue("@estado", fornecedor.Estado);
                    command.Parameters.AddWithValue("@cep", fornecedor.CEP);
                    command.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                    command.Parameters.AddWithValue("@email", fornecedor.Email);
                    command.Parameters.AddWithValue("@idFornecedor", fornecedor.IdFornecedor);

                    connectDb.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFornecedor(int id)
        {
            var query = "DELETE FROM Fornecedor WHERE IdFornecedor = @id";

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

        public void Dispose()
        {
            _connection.desconectar();
        }
    }
}
