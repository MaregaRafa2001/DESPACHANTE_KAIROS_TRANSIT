namespace APP_UI
{
    partial class frmCad_Administracao_Fases
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFase = new System.Windows.Forms.ComboBox();
            this.mskData = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetalhe = new System.Windows.Forms.TabPage();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabDetalhe.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(373, 223);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 32);
            this.btnCancelar.TabIndex = 532;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(288, 223);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(80, 32);
            this.btnConfirmar.TabIndex = 531;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 534;
            this.label1.Text = "Fase:";
            // 
            // cboFase
            // 
            this.cboFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFase.FormattingEnabled = true;
            this.cboFase.Location = new System.Drawing.Point(10, 24);
            this.cboFase.Margin = new System.Windows.Forms.Padding(2);
            this.cboFase.Name = "cboFase";
            this.cboFase.Size = new System.Drawing.Size(326, 21);
            this.cboFase.TabIndex = 535;
            this.cboFase.SelectedIndexChanged += new System.EventHandler(this.cboFase_SelectedIndexChanged);
            // 
            // mskData
            // 
            this.mskData.Location = new System.Drawing.Point(340, 25);
            this.mskData.Margin = new System.Windows.Forms.Padding(2);
            this.mskData.Mask = "00/00/0000";
            this.mskData.Name = "mskData";
            this.mskData.Size = new System.Drawing.Size(101, 20);
            this.mskData.TabIndex = 536;
            this.mskData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskData.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 537;
            this.label2.Text = "Data:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDetalhe);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 141);
            this.tabControl1.TabIndex = 538;
            // 
            // tabDetalhe
            // 
            this.tabDetalhe.Controls.Add(this.lblDescricao);
            this.tabDetalhe.Location = new System.Drawing.Point(4, 22);
            this.tabDetalhe.Name = "tabDetalhe";
            this.tabDetalhe.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetalhe.Size = new System.Drawing.Size(416, 115);
            this.tabDetalhe.TabIndex = 0;
            this.tabDetalhe.Text = "Histórico";
            this.tabDetalhe.UseVisualStyleBackColor = true;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(7, 4);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(414, 108);
            this.lblDescricao.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtObservacao);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adicionar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(6, 6);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(404, 102);
            this.txtObservacao.TabIndex = 530;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(10, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 168);
            this.groupBox1.TabIndex = 539;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Observação";
            // 
            // frmCad_Administracao_Fases
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 265);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskData);
            this.Controls.Add(this.cboFase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCad_Administracao_Fases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fase do registro";
            this.Load += new System.EventHandler(this.FrmCad_Financeiro_Fases_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDetalhe.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFase;
        private System.Windows.Forms.MaskedTextBox mskData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDetalhe;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}