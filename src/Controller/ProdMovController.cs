using System;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class ProdMovController
    {
        private readonly ProdMovService _prodMovService;

        public ProdMovController()
        {
            _prodMovService = new ProdMovService();
        }

        public void AddProductMovement(ProductMovement productMovement)
        {
            try
            {
                _prodMovService.AddProductMovement(productMovement);
                Console.WriteLine("Movimento de produto adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }

        public void AddMovementHasProduct(int idMovement, int idProduct, int movedAmount)
        {
            try
            {
                _prodMovService.AddMovementHasProduct(idMovement, idProduct, movedAmount);
                Console.WriteLine("Movimento de produto adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }
    }
}
