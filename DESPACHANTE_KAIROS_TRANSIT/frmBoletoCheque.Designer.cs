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
            this.label4 = new System.Windows.Forms.Label();
            this.cboForma_Pagamento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorJuros = new System.Windows.Forms.TextBox();
            this.mskDataPagamento = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFormaPagamentoJuros = new System.Windows.Forms.ComboBox();
            this.txtCobranca = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mskDataProtesto = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskCartaAnuencia = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCartorio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumBolChe
            // 
            this.txtNumBolChe.Location = new System.Drawing.Point(7, 201);
            this.txtNumBolChe.MaxLength = 200;
            this.txtNumBolChe.Multiline = true;
            this.txtNumBolChe.Name = "txtNumBolChe";
            this.txtNumBolChe.Size = new System.Drawing.Size(421, 102);
            this.txtNumBolChe.TabIndex = 10;
            // 
            // lblBoletoCheque
            // 
            this.lblBoletoCheque.AutoSize = true;
            this.lblBoletoCheque.Location = new System.Drawing.Point(7, 185);
            this.lblBoletoCheque.Name = "lblBoletoCheque";
            this.lblBoletoCheque.Size = new System.Drawing.Size(73, 13);
            this.lblBoletoCheque.TabIndex = 479;
            this.lblBoletoCheque.Text = "Observações:";
            this.lblBoletoCheque.Click += new System.EventHandler(this.lblBoletoCheque_Click);
            // 
            // cboStatusPagamento
            // 
            this.cboStatusPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusPagamento.FormattingEnabled = true;
            this.cboStatusPagamento.Location = new System.Drawing.Point(280, 32);
            this.cboStatusPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatusPagamento.Name = "cboStatusPagamento";
            this.cboStatusPagamento.Size = new System.Drawing.Size(149, 21);
            this.cboStatusPagamento.TabIndex = 523;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 16);
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
            this.txtParcela.Size = new System.Drawing.Size(97, 20);
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
            this.btnRegistrar.Location = new System.Drawing.Point(490, 410);
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
            this.btnCancelar.Location = new System.Drawing.Point(575, 410);
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
            this.mskDataVencimento.Location = new System.Drawing.Point(10, 71);
            this.mskDataVencimento.Margin = new System.Windows.Forms.Padding(2);
            this.mskDataVencimento.Mask = "00/00/0000";
            this.mskDataVencimento.Name = "mskDataVencimento";
            this.mskDataVencimento.Size = new System.Drawing.Size(119, 20);
            this.mskDataVencimento.TabIndex = 530;
            this.mskDataVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDataVencimento.ValidatingType = typeof(System.DateTime);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 55);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 529;
            this.label19.Text = "Vencimento:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(264, 71);
            this.txtValor.MaxLength = 12;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(79, 20);
            this.txtValor.TabIndex = 531;
            this.txtValor.Text = "0.00";
            this.txtValor.TextChanged += new System.EventHandler(this.TxtValor_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 532;
            this.label3.Text = "Valor original:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 536;
            this.label4.Text = "Forma de pagamento:";
            // 
            // cboForma_Pagamento
            // 
            this.cboForma_Pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForma_Pagamento.FormattingEnabled = true;
            this.cboForma_Pagamento.Location = new System.Drawing.Point(111, 32);
            this.cboForma_Pagamento.Margin = new System.Windows.Forms.Padding(2);
            this.cboForma_Pagamento.Name = "cboForma_Pagamento";
            this.cboForma_Pagamento.Size = new System.Drawing.Size(165, 21);
            this.cboForma_Pagamento.TabIndex = 535;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 538;
            this.label5.Text = "Valor c/ juros:";
            // 
            // txtValorJuros
            // 
            this.txtValorJuros.Location = new System.Drawing.Point(349, 71);
            this.txtValorJuros.MaxLength = 12;
            this.txtValorJuros.Name = "txtValorJuros";
            this.txtValorJuros.Size = new System.Drawing.Size(79, 20);
            this.txtValorJuros.TabIndex = 537;
            this.txtValorJuros.Text = "0.00";
            this.txtValorJuros.TextChanged += new System.EventHandler(this.txtValorJuros_TextChanged);
            // 
            // mskDataPagamento
            // 
            this.mskDataPagamento.Location = new System.Drawing.Point(133, 71);
            this.mskDataPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.mskDataPagamento.Mask = "00/00/0000";
            this.mskDataPagamento.Name = "mskDataPagamento";
            this.mskDataPagamento.Size = new System.Drawing.Size(126, 20);
            this.mskDataPagamento.TabIndex = 540;
            this.mskDataPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDataPagamento.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 539;
            this.label6.Text = "Data do pagamento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 13);
            this.label7.TabIndex = 542;
            this.label7.Text = "Forma de pagamento:, c/ juros";
            // 
            // cboFormaPagamentoJuros
            // 
            this.cboFormaPagamentoJuros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPagamentoJuros.FormattingEnabled = true;
            this.cboFormaPagamentoJuros.Location = new System.Drawing.Point(15, 108);
            this.cboFormaPagamentoJuros.Margin = new System.Windows.Forms.Padding(2);
            this.cboFormaPagamentoJuros.Name = "cboFormaPagamentoJuros";
            this.cboFormaPagamentoJuros.Size = new System.Drawing.Size(165, 21);
            this.cboFormaPagamentoJuros.TabIndex = 541;
            // 
            // txtCobranca
            // 
            this.txtCobranca.Location = new System.Drawing.Point(185, 109);
            this.txtCobranca.Name = "txtCobranca";
            this.txtCobranca.Size = new System.Drawing.Size(100, 20);
            this.txtCobranca.TabIndex = 543;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(182, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 544;
            this.label8.Text = "Cobrança:";
            // 
            // mskDataProtesto
            // 
            this.mskDataProtesto.Location = new System.Drawing.Point(290, 109);
            this.mskDataProtesto.Margin = new System.Windows.Forms.Padding(2);
            this.mskDataProtesto.Mask = "00/00/0000";
            this.mskDataProtesto.Name = "mskDataProtesto";
            this.mskDataProtesto.Size = new System.Drawing.Size(119, 20);
            this.mskDataProtesto.TabIndex = 545;
            this.mskDataProtesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDataProtesto.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 546;
            this.label9.Text = "Data Protesto:";
            // 
            // mskCartaAnuencia
            // 
            this.mskCartaAnuencia.Location = new System.Drawing.Point(413, 109);
            this.mskCartaAnuencia.Margin = new System.Windows.Forms.Padding(2);
            this.mskCartaAnuencia.Mask = "00/00/0000";
            this.mskCartaAnuencia.Name = "mskCartaAnuencia";
            this.mskCartaAnuencia.Size = new System.Drawing.Size(119, 20);
            this.mskCartaAnuencia.TabIndex = 547;
            this.mskCartaAnuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskCartaAnuencia.ValidatingType = typeof(System.DateTime);
            this.mskCartaAnuencia.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(410, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 548;
            this.label10.Text = "Carta Anuencia:";
            // 
            // txtCartorio
            // 
            this.txtCartorio.Location = new System.Drawing.Point(537, 109);
            this.txtCartorio.Name = "txtCartorio";
            this.txtCartorio.Size = new System.Drawing.Size(100, 20);
            this.txtCartorio.TabIndex = 549;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(534, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 550;
            this.label11.Text = "Cartório:";
            // 
            // frmBoletoCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 453);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCartorio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mskCartaAnuencia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mskDataProtesto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCobranca);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboFormaPagamentoJuros);
            this.Controls.Add(this.mskDataPagamento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtValorJuros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboForma_Pagamento);
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
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboForma_Pagamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorJuros;
        private System.Windows.Forms.MaskedTextBox mskDataPagamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboFormaPagamentoJuros;
        private System.Windows.Forms.TextBox txtCobranca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mskDataProtesto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskCartaAnuencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCartorio;
        private System.Windows.Forms.Label label11;
    }
}