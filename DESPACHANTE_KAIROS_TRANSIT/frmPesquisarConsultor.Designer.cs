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
            this.txtValor.Location = new System.Drawing.Point(10, 24);
            this.txtValor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(304, 20);
            this.txtValor.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parâmetro:";
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Location = new System.Drawing.Point(236, 124);
            this.btnLocalizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(77, 37);
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
            this.dtgDados.Location = new System.Drawing.Point(10, 166);
            this.dtgDados.MultiSelect = false;
            this.dtgDados.Name = "dtgDados";
            this.dtgDados.ReadOnly = true;
            this.dtgDados.RowHeadersWidth = 51;
            this.dtgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDados.Size = new System.Drawing.Size(302, 187);
            this.dtgDados.TabIndex = 426;
            this.dtgDados.DoubleClick += new System.EventHandler(this.DtgDados_DoubleClick);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(236, 358);
            this.btnSelecionar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(77, 37);
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
            this.grpOpcoes.Location = new System.Drawing.Point(10, 47);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Size = new System.Drawing.Size(303, 71);
            this.grpOpcoes.TabIndex = 428;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Text = "Parâmetros para a pesquisa:";
            // 
            // radFonetica
            // 
            this.radFonetica.AutoSize = true;
            this.radFonetica.Location = new System.Drawing.Point(180, 19);
            this.radFonetica.Name = "radFonetica";
            this.radFonetica.Size = new System.Drawing.Size(108, 17);
            this.radFonetica.TabIndex = 2;
            this.radFonetica.Text = "pesquisa fonética";
            this.radFonetica.UseVisualStyleBackColor = true;
            // 
            // radQualquerParte
            // 
            this.radQualquerParte.AutoSize = true;
            this.radQualquerParte.Location = new System.Drawing.Point(6, 42);
            this.radQualquerParte.Name = "radQualquerParte";
            this.radQualquerParte.Size = new System.Drawing.Size(151, 17);
            this.radQualquerParte.TabIndex = 1;
            this.radQualquerParte.Text = "em qualquer parte do texto";
            this.radQualquerParte.UseVisualStyleBackColor = true;
            // 
            // radInicio
            // 
            this.radInicio.AutoSize = true;
            this.radInicio.Checked = true;
            this.radInicio.Location = new System.Drawing.Point(6, 19);
            this.radInicio.Name = "radInicio";
            this.radInicio.Size = new System.Drawing.Size(142, 17);
            this.radInicio.TabIndex = 0;
            this.radInicio.TabStop = true;
            this.radInicio.Text = "a partir do início do texto";
            this.radInicio.UseVisualStyleBackColor = true;
            // 
            // frmPesquisarConsultor
            // 
            this.AcceptButton = this.btnLocalizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 405);
            this.Controls.Add(this.grpOpcoes);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.dtgDados);
            this.Controls.Add(this.btnLocalizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmPesquisarConsultor";
            this.ShowIcon = false;
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