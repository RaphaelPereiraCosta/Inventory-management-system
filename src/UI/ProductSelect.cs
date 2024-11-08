using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class ProductSelect : Form
    {
        // Fields for product data and controllers
        private Product _product;
        private List<Product> _products;
        private readonly ProductController _controller;
        private readonly List<Product> _added; // List of added products
        public event Action<List<Product>> ProdutoSelected; // Event for selected products
        private readonly int _type; // Type of operation: add or remove
        private readonly Utils _utils;

        // Constructor initializes the form with type and selected products
        public ProductSelect(int type, List<Product> selectedProduct)
        {
            _type = type;
            _added = selectedProduct ?? new List<Product>();
            _controller = new ProductController();
            _utils = new Utils();
            _product = new Product();
            _products = new List<Product>();

            InitializeComponent();
            InitializeForm();
        }

        // Initializes form components and loads data
        private void InitializeForm()
        {
            SetBehavior();
            AddColumnsToProductLists();
            LoadDGV();
            HandleFields();
        }

        // Sets the form behavior based on operation type
        private void SetBehavior()
        {
            LblMovQuant.Text = _type == 0 ? "Adicionando:" : "Removendo:";
        }

        // Event handler for text change in search box
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillProductList(TxtSearch.Text);
        }

        // Event handler for text change in the movement quantity text box
        private void TxtMovQuant_TextChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = !string.IsNullOrEmpty(TxtMovQuant.Text);
            LblInstruction.Visible = string.IsNullOrEmpty(TxtMovQuant.Text);
            TxtMovQuant.Text = _utils.ValidateNumber(TxtMovQuant.Text);
        }

        private bool _isClearingSelection = false; // Flag to avoid recursive selection

        // Event handler for product selection in the products list
        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            SelectOnDtProd();
        }

        // Event handler for product selection in the added products list
        private void DtAdded_SelectionChanged(object sender, EventArgs e)
        {
            SelectOnDtAdd();
        }

        // Event handler for adding a product
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddProd();
        }

        // Event handler for removing a product
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveProd();
        }

        // Event handler for confirming the selection
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmSelection();
        }

        // Selects a row from the specified DataGridView
        public void SelectRow(DataGridView table)
        {
            if (table.SelectedRows.Count > 0)
            {
                _product = _utils.SelectRowProduct(table);
                HandleFields();
                BtnAdd.Text = "Selecionar";
            }
        }

        // Adds a product to the list
        private void AddProd()
        {
            Product productDTO = CreateProductDTO();

            if (!VerifySupply(productDTO))
            {
                return;
            }

            UpdateOrAddProductToList(productDTO);

            CleanProduct();
            HandleFields();

            LoadDGV();
        }

        // Removes a product from the list
        private void RemoveProd()
        {
            foreach (Product produto in _added.ToList())
            {
                if (produto.Id == _product.Id)
                {
                    _added.Remove(produto);
                }
            }
            LoadDGV();
        }

        // Confirms the product selection and triggers the event
        private void ConfirmSelection()
        {
            if (ProdutoSelected != null)
            {
                ProdutoSelected?.Invoke(_added);
            }
            Close();
        }

        // Handles product selection in the products DataGridView
        private void SelectOnDtProd()
        {
            if (_isClearingSelection)
                return;

            SelectRow(DtProduct);

            _isClearingSelection = true;
            DtAdded.ClearSelection();
            _isClearingSelection = false;
        }

        // Handles product selection in the added products DataGridView
        private void SelectOnDtAdd()
        {
            if (_isClearingSelection)
                return;

            SelectRow(DtAdded);

            _isClearingSelection = true;
            DtProduct.ClearSelection();
            _isClearingSelection = false;
        }

        // Adds columns to the product lists for display
        private void AddColumnsToProductLists()
        {
            _utils.AddProductColumns(DtProduct);
            _utils.AddProductColumns(DtAdded);
            DtAdded.Columns.Add("AmountChange", _type == 0 ? "Entrada" : "Saída");
        }

        // Fills the product list with filtered data
        private void FillProductList(string nome)
        {
            GatherProducts();
            List<Product> filtered = FiltersProducts(nome);
            FillProductTable(filtered);
        }

        // Populates the products DataGridView
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

        // Fills the added products DataGridView
        private void FillDtAdded()
        {
            DtAdded.Rows.Clear();
            FillAddedTable(_added);
        }

        // Populates the added products table with data
        private void FillAddedTable(List<Product> list)
        {
            foreach (var product in list)
            {
                string amountChangeDisplay = product.AmountChange.ToString();
                if (_type == 0)
                {
                    amountChangeDisplay = "+" + amountChangeDisplay;
                }
                else
                {
                    amountChangeDisplay = "-" + amountChangeDisplay;
                }

                DtAdded.Rows.Add(
                    product.Id,
                    product.Name,
                    product.AvailableAmount,
                    product.Description,
                    amountChangeDisplay
                );
            }
        }

        // Gathers products from the controller if needed
        private void GatherProducts()
        {
            if (_products.Count <= 0)
            {
                _products = _controller.GatherProducts();
            }
        }

        // Filters products based on the search criteria
        private List<Product> FiltersProducts(string name)
        {
            List<Product> filtered = _utils.FilterProductList(_products, name);
            return filtered.Where(p => !_added.Any(a => a.Id == p.Id)).ToList();
        }

        // Updates form fields with the selected product data
        private void HandleFields()
        {
            TxtName.Text = _product.Name ?? "";
            TxtDescription.Text = _product.Description ?? "";
            TxtAvaQuantity.Text = Convert.ToString(_product.AvailableAmount) ?? "";
            TxtMovQuant.Text = Convert.ToString(_product.AmountChange) ?? "";
        }

        // Updates or adds a product to the list
        private void UpdateOrAddProductToList(Product productDTO)
        {
            Product existingProduct = _added.FirstOrDefault(p => p.Id == productDTO.Id);
            if (existingProduct != null)
            {
                UpdateExistingProduct(existingProduct);
            }
            else
            {
                _added.Add(productDTO);
            }
        }

        // Updates an existing product in the list
        private void UpdateExistingProduct(Product existingProduct)
        {
            existingProduct.AmountChange = Convert.ToInt32(TxtMovQuant.Text);
            existingProduct.AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text);
        }

        // Loads the data grid views
        private void LoadDGV()
        {
            FillDtAdded();
            FillProductList(TxtSearch.Text);
        }

        // Verifies if the supply is sufficient for the operation
        private bool VerifySupply(Product productDTO)
        {
            if (productDTO.AmountChange <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que 0");
                return false;
            }

            if (_type == 1 && productDTO.AmountChange > productDTO.AvailableAmount)
            {
                MessageBox.Show("Estoque insuficiente");
                return false;
            }

            return true;
        }

        // Clears the current product data
        private void CleanProduct()
        {
            _product = new Product();
        }

        // Creates a new product DTO from the input fields
        private Product CreateProductDTO()
        {
            return new Product
            {
                Id = _product.Id,
                Name = _product.Name,
                Description = _product.Description,
                AmountChange = Convert.ToInt32(TxtMovQuant.Text),
                AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text)
            };
        }
    }
}
