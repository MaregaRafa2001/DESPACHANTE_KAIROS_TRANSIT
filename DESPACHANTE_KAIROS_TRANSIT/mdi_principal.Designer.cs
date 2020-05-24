namespace APP_UI
{
    partial class mdi_principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.financeiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmFinanceiro = new System.Windows.Forms.ToolStripMenuItem();
            this.administracaoToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmAdministracao = new System.Windows.Forms.ToolStripMenuItem();
            this.tssRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.apoioDoSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmPermissoes = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.jurídicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tssfrmJuridico = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.financeiroToolStripMenuItem,
            this.administracaoToolStrip,
            this.jurídicoToolStripMenuItem,
            this.tssRelatorios,
            this.apoioDoSistemaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssfrmCliente});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.clienteToolStripMenuItem.Text = "Cadastros";
            // 
            // tssfrmCliente
            // 
            this.tssfrmCliente.Name = "tssfrmCliente";
            this.tssfrmCliente.Size = new System.Drawing.Size(144, 26);
            this.tssfrmCliente.Text = "Clientes";
            this.tssfrmCliente.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // financeiroToolStripMenuItem
            // 
            this.financeiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssfrmFinanceiro});
            this.financeiroToolStripMenuItem.Name = "financeiroToolStripMenuItem";
            this.financeiroToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.financeiroToolStripMenuItem.Text = "Financeiro";
            // 
            // tssfrmFinanceiro
            // 
            this.tssfrmFinanceiro.Name = "tssfrmFinanceiro";
            this.tssfrmFinanceiro.Size = new System.Drawing.Size(160, 26);
            this.tssfrmFinanceiro.Text = "Financeiro";
            this.tssfrmFinanceiro.Click += new System.EventHandler(this.TssfrmFinanceiro_Click);
            // 
            // administracaoToolStrip
            // 
            this.administracaoToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssfrmAdministracao});
            this.administracaoToolStrip.Name = "administracaoToolStrip";
            this.administracaoToolStrip.Size = new System.Drawing.Size(119, 24);
            this.administracaoToolStrip.Text = "Administração";
            // 
            // tssfrmAdministracao
            // 
            this.tssfrmAdministracao.Name = "tssfrmAdministracao";
            this.tssfrmAdministracao.Size = new System.Drawing.Size(224, 26);
            this.tssfrmAdministracao.Text = "Administração";
            this.tssfrmAdministracao.Click += new System.EventHandler(this.AdminstracaoToolStripMenuItem_Click);
            // 
            // tssRelatorios
            // 
            this.tssRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssfrmRelatorios});
            this.tssRelatorios.Name = "tssRelatorios";
            this.tssRelatorios.Size = new System.Drawing.Size(90, 24);
            this.tssRelatorios.Text = "Relatórios";
            // 
            // tssfrmRelatorios
            // 
            this.tssfrmRelatorios.Name = "tssfrmRelatorios";
            this.tssfrmRelatorios.Size = new System.Drawing.Size(159, 26);
            this.tssfrmRelatorios.Text = "Relatórios";
            this.tssfrmRelatorios.Click += new System.EventHandler(this.TssfrmRelatorios_Click);
            // 
            // apoioDoSistemaToolStripMenuItem
            // 
            this.apoioDoSistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssfrmPermissoes,
            this.tssfrmUsuario});
            this.apoioDoSistemaToolStripMenuItem.Name = "apoioDoSistemaToolStripMenuItem";
            this.apoioDoSistemaToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.apoioDoSistemaToolStripMenuItem.Text = "Configurações";
            // 
            // tssfrmPermissoes
            // 
            this.tssfrmPermissoes.Name = "tssfrmPermissoes";
            this.tssfrmPermissoes.Size = new System.Drawing.Size(177, 26);
            this.tssfrmPermissoes.Text = "Permissões";
            this.tssfrmPermissoes.Click += new System.EventHandler(this.apoioToolStripMenuItem_Click);
            // 
            // tssfrmUsuario
            // 
            this.tssfrmUsuario.Name = "tssfrmUsuario";
            this.tssfrmUsuario.Size = new System.Drawing.Size(177, 26);
            this.tssfrmUsuario.Text = "Criar Usuario";
            this.tssfrmUsuario.Click += new System.EventHandler(this.criarUsuarioToolStripMenuItem_Click);
            // 
            // jurídicoToolStripMenuItem
            // 
            this.jurídicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssfrmJuridico});
            this.jurídicoToolStripMenuItem.Name = "jurídicoToolStripMenuItem";
            this.jurídicoToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.jurídicoToolStripMenuItem.Text = "Jurídico";
            // 
            // tssfrmJuridico
            // 
            this.tssfrmJuridico.Name = "tssfrmJuridico";
            this.tssfrmJuridico.Size = new System.Drawing.Size(224, 26);
            this.tssfrmJuridico.Text = "Jurídico";
            this.tssfrmJuridico.Click += new System.EventHandler(this.TssfrmJuridico_Click);
            // 
            // mdi_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mdi_principal";
            this.ShowIcon = false;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Mdi_principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tssfrmCliente;
        private System.Windows.Forms.ToolStripMenuItem apoioDoSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tssfrmPermissoes;
        private System.Windows.Forms.ToolStripMenuItem tssfrmUsuario;
        private System.Windows.Forms.ToolStripMenuItem financeiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tssfrmFinanceiro;
        private System.Windows.Forms.ToolStripMenuItem tssRelatorios;
        private System.Windows.Forms.ToolStripMenuItem administracaoToolStrip;
        private System.Windows.Forms.ToolStripMenuItem tssfrmAdministracao;
        private System.Windows.Forms.ToolStripMenuItem tssfrmRelatorios;
        private System.Windows.Forms.ToolStripMenuItem jurídicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tssfrmJuridico;
    }
}