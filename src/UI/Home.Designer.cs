﻿namespace Gerenciador_de_estoque
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
            this.dtProduct = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DtMovement)).BeginInit();
            this.pnlButtonBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).BeginInit();
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
            this.DtMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtMovement.Location = new System.Drawing.Point(12, 78);
            this.DtMovement.Name = "DtMovement";
            this.DtMovement.Size = new System.Drawing.Size(302, 328);
            this.DtMovement.TabIndex = 7;
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
            this.TxtSearch.Location = new System.Drawing.Point(12, 52);
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
            // dtProduct
            // 
            this.dtProduct.AllowUserToAddRows = false;
            this.dtProduct.AllowUserToDeleteRows = false;
            this.dtProduct.AllowUserToOrderColumns = true;
            this.dtProduct.AllowUserToResizeRows = false;
            this.dtProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProduct.Location = new System.Drawing.Point(332, 222);
            this.dtProduct.MultiSelect = false;
            this.dtProduct.Name = "dtProduct";
            this.dtProduct.ReadOnly = true;
            this.dtProduct.RowHeadersVisible = false;
            this.dtProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProduct.Size = new System.Drawing.Size(247, 184);
            this.dtProduct.TabIndex = 35;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 418);
            this.Controls.Add(this.dtProduct);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).EndInit();
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
        private System.Windows.Forms.DataGridView dtProduct;
    }
}

