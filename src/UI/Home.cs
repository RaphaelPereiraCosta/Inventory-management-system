using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.UI;
using Gerenciador_de_estoque.UI;

namespace Gerenciador_de_estoque
{
    public partial class Home : Form
    {
        ProductMenu productMenu;
        SupplierMenu supplierMenu;
        SupplyMovementMenu supplyMovementMenu;
        readonly ProdMovController _controller = new ProdMovController();

        public Home()
        {
            InitializeComponent();
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
                    movement.Supplier = supplierController.GetOneFornecedor(movement.Supplier.IdSupplier);

                    DtMovement.Rows.Add(
                        movement.IdMovement,
                        movement.Date,
                        movement.Supplier.Name,
                        movement.Type
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
    }
}
