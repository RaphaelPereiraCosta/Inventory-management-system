using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repository;
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

                productMovement.IdMovement = _prodMovService.AddProductMovement(productMovement);

                if (productMovement.IdMovement < 1)
                {
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
                    Product registproduct = new Product();

                    registproduct = utils.ConvertSelectedToProduct(selected);

                    _productController.AddProduct(registproduct);

                    _movHas_ProdService.AddMov_has_Prod(
                        productMovement.IdMovement,
                        registproduct.Id,
                        selected.AmountChange
                    );
                }

                Console.WriteLine("Movimento de produto adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }

        public List<ProductMovement> GatherMovement()
        {
            return _prodMovService.GatherMovement();
        }

    }
}
