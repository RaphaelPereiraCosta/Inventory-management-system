namespace Gerenciador_de_estoque.src.UI
{
    partial class ProductMenu
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
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.LblQuantity = new System.Windows.Forms.Label();
            this.DtProduct = new System.Windows.Forms.DataGridView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.LblSearch = new System.Windows.Forms.Label();
            this.BtnGoBack = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(21, 41);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(142, 20);
            this.TxtName.TabIndex = 0;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(18, 25);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Nome";
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(18, 124);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(55, 13);
            this.LblDescription.TabIndex = 6;
            this.LblDescription.Text = "Descrição";
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(21, 140);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(237, 174);
            this.TxtDescription.TabIndex = 5;
            // 
            // LblQuantity
            // 
            this.LblQuantity.AutoSize = true;
            this.LblQuantity.Location = new System.Drawing.Point(18, 74);
            this.LblQuantity.Name = "LblQuantity";
            this.LblQuantity.Size = new System.Drawing.Size(62, 13);
            this.LblQuantity.TabIndex = 8;
            this.LblQuantity.Text = "Quantidade";
            // 
            // DtProduct
            // 
            this.DtProduct.AllowUserToAddRows = false;
            this.DtProduct.AllowUserToDeleteRows = false;
            this.DtProduct.AllowUserToOrderColumns = true;
            this.DtProduct.AllowUserToResizeRows = false;
            this.DtProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtProduct.Location = new System.Drawing.Point(360, 67);
            this.DtProduct.MultiSelect = false;
            this.DtProduct.Name = "DtProduct";
            this.DtProduct.ReadOnly = true;
            this.DtProduct.RowHeadersVisible = false;
            this.DtProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtProduct.Size = new System.Drawing.Size(401, 305);
            this.DtProduct.TabIndex = 9;
            this.DtProduct.SelectionChanged += new System.EventHandler(this.DtProduct_SelectionChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(66, 320);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Salvar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(147, 320);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(66, 320);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 12;
            this.BtnNew.Text = "Novo";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(360, 41);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(244, 20);
            this.TxtSearch.TabIndex = 13;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Location = new System.Drawing.Point(357, 25);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(129, 13);
            this.LblSearch.TabIndex = 14;
            this.LblSearch.Text = "Buscar (nome do produto)";
            // 
            // BtnGoBack
            // 
            this.BtnGoBack.Location = new System.Drawing.Point(52, 369);
            this.BtnGoBack.Name = "BtnGoBack";
            this.BtnGoBack.Size = new System.Drawing.Size(156, 23);
            this.BtnGoBack.TabIndex = 15;
            this.BtnGoBack.Text = "Voltar";
            this.BtnGoBack.UseVisualStyleBackColor = true;
            this.BtnGoBack.Click += new System.EventHandler(this.BtnGoBack_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(147, 320);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 16;
            this.BtnEdit.Text = "Editar";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(21, 90);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(73, 20);
            this.TxtAmount.TabIndex = 7;
            this.TxtAmount.TextChanged += new System.EventHandler(this.TxtAmount_TextChanged);
            // 
            // ProductMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(787, 404);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnGoBack);
            this.Controls.Add(this.LblSearch);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.DtProduct);
            this.Controls.Add(this.LblQuantity);
            this.Controls.Add(this.TxtAmount);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtName);
            this.MaximizeBox = false;
            this.Name = "ProductMenu";
            this.Text = "Menu de produtos";
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Label LblQuantity;
        private System.Windows.Forms.DataGridView DtProduct;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.Button BtnGoBack;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.TextBox TxtAmount;
    }
}