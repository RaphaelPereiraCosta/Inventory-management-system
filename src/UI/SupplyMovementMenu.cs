using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utils;
using Gerenciador_de_estoque.UI;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class SupplyMovementMenu : Form
    {
        private Fornecedor _fornecedor = new Fornecedor();
        private readonly Produto _produto = new Produto();
        private List<ProdutoSelecionado> _produtos = new List<ProdutoSelecionado>();
        private int movement;

        private SupplierMenu supplierMenu;
        private ProductSelect productSelect;

        public SupplyMovementMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            FillTypes();

            AddColumnsToProductList();
        }

        private void FillTypes()
        {
            try
            {
                Utilities utils = new Utilities();
                Dictionary<string, int> types = utils.FillType();
                foreach (var type in types)
                {
                    CmbType.Items.Add(new { Text = type.Key, type.Value });
                }
                CmbType.DisplayMember = "Text";
                CmbType.ValueMember = "Value";
                CmbType.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher tipos: {ex.Message}");
            }
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (int.TryParse(CmbType.SelectedIndex.ToString(), out int tipo)) ;
                {
                    movement = tipo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar tipo de movimentação: {ex.Message}");
            }
        }

        private void CreateNewSupplierMenu(bool isSelecting)
        {
            supplierMenu = new SupplierMenu(isSelecting);
            supplierMenu.FormClosed += SupplierMenu_FormClosed;
            supplierMenu.SupplierSelected += SupplierSelectForm_SupplierSelected;
        }

        private void CreateNewProductSelect(int type, List<ProdutoSelecionado> produtos)
        {
            productSelect = new ProductSelect(type, produtos);
            productSelect.FormClosed += ProductSelect_FormClosed;
            productSelect.ProdutoSelected += ProductSelectForm_ProductSelected;
        }

        private void ProductSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();

            CreateNewProductSelect(movement, _produtos);
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

        private void ProductSelectForm_ProductSelected(List<ProdutoSelecionado> produtos)
        {
            _produtos = produtos;
            UpdateProdList(_produtos);
        }

        private void BtnSelectSupplier_Click(object sender, EventArgs e)
        {
            if (supplierMenu == null || supplierMenu.IsDisposed)
                CreateNewSupplierMenu(true);
            ShowSupplierMenu();
        }

        private void BtnSelectProducts_Click(object sender, EventArgs e)
        {
            if (productSelect == null || productSelect.IsDisposed)
                CreateNewProductSelect(movement, _produtos);

            ShowProductSelect();
        }

        private void ShowProductSelect()
        {
            try
            {
                Hide();
                productSelect.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao mostrar o menu de produtos: {ex.Message}");
            }
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

        private void AddColumnsToProductList()
        {
            try
            {
                DtProduct.Columns.Clear();
                DtProduct.Columns.Add("IdProduto", "Id");
                DtProduct.Columns["IdProduto"].Visible = false;
                DtProduct.Columns.Add("NomeProduto", "Nome do Produto");
                DtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque");
                DtProduct.Columns.Add("Descricao", "Descrição");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
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

        private void UpdateProdList(List<ProdutoSelecionado> produtoList)
        {
            DtProduct.Rows.Clear();

            foreach (var produto in produtoList)
            {
                DtProduct.Rows.Add(
                    produto.IdProduto,
                    produto.NomeProduto,
                    produto.QuantidadeEstoque,
                    produto.Descricao
                );
            }
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DtProduct.CurrentRow != null)
                {
                    int index = DtProduct.CurrentRow.Index;

                    _produto.NomeProduto = DtProduct
                        .Rows[index]
                        .Cells["NomeProduto"]
                        .Value.ToString();
                    _produto.QuantidadeEstoque = Convert.ToInt32(
                        DtProduct.Rows[index].Cells["QuantidadeEstoque"].Value
                    );
                    _produto.Descricao = DtProduct.Rows[index].Cells["Descricao"].Value.ToString();
                    _produto.IdProduto = Convert.ToInt32(
                        DtProduct.Rows[index].Cells["IdProduto"].Value
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
