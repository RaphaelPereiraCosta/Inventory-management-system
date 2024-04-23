namespace Gerenciador_de_estoque
{
    partial class Home
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProductBtn = new System.Windows.Forms.Button();
            this.btnSupplierMenu = new System.Windows.Forms.Button();
            this.BtnSupplyMovementMenu = new System.Windows.Forms.Button();
            this.DtMovement = new System.Windows.Forms.DataGridView();
            this.pnlButtonBox = new System.Windows.Forms.Panel();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblPhone = new System.Windows.Forms.Label();
            this.TxtPhone = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.DtProduct = new System.Windows.Forms.DataGridView();
            this.LblProducts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtMovement)).BeginInit();
            this.pnlButtonBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductBtn
            // 
            this.ProductBtn.Location = new System.Drawing.Point(33, 18);
            this.ProductBtn.Name = "ProductBtn";
            this.ProductBtn.Size = new System.Drawing.Size(136, 48);
            this.ProductBtn.TabIndex = 0;
            this.ProductBtn.Text = "Gerenciar produtos";
            this.ProductBtn.UseVisualStyleBackColor = true;
            this.ProductBtn.Click += new System.EventHandler(this.BtnProductMenu_Click);
            // 
            // btnSupplierMenu
            // 
            this.btnSupplierMenu.Location = new System.Drawing.Point(33, 85);
            this.btnSupplierMenu.Name = "btnSupplierMenu";
            this.btnSupplierMenu.Size = new System.Drawing.Size(136, 48);
            this.btnSupplierMenu.TabIndex = 1;
            this.btnSupplierMenu.Text = "Gerenciar fornecedores";
            this.btnSupplierMenu.UseVisualStyleBackColor = true;
            this.btnSupplierMenu.Click += new System.EventHandler(this.BtnSupplierMenu_Click);
            // 
            // BtnSupplyMovementMenu
            // 
            this.BtnSupplyMovementMenu.Location = new System.Drawing.Point(33, 148);
            this.BtnSupplyMovementMenu.Name = "BtnSupplyMovementMenu";
            this.BtnSupplyMovementMenu.Size = new System.Drawing.Size(136, 48);
            this.BtnSupplyMovementMenu.TabIndex = 6;
            this.BtnSupplyMovementMenu.Text = "Nova Movimentação";
            this.BtnSupplyMovementMenu.UseVisualStyleBackColor = true;
            this.BtnSupplyMovementMenu.Click += new System.EventHandler(this.BtnSupplyMovementMenu_Click);
            // 
            // DtMovement
            // 
            this.DtMovement.AllowUserToAddRows = false;
            this.DtMovement.AllowUserToDeleteRows = false;
            this.DtMovement.AllowUserToOrderColumns = true;
            this.DtMovement.AllowUserToResizeRows = false;
            this.DtMovement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtMovement.Location = new System.Drawing.Point(12, 98);
            this.DtMovement.MultiSelect = false;
            this.DtMovement.Name = "DtMovement";
            this.DtMovement.ReadOnly = true;
            this.DtMovement.RowHeadersVisible = false;
            this.DtMovement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtMovement.Size = new System.Drawing.Size(302, 338);
            this.DtMovement.TabIndex = 7;
            this.DtMovement.SelectionChanged += new System.EventHandler(this.DtMovement_SelectionChanged);
            // 
            // pnlButtonBox
            // 
            this.pnlButtonBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtonBox.Controls.Add(this.ProductBtn);
            this.pnlButtonBox.Controls.Add(this.btnSupplierMenu);
            this.pnlButtonBox.Controls.Add(this.BtnSupplyMovementMenu);
            this.pnlButtonBox.Location = new System.Drawing.Point(615, 102);
            this.pnlButtonBox.Name = "pnlButtonBox";
            this.pnlButtonBox.Size = new System.Drawing.Size(200, 215);
            this.pnlButtonBox.TabIndex = 8;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(12, 72);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(165, 20);
            this.TxtSearch.TabIndex = 14;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Location = new System.Drawing.Point(329, 128);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(35, 13);
            this.LblEmail.TabIndex = 34;
            this.LblEmail.Text = "E-mail";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(332, 144);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.ReadOnly = true;
            this.TxtEmail.Size = new System.Drawing.Size(190, 20);
            this.TxtEmail.TabIndex = 33;
            // 
            // LblPhone
            // 
            this.LblPhone.AutoSize = true;
            this.LblPhone.Location = new System.Drawing.Point(329, 173);
            this.LblPhone.Name = "LblPhone";
            this.LblPhone.Size = new System.Drawing.Size(49, 13);
            this.LblPhone.TabIndex = 32;
            this.LblPhone.Text = "Telefone";
            // 
            // TxtPhone
            // 
            this.TxtPhone.Location = new System.Drawing.Point(332, 189);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.ReadOnly = true;
            this.TxtPhone.Size = new System.Drawing.Size(134, 20);
            this.TxtPhone.TabIndex = 31;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(329, 82);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 30;
            this.LblName.Text = "Nome";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(332, 98);
            this.TxtName.Name = "TxtName";
            this.TxtName.ReadOnly = true;
            this.TxtName.Size = new System.Drawing.Size(225, 20);
            this.TxtName.TabIndex = 29;
            // 
            // DtProduct
            // 
            this.DtProduct.AllowUserToAddRows = false;
            this.DtProduct.AllowUserToDeleteRows = false;
            this.DtProduct.AllowUserToOrderColumns = true;
            this.DtProduct.AllowUserToResizeRows = false;
            this.DtProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtProduct.Location = new System.Drawing.Point(332, 252);
            this.DtProduct.MultiSelect = false;
            this.DtProduct.Name = "DtProduct";
            this.DtProduct.ReadOnly = true;
            this.DtProduct.RowHeadersVisible = false;
            this.DtProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtProduct.Size = new System.Drawing.Size(247, 184);
            this.DtProduct.TabIndex = 35;
            // 
            // LblProducts
            // 
            this.LblProducts.AutoSize = true;
            this.LblProducts.Location = new System.Drawing.Point(329, 236);
            this.LblProducts.Name = "LblProducts";
            this.LblProducts.Size = new System.Drawing.Size(82, 13);
            this.LblProducts.TabIndex = 36;
            this.LblProducts.Text = "Movimentações";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 446);
            this.Controls.Add(this.LblProducts);
            this.Controls.Add(this.DtProduct);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.LblPhone);
            this.Controls.Add(this.TxtPhone);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.pnlButtonBox);
            this.Controls.Add(this.DtMovement);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Historico de movimentações";
            ((System.ComponentModel.ISupportInitialize)(this.DtMovement)).EndInit();
            this.pnlButtonBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ProductBtn;
        private System.Windows.Forms.Button btnSupplierMenu;
        private System.Windows.Forms.Button BtnSupplyMovementMenu;
        private System.Windows.Forms.DataGridView DtMovement;
        private System.Windows.Forms.Panel pnlButtonBox;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblPhone;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.DataGridView DtProduct;
        private System.Windows.Forms.Label LblProducts;
    }
}

