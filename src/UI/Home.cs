using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.UI;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque
{
    public partial class Home : Form
    {
        ProductMenu productMenu;
        SupplierMenu supplierMenu;
        SupplyMovementMenu supplyMovementMenu;
        ProductMovement movement = new ProductMovement();

        readonly Utils _util = new Utils();

        readonly ProdMovController _controller = new ProdMovController();

        public Home()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            AddColumns();
            FillMovementList();
        }

        private void AddColumns()
        {
            _util.AddMovementColumns(DtMovement);
            _util.AddProductColumns(DtProduct);

            DtProduct.Columns["AvaliableAmount"].Visible = false;
            DtProduct.Columns.Add("AmountChange", movement.Type == "Entrada" ? "Entrada" : "Saída");
        }

        private void FillMovementList()
        {
            try
            {
                SupplierController supplierController = new SupplierController();

                var movements = _controller.GatherMovement();

                DtMovement.Rows.Clear();

                foreach (var movement in movements)
                {
                    movement.Supplier = supplierController.GetOneFornecedor(movement.Supplier.Id);

                    DtMovement.Rows.Add(
                        movement.Id,
                        movement.Supplier.Id,
                        movement.Supplier.Name,
                        movement.Type,
                        movement.Date
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
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

        private void BtnProductMenu_Click(object sender, EventArgs e)
        {
            if (productMenu == null || productMenu.IsDisposed)
                CreateNewProductMenu();

            ShowForm(productMenu);
        }

        private void BtnSupplierMenu_Click(object sender, EventArgs e)
        {
            if (supplierMenu == null || supplierMenu.IsDisposed)
                CreateNewSupplierMenu(false);

            ShowForm(supplierMenu);
        }

        private void BtnSupplyMovementMenu_Click(object sender, EventArgs e)
        {
            if (supplyMovementMenu == null || supplyMovementMenu.IsDisposed)
                CreateNewSupplyMovementMenu();

            ShowForm(supplyMovementMenu);
        }

        private void ShowForm(Form formToShow)
        {
            Hide();

            formToShow.FormClosed += (sender, e) =>
            {
                Show();
                FillMovementList();
            };

            formToShow.Show();
        }

        private void CreateNewProductMenu()
        {
            productMenu = new ProductMenu();
        }

        private void CreateNewSupplierMenu(bool isSelecting)
        {
            supplierMenu = new SupplierMenu(isSelecting);
        }

        private void CreateNewSupplyMovementMenu()
        {
            supplyMovementMenu = new SupplyMovementMenu();
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

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    movement = _util.SelectRowMovement(DtMovement);
                    HandleFields(movement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void HandleFields(ProductMovement movement)
        {
            TxtName.Text = movement.Supplier.Name;
            TxtPhone.Text = movement.Supplier.Phone;
            TxtEmail.Text = movement.Supplier.Email;
        }
    }
}
