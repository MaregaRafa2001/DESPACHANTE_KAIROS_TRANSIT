namespace APP_UI
{
    partial class frmBoletoCheque
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
            this.txtNumBolChe = new System.Windows.Forms.TextBox();
            this.lblBoletoCheque = new System.Windows.Forms.Label();
            this.cboStatusPagamento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParcela = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.mskDataVencimento = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumBolChe
            // 
            this.txtNumBolChe.Location = new System.Drawing.Point(10, 83);
            this.txtNumBolChe.Multiline = true;
            this.txtNumBolChe.Name = "txtNumBolChe";
            this.txtNumBolChe.Size = new System.Drawing.Size(418, 102);
            this.txtNumBolChe.TabIndex = 10;
            // 
            // lblBoletoCheque
            // 
            this.lblBoletoCheque.AutoSize = true;
            this.lblBoletoCheque.Location = new System.Drawing.Point(10, 66);
            this.lblBoletoCheque.Name = "lblBoletoCheque";
            this.lblBoletoCheque.Size = new System.Drawing.Size(73, 13);
            this.lblBoletoCheque.TabIndex = 479;
            this.lblBoletoCheque.Text = "Observações:";
            // 
            // cboStatusPagamento
            // 
            this.cboStatusPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusPagamento.FormattingEnabled = true;
            this.cboStatusPagamento.Location = new System.Drawing.Point(73, 32);
            this.cboStatusPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatusPagamento.Name = "cboStatusPagamento";
            this.cboStatusPagamento.Size = new System.Drawing.Size(166, 21);
            this.cboStatusPagamento.TabIndex = 523;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 524;
            this.label1.Text = "Status de pagamento:";
            // 
            // txtParcela
            // 
            this.txtParcela.Location = new System.Drawing.Point(10, 32);
            this.txtParcela.Margin = new System.Windows.Forms.Padding(2);
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.ReadOnly = true;
            this.txtParcela.Size = new System.Drawing.Size(60, 20);
            this.txtParcela.TabIndex = 525;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 526;
            this.label2.Text = "Parcela:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(264, 190);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(80, 32);
            this.btnRegistrar.TabIndex = 527;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(349, 190);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 32);
            this.btnCancelar.TabIndex = 528;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // mskDataVencimento
            // 
            this.mskDataVencimento.Location = new System.Drawing.Point(243, 33);
            this.mskDataVencimento.Margin = new System.Windows.Forms.Padding(2);
            this.mskDataVencimento.Mask = "00/00/0000";
            this.mskDataVencimento.Name = "mskDataVencimento";
            this.mskDataVencimento.Size = new System.Drawing.Size(103, 20);
            this.mskDataVencimento.TabIndex = 530;
            this.mskDataVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDataVencimento.ValidatingType = typeof(System.DateTime);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(243, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 529;
            this.label19.Text = "Vencimento:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(351, 33);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(80, 20);
            this.txtValor.TabIndex = 531;
            this.txtValor.Text = "0.00";
            this.txtValor.TextChanged += new System.EventHandler(this.TxtValor_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 532;
            this.label3.Text = "Valor:";
            // 
            // frmBoletoCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 234);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.mskDataVencimento);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParcela);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStatusPagamento);
            this.Controls.Add(this.lblBoletoCheque);
            this.Controls.Add(this.txtNumBolChe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBoletoCheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados da prestação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumBolChe;
        private System.Windows.Forms.Label lblBoletoCheque;
        private System.Windows.Forms.ComboBox cboStatusPagamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParcela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox mskDataVencimento;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
    }
}