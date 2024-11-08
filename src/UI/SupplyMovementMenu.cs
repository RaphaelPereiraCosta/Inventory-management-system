using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class SupplyMovementMenu : Form
    {
        private Supplier _supplier;
        private Product _selectedProduct;
        private List<Product> _products;
        private int movement;
        private readonly Utils _utils;
        private readonly ProdMovController _controller;
        private readonly MovementTypeController _movementTypeController;

        private SupplierMenu _supplierMenu;
        private ProductSelect _productSelect;

        // Constructor: Initializes the supply movement menu and its components.
        public SupplyMovementMenu()
        {
            _supplier = new Supplier();
            _selectedProduct = new Product();
            _products = new List<Product>();
            _utils = new Utils();
            _controller = new ProdMovController();
            _movementTypeController = new MovementTypeController();

            InitializeComponent();
            InitializeForm();

            movement = CmbType.SelectedIndex;
        }

        // Sets the initial values and configurations for the form.
        private void InitializeForm()
        {
            MskTxtDate.Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            FillTypes();
            AddColumnsToProductList();
        }

        // Handles the change in the combo box selection.
        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBehavior();
        }

        // Manages the state of the date input based on checkbox status.
        private void ChkToday_CheckedChanged(object sender, EventArgs e)
        {
            HandleDateInput();
        }

        // Updates the selected product based on the DataGridView selection.
        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        // Opens the supplier selection menu.
        private void BtnSelectSupplier_Click(object sender, EventArgs e)
        {
            OpenSupMenu();
        }

        // Opens the product selection menu.
        private void BtnSelectProducts_Click(object sender, EventArgs e)
        {
            OpenProdMenu();
        }

        // Confirms and saves the movement data.
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            SaveMovement();
        }

        // Handles closure of the product selection form.
        private void ProductSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProdSelectClosedEvent();
        }

        // Handles closure of the supplier menu form.
        private void SupplierMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            SupplierMenuClosedEvent();
        }

        // Invoked when a supplier is selected from the supplier menu.
        private void SupplierSelectForm_SupplierSelected(Supplier supplier)
        {
            SupplierSelectedEvent(supplier);
        }

        // Invoked when products are selected from the product menu.
        private void ProductSelectForm_ProductSelected(List<Product> products)
        {
            ProductSelectedEvent(products);
        }

        // Sets the selected supplier and updates the form fields.
        private void SupplierSelectedEvent(Supplier supplier)
        {
            _supplier = supplier;
            HandleSupFields(_supplier);
        }

        // Updates the product list based on the selected products.
        private void ProductSelectedEvent(List<Product> products)
        {
            _products = products;
            UpdateProdList(_products);
        }

        // Saves the product movement by creating a new movement object.
        private void SaveMovement()
        {
            ProductMovement movement = CreateNewMovementObj();
            _controller.AddProductMovement(movement);
            Close();
        }

        // Selects a product from the DataGridView.
        private void SelectRow()
        {
            try
            {
                _selectedProduct = _utils.SelectRowProduct(DtProduct);
                int rowIndex = DtProduct.CurrentRow.Index;
                _selectedProduct.AmountChange = _utils.GetIntValueFromCell(
                    DtProduct,
                    rowIndex,
                    "AmountChange"
                );

                HandleFields(_selectedProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting product: {ex.Message}");
            }
        }

        // Opens the supplier selection menu.
        private void OpenSupMenu()
        {
            if (_supplierMenu == null || _supplierMenu.IsDisposed)
                CreateNewSupplierMenu(true);

            ShowSupplierMenu();
        }

        // Opens the product selection menu.
        private void OpenProdMenu()
        {
            if (_productSelect == null || _productSelect.IsDisposed)
                CreateNewProductSelect(movement, _products);

            ShowProductSelect();
        }

        // Handles the closure of the product selection menu.
        private void ProdSelectClosedEvent()
        {
            Show();
            CreateNewProductSelect(movement, _products);
        }

        // Handles the closure of the supplier selection menu.
        private void SupplierMenuClosedEvent()
        {
            Show();
            CreateNewSupplierMenu(true);
        }

        // Adds columns to the product DataGridView.
        private void AddColumnsToProductList()
        {
            _utils.AddProductColumns(DtProduct);
            DtProduct.Columns.Add("AmountChange", "Entrada");
        }

        // Updates the DataGridView with the current product list.
        private void UpdateProdList(List<Product> productList)
        {
            DtProduct.Rows.Clear();

            foreach (var product in productList)
            {
                DtProduct.Rows.Add(
                    product.Id,
                    product.Name,
                    product.AvailableAmount,
                    product.Description,
                    product.AmountChange
                );
            }
        }

        // Fills the combo box with movement types.
        private void FillTypes()
        {
            try
            {
                List<MovementType> types = _movementTypeController.GetAllMovementTypes();
                CmbType.Items.Clear();
                CmbType.DataSource = types;
                CmbType.ValueMember = "Id";
                CmbType.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filling types: {ex.Message}");
            }
        }

        // Creates a new instance of the supplier menu.
        private void CreateNewSupplierMenu(bool isSelecting)
        {
            _supplierMenu = new SupplierMenu(isSelecting);
            _supplierMenu.FormClosed += SupplierMenu_FormClosed;
            _supplierMenu.SupplierSelected += SupplierSelectForm_SupplierSelected;
        }

        // Creates a new instance of the product selection menu.
        private void CreateNewProductSelect(int type, List<Product> products)
        {
            _productSelect = new ProductSelect(type, products);
            _productSelect.FormClosed += ProductSelect_FormClosed;
            _productSelect.ProdutoSelected += ProductSelectForm_ProductSelected;
        }

        // Shows the product selection menu.
        private void ShowProductSelect()
        {
            Hide();
            _productSelect.Show();
        }

        // Shows the supplier selection menu.
        private void ShowSupplierMenu()
        {
            Hide();
            _supplierMenu.Show();
        }

        // Updates the form fields with the selected product's details.
        private void HandleFields(Product selected)
        {
            TxtProdName.Text = selected.Name ?? "";
            TxtDescription.Text = selected.Description ?? "";
            TxtAmount.Text = Convert.ToString(selected.AvailableAmount) ?? "";
            TxtAmountChanged.Text = Convert.ToString(selected.AmountChange) ?? "";
        }

        // Manages the date input based on the checkbox state.
        private void HandleDateInput()
        {
            if (ChkToday.Checked)
            {
                MskTxtDate.ReadOnly = true;
                LblDate.Visible = false;
                MskTxtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                LblDate.Visible = true;
                MskTxtDate.ReadOnly = false;
                MskTxtDate.Text = "";
            }
        }

        // Sets the behavior based on the selected movement type.
        public void SetBehavior()
        {
            if (int.TryParse(CmbType.SelectedIndex.ToString(), out int type))
            {
                movement = type;

                LblAmountChanged.Text = type == 0 ? "Quantidade adicionada" : "Quantidade retirada";

                BtnConfirm.Text = "Confirmar " + CmbType.SelectedText;

                if (DtProduct.Columns.Contains("AmountChange"))
                    DtProduct.Columns["AmountChange"].HeaderText = CmbType.Text;

                CreateNewProductSelect(movement, _products);
            }
        }

        // Creates a new product movement object.
        private ProductMovement CreateNewMovementObj()
        {
            int typeid = Convert.ToInt32(CmbType.SelectedValue);

            ProductMovement movement = new ProductMovement
            {
                Supplier = new Supplier() { Id = _supplier.Id },
                Type = new MovementType { Id = typeid },
                ProductsList = _products,
                Date = MskTxtDate.Text
            };
            return movement;
        }

        // Updates the supplier fields with the selected supplier's data.
        private void HandleSupFields(Supplier supplier)
        {
            TxtName.Text = supplier.Name ?? "";
            TxtCity.Text = supplier.City ?? "";
            TxtCEP.Text = supplier.CEP ?? "";
            TxtNeigh.Text = supplier.Neighborhood ?? "";
            TxtPhone.Text = supplier.Phone ?? "";
            TxtStreet.Text = supplier.Street ?? "";
            TxtEmail.Text = supplier.Email ?? "";
            TxtNumber.Text = supplier.Number ?? "";
            TxtComplement.Text = supplier.Complement ?? "";
            TxtState.Text = supplier.state.Name ?? "";
        }

        // Closes the current form.
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
