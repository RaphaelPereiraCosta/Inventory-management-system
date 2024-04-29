namespace Gerenciador_de_estoque.src.UI
{
    partial class SupplierMenu
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
            this.LblNumber = new System.Windows.Forms.Label();
            this.TxtNumber = new System.Windows.Forms.TextBox();
            this.LblStreet = new System.Windows.Forms.Label();
            this.TxtStreet = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblComplement = new System.Windows.Forms.Label();
            this.TxtComplement = new System.Windows.Forms.TextBox();
            this.LblNeigh = new System.Windows.Forms.Label();
            this.TxtNeigh = new System.Windows.Forms.TextBox();
            this.LblCity = new System.Windows.Forms.Label();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.LblState = new System.Windows.Forms.Label();
            this.LblCEP = new System.Windows.Forms.Label();
            this.TxtCEP = new System.Windows.Forms.TextBox();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtPhone = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.CmbStates = new System.Windows.Forms.ComboBox();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnGoBack = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.DtSupplier = new System.Windows.Forms.DataGridView();
            this.LblSearch = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // LblNumber
            // 
            this.LblNumber.AutoSize = true;
            this.LblNumber.Location = new System.Drawing.Point(241, 83);
            this.LblNumber.Name = "LblNumber";
            this.LblNumber.Size = new System.Drawing.Size(44, 13);
            this.LblNumber.TabIndex = 14;
            this.LblNumber.Text = "Numero";
            // 
            // TxtNumber
            // 
            this.TxtNumber.Location = new System.Drawing.Point(244, 99);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Size = new System.Drawing.Size(59, 20);
            this.TxtNumber.TabIndex = 13;
            this.TxtNumber.TextChanged += new System.EventHandler(this.TxtNumber_TextChanged);
            // 
            // LblStreet
            // 
            this.LblStreet.AutoSize = true;
            this.LblStreet.Location = new System.Drawing.Point(23, 83);
            this.LblStreet.Name = "LblStreet";
            this.LblStreet.Size = new System.Drawing.Size(27, 13);
            this.LblStreet.TabIndex = 12;
            this.LblStreet.Text = "Rua";
            // 
            // TxtStreet
            // 
            this.TxtStreet.Location = new System.Drawing.Point(26, 99);
            this.TxtStreet.Name = "TxtStreet";
            this.TxtStreet.Size = new System.Drawing.Size(212, 20);
            this.TxtStreet.TabIndex = 11;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(23, 41);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 10;
            this.LblName.Text = "Nome";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(26, 57);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(319, 20);
            this.TxtName.TabIndex = 9;
            // 
            // LblComplement
            // 
            this.LblComplement.AutoSize = true;
            this.LblComplement.Location = new System.Drawing.Point(23, 134);
            this.LblComplement.Name = "LblComplement";
            this.LblComplement.Size = new System.Drawing.Size(71, 13);
            this.LblComplement.TabIndex = 16;
            this.LblComplement.Text = "Complemento";
            // 
            // TxtComplement
            // 
            this.TxtComplement.Location = new System.Drawing.Point(26, 150);
            this.TxtComplement.Name = "TxtComplement";
            this.TxtComplement.Size = new System.Drawing.Size(149, 20);
            this.TxtComplement.TabIndex = 15;
            // 
            // LblNeigh
            // 
            this.LblNeigh.AutoSize = true;
            this.LblNeigh.Location = new System.Drawing.Point(189, 134);
            this.LblNeigh.Name = "LblNeigh";
            this.LblNeigh.Size = new System.Drawing.Size(34, 13);
            this.LblNeigh.TabIndex = 18;
            this.LblNeigh.Text = "Bairro";
            // 
            // TxtNeigh
            // 
            this.TxtNeigh.Location = new System.Drawing.Point(192, 150);
            this.TxtNeigh.Name = "TxtNeigh";
            this.TxtNeigh.Size = new System.Drawing.Size(153, 20);
            this.TxtNeigh.TabIndex = 17;
            // 
            // LblCity
            // 
            this.LblCity.AutoSize = true;
            this.LblCity.Location = new System.Drawing.Point(23, 185);
            this.LblCity.Name = "LblCity";
            this.LblCity.Size = new System.Drawing.Size(40, 13);
            this.LblCity.TabIndex = 20;
            this.LblCity.Text = "Cidade";
            // 
            // TxtCity
            // 
            this.TxtCity.Location = new System.Drawing.Point(26, 201);
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.Size = new System.Drawing.Size(134, 20);
            this.TxtCity.TabIndex = 19;
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Location = new System.Drawing.Point(176, 185);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(40, 13);
            this.LblState.TabIndex = 22;
            this.LblState.Text = "Estado";
            // 
            // LblCEP
            // 
            this.LblCEP.AutoSize = true;
            this.LblCEP.Location = new System.Drawing.Point(23, 244);
            this.LblCEP.Name = "LblCEP";
            this.LblCEP.Size = new System.Drawing.Size(28, 13);
            this.LblCEP.TabIndex = 24;
            this.LblCEP.Text = "CEP";
            // 
            // TxtCEP
            // 
            this.TxtCEP.Location = new System.Drawing.Point(26, 260);
            this.TxtCEP.Name = "TxtCEP";
            this.TxtCEP.Size = new System.Drawing.Size(140, 20);
            this.TxtCEP.TabIndex = 23;
            this.TxtCEP.TextChanged += new System.EventHandler(this.TxtCEP_TextChanged);
            // 
            // LblPhone
            // 
            this.LblPhone.AutoSize = true;
            this.LblPhone.Location = new System.Drawing.Point(189, 244);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(49, 13);
            this.LblPhone.TabIndex = 26;
            this.LblPhone.Text = "Telefone";
            // 
            // TxtPhone
            // 
            this.TxtPhone.Location = new System.Drawing.Point(192, 260);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Size = new System.Drawing.Size(134, 20);
            this.TxtPhone.TabIndex = 25;
            this.TxtPhone.TextChanged += new System.EventHandler(this.TxtPhone_TextChanged);
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(23, 296);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(35, 13);
            this.LblEmail.TabIndex = 28;
            this.LblEmail.Text = "E-mail";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(26, 312);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(190, 20);
            this.TxtEmail.TabIndex = 27;
            // 
            // CmbStates
            // 
            this.CmbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStates.FormattingEnabled = true;
            this.CmbStates.Location = new System.Drawing.Point(179, 199);
            this.CmbStates.Name = "CmbStates";
            this.CmbStates.Size = new System.Drawing.Size(124, 21);
            this.CmbStates.TabIndex = 29;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(127, 357);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 34;
            this.BtnEdit.Text = "Editar";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnGoBack
            // 
            this.BtnGoBack.Location = new System.Drawing.Point(46, 386);
            this.BtnGoBack.Name = "BtnGoBack";
            this.BtnGoBack.Size = new System.Drawing.Size(156, 23);
            this.BtnGoBack.TabIndex = 33;
            this.BtnGoBack.Text = "Voltar";
            this.BtnGoBack.UseVisualStyleBackColor = true;
            this.BtnGoBack.Click += new System.EventHandler(this.BtnGoBack_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(46, 357);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 32;
            this.BtnNew.Text = "Novo";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(127, 357);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 31;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(46, 357);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 30;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // DtSupplier
            // 
            this.DtSupplier.AllowUserToAddRows = false;
            this.DtSupplier.AllowUserToDeleteRows = false;
            this.DtSupplier.AllowUserToOrderColumns = true;
            this.DtSupplier.AllowUserToResizeRows = false;
            this.DtSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtSupplier.Location = new System.Drawing.Point(392, 83);
            this.DtSupplier.MultiSelect = false;
            this.DtSupplier.Name = "DtSupplier";
            this.DtSupplier.ReadOnly = true;
            this.DtSupplier.RowHeadersVisible = false;
            this.DtSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtSupplier.Size = new System.Drawing.Size(362, 326);
            this.DtSupplier.TabIndex = 36;
            this.DtSupplier.SelectionChanged += new System.EventHandler(this.DtSupplier_SelectionChanged);
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Location = new System.Drawing.Point(389, 41);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(144, 13);
            this.LblSearch.TabIndex = 38;
            this.LblSearch.Text = "Buscar (nome do fornecedor)";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(392, 57);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(244, 20);
            this.TxtSearch.TabIndex = 37;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(123, 357);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(180, 45);
            this.BtnSelect.TabIndex = 64;
            this.BtnSelect.Text = "Selecionar";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // SupplierMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.LblSearch);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.DtSupplier);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnGoBack);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CmbStates);
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
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtName);
            this.MaximizeBox = false;
            this.Name = "SupplierMenu";
            this.Text = "Menu de Fornecedor";
            ((System.ComponentModel.ISupportInitialize)(this.DtSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNumber;
        private System.Windows.Forms.TextBox TxtNumber;
        private System.Windows.Forms.Label LblStreet;
        private System.Windows.Forms.TextBox TxtStreet;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblComplement;
        private System.Windows.Forms.TextBox TxtComplement;
        private System.Windows.Forms.Label LblNeigh;
        private System.Windows.Forms.TextBox TxtNeigh;
        private System.Windows.Forms.Label LblCity;
        private System.Windows.Forms.TextBox TxtCity;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Label LblCEP;
        private System.Windows.Forms.TextBox TxtCEP;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.ComboBox CmbStates;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnGoBack;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView DtSupplier;
        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnSelect;
    }
}