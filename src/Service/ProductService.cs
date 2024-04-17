using System.Collections.Generic;
using Gerenciador_de_estoque.src.Repositories;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProductService
    {
        readonly ProductRepository produtoRepository = new ProductRepository();

        public List<Product> GatherProducts(string nome)
        {
            return produtoRepository.GatherProducts (nome);
        }

        public Product GetOneProduct(int id)
        {
            return produtoRepository.GetOneProduct(id);
        }

        public void AddProduct(Product produto)
        {
            produtoRepository.AddProduct(produto);
        }

        public void UpdateProduct(Product produto)
        {
            produtoRepository.UpdateProduct(produto);
        }

        public void DeleteProduct(int id)
        {
            produtoRepository.DeleteProduct(id);
        }
    }
}
