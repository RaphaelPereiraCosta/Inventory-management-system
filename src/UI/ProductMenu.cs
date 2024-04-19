using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class ProductMenu : Form
    {
        private Product _selectedProduct = new Product();
        private readonly ProductController _controller = new ProductController();
        private readonly Utils _utils = new Utils();

        public ProductMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            AddColumnsToProductList();
            FillProductList("");
            HandleFields(true, _selectedProduct);
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            TxtAmount.Text = _utils.ValidateNumber(TxtAmount.Text);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillProductList(TxtSearch.Text);
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dtProduct.CurrentRow == null)
                return;

            _selectedProduct = _utils.SelectRowProduct(dtProduct);
            UpdateProductFields(_selectedProduct);
        }

        private void UpdateProductFields(Product product)
        {
            TxtName.Text = product.Name;
            TxtAmount.Text = product.AvailableAmount.ToString();
            TxtDescription.Text = product.Description;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            HandleFields(false, null);
            _selectedProduct = new Product();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _selectedProduct.Name = TxtName.Text;

            if (int.TryParse(TxtAmount.Text, out int quantidade))
            {
                _selectedProduct.AvailableAmount = quantidade;
            }
            else
            {
                MessageBox.Show("Quantidade inválida");
                return;
            }

            _selectedProduct.Description = TxtDescription.Text;
            SaveOrUpdateProduct();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(true, _selectedProduct);
            _selectedProduct = new Product();
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(false, _selectedProduct);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct(_selectedProduct.Id);
            FillProductList(TxtSearch.Text);
        }

        private void SaveOrUpdateProduct()
        {
            try
            {
                _controller.AddProduct(_selectedProduct);
                HandleFields(true, _selectedProduct);
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o produto: {ex.Message}");
            }
        }

        private void DeleteProduct(int productId)
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
                _controller.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o produto: {ex.Message}");
            }
        }

        private void AddColumnsToProductList()
        {
            dtProduct.Columns.Clear();
            dtProduct.Columns.Add("IdProduct", "Id");
            dtProduct.Columns["IdProduct"].Visible = false;
            dtProduct.Columns.Add("Name", "Nome do Produto");
            dtProduct.Columns.Add("AvaliableAmount", "Quantidade em Estoque");
            dtProduct.Columns.Add("Description", "Descrição");
        }

        private void FillProductList(string name)
        {
            var produtos = _controller.GatherProducts(name);
            dtProduct.Rows.Clear();

            foreach (var produto in produtos)
            {
                dtProduct.Rows.Add(
                    produto.Id,
                    produto.Name,
                    produto.AvailableAmount,
                    produto.Description
                );
            }
        }

        private void HandleFields(bool isReadOnly, Product produto)
        {
            TxtName.Text = produto?.Name ?? "";
            TxtAmount.Text = (produto?.AvailableAmount).ToString() ?? "0";
            TxtDescription.Text = produto?.Description ?? "";

            TxtName.ReadOnly = isReadOnly;
            TxtAmount.ReadOnly = isReadOnly;
            TxtDescription.ReadOnly = isReadOnly;

            UpdateButtons(isReadOnly);
        }

        private void UpdateButtons(bool isEnabled)
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
    }
}
