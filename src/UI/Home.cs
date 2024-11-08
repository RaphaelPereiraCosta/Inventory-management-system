using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.UI;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque
{
    public partial class Home : Form
    {
        // Fields for menus and data
        ProductMenu _productMenu;
        SupplierMenu _supplierMenu;
        SupplyMovementMenu _supplyMovementMenu;
        ProductMovement movement;
        List<ProductMovement> movements;

        // Utility and controller references
        readonly Utils _utils;
        readonly ProdMovController _controller;
        readonly SupplierController _supplierController;
        readonly MovementTypeController _movementTypeController;

        // Constructor initializes menus, controllers, and utilities
        public Home()
        {
            _productMenu = new ProductMenu();
            _supplierMenu = new SupplierMenu(false);
            _supplyMovementMenu = new SupplyMovementMenu();
            _utils = new Utils();
            _controller = new ProdMovController();
            _supplierController = new SupplierController();
            _movementTypeController = new MovementTypeController();

            movement = new ProductMovement();
            movements = new List<ProductMovement>();

            InitializeComponent();
            InitializeForm();
        }

        // Initializes the form with necessary data and components
        private void InitializeForm()
        {
            AddColumns();
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, true);
            FillCmb();
        }

        // Handles text change in the search box
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, false);
        }

        // Handles the month selection change
        private void CmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, false);
        }

        // Handles the year selection change
        private void CmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, false);
        }

        // Handles the selection change in the movement table
        private void DtMovement_SelectionChanged(object sender, EventArgs e)
        {
            SelectMovement();
        }

        // Opens the product menu
        private void BtnProductMenu_Click(object sender, EventArgs e)
        {
            OpenProdMenu();
        }

        // Opens the supplier menu
        private void BtnSupplierMenu_Click(object sender, EventArgs e)
        {
            OpenSupMenu();
        }

        // Opens the supply movement menu
        private void BtnSupplyMovementMenu_Click(object sender, EventArgs e)
        {
            OpenMovMenu();
        }

        // Selects a row in the table and handles any exceptions
        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    movement = _utils.SelectRowMovement(DtMovement);
                    HandleFields(movement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        // Adds columns to data tables for display
        private void AddColumns()
        {
            _utils.AddMovementColumns(DtMovement);
            _utils.AddProductColumns(DtProduct);

            DtProduct.Columns["AvaliableAmount"].Visible = false;
            if (movement.Type != null)
            {
                DtProduct.Columns.Add("AmountChange", movement.Type.Name);
            }
            
        }

        // Fills the data grid view based on search criteria
        private void FillDataGridView(string name, string month, string year, bool dbchange)
        {
            try
            {
                GatherMovements(dbchange);
                List<ProductMovement> filtered = FilterMovements(name, month, year);

                FillMovementTable(filtered);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
            }
        }

        // Populates the movement table with data
        private void FillMovementTable(List<ProductMovement> list)
        {
            DtMovement.Rows.Clear();

            foreach (var movement in list)
            {
                DtMovement.Rows.Add(
                    movement.Id,
                    movement.Supplier.Id,
                    movement.Supplier.Name,
                    movement.Type.Id,
                    movement.Type.Name,
                    movement.Date
                );
            }
        }

        // Fills the product details table
        private void FillDtProduct()
        {
            DtProduct.Rows.Clear();
            foreach (var product in movement.ProductsList)
            {
                string amountChangeDisplay = product.AmountChange.ToString();
                if (movement.Type.Id == 1)
                {
                    amountChangeDisplay = "+" + amountChangeDisplay;
                }
                else
                {
                    amountChangeDisplay = "-" + amountChangeDisplay;
                }

                DtProduct.Rows.Add(
                    product.Id,
                    product.Name,
                    product.AvailableAmount,
                    product.Description,
                    amountChangeDisplay
                );
            }
        }

        // Fills the combo boxes for months and years
        private void FillCmb()
        {
            FillCmbMonths(movements);
            FillCmbYears(movements);
        }

        // Populates the month combo box with data
        private void FillCmbMonths(List<ProductMovement> movements)
        {
            CmbMonths.Items.AddRange(_utils.ListMonths(movements).ToArray());
            CmbMonths.SelectedIndex = 0;
        }

        // Populates the year combo box with data
        private void FillCmbYears(List<ProductMovement> movements)
        {
            CmbYears.Items.AddRange(_utils.ListYears(movements).ToArray());
            CmbYears.SelectedIndex = 0;
        }

        // Retrieves movements from the database if necessary
        private void GatherMovements(bool dbchange)
        {
            if (movements.Count <= 0 || dbchange)
            {
                movements = _controller.GatherMovement();

                foreach (ProductMovement movement in movements)
                {
                    movement.Supplier = _supplierController.GetOneSupplier(movement.Supplier.Id);
                    movement.Type = _movementTypeController.GetOneMovementType(movement.Type.Id);
                }
            }
        }

        // Selects the current movement in the table
        private void SelectMovement()
        {
            if (DtMovement.SelectedRows.Count > 0)
            {
                SelectRow(DtMovement);
                FillDtProduct();
                HandleFields(movement);
            }
        }

        // Filters the movements based on search criteria
        private List<ProductMovement> FilterMovements(string name, string month, string year)
        {
            return _utils.FilterMovementList(movements, name, month, year);
        }

        // Opens the product menu form
        private void OpenProdMenu()
        {
            if (_productMenu == null || _productMenu.IsDisposed)
                CreateNewProductMenu();

            ShowForm(_productMenu);
        }

        // Opens the supplier menu form
        private void OpenSupMenu()
        {
            if (_supplierMenu == null || _supplierMenu.IsDisposed)
                CreateNewSupplierMenu(false);

            ShowForm(_supplierMenu);
        }

        // Opens the supply movement menu form
        private void OpenMovMenu()
        {
            if (_supplyMovementMenu == null || _supplyMovementMenu.IsDisposed)
                CreateNewSupplyMovementMenu();

            ShowForm(_supplyMovementMenu);
        }

        // Displays a form and sets up its close event handler
        private void ShowForm(Form formToShow)
        {
            Hide();

            formToShow.FormClosed += (sender, e) =>
            {
                Show();
                FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, true);
            };

            formToShow.Show();
        }

        // Creates a new instance of the product menu
        private void CreateNewProductMenu()
        {
            _productMenu = new ProductMenu();
        }

        // Creates a new instance of the supplier menu
        private void CreateNewSupplierMenu(bool isSelecting)
        {
            _supplierMenu = new SupplierMenu(isSelecting);
        }

        // Creates a new instance of the supply movement menu
        private void CreateNewSupplyMovementMenu()
        {
            _supplyMovementMenu = new SupplyMovementMenu();
        }

        // Handles input fields based on the selected product movement
        private void HandleFields(ProductMovement movement)
        {
            TxtName.Text = movement.Supplier.Name;
            TxtPhone.Text = movement.Supplier.Phone;
            TxtEmail.Text = movement.Supplier.Email;
        }

        // Closes the application when the exit button is clicked
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
