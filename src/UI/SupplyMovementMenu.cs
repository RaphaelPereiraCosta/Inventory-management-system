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
        private Supplier _fornecedor;
        private Product _selectedProduct;
        private List<Product> _products;
        private int movement;
        private readonly Utils _utils;

        private SupplierMenu _supplierMenu;
        private ProductSelect _productSelect;

        public SupplyMovementMenu()
        {
            _utils = new Utils();

            _fornecedor = new Supplier();
            _selectedProduct = new Product();
            _products = new List<Product>();

            InitializeComponent();
            InitializeForm();

            movement = CmbType.SelectedIndex;
        }

        private void InitializeForm()
        {
            TxtDate.Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            FillTypes();

            AddColumnsToProductList();
        }

        private void TxtDate_TextChanged(object sender, EventArgs e)
        {
            TxtDate.Text = _utils.FormatDate(TxtDate.Text);
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(CmbType.SelectedIndex.ToString(), out int type))
                {
                    movement = type;

                    LblAmountChanged.Text =
                        type == 0 ? "Quantidade adicionada" : "Quantidade retirada";

                    BtnConfirm.Text = "Confirmar " + CmbType.Text;

                    CreateNewProductSelect(movement, _products);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar tipo de movimentação: {ex.Message}");
            }
        }

        private void ChkToday_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkToday.Checked)
            {
                TxtDate.ReadOnly = true;
                TxtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                TxtDate.ReadOnly = false;
            }
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow(DtProduct);
            HandleFields(_selectedProduct);
        }

        private void BtnSelectSupplier_Click(object sender, EventArgs e)
        {
            if (_supplierMenu == null || _supplierMenu.IsDisposed)
                CreateNewSupplierMenu(true);
            ShowSupplierMenu();
        }

        private void BtnSelectProducts_Click(object sender, EventArgs e)
        {
            if (_productSelect == null || _productSelect.IsDisposed)
                CreateNewProductSelect(movement, _products);

            ShowProductSelect();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            ProdMovController controller = new ProdMovController();

            ProductMovement movement = new ProductMovement
            {
                Supplier = new Supplier() { Id = _fornecedor.Id },
                Type = CmbType.Text,
                ProductsList = _products,
                Date = TxtDate.Text
            };

            controller.AddProductMovement(movement);
            Close();
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

        private void ProductSelectForm_ProductSelected(List<Product> products)
        {
            _products = products;
            UpdateProdList(_products);
        }

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    _selectedProduct = _utils.SelectRowProduct(table);
                    if (
                        int.TryParse(
                            table.CurrentRow.Cells["AmountChange"].Value.ToString(),
                            out int availableAmount
                        )
                    )
                    {
                        _selectedProduct.AmountChange = availableAmount;
                    }
                    else
                    {
                        _selectedProduct.AmountChange = 0;
                    }

                    HandleFields(_selectedProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void AddColumnsToProductList()
        {
            try
            {
                DtProduct.Columns.Clear();
                _utils.AddProductColumns(DtProduct);
                DtProduct.Columns.Add(
                    "AmountChange",
                    CmbType.Text == "Entrada" ? "Entrada" : "Saída"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
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

        private void FillTypes()
        {
            try
            {
                Utils utils = new Utils();
                Dictionary<string, int> types = utils.ListTypes();
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

        private void CreateNewSupplierMenu(bool isSelecting)
        {
            _supplierMenu = new SupplierMenu(isSelecting);
            _supplierMenu.FormClosed += SupplierMenu_FormClosed;
            _supplierMenu.SupplierSelected += SupplierSelectForm_SupplierSelected;
        }

        private void CreateNewProductSelect(int type, List<Product> produtos)
        {
            _productSelect = new ProductSelect(type, produtos);
            _productSelect.FormClosed += ProductSelect_FormClosed;
            _productSelect.ProdutoSelected += ProductSelectForm_ProductSelected;
        }

        private void ShowProductSelect()
        {
            try
            {
                Hide();
                _productSelect.Show();
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
                _supplierMenu.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao mostrar o menu do fornecedor: {ex.Message}");
            }
        }

        private void UpdateProdList(List<Product> productList)
        {
            DtProduct.Rows.Clear();

            foreach (var produto in productList)
            {
                DtProduct.Rows.Add(
                    produto.Id,
                    produto.Name,
                    produto.AvailableAmount,
                    produto.Description,
                    produto.AmountChange
                );
            }
        }

        private void HandleFields(Product selected)
        {
            try
            {
                if (selected != null)
                {
                    TxtProdName.Text = selected.Name;
                    TxtDescription.Text = selected.Description;
                    TxtAmount.Text = Convert.ToString(selected.AvailableAmount);
                    TxtAmountChanged.Text = Convert.ToString(selected.AmountChange);
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
    }
}
