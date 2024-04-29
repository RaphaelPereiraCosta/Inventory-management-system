using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class SupplierService
    {
        readonly SupplierRepository _repository;

        public SupplierService()
        {
            _repository = new SupplierRepository();
        }

        public List<Supplier> GatherSuppliers()
        {
            return _repository.GatherSuppliers();
        }

        public Supplier GetOneSupplier(int id)
        {
            return _repository.GetOneSupplier(id);
        }

        public void AddSupplier(Supplier supplier)
        {
            _repository.AddSupplier(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _repository.UpdateSupplier(supplier);
        }
    }
}
