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
            ((System.ComponentModel.ISupportInitialize)(this.DtMovement)).BeginInit();
            this.pnlButtonBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductBtn
            // 
            this.ProductBtn.Location = new System.Drawing.Point(33, 18);
            this.ProductBtn.Name = "ProductBtn";
            this.ProductBtn.Size = new System.Drawing.Size(136, 48);
            this.ProductBtn.TabIndex = 0;
            this.ProductBtn.Text = "Produtos";
            this.ProductBtn.UseVisualStyleBackColor = true;
            this.ProductBtn.Click += new System.EventHandler(this.BtnProductMenu_Click);
            // 
            // btnSupplierMenu
            // 
            this.btnSupplierMenu.Location = new System.Drawing.Point(33, 85);
            this.btnSupplierMenu.Name = "btnSupplierMenu";
            this.btnSupplierMenu.Size = new System.Drawing.Size(136, 48);
            this.btnSupplierMenu.TabIndex = 1;
            this.btnSupplierMenu.Text = "Fornecedores";
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
            this.DtMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtMovement.Location = new System.Drawing.Point(34, 63);
            this.DtMovement.Name = "DtMovement";
            this.DtMovement.Size = new System.Drawing.Size(302, 282);
            this.DtMovement.TabIndex = 7;
            // 
            // pnlButtonBox
            // 
            this.pnlButtonBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtonBox.Controls.Add(this.ProductBtn);
            this.pnlButtonBox.Controls.Add(this.btnSupplierMenu);
            this.pnlButtonBox.Controls.Add(this.BtnSupplyMovementMenu);
            this.pnlButtonBox.Location = new System.Drawing.Point(391, 93);
            this.pnlButtonBox.Name = "pnlButtonBox";
            this.pnlButtonBox.Size = new System.Drawing.Size(200, 215);
            this.pnlButtonBox.TabIndex = 8;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(34, 37);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(165, 20);
            this.TxtSearch.TabIndex = 14;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 370);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.pnlButtonBox);
            this.Controls.Add(this.DtMovement);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Movimentações";
            ((System.ComponentModel.ISupportInitialize)(this.DtMovement)).EndInit();
            this.pnlButtonBox.ResumeLayout(false);
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
    }
}

