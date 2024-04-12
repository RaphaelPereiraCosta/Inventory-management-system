using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class ProductController
    {
        readonly ProductService produtoService = new ProductService();

        public List<Product> GatherProdutos(string nome)
        {
            try
            {
                var produtos = produtoService.GatherProdutos(nome);
                return produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public Product GetOneProduto(int id)
        {
            try
            {
                var produto = produtoService.GetOneProduto(id);
                return produto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public void AddProduto(Product produto)
        {
            try
            {
                if (string.IsNullOrEmpty(produto.Name) || produto.AvaliableAmount < 0)
                {
                    throw new ArgumentException(
                        "Nome, Descrição, Preço e Quantidade em Estoque do produto não podem estar vazios ou negativos"
                    );
                }
                else
                {
                    if (produto.IdProduct <= 0)
                    {
                        produtoService.AddProduto(produto);
                        MessageBox.Show("Produto adicionado com sucesso!");
                    }
                    else
                    {
                        produtoService.UpdateProduto(produto);
                        MessageBox.Show("Produto editado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
        }

        public void DeleteProduto(int id)
        {
            try
            {
                produtoService.DeleteProduto(id);
                MessageBox.Show("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
        }
    }
}
