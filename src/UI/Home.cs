using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.Controllers;
using Gerenciador_de_estoque.src.Utils;
using Gerenciador_de_estoque.UI;

namespace Gerenciador_de_estoque
{
    public partial class Home : Form
    {
        ProductMenu productMenu = new ProductMenu();
        SupplierMenu supplierMenu = new SupplierMenu();
        List<string> types = new List<string>();
        FornecedorController _controller = new FornecedorController();

        public Home()
        {
            InitializeComponent();
            CreateNewProductMenu();
            CreateNewSupplierMenu();
            InitializeForm();
            
        }
            

        private void InitializeForm()
        {
            FillTypes();
            FillSupplierCmb("");
        }

        private void FillSupplierCmb(string nome)
        {
            try
            {
                var fornecedores = _controller.GatherFornecedores(nome);
                cmbSupplier.Items.Clear();

                foreach (var fornecedor in fornecedores)
                {
                    cmbSupplier.Items.Add(
                        new
                        {
                            IdFornecedor = fornecedor.IdFornecedor,
                            NomeFornecedor = fornecedor.NomeFornecedor
                        }
                    );
                }
                cmbSupplier.DisplayMember = "NomeFornecedor";
                cmbSupplier.ValueMember = "IdFornecedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de fornecedores: {ex.Message}");
            }
        }


        private void FillTypes()
        {
            try
            {
                types = Utils.FillType(types);
                foreach (string type in types)
                {
                    cmbType.Items.Add(type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher estados: {ex.Message}");
            }
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
