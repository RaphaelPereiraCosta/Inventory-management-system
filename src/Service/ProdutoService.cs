using System.Collections.Generic;
using Gerenciador_de_estoque.src.Repositories;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProdutoService
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        public List<Produto> GatherProdutos(string nome)
        {
            return produtoRepository.GatherProdutos(nome);
        }

        public Produto GetOneProduto(int id)
        {
            return produtoRepository.GetOneProduto(id);
        }

        public void AddProduto(Produto produto)
        {
            produtoRepository.AddProduto(produto);
        }

        public void UpdateProduto(Produto produto)
        {
            produtoRepository.UpdateProduto(produto);
        }

        public void DeleteProduto(int id)
        {
            produtoRepository.DeleteProduto(id);
        }
    }
}
