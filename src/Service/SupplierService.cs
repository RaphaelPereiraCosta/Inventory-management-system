using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class SupplierService
    {
        readonly SupplierRepository fornecedorRepository = new SupplierRepository();

        public List<Supplier> GatherFornecedores(string nome)
        {
            return fornecedorRepository.GatherSuppliers(nome);
        }

        public Supplier GetOneFornecedor(int id)
        {
            return fornecedorRepository.GetOneSupplier(id);
        }

        public void AddFornecedor(Supplier fornecedor)
        {
            fornecedorRepository.AddSupplier(fornecedor);
        }

        public void UpdateFornecedor(Supplier fornecedor)
        {
            fornecedorRepository.UpdateSupplier(fornecedor);
        }

        public void DeleteFornecedor(int id)
        {
            fornecedorRepository.DeleteSupplier(id);
        }
    }
}
