using System;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repository;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProdMovService
    {
        private readonly ProdMovRepository _prodMovRepository;

        public ProdMovService()
        {
            _prodMovRepository = new ProdMovRepository();
        }

        public void AddProductMovement(ProductMovement productMovement)
        {
            try
            {
                _prodMovRepository.Add(productMovement);
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
                _prodMovRepository.AddMovementHasProduct(idMovement, idProduct, movedAmount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto: {ex.Message}");
            }
        }
    }
}
