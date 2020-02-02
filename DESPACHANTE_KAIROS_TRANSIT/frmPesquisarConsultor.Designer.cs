namespace APP_UI
{
    partial class frmPesquisarConsultor
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
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.dtgDados = new System.Windows.Forms.DataGridView();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.grpOpcoes = new System.Windows.Forms.GroupBox();
            this.radFonetica = new System.Windows.Forms.RadioButton();
            this.radQualquerParte = new System.Windows.Forms.RadioButton();
            this.radInicio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDados)).BeginInit();
            this.grpOpcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(13, 29);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(404, 22);
            this.txtValor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parâmetro:";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Location = new System.Drawing.Point(314, 152);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(103, 45);
            this.btnLocalizar.TabIndex = 2;
            this.btnLocalizar.Text = "Localizar";
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.BtnLocalizar_Click);
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
            this.dtgDados.Location = new System.Drawing.Point(13, 204);
            this.dtgDados.Margin = new System.Windows.Forms.Padding(4);
            this.dtgDados.MultiSelect = false;
            this.dtgDados.Name = "dtgDados";
            this.dtgDados.ReadOnly = true;
            this.dtgDados.RowHeadersWidth = 51;
            this.dtgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDados.Size = new System.Drawing.Size(403, 230);
            this.dtgDados.TabIndex = 426;
            this.dtgDados.DoubleClick += new System.EventHandler(this.DtgDados_DoubleClick);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(314, 441);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(103, 45);
            this.btnSelecionar.TabIndex = 427;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.BtnSelecionar_Click);
            // 
            // grpOpcoes
            // 
            this.grpOpcoes.Controls.Add(this.radFonetica);
            this.grpOpcoes.Controls.Add(this.radQualquerParte);
            this.grpOpcoes.Controls.Add(this.radInicio);
            this.grpOpcoes.Location = new System.Drawing.Point(13, 58);
            this.grpOpcoes.Margin = new System.Windows.Forms.Padding(4);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Padding = new System.Windows.Forms.Padding(4);
            this.grpOpcoes.Size = new System.Drawing.Size(404, 87);
            this.grpOpcoes.TabIndex = 428;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Text = "Parâmetros para a pesquisa:";
            // 
            // radFonetica
            // 
            this.radFonetica.AutoSize = true;
            this.radFonetica.Location = new System.Drawing.Point(240, 23);
            this.radFonetica.Margin = new System.Windows.Forms.Padding(4);
            this.radFonetica.Name = "radFonetica";
            this.radFonetica.Size = new System.Drawing.Size(140, 21);
            this.radFonetica.TabIndex = 2;
            this.radFonetica.Text = "pesquisa fonética";
            this.radFonetica.UseVisualStyleBackColor = true;
            // 
            // radQualquerParte
            // 
            this.radQualquerParte.AutoSize = true;
            this.radQualquerParte.Location = new System.Drawing.Point(8, 52);
            this.radQualquerParte.Margin = new System.Windows.Forms.Padding(4);
            this.radQualquerParte.Name = "radQualquerParte";
            this.radQualquerParte.Size = new System.Drawing.Size(199, 21);
            this.radQualquerParte.TabIndex = 1;
            this.radQualquerParte.Text = "em qualquer parte do texto";
            this.radQualquerParte.UseVisualStyleBackColor = true;
            // 
            // radInicio
            // 
            this.radInicio.AutoSize = true;
            this.radInicio.Checked = true;
            this.radInicio.Location = new System.Drawing.Point(8, 23);
            this.radInicio.Margin = new System.Windows.Forms.Padding(4);
            this.radInicio.Name = "radInicio";
            this.radInicio.Size = new System.Drawing.Size(184, 21);
            this.radInicio.TabIndex = 0;
            this.radInicio.TabStop = true;
            this.radInicio.Text = "a partir do início do texto";
            this.radInicio.UseVisualStyleBackColor = true;
            // 
            // frmPesquisarConsultor
            // 
            this.AcceptButton = this.btnLocalizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 498);
            this.Controls.Add(this.grpOpcoes);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.dtgDados);
            this.Controls.Add(this.btnLocalizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPesquisarConsultor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar";
            this.Load += new System.EventHandler(this.FrmPesquisarConsultor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDados)).EndInit();
            this.grpOpcoes.ResumeLayout(false);
            this.grpOpcoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.DataGridView dtgDados;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.GroupBox grpOpcoes;
        private System.Windows.Forms.RadioButton radFonetica;
        private System.Windows.Forms.RadioButton radQualquerParte;
        private System.Windows.Forms.RadioButton radInicio;
    }
}