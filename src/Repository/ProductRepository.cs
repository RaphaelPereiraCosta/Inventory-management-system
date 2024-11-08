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
        // Database connection object
        readonly DbConnect _connection;

        // Constructor to initialize the database connection
        public ProductRepository(DbConnect connect)
        {
            _connection = connect;
        }

        // Method to retrieve all products from the database
        public List<Product> GatherProducts()
        {
            var products = new List<Product>();

            string query = "SELECT * FROM product";

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
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving products: {ex.Message}");
            }

            return products;
        }

        // Method to retrieve products by movement ID
        public List<Product> GatherProductsByMovementId(int movementId)
        {
            var products = new List<Product>();
            var query =
                @"SELECT p.*, mhp.MovedAmount FROM product p INNER JOIN movement_has_product mhp 
                 ON p.Id = mhp.product_Id
                 WHERE mhp.movement_Id = @movementId";

            try
            {
                // Using the database connection to execute the query
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
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving products for the movement: {ex.Message}");
            }

            return products;
        }

        // Method to retrieve a single product by its ID
        public Product GetOneProduct(int id)
        {
            Product product = null;
            var query = $"SELECT * FROM product WHERE Id = @id";

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
                // Display an error message if something goes wrong
                MessageBox.Show($"Error retrieving product: {ex.Message}");
            }

            return product;
        }

        // Method to add a new product to the database
        public void AddProduct(Product product)
        {
            var query =
                "INSERT INTO product (Name, Description, AvailableAmount) VALUES (@Name, @Description, @AvailableAmount)";

            try
            {
                // Using the database connection to execute the insert command
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
                // Display an error message if something goes wrong
                MessageBox.Show($"Error adding product: {ex.Message}");
            }
        }

        // Method to update an existing product in the database
        public void UpdateProduct(Product product)
        {
            var query =
                "UPDATE product SET Name = @Name, Description = @Description, AvailableAmount = @AvailableAmount WHERE Id = @Id";

            try
            {
                // Using the database connection to execute the update command
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
                // Display an error message if something goes wrong
                MessageBox.Show($"Error updating product: {ex.Message}");
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
