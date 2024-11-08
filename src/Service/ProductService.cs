using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProductService
    {
        // Reference to the repository for handling data operations related to products
        private readonly ProductRepository _repository;

        // Constructor to initialize the repository
        public ProductService()
        {
            _repository = new ProductRepository(new DbConnect());
        }

        // Method to gather all products from the repository
        public List<Product> GatherProducts()
        {
            return _repository.GatherProducts();
        }

        // Method to retrieve a single product by its ID from the repository
        public Product GetOneProduct(int id)
        {
            return _repository.GetOneProduct(id);
        }

        // Method to gather products associated with a specific movement ID
        public List<Product> GatherProductsByMovementId(int movementId)
        {
            return _repository.GatherProductsByMovementId(movementId);
        }

        // Method to add a new product to the repository
        public void AddProduct(Product produto)
        {
            _repository.AddProduct(produto);
        }

        // Method to update an existing product in the repository
        public void UpdateProduct(Product produto)
        {
            _repository.UpdateProduct(produto);
        }
    }
}
