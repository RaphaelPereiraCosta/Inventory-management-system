using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utils;
using Gerenciador_de_estoque.UI;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class SupplyMovementMenu : Form
    {
        Fornecedor _fornecedor = new Fornecedor();
        List<string> types = new List<string>();

        Produto _produto = new Produto();
        ProdutoController _controller = new ProdutoController();

        SupplierMenu supplierMenu;

        public SupplyMovementMenu()
        {
            InitializeComponent();
            InitializeForm();
            CreateNewSupplierMenu(true);
        }


        private void InitializeForm()
        {
            FillTypes();
        }

        private void FillTypes()
        {
            try
            {
                Utilities utils = new Utilities();

                types = utils.FillType(types);
                foreach (string type in types)
                {
                    cmbType.Items.Add(type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher tipos: {ex.Message}");
            }
        }

        private void CreateNewSupplierMenu(bool isSelecting)
        {

            this.supplierMenu = new SupplierMenu(isSelecting);
            supplierMenu.FormClosed += SupplierMenu_FormClosed;
            supplierMenu.SupplierSelected += SupplierSelectForm_SupplierSelected;
        }

        private void SupplierMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
            CreateNewSupplierMenu(true);
        }

        private void SupplierSelectForm_SupplierSelected(Fornecedor fornecedor)
        {

            _fornecedor = fornecedor;
            UpdateSupFields(_fornecedor);
           
        }

        private void btnSelectSupplier_Click(object sender, EventArgs e)
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

        private void UpdateSupFields(Fornecedor fornecedor)
        {
            try
            {
                if (fornecedor != null && fornecedor.IdFornecedor > 0)
                {
                    txtName.Text = fornecedor.NomeFornecedor;
                    txtCity.Text = fornecedor.Cidade;
                    txtCEP.Text = fornecedor.CEP;
                    txtNeigh.Text = fornecedor.Bairro;
                    txtPhone.Text = fornecedor.Telefone;
                    txtStreet.Text = fornecedor.Rua;
                    txtEmail.Text = fornecedor.Email;
                    txtNumber.Text = fornecedor.Numero;
                    txtComplement.Text = fornecedor.Complemento;
                    txtState.Text = fornecedor.Estado;
                }
                else
                {
                    txtName.Text = "";
                    txtCity.Text = "";
                    txtCEP.Text = "";
                    txtNeigh.Text = "";
                    txtPhone.Text = "";
                    txtStreet.Text = "";
                    txtEmail.Text = "";
                    txtNumber.Text = "";
                    txtComplement.Text = "";
                    txtState.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar campos: {ex.Message}");
            }
        }

        private void AddColumnsToProductList()
        {
            try
            {
                dtProduct.Columns.Clear();
                dtProduct.Columns.Add("IdProduto", "Id");
                dtProduct.Columns["IdProduto"].Visible = false;
                dtProduct.Columns.Add("NomeProduto", "Nome do Produto");
                dtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque");
                dtProduct.Columns.Add("Descricao", "Descrição");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void FillProductList(string nome)
        {
            try
            {
                List<Produto> produtos = _controller.GatherProdutos(nome);
                dtProduct.Rows.Clear();

                foreach (var produto in produtos)
                {
                    dtProduct.Rows.Add(
                        produto.IdProduto,
                        produto.NomeProduto,
                        produto.QuantidadeEstoque,
                        produto.Descricao
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
            }
        }

        private void dtProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (dtProduct.CurrentRow != null)
                {
                    int index = dtProduct.CurrentRow.Index;

                    _produto.NomeProduto = dtProduct
                        .Rows[index]
                        .Cells["NomeProduto"]
                        .Value.ToString();
                    _produto.QuantidadeEstoque = Convert.ToInt32(
                        dtProduct.Rows[index].Cells["QuantidadeEstoque"].Value
                    );
                    _produto.Descricao = dtProduct.Rows[index].Cells["Descricao"].Value.ToString();
                    _produto.IdProduto = Convert.ToInt32(
                        dtProduct.Rows[index].Cells["IdProduto"].Value
                    );

                    txtProdName.Text = _produto.NomeProduto;
                    txtQuantity.Text = _produto.QuantidadeEstoque.ToString();
                    txtDescription.Text = _produto.Descricao;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

    }
}
