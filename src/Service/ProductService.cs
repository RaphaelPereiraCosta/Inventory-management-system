using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProductService
    {
        readonly ProductRepository _repository = new ProductRepository();

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public List<Product> GatherProducts()
        {
            return _repository.GatherProducts();
        }

        public Product GetOneProduct(int id)
        {
            return _repository.GetOneProduct(id);
        }

        public List<Product> GatherProductsByMovementId(int movementId)
        {
            return _repository.GatherProductsByMovementId(movementId);
        }

        public void AddProduct(Product produto)
        {
            _repository.AddProduct(produto);
        }

        public void UpdateProduct(Product produto)
        {
            _repository.UpdateProduct(produto);
        }
    }
}
