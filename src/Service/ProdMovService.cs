using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProdMovService
    {
        private readonly ProdMovRepository _repository;

        public ProdMovService()
        {
            _repository = new ProdMovRepository();
        }

        public List<ProductMovement> GatherMovement()
        {
            return _repository.GatherMovement();
        }

        public int AddProductMovement(ProductMovement productMovement)
        {
            return _repository.AddMovement(productMovement);
        }
    }
}
