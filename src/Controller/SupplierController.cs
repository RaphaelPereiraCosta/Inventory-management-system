using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class SupplierController
    {
        // Service to handle supplier-related operations
        readonly SupplierService _service;

        // Constructor to initialize the supplier service
        public SupplierController()
        {
            _service = new SupplierService();
        }

        // Method to gather all suppliers from the database
        public List<Supplier> GatherSuppliers()
        {
            try
            {
                // Retrieve the list of suppliers from the service
                List<Supplier> suppliers = _service.GatherSuppliers();

                return suppliers;
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Operation failed: {ex.Message}");
                return null;
            }
        }

        // Method to retrieve a single supplier by its ID
        public Supplier GetOneSupplier(int id)
        {
            try
            {
                // Retrieve the supplier from the service
                var fornecedor = _service.GetOneSupplier(id);
                return fornecedor;
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Operation failed: {ex.Message}");
                return null;
            }
        }

        // Method to add a new supplier or update an existing one
        public bool AddSupplier(Supplier supplier)
        {
            try
            {
                // If the supplier ID is less than or equal to 0, it's a new supplier, so add it
                if (supplier.Id <= 0)
                {
                    _service.AddSupplier(supplier);
                }
                // Otherwise, update the existing supplier
                else
                {
                    _service.UpdateSupplier(supplier);
                }
                return true;
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"Operation failed: {ex.Message}");
                return false;
            }
        }

        // Method to validate the supplier by checking for empty fields
        public List<string> ValidateSupplier(Supplier supplier)
        {
            return GetEmptyFields(supplier);
        }

        // Helper method to identify and return any empty fields in the supplier
        private List<string> GetEmptyFields(Supplier supplier)
        {
            List<string> emptyFields = new List<string>();

            // Check if the supplier's name is null or empty
            if (string.IsNullOrEmpty(supplier.Name))
                emptyFields.Add("Name");

            // Check if the supplier's street is null or empty
            if (string.IsNullOrEmpty(supplier.Street))
                emptyFields.Add("Street");

            // Check if the supplier's number is null or empty
            if (string.IsNullOrEmpty(supplier.Number))
                emptyFields.Add("Number");

            // Check if the supplier's neighborhood is null or empty
            if (string.IsNullOrEmpty(supplier.Neighborhood))
                emptyFields.Add("Neighborhood");

            // Check if the supplier's city is null or empty
            if (string.IsNullOrEmpty(supplier.City))
                emptyFields.Add("City");

            // Check if the supplier's state ID is valid
            if (supplier.state.Id <= 0)
                emptyFields.Add("State");

            return emptyFields;
        }
    }
}
