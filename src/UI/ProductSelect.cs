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
        private SelectedProd selectedProduct = new SelectedProd();
        private readonly ProductController _controller = new ProductController();
        private List<SelectedProd> added = new List<SelectedProd>();
        public event Action<List<SelectedProd>> ProdutoSelected;
        private readonly int type;
        readonly Utils utils = new Utils();

        public ProductSelect(int type, List<SelectedProd> produtosSelecionados)
        {
            InitializeComponent();
            InitializeComponents();
            InitializeForm();
            this.type = type;
            added = produtosSelecionados;
        }

        private void InitializeComponents()
        {
            try
            {
                SetBehavior();
                AddColumnsToProductLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar os componentes: {ex.Message}");
            }
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedProd productDTO = CreateProductDTO();

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

        private bool VerifySupply(SelectedProd productDTO)
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

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SelectedProd produto in added.ToList())
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

        private void AddColumnsToProductLists()
        {
            try
            {
                utils.AddProductColumns(DtProduct);

                utils.AddProductColumns(DtAdded);
                DtAdded.Columns.Add("AmountChange", type == 0 ? "Entrada" : "Saída");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
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
                    TxtMovQuant.Text = Convert.ToString(selected.AmountChange);
                    TxtAvaQuantity.Text = Convert.ToString(selected.AvailableAmount);
                    if (selected.AmountChange >= 0)
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
                var produtos = _controller.GatherProducts(nome);
                DtProduct.Rows.Clear();

                foreach (var produto in produtos)
                {
                    bool existsInDtAdded = added.Any(p => p.Id == produto.Id);

                    if (!existsInDtAdded)
                    {
                        DtProduct.Rows.Add(
                            produto.Id,
                            produto.Name,
                            produto.AvailableAmount,
                            produto.Description
                        );
                    }
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
            foreach (var product in added)
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
                    selectedProduct = utils.SelectRowProduct(table);

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

        private SelectedProd CreateProductDTO()
        {
            return new SelectedProd
            {
                Id = selectedProduct.Id,
                Name = selectedProduct.Name,
                Description = selectedProduct.Description,
                AmountChange = Convert.ToInt32(TxtMovQuant.Text),
                AvailableAmount = Convert.ToInt32(TxtAvaQuantity.Text)
            };
        }

        public void UpdateSelectedProducts(List<SelectedProd> produtosSelecionados)
        {
            added = produtosSelecionados;
            FillDtAdded();
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
