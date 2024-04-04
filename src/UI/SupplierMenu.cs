using System;
using System.Windows.Forms;

namespace Gerenciador_de_estoque.UI
{
    public partial class SupplierMenu : Form
    {
        public SupplierMenu()
        {
            InitializeComponent();
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
    }
}
