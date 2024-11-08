using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class ProdMovController
    {
        // Services and controllers to handle business logic
        private readonly ProdMovService _service;
        private readonly ProductController _productController;
        private readonly Mov_Has_ProdService _movHas_ProdService;

        // Constructor to initialize services and controllers
        public ProdMovController()
        {
            _service = new ProdMovService();
            _productController = new ProductController();
            _movHas_ProdService = new Mov_Has_ProdService();
        }

        // Method to add a product movement and update related data
        public void AddProductMovement(ProductMovement productMovement)
        {
            try
            {
                // Add the movement record to the database
                AddMovement(productMovement);

                // Update the available amount of each product based on the movement type
                UpdateProductAmounts(productMovement);

                // Save the updated products and associate them with the movement
                UpdateProducts(productMovement);
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Error adding product movement: {ex.Message}");
            }
        }

        // Method to add the movement record to the database
        private void AddMovement(ProductMovement productMovement)
        {
            // Save the product movement and get the generated ID
            productMovement.Id = _service.AddProductMovement(productMovement);

            // Check if the movement was saved successfully
            if (productMovement.Id < 1)
            {
                MessageBox.Show("Failed to save the product movement.");
                return;
            }
        }

        // Method to update the available amounts of the products based on the movement type
        private void UpdateProductAmounts(ProductMovement productMovement)
        {
            // If the movement is an entry, increase the available amount of each product
            if (productMovement.Type.Id == 1)
            {
                foreach (var product in productMovement.ProductsList)
                {
                    product.AvailableAmount += product.AmountChange;
                }
            }
            // If the movement is an exit, decrease the available amount of each product
            else
            {
                foreach (var product in productMovement.ProductsList)
                {
                    product.AvailableAmount -= product.AmountChange;
                }
            }
        }

        // Method to save the updated products and associate them with the movement
        private void UpdateProducts(ProductMovement productMovement)
        {
            foreach (var selected in productMovement.ProductsList)
            {
                // Save each product and check if it was saved successfully
                bool isSaved = _productController.AddProduct(selected);

                if (!isSaved)
                {
                    MessageBox.Show("Failed to save the product.");
                    return;
                }

                // Associate the product with the movement in the database
                _movHas_ProdService.AddMov_has_Prod(
                    productMovement.Id,
                    selected.Id,
                    selected.AmountChange
                );
            }
        }

        // Method to gather all product movements from the database
        public List<ProductMovement> GatherMovement()
        {
            return _service.GatherMovement();
        }
    }
}
