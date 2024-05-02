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
        ProductMenu _productMenu;
        SupplierMenu _supplierMenu;
        SupplyMovementMenu _supplyMovementMenu;
        ProductMovement movement;
        List<ProductMovement> movements;

        readonly Utils _utils;
        readonly ProdMovController _controller;
        readonly SupplierController _supplierController;

        public Home()
        {
            _productMenu = new ProductMenu();
            _supplierMenu = new SupplierMenu(false);
            _supplyMovementMenu = new SupplyMovementMenu();
            _utils = new Utils();
            _controller = new ProdMovController();
            _supplierController = new SupplierController();
            movement = new ProductMovement();
            movements = new List<ProductMovement>();

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            AddColumns();
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, true);
            FillCmb();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, false);
        }

        private void CmbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, false);
        }

        private void CmbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, CmbMonths.Text, CmbYears.Text, false);
        }

        private void DtMovement_SelectionChanged(object sender, EventArgs e)
        {
            if (DtMovement.SelectedRows.Count > 0)
            {
                SelectRow(DtMovement);
                FillDtProduct();
                HandleFields(movement);
            }
        }

        private void BtnProductMenu_Click(object sender, EventArgs e)
        {
            if (_productMenu == null || _productMenu.IsDisposed)
                CreateNewProductMenu();

            ShowForm(_productMenu);
        }

        private void BtnSupplierMenu_Click(object sender, EventArgs e)
        {
            if (_supplierMenu == null || _supplierMenu.IsDisposed)
                CreateNewSupplierMenu(false);

            ShowForm(_supplierMenu);
        }

        private void BtnSupplyMovementMenu_Click(object sender, EventArgs e)
        {
            if (_supplyMovementMenu == null || _supplyMovementMenu.IsDisposed)
                CreateNewSupplyMovementMenu();

            ShowForm(_supplyMovementMenu);
        }

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

        private void AddColumns()
        {
            _utils.AddMovementColumns(DtMovement);
            _utils.AddProductColumns(DtProduct);

            DtProduct.Columns["AvaliableAmount"].Visible = false;
            DtProduct.Columns.Add("AmountChange", movement.Type == "Entrada" ? "Entrada" : "Saída");
        }

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

        private void FillMovementTable(List<ProductMovement> list)
        {
            DtMovement.Rows.Clear();

            foreach (var movement in list)
            {
                DtMovement.Rows.Add(
                    movement.Id,
                    movement.Supplier.Id,
                    movement.Supplier.Name,
                    movement.Type,
                    movement.Date
                );
            }
        }

        private void FillDtProduct()
        {
            DtProduct.Rows.Clear();
            foreach (var product in movement.ProductsList)
            {
                string amountChangeDisplay = product.AmountChange.ToString();
                if (movement.Type == "Entrada")
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

        private void FillCmb()
        {
            FillCmbMonths(movements);
            FillCmbYears(movements);
        }

        private void FillCmbMonths(List<ProductMovement> movements)
        {
            CmbMonths.Items.AddRange(_utils.ListMonths(movements).ToArray());
            CmbMonths.SelectedIndex = 0;
        }

        private void FillCmbYears(List<ProductMovement> movements)
        {
            CmbYears.Items.AddRange(_utils.ListYears(movements).ToArray());
            CmbYears.SelectedIndex = 0;
        }

        private void GatherMovements(bool dbchange)
        {
            if (movements.Count <= 0 || dbchange)
            {
                movements = _controller.GatherMovement();

                foreach (ProductMovement movement in movements)
                {
                    movement.Supplier = _supplierController.GetOneSupplier(movement.Supplier.Id);
                }
            }
        }

        private List<ProductMovement> FilterMovements(string name, string month, string year)
        {
            return _utils.FilterMovementList(movements, name, month, year);
        }

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

        private void CreateNewProductMenu()
        {
            _productMenu = new ProductMenu();
        }

        private void CreateNewSupplierMenu(bool isSelecting)
        {
            _supplierMenu = new SupplierMenu(isSelecting);
        }

        private void CreateNewSupplyMovementMenu()
        {
            _supplyMovementMenu = new SupplyMovementMenu();
        }

        private void HandleFields(ProductMovement movement)
        {
            TxtName.Text = movement.Supplier.Name;
            TxtPhone.Text = movement.Supplier.Phone;
            TxtEmail.Text = movement.Supplier.Email;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
