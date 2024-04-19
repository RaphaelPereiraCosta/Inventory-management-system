using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.UI;

namespace Gerenciador_de_estoque
{
    public partial class Home : Form
    {
        ProductMenu productMenu;
        SupplierMenu supplierMenu;
        SupplyMovementMenu supplyMovementMenu;

        readonly ProdMovController _controller = new ProdMovController();

        readonly ProductMovement movement = new ProductMovement();

        public Home()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            FillMovementList();
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
                        movement.IdMovement,
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

        private void ShowForm(Form form)
        {
            Hide();
            form.FormClosed += (s, args) => Show();
            form.Show();
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

        private bool _isClearingSelection = false;

        private void DtMovement_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearingSelection)
                return;

            if (DtMovement.SelectedRows.Count > 0)
            {
                SelectRow(DtMovement);
                HandleFields(movement);
            }

            _isClearingSelection = true;
            DtMovement.ClearSelection();
            _isClearingSelection = false;
        }

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
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
