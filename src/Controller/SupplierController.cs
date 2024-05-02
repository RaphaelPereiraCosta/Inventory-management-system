using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class SupplierController
    {
        readonly SupplierService _service;

        public SupplierController() {
            _service = new SupplierService();
        }

        public List<Supplier> GatherSuppliers()
        {
            try
            {
                List<Supplier> suppliers = _service.GatherSuppliers();

                return suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public Supplier GetOneSupplier(int id)
        {
            try
            {
                var fornecedor = _service.GetOneSupplier(id);
                return fornecedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public bool AddSupplier(Supplier supplier)
        {
            try
            {
                if (supplier.Id <= 0)
                {
                    _service.AddSupplier(supplier);
                }
                else
                {
                    _service.UpdateSupplier(supplier);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return false;
            }
        }

        public List<string> ValidateSupplier(Supplier supplier)
        {
            return GetEmptyFields(supplier);
        }

        private List<string> GetEmptyFields(Supplier supplier)
        {
            List<string> emptyFields = new List<string>();

            if (string.IsNullOrEmpty(supplier.Name))
                emptyFields.Add("Nome");
            if (string.IsNullOrEmpty(supplier.Street))
                emptyFields.Add("Rua");
            if (string.IsNullOrEmpty(supplier.Number))
                emptyFields.Add("Numero");
            if (string.IsNullOrEmpty(supplier.Neighborhood))
                emptyFields.Add("Bairro");
            if (string.IsNullOrEmpty(supplier.City))
                emptyFields.Add("Cidade");
            if (string.IsNullOrEmpty(supplier.State))
                emptyFields.Add("Estado");

            return emptyFields;
        }
    }
}
