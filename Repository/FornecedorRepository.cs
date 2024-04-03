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
                                Endereco = reader.GetString("Endereco"),
                                Contato = reader.GetString("Contato")
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
                                Endereco = reader.GetString("Endereco"),
                                Contato = reader.GetString("Contato")
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
                "INSERT INTO Fornecedor (NomeFornecedor, Endereco, Contato) VALUES (@nomeFornecedor, @endereco, @contato)";

            using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
            {
                using (var command = new MySqlCommand(query, connectDb))
                {
                    command.Parameters.AddWithValue("@nomeFornecedor", fornecedor.NomeFornecedor);
                    command.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                    command.Parameters.AddWithValue("@contato", fornecedor.Contato);

                    connectDb.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            var query =
                "UPDATE Fornecedor SET NomeFornecedor = @nomeFornecedor, Endereco = @endereco, Contato = @contato WHERE IdFornecedor = @idFornecedor";

            using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
            {
                using (var command = new MySqlCommand(query, connectDb))
                {
                    command.Parameters.AddWithValue("@nomeFornecedor", fornecedor.NomeFornecedor);
                    command.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                    command.Parameters.AddWithValue("@contato", fornecedor.Contato);
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
