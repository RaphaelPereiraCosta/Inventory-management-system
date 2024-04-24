using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class SupplierMenu : Form
    {
        private Supplier _fornecedor;
        private readonly SupplierController _controller;
        private List<string> states;
        private readonly bool _isSelecting;
        private readonly Utils utils;

        public event Action<Supplier> SupplierSelected;

        public SupplierMenu(bool isSelecting)
        {
            try
            {
                _controller = new SupplierController();
                utils = new Utils();

                _fornecedor = new Supplier();
                states = new List<string>();

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
            TxtPhone.Text = utils.FormatPhone(TxtPhone.Text);
        }

        private void TxtCEP_TextChanged(object sender, EventArgs e)
        {
            TxtCEP.Text = utils.FormatCEP(TxtCEP.Text);
        }

        private void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            TxtNumber.Text = utils.ValidateNumber(TxtNumber.Text);
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
                if (_fornecedor.Id > 0)
                {
                    if (ConfirmDeletion())
                    {
                        DeleteSupplier(_fornecedor.Id);
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
                    SelectRow();
                    HandleFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar seleção: {ex.Message}");
            }
        }

        private void SelectRow()
        {
            _fornecedor = utils.SelectRowSupplier(DtSupplier);
        }

        private void HandleFields()
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
            utils.AddSupplierColumns(DtSupplier);
        }

        private void FillSupplierList(string nome)
        {
            var fornecedores = _controller.GatherFornecedores(nome);
            DtSupplier.Rows.Clear();

            foreach (var fornecedor in fornecedores)
            {
                DtSupplier.Rows.Add(
                    fornecedor.Id,
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
            if (fornecedor != null && fornecedor.Id > 0)
            {
                HandleFields();
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
