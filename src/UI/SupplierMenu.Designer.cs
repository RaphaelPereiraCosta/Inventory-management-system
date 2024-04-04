﻿namespace Gerenciador_de_estoque.UI
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
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblComplement = new System.Windows.Forms.Label();
            this.txtComplement = new System.Windows.Forms.TextBox();
            this.lblNeigh = new System.Windows.Forms.Label();
            this.txtNeigh = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbStates = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtSupplier = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(241, 83);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 14;
            this.lblNumber.Text = "Numero";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(244, 99);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(59, 20);
            this.txtNumber.TabIndex = 13;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(23, 83);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(27, 13);
            this.lblStreet.TabIndex = 12;
            this.lblStreet.Text = "Rua";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(26, 99);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(212, 20);
            this.txtStreet.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Nome";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(26, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(354, 20);
            this.txtName.TabIndex = 9;
            // 
            // lblComplement
            // 
            this.lblComplement.AutoSize = true;
            this.lblComplement.Location = new System.Drawing.Point(309, 83);
            this.lblComplement.Name = "lblComplement";
            this.lblComplement.Size = new System.Drawing.Size(71, 13);
            this.lblComplement.TabIndex = 16;
            this.lblComplement.Text = "Complemento";
            // 
            // txtComplement
            // 
            this.txtComplement.Location = new System.Drawing.Point(312, 99);
            this.txtComplement.Name = "txtComplement";
            this.txtComplement.Size = new System.Drawing.Size(149, 20);
            this.txtComplement.TabIndex = 15;
            // 
            // lblNeigh
            // 
            this.lblNeigh.AutoSize = true;
            this.lblNeigh.Location = new System.Drawing.Point(23, 133);
            this.lblNeigh.Name = "lblNeigh";
            this.lblNeigh.Size = new System.Drawing.Size(34, 13);
            this.lblNeigh.TabIndex = 18;
            this.lblNeigh.Text = "Bairro";
            // 
            // txtNeigh
            // 
            this.txtNeigh.Location = new System.Drawing.Point(26, 149);
            this.txtNeigh.Name = "txtNeigh";
            this.txtNeigh.Size = new System.Drawing.Size(158, 20);
            this.txtNeigh.TabIndex = 17;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(189, 133);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(40, 13);
            this.lblCity.TabIndex = 20;
            this.lblCity.Text = "Cidade";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(192, 149);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(134, 20);
            this.txtCity.TabIndex = 19;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(342, 133);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(40, 13);
            this.lblState.TabIndex = 22;
            this.lblState.Text = "Estado";
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(23, 181);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(28, 13);
            this.lblCEP.TabIndex = 24;
            this.lblCEP.Text = "CEP";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(26, 197);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(158, 20);
            this.txtCEP.TabIndex = 23;
            this.txtCEP.TextChanged += new System.EventHandler(this.txtCEP_TextChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(189, 181);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 13);
            this.lblPhone.TabIndex = 26;
            this.lblPhone.Text = "Telefone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(192, 197);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(134, 20);
            this.txtPhone.TabIndex = 25;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(342, 181);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(345, 197);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(116, 20);
            this.txtEmail.TabIndex = 27;
            // 
            // cmbStates
            // 
            this.cmbStates.FormattingEnabled = true;
            this.cmbStates.Location = new System.Drawing.Point(345, 147);
            this.cmbStates.Name = "cmbStates";
            this.cmbStates.Size = new System.Drawing.Size(79, 21);
            this.cmbStates.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 235);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(123, 264);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(73, 313);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(156, 23);
            this.btnGoBack.TabIndex = 33;
            this.btnGoBack.Text = "Voltar";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(42, 235);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 32;
            this.btnNew.Text = "Novo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(204, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(42, 264);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dtSupplier
            // 
            this.dtSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtSupplier.Location = new System.Drawing.Point(514, 83);
            this.dtSupplier.Name = "dtSupplier";
            this.dtSupplier.Size = new System.Drawing.Size(240, 326);
            this.dtSupplier.TabIndex = 36;
            // 
            // SupplierMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtSupplier);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbStates);
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
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Name = "SupplierMenu";
            this.Text = "Menu de Fornecedor";
            ((System.ComponentModel.ISupportInitialize)(this.dtSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblComplement;
        private System.Windows.Forms.TextBox txtComplement;
        private System.Windows.Forms.Label lblNeigh;
        private System.Windows.Forms.TextBox txtNeigh;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCEP;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbStates;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dtSupplier;
    }
}