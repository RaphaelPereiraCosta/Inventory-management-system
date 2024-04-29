using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class ProductSelect : Form
    {
        private Product _product;
        private List<Product> _products;
        private readonly ProductController _controller;
        private readonly List<Product> _added;
        public event Action<List<Product>> ProdutoSelected;
        private readonly int _type;
        private readonly Utils _utils;

        public ProductSelect(int type, List<Product> produtosSelecionados)
        {
            _type = type;
            _added = produtosSelecionados ?? new List<Product>();
            _controller = new ProductController();
            _utils = new Utils();

            _product = new Product();
            _products = new List<Product>();

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            SetBehavior();
            AddColumnsToProductLists();
            LoadDGV();
            HandleFields();
        }

        private void SetBehavior()
        {
            LblMovQuant.Text = _type == 0 ? "Adicionando:" : "Removendo:";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillProductList(TxtSearch.Text);
        }

        private void TxtMovQuant_TextChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = !string.IsNullOrEmpty(TxtMovQuant.Text);
            LblInstruction.Visible = string.IsNullOrEmpty(TxtMovQuant.Text);
            TxtMovQuant.Text = _utils.ValidateNumber(TxtMovQuant.Text);
        }

        private bool _isClearingSelection = false;

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearingSelection)
                return;

            SelectRow(DtProduct);

            _isClearingSelection = true;
            DtAdded.ClearSelection();
            _isClearingSelection = false;
        }

        private void DtAdded_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearingSelection)
                return;

            SelectRow(DtAdded);

            _isClearingSelection = true;
            DtProduct.ClearSelection();
            _isClearingSelection = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Product productDTO = CreateProductDTO();

            if (!VerifySupply(productDTO))
            {
                return;
            }

            UpdateOrAddProductToList(productDTO);

            CleanProduct();
            HandleFields();

            LoadDGV();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            foreach (Product produto in _added.ToList())
            {
                if (produto.Id == _product.Id)
                {
                    _added.Remove(produto);
                }
            }
            LoadDGV();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (ProdutoSelected != null)
            {
                ProdutoSelected?.Invoke(_added);
            }
            Close();
        }

        public void SelectRow(DataGridView table)
        {
            if (table.SelectedRows.Count > 0)
            {
                _product = _utils.SelectRowProduct(table);
                HandleFields();
                BtnAdd.Text = "Selecionar";
            }
        }

        private void AddColumnsToProductLists()
        {
            _utils.AddProductColumns(DtProduct);
            _utils.AddProductColumns(DtAdded);
            DtAdded.Columns.Add("AmountChange", _type == 0 ? "Entrada" : "Saída");
        }

        private void FillProductList(string nome)
        {
            GatherProducts();
            List<Product> filtered = FiltersProducts(nome);
            FillProductTable(filtered);
        }

        private void FillProductTable(List<Product> list)
        {
            DtProduct.Rows.Clear();
            foreach (var product in list)
            {
                DtProduct.Rows.Add(
                    product.Id,
                    product.Name,
                    product.AvailableAmount,
                    product.Description
                );
            }
        }

        private void FillDtAdded()
        {
            DtAdded.Rows.Clear();
            FillAddedTable(_added);
        }

        private void FillAddedTable(List<Product> list)
        {
            foreach (var product in list)
            {
                string amountChangeDisplay = product.AmountChange.ToString();
                if (_type == 0)
                {
                    amountChangeDisplay = "+" + amountChangeDisplay;
                }
                else
                {
                    amountChangeDisplay = "-" + amountChangeDisplay;
                }

                DtAdded.Rows.Add(
                    product.Id,
                    product.Name,
                    product.AvailableAmount,
                    product.Description,
                    amountChangeDisplay
                );
            }
        }

        private void GatherProducts()
        {
            if (_products.Count <= 0)
            {
                _products = _controller.GatherProducts();
            }
        }

        private List<Product> FiltersProducts(string nome)
        {
            List<Product> filtered = _utils.FilterProductList(_products, nome);
            return filtered.Where(p => !_added.Any(a => a.Id == p.Id)).ToList();
        }

        private void HandleFields()
        {
            if (_product != null)
            {
                TxtName.Text = _product.Name;
                TxtDescription.Text = _product.Description;
                TxtAvaQuantity.Text = Convert.ToString(_product.AvailableAmount);
                TxtMovQuant.Text = Convert.ToString(_product.AmountChange);
            }
            else
            {
                TxtName.Text = "";
                TxtAvaQuantity.Text = "";
                TxtMovQuant.Text = "";
                TxtDescription.Text = "";
            }
        }

        private void UpdateOrAddProductToList(Product productDTO)
        {
            Product existingProduct = _added.FirstOrDefault(p => p.Id == productDTO.Id);
            if (existingProduct != null)
            {
                UpdateExistingProduct(existingProduct);
            }
            else
            {
                _added.Add(productDTO);
            }
        }

        private void UpdateExistingProduct(Product existingProduct)
        {
            existingProduct.AmountChange = Convert.ToInt32(TxtMovQuant.Text);
            existingProduct.AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text);
        }

        private void LoadDGV()
        {
            FillDtAdded();
            FillProductList(TxtSearch.Text);
        }

        private bool VerifySupply(Product productDTO)
        {
            if (productDTO.AmountChange <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que 0");
                return false;
            }

            if (_type == 1 && productDTO.AmountChange > productDTO.AvailableAmount)
            {
                MessageBox.Show("Estoque insuficiente");
                return false;
            }

            return true;
        }

        private void CleanProduct()
        {
            _product = new Product();
        }

        private Product CreateProductDTO()
        {
            return new Product
            {
                Id = _product.Id,
                Name = _product.Name,
                Description = _product.Description,
                AmountChange = Convert.ToInt32(TxtMovQuant.Text),
                AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text)
            };
        }
    }
}
