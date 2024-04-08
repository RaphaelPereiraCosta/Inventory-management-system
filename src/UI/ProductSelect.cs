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
        private readonly ProdutoController _controller = new ProdutoController();
        private List<Produto> added = new List<Produto>();
        public event Action<List<Produto>> ProdutoSelected;
        private readonly int type;

        public ProductSelect(int type, List<Produto> produtosSelecionados)
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
                AddColumnsToProductLists();
                FillProductList("");
                FillDtAdded();
                HandleFields(_produto);
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

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtAdded.SelectedRows.Count > 0)
                {
                    Produto produtoDTO = (Produto)DtAdded.SelectedRows[0].DataBoundItem;
                    added.Remove(produtoDTO);
                    DtAdded.Rows.Remove(DtAdded.SelectedRows[0]);
                    FillProductList(TxtSearch.Text);
                }
                else
                {
                    MessageBox.Show("Nenhum produto selecionado para remover");
                }
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

        private void DtProduct_SelectionChanged(object sender, EventArgs e)
        {
            DtAdded.ClearSelection();
            LblAvalQuantity.Text = "Quantidade Disponivel";
            SelectRow(DtProduct);
        }

        private void DtAdded_SelectionChanged(object sender, EventArgs e)
        {
            DtProduct.ClearSelection();
            LblAvalQuantity.Text = "Quantidade";
            SelectRow(DtAdded);
        }

        private void HandleFields(Produto produto)
        {
            try
            {
                UpdateFields(produto);
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

        private void AddColumnsToProductLists()
        {
            try
            {
                DtProduct.Columns.Clear();
                DtProduct.Columns.Add("IdProduto", "Id");
                DtProduct.Columns["IdProduto"].Visible = false;
                DtProduct.Columns.Add("NomeProduto", "Nome do Produto");
                DtProduct.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque");
                DtProduct.Columns.Add("Descricao", "Descrição");

                DtAdded.Columns.Clear();
                DtAdded.Columns.Add("IdProduto", "Id");
                DtAdded.Columns["IdProduto"].Visible = false;
                DtAdded.Columns.Add("NomeProduto", "Nome do Produto");
                DtAdded.Columns.Add("QuantidadeEstoque", "Quantidade em Estoque");
                DtAdded.Columns.Add("Descricao", "Descrição");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }
        }

        private void UpdateFields(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    TxtName.Text = produto.NomeProduto;
                    TxtAvaQuantity.Text = Convert.ToString(produto.QuantidadeEstoque);
                }
                else
                {
                    TxtName.Text = "";
                    TxtAvaQuantity.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar campos: {ex.Message}");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Produto productDTO = CreateProductDTO();
                int quantity = GetProductQuantity();

                if (quantity == -1)
                {
                    return;
                }

                UpdateStockQuantity(productDTO, quantity);
                added.Add(productDTO);

                FillDtAdded();
                FillProductList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when adding product: {ex.Message}");
            }
        }

        private Produto CreateProductDTO()
        {
            return new Produto
            {
                IdProduto = _produto.IdProduto,
                NomeProduto = _produto.NomeProduto,
                Descricao = _produto.Descricao
            };
        }

        private int GetProductQuantity()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter the quantity of the product to be moved",
                "Product Quantity",
                "0",
                -1,
                -1
            );
            if (int.TryParse(input, out int quantity))
            {
                return quantity;
            }
            else
            {
                MessageBox.Show("Invalid quantity");
                return -1;
            }
        }

        private void UpdateStockQuantity(Produto productDTO, int quantity)
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
                MessageBox.Show("Insufficient stock");
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
                    product.QuantidadeEstoque,
                    product.Descricao
                );
            }
        }

        private void SelectRow(DataGridView table)
        {
            try
            {
                if (table.CurrentRow != null)
                {
                    int index = table.CurrentRow.Index;

                    _produto.NomeProduto = table.Rows[index].Cells["NomeProduto"].Value.ToString();
                    _produto.QuantidadeEstoque = Convert.ToInt32(
                        table.Rows[index].Cells["QuantidadeEstoque"].Value
                    );
                    _produto.Descricao = table.Rows[index].Cells["Descricao"].Value.ToString();
                    _produto.IdProduto = Convert.ToInt32(
                        table.Rows[index].Cells["IdProduto"].Value
                    );

                    TxtName.Text = _produto.NomeProduto;
                    TxtAvaQuantity.Text = _produto.QuantidadeEstoque.ToString();
                }
                HandleFields(_produto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
            }
        }

        public void UpdateSelectedProducts(List<Produto> produtosSelecionados)
        {
            added = produtosSelecionados;
            FillDtAdded();
        }
    }
}
