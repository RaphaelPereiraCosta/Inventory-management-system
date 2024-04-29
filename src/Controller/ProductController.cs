using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class ProductController
    {
        readonly ProductService _service;
        public ProductController()
        {
            _service = new ProductService();
        }

        public List<Product> GatherProducts()
        {
            try
            {
                List<Product> products = _service.GatherProducts();

                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public List<Product> GatherProductsByMovementId(int movementId)
        {
            return _service.GatherProductsByMovementId(movementId);
        }

        public Product GetOneProduct(int id)
        {
            try
            {
                var produto = _service.GetOneProduct(id);
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
                if (product.Id <= 0)
                {
                    _service.AddProduct(product);
                }
                else
                {
                    _service.UpdateProduct(product);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return false;
            }
        }

        public List<string> ValidateProduct(Product product)
        {
            return GetEmptyFields(product);
        }

        private List<string> GetEmptyFields(Product product)
        {
            List<string> emptyFields = new List<string>();

            if (string.IsNullOrEmpty(product.Name))
                emptyFields.Add("Nome");
            if (product.AvailableAmount < 0)
                emptyFields.Add("Quantidade");

            return emptyFields;
        }
    }
}
