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
            this.SuspendLayout();
            // 
            // ProductBtn
            // 
            this.ProductBtn.Location = new System.Drawing.Point(167, 31);
            this.ProductBtn.Name = "ProductBtn";
            this.ProductBtn.Size = new System.Drawing.Size(136, 48);
            this.ProductBtn.TabIndex = 0;
            this.ProductBtn.Text = "Produtos";
            this.ProductBtn.UseVisualStyleBackColor = true;
            this.ProductBtn.Click += new System.EventHandler(this.ProductBtn_Click);
            // 
            // btnSupplierMenu
            // 
            this.btnSupplierMenu.Location = new System.Drawing.Point(371, 31);
            this.btnSupplierMenu.Name = "btnSupplierMenu";
            this.btnSupplierMenu.Size = new System.Drawing.Size(136, 48);
            this.btnSupplierMenu.TabIndex = 1;
            this.btnSupplierMenu.Text = "Fornecedores";
            this.btnSupplierMenu.UseVisualStyleBackColor = true;
            this.btnSupplierMenu.Click += new System.EventHandler(this.btnSupplierMenu_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSupplierMenu);
            this.Controls.Add(this.ProductBtn);
            this.Name = "Home";
            this.Text = "Historico de transações";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProductBtn;
        private System.Windows.Forms.Button btnSupplierMenu;
    }
}

