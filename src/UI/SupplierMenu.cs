using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Utilities;

namespace Gerenciador_de_estoque.src.UI
{
    public partial class SupplierMenu : Form
    {
        private Supplier _supplier;
        private List<Supplier> suppliers;
        private readonly SupplierController _controller;
        private List<string> states;
        private readonly bool _isSelecting;
        private readonly Utils _utils;

        public event Action<Supplier> SupplierSelected;

        public SupplierMenu(bool isSelecting)
        {
            try
            {
                _controller = new SupplierController();
                _utils = new Utils();
                suppliers = new List<Supplier>();
                _supplier = new Supplier();

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
                HandleFields(_isSelecting, true);
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
            FillSupplierList(TxtSearch.Text);
        }

        private void TxtName_TextChanged(object sender, EventArgs e) { }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
            TxtPhone.Text = _utils.FormatPhone(TxtPhone.Text);
        }

        private void TxtCEP_TextChanged(object sender, EventArgs e)
        {
            TxtCEP.Text = _utils.FormatCEP(TxtCEP.Text);
        }

        private void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            TxtNumber.Text = _utils.ValidateNumber(TxtNumber.Text);
        }

        private void DtSupplier_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            _supplier = new Supplier();
            HandleFields(_isSelecting, false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSupplierObj();
                SaveSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o fornecedor: {ex.Message}");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(_isSelecting, false);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(_isSelecting, true);
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
            DeleteSupplier();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (_supplier != null)
            {
                SupplierSelected?.Invoke(_supplier);
            }
            Close();
        }

        private void HandleFields(bool isSelecting, bool isReadOnly)
        {
            TxtName.Text = _supplier.Name ?? "";
            TxtCity.Text = _supplier.City ?? "";
            TxtCEP.Text = _supplier.CEP ?? "";
            TxtNeigh.Text = _supplier.Neighborhood ?? "";
            TxtPhone.Text = _supplier.Phone ?? "";
            TxtStreet.Text = _supplier.Street ?? "";
            TxtEmail.Text = _supplier.Email ?? "";
            TxtNumber.Text = _supplier.Number ?? "";
            TxtComplement.Text = _supplier.Complement ?? "";
            CmbStates.SelectedItem = _supplier.State ?? null;

            UpdateButtons(isSelecting, isReadOnly);

            SetFieldReadOnlyStatus(isReadOnly);
        }

        private void SelectRow()
        {
            _supplier = _utils.SelectRowSupplier(DtSupplier);

            HandleFields(_isSelecting, true);
        }

        private void SaveSupplier()
        {
            _controller.AddFornecedor(_supplier);
            HandleFields(_isSelecting, true);
            FillSupplierList(TxtSearch.Text);
        }

        private void DeleteSupplier()
        {
            if (ConfirmDeletion())
            {
                _controller.DeleteFornecedor(_supplier.Id);
                FillSupplierList(TxtSearch.Text);
            }
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

        private void AddColumnsToSupplierList()
        {
            _utils.AddSupplierColumns(DtSupplier);
        }

        private void FillSupplierList(string name)
        {
            GatherSuppliers();

            List<Supplier> filtered = FilterSuppliers(name);

            FillSuppierTable(filtered);
        }

        private void FillSuppierTable(List<Supplier> list)
        {
            DtSupplier.Rows.Clear();

            foreach (var fornecedor in list)
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

        private void GatherSuppliers()
        {
            if (suppliers.Count <= 0)
                suppliers = _controller.GatherSuppliers();
        }

        private List<Supplier> FilterSuppliers(string name)
        {
            return _utils.FilterSupplierList(suppliers, name);
        }

        private void FillStates()
        {
            states = new Utils().FillStates(states);
            foreach (string state in states)
            {
                CmbStates.Items.Add(state);
            }
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

        private void UpdateSupplierObj()
        {
            _supplier.Name = TxtName.Text;
            _supplier.City = TxtCity.Text;
            _supplier.CEP = TxtCEP.Text;
            _supplier.Neighborhood = TxtNeigh.Text;
            _supplier.Phone = TxtPhone.Text;
            _supplier.Street = TxtStreet.Text;
            _supplier.Email = TxtEmail.Text;
            _supplier.Number = TxtNumber.Text;
            _supplier.Complement = TxtComplement.Text;
            _supplier.State = CmbStates.SelectedItem?.ToString();
        }
    }
}
