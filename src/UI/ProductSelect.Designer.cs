namespace Gerenciador_de_estoque.src.UI
{
    partial class ProductSelect
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
            this.LblSearch = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.DtProduct = new System.Windows.Forms.DataGridView();
            this.LblAvalQuantity = new System.Windows.Forms.Label();
            this.TxtAvaQuantity = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DtAdded = new System.Windows.Forms.DataGridView();
            this.LblDescription = new System.Windows.Forms.Label();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtAdded)).BeginInit();
            this.SuspendLayout();
            // 
            // LblSearch
            // 
            this.LblSearch.AutoSize = true;
            this.LblSearch.Location = new System.Drawing.Point(9, 30);
            this.LblSearch.Name = "LblSearch";
            this.LblSearch.Size = new System.Drawing.Size(129, 13);
            this.LblSearch.TabIndex = 17;
            this.LblSearch.Text = "Buscar (nome do produto)";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(12, 46);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(244, 20);
            this.TxtSearch.TabIndex = 16;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
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
            this.DtProduct.Location = new System.Drawing.Point(12, 72);
            this.DtProduct.Name = "DtProduct";
            this.DtProduct.ReadOnly = true;
            this.DtProduct.RowHeadersVisible = false;
            this.DtProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtProduct.Size = new System.Drawing.Size(244, 305);
            this.DtProduct.TabIndex = 15;
            this.DtProduct.SelectionChanged += new System.EventHandler(this.DtProduct_SelectionChanged);
            // 
            // LblAvalQuantity
            // 
            this.LblAvalQuantity.AutoSize = true;
            this.LblAvalQuantity.Location = new System.Drawing.Point(301, 171);
            this.LblAvalQuantity.Name = "LblAvalQuantity";
            this.LblAvalQuantity.Size = new System.Drawing.Size(114, 13);
            this.LblAvalQuantity.TabIndex = 23;
            this.LblAvalQuantity.Text = "Quantidade Disponivel";
            // 
            // TxtAvaQuantity
            // 
            this.TxtAvaQuantity.Location = new System.Drawing.Point(304, 187);
            this.TxtAvaQuantity.Name = "TxtAvaQuantity";
            this.TxtAvaQuantity.ReadOnly = true;
            this.TxtAvaQuantity.Size = new System.Drawing.Size(73, 20);
            this.TxtAvaQuantity.TabIndex = 22;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(301, 122);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 19;
            this.LblName.Text = "Nome";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(304, 138);
            this.TxtName.Name = "TxtName";
            this.TxtName.ReadOnly = true;
            this.TxtName.Size = new System.Drawing.Size(142, 20);
            this.TxtName.TabIndex = 18;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(304, 72);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(171, 35);
            this.BtnAdd.TabIndex = 24;
            this.BtnAdd.Text = "Listar";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DtAdded
            // 
            this.DtAdded.AllowUserToAddRows = false;
            this.DtAdded.AllowUserToDeleteRows = false;
            this.DtAdded.AllowUserToOrderColumns = true;
            this.DtAdded.AllowUserToResizeColumns = false;
            this.DtAdded.AllowUserToResizeRows = false;
            this.DtAdded.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtAdded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtAdded.Location = new System.Drawing.Point(544, 72);
            this.DtAdded.Name = "DtAdded";
            this.DtAdded.ReadOnly = true;
            this.DtAdded.RowHeadersVisible = false;
            this.DtAdded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtAdded.Size = new System.Drawing.Size(244, 305);
            this.DtAdded.TabIndex = 25;
            this.DtAdded.SelectionChanged += new System.EventHandler(this.DtAdded_SelectionChanged);
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(301, 220);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(55, 13);
            this.LblDescription.TabIndex = 27;
            this.LblDescription.Text = "Descrição";
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(304, 236);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.ReadOnly = true;
            this.TxtDescription.Size = new System.Drawing.Size(171, 65);
            this.TxtDescription.TabIndex = 26;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(304, 328);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(171, 35);
            this.BtnRemove.TabIndex = 28;
            this.BtnRemove.Text = "Remover da lista";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(304, 403);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(171, 35);
            this.BtnConfirm.TabIndex = 29;
            this.BtnConfirm.Text = "Confirmar";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // ProductSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.DtAdded);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblAvalQuantity);
            this.Controls.Add(this.TxtAvaQuantity);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblSearch);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.DtProduct);
            this.Name = "ProductSelect";
            this.Text = "Selecão de produto";
            ((System.ComponentModel.ISupportInitialize)(this.DtProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtAdded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSearch;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.DataGridView DtProduct;
        private System.Windows.Forms.Label LblAvalQuantity;
        private System.Windows.Forms.TextBox TxtAvaQuantity;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView DtAdded;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnConfirm;
    }
}