using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utils;

namespace Gerenciador_de_estoque.UI
{
    public partial class SupplierMenu : Form
    {
        private Fornecedor _fornecedor = new Fornecedor();
        private FornecedorController _controller = new FornecedorController();
        private List<string> states = new List<string>();
        private bool _isSelecting;

        public event Action<Fornecedor> SupplierSelected;

        public SupplierMenu(bool isSelecting)
        {
            try
            {
                InitializeComponent();
                _isSelecting = isSelecting;
                InitializeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o menu do fornecedor: {ex.Message}");
            }
        }

        private void InitializeForm()
        {
            try
            {
                HandleFields(_isSelecting, true, _fornecedor);
                AddColumnsToSupplierList();
                FillSupplierList("");
                FillStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o formulário: {ex.Message}");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillSupplierList(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de fornecedores: {ex.Message}");
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            FormatPhone(txtPhone.Text);
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            FormatCEP(txtCEP.Text);
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            txtNumber.Text = new Utilities().ValidateNonNegativeNumber(txtNumber.Text);
        }

        private void FormatPhone(string text)
        {
            try
            {
                text = new string(text.Where(char.IsDigit).ToArray());
                text = text.PadLeft(10, '0');

                if (text.Length > 10)
                    text = text.Substring(0, 10);

                if (text.Length == 10)
                    text = text.Insert(0, "(").Insert(3, ")").Insert(8, "-");

                txtPhone.Text = text;
                txtPhone.SelectionStart = txtPhone.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao formatar telefone: {ex.Message}");
            }
        }

        private void FormatCEP(string text)
        {
            try
            {
                text = new string(text.Where(char.IsDigit).ToArray());
                text = text.PadLeft(8, '0');

                if (text.Length > 8)
                    text = text.Substring(0, 8);

                if (text.Length == 8 && !text.Contains("-"))
                    text = text.Insert(5, "-");

                txtCEP.Text = text;
                txtCEP.SelectionStart = txtCEP.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao formatar CEP: {ex.Message}");
            }
        }
 
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(_isSelecting, false, null);
                _fornecedor = new Fornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo fornecedor: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateFornecedorFromUI();
                SaveSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o fornecedor: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(_isSelecting, false, _fornecedor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar fornecedor: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(_isSelecting, true, _fornecedor);
                _fornecedor = new Fornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar operação: {ex.Message}");
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao voltar: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_fornecedor.IdFornecedor > 0)
                {
                    if (ConfirmDeletion())
                    {
                        DeleteSupplier(_fornecedor.IdFornecedor);
                        FillSupplierList(txtSearch.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum fornecedor selecionado para excluir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir fornecedor: {ex.Message}");
            }
        }

        private void dtSupplier_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                HandleFields(_isSelecting, true, _fornecedor);

                if (dtSupplier.CurrentRow != null)
                {
                    int index = dtSupplier.CurrentRow.Index;
                    UpdateFornecedorFromGridRow(index);
                    UpdateUIFromFornecedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar seleção: {ex.Message}");
            }
        }

        private void UpdateFornecedorFromGridRow(int index)
        {
            _fornecedor.IdFornecedor = Convert.ToInt32(dtSupplier.Rows[index].Cells["IdFornecedor"].Value);
            _fornecedor.NomeFornecedor = dtSupplier.Rows[index].Cells["NomeFornecedor"].Value.ToString();
            _fornecedor.Cidade = dtSupplier.Rows[index].Cells["Cidade"].Value.ToString();
            _fornecedor.CEP = dtSupplier.Rows[index].Cells["CEP"].Value.ToString();
            _fornecedor.Bairro = dtSupplier.Rows[index].Cells["Bairro"].Value.ToString();
            _fornecedor.Telefone = dtSupplier.Rows[index].Cells["Telefone"].Value.ToString();
            _fornecedor.Rua = dtSupplier.Rows[index].Cells["Rua"].Value.ToString();
            _fornecedor.Email = dtSupplier.Rows[index].Cells["Email"].Value.ToString();
            _fornecedor.Numero = dtSupplier.Rows[index].Cells["Numero"].Value.ToString();
            _fornecedor.Complemento = dtSupplier.Rows[index].Cells["Complemento"].Value.ToString();
            _fornecedor.Estado = dtSupplier.Rows[index].Cells["Estado"].Value.ToString();
        }

        private void UpdateUIFromFornecedor()
        {
            txtName.Text = _fornecedor.NomeFornecedor;
            txtCity.Text = _fornecedor.Cidade;
            txtCEP.Text = _fornecedor.CEP;
            txtNeigh.Text = _fornecedor.Bairro;
            txtPhone.Text = _fornecedor.Telefone;
            txtStreet.Text = _fornecedor.Rua;
            txtEmail.Text = _fornecedor.Email;
            txtNumber.Text = _fornecedor.Numero;
            txtComplement.Text = _fornecedor.Complemento;
            cmbStates.SelectedItem = _fornecedor.Estado;
        }

        private bool ConfirmDeletion()
        {
            DialogResult dialogResult = MessageBox.Show(
                "Você está prestes a excluir um fornecedor. Você deseja continuar?",
                "Confirmação",
                MessageBoxButtons.YesNo
            );
            return dialogResult == DialogResult.Yes;
        }

        private void DeleteSupplier(int fornecedorId)
        {
            _controller.DeleteFornecedor(fornecedorId);
        }

        private void SaveSupplier()
        {
            _controller.AddFornecedor(_fornecedor);
            HandleFields(_isSelecting, true, _fornecedor);
            FillSupplierList(txtSearch.Text);
        }

        private void AddColumnsToSupplierList()
        {
            dtSupplier.Columns.Clear();
            dtSupplier.Columns.Add("IdFornecedor", "Id");
            dtSupplier.Columns.Add("NomeFornecedor", "Nome");
            dtSupplier.Columns.Add("Telefone", "Telefone");
            dtSupplier.Columns.Add("CEP", "CEP");
            dtSupplier.Columns.Add("Bairro", "Bairro");
            dtSupplier.Columns.Add("Rua", "Rua");
            dtSupplier.Columns.Add("Email", "Email");
            dtSupplier.Columns.Add("Numero", "Número");
            dtSupplier.Columns.Add("Complemento", "Complemento");
            dtSupplier.Columns.Add("Cidade", "Cidade");
            dtSupplier.Columns.Add("Estado", "Estado");

            dtSupplier.Columns["IdFornecedor"].Visible = false;
            dtSupplier.Columns["CEP"].Visible = false;
            dtSupplier.Columns["Bairro"].Visible = false;
            dtSupplier.Columns["Rua"].Visible = false;
            dtSupplier.Columns["Email"].Visible = false;
            dtSupplier.Columns["Numero"].Visible = false;
            dtSupplier.Columns["Complemento"].Visible = false;
            dtSupplier.Columns["Telefone"].Visible = false;
        }

        private void FillSupplierList(string nome)
        {
            var fornecedores = _controller.GatherFornecedores(nome);
            dtSupplier.Rows.Clear();

            foreach (var fornecedor in fornecedores)
            {
                dtSupplier.Rows.Add(
                    fornecedor.IdFornecedor,
                    fornecedor.NomeFornecedor,
                    fornecedor.Telefone,
                    fornecedor.CEP,
                    fornecedor.Bairro,
                    fornecedor.Rua,
                    fornecedor.Email,
                    fornecedor.Numero,
                    fornecedor.Complemento,
                    fornecedor.Cidade,
                    fornecedor.Estado
                );
            }
        }

        private void FillStates()
        {
            states = new Utilities().FillStates(states);
            foreach (string state in states)
            {
                cmbStates.Items.Add(state);
            }
        }

        private void HandleFields(bool isSelecting, bool isReadOnly, Fornecedor fornecedor)
        {
            UpdateFields(isReadOnly, fornecedor);
            UpdateButtons(isSelecting, isReadOnly);
        }

        private void UpdateFields(bool isReadOnly, Fornecedor fornecedor)
        {
            if (fornecedor != null && fornecedor.IdFornecedor > 0)
            {
                UpdateUIFromFornecedor();
            }
            else
            {
                SetFieldsEmpty();
            }

            SetFieldReadOnlyStatus(isReadOnly);
        }

        private void SetFieldsEmpty()
        {
            txtName.Text = "";
            txtCity.Text = "";
            txtCEP.Text = "";
            txtNeigh.Text = "";
            txtPhone.Text = "";
            txtStreet.Text = "";
            txtEmail.Text = "";
            txtNumber.Text = "";
            txtComplement.Text = "";
            cmbStates.SelectedItem = null;
            cmbStates.SelectedText = "";
        }

        private void SetFieldReadOnlyStatus(bool isReadOnly)
        {
            txtName.ReadOnly = isReadOnly;
            txtCity.ReadOnly = isReadOnly;
            txtCEP.ReadOnly = isReadOnly;
            txtNeigh.ReadOnly = isReadOnly;
            txtPhone.ReadOnly = isReadOnly;
            txtStreet.ReadOnly = isReadOnly;
            txtEmail.ReadOnly = isReadOnly;
            txtNumber.ReadOnly = isReadOnly;
            txtComplement.ReadOnly = isReadOnly;
            cmbStates.Enabled = !isReadOnly;
        }

        private void UpdateButtons(bool isSelecting, bool isEnabled)
        {
            if (isSelecting == true)
            {
                btnSelect.Enabled = isSelecting;
                btnSelect.Visible = isSelecting;
                btnNew.Enabled = !isSelecting;
                btnNew.Visible = !isSelecting;
                btnDelete.Visible = !isSelecting;
                btnDelete.Enabled = !isSelecting;
                btnEdit.Enabled = !isSelecting;
                btnEdit.Visible = !isSelecting;
                btnSave.Enabled = !isSelecting;
                btnCancel.Enabled = !isSelecting;
                btnCancel.Visible = !isSelecting;
                btnSave.Visible = !isSelecting;
                btnCancel.Visible = !isSelecting;
                btnCancel.Enabled = !isSelecting;
                btnGoBack.Enabled = !isSelecting;
                btnGoBack.Visible = !isSelecting;
            }
            else
            {
                btnSelect.Enabled = false;
                btnSelect.Visible = false;
                btnNew.Enabled = isEnabled;
                btnNew.Visible = isEnabled;
                btnDelete.Visible = isEnabled;
                btnDelete.Enabled = isEnabled;
                btnEdit.Enabled = isEnabled;
                btnEdit.Visible = isEnabled;
                btnSave.Enabled = !isEnabled;
                btnCancel.Enabled = !isEnabled;
                btnCancel.Visible = !isEnabled;
                btnSave.Visible = !isEnabled;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_fornecedor != null)
            {
                SupplierSelected?.Invoke(_fornecedor);
            }
            Close();
        }

        private void UpdateFornecedorFromUI()
        {
            _fornecedor.NomeFornecedor = txtName.Text;
            _fornecedor.Cidade = txtCity.Text;
            _fornecedor.CEP = txtCEP.Text;
            _fornecedor.Bairro = txtNeigh.Text;
            _fornecedor.Telefone = txtPhone.Text;
            _fornecedor.Rua = txtStreet.Text;
            _fornecedor.Email = txtEmail.Text;
            _fornecedor.Numero = txtNumber.Text;
            _fornecedor.Complemento = txtComplement.Text;
            _fornecedor.Estado = cmbStates.SelectedItem != null ? cmbStates.SelectedItem.ToString() : null;
        }

    }
}
