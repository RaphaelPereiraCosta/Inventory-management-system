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
        private Supplier _fornecedor = new Supplier();
        private readonly SelectedProd _produto = new SelectedProd();
        private List<SelectedProd> _produtos = new List<SelectedProd>();
        private int movement;

        private SupplierMenu supplierMenu;
        private ProductSelect productSelect;

        // Ajuste na inicialização do formulário
        public SupplyMovementMenu()
        {
            InitializeComponent();
            InitializeForm();
            // Inicializa o fornecedor corretamente
            _fornecedor = new Supplier();
        }

        // Ajuste na função UpdateSupFields
        private void UpdateSupFields(Supplier fornecedor)
        {
            try
            {
                if (fornecedor != null && fornecedor.IdSupplier > 0)
                {
                    txtName.Text = fornecedor.Name;
                    txtCity.Text = fornecedor.City;
                    txtCEP.Text = fornecedor.CEP;
                    txtNeigh.Text = fornecedor.Neighborhood;
                    txtPhone.Text = fornecedor.Phone;
                    txtStreet.Text = fornecedor.Street;
                    txtEmail.Text = fornecedor.Email;
                    txtNumber.Text = fornecedor.Number;
                    txtComplement.Text = fornecedor.Complement;
                    txtState.Text = fornecedor.State;
                }
                else
                {
                    // Limpa os campos se não houver fornecedor selecionado
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

        // Ajuste na função AddColumnsToProductList
        private void AddColumnsToProductList()
        {
            try
            {
                DtProduct.Columns.Clear();
                DtProduct.Columns.Add("IdProduto", "Id");
                DtProduct.Columns["IdProduto"].Visible = false;
                DtProduct.Columns.Add("NomeProduto", "Nome do Produto"); // Ajuste no nome da coluna
                DtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque"); // Ajuste no nome da coluna
                DtProduct.Columns.Add("Descricao", "Descrição");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        // Ajuste na função DtProduct_SelectionChanged
        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DtProduct.CurrentRow != null)
                {
                    int index = DtProduct.CurrentRow.Index;

                    _produto.Name = DtProduct.Rows[index].Cells["NomeProduto"].Value.ToString(); // Ajuste no nome da coluna
                    _produto.AvaliableAmount = Convert.ToInt32(DtProduct.Rows[index].Cells["QuantidadeEstoque"].Value); // Ajuste no nome da coluna
                    _produto.Description = DtProduct.Rows[index].Cells["Descricao"].Value.ToString();
                    _produto.IdProduct = Convert.ToInt32(DtProduct.Rows[index].Cells["IdProduto"].Value);

                    txtProdName.Text = _produto.Name;
                    txtQuantity.Text = _produto.AvaliableAmount.ToString();
                    txtDescription.Text = _produto.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
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

                if (int.TryParse(CmbType.SelectedIndex.ToString(), out int tipo))
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

        private void CreateNewProductSelect(int type, List<SelectedProd> produtos)
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

        private void SupplierSelectForm_SupplierSelected(Supplier fornecedor)
        {
            _fornecedor = fornecedor;
            UpdateSupFields(_fornecedor);
        }

        private void ProductSelectForm_ProductSelected(List<SelectedProd> produtos)
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


        private void UpdateProdList(List<SelectedProd> productList)
        {
            DtProduct.Rows.Clear();

            foreach (var produto in productList)
            {
                DtProduct.Rows.Add(
                    produto.IdProduct,
                    produto.Name,
                    produto.AvaliableAmount,
                    produto.Description
                );
            }
        }


        
    }
}
