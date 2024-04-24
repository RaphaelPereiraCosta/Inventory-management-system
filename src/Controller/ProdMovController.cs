using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class ProdMovController
    {
        private readonly ProdMovService _prodMovService;
        private readonly ProductController _productController;
        private readonly Mov_Has_ProdService _movHas_ProdService;

        public ProdMovController()
        {
            _prodMovService = new ProdMovService();
            _productController = new ProductController();
            _movHas_ProdService = new Mov_Has_ProdService();
        }

        public void AddProductMovement(ProductMovement productMovement)
        {
            try
            {
                Utils utils = new Utils();

                productMovement.Id = _prodMovService.AddProductMovement(productMovement);

                if (productMovement.Id < 1)
                {
                    MessageBox.Show("Falha ao salvar o movimento do produto.");
                    return;
                }

                if (productMovement.Type == "Entrada")
                {
                    foreach (var product in productMovement.ProductsList)
                    {
                        product.AvailableAmount += product.AmountChange;
                    }
                }
                else
                {
                    foreach (var product in productMovement.ProductsList)
                    {
                        product.AvailableAmount -= product.AmountChange;
                    }
                }

                foreach (var selected in productMovement.ProductsList)
                {

                    bool isSaved = _productController.AddProduct(selected);

                    if (!isSaved)
                    {
                        MessageBox.Show("Falha ao salvar o produto.");
                        return;
                    }

                    _movHas_ProdService.AddMov_has_Prod(
                        productMovement.Id,
                        selected.Id,
                        selected.AmountChange
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }


        public List<ProductMovement> GatherMovement()
        {
            return _prodMovService.GatherMovement();
        }

    }
}
