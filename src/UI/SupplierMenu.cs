using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

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
                FillSupplierList(TxtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao preencher a lista de fornecedores: {ex.Message}");
            }
        }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
            FormatPhone(TxtPhone.Text);
        }

        private void TxtCEP_TextChanged(object sender, EventArgs e)
        {
            FormatCEP(TxtCEP.Text);
        }

        private void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            TxtNumber.Text = new Utils().ValidateNonNegativeNumber(TxtNumber.Text);
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

                TxtPhone.Text = text;
                TxtPhone.SelectionStart = TxtPhone.Text.Length;
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

                TxtCEP.Text = text;
                TxtCEP.SelectionStart = TxtCEP.Text.Length;
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
                        FillSupplierList(TxtSearch.Text);
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

                if (DtSupplier.CurrentRow != null)
                {
                    int index = DtSupplier.CurrentRow.Index;
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
            _fornecedor.IdSupplier = Convert.ToInt32(DtSupplier.Rows[index].Cells["IdFornecedor"].Value);
            _fornecedor.Name = DtSupplier.Rows[index].Cells["NomeFornecedor"].Value.ToString();
            _fornecedor.City = DtSupplier.Rows[index].Cells["Cidade"].Value.ToString();
            _fornecedor.CEP = DtSupplier.Rows[index].Cells["CEP"].Value.ToString();
            _fornecedor.Neighborhood = DtSupplier.Rows[index].Cells["Bairro"].Value.ToString();
            _fornecedor.Phone = DtSupplier.Rows[index].Cells["Telefone"].Value.ToString();
            _fornecedor.Street = DtSupplier.Rows[index].Cells["Rua"].Value.ToString();
            _fornecedor.Email = DtSupplier.Rows[index].Cells["Email"].Value.ToString();
            _fornecedor.Number = DtSupplier.Rows[index].Cells["Numero"].Value.ToString();
            _fornecedor.Complement = DtSupplier.Rows[index].Cells["Complemento"].Value.ToString();
            _fornecedor.State = DtSupplier.Rows[index].Cells["Estado"].Value.ToString();
        }

        private void UpdateUIFromFornecedor()
        {
            TxtName.Text = _fornecedor.Name;
            TxtCity.Text = _fornecedor.City;
            TxtCEP.Text = _fornecedor.CEP;
            TxtNeigh.Text = _fornecedor.Neighborhood;
            TxtPhone.Text = _fornecedor.Phone;
            TxtStreet.Text = _fornecedor.Street;
            TxtEmail.Text = _fornecedor.Email;
            TxtNumber.Text = _fornecedor.Number;
            TxtComplement.Text = _fornecedor.Complement;
            CmbStates.SelectedItem = _fornecedor.State;
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
            FillSupplierList(TxtSearch.Text);
        }

        private void AddColumnsToSupplierList()
        {
            DtSupplier.Columns.Clear();
            DtSupplier.Columns.Add("IdFornecedor", "Id");
            DtSupplier.Columns.Add("NomeFornecedor", "Nome");
            DtSupplier.Columns.Add("Telefone", "Telefone");
            DtSupplier.Columns.Add("CEP", "CEP");
            DtSupplier.Columns.Add("Bairro", "Bairro");
            DtSupplier.Columns.Add("Rua", "Rua");
            DtSupplier.Columns.Add("Email", "Email");
            DtSupplier.Columns.Add("Numero", "Número");
            DtSupplier.Columns.Add("Complemento", "Complemento");
            DtSupplier.Columns.Add("Cidade", "Cidade");
            DtSupplier.Columns.Add("Estado", "Estado");

            DtSupplier.Columns["IdFornecedor"].Visible = false;
            DtSupplier.Columns["CEP"].Visible = false;
            DtSupplier.Columns["Bairro"].Visible = false;
            DtSupplier.Columns["Rua"].Visible = false;
            DtSupplier.Columns["Email"].Visible = false;
            DtSupplier.Columns["Numero"].Visible = false;
            DtSupplier.Columns["Complemento"].Visible = false;
            DtSupplier.Columns["Telefone"].Visible = false;
        }

        private void FillSupplierList(string nome)
        {
            var fornecedores = _controller.GatherFornecedores(nome);
            DtSupplier.Rows.Clear();

            foreach (var fornecedor in fornecedores)
            {
                DtSupplier.Rows.Add(
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
            states = new Utils().FillStates(states);
            foreach (string state in states)
            {
                CmbStates.Items.Add(state);
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
            TxtName.Text = "";
            TxtCity.Text = "";
            TxtCEP.Text = "";
            TxtNeigh.Text = "";
            TxtPhone.Text = "";
            TxtStreet.Text = "";
            TxtEmail.Text = "";
            TxtNumber.Text = "";
            TxtComplement.Text = "";
            CmbStates.SelectedItem = null;
            CmbStates.SelectedText = "";
        }

        private void SetFieldReadOnlyStatus(bool isReadOnly)
        {
            TxtName.ReadOnly = isReadOnly;
            TxtCity.ReadOnly = isReadOnly;
            TxtCEP.ReadOnly = isReadOnly;
            TxtNeigh.ReadOnly = isReadOnly;
            TxtPhone.ReadOnly = isReadOnly;
            TxtStreet.ReadOnly = isReadOnly;
            TxtEmail.ReadOnly = isReadOnly;
            TxtNumber.ReadOnly = isReadOnly;
            TxtComplement.ReadOnly = isReadOnly;
            CmbStates.Enabled = !isReadOnly;
        }

        private void UpdateButtons(bool isSelecting, bool isEnabled)
        {
            if (isSelecting == true)
            {
                BtnSelect.Enabled = isSelecting;
                BtnSelect.Visible = isSelecting;
                BtnNew.Enabled = !isSelecting;
                BtnNew.Visible = !isSelecting;
                BtnDelete.Visible = !isSelecting;
                BtnDelete.Enabled = !isSelecting;
                BtnEdit.Enabled = !isSelecting;
                BtnEdit.Visible = !isSelecting;
                BtnSave.Enabled = !isSelecting;
                BtnCancel.Enabled = !isSelecting;
                BtnCancel.Visible = !isSelecting;
                BtnSave.Visible = !isSelecting;
                BtnCancel.Visible = !isSelecting;
                BtnCancel.Enabled = !isSelecting;
                BtnGoBack.Enabled = !isSelecting;
                BtnGoBack.Visible = !isSelecting;
            }
            else
            {
                BtnSelect.Enabled = false;
                BtnSelect.Visible = false;
                BtnNew.Enabled = isEnabled;
                BtnNew.Visible = isEnabled;
                BtnDelete.Visible = isEnabled;
                BtnDelete.Enabled = isEnabled;
                BtnEdit.Enabled = isEnabled;
                BtnEdit.Visible = isEnabled;
                BtnSave.Enabled = !isEnabled;
                BtnCancel.Enabled = !isEnabled;
                BtnCancel.Visible = !isEnabled;
                BtnSave.Visible = !isEnabled;
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
            _fornecedor.Name = TxtName.Text;
            _fornecedor.City = TxtCity.Text;
            _fornecedor.CEP = TxtCEP.Text;
            _fornecedor.Neighborhood = TxtNeigh.Text;
            _fornecedor.Phone = TxtPhone.Text;
            _fornecedor.Street = TxtStreet.Text;
            _fornecedor.Email = TxtEmail.Text;
            _fornecedor.Number = TxtNumber.Text;
            _fornecedor.Complement = TxtComplement.Text;
            _fornecedor.State = CmbStates.SelectedItem?.ToString();
        }

    }
}
