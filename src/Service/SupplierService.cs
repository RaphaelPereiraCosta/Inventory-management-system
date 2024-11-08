using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Services
{
    public class SupplierService
    {
        // Reference to the repository for handling data operations related to suppliers
        readonly SupplierRepository _repository;

        // Constructor to initialize the supplier repository
        public SupplierService()
        {
            _repository = new SupplierRepository(new DbConnect());
        }

        // Method to retrieve all suppliers from the repository
        public List<Supplier> GatherSuppliers()
        {
            return _repository.GatherSuppliers();
        }

        // Method to retrieve a single supplier by its ID
        public Supplier GetOneSupplier(int id)
        {
            return _repository.GetOneSupplier(id);
        }

        // Method to add a new supplier to the repository
        public void AddSupplier(Supplier supplier)
        {
            _repository.AddSupplier(supplier);
        }

        // Method to update an existing supplier's information in the repository
        public void UpdateSupplier(Supplier supplier)
        {
            _repository.UpdateSupplier(supplier);
        }
    }
}
