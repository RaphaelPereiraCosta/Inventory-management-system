using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class ProductSelect : Form
    {
        
        private readonly SelectedProd _selectedProduct = new SelectedProd();
        private readonly ProdutoController _controller = new ProdutoController();
        private List<SelectedProd> added = new List<SelectedProd>();
        public event Action<List<SelectedProd>> ProdutoSelected;
        private readonly int type;

        public ProductSelect(int type, List<SelectedProd> produtosSelecionados)
        {
            InitializeComponent();
            InitializeForm();
            this.type = type;
            added = produtosSelecionados;
        }

        private void InitializeForm()
        {
            try
            {
                SetBehavior();
                AddColumnsToProductLists();
                FillProductList("");
                FillDtAdded();
                HandleFields(_selectedProduct);
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

                var existingProduct = added.FirstOrDefault(p =>
                    p.IdProduct == productDTO.IdProduct
                );
                if (existingProduct != null)
                {
                    existingProduct.AmountChange = Convert.ToInt32(TxtMovQuant.Text);
                    existingProduct.AvaliableAmount = Convert.ToInt32(TxtAvaQuantity.Text);
                }
                else
                {
                    added.Add(productDTO);
                }

                CleanProduct();
                UpdateFields(_selectedProduct);

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

            if (type == 1 && productDTO.AmountChange > productDTO.AvaliableAmount)
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
                    if (produto.IdProduct == _selectedProduct.IdProduct)
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
            if (_isClearingSelection) return;

            if (DtProduct.SelectedRows.Count > 0)
            {
                SelectRow(DtProduct);
                UpdateFields(_selectedProduct);
                BtnAdd.Text = "Selecionar";
            }

            _isClearingSelection = true;
            DtAdded.ClearSelection();
            _isClearingSelection = false;
        }

        private void DtAdded_SelectionChanged(object sender, EventArgs e)
        {
            if (_isClearingSelection) return;

            if (DtAdded.SelectedRows.Count > 0)
            {
                SelectRow(DtAdded);
                UpdateFields(_selectedProduct);
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
                DtProduct.Columns.Clear();
                DtProduct.Columns.Add("IdProduct", "Id");
                DtProduct.Columns["IdProduct"].Visible = false;
                DtProduct.Columns.Add("Name", "Nome do Produto");
                DtProduct.Columns.Add("AvaliableAmount", "Quantidade em Estoque");
                DtProduct.Columns.Add("Description", "Descrição");

                DtAdded.Columns.Clear();
                DtAdded.Columns.Add("IdProduct", "Id");
                DtAdded.Columns["IdProduct"].Visible = false;
                DtAdded.Columns.Add("Name", "Nome do produto");

                DtAdded.Columns.Add("Description", "Descrição");
                DtAdded.Columns.Add("AvaliableAmount", "Quantidade Disponivel");
                DtAdded.Columns.Add("AmountChange", type == 0 ? "Entrada" : "Saída");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void UpdateFields(SelectedProd selected)
        {
            try
            {
               if (selected != null)
                {
                    TxtName.Text = selected.Name;
                    TxtDescription.Text = selected.Description;
                    TxtMovQuant.Text = Convert.ToString(selected.AmountChange);
                    TxtAvaQuantity.Text = Convert.ToString(selected.AvaliableAmount);
                    if(selected.AmountChange >= 0)
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

        private void HandleFields(SelectedProd selected)
        {
            try
            {
                UpdateFields(selected);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao manipular campos: {ex.Message}");
            }
        }

        private void FillProductList(string nome)
        {
            try
            {
                var produtos = _controller.GatherProdutos(nome);
                DtProduct.Rows.Clear();

                foreach (var produto in produtos)
                {
                    bool existsInDtAdded = added.Any(p => p.IdProduct == produto.IdProduct);

                    if (!existsInDtAdded)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de produtos: {ex.Message}");
            }
        }

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    int index = table.CurrentRow.Index;
                    
                        _selectedProduct.IdProduct = Convert.ToInt32(table.Rows[index].Cells["IdProduct"].Value);
                        _selectedProduct.Name = table.Rows[index].Cells["Name"].Value.ToString();
                        _selectedProduct.Description = table.Rows[index].Cells["Description"].Value.ToString();
                        _selectedProduct.AvaliableAmount = Convert.ToInt32(table.Rows[index].Cells["AvaliableAmount"].Value);
                    
                    if(table == DtProduct)
                    {
                        _selectedProduct.AmountChange = 0;
                    }

                    if (table == DtAdded)
                    {
                        _selectedProduct.AmountChange = Convert.ToInt32(table.Rows[index].Cells["AmountChange"].Value);
                    }
                        HandleFields(_selectedProduct);
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
                IdProduct = _selectedProduct.IdProduct,
                Name = _selectedProduct.Name,
                Description = _selectedProduct.Description,
                AmountChange = Convert.ToInt32(TxtMovQuant.Text),
                AvaliableAmount = Convert.ToInt32(TxtAvaQuantity.Text)
            };
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
                    product.IdProduct,
                    product.Name,
                    product.Description,
                    product.AvaliableAmount,
                    amountChangeDisplay
                );
            }
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
            _selectedProduct.IdProduct = 0;
            _selectedProduct.Name = string.Empty;
            _selectedProduct.Description = string.Empty;
            _selectedProduct.AvaliableAmount = 0;
            _selectedProduct.AmountChange = 0;

        }
    }
}
