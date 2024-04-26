using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class SupplierController
    {
        readonly SupplierService supplierService = new SupplierService();

        public List<Supplier> GatherSuppliers()
        {
            try
            {
               List<Supplier> suppliers = supplierService.GatherSuppliers();

             

                return suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public Supplier GetOneFornecedor(int id)
        {
            try
            {
                var fornecedor = supplierService.GetOneSupplier(id);
                return fornecedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public void AddFornecedor(Supplier supplier)
        {
            try
            {
                CheckForEmptyFields(supplier);

                if (supplier.Id <= 0)
                {
                    supplierService.AddSupplier(supplier);
                    MessageBox.Show("Fornecedor adicionado com sucesso!");
                }
                else
                {
                    supplierService.UpdateSupplier(supplier);
                    MessageBox.Show("Fornecedor editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Aviso: {ex.Message}");
            }
        }

        private void CheckForEmptyFields(Supplier supplier)
        {
            List<string> emptyFields = GetEmptyFields(supplier);

            if (emptyFields.Count > 0)
            {
                throw new ArgumentException(
                    "Preencha os campos a seguir antes de continuar: "
                        + string.Join(", ", emptyFields)
                );
            }
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
            if (string.IsNullOrEmpty(supplier.CEP))
                emptyFields.Add("CEP");

            return emptyFields;
        }

        public void DeleteFornecedor(int id)
        {
            try
            {
                supplierService.DeleteSupplier(id);
                MessageBox.Show("Fornecedor deletado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
        }
    }
}
