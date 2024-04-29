using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using MySql.Data.MySqlClient;

namespace Gerenciador_de_estoque.src.Repositories
{
    public class ProductRepository : IDisposable
    {
        readonly DbConnect _connection;

        public ProductRepository()
        {
            _connection = new DbConnect();
        }

        public List<Product> GatherProducts()
        {
            var products = new List<Product>();

            string query;
            query = "SELECT * FROM product";

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
                                var product = new Product
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                        ? null
                                        : reader.GetString("Description"),
                                    AvailableAmount = reader.GetInt32("AvailableAmount")
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar produtos: {ex.Message}");
            }

            return products;
        }

        public List<Product> GatherProductsByMovementId(int movementId)
        {
            var products = new List<Product>();
            var query =
                @"SELECT p.*, mhp.MovedAmount FROM product p INNER JOIN movement_has_product mhp 
         ON p.Id = mhp.product_Id
         WHERE mhp.movement_Id = @movementId";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@movementId", movementId);
                        connectDb.Open();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                        ? null
                                        : reader.GetString("Description"),
                                    AvailableAmount = reader.GetInt32("AvailableAmount"),
                                    AmountChange = reader.GetInt32("MovedAmount")
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar produtos do movimento: {ex.Message}");
            }

            return products;
        }

        public Product GetOneProduct(int id)
        {
            Product product = null;
            var query = $"SELECT * FROM product WHERE Id = @id";

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
                                product = new Product
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Name"),
                                    Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                        ? null
                                        : reader.GetString("Description"),
                                    AvailableAmount = reader.GetInt32("AvailableAmount")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar produto: {ex.Message}");
            }

            return product;
        }

        public void AddProduct(Product product)
        {
            var query =
                "INSERT INTO product (Name, Description, AvailableAmount) VALUES (@Name, @Description, @AvailableAmount)";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue(
                            "@AvailableAmount",
                            product.AvailableAmount
                        );

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        public void UpdateProduct(Product product)
        {
            var query =
                "UPDATE product SET Name = @Name, Description = @Description, AvailableAmount = @AvailableAmount WHERE Id = @Id";

            try
            {
                using (var connectDb = new MySqlConnection(_connection.conectDb.ConnectionString))
                {
                    using (var command = new MySqlCommand(query, connectDb))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue(
                            "@AvailableAmount",
                            product.AvailableAmount
                        );
                        command.Parameters.AddWithValue("@Id", product.Id);

                        connectDb.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar produto: {ex.Message}");
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
