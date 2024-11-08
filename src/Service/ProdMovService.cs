using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProdMovService
    {
        // Reference to the repository for handling data operations related to product movements
        private readonly ProdMovRepository _repository;

        // Constructor to initialize the repository
        public ProdMovService()
        {
            _repository = new ProdMovRepository(new DbConnect());
        }

        // Method to gather all product movements from the repository
        public List<ProductMovement> GatherMovement()
        {
            return _repository.GatherMovement();
        }

        // Method to add a new product movement to the repository
        public int AddProductMovement(ProductMovement productMovement)
        {
            return _repository.AddMovement(productMovement);
        }
    }
}
