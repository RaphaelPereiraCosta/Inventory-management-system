namespace Gerenciador_de_estoque.src.UI
{
    partial class SupplyMovementMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblType = new System.Windows.Forms.Label();
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtPhone = new System.Windows.Forms.TextBox();
            this.LblCEP = new System.Windows.Forms.Label();
            this.TxtCEP = new System.Windows.Forms.TextBox();
            this.LblState = new System.Windows.Forms.Label();
            this.LblCity = new System.Windows.Forms.Label();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.LblNeigh = new System.Windows.Forms.Label();
            this.TxtNeigh = new System.Windows.Forms.TextBox();
            this.LblComplement = new System.Windows.Forms.Label();
            this.TxtComplement = new System.Windows.Forms.TextBox();
            this.LblNumber = new System.Windows.Forms.Label();
            this.TxtNumber = new System.Windows.Forms.TextBox();
            this.LblStreet = new System.Windows.Forms.Label();
            this.TxtStreet = new System.Windows.Forms.TextBox();
            this.LblSupName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtState = new System.Windows.Forms.TextBox();
            this.BtnSelectSupplier = new System.Windows.Forms.Button();
            this.DtProduct = new System.Windows.Forms.DataGridView();
            this.LblQuantity = new System.Windows.Forms.Label();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.LblDescription = new System.Windows.Forms.Label();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.LblProdName = new System.Windows.Forms.Label();
            this.TxtProdName = new System.Windows.Forms.TextBox();
            this.BtnSelectProducts = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblAmountChanged = new System.Windows.Forms.Label();
            this.TxtAmountChanged = new System.Windows.Forms.TextBox();
            this.TxtDate = new System.Windows.Forms.TextBox();
            this.LblTodayDate = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.ChkToday = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(22, 31);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(98, 13);
            this.LblType.TabIndex = 5;
            this.LblType.Text = "Movimentação de: ";
            // 
            // CmbType
            // 
            this.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(126, 28);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(121, 21);
            this.CmbType.TabIndex = 4;
            this.CmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(342, 34);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(35, 13);
            this.LblEmail.TabIndex = 48;
            this.LblEmail.Text = "E-mail";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(345, 50);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.ReadOnly = true;
            this.TxtEmail.Size = new System.Drawing.Size(190, 20);
            this.TxtEmail.TabIndex = 47;
            // 
            // LblPhone
            // 
            this.LblPhone.AutoSize = true;
            this.LblPhone.Location = new System.Drawing.Point(538, 34);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(49, 13);
            this.LblPhone.TabIndex = 46;
            this.LblPhone.Text = "Telefone";
            // 
            // TxtPhone
            // 
            this.TxtPhone.Location = new System.Drawing.Point(541, 50);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.ReadOnly = true;
            this.TxtPhone.Size = new System.Drawing.Size(134, 20);
            this.TxtPhone.TabIndex = 45;
            // 
            // LblCEP
            // 
            this.LblCEP.AutoSize = true;
            this.LblCEP.Location = new System.Drawing.Point(678, 34);
            this.LblCEP.Name = "LblCEP";
            this.LblCEP.Size = new System.Drawing.Size(28, 13);
            this.LblCEP.TabIndex = 44;
            this.LblCEP.Text = "CEP";
            // 
            // TxtCEP
            // 
            this.TxtCEP.Location = new System.Drawing.Point(681, 50);
            this.TxtCEP.Name = "TxtCEP";
            this.TxtCEP.ReadOnly = true;
            this.TxtCEP.Size = new System.Drawing.Size(140, 20);
            this.TxtCEP.TabIndex = 43;
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Location = new System.Drawing.Point(756, 85);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(40, 13);
            this.LblState.TabIndex = 42;
            this.LblState.Text = "Estado";
            // 
            // LblCity
            // 
            this.LblCity.AutoSize = true;
            this.LblCity.Location = new System.Drawing.Point(616, 85);
            this.LblCity.Name = "LblCity";
            this.LblCity.Size = new System.Drawing.Size(40, 13);
            this.LblCity.TabIndex = 41;
            this.LblCity.Text = "Cidade";
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(619, 101);
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.ReadOnly = true;
            this.TxtCity.Size = new System.Drawing.Size(134, 20);
            this.TxtCity.TabIndex = 40;
            // 
            // LblNeigh
            // 
            this.LblNeigh.AutoSize = true;
            this.LblNeigh.Location = new System.Drawing.Point(457, 85);
            this.LblNeigh.Name = "LblNeigh";
            this.LblNeigh.Size = new System.Drawing.Size(34, 13);
            this.LblNeigh.TabIndex = 39;
            this.LblNeigh.Text = "Bairro";
            // 
            // TxtNeigh
            // 
            this.TxtNeigh.Location = new System.Drawing.Point(460, 101);
            this.TxtNeigh.Name = "TxtNeigh";
            this.TxtNeigh.ReadOnly = true;
            this.TxtNeigh.Size = new System.Drawing.Size(153, 20);
            this.TxtNeigh.TabIndex = 38;
            // 
            // LblComplement
            // 
            this.LblComplement.AutoSize = true;
            this.LblComplement.Location = new System.Drawing.Point(302, 85);
            this.LblComplement.Name = "LblComplement";
            this.LblComplement.Size = new System.Drawing.Size(71, 13);
            this.LblComplement.TabIndex = 37;
            this.LblComplement.Text = "Complemento";
            // 
            // TxtComplement
            // 
            this.TxtComplement.Location = new System.Drawing.Point(305, 101);
            this.TxtComplement.Name = "TxtComplement";
            this.TxtComplement.ReadOnly = true;
            this.TxtComplement.Size = new System.Drawing.Size(149, 20);
            this.TxtComplement.TabIndex = 36;
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Location = new System.Drawing.Point(235, 85);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(44, 13);
            this.LblNumber.TabIndex = 35;
            this.LblNumber.Text = "Numero";
            // 
            // TxtNumber
            // 
            this.TxtNumber.Location = new System.Drawing.Point(238, 101);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.ReadOnly = true;
            this.TxtNumber.Size = new System.Drawing.Size(59, 20);
            this.TxtNumber.TabIndex = 34;
            // 
            // LblStreet
            // 
            this.LblStreet.AutoSize = true;
            this.LblStreet.Location = new System.Drawing.Point(17, 85);
            this.LblStreet.Name = "LblStreet";
            this.LblStreet.Size = new System.Drawing.Size(27, 13);
            this.LblStreet.TabIndex = 33;
            this.LblStreet.Text = "Rua";
            // 
            // TxtStreet
            // 
            this.TxtStreet.Location = new System.Drawing.Point(20, 101);
            this.TxtStreet.Name = "TxtStreet";
            this.TxtStreet.ReadOnly = true;
            this.TxtStreet.Size = new System.Drawing.Size(212, 20);
            this.TxtStreet.TabIndex = 32;
            // 
            // LblSupName
            // 
            this.LblSupName.AutoSize = true;
            this.LblSupName.Location = new System.Drawing.Point(17, 34);
            this.LblSupName.Name = "LblSupName";
            this.LblSupName.Size = new System.Drawing.Size(104, 13);
            this.LblSupName.TabIndex = 31;
            this.LblSupName.Text = "Nome do fornecedor";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(20, 50);
            this.TxtName.Name = "TxtName";
            this.TxtName.ReadOnly = true;
            this.TxtName.Size = new System.Drawing.Size(319, 20);
            this.TxtName.TabIndex = 30;
            // 
            // TxtState
            // 
            this.TxtState.Location = new System.Drawing.Point(759, 101);
            this.TxtState.Name = "TxtState";
            this.TxtState.ReadOnly = true;
            this.TxtState.Size = new System.Drawing.Size(80, 20);
            this.TxtState.TabIndex = 49;
            // 
            // BtnSelectSupplier
            // 
            this.BtnSelectSupplier.Location = new System.Drawing.Point(376, 139);
            this.BtnSelectSupplier.Name = "BtnSelectSupplier";
            this.BtnSelectSupplier.Size = new System.Drawing.Size(140, 23);
            this.BtnSelectSupplier.TabIndex = 50;
            this.BtnSelectSupplier.Text = "Selecionar fornecedor";
            this.BtnSelectSupplier.UseVisualStyleBackColor = true;
            this.BtnSelectSupplier.Click += new System.EventHandler(this.BtnSelectSupplier_Click);
            // 
            // DtProduct
            // 
            this.DtProduct.AllowUserToAddRows = false;
            this.DtProduct.AllowUserToDeleteRows = false;
            this.DtProduct.AllowUserToOrderColumns = true;
            this.DtProduct.AllowUserToResizeColumns = false;
            this.DtProduct.AllowUserToResizeRows = false;
            this.DtProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtProduct.Location = new System.Drawing.Point(411, 64);
            this.DtProduct.MultiSelect = false;
            this.DtProduct.Name = "DtProduct";
            this.DtProduct.ReadOnly = true;
            this.DtProduct.RowHeadersVisible = false;
            this.DtProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtProduct.Size = new System.Drawing.Size(387, 164);
            this.DtProduct.TabIndex = 51;
            this.DtProduct.SelectionChanged += new System.EventHandler(this.DtProduct_SelectionChanged);
            // 
            // LblQuantity
            // 
            this.LblQuantity.AutoSize = true;
            this.LblQuantity.Location = new System.Drawing.Point(164, 64);
            this.LblQuantity.Name = "LblQuantity";
            this.LblQuantity.Size = new System.Drawing.Size(88, 13);
            this.LblQuantity.TabIndex = 57;
            this.LblQuantity.Text = "Quantidade atual";
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(167, 80);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.ReadOnly = true;
            this.TxtAmount.Size = new System.Drawing.Size(73, 20);
            this.TxtAmount.TabIndex = 56;
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(16, 112);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(55, 13);
            this.LblDescription.TabIndex = 55;
            this.LblDescription.Text = "Descrição";
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(19, 128);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.ReadOnly = true;
            this.TxtDescription.Size = new System.Drawing.Size(300, 100);
            this.TxtDescription.TabIndex = 54;
            // 
            // LblProdName
            // 
            this.LblProdName.AutoSize = true;
            this.LblProdName.Location = new System.Drawing.Point(16, 63);
            this.LblProdName.Name = "LblProdName";
            this.LblProdName.Size = new System.Drawing.Size(35, 13);
            this.LblProdName.TabIndex = 53;
            this.LblProdName.Text = "Nome";
            // 
            // TxtProdName
            // 
            this.TxtProdName.Location = new System.Drawing.Point(19, 79);
            this.TxtProdName.Name = "TxtProdName";
            this.TxtProdName.ReadOnly = true;
            this.TxtProdName.Size = new System.Drawing.Size(142, 20);
            this.TxtProdName.TabIndex = 52;
            // 
            // BtnSelectProducts
            // 
            this.BtnSelectProducts.Location = new System.Drawing.Point(411, 21);
            this.BtnSelectProducts.Name = "BtnSelectProducts";
            this.BtnSelectProducts.Size = new System.Drawing.Size(387, 23);
            this.BtnSelectProducts.TabIndex = 58;
            this.BtnSelectProducts.Text = "Selecionar produtos";
            this.BtnSelectProducts.UseVisualStyleBackColor = true;
            this.BtnSelectProducts.Click += new System.EventHandler(this.BtnSelectProducts_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(316, 468);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(228, 38);
            this.BtnConfirm.TabIndex = 59;
            this.BtnConfirm.Text = "Confirmar";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LblAmountChanged);
            this.panel1.Controls.Add(this.TxtAmountChanged);
            this.panel1.Controls.Add(this.DtProduct);
            this.panel1.Controls.Add(this.BtnSelectProducts);
            this.panel1.Controls.Add(this.LblQuantity);
            this.panel1.Controls.Add(this.TxtDescription);
            this.panel1.Controls.Add(this.TxtAmount);
            this.panel1.Controls.Add(this.CmbType);
            this.panel1.Controls.Add(this.LblDescription);
            this.panel1.Controls.Add(this.LblType);
            this.panel1.Controls.Add(this.TxtProdName);
            this.panel1.Controls.Add(this.LblProdName);
            this.panel1.Location = new System.Drawing.Point(12, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 250);
            this.panel1.TabIndex = 60;
            // 
            // LblAmountChanged
            // 
            this.LblAmountChanged.AutoSize = true;
            this.LblAmountChanged.Location = new System.Drawing.Point(255, 63);
            this.LblAmountChanged.Name = "LblAmountChanged";
            this.LblAmountChanged.Size = new System.Drawing.Size(62, 13);
            this.LblAmountChanged.TabIndex = 60;
            this.LblAmountChanged.Text = "Quantidade";
            // 
            // TxtAmountChanged
            // 
            this.TxtAmountChanged.Location = new System.Drawing.Point(258, 79);
            this.TxtAmountChanged.Name = "TxtAmountChanged";
            this.TxtAmountChanged.ReadOnly = true;
            this.TxtAmountChanged.Size = new System.Drawing.Size(73, 20);
            this.TxtAmountChanged.TabIndex = 59;
            // 
            // TxtDate
            // 
            this.TxtDate.Location = new System.Drawing.Point(460, 448);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.ReadOnly = true;
            this.TxtDate.Size = new System.Drawing.Size(80, 20);
            this.TxtDate.TabIndex = 61;
            this.TxtDate.TextChanged += new System.EventHandler(this.TxtDate_TextChanged);
            // 
            // LblTodayDate
            // 
            this.LblTodayDate.AutoSize = true;
            this.LblTodayDate.Location = new System.Drawing.Point(334, 425);
            this.LblTodayDate.Name = "LblTodayDate";
            this.LblTodayDate.Size = new System.Drawing.Size(120, 13);
            this.LblTodayDate.TabIndex = 62;
            this.LblTodayDate.Text = "Data da movimentação:";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(292, 452);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(162, 13);
            this.LblDate.TabIndex = 64;
            this.LblDate.Text = "Digite a data (somente numeros):";
            // 
            // ChkToday
            // 
            this.ChkToday.AutoSize = true;
            this.ChkToday.Checked = true;
            this.ChkToday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkToday.Location = new System.Drawing.Point(460, 425);
            this.ChkToday.Name = "ChkToday";
            this.ChkToday.Size = new System.Drawing.Size(87, 17);
            this.ChkToday.TabIndex = 65;
            this.ChkToday.Text = "Data de hoje";
            this.ChkToday.UseVisualStyleBackColor = true;
            this.ChkToday.CheckedChanged += new System.EventHandler(this.ChkToday_CheckedChanged);
            // 
            // SupplyMovementMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 508);
            this.Controls.Add(this.ChkToday);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.LblTodayDate);
            this.Controls.Add(this.TxtDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.BtnSelectSupplier);
            this.Controls.Add(this.TxtState);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.TxtPhone);
            this.Controls.Add(this.LblCEP);
            this.Controls.Add(this.TxtCEP);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblCity);
            this.Controls.Add(this.TxtCity);
            this.Controls.Add(this.LblNeigh);
            this.Controls.Add(this.TxtNeigh);
            this.Controls.Add(this.LblComplement);
            this.Controls.Add(this.TxtComplement);
            this.Controls.Add(this.LblNumber);
            this.Controls.Add(this.TxtNumber);
            this.Controls.Add(this.LblStreet);
            this.Controls.Add(this.TxtStreet);
            this.Controls.Add(this.LblSupName);
            this.Controls.Add(this.TxtName);
            this.MaximizeBox = false;
            this.Name = "SupplyMovementMenu";
            this.Text = "Realizar movimentação";
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.ComboBox CmbType;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.Label LblCEP;
        private System.Windows.Forms.TextBox TxtCEP;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Label LblCity;
        private System.Windows.Forms.TextBox TxtCity;
        private System.Windows.Forms.Label LblNeigh;
        private System.Windows.Forms.TextBox TxtNeigh;
        private System.Windows.Forms.Label LblComplement;
        private System.Windows.Forms.TextBox TxtComplement;
        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.TextBox TxtNumber;
        private System.Windows.Forms.Label LblStreet;
        private System.Windows.Forms.TextBox TxtStreet;
        private System.Windows.Forms.Label LblSupName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtState;
        private System.Windows.Forms.Button BtnSelectSupplier;
        private System.Windows.Forms.DataGridView DtProduct;
        private System.Windows.Forms.Label LblQuantity;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Label LblProdName;
        private System.Windows.Forms.TextBox TxtProdName;
        private System.Windows.Forms.Button BtnSelectProducts;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtDate;
        private System.Windows.Forms.Label LblTodayDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.CheckBox ChkToday;
        private System.Windows.Forms.Label LblAmountChanged;
        private System.Windows.Forms.TextBox TxtAmountChanged;
    }
}