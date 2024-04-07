using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class ProdutoRepository : IDisposable
    {
        DbConnect _connection = new DbConnect();

        public List<Produto> GatherProdutos(string nome)
        {
            var produtos = new List<Produto>();

            string query;

            if (string.IsNullOrEmpty(nome))
            {
                query = "SELECT * FROM Produto";
            }
            else
            {
                query = "SELECT * FROM Produto WHERE NomeProduto LIKE @nome";
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
                                var produto = new Produto
                                {
                                    IdProduto = reader.GetInt32("IdProduto"),
                                    NomeProduto = reader.GetString("NomeProduto"),
                                    Descricao = reader.GetString("Descricao"),
                                    QuantidadeEstoque = reader.GetInt32("QuantidadeEstoque")
                                };

                                produtos.Add(produto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar produtos: {ex.Message}");
            }

            return produtos;
        }

        public Produto GetOneProduto(int id)
        {
            Produto produto = null;
            var query = $"SELECT * FROM Produto WHERE IdProduto = @id";

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
                                produto = new Produto
                                {
                                    IdProduto = reader.GetInt32("IdProduto"),
                                    NomeProduto = reader.GetString("NomeProduto"),
                                    Descricao = reader.GetString("Descricao"),
                                    QuantidadeEstoque = reader.GetInt32("QuantidadeEstoque")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao recuperar produto: {ex.Message}");
            }

            return produto;
        }

        public void AddProduto(Produto produto)
        {
            var query =
                "INSERT INTO Produto (NomeProduto, Descricao, QuantidadeEstoque) VALUES (@nomeProduto, @descricao, @quantidadeEstoque)";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                        command.Parameters.AddWithValue("@descricao", produto.Descricao);
                        command.Parameters.AddWithValue(
                            "@quantidadeEstoque",
                            produto.QuantidadeEstoque
                        );

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        public void UpdateProduto(Produto produto)
        {
            var query =
                "UPDATE Produto SET NomeProduto = @nomeProduto, Descricao = @descricao, QuantidadeEstoque = @quantidadeEstoque WHERE IdProduto = @idProduto";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                        command.Parameters.AddWithValue("@descricao", produto.Descricao);
                        command.Parameters.AddWithValue(
                            "@quantidadeEstoque",
                            produto.QuantidadeEstoque
                        );
                        command.Parameters.AddWithValue("@idProduto", produto.IdProduto);

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        public void DeleteProduto(int id)
        {
            var query = "DELETE FROM Produto WHERE IdProduto = @id";

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
                Console.WriteLine($"Erro ao excluir produto: {ex.Message}");
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
