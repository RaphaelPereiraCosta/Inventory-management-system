using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class ProdMovService
    {
        private readonly ProdMovRepository _prodMovRepository;

        public ProdMovService()
        {
            _prodMovRepository = new ProdMovRepository();
        }

        public int AddProductMovement(ProductMovement productMovement)
        {
           
                return _prodMovRepository.AddMovement(productMovement);
            
           
        }

        public List<ProductMovement> GatherMovement()
        {
            return _prodMovRepository.GatherMovement();
        }


    }
}
