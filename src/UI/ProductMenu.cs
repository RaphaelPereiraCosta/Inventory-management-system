using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utils;

namespace Gerenciador_de_estoque.UI
{
    public partial class ProductMenu : Form
    {
        Produto _produto = new Produto();
        ProdutoController _controller = new ProdutoController();

        public ProductMenu()
        {
            try
            {
                InitializeComponent();
                if (this.IsHandleCreated)
                {
                    InitializeForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o menu do produto: {ex.Message}");
            }
        }

        private void InitializeForm()
        {
            try
            {
                HandleFields(true, _produto);
                AddColumnsToProductList();
                FillProductList("");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o formulário: {ex.Message}");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(false, null);
                _produto = new Produto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo produto: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _produto.NomeProduto = txtName.Text;

                if (int.TryParse(txtQuantity.Text, out int quantidade))
                {
                    _produto.QuantidadeEstoque = quantidade;
                }
                else
                {
                    MessageBox.Show("Quantidade inválida");
                    return;
                }

                _produto.Descricao = txtDescription.Text;
                SaveProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(true, _produto);
                _produto = new Produto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar a operação: {ex.Message}");
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao voltar: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(false, _produto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteProduct(_produto.IdProduto);
                FillProductList(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o produto: {ex.Message}");
            }
        }

        private void HandleFields(bool isReadOnly, Produto produto)
        {
            try
            {
                UpdateFields(isReadOnly, produto);
                UpdateButtons(isReadOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao manipular campos: {ex.Message}");
            }
        }

        private void UpdateFields(bool isReadOnly, Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    txtName.Text = produto.NomeProduto;
                    txtQuantity.Text = Convert.ToString(produto.QuantidadeEstoque);
                    txtDescription.Text = produto.Descricao;
                }
                else
                {
                    txtName.Text = "";
                    txtQuantity.Text = "0";
                    txtDescription.Text = "";
                }

                txtName.ReadOnly = isReadOnly;
                txtQuantity.ReadOnly = isReadOnly;
                txtDescription.ReadOnly = isReadOnly;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar campos: {ex.Message}");
            }
        }

        private void UpdateButtons(bool isEnabled)
        {
            try
            {
                btnNew.Enabled = isEnabled;
                btnNew.Visible = isEnabled;
                btnDelete.Visible = isEnabled;
                btnDelete.Enabled = isEnabled;
                btnEdit.Enabled = isEnabled;
                btnEdit.Visible = isEnabled;
                btnSave.Enabled = !isEnabled;
                btnCancel.Enabled = !isEnabled;
                btnCancel.Visible = !isEnabled;
                btnSave.Visible = !isEnabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar botões: {ex.Message}");
            }
        }

        private void AddColumnsToProductList()
        {
            try
            {
                dtProduct.Columns.Clear();
                dtProduct.Columns.Add("IdProduto", "Id");
                dtProduct.Columns["IdProduto"].Visible = false;
                dtProduct.Columns.Add("NomeProduto", "Nome do Produto");
                dtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque");
                dtProduct.Columns.Add("Descricao", "Descrição");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void FillProductList(string nome)
        {
            try
            {
                var produtos = _controller.GatherProdutos(nome);
                dtProduct.Rows.Clear();

                foreach (var produto in produtos)
                {
                    dtProduct.Rows.Add(
                        produto.IdProduto,
                        produto.NomeProduto,
                        produto.QuantidadeEstoque,
                        produto.Descricao
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
            }
        }

        private void dtProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                HandleFields(true, _produto);

                if (dtProduct.CurrentRow != null)
                {
                    int index = dtProduct.CurrentRow.Index;

                    _produto.NomeProduto = dtProduct
                        .Rows[index]
                        .Cells["NomeProduto"]
                        .Value.ToString();
                    _produto.QuantidadeEstoque = Convert.ToInt32(
                        dtProduct.Rows[index].Cells["QuantidadeEstoque"].Value
                    );
                    _produto.Descricao = dtProduct.Rows[index].Cells["Descricao"].Value.ToString();
                    _produto.IdProduto = Convert.ToInt32(
                        dtProduct.Rows[index].Cells["IdProduto"].Value
                    );

                    txtName.Text = _produto.NomeProduto;
                    txtQuantity.Text = _produto.QuantidadeEstoque.ToString();
                    txtDescription.Text = _produto.Descricao;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void DeleteProduct(int produto)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Você está prestes a excluir um produto. Você deseja continuar?",
                    "Confirmação",
                    MessageBoxButtons.YesNo
                );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                _controller.DeleteProduto(produto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o produto: {ex.Message}");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillProductList(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar produto: {ex.Message}");
            }
        }

        private void SaveProduct()
        {
            try
            {
                _controller.AddProduto(_produto);
                HandleFields(false, _produto);
                FillProductList(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();

            txtQuantity.Text = utils.ValidateNonNegativeNumber(txtQuantity.Text);

          
        }

    }
}
