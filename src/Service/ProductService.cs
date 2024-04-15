using System.Collections.Generic;
using Gerenciador_de_estoque.src.Repositories;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProductService
    {
        readonly ProductRepository produtoRepository = new ProductRepository();

        public List<Product> GatherProdutos(string nome)
        {
            return produtoRepository.GatherProducts (nome);
        }

        public Product GetOneProduto(int id)
        {
            return produtoRepository.GetOneProduct(id);
        }

        public void AddProduto(Product produto)
        {
            produtoRepository.AddProduct(produto);
        }

        public void UpdateProduto(Product produto)
        {
            produtoRepository.UpdateProduct(produto);
        }

        public void DeleteProduto(int id)
        {
            produtoRepository.DeleteProduct(id);
        }
    }
}
