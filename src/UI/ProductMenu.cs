using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class ProductMenu : Form
    {
        private Product _product = new Product();
        private readonly ProductController _controller = new ProductController();
        private readonly Utils _utils = new Utils();
        private List<Product> products = new List<Product>();

        public ProductMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            AddColumnsToProductList();
            FillProductList("");
            HandleFields(true, _product);
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            TxtAmount.Text = _utils.ValidateNumber(TxtAmount.Text);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            if (TxtName.ReadOnly == false)
            {
                FillProductList(TxtName.Text);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillProductList(TxtSearch.Text);
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (DtProduct.CurrentRow == null)
                return;
            if (TxtName.ReadOnly == true)
            {
                _product = _utils.SelectRowProduct(DtProduct);
                UpdateProductFields(_product);
            }
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
            _product = new Product();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _product.Name = TxtName.Text;

            if (int.TryParse(TxtAmount.Text, out int quantidade))
            {
                _product.AvailableAmount = quantidade;
            }
            else
            {
                MessageBox.Show("Quantidade inválida");
                return;
            }

            _product.Description = TxtDescription.Text;
            SaveOrUpdateProduct();
            products.Clear();
            FillProductList("");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(true, _product);
            _product = new Product();
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(false, _product);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct(_product.Id);
            products.Clear();
            FillProductList(TxtSearch.Text);
        }

        private void SaveOrUpdateProduct()
        {
            try
            {
                _controller.AddProduct(_product);
                HandleFields(true, _product);
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
            _utils.AddProductColumns(DtProduct);
        }

        private void FillProductList(string name)
        {
            DtProduct.Rows.Clear();
            if (products.Count <= 0)
            {
                products = _controller.GatherProducts();

                FillProductTable(products);
            }
            else
            {
                List<Product> filtered = _utils.FilterProductList(products, name);

                FillProductTable(filtered);
            }
        }

        private void FillProductTable(List<Product> list)
        {
            foreach (var product in list)
            {
                DtProduct.Rows.Add(
                    product.Id,
                    product.Name,
                    product.AvailableAmount,
                    product.Description
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
