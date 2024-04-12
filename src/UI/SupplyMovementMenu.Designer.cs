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
            this.lblType = new System.Windows.Forms.Label();
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblNeigh = new System.Windows.Forms.Label();
            this.txtNeigh = new System.Windows.Forms.TextBox();
            this.lblComplement = new System.Windows.Forms.Label();
            this.txtComplement = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblSupName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.BtnSelectSupplier = new System.Windows.Forms.Button();
            this.DtProduct = new System.Windows.Forms.DataGridView();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblProdName = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.BtnSelectProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(417, 205);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(98, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Movimentação de: ";
            // 
            // CmbType
            // 
            this.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(521, 202);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(121, 21);
            this.CmbType.TabIndex = 4;
            this.CmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(347, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 48;
            this.lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(350, 76);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(190, 20);
            this.txtEmail.TabIndex = 47;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(543, 60);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 13);
            this.lblPhone.TabIndex = 46;
            this.lblPhone.Text = "Telefone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(546, 76);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(134, 20);
            this.txtPhone.TabIndex = 45;
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(683, 60);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(28, 13);
            this.lblCEP.TabIndex = 44;
            this.lblCEP.Text = "CEP";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(686, 76);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.ReadOnly = true;
            this.txtCEP.Size = new System.Drawing.Size(140, 20);
            this.txtCEP.TabIndex = 43;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(761, 111);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(40, 13);
            this.lblState.TabIndex = 42;
            this.lblState.Text = "Estado";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(621, 111);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(40, 13);
            this.lblCity.TabIndex = 41;
            this.lblCity.Text = "Cidade";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(624, 127);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(134, 20);
            this.txtCity.TabIndex = 40;
            // 
            // lblNeigh
            // 
            this.lblNeigh.AutoSize = true;
            this.lblNeigh.Location = new System.Drawing.Point(462, 111);
            this.lblNeigh.Name = "lblNeigh";
            this.lblNeigh.Size = new System.Drawing.Size(34, 13);
            this.lblNeigh.TabIndex = 39;
            this.lblNeigh.Text = "Bairro";
            // 
            // txtNeigh
            // 
            this.txtNeigh.Location = new System.Drawing.Point(465, 127);
            this.txtNeigh.Name = "txtNeigh";
            this.txtNeigh.ReadOnly = true;
            this.txtNeigh.Size = new System.Drawing.Size(153, 20);
            this.txtNeigh.TabIndex = 38;
            // 
            // lblComplement
            // 
            this.lblComplement.AutoSize = true;
            this.lblComplement.Location = new System.Drawing.Point(307, 111);
            this.lblComplement.Name = "lblComplement";
            this.lblComplement.Size = new System.Drawing.Size(71, 13);
            this.lblComplement.TabIndex = 37;
            this.lblComplement.Text = "Complemento";
            // 
            // txtComplement
            // 
            this.txtComplement.Location = new System.Drawing.Point(310, 127);
            this.txtComplement.Name = "txtComplement";
            this.txtComplement.ReadOnly = true;
            this.txtComplement.Size = new System.Drawing.Size(149, 20);
            this.txtComplement.TabIndex = 36;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(240, 111);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 35;
            this.lblNumber.Text = "Numero";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(243, 127);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(59, 20);
            this.txtNumber.TabIndex = 34;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(22, 111);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(27, 13);
            this.lblStreet.TabIndex = 33;
            this.lblStreet.Text = "Rua";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(25, 127);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.ReadOnly = true;
            this.txtStreet.Size = new System.Drawing.Size(212, 20);
            this.txtStreet.TabIndex = 32;
            // 
            // lblSupName
            // 
            this.lblSupName.AutoSize = true;
            this.lblSupName.Location = new System.Drawing.Point(22, 60);
            this.lblSupName.Name = "lblSupName";
            this.lblSupName.Size = new System.Drawing.Size(104, 13);
            this.lblSupName.TabIndex = 31;
            this.lblSupName.Text = "Nome do fornecedor";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(25, 76);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(319, 20);
            this.txtName.TabIndex = 30;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(764, 127);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(80, 20);
            this.txtState.TabIndex = 49;
            // 
            // BtnSelectSupplier
            // 
            this.BtnSelectSupplier.Location = new System.Drawing.Point(356, 22);
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
            this.DtProduct.Location = new System.Drawing.Point(349, 231);
            this.DtProduct.MultiSelect = false;
            this.DtProduct.Name = "DtProduct";
            this.DtProduct.ReadOnly = true;
            this.DtProduct.RowHeadersVisible = false;
            this.DtProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtProduct.Size = new System.Drawing.Size(362, 179);
            this.DtProduct.TabIndex = 51;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(78, 264);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 13);
            this.lblQuantity.TabIndex = 57;
            this.lblQuantity.Text = "Quantidade";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(81, 280);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(73, 20);
            this.txtQuantity.TabIndex = 56;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(78, 314);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(55, 13);
            this.lblDescription.TabIndex = 55;
            this.lblDescription.Text = "Descrição";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 330);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(237, 81);
            this.txtDescription.TabIndex = 54;
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Location = new System.Drawing.Point(78, 215);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(35, 13);
            this.lblProdName.TabIndex = 53;
            this.lblProdName.Text = "Nome";
            // 
            // txtProdName
            // 
            this.txtProdName.Location = new System.Drawing.Point(81, 231);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.ReadOnly = true;
            this.txtProdName.Size = new System.Drawing.Size(142, 20);
            this.txtProdName.TabIndex = 52;
            // 
            // BtnSelectProducts
            // 
            this.BtnSelectProducts.Location = new System.Drawing.Point(356, 167);
            this.BtnSelectProducts.Name = "BtnSelectProducts";
            this.BtnSelectProducts.Size = new System.Drawing.Size(140, 23);
            this.BtnSelectProducts.TabIndex = 58;
            this.BtnSelectProducts.Text = "Selecionar produtos";
            this.BtnSelectProducts.UseVisualStyleBackColor = true;
            this.BtnSelectProducts.Click += new System.EventHandler(this.BtnSelectProducts_Click);
            // 
            // SupplyMovementMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 474);
            this.Controls.Add(this.BtnSelectProducts);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblProdName);
            this.Controls.Add(this.txtProdName);
            this.Controls.Add(this.DtProduct);
            this.Controls.Add(this.BtnSelectSupplier);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblCEP);
            this.Controls.Add(this.txtCEP);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblNeigh);
            this.Controls.Add(this.txtNeigh);
            this.Controls.Add(this.lblComplement);
            this.Controls.Add(this.txtComplement);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.lblSupName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.CmbType);
            this.MaximizeBox = false;
            this.Name = "SupplyMovementMenu";
            this.Text = "Movimentação";
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox CmbType;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblNeigh;
        private System.Windows.Forms.TextBox txtNeigh;
        private System.Windows.Forms.Label lblComplement;
        private System.Windows.Forms.TextBox txtComplement;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblSupName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Button BtnSelectSupplier;
        private System.Windows.Forms.DataGridView DtProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.Button BtnSelectProducts;
    }
}