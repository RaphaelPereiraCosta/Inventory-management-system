using System;
using Gerenciador_de_estoque.src.Repository;

namespace Gerenciador_de_estoque.src.Services
{
    internal class Mov_Has_ProdService
    {
        private readonly Mov_Has_ProdRepository _repository = new Mov_Has_ProdRepository();

        public void AddMov_has_Prod(int idMovement, int idProduct, int movedAmount)
        {
            try
            {
                _repository.AddMov_has_Prod(idMovement, idProduct, movedAmount);
                Console.WriteLine("Movimento de produto adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar movimento de produto na camada de serviço: {ex.Message}");
            }
        }

        public void DeleteMov_has_Prod(int idMovement, int idProduct)
        {
            try
            {
                _repository.DeleteMov_has_Prod(idMovement, idProduct);
                Console.WriteLine("Movimento de produto deletado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar movimento de produto na camada de serviço: {ex.Message}");
            }
        }
    }
}
