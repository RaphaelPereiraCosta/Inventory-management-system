using System;
using System.Globalization;
using System.Windows.Forms;
using Gerenciador_de_estoque.Controllers;
using Gerenciador_de_estoque.Models;

namespace Gerenciador_de_estoque.UI
{
    public partial class ProductMenu : Form
    {
        Produto _produto = new Produto();
        ProdutoController _controller = new ProdutoController();

        public ProductMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            HandleFields(true, _produto);
            AddColumnsToProductList();
            FillProductList("");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            HandleFields(false, null);
            _produto = new Produto();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _produto.NomeProduto = txtName.Text;

            _produto.Preco = txtPrice.Text;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(true, _produto);
            _produto = new Produto();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(false, _produto);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct(_produto.IdProduto);
            FillProductList(txtSearch.Text);
        }

        private void HandleFields(bool isReadOnly, Produto produto)
        {
            UpdateFields(isReadOnly, produto);
            UpdateButtons(isReadOnly);
        }

        private void UpdateFields(bool isReadOnly, Produto produto)
        {
            if (produto != null)
            {
                txtName.Text = produto.NomeProduto;
                txtPrice.Text = Convert.ToString(produto.Preco);
                txtQuantity.Text = Convert.ToString(produto.QuantidadeEstoque);
                txtDescription.Text = produto.Descricao;
            }
            else
            {
                txtName.Text = "";
                txtPrice.Text = "0";
                txtQuantity.Text = "0";
                txtDescription.Text = "";
            }

            txtName.ReadOnly = isReadOnly;
            txtPrice.ReadOnly = isReadOnly;
            txtQuantity.ReadOnly = isReadOnly;
            txtDescription.ReadOnly = isReadOnly;
        }

        private void UpdateButtons(bool isEnabled)
        {
            btnNew.Enabled = isEnabled;
            btnNew.Visible = isEnabled;
            btnEdit.Enabled = isEnabled;
            btnEdit.Visible = isEnabled;
            btnSave.Enabled = !isEnabled;
            btnCancel.Enabled = !isEnabled;
            btnCancel.Visible = !isEnabled;
            btnSave.Visible = !isEnabled;
        }

        private void AddColumnsToProductList()
        {
            dtProduct.Columns.Clear();
            dtProduct.Columns.Add("IdProduto", "Id");
            dtProduct.Columns["IdProduto"].Visible = false;
            dtProduct.Columns.Add("NomeProduto", "Nome do Produto");
            dtProduct.Columns.Add("Preco", "Preço");
            dtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque");
            dtProduct.Columns.Add("Descricao", "Descrição");
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
                        produto.Preco,
                        produto.QuantidadeEstoque,
                        produto.Descricao
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a lista de produtos: {ex.Message}");
            }
        }

        private void dtProduct_SelectionChanged(object sender, EventArgs e)
        {
            HandleFields(true, _produto);

            if (dtProduct.CurrentRow != null)
            {
                int index = dtProduct.CurrentRow.Index;

                _produto.NomeProduto = dtProduct.Rows[index].Cells["NomeProduto"].Value.ToString();
                _produto.Preco = dtProduct.Rows[index].Cells["Preco"].Value.ToString();
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
                txtPrice.Text = _produto.Preco.ToString();
            }
        }

        private void DeleteProduct(int produto)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillProductList(txtSearch.Text);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            txtPrice.TextChanged -= txtPrice_TextChanged;

            ApplyCurrencyFormat();

            txtPrice.TextChanged += txtPrice_TextChanged;
        }

        private void SaveProduct()
        {
            try
            {
                decimal preco = decimal.Parse(RemoveNonNumericCharacters(txtPrice.Text));
                if (preco == 0 || _produto.QuantidadeEstoque == 0)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        "O preço do produto ou a quantidade em estoque é 0. Você deseja continuar?",
                        "Confirmação",
                        MessageBoxButtons.YesNo
                    );
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                _produto.Preco = FormatAndSetNumber(preco.ToString());
                _controller.AddProduto(_produto);
                HandleFields(false, _produto);
                FillProductList(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}");
            }
        }

        private void ApplyCurrencyFormat()
        {
            string cleanNumber = RemoveNonNumericCharacters(txtPrice.Text);

            if (string.IsNullOrEmpty(cleanNumber))
            {
                SetTextAndSelection("0,00");
            }
            else
            {
                FormatAndSetNumber(cleanNumber);
            }
        }

        private string RemoveNonNumericCharacters(string text)
        {
            return text.Replace(",", "").Replace("R$", "").Replace(".", "").TrimStart('0');
        }

        private void SetTextAndSelection(string text)
        {
            txtPrice.Text = text;
            txtPrice.Select(txtPrice.Text.Length, 0);
        }

        private string FormatAndSetNumber(string cleanNumber)
        {
            decimal parsed = decimal.Parse(cleanNumber);
            string formattedNumber = string.Format(
                CultureInfo.CurrentCulture,
                "{0:C2}",
                parsed / 100
            );
            SetTextAndSelection(formattedNumber);
            return formattedNumber;
        }

    }
}
