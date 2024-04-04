using System;
using System.Windows.Forms;
using Gerenciador_de_estoque.Controllers;
using Gerenciador_de_estoque.Models;

namespace Gerenciador_de_estoque.UI
{
    public partial class SupplierMenu : Form
    {
        Fornecedor _fornecedor = new Fornecedor();
        FornecedorController _controller = new FornecedorController();

        public SupplierMenu()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            HandleFields(true, _fornecedor);
            AddColumnsToSupplierList();
            FillSupplierList("");
        }

        private void AddColumnsToSupplierList()
        {
            dtSupplier.Columns.Clear();
            dtSupplier.Columns.Add("IdFornecedor", "Id");
            dtSupplier.Columns["IdFornecedor"].Visible = false;
            dtSupplier.Columns.Add("NomeFornecedor", "Nome");
            dtSupplier.Columns.Add("Cidade", "Cidade");
            dtSupplier.Columns.Add("CEP", "CEP");
            dtSupplier.Columns.Add("Bairro", "Bairro");
            dtSupplier.Columns.Add("Telefone", "Telefone");
            dtSupplier.Columns.Add("Rua", "Rua");
            dtSupplier.Columns.Add("Email", "Email");
            dtSupplier.Columns.Add("Numero", "Número");
            dtSupplier.Columns.Add("Complemento", "Complemento");
            dtSupplier.Columns.Add("Estado", "Estado");
        }

        private void HandleFields(bool isReadOnly, Fornecedor fornecedor)
        {
            UpdateFields(isReadOnly, fornecedor);
            UpdateButtons(isReadOnly);
        }

        private void UpdateFields(bool isReadOnly, Fornecedor fornecedor)
        {
            if (fornecedor != null)
            {
                txtName.Text = fornecedor.NomeFornecedor;
                txtCity.Text = fornecedor.Cidade;
                txtCEP.Text = fornecedor.CEP;
                txtNeigh.Text = fornecedor.Bairro;
                txtPhone.Text = fornecedor.Telefone;
                txtStreet.Text = fornecedor.Rua;
                txtEmail.Text = fornecedor.Email;
                txtNumber.Text = fornecedor.Numero;
                txtComplement.Text = fornecedor.Complemento;
                cmbStates.SelectedItem = fornecedor.Estado;
            }
            else
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
                cmbStates.SelectedIndex = -1;
            }

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

        private void UpdateButtons(bool isEnabled)
        {
            btnNew.Enabled = isEnabled;
            btnNew.Visible = isEnabled;
            btnEdit.Enabled = isEnabled;
            btnEdit.Visible = isEnabled;
            btnSave.Enabled = !isEnabled;
            btnCancel.Enabled = !isEnabled;
            btnCancel.Visible = !isEnabled;
            btnSave.Visible = !isEnabled;
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            if (txtCEP.Text.Length > 8)
            {
                txtCEP.Text = txtCEP.Text.Substring(0, 8);
            }
            else if (txtCEP.Text.Length == 8)
            {
                txtCEP.Text = txtCEP.Text.Insert(5, "-");
            }
            txtCEP.SelectionStart = txtCEP.Text.Length;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e) { }

        private void FillSupplierList(string nome)
        {
            try
            {
                var fornecedores = _controller.GatherFornecedores(nome);
                dtSupplier.Rows.Clear();

                foreach (var fornecedor in fornecedores)
                {
                    dtSupplier.Rows.Add(
                        fornecedor.IdFornecedor,
                        fornecedor.NomeFornecedor,
                        fornecedor.Cidade,
                        fornecedor.CEP,
                        fornecedor.Bairro,
                        fornecedor.Telefone,
                        fornecedor.Rua,
                        fornecedor.Email,
                        fornecedor.Numero,
                        fornecedor.Complemento,
                        fornecedor.Estado
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a lista de fornecedores: {ex.Message}");
            }
        }
    }
}
