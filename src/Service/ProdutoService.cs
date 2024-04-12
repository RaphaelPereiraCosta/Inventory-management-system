using System.Collections.Generic;
using Gerenciador_de_estoque.src.Repositories;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProdutoService
    {
        readonly ProdutoRepository produtoRepository = new ProdutoRepository();

        public List<Product> GatherProdutos(string nome)
        {
            return produtoRepository.GatherProdutos(nome);
        }

        public Product GetOneProduto(int id)
        {
            return produtoRepository.GetOneProduto(id);
        }

        public void AddProduto(Product produto)
        {
            produtoRepository.AddProduto(produto);
        }

        public void UpdateProduto(Product produto)
        {
            produtoRepository.UpdateProduto(produto);
        }

        public void DeleteProduto(int id)
        {
            produtoRepository.DeleteProduto(id);
        }
    }
}
