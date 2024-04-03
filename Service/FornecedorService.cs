using System.Collections.Generic;
using Gerenciador_de_estoque.Models;
using Gerenciador_de_estoque.Repositories;

namespace Gerenciador_de_estoque.Services
{
    public class FornecedorService
    {
        FornecedorRepository fornecedorRepository = new FornecedorRepository();

        public List<Fornecedor> GatherFornecedores(string nome)
        {
            return fornecedorRepository.GatherFornecedores(nome);
        }

        public Fornecedor GetOneFornecedor(int id)
        {
            return fornecedorRepository.GetOneFornecedor(id);
        }

        public void AddFornecedor(Fornecedor fornecedor)
        {
            fornecedorRepository.AddFornecedor(fornecedor);
        }

        public void UpdateFornecedor(Fornecedor fornecedor)
        {
            fornecedorRepository.UpdateFornecedor(fornecedor);
        }

        public void DeleteFornecedor(int id)
        {
            fornecedorRepository.DeleteFornecedor(id);
        }
    }
}
