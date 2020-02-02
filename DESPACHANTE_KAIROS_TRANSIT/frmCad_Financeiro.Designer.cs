﻿namespace APP_UI
{
    partial class frmCad_Financeiro
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCad_Financeiro));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.gpbDetalhes = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtgBoletosCheques = new System.Windows.Forms.DataGridView();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.nudDiaVencimento = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.picConsultor = new System.Windows.Forms.PictureBox();
            this.cboConsultor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocal_os = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboForma_Pagamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValorOS = new System.Windows.Forms.TextBox();
            this.txtMotoboy_os = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numQtdParcela = new System.Windows.Forms.NumericUpDown();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtValorL = new System.Windows.Forms.Label();
            this.txtValorLi = new System.Windows.Forms.TextBox();
            this.txtValorB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboIndicacao = new System.Windows.Forms.ComboBox();
            this.btnPesquisarAdvogado = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.gpbDetalhes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBoletosCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaVencimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConsultor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdParcela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisarAdvogado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(867, 732);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 38);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(751, 732);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(107, 38);
            this.btnRegistrar.TabIndex = 16;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // gpbDetalhes
            // 
            this.gpbDetalhes.Controls.Add(this.groupBox1);
            this.gpbDetalhes.Controls.Add(this.nudDiaVencimento);
            this.gpbDetalhes.Controls.Add(this.label14);
            this.gpbDetalhes.Controls.Add(this.picConsultor);
            this.gpbDetalhes.Controls.Add(this.cboConsultor);
            this.gpbDetalhes.Controls.Add(this.label9);
            this.gpbDetalhes.Controls.Add(this.txtBanco);
            this.gpbDetalhes.Controls.Add(this.label8);
            this.gpbDetalhes.Controls.Add(this.txtLocal_os);
            this.gpbDetalhes.Controls.Add(this.label13);
            this.gpbDetalhes.Controls.Add(this.cboForma_Pagamento);
            this.gpbDetalhes.Controls.Add(this.label3);
            this.gpbDetalhes.Controls.Add(this.label7);
            this.gpbDetalhes.Controls.Add(this.txtValorOS);
            this.gpbDetalhes.Controls.Add(this.txtMotoboy_os);
            this.gpbDetalhes.Controls.Add(this.label1);
            this.gpbDetalhes.Controls.Add(this.label5);
            this.gpbDetalhes.Controls.Add(this.txtValor);
            this.gpbDetalhes.Controls.Add(this.cboServico);
            this.gpbDetalhes.Controls.Add(this.label4);
            this.gpbDetalhes.Controls.Add(this.numQtdParcela);
            this.gpbDetalhes.Controls.Add(this.lblObservacao);
            this.gpbDetalhes.Controls.Add(this.txtObservacao);
            this.gpbDetalhes.Controls.Add(this.label6);
            this.gpbDetalhes.Location = new System.Drawing.Point(17, 62);
            this.gpbDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDetalhes.Name = "gpbDetalhes";
            this.gpbDetalhes.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDetalhes.Size = new System.Drawing.Size(956, 649);
            this.gpbDetalhes.TabIndex = 10;
            this.gpbDetalhes.TabStop = false;
            this.gpbDetalhes.Text = "Dados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtgBoletosCheques);
            this.groupBox1.Controls.Add(this.btnAplicar);
            this.groupBox1.Location = new System.Drawing.Point(11, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(933, 282);
            this.groupBox1.TabIndex = 526;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados pagamento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 17);
            this.label10.TabIndex = 501;
            this.label10.Text = "Boletos/Cheques:";
            // 
            // dtgBoletosCheques
            // 
            this.dtgBoletosCheques.AllowUserToAddRows = false;
            this.dtgBoletosCheques.AllowUserToDeleteRows = false;
            this.dtgBoletosCheques.AllowUserToOrderColumns = true;
            this.dtgBoletosCheques.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgBoletosCheques.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgBoletosCheques.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgBoletosCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBoletosCheques.Location = new System.Drawing.Point(19, 50);
            this.dtgBoletosCheques.Margin = new System.Windows.Forms.Padding(4);
            this.dtgBoletosCheques.Name = "dtgBoletosCheques";
            this.dtgBoletosCheques.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBoletosCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBoletosCheques.RowHeadersWidth = 51;
            this.dtgBoletosCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBoletosCheques.Size = new System.Drawing.Size(897, 177);
            this.dtgBoletosCheques.TabIndex = 8;
            this.dtgBoletosCheques.DoubleClick += new System.EventHandler(this.dtgBoletosCheques_DoubleClick);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(827, 233);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(91, 39);
            this.btnAplicar.TabIndex = 517;
            this.btnAplicar.Text = "Alterar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // nudDiaVencimento
            // 
            this.nudDiaVencimento.Location = new System.Drawing.Point(891, 78);
            this.nudDiaVencimento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudDiaVencimento.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudDiaVencimento.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiaVencimento.Name = "nudDiaVencimento";
            this.nudDiaVencimento.Size = new System.Drawing.Size(53, 22);
            this.nudDiaVencimento.TabIndex = 519;
            this.nudDiaVencimento.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiaVencimento.ValueChanged += new System.EventHandler(this.NudDiaVencimento_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(661, 79);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(224, 17);
            this.label14.TabIndex = 520;
            this.label14.Text = "Dia de vencimento de pagamento:";
            // 
            // picConsultor
            // 
            this.picConsultor.Image = ((System.Drawing.Image)(resources.GetObject("picConsultor.Image")));
            this.picConsultor.Location = new System.Drawing.Point(901, 406);
            this.picConsultor.Margin = new System.Windows.Forms.Padding(4);
            this.picConsultor.Name = "picConsultor";
            this.picConsultor.Size = new System.Drawing.Size(21, 20);
            this.picConsultor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picConsultor.TabIndex = 516;
            this.picConsultor.TabStop = false;
            this.toolTip.SetToolTip(this.picConsultor, "Consultor não encontrado em registros anteriores.\r\nAo inserir, será considerado c" +
        "omo novo consultor.");
            this.picConsultor.Visible = false;
            // 
            // cboConsultor
            // 
            this.cboConsultor.FormattingEnabled = true;
            this.cboConsultor.Location = new System.Drawing.Point(479, 404);
            this.cboConsultor.Margin = new System.Windows.Forms.Padding(4);
            this.cboConsultor.Name = "cboConsultor";
            this.cboConsultor.Size = new System.Drawing.Size(464, 24);
            this.cboConsultor.TabIndex = 11;
            this.cboConsultor.Leave += new System.EventHandler(this.CboConsultor_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 384);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 515;
            this.label9.Text = "Banco:";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(12, 404);
            this.txtBanco.Margin = new System.Windows.Forms.Padding(4);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(459, 22);
            this.txtBanco.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(475, 384);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 513;
            this.label8.Text = "Consultor:";
            // 
            // txtLocal_os
            // 
            this.txtLocal_os.Location = new System.Drawing.Point(400, 452);
            this.txtLocal_os.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocal_os.Name = "txtLocal_os";
            this.txtLocal_os.Size = new System.Drawing.Size(437, 22);
            this.txtLocal_os.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.Location = new System.Drawing.Point(396, 432);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 17);
            this.label13.TabIndex = 509;
            this.label13.Text = "Local:";
            // 
            // cboForma_Pagamento
            // 
            this.cboForma_Pagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForma_Pagamento.FormattingEnabled = true;
            this.cboForma_Pagamento.ItemHeight = 16;
            this.cboForma_Pagamento.Location = new System.Drawing.Point(569, 39);
            this.cboForma_Pagamento.Margin = new System.Windows.Forms.Padding(4);
            this.cboForma_Pagamento.Name = "cboForma_Pagamento";
            this.cboForma_Pagamento.Size = new System.Drawing.Size(268, 24);
            this.cboForma_Pagamento.TabIndex = 6;
            this.cboForma_Pagamento.SelectedIndexChanged += new System.EventHandler(this.CboForma_Pagamento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 507;
            this.label3.Text = "Forma de pagamento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(843, 433);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 496;
            this.label7.Text = "Valor O.S.:";
            // 
            // txtValorOS
            // 
            this.txtValorOS.Location = new System.Drawing.Point(845, 452);
            this.txtValorOS.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorOS.Name = "txtValorOS";
            this.txtValorOS.Size = new System.Drawing.Size(97, 22);
            this.txtValorOS.TabIndex = 14;
            this.txtValorOS.Text = "0.00";
            this.txtValorOS.TextChanged += new System.EventHandler(this.txtValorOS_TextChanged);
            // 
            // txtMotoboy_os
            // 
            this.txtMotoboy_os.Location = new System.Drawing.Point(11, 452);
            this.txtMotoboy_os.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotoboy_os.Name = "txtMotoboy_os";
            this.txtMotoboy_os.Size = new System.Drawing.Size(381, 22);
            this.txtMotoboy_os.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 432);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 494;
            this.label1.Text = "MotoBoy:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 484;
            this.label5.Text = "Valor:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(452, 39);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(109, 22);
            this.txtValor.TabIndex = 5;
            this.txtValor.Text = "0.00";
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.FormattingEnabled = true;
            this.cboServico.ItemHeight = 16;
            this.cboServico.Location = new System.Drawing.Point(13, 39);
            this.cboServico.Margin = new System.Windows.Forms.Padding(4);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(431, 24);
            this.cboServico.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 482;
            this.label4.Text = "Serviço:";
            // 
            // numQtdParcela
            // 
            this.numQtdParcela.Location = new System.Drawing.Point(845, 39);
            this.numQtdParcela.Margin = new System.Windows.Forms.Padding(4);
            this.numQtdParcela.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQtdParcela.Name = "numQtdParcela";
            this.numQtdParcela.Size = new System.Drawing.Size(99, 22);
            this.numQtdParcela.TabIndex = 7;
            this.numQtdParcela.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQtdParcela.ValueChanged += new System.EventHandler(this.numQtdParcela_ValueChanged);
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(8, 480);
            this.lblObservacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(89, 17);
            this.lblObservacao.TabIndex = 475;
            this.lblObservacao.Text = "Observação:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 500);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(931, 82);
            this.txtObservacao.TabIndex = 15;
            this.txtObservacao.Enter += new System.EventHandler(this.TxtObservacao_Enter);
            this.txtObservacao.Leave += new System.EventHandler(this.TxtObservacao_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(845, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 471;
            this.label6.Text = "Nº de parcelas:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 743);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 17);
            this.label15.TabIndex = 531;
            this.label15.Text = "Valor Bruto:";
            // 
            // txtValorL
            // 
            this.txtValorL.AutoSize = true;
            this.txtValorL.Location = new System.Drawing.Point(131, 743);
            this.txtValorL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtValorL.Name = "txtValorL";
            this.txtValorL.Size = new System.Drawing.Size(95, 17);
            this.txtValorL.TabIndex = 530;
            this.txtValorL.Text = "Valor Líquido:";
            // 
            // txtValorLi
            // 
            this.txtValorLi.Location = new System.Drawing.Point(134, 764);
            this.txtValorLi.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorLi.Name = "txtValorLi";
            this.txtValorLi.Size = new System.Drawing.Size(109, 22);
            this.txtValorLi.TabIndex = 528;
            this.txtValorLi.Text = "0.00";
            this.txtValorLi.TextChanged += new System.EventHandler(this.txtValorLi_TextChanged);
            // 
            // txtValorB
            // 
            this.txtValorB.Location = new System.Drawing.Point(17, 764);
            this.txtValorB.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorB.Name = "txtValorB";
            this.txtValorB.Size = new System.Drawing.Size(109, 22);
            this.txtValorB.TabIndex = 527;
            this.txtValorB.Text = "0.00";
            this.txtValorB.TextChanged += new System.EventHandler(this.txtValorB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 445;
            this.label2.Text = "Indicação:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 16;
            this.cboStatus.Location = new System.Drawing.Point(783, 30);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(191, 24);
            this.cboStatus.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(780, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 462;
            this.label11.Text = "Status:";
            // 
            // cboIndicacao
            // 
            this.cboIndicacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndicacao.FormattingEnabled = true;
            this.cboIndicacao.ItemHeight = 16;
            this.cboIndicacao.Location = new System.Drawing.Point(568, 30);
            this.cboIndicacao.Margin = new System.Windows.Forms.Padding(4);
            this.cboIndicacao.Name = "cboIndicacao";
            this.cboIndicacao.Size = new System.Drawing.Size(207, 24);
            this.cboIndicacao.TabIndex = 518;
            // 
            // btnPesquisarAdvogado
            // 
            this.btnPesquisarAdvogado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarAdvogado.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarAdvogado.Image")));
            this.btnPesquisarAdvogado.Location = new System.Drawing.Point(420, 32);
            this.btnPesquisarAdvogado.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarAdvogado.Name = "btnPesquisarAdvogado";
            this.btnPesquisarAdvogado.Size = new System.Drawing.Size(16, 16);
            this.btnPesquisarAdvogado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPesquisarAdvogado.TabIndex = 521;
            this.btnPesquisarAdvogado.TabStop = false;
            this.btnPesquisarAdvogado.Click += new System.EventHandler(this.btnPesquisarAdvogado_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(13, 10);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(55, 17);
            this.lblCliente.TabIndex = 520;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(17, 30);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(424, 22);
            this.txtCliente.TabIndex = 519;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(445, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 17);
            this.label12.TabIndex = 523;
            this.label12.Text = "Data:";
            // 
            // mskData
            // 
            this.mskData.Location = new System.Drawing.Point(448, 30);
            this.mskData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(113, 22);
            this.mskData.TabIndex = 522;
            this.mskData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskData.ValidatingType = typeof(System.DateTime);
            // 
            // frmCad_Financeiro
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 799);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnPesquisarAdvogado);
            this.Controls.Add(this.txtValorL);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtValorLi);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtValorB);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.cboIndicacao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.gpbDetalhes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmCad_Financeiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Financeiro";
            this.Load += new System.EventHandler(this.FrmCad_Financeiro_Load);
            this.gpbDetalhes.ResumeLayout(false);
            this.gpbDetalhes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBoletosCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiaVencimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConsultor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQtdParcela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPesquisarAdvogado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox gpbDetalhes;
        private System.Windows.Forms.NumericUpDown numQtdParcela;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValorOS;
        private System.Windows.Forms.TextBox txtMotoboy_os;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboForma_Pagamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocal_os;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dtgBoletosCheques;
        private System.Windows.Forms.PictureBox picConsultor;
        private System.Windows.Forms.ComboBox cboConsultor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.ComboBox cboIndicacao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudDiaVencimento;
        private System.Windows.Forms.PictureBox btnPesquisarAdvogado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtValorL;
        private System.Windows.Forms.TextBox txtValorLi;
        private System.Windows.Forms.TextBox txtValorB;
        private System.Windows.Forms.Label label15;
    }
}