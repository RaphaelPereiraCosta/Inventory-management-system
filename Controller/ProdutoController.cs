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
                if (
                    string.IsNullOrEmpty(fornecedor.NomeFornecedor)
                    || string.IsNullOrEmpty(fornecedor.Endereco)
                    || string.IsNullOrEmpty(fornecedor.Contato)
                )
                {
                    throw new ArgumentException(
                        "Nome, Endereço e Contato do fornecedor não podem estar vazios"
                    );
                }
                else
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha na operação: {ex.Message}");
            }
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
