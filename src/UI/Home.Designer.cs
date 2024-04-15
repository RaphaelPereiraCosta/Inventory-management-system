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
            this.SuspendLayout();
            // 
            // ProductBtn
            // 
            this.ProductBtn.Location = new System.Drawing.Point(593, 96);
            this.ProductBtn.Name = "ProductBtn";
            this.ProductBtn.Size = new System.Drawing.Size(136, 48);
            this.ProductBtn.TabIndex = 0;
            this.ProductBtn.Text = "Produtos";
            this.ProductBtn.UseVisualStyleBackColor = true;
            this.ProductBtn.Click += new System.EventHandler(this.BtnProductMenu_Click);
            // 
            // btnSupplierMenu
            // 
            this.btnSupplierMenu.Location = new System.Drawing.Point(593, 173);
            this.btnSupplierMenu.Name = "btnSupplierMenu";
            this.btnSupplierMenu.Size = new System.Drawing.Size(136, 48);
            this.btnSupplierMenu.TabIndex = 1;
            this.btnSupplierMenu.Text = "Fornecedores";
            this.btnSupplierMenu.UseVisualStyleBackColor = true;
            this.btnSupplierMenu.Click += new System.EventHandler(this.BtnSupplierMenu_Click);
            // 
            // BtnSupplyMovementMenu
            // 
            this.BtnSupplyMovementMenu.Location = new System.Drawing.Point(593, 245);
            this.BtnSupplyMovementMenu.Name = "BtnSupplyMovementMenu";
            this.BtnSupplyMovementMenu.Size = new System.Drawing.Size(136, 48);
            this.BtnSupplyMovementMenu.TabIndex = 6;
            this.BtnSupplyMovementMenu.Text = "Nova Movimentação";
            this.BtnSupplyMovementMenu.UseVisualStyleBackColor = true;
            this.BtnSupplyMovementMenu.Click += new System.EventHandler(this.BtnSupplyMovementMenu_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSupplyMovementMenu);
            this.Controls.Add(this.btnSupplierMenu);
            this.Controls.Add(this.ProductBtn);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Movimentações";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProductBtn;
        private System.Windows.Forms.Button btnSupplierMenu;
        private System.Windows.Forms.Button BtnSupplyMovementMenu;
    }
}

