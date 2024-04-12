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
        private readonly Produto _produto = new Produto();
        private readonly ProdutoSelecionado _selectedProduct = new ProdutoSelecionado();
        private readonly ProdutoController _controller = new ProdutoController();
        private List<ProdutoSelecionado> added = new List<ProdutoSelecionado>();
        public event Action<List<ProdutoSelecionado>> ProdutoSelected;
        private readonly int type;

        public ProductSelect(int type, List<ProdutoSelecionado> produtosSelecionados)
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
                HandleFields(_produto, null);
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
                ProdutoSelecionado productDTO = CreateProductDTO();
                int quantity = Convert.ToInt32(TxtMovQuant.Text);
                int availableQuantity = Convert.ToInt32(TxtAvaQuantity.Text);

                if (quantity <= 0)
                {
                    MessageBox.Show(
                        "A quantidade deve ser maior que 0!",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                if (type == 1 && quantity > availableQuantity)
                {
                    MessageBox.Show(
                        "O estoque do produto é insuficiente!",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                UpdateStockQuantity(productDTO, quantity);

                var existingProduct = added.FirstOrDefault(p =>
                    p.IdProduto == productDTO.IdProduto
                );
                if (existingProduct != null)
                {
                    existingProduct.QuantidadeEstoque = quantity;
                    existingProduct.QuantidadeDisponivel = availableQuantity;
                }
                else
                {
                    added.Add(productDTO);
                }

                CleanProduct();
                UpdateFields(_produto, null);

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
                foreach (ProdutoSelecionado produto in added.ToList())
                {
                    if (produto.IdProduto == _produto.IdProduto)
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
                UpdateFields(_produto, null);
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
                UpdateFields(null, _selectedProduct);
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
                DtProduct.Columns.Add("IdProduto", "Id");
                DtProduct.Columns["IdProduto"].Visible = false;
                DtProduct.Columns.Add("NomeProduto", "Nome do produto");
                DtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em estoque");
                DtProduct.Columns.Add("Descricao", "Descrição");

                DtAdded.Columns.Clear();
                DtAdded.Columns.Add("IdProduto", "Id");
                DtAdded.Columns["IdProduto"].Visible = false;
                DtAdded.Columns.Add("NomeProduto", "Nome do produto");

                DtAdded.Columns.Add("Descricao", "Descrição");
                DtAdded.Columns.Add("QuantidadeEstoque", "Nova quantidade");
                DtAdded.Columns.Add("QuantidadeDisponivel", "Quantidade disponivel");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void UpdateFields(Produto produto, ProdutoSelecionado selected)
        {
            try
            {
                if (produto != null)
                {
                    TxtName.Text = produto.NomeProduto;
                    TxtDescription.Text = produto.Descricao;
                    TxtAvaQuantity.Text = produto.QuantidadeEstoque.ToString();
                    TxtMovQuant.Text = "";
                }
                else if (selected != null)
                {
                    TxtName.Text = selected.NomeProduto;
                    TxtDescription.Text = selected.Descricao;


                    TxtMovQuant.Text = Convert.ToString(selected.QuantidadeEstoque);
                    TxtAvaQuantity.Text = Convert.ToString(selected.QuantidadeDisponivel);
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


        private void HandleFields(Produto produto, ProdutoSelecionado selected)
        {
            try
            {
                UpdateFields(produto, selected);
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
                    bool existsInDtAdded = added.Any(p => p.IdProduto == produto.IdProduto);

                    if (!existsInDtAdded)
                    {
                        DtProduct.Rows.Add(
                            produto.IdProduto,
                            produto.NomeProduto,
                            produto.QuantidadeEstoque,
                            produto.Descricao
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

                    if (table == DtProduct)
                    {
                        _produto.NomeProduto = table.Rows[index].Cells["NomeProduto"].Value.ToString();
                        _produto.QuantidadeEstoque = Convert.ToInt32(table.Rows[index].Cells["QuantidadeEstoque"].Value);
                        _produto.Descricao = table.Rows[index].Cells["Descricao"].Value.ToString();
                        _produto.IdProduto = Convert.ToInt32(table.Rows[index].Cells["IdProduto"].Value);
                        TxtName.Text = _produto.NomeProduto;
                        TxtAvaQuantity.Text = _produto.QuantidadeEstoque.ToString();
                        TxtDescription.Text = _produto.Descricao;

                        HandleFields(_produto, null);
                    }
                    else if (table == DtAdded)
                    {
                        _selectedProduct.IdProduto = Convert.ToInt32(table.Rows[index].Cells["IdProduto"].Value);
                        _selectedProduct.NomeProduto = table.Rows[index].Cells["NomeProduto"].Value.ToString();
                        _selectedProduct.Descricao = table.Rows[index].Cells["Descricao"].Value.ToString();
                        _selectedProduct.QuantidadeEstoque = Convert.ToInt32(table.Rows[index].Cells["QuantidadeEstoque"].Value);
                        _selectedProduct.QuantidadeDisponivel = Convert.ToInt32(table.Rows[index].Cells["QuantidadeDisponivel"].Value);
                        TxtName.Text = _selectedProduct.NomeProduto;
                        TxtMovQuant.Text = _selectedProduct.QuantidadeEstoque.ToString();

                        HandleFields(null, _selectedProduct);
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }


        private ProdutoSelecionado CreateProductDTO()
        {
            return new ProdutoSelecionado
            {
                IdProduto = _produto.IdProduto,
                NomeProduto = _produto.NomeProduto,
                Descricao = _produto.Descricao,
                QuantidadeEstoque = Convert.ToInt32(TxtMovQuant.Text),
                QuantidadeDisponivel = Convert.ToInt32(TxtAvaQuantity.Text)
            };
        }

        private void UpdateStockQuantity(ProdutoSelecionado productDTO, int quantity)
        {
            if (type != 1 && quantity >= 0)
            {
                productDTO.QuantidadeEstoque = quantity;
            }
            else if (type == 1 && quantity <= productDTO.QuantidadeEstoque)
            {
                productDTO.QuantidadeEstoque = quantity;
            }
            else
            {
                MessageBox.Show("Estoque insuficiente");
            }
        }

        private void FillDtAdded()
        {
            DtAdded.Rows.Clear();
            foreach (var product in added)
            {
                DtAdded.Rows.Add(
                    product.IdProduto,
                    product.NomeProduto,
                    product.Descricao,
                    product.QuantidadeEstoque,
                    product.QuantidadeDisponivel
                );
            }
        }


        public void UpdateSelectedProducts(List<ProdutoSelecionado> produtosSelecionados)
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
            _produto.IdProduto = 0;
            _produto.NomeProduto = string.Empty;
            _produto.Descricao = string.Empty;
            _produto.QuantidadeEstoque = 0;
        }
    }
}
