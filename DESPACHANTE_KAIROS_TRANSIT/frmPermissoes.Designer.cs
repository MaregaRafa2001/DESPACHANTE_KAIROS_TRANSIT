namespace APP_UI
{
    partial class frmPermissoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissoes));
            this.tss = new System.Windows.Forms.ToolStrip();
            this.tssMSG = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Telas = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trwTelasSelecionadas = new System.Windows.Forms.TreeView();
            this.trwTelasDisponiveis = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPerfil = new System.Windows.Forms.ComboBox();
            this.tss.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Telas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tss
            // 
            this.tss.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tss.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMSG});
            this.tss.Location = new System.Drawing.Point(0, 579);
            this.tss.Name = "tss";
            this.tss.Size = new System.Drawing.Size(890, 25);
            this.tss.TabIndex = 54;
            this.tss.Text = "toolStrip1";
            // 
            // tssMSG
            // 
            this.tssMSG.ForeColor = System.Drawing.Color.Green;
            this.tssMSG.Name = "tssMSG";
            this.tssMSG.Size = new System.Drawing.Size(0, 22);
            this.tssMSG.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Telas);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 558);
            this.tabControl1.TabIndex = 55;
            // 
            // Telas
            // 
            this.Telas.Controls.Add(this.label4);
            this.Telas.Controls.Add(this.btnCancelar);
            this.Telas.Controls.Add(this.btnAplicar);
            this.Telas.Controls.Add(this.label3);
            this.Telas.Controls.Add(this.label2);
            this.Telas.Controls.Add(this.trwTelasSelecionadas);
            this.Telas.Controls.Add(this.trwTelasDisponiveis);
            this.Telas.Controls.Add(this.label1);
            this.Telas.Controls.Add(this.cboPerfil);
            this.Telas.Location = new System.Drawing.Point(4, 25);
            this.Telas.Name = "Telas";
            this.Telas.Padding = new System.Windows.Forms.Padding(3);
            this.Telas.Size = new System.Drawing.Size(864, 529);
            this.Telas.TabIndex = 0;
            this.Telas.Text = "Telas";
            this.Telas.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 64;
            this.label4.Text = "Telas com permissão:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(737, 484);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 38);
            this.btnCancelar.TabIndex = 63;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(622, 484);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(107, 38);
            this.btnAplicar.TabIndex = 62;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(836, 48);
            this.label3.TabIndex = 61;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Telas sem permissão:";
            // 
            // trwTelasSelecionadas
            // 
            this.trwTelasSelecionadas.Location = new System.Drawing.Point(428, 126);
            this.trwTelasSelecionadas.Margin = new System.Windows.Forms.Padding(4);
            this.trwTelasSelecionadas.Name = "trwTelasSelecionadas";
            this.trwTelasSelecionadas.Size = new System.Drawing.Size(417, 347);
            this.trwTelasSelecionadas.TabIndex = 59;
            this.trwTelasSelecionadas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrwTelasSelecionadas_AfterSelect);
            // 
            // trwTelasDisponiveis
            // 
            this.trwTelasDisponiveis.Location = new System.Drawing.Point(6, 126);
            this.trwTelasDisponiveis.Margin = new System.Windows.Forms.Padding(4);
            this.trwTelasDisponiveis.Name = "trwTelasDisponiveis";
            this.trwTelasDisponiveis.Size = new System.Drawing.Size(414, 347);
            this.trwTelasDisponiveis.TabIndex = 58;
            this.trwTelasDisponiveis.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrwTelasDisponiveis_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Perfil";
            // 
            // cboPerfil
            // 
            this.cboPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfil.FormattingEnabled = true;
            this.cboPerfil.Location = new System.Drawing.Point(6, 74);
            this.cboPerfil.Margin = new System.Windows.Forms.Padding(4);
            this.cboPerfil.Name = "cboPerfil";
            this.cboPerfil.Size = new System.Drawing.Size(839, 24);
            this.cboPerfil.TabIndex = 56;
            this.cboPerfil.SelectedIndexChanged += new System.EventHandler(this.CboPerfil_SelectedIndexChanged);
            // 
            // frmPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 604);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPermissoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permissões";
            this.Load += new System.EventHandler(this.FrmApoio_Load);
            this.tss.ResumeLayout(false);
            this.tss.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Telas.ResumeLayout(false);
            this.Telas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tss;
        private System.Windows.Forms.ToolStripLabel tssMSG;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Telas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView trwTelasSelecionadas;
        private System.Windows.Forms.TreeView trwTelasDisponiveis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPerfil;
    }
}