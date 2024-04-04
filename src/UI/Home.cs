using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.UI;

namespace Gerenciador_de_estoque
{
    public partial class Home : Form
    {
        ProductMenu productMenu;
        SupplierMenu supplierMenu;

        public Home()
        {
            InitializeComponent();
            CreateNewProductMenu();
            CreateNewSupplierMenu();
        }

        private void ProductBtn_Click(object sender, EventArgs e)
        {
            ShowProductMenu();
        }

        private void ShowProductMenu()
        {
            try
            {
                Hide();
                productMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao mostrar o menu do produto: {ex.Message}");
            }
        }

        private void ProductMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            CreateNewProductMenu();
        }

        private void CreateNewProductMenu()
        {
            this.productMenu = new ProductMenu();
            productMenu.FormClosed += ProductMenu_FormClosed;
        }

        private void btnSupplierMenu_Click(object sender, EventArgs e)
        {
            ShowSupplierMenu();
        }

        private void ShowSupplierMenu()
        {
            try
            {
                Hide();
                supplierMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao mostrar o menu do fornecedor: {ex.Message}");
            }
        }

        private void SupplierMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            CreateNewSupplierMenu();
        }

        private void CreateNewSupplierMenu()
        {
            this.supplierMenu = new SupplierMenu();
            supplierMenu.FormClosed += SupplierMenu_FormClosed;
        }
    }
}
