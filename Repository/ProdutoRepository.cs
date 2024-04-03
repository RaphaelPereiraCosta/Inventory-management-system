using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.Connection;
using Gerenciador_de_estoque.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.Repositories
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
                                Preco = reader.GetDouble("Preco"),
                                QuantidadeEstoque = reader.GetInt32("QuantidadeEstoque")
                            };

                            produtos.Add(produto);
                        }
                    }
                }
            }

            return produtos;
        }

        public Produto GetOneProduto(int id)
        {
            Produto produto = null;
            var query = $"SELECT * FROM Produto WHERE IdProduto = @id";

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
                                Preco = reader.GetDouble("Preco"),
                                QuantidadeEstoque = reader.GetInt32("QuantidadeEstoque")
                            };
                        }
                    }
                }
            }

            return produto;
        }

        public void AddProduto(Produto produto)
        {
            var query =
                "INSERT INTO Produto (NomeProduto, Descricao, Preco, QuantidadeEstoque) VALUES (@nomeProduto, @descricao, @preco, @quantidadeEstoque)";

            using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
            {
                using (var command = new MySqlCommand(query, connectDb))
                {
                    command.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@preco", produto.Preco);
                    command.Parameters.AddWithValue(
                        "@quantidadeEstoque",
                        produto.QuantidadeEstoque
                    );

                    connectDb.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduto(Produto produto)
        {
            var query =
                "UPDATE Produto SET NomeProduto = @nomeProduto, Descricao = @descricao, Preco = @preco, QuantidadeEstoque = @quantidadeEstoque WHERE IdProduto = @idProduto";

            using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
            {
                using (var command = new MySqlCommand(query, connectDb))
                {
                    command.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@preco", produto.Preco);
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

        public void DeleteProduto(int id)
        {
            var query = "DELETE FROM Produto WHERE IdProduto = @id";

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
