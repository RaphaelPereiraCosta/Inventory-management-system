using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class ProductController
    {
        // Service to handle product-related operations
        readonly ProductService _service;

        // Constructor to initialize the product service
        public ProductController()
        {
            _service = new ProductService();
        }

        // Method to gather all products from the database
        public List<Product> GatherProducts()
        {
            try
            {
                // Retrieve the list of products from the service
                List<Product> products = _service.GatherProducts();

                return products;
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Operation failed: {ex.Message}");
                return null;
            }
        }

        // Method to gather products associated with a specific movement ID
        public List<Product> GatherProductsByMovementId(int movementId)
        {
            return _service.GatherProductsByMovementId(movementId);
        }

        // Method to retrieve a single product by its ID
        public Product GetOneProduct(int id)
        {
            try
            {
                // Retrieve the product from the service
                var produto = _service.GetOneProduct(id);
                return produto;
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Operation failed: {ex.Message}");
                return null;
            }
        }

        // Method to add a new product or update an existing one
        public bool AddProduct(Product product)
        {
            try
            {
                // If the product ID is less than or equal to 0, it's a new product, so add it
                if (product.Id <= 0)
                {
                    _service.AddProduct(product);
                }
                // Otherwise, update the existing product
                else
                {
                    _service.UpdateProduct(product);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Operation failed: {ex.Message}");
                return false;
            }
        }

        // Method to validate the product by checking for empty fields
        public List<string> ValidateProduct(Product product)
        {
            return GetEmptyFields(product);
        }

        // Helper method to identify and return any empty fields in the product
        private List<string> GetEmptyFields(Product product)
        {
            List<string> emptyFields = new List<string>();

            // Check if the product name is null or empty
            if (string.IsNullOrEmpty(product.Name))
                emptyFields.Add("Name");

            // Check if the available amount is less than 0
            if (product.AvailableAmount < 0)
                emptyFields.Add("Quantity");

            return emptyFields;
        }
    }
}
