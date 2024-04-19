using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class SupplyMovementMenu : Form
    {
        private Supplier _fornecedor = new Supplier();
        private SelectedProd selectedProduct = new SelectedProd();
        private List<SelectedProd> _products = new List<SelectedProd>();
        private int movement;
        readonly Utils utils = new Utils();

        private SupplierMenu supplierMenu;
        private ProductSelect productSelect;

        public SupplyMovementMenu()
        {
            InitializeComponent();
            InitializeForm();

            _fornecedor = new Supplier();
        }

        private void InitializeForm()
        {
            TxtDate.Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            FillTypes();

            AddColumnsToProductList();
        }

        private void UpdateSupFields(Supplier fornecedor)
        {
            try
            {
                if (fornecedor != null && fornecedor.Id > 0)
                {
                    TxtName.Text = fornecedor.Name;
                    TxtCity.Text = fornecedor.City;
                    TxtCEP.Text = fornecedor.CEP;
                    TxtNeigh.Text = fornecedor.Neighborhood;
                    TxtPhone.Text = fornecedor.Phone;
                    TxtStreet.Text = fornecedor.Street;
                    TxtEmail.Text = fornecedor.Email;
                    TxtNumber.Text = fornecedor.Number;
                    TxtComplement.Text = fornecedor.Complement;
                    TxtState.Text = fornecedor.State;
                }
                else
                {
                    TxtName.Text = "";
                    TxtCity.Text = "";
                    TxtCEP.Text = "";
                    TxtNeigh.Text = "";
                    TxtPhone.Text = "";
                    TxtStreet.Text = "";
                    TxtEmail.Text = "";
                    TxtNumber.Text = "";
                    TxtComplement.Text = "";
                    TxtState.Text = "";
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
                DtProduct.Columns.Clear();
                utils.AddProductColumns(DtProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DtProduct.CurrentRow != null)
                {
                    int index = DtProduct.CurrentRow.Index;

                    selectedProduct.Name = DtProduct
                        .Rows[index]
                        .Cells["NomeProduto"]
                        .Value.ToString();
                    selectedProduct.AvailableAmount = Convert.ToInt32(
                        DtProduct.Rows[index].Cells["QuantidadeEstoque"].Value
                    );
                    selectedProduct.Description = DtProduct
                        .Rows[index]
                        .Cells["Descricao"]
                        .Value.ToString();
                    selectedProduct.Id = Convert.ToInt32(
                        DtProduct.Rows[index].Cells["IdProduto"].Value
                    );

                    TxtProdName.Text = selectedProduct.Name;
                    TxtAmount.Text = selectedProduct.AvailableAmount.ToString();
                    TxtDescription.Text = selectedProduct.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void FillTypes()
        {
            try
            {
                Utils utils = new Utils();
                Dictionary<string, int> types = utils.FillType();
                foreach (var type in types)
                {
                    CmbType.Items.Add(new { Text = type.Key, type.Value });
                }
                CmbType.DisplayMember = "Text";
                CmbType.ValueMember = "Value";
                CmbType.SelectedIndex = 0;
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
                if (int.TryParse(CmbType.SelectedIndex.ToString(), out int type))
                {
                    movement = type;

                     LblAmountChanged.Text = type == 0 ? "Quantidade adicionada" : "Quantidade retirada";

                    BtnConfirm.Text = "Confirmar " + CmbType.Text;
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

            CreateNewProductSelect(movement, _products);
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

        private void ProductSelectForm_ProductSelected(List<SelectedProd> products)
        {
            _products = products;
            UpdateProdList(_products);
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
                CreateNewProductSelect(movement, _products);

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
                    produto.Id,
                    produto.Name,
                    produto.AvailableAmount,
                    produto.Description
                );
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            ProdMovController controller = new ProdMovController();

            ProductMovement movement = new ProductMovement
            {
                Supplier = new Supplier() { Id = _fornecedor.Id },
                Type = CmbType.Text,
                ProductsList = _products,
                Date = null
            };

            if (ChkToday.Checked)
            {
                movement.Date = DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                movement.Date = TxtDate.Text;
            }

            controller.AddProductMovement(movement);
        }

        private void TxtDate_TextChanged(object sender, EventArgs e)
        {
            if (TxtDate.Text.Length > 0)
            {
                bool isValid = DateTime.TryParseExact(
                    TxtDate.Text,
                    "dd/MM/yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out _
                );

                if (!isValid)
                {
                    MessageBox.Show(
                        "Data inválida. Por favor, insira a data no formato dd/MM/yyyy"
                    );
                    TxtDate.Focus();
                }
            }
        }

        private void ChkToday_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkToday.Checked)
            {
                TxtDate.ReadOnly = true;
                TxtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                TxtDate.ReadOnly = false;
            }
        }

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    selectedProduct = utils.SelectRowProduct(table);

                    HandleFields(selectedProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void HandleFields(SelectedProd selected)
        {
            try
            {
                if (selected != null)
                {
                    TxtName.Text = selected.Name;
                    TxtDescription.Text = selected.Description;
                    TxtAmount.Text = Convert.ToString(selected.AvailableAmount);
                    if (selected.AmountChange >= 0)
                    {
                        TxtAmount.Text = Convert.ToString(selected.AmountChange);
                    }
                }
                else
                {
                    TxtName.Text = "";
                    TxtAmount.Text = "";

                    TxtDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar campos: {ex.Message}");
            }
        }

        private void DtProduct_SelectionChanged_1(object sender, EventArgs e)
        {
            SelectRow(DtProduct);
            HandleFields(selectedProduct);
        }
    }
}
