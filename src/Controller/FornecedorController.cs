using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.Models;
using Gerenciador_de_estoque.Services;

namespace Gerenciador_de_estoque.Controllers
{
    public class FornecedorController
    {
        FornecedorService fornecedorService = new FornecedorService();

        public List<Fornecedor> GatherFornecedores(string nome)
        {
            try
            {
                var fornecedores = fornecedorService.GatherFornecedores(nome);
                return fornecedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
                return null;
            }
        }

        public Fornecedor GetOneFornecedor(int id)
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

        public void AddFornecedor(Fornecedor fornecedor)
        {
            try
            {
                CheckForEmptyFields(fornecedor);

                if (fornecedor.IdFornecedor <= 0)
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
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
        }

        private void CheckForEmptyFields(Fornecedor fornecedor)
        {
            List<string> emptyFields = GetEmptyFields(fornecedor);

            if (emptyFields.Count > 0)
            {
                throw new ArgumentException(
                    "Os seguintes campos estão vazios e não podem estar: " + string.Join(", ", emptyFields)
                );
            }
        }

        private List<string> GetEmptyFields(Fornecedor fornecedor)
        {
            List<string> emptyFields = new List<string>();

            if (string.IsNullOrEmpty(fornecedor.NomeFornecedor)) emptyFields.Add("Nome");
            if (string.IsNullOrEmpty(fornecedor.Cidade)) emptyFields.Add("Cidade");
            if (string.IsNullOrEmpty(fornecedor.CEP)) emptyFields.Add("CEP");
            if (string.IsNullOrEmpty(fornecedor.Bairro)) emptyFields.Add("Bairro");
            if (string.IsNullOrEmpty(fornecedor.Rua)) emptyFields.Add("Rua");
            if (string.IsNullOrEmpty(fornecedor.Numero)) emptyFields.Add("Numero");
            if (string.IsNullOrEmpty(fornecedor.Estado)) emptyFields.Add("Estado");

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
