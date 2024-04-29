
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
        private Product _product;
        private List<Product> _products;
        private readonly ProductController _controller;
        private readonly Utils _utils;

        public ProductMenu()
        {
            _controller = new ProductController();
            _utils = new Utils();
            _product = new Product();
            _products = new List<Product>();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            AddColumns();
            FillDataGridView(TxtSearch.Text, true);
            HandleFields(true);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, false);
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            TxtAmount.Text = _utils.ValidateNumber(TxtAmount.Text);
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CleanProduct();
            HandleFields(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateProductObj();
                SaveProduct();
                FillDataGridView(TxtSearch.Text, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o Produto. {ex.Message}");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(false);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(true);
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SelectRow()
        {
            if (DtProduct.SelectedRows.Count > 0)
            {
                _product = _utils.SelectRowProduct(DtProduct);
                HandleFields(true);
            }
        }

        private void SaveProduct()
        {
            if (_controller.ValidateProduct(_product).Count <= 0)
            {
                if (_controller.AddProduct(_product))
                {
                    MessageBox.Show("Produto salvo com sucesso!");
                }
            }
            else
            {
                throw new ArgumentException(
                    "Preencha os campos a seguir antes de continuar: "
                        + string.Join(", ", _controller.ValidateProduct(_product))
                );
            }
        }

        private void AddColumns()
        {
            _utils.AddProductColumns(DtProduct);
        }

        private void FillDataGridView(string name, bool dbchange)
        {
            GatherProducts(dbchange);
            List<Product> filtered = FilterProducts(name);
            FillProductTable(filtered);
        }

        private void FillProductTable(List<Product> list)
        {
            DtProduct.Rows.Clear();
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

        private void GatherProducts(bool dbchange)
        {
            if (_products.Count <= 0 || dbchange)
                _products = _controller.GatherProducts();
        }

        private List<Product> FilterProducts(string name)
        {
            return _utils.FilterProductList(_products, name);
        }

        private void HandleFields(bool isReadOnly)
        {
            TxtName.Text = _product.Name ?? "";
            TxtAmount.Text = _product.AvailableAmount.ToString() ?? "";
            TxtDescription.Text = _product.Description ?? "";

            UpdateButtons(isReadOnly);

            SetFieldReadOnlyStatus(isReadOnly);
        }

        private void SetFieldReadOnlyStatus(bool isReadOnly)
        {
            TxtName.ReadOnly = isReadOnly;
            TxtAmount.ReadOnly = isReadOnly;
            TxtDescription.ReadOnly = isReadOnly;
        }

        private void UpdateButtons(bool isEnabled)
        {
            BtnNew.Visible = isEnabled;
            BtnEdit.Visible = isEnabled;
            BtnSave.Visible = !isEnabled;
            BtnCancel.Visible = !isEnabled;

            BtnNew.Enabled = isEnabled;
            BtnEdit.Enabled = isEnabled;
            BtnSave.Enabled = !isEnabled;
            BtnCancel.Enabled = !isEnabled;
        }

        private void UpdateProductObj()
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
        }

        private void CleanProduct()
        {
            _product = new Product();
        }
    }
}