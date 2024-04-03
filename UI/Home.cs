using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.UI;

namespace Gerenciador_de_estoque
{
    public partial class btnSupplier : Form
    {
        ProductMenu productMenu;

        public btnSupplier()
        {
            InitializeComponent();
            CreateNewProductMenu();
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
    }
}
