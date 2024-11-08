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
        private readonly StateController _stateController;

        public event Action<Supplier> SupplierSelected;

        // Constructor: Initializes the supplier menu form and sets up necessary variables.
        public SupplierMenu(bool isSelecting)
        {
            try
            {
                _suppliers = new List<Supplier>();
                _supplier = new Supplier();
                _controller = new SupplierController();
                _utils = new Utils();
                _isSelecting = isSelecting;
                _stateController = new StateController();

                InitializeComponent();
                InitializeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing supplier menu: {ex.Message}");
            }
        }

        // Sets up the initial values and configurations for the form components.
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
                MessageBox.Show($"Error initializing form: {ex.Message}");
            }
        }

        // Updates the DataGridView based on the search input.
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView(TxtSearch.Text, false);
        }

        // Validates the number input field.
        private void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            ValidateNum();
        }

        // Updates the selected supplier based on DataGridView selection.
        private void DtSupplier_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        // Prepares the form for adding a new supplier.
        private void BtnNew_Click(object sender, EventArgs e)
        {
            PrepareForNew();
        }

        // Saves the current supplier's data.
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SavingSup();
        }

        // Enables fields for editing.
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HandleFields(_isSelecting, false);
        }

        // Cancels the edit operation and sets fields to read-only.
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandleFields(_isSelecting, true);
        }

        // Closes the form.
        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Selects the current supplier and closes the form.
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectSup();
        }

        // Validates the number field using the utility method.
        private void ValidateNum()
        {
            TxtNumber.Text = _utils.ValidateNumber(TxtNumber.Text);
        }

        // Clears the current supplier data and enables editing fields.
        private void PrepareForNew()
        {
            CleanSupplier();
            HandleFields(_isSelecting, false);
        }

        // Saves the supplier and updates the DataGridView.
        private void SavingSup()
        {
            try
            {
                if (SaveSupplier())
                    FillDataGridView(TxtSearch.Text, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving supplier: {ex.Message}");
            }
        }

        // Invokes the SupplierSelected event if a supplier is selected, then closes the form.
        private void SelectSup()
        {
            if (_supplier != null)
            {
                SupplierSelected?.Invoke(_supplier);
            }
            Close();
        }

        // Updates the selected supplier based on DataGridView selection.
        private void SelectRow()
        {
            _supplier = _utils.SelectRowSupplier(DtSupplier);
            HandleFields(_isSelecting, true);
        }

        // Saves the supplier data after validating fields.
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
                    MessageBox.Show("Supplier saved successfully!");
                }
                return true;
            }
            else
            {
                throw new ArgumentException(
                    "Please fill the following fields before continuing: "
                    + string.Join(", ", _controller.ValidateSupplier(supplier))
                );
            }
        }

        // Adds columns to the DataGridView.
        private void AddColumns()
        {
            _utils.AddSupplierColumns(DtSupplier);
        }

        // Fetches and filters suppliers, then updates the DataGridView.
        private void FillDataGridView(string name, bool dbchange)
        {
            GatherSuppliers(dbchange);
            List<Supplier> filtered = FilterSuppliers(name);
            FillSuppierTable(filtered);
        }

        // Populates the DataGridView with supplier data.
        private void FillSuppierTable(List<Supplier> list)
        {
            DtSupplier.Rows.Clear();

            foreach (var supplier in list)
            {
                DtSupplier.Rows.Add(
                    supplier.Id,
                    supplier.Name,
                    supplier.Phone,
                    supplier.CEP,
                    supplier.Neighborhood,
                    supplier.Street,
                    supplier.Email,
                    supplier.Number,
                    supplier.Complement,
                    supplier.City,
                    supplier.state.Name
                );
            }
        }

        // Populates the ComboBox with state data.
        private void FillCmbStates()
        {
            try
            {
                List<State> states = _stateController.GetAllStates();
                CmbStates.Items.Clear();
                CmbStates.DataSource = states;
                CmbStates.ValueMember = "Id";
                CmbStates.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filling state ComboBox: {ex.Message}");
            }
        }

        // Refreshes the supplier list if empty or if the database has changed.
        private void GatherSuppliers(bool dbchange)
        {
            if (_suppliers.Count <= 0 || dbchange)
            {
                _suppliers = _controller.GatherSuppliers();
                SetStates(_suppliers);
            }
        }

        // Updates the state information for each supplier in the list.
        private void SetStates(List<Supplier> suppliers)
        {
            if (suppliers.Count > 0)
            {
                foreach (Supplier supplier in suppliers)
                {
                    if (supplier.state.Id > 0)
                        supplier.state = _stateController.GetStateById(supplier.state.Id);
                }
            }
        }

        // Filters the supplier list based on the specified name.
        private List<Supplier> FilterSuppliers(string name)
        {
            return _utils.FilterSupplierList(_suppliers, name);
        }

        // Configures form fields based on current supplier data and read-only status.
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
            CmbStates.Text = _supplier.state.Name;

            UpdateButtons(isSelecting, isReadOnly);
            SetFieldReadOnlyStatus(isReadOnly);
        }

        // Sets each field to read-only or editable based on the parameter.
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

        // Creates a new supplier object based on current form values.
        private Supplier CreateNewSupplierObj()
        {
            int stateId = Convert.ToInt32(CmbStates.SelectedValue);

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
                state = new State { Id = stateId }
            };

            if (_supplier.Id > 0)
            {
                supplier.Id = _supplier.Id;
            }

            return supplier;
        }

        // Resets the current supplier and sets to default.
        private void CleanSupplier()
        {
            _supplier = new Supplier();
        }

        // Verifies if mandatory fields meet the minimum length requirements.
        private bool VerifyLength()
        {
            return _utils.VerifyLength(MskTxtPhone.Text, LblPhone.Text, 10)
                && _utils.VerifyLength(MskTxtCEP.Text, LblCEP.Text, 8);
        }

        // Updates the visibility and enabled status of buttons based on selection state.
        private void UpdateButtons(bool isSelecting, bool isEnabled)
        {
            if (isSelecting)
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
    }
}
