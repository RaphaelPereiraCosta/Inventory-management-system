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

        public List<Product> GatherProducts(string nome)
        {
            try
            {
                var produtos = produtoService.GatherProducts(nome);
                return produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public Product GetOneProduct(int id)
        {
            try
            {
                var produto = produtoService.GetOneProduct(id);
                return produto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public bool AddProduct(Product product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Name) || product.AvailableAmount < 0)
                {
                    throw new ArgumentException(
                        "Nome e Quantidade do produto não podem estar vazios ou negativos"
                    );
                }
                else
                {
                    if (product.Id <= 0)
                    {
                        produtoService.AddProduct(product);
                        MessageBox.Show("Produto adicionado com sucesso!");
                    }
                    else
                    {
                        produtoService.UpdateProduct(product);
                        MessageBox.Show("Produto editado com sucesso!");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return false;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                produtoService.DeleteProduct(id);
                MessageBox.Show("Produto deletado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
        }
    }
}
