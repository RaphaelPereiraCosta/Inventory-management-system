using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class SupplierService
    {
        readonly SupplierRepository supplierRepository = new SupplierRepository();

        public List<Supplier> GatherSuppliers()
        {
            return supplierRepository.GatherSuppliers();
        }

        public Supplier GetOneSupplier(int id)
        {
            return supplierRepository.GetOneSupplier(id);
        }

        public void AddSupplier(Supplier supplier)
        {
            supplierRepository.AddSupplier(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            supplierRepository.UpdateSupplier(supplier);
        }

    }
}
