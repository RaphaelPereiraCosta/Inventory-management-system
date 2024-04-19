using System.Collections.Generic;
using Gerenciador_de_estoque.src.Repositories;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProductService
    {
        readonly ProductRepository productRepository = new ProductRepository();

        public List<Product> GatherProducts(string nome)
        {
            return productRepository.GatherProducts (nome);
        }

        public List<Product> GatherProductsByMovementId(int movementId)
        {
            return productRepository.GatherProductsByMovementId(movementId);
        }

        public Product GetOneProduct(int id)
        {
            return productRepository.GetOneProduct(id);
        }

        public void AddProduct(Product produto)
        {
            productRepository.AddProduct(produto);
        }

        public void UpdateProduct(Product produto)
        {
            productRepository.UpdateProduct(produto);
        }

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }
    }
}
