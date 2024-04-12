using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utils;

namespace Gerenciador_de_estoque.UI
{
    public partial class ProductMenu : Form
    {
        Product _produto = new Product();
        readonly ProductController _controller = new ProductController();

        public ProductMenu()
        {
            try
            {
                InitializeComponent();

                    InitializeForm();
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
                
                AddColumnsToProductList();
                FillProductList(TxtSearch.Text);
                HandleFields(true, _produto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o formulário: {ex.Message}");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar produto: {ex.Message}");
            }
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            Utilities utils = new Utilities();

            TxtQuantity.Text = utils.ValidateNonNegativeNumber(TxtQuantity.Text);
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                HandleFields(true, _produto);

                if (dtProduct.CurrentRow != null)
                {
                    int index = dtProduct.CurrentRow.Index;

                    _produto.Name = dtProduct
                        .Rows[index]
                        .Cells["Name"]
                        .Value.ToString();
                    _produto.AvaliableAmount = Convert.ToInt32(
                        dtProduct.Rows[index].Cells["AvaliableAmount"].Value
                    );
                    _produto.Description = dtProduct.Rows[index].Cells["Description"].Value.ToString();
                    _produto.IdProduct = Convert.ToInt32(
                        dtProduct.Rows[index].Cells["IdProduct"].Value
                    );

                    TxtName.Text = _produto.Name;
                    TxtQuantity.Text = _produto.AvaliableAmount.ToString();
                    TxtDescription.Text = _produto.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(false, null);
                _produto = new Product();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo produto: {ex.Message}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _produto.Name = TxtName.Text;

                if (int.TryParse(TxtQuantity.Text, out int quantidade))
                {
                    _produto.AvaliableAmount = quantidade;
                }
                else
                {
                    MessageBox.Show("Quantidade inválida");
                    return;
                }

                _produto.Description = TxtDescription.Text;
                SaveProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(true, _produto);
                _produto = new Product();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar a operação: {ex.Message}");
            }
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
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

        private void BtnEdit_Click(object sender, EventArgs e)
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteProduct(_produto.IdProduct);
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o produto: {ex.Message}");
            }
        }

        private void HandleFields(bool isReadOnly, Product produto)
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

        private void UpdateFields(bool isReadOnly, Product produto)
        {
            try
            {
                if (produto != null)
                {
                    TxtName.Text = produto.Name;
                    TxtQuantity.Text = Convert.ToString(produto.AvaliableAmount);
                    TxtDescription.Text = produto.Description;
                }
                else
                {
                    TxtName.Text = "";
                    TxtQuantity.Text = "0";
                    TxtDescription.Text = "";
                }

                TxtName.ReadOnly = isReadOnly;
                TxtQuantity.ReadOnly = isReadOnly;
                TxtDescription.ReadOnly = isReadOnly;
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
                BtnNew.Enabled = isEnabled;
                BtnNew.Visible = isEnabled;
                BtnDelete.Visible = isEnabled;
                BtnDelete.Enabled = isEnabled;
                BtnEdit.Enabled = isEnabled;
                BtnEdit.Visible = isEnabled;
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
                dtProduct.Columns.Add("IdProduct", "Id");
                dtProduct.Columns["IdProduct"].Visible = false;
                dtProduct.Columns.Add("Name", "Nome do Produto");
                dtProduct.Columns.Add("AvaliableAmount", "Quantidade em Estoque");
                dtProduct.Columns.Add("Description", "Descrição");
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
                        produto.IdProduct,
                        produto.Name,
                        produto.AvaliableAmount,
                        produto.Description
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
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

        private void SaveProduct()
        {
            try
            {
                _controller.AddProduto(_produto);
                HandleFields(false, _produto);
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}");
            }
        }


    }
}
