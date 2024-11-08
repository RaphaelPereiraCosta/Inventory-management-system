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
        // Fields for product data and controllers
        private Product _product;
        private List<Product> _products;
        private readonly ProductController _controller;
        private readonly Utils _utils;

        // Constructor initializes controller, utils, and components
        public ProductMenu()
        {
            _controller = new ProductController();
            _utils = new Utils();
            _product = new Product();
            _products = new List<Product>();
            InitializeComponent();
            InitializeForm();
        }

        // Initializes the form by setting up columns and loading data
        private void InitializeForm()
        {
            AddColumns();
            FillDataGridView(TxtSearch.Text, true);
            HandleFields(true);
        }

        // Event handler for text change in search box
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, false);
        }

        // Event handler for text change in the amount text box, validating input
        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            ValidateAmount();
        }

        // Event handler for product table selection change
        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        // Event handler for creating a new product entry
        private void BtnNew_Click(object sender, EventArgs e)
        {
            PrepareForNew();
        }

        // Event handler for saving product data
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SavingProd();
        }

        // Event handler for enabling edit mode
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(false);
        }

        // Event handler for canceling edit or new entry
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(true);
        }

        // Event handler for closing the form
        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Validates that the amount field contains a number
        private void ValidateAmount()
        {
            TxtAmount.Text = _utils.ValidateNumber(TxtAmount.Text);
        }

        // Prepares form for entering a new product
        private void PrepareForNew()
        {
            CleanProduct();
            HandleFields(false);
        }

        // Handles the saving of a product, including error handling
        private void SavingProd()
        {
            try
            {
                if (SaveProduct())
                    FillDataGridView(TxtSearch.Text, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o Produto. {ex.Message}");
            }
        }

        // Selects a row in the product table
        public void SelectRow()
        {
            if (DtProduct.SelectedRows.Count > 0)
            {
                _product = _utils.SelectRowProduct(DtProduct);
                HandleFields(true);
            }
        }

        // Saves a new or edited product
        private bool SaveProduct()
        {
            Product product = CreateNewProductObj();

            // Validates the product and attempts to save it
            if (_controller.ValidateProduct(product).Count <= 0)
            {
                if (_controller.AddProduct(product))
                {
                    MessageBox.Show("Produto salvo com sucesso!");
                }
                return true;
            }
            else
            {
                throw new ArgumentException(
                    "Preencha os campos a seguir antes de continuar: "
                        + string.Join(", ", _controller.ValidateProduct(product))
                );
            }
        }

        // Adds columns to the product table for display
        private void AddColumns()
        {
            _utils.AddProductColumns(DtProduct);
        }

        // Fills the data grid view with filtered product data
        private void FillDataGridView(string name, bool dbchange)
        {
            GatherProducts(dbchange);
            List<Product> filtered = FilterProducts(name);
            FillProductTable(filtered);
        }

        // Populates the product table with data
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

        // Retrieves products from the database if necessary
        private void GatherProducts(bool dbchange)
        {
            if (_products.Count <= 0 || dbchange)
                _products = _controller.GatherProducts();
        }

        // Filters products based on the search criteria
        private List<Product> FilterProducts(string name)
        {
            return _utils.FilterProductList(_products, name);
        }

        // Handles enabling/disabling fields and buttons based on context
        private void HandleFields(bool isReadOnly)
        {
            TxtName.Text = _product.Name ?? "";
            TxtAmount.Text = _product.AvailableAmount.ToString() ?? "";
            TxtDescription.Text = _product.Description ?? "";

            UpdateButtons(isReadOnly);
            SetFieldReadOnlyStatus(isReadOnly);
        }

        // Sets fields to be read-only or editable
        private void SetFieldReadOnlyStatus(bool isReadOnly)
        {
            TxtName.ReadOnly = isReadOnly;
            TxtAmount.ReadOnly = isReadOnly;
            TxtDescription.ReadOnly = isReadOnly;
        }

        // Updates button visibility and enablement based on the form state
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

        // Creates a new product object from the input fields
        private Product CreateNewProductObj()
        {
            int.TryParse(TxtAmount.Text, out int quantidade);

            Product product = new Product()
            {
                Name = TxtName.Text,
                AvailableAmount = quantidade,
                Description = TxtDescription.Text
            };

            if (_product.Id > 0)
                product.Id = _product.Id;

            return product;
        }

        // Clears the current product data
        private void CleanProduct()
        {
            _product = new Product();
        }
    }
}
