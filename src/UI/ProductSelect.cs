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
        private Product selectedProduct;
        private List<Product> products;
        private readonly ProductController _controller;
        private List<Product> added;
        public event Action<List<Product>> ProdutoSelected;
        private readonly int type;
        private readonly Utils _utils;

        public ProductSelect(int type, List<Product> produtosSelecionados)
        {
            this.type = type;
            added = produtosSelecionados ?? new List<Product>();
            _controller = new ProductController();
            _utils = new Utils();

            selectedProduct = new Product();
            products = new List<Product>();

            InitializeComponent();
            InitializeForm();
        }



        private void InitializeForm()
        {
            try
            {
                SetBehavior();
                AddColumnsToProductLists();
                FillProductList("");
                FillDtAdded();
                HandleFields(selectedProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o formulário: {ex.Message}");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar produto: {ex.Message}");
            }
        }

        private bool _isClearingSelection = false;

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearingSelection)
                return;

            if (DtProduct.SelectedRows.Count > 0)
            {
                SelectRow(DtProduct);
                HandleFields(selectedProduct);
                BtnAdd.Text = "Selecionar";
            }

            _isClearingSelection = true;
            DtAdded.ClearSelection();
            _isClearingSelection = false;
        }

        private void DtAdded_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearingSelection)
                return;

            if (DtAdded.SelectedRows.Count > 0)
            {
                SelectRow(DtAdded);
                HandleFields(selectedProduct);
                BtnAdd.Text = "Confirmar edição";
            }

            _isClearingSelection = true;
            DtProduct.ClearSelection();
            _isClearingSelection = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product productDTO = CreateProductDTO();

                if (!VerifySupply(productDTO))
                {
                    return;
                }

                var existingProduct = added.FirstOrDefault(p => p.Id == productDTO.Id);
                if (existingProduct != null)
                {
                    existingProduct.AmountChange = Convert.ToInt32(TxtMovQuant.Text);
                    existingProduct.AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text);
                }
                else
                {
                    added.Add(productDTO);
                }

                CleanProduct();
                HandleFields(selectedProduct);

                FillDtAdded();
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao adicionar produto: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Product produto in added.ToList())
                {
                    if (produto.Id == selectedProduct.Id)
                    {
                        added.Remove(produto);
                    }
                }
                FillDtAdded();
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover produto: {ex.Message}");
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdutoSelected != null)
                {
                    ProdutoSelected?.Invoke(added);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao confirmar seleção de produtos: {ex.Message}");
            }
        }

        private bool VerifySupply(Product productDTO)
        {
            try
            {
                if (productDTO.AmountChange <= 0)
                {
                    MessageBox.Show("A quantidade deve ser maior que 0");
                    return false;
                }

                if (type == 1 && productDTO.AmountChange > productDTO.AvailableAmount)
                {
                    MessageBox.Show("Estoque insuficiente");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar suprimento: {ex.Message}");
                return false;
            }
        }

        private void AddColumnsToProductLists()
        {
            try
            {
                _utils.AddProductColumns(DtProduct);
                _utils.AddProductColumns(DtAdded);
                DtAdded.Columns.Add("AmountChange", type == 0 ? "Entrada" : "Saída");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void HandleFields(Product selected)
        {
            try
            {
                if (selected != null)
                {
                    TxtName.Text = selected.Name;
                    TxtDescription.Text = selected.Description;
                    TxtAvaQuantity.Text = Convert.ToString(selected.AvailableAmount);
                    if (type == 0)
                    {
                        TxtMovQuant.Text = Convert.ToString(selected.AmountChange);
                    }
                    else
                    {
                        TxtMovQuant.Text = Convert.ToString(selected.AmountChange);
                    }
                }
                else
                {
                    TxtName.Text = "";
                    TxtAvaQuantity.Text = "";
                    TxtMovQuant.Text = "";
                    TxtDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar campos: {ex.Message}");
            }
        }

        private void FillProductList(string nome)
        {
            try
            {
                DtProduct.Rows.Clear();
                if (products.Count <= 0)
                {
                    products = _controller.GatherProducts();

                    FillProductTable(products);
                }
                else
                {
                    List<Product> filtered = _utils.FilterProductList(products, nome);

                    filtered = filtered.Where(p => !added.Any(a => a.Id == p.Id)).ToList();

                    FillProductTable(filtered);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
            }
        }

        private void FillDtAdded()
        {
            DtAdded.Rows.Clear();
            FillAddedTable(added);
        }

        private void FillProductTable(List<Product> list)
        {
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

        private void FillAddedTable(List<Product> list)
        {
            foreach (var product in list)
            {
                string amountChangeDisplay = product.AmountChange.ToString();
                if (type == 0)
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

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    selectedProduct = _utils.SelectRowProduct(table);

                    if (table.Equals(DtProduct))
                    {
                        selectedProduct.AmountChange = 0;
                    }

                    if (table.Equals(DtAdded))
                    {
                        if (
                            int.TryParse(
                                table.CurrentRow.Cells["AmountChange"].Value.ToString(),
                                out int amountChange
                            )
                        )
                        {
                            selectedProduct.AmountChange = amountChange;
                        }
                    }
                    HandleFields(selectedProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        private Product CreateProductDTO()
        {
            return new Product
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                Description = selectedProduct.Description,
                AmountChange = Convert.ToInt32(TxtMovQuant.Text),
                AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text)
            };
        }

        private void SetBehavior()
        {
            if (type == 0)
            {
                LblMovQuant.Text = "Adicionando:";
            }
            else
            {
                LblMovQuant.Text = "Removendo:";
            }
        }

        private void TxtMovQuant_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMovQuant.Text))
            {
                BtnAdd.Enabled = true;
                LblInstruction.Visible = false;
            }
            else
            {
                BtnAdd.Enabled = false;
                LblInstruction.Visible = true;
            }
        }

        private void CleanProduct()
        {
            selectedProduct.Id = 0;
            selectedProduct.Name = string.Empty;
            selectedProduct.Description = string.Empty;
            selectedProduct.AvailableAmount = 0;
            selectedProduct.AmountChange = 0;
        }
    }
}
