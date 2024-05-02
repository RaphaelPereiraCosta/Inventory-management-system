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

        private readonly ProdMovController _controller;

        private SupplierMenu _supplierMenu;
        private ProductSelect _productSelect;

        public SupplyMovementMenu()
        {
            _fornecedor = new Supplier();
            _selectedProduct = new Product();
            _products = new List<Product>();
            _utils = new Utils();
            _controller = new ProdMovController();

            InitializeComponent();
            InitializeForm();

            movement = CmbType.SelectedIndex;
        }

        private void InitializeForm()
        {
            MskTxtDate.Text = DateTime.Now.ToString("dd-MM-yyyy").ToString();
            FillTypes();

            AddColumnsToProductList();
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBehavior();
        }

        private void ChkToday_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkToday.Checked)
            {
                MskTxtDate.ReadOnly = true;
                LblDate.Visible = false;
                MskTxtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                LblDate.Visible = true;
                MskTxtDate.ReadOnly = false;
                MskTxtDate.Text = "";
            }
        }

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
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
            SaveMovement();
        }

        private void SaveMovement()
        {
            ProductMovement movement = CreateNewMovementObj();
            _controller.AddProductMovement(movement);
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
            HandleSupFields(_fornecedor);
        }

        private void ProductSelectForm_ProductSelected(List<Product> products)
        {
            _products = products;
            UpdateProdList(_products);
        }

        private void SelectRow()
        {
            try
            {
                _selectedProduct = _utils.SelectRowProduct(DtProduct);
                int rowIndex = DtProduct.CurrentRow.Index;
                _selectedProduct.AmountChange = _utils.GetIntValueFromCell(
                    DtProduct,
                    rowIndex,
                    "AmountChange"
                );

                HandleFields(_selectedProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private void AddColumnsToProductList()
        {
            _utils.AddProductColumns(DtProduct);
            DtProduct.Columns.Add("AmountChange", "Entrada");
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
            Hide();
            _productSelect.Show();
        }

        private void ShowSupplierMenu()
        {
            Hide();
            _supplierMenu.Show();
        }

        private void HandleFields(Product selected)
        {
            TxtProdName.Text = selected.Name ?? "";
            TxtDescription.Text = selected.Description ?? "";
            TxtAmount.Text = Convert.ToString(selected.AvailableAmount) ?? "";
            TxtAmountChanged.Text = Convert.ToString(selected.AmountChange) ?? "";
        }

        public void SetBehavior()
        {
            if (int.TryParse(CmbType.SelectedIndex.ToString(), out int type))
            {
                movement = type;

                LblAmountChanged.Text = type == 0 ? "Quantidade adicionada" : "Quantidade retirada";

                BtnConfirm.Text = "Confirmar " + CmbType.Text;

                if (DtProduct.Columns.Contains("AmountChange"))
                    DtProduct.Columns["AmountChange"].HeaderText = CmbType.Text;

                CreateNewProductSelect(movement, _products);
            }
        }

        private ProductMovement CreateNewMovementObj()
        {
            ProductMovement movement = new ProductMovement
            {
                Supplier = new Supplier() { Id = _fornecedor.Id },
                Type = CmbType.Text,
                ProductsList = _products,
                Date = MskTxtDate.Text
            };
            return movement;
        }

        private void HandleSupFields(Supplier fornecedor)
        {
            TxtName.Text = fornecedor.Name ?? "";
            TxtCity.Text = fornecedor.City ?? "";
            TxtCEP.Text = fornecedor.CEP ?? "";
            TxtNeigh.Text = fornecedor.Neighborhood ?? "";
            TxtPhone.Text = fornecedor.Phone ?? "";
            TxtStreet.Text = fornecedor.Street ?? "";
            TxtEmail.Text = fornecedor.Email ?? "";
            TxtNumber.Text = fornecedor.Number ?? "";
            TxtComplement.Text = fornecedor.Complement ?? "";
            TxtState.Text = fornecedor.State ?? "";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
