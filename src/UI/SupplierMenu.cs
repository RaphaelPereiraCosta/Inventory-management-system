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
        private List<Supplier> _suppliers;
        private readonly SupplierController _controller;
        private readonly bool _isSelecting;
        private readonly Utils _utils;

        public event Action<Supplier> SupplierSelected;

        public SupplierMenu(bool isSelecting)
        {
            try
            {
                _suppliers = new List<Supplier>();
                _supplier = new Supplier();
                _controller = new SupplierController();
                _utils = new Utils();
                _isSelecting = isSelecting;

                InitializeComponent();

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
                AddColumns();
                FillDataGridView(TxtSearch.Text, true);
                FillCmbStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar o formulário: {ex.Message}");
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, false);
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
            CleanSupplier();
            HandleFields(_isSelecting, false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveSupplier())
                    FillDataGridView(TxtSearch.Text, true);
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

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (_supplier != null)
            {
                SupplierSelected?.Invoke(_supplier);
            }
            Close();
        }

        private void SelectRow()
        {
            _supplier = _utils.SelectRowSupplier(DtSupplier);
            HandleFields(_isSelecting, true);
        }

        private bool SaveSupplier()
        {
            if (!VerifyLength())
                return false;

            Supplier supplier = CreateNewSupplierObj();

            var validationErrors = _controller.ValidateSupplier(supplier);
            if (validationErrors.Count <= 0)
            {
                if (_controller.AddSupplier(supplier))
                {
                    MessageBox.Show("Fornecedor salvo com sucesso!");
                }

                return true;
            }
            else
            {
                throw new ArgumentException(
                    "Preencha os campos a seguir antes de continuar: "
                        + string.Join(", ", _controller.ValidateSupplier(supplier))
                );
            }
        }

        private void AddColumns()
        {
            _utils.AddSupplierColumns(DtSupplier);
        }

        private void FillDataGridView(string name, bool dbchange)
        {
            GatherSuppliers(dbchange);
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

        private void FillCmbStates()
        {
            CmbStates.Items.AddRange(new Utils().ListStates().ToArray());
        }

        private void GatherSuppliers(bool dbchange)
        {
            if (_suppliers.Count <= 0 || dbchange)
                _suppliers = _controller.GatherSuppliers();
        }

        private List<Supplier> FilterSuppliers(string name)
        {
            return _utils.FilterSupplierList(_suppliers, name);
        }

        private void HandleFields(bool isSelecting, bool isReadOnly)
        {
            TxtName.Text = _supplier.Name ?? "";
            TxtCity.Text = _supplier.City ?? "";
            MskTxtCEP.Text = _supplier.CEP ?? "";
            TxtNeigh.Text = _supplier.Neighborhood ?? "";
            MskTxtPhone.Text = _supplier.Phone ?? "";
            TxtStreet.Text = _supplier.Street ?? "";
            TxtEmail.Text = _supplier.Email ?? "";
            TxtNumber.Text = _supplier.Number ?? "";
            TxtComplement.Text = _supplier.Complement ?? "";
            CmbStates.SelectedItem = _supplier.State ?? null;

            UpdateButtons(isSelecting, isReadOnly);

            SetFieldReadOnlyStatus(isReadOnly);
        }

        private void SetFieldReadOnlyStatus(bool isReadOnly)
        {
            TxtName.ReadOnly = isReadOnly;
            TxtCity.ReadOnly = isReadOnly;
            MskTxtCEP.ReadOnly = isReadOnly;
            TxtNeigh.ReadOnly = isReadOnly;
            MskTxtPhone.ReadOnly = isReadOnly;
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
                BtnEdit.Enabled = isEnabled;
                BtnEdit.Visible = isEnabled;
                BtnSave.Enabled = !isEnabled;
                BtnCancel.Enabled = !isEnabled;
                BtnCancel.Visible = !isEnabled;
                BtnSave.Visible = !isEnabled;
            }
        }

        private Supplier CreateNewSupplierObj()
        {
            Supplier supplier = new Supplier
            {
                Name = TxtName.Text,
                City = TxtCity.Text,
                CEP = MskTxtCEP.Text,
                Neighborhood = TxtNeigh.Text,
                Phone = MskTxtPhone.Text,
                Street = TxtStreet.Text,
                Email = TxtEmail.Text,
                Number = TxtNumber.Text,
                Complement = TxtComplement.Text,
                State = CmbStates.SelectedItem?.ToString()
            };

            if (_supplier.Id > 0)
                supplier.Id = _supplier.Id;

            return supplier;
        }

        private void CleanSupplier()
        {
            _supplier = new Supplier();
        }

        private bool VerifyLength()
        {
            if (
                !_utils.VerifyLength(MskTxtPhone.Text, LblPhone.Text, 10)
                || !_utils.VerifyLength(MskTxtCEP.Text, LblCEP.Text, 8)
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
