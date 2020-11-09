namespace APP_UI
{
    partial class frmCad_Juridico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabHistórico = new System.Windows.Forms.TabPage();
            this.grpMaisDetalhes = new System.Windows.Forms.GroupBox();
            this.txtMaisDetalhes = new System.Windows.Forms.TextBox();
            this.dtgHistorico = new System.Windows.Forms.DataGridView();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPortaria = new System.Windows.Forms.TextBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgDados = new System.Windows.Forms.DataGridView();
            this.txtPontuacaoCNH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtNParcelas = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.gpbDados = new System.Windows.Forms.GroupBox();
            this.tabHistórico.SuspendLayout();
            this.grpMaisDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorico)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDados)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.gpbDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabHistórico
            // 
            this.tabHistórico.Controls.Add(this.grpMaisDetalhes);
            this.tabHistórico.Controls.Add(this.dtgHistorico);
            this.tabHistórico.Location = new System.Drawing.Point(4, 22);
            this.tabHistórico.Name = "tabHistórico";
            this.tabHistórico.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistórico.Size = new System.Drawing.Size(751, 316);
            this.tabHistórico.TabIndex = 1;
            this.tabHistórico.Text = "Histórico";
            this.tabHistórico.UseVisualStyleBackColor = true;
            // 
            // grpMaisDetalhes
            // 
            this.grpMaisDetalhes.Controls.Add(this.txtMaisDetalhes);
            this.grpMaisDetalhes.Location = new System.Drawing.Point(4, 133);
            this.grpMaisDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.grpMaisDetalhes.Name = "grpMaisDetalhes";
            this.grpMaisDetalhes.Padding = new System.Windows.Forms.Padding(4);
            this.grpMaisDetalhes.Size = new System.Drawing.Size(741, 176);
            this.grpMaisDetalhes.TabIndex = 362;
            this.grpMaisDetalhes.TabStop = false;
            this.grpMaisDetalhes.Text = "Mais detalhes:";
            // 
            // txtMaisDetalhes
            // 
            this.txtMaisDetalhes.BackColor = System.Drawing.SystemColors.Window;
            this.txtMaisDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaisDetalhes.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaisDetalhes.Location = new System.Drawing.Point(8, 23);
            this.txtMaisDetalhes.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaisDetalhes.Multiline = true;
            this.txtMaisDetalhes.Name = "txtMaisDetalhes";
            this.txtMaisDetalhes.ReadOnly = true;
            this.txtMaisDetalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMaisDetalhes.Size = new System.Drawing.Size(725, 145);
            this.txtMaisDetalhes.TabIndex = 11;
            // 
            // dtgHistorico
            // 
            this.dtgHistorico.AllowUserToAddRows = false;
            this.dtgHistorico.AllowUserToDeleteRows = false;
            this.dtgHistorico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dtgHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgHistorico.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgHistorico.ColumnHeadersHeight = 29;
            this.dtgHistorico.Location = new System.Drawing.Point(4, 7);
            this.dtgHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.dtgHistorico.Name = "dtgHistorico";
            this.dtgHistorico.ReadOnly = true;
            this.dtgHistorico.RowHeadersWidth = 51;
            this.dtgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistorico.Size = new System.Drawing.Size(739, 118);
            this.dtgHistorico.TabIndex = 361;
            this.dtgHistorico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgHistorico_CellClick);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(8, 83);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(321, 20);
            this.txtEmail.TabIndex = 551;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 550;
            this.label7.Text = "Email:";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(425, 83);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(329, 20);
            this.txtStatus.TabIndex = 549;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 548;
            this.label12.Text = "Data:";
            // 
            // mskData
            // 
            this.mskData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mskData.Location = new System.Drawing.Point(335, 83);
            this.mskData.Margin = new System.Windows.Forms.Padding(2);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.ReadOnly = true;
            this.mskData.Size = new System.Drawing.Size(85, 20);
            this.mskData.TabIndex = 547;
            this.mskData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskData.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(423, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 546;
            this.label11.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(658, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 545;
            this.label8.Text = "Portaria:";
            // 
            // txtPortaria
            // 
            this.txtPortaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPortaria.Location = new System.Drawing.Point(661, 43);
            this.txtPortaria.Name = "txtPortaria";
            this.txtPortaria.ReadOnly = true;
            this.txtPortaria.Size = new System.Drawing.Size(94, 20);
            this.txtPortaria.TabIndex = 544;
            // 
            // btnRemover
            // 
            this.btnRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemover.Location = new System.Drawing.Point(139, 6);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(62, 23);
            this.btnRemover.TabIndex = 471;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.Location = new System.Drawing.Point(72, 6);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(62, 23);
            this.btnAlterar.TabIndex = 470;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionar.Location = new System.Drawing.Point(5, 5);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(62, 23);
            this.btnAdicionar.TabIndex = 469;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRemover);
            this.tabPage1.Controls.Add(this.btnAlterar);
            this.tabPage1.Controls.Add(this.btnAdicionar);
            this.tabPage1.Controls.Add(this.dtgDados);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(751, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fase";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgDados
            // 
            this.dtgDados.AllowUserToAddRows = false;
            this.dtgDados.AllowUserToDeleteRows = false;
            this.dtgDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgDados.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDados.Location = new System.Drawing.Point(6, 34);
            this.dtgDados.MultiSelect = false;
            this.dtgDados.Name = "dtgDados";
            this.dtgDados.ReadOnly = true;
            this.dtgDados.RowHeadersWidth = 51;
            this.dtgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDados.Size = new System.Drawing.Size(739, 279);
            this.dtgDados.TabIndex = 468;
            this.dtgDados.DoubleClick += new System.EventHandler(this.DtgDados_DoubleClick);
            // 
            // txtPontuacaoCNH
            // 
            this.txtPontuacaoCNH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPontuacaoCNH.Location = new System.Drawing.Point(522, 43);
            this.txtPontuacaoCNH.Name = "txtPontuacaoCNH";
            this.txtPontuacaoCNH.ReadOnly = true;
            this.txtPontuacaoCNH.Size = new System.Drawing.Size(133, 20);
            this.txtPontuacaoCNH.TabIndex = 538;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 539;
            this.label2.Text = "Pontuação:";
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(614, 18);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCliente.TabIndex = 473;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.BtnCliente_Click);
            // 
            // txtNParcelas
            // 
            this.txtNParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNParcelas.Location = new System.Drawing.Point(629, 123);
            this.txtNParcelas.Name = "txtNParcelas";
            this.txtNParcelas.ReadOnly = true;
            this.txtNParcelas.Size = new System.Drawing.Size(125, 20);
            this.txtNParcelas.TabIndex = 535;
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormaPagamento.Location = new System.Drawing.Point(424, 123);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.ReadOnly = true;
            this.txtFormaPagamento.Size = new System.Drawing.Size(200, 20);
            this.txtFormaPagamento.TabIndex = 534;
            // 
            // txtServico
            // 
            this.txtServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServico.Location = new System.Drawing.Point(8, 123);
            this.txtServico.Name = "txtServico";
            this.txtServico.ReadOnly = true;
            this.txtServico.Size = new System.Drawing.Size(321, 20);
            this.txtServico.TabIndex = 533;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 515;
            this.label3.Text = "Forma de pagamento:";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(8, 43);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(508, 20);
            this.txtCliente.TabIndex = 528;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabHistórico);
            this.tabControl1.Location = new System.Drawing.Point(11, 222);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(759, 342);
            this.tabControl1.TabIndex = 474;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 514;
            this.label5.Text = "Valor:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Black;
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(5, 12, 0, 0);
            this.lblTitulo.Size = new System.Drawing.Size(782, 50);
            this.lblTitulo.TabIndex = 471;
            this.lblTitulo.Text = "Jurídico";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(683, 570);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 34);
            this.btnCancelar.TabIndex = 470;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.Location = new System.Drawing.Point(590, 570);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(87, 34);
            this.btnRegistrar.TabIndex = 469;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(334, 123);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(86, 20);
            this.txtValor.TabIndex = 509;
            this.txtValor.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 513;
            this.label4.Text = "Serviço:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(9, 27);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 529;
            this.lblCliente.Text = "Cliente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(627, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 512;
            this.label6.Text = "Nº de parcelas:";
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.Location = new System.Drawing.Point(695, 18);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(75, 23);
            this.btnFinanceiro.TabIndex = 472;
            this.btnFinanceiro.Text = "Financeiro";
            this.btnFinanceiro.UseVisualStyleBackColor = true;
            this.btnFinanceiro.Click += new System.EventHandler(this.BtnFinanceiro_Click);
            // 
            // gpbDados
            // 
            this.gpbDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDados.Controls.Add(this.txtEmail);
            this.gpbDados.Controls.Add(this.label7);
            this.gpbDados.Controls.Add(this.txtStatus);
            this.gpbDados.Controls.Add(this.label12);
            this.gpbDados.Controls.Add(this.mskData);
            this.gpbDados.Controls.Add(this.label11);
            this.gpbDados.Controls.Add(this.label8);
            this.gpbDados.Controls.Add(this.txtPortaria);
            this.gpbDados.Controls.Add(this.txtPontuacaoCNH);
            this.gpbDados.Controls.Add(this.label2);
            this.gpbDados.Controls.Add(this.txtNParcelas);
            this.gpbDados.Controls.Add(this.txtFormaPagamento);
            this.gpbDados.Controls.Add(this.txtServico);
            this.gpbDados.Controls.Add(this.label3);
            this.gpbDados.Controls.Add(this.txtCliente);
            this.gpbDados.Controls.Add(this.label5);
            this.gpbDados.Controls.Add(this.txtValor);
            this.gpbDados.Controls.Add(this.label4);
            this.gpbDados.Controls.Add(this.lblCliente);
            this.gpbDados.Controls.Add(this.label6);
            this.gpbDados.Location = new System.Drawing.Point(11, 58);
            this.gpbDados.Margin = new System.Windows.Forms.Padding(2);
            this.gpbDados.Name = "gpbDados";
            this.gpbDados.Padding = new System.Windows.Forms.Padding(2);
            this.gpbDados.Size = new System.Drawing.Size(760, 158);
            this.gpbDados.TabIndex = 468;
            this.gpbDados.TabStop = false;
            this.gpbDados.Text = "Dados";
            // 
            // frmCad_Juridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 610);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnFinanceiro);
            this.Controls.Add(this.gpbDados);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmCad_Juridico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Jurídico";
            this.Load += new System.EventHandler(this.FrmCad_Juridico_Load);
            this.tabHistórico.ResumeLayout(false);
            this.grpMaisDetalhes.ResumeLayout(false);
            this.grpMaisDetalhes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorico)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDados)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.gpbDados.ResumeLayout(false);
            this.gpbDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabHistórico;
        private System.Windows.Forms.GroupBox grpMaisDetalhes;
        private System.Windows.Forms.TextBox txtMaisDetalhes;
        private System.Windows.Forms.DataGridView dtgHistorico;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPortaria;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtgDados;
        private System.Windows.Forms.TextBox txtPontuacaoCNH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtNParcelas;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.GroupBox gpbDados;
    }
}