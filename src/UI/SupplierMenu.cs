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
        private Supplier _fornecedor = new Supplier();
        private readonly SupplierController _controller = new SupplierController();
        private List<string> states = new List<string>();
        private readonly bool _isSelecting;

        public event Action<Supplier> SupplierSelected;

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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
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

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
            FormatPhone(txtPhone.Text);
        }

        private void TxtCEP_TextChanged(object sender, EventArgs e)
        {
            FormatCEP(txtCEP.Text);
        }

        private void TxtNumber_TextChanged(object sender, EventArgs e)
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
 
        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(_isSelecting, false, null);
                _fornecedor = new Supplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo fornecedor: {ex.Message}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
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

        private void BtnEdit_Click(object sender, EventArgs e)
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                HandleFields(_isSelecting, true, _fornecedor);
                _fornecedor = new Supplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar operação: {ex.Message}");
            }
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_fornecedor.IdSupplier > 0)
                {
                    if (ConfirmDeletion())
                    {
                        DeleteSupplier(_fornecedor.IdSupplier);
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

        private void DtSupplier_SelectionChanged(object sender, EventArgs e)
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
            _fornecedor.IdSupplier = Convert.ToInt32(dtSupplier.Rows[index].Cells["IdFornecedor"].Value);
            _fornecedor.Name = dtSupplier.Rows[index].Cells["NomeFornecedor"].Value.ToString();
            _fornecedor.City = dtSupplier.Rows[index].Cells["Cidade"].Value.ToString();
            _fornecedor.CEP = dtSupplier.Rows[index].Cells["CEP"].Value.ToString();
            _fornecedor.Neighborhood = dtSupplier.Rows[index].Cells["Bairro"].Value.ToString();
            _fornecedor.Phone = dtSupplier.Rows[index].Cells["Telefone"].Value.ToString();
            _fornecedor.Street = dtSupplier.Rows[index].Cells["Rua"].Value.ToString();
            _fornecedor.Email = dtSupplier.Rows[index].Cells["Email"].Value.ToString();
            _fornecedor.Number = dtSupplier.Rows[index].Cells["Numero"].Value.ToString();
            _fornecedor.Complement = dtSupplier.Rows[index].Cells["Complemento"].Value.ToString();
            _fornecedor.State = dtSupplier.Rows[index].Cells["Estado"].Value.ToString();
        }

        private void UpdateUIFromFornecedor()
        {
            txtName.Text = _fornecedor.Name;
            txtCity.Text = _fornecedor.City;
            txtCEP.Text = _fornecedor.CEP;
            txtNeigh.Text = _fornecedor.Neighborhood;
            txtPhone.Text = _fornecedor.Phone;
            txtStreet.Text = _fornecedor.Street;
            txtEmail.Text = _fornecedor.Email;
            txtNumber.Text = _fornecedor.Number;
            txtComplement.Text = _fornecedor.Complement;
            cmbStates.SelectedItem = _fornecedor.State;
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
                    fornecedor.IdSupplier,
                    fornecedor.Name,
                    fornecedor.Phone,
                    fornecedor.CEP,
                    fornecedor.Neighborhood,
                    fornecedor.Street,
                    fornecedor.Email,
                    fornecedor.Number,
                    fornecedor.Complement,
                    fornecedor.City,
                    fornecedor.State
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

        private void HandleFields(bool isSelecting, bool isReadOnly, Supplier fornecedor)
        {
            UpdateFields(isReadOnly, fornecedor);
            UpdateButtons(isSelecting, isReadOnly);
        }

        private void UpdateFields(bool isReadOnly, Supplier fornecedor)
        {
            if (fornecedor != null && fornecedor.IdSupplier > 0)
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

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (_fornecedor != null)
            {
                SupplierSelected?.Invoke(_fornecedor);
            }
            Close();
        }

        private void UpdateFornecedorFromUI()
        {
            _fornecedor.Name = txtName.Text;
            _fornecedor.City = txtCity.Text;
            _fornecedor.CEP = txtCEP.Text;
            _fornecedor.Neighborhood = txtNeigh.Text;
            _fornecedor.Phone = txtPhone.Text;
            _fornecedor.Street = txtStreet.Text;
            _fornecedor.Email = txtEmail.Text;
            _fornecedor.Number = txtNumber.Text;
            _fornecedor.Complement = txtComplement.Text;
            _fornecedor.State = cmbStates.SelectedItem?.ToString();
        }

    }
}
