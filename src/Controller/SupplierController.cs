using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Services;

namespace Gerenciador_de_estoque.src.Controllers
{
    public class SupplierController
    {
        readonly SupplierService fornecedorService = new SupplierService();

        public List<Supplier> GatherFornecedores(string nome)
        {
            try
            {
                var fornecedores = fornecedorService.GatherFornecedores(nome);

                if (!string.IsNullOrEmpty(nome) && (fornecedores == null || fornecedores.Count == 0))
                {
                    MessageBox.Show("O fornecedor não está cadastrado.");
                    return null;
                }

                return fornecedores;
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
                var fornecedor = fornecedorService.GetOneFornecedor(id);
                return fornecedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public void AddFornecedor(Supplier fornecedor)
        {
            try
            {
                CheckForEmptyFields(fornecedor);

                if (fornecedor.IdSupplier <= 0)
                {
                    fornecedorService.AddFornecedor(fornecedor);
                    MessageBox.Show("Fornecedor adicionado com sucesso!");
                }
                else
                {
                    fornecedorService.UpdateFornecedor(fornecedor);
                    MessageBox.Show("Fornecedor editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Aviso: {ex.Message}");
            }
        }

        private void CheckForEmptyFields(Supplier fornecedor)
        {
            List<string> emptyFields = GetEmptyFields(fornecedor);

            if (emptyFields.Count > 0)
            {
                throw new ArgumentException(
                    "Preencha os campos a seguir antes de continuar: "
                        + string.Join(", ", emptyFields)
                );
            }
        }

        private List<string> GetEmptyFields(Supplier fornecedor)
        {
            List<string> emptyFields = new List<string>();

            if (string.IsNullOrEmpty(fornecedor.Name))
                emptyFields.Add("Nome");
            if (string.IsNullOrEmpty(fornecedor.Street))
                emptyFields.Add("Rua");
            if (string.IsNullOrEmpty(fornecedor.Number))
                emptyFields.Add("Numero");
            if (string.IsNullOrEmpty(fornecedor.Neighborhood))
                emptyFields.Add("Bairro");
            if (string.IsNullOrEmpty(fornecedor.City))
                emptyFields.Add("Cidade");
            if (string.IsNullOrEmpty(fornecedor.State))
                emptyFields.Add("Estado");
            if (string.IsNullOrEmpty(fornecedor.CEP))
                emptyFields.Add("CEP");

            return emptyFields;
        }

        public void DeleteFornecedor(int id)
        {
            try
            {
                fornecedorService.DeleteFornecedor(id);
                MessageBox.Show("Fornecedor deletado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
        }
    }
}
