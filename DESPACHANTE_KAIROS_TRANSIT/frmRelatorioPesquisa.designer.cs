namespace APP_UI
{
    partial class frmRelatorioPesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioPesquisa));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabListaRelatorios = new System.Windows.Forms.TabPage();
            this.lvwFiltros = new System.Windows.Forms.ListView();
            this.colFiltros = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tspFiltros = new System.Windows.Forms.ToolStrip();
            this.tsbFiltroPlay = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroDel = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltroEdit = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabGerarRelatorio = new System.Windows.Forms.TabPage();
            this.btnGerarHtml = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGroupBy = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNOME = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtListaHTML2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.txtListaHTML1 = new System.Windows.Forms.TextBox();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.staUsuario = new System.Windows.Forms.StatusStrip();
            this.tssErro = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMSG = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabListaRelatorios.SuspendLayout();
            this.tspFiltros.SuspendLayout();
            this.tabGerarRelatorio.SuspendLayout();
            this.staUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabListaRelatorios);
            this.tabControl1.Controls.Add(this.tabGerarRelatorio);
            this.tabControl1.Location = new System.Drawing.Point(13, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1029, 636);
            this.tabControl1.TabIndex = 0;
            // 
            // tabListaRelatorios
            // 
            this.tabListaRelatorios.Controls.Add(this.lvwFiltros);
            this.tabListaRelatorios.Controls.Add(this.tspFiltros);
            this.tabListaRelatorios.Controls.Add(this.label7);
            this.tabListaRelatorios.Controls.Add(this.label6);
            this.tabListaRelatorios.Location = new System.Drawing.Point(4, 25);
            this.tabListaRelatorios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabListaRelatorios.Name = "tabListaRelatorios";
            this.tabListaRelatorios.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabListaRelatorios.Size = new System.Drawing.Size(1021, 607);
            this.tabListaRelatorios.TabIndex = 0;
            this.tabListaRelatorios.Text = "Lista de relatórios";
            this.tabListaRelatorios.UseVisualStyleBackColor = true;
            // 
            // lvwFiltros
            // 
            this.lvwFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwFiltros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFiltros});
            this.lvwFiltros.FullRowSelect = true;
            this.lvwFiltros.GridLines = true;
            this.lvwFiltros.HideSelection = false;
            this.lvwFiltros.Location = new System.Drawing.Point(11, 62);
            this.lvwFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 8, 7);
            this.lvwFiltros.Name = "lvwFiltros";
            this.lvwFiltros.Size = new System.Drawing.Size(967, 536);
            this.lvwFiltros.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwFiltros.TabIndex = 7;
            this.lvwFiltros.UseCompatibleStateImageBehavior = false;
            this.lvwFiltros.View = System.Windows.Forms.View.Details;
            this.lvwFiltros.DoubleClick += new System.EventHandler(this.LvwFiltros_DoubleClick);
            // 
            // colFiltros
            // 
            this.colFiltros.Text = "Filtros / Consultas";
            this.colFiltros.Width = 605;
            // 
            // tspFiltros
            // 
            this.tspFiltros.BackColor = System.Drawing.SystemColors.Window;
            this.tspFiltros.Dock = System.Windows.Forms.DockStyle.None;
            this.tspFiltros.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspFiltros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFiltroPlay,
            this.tsbFiltroAdd,
            this.tsbFiltroDel,
            this.tsbFiltroEdit});
            this.tspFiltros.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.tspFiltros.Location = new System.Drawing.Point(985, 63);
            this.tspFiltros.Name = "tspFiltros";
            this.tspFiltros.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspFiltros.Size = new System.Drawing.Size(40, 132);
            this.tspFiltros.TabIndex = 6;
            this.tspFiltros.Text = "toolStrip1";
            // 
            // tsbFiltroPlay
            // 
            this.tsbFiltroPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltroPlay.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiltroPlay.Image")));
            this.tsbFiltroPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroPlay.Name = "tsbFiltroPlay";
            this.tsbFiltroPlay.Size = new System.Drawing.Size(29, 24);
            this.tsbFiltroPlay.Text = "Executar (F5)";
            this.tsbFiltroPlay.Click += new System.EventHandler(this.TsbFiltroPlay_Click);
            // 
            // tsbFiltroAdd
            // 
            this.tsbFiltroAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltroAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiltroAdd.Image")));
            this.tsbFiltroAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroAdd.Name = "tsbFiltroAdd";
            this.tsbFiltroAdd.Size = new System.Drawing.Size(29, 24);
            this.tsbFiltroAdd.Text = "Adicionar";
            this.tsbFiltroAdd.Click += new System.EventHandler(this.TsbFiltroAdd_Click);
            // 
            // tsbFiltroDel
            // 
            this.tsbFiltroDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltroDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiltroDel.Image")));
            this.tsbFiltroDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroDel.Name = "tsbFiltroDel";
            this.tsbFiltroDel.Size = new System.Drawing.Size(29, 24);
            this.tsbFiltroDel.Text = "Remover";
            this.tsbFiltroDel.Visible = false;
            this.tsbFiltroDel.Click += new System.EventHandler(this.TsbFiltroDel_Click);
            // 
            // tsbFiltroEdit
            // 
            this.tsbFiltroEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltroEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiltroEdit.Image")));
            this.tsbFiltroEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltroEdit.Name = "tsbFiltroEdit";
            this.tsbFiltroEdit.Size = new System.Drawing.Size(29, 24);
            this.tsbFiltroEdit.Text = "Alterar";
            this.tsbFiltroEdit.Click += new System.EventHandler(this.TsbFiltroEdit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Lista de relatórios:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(972, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Clique duas vezes sobre um filtro para gerar um relatório";
            // 
            // tabGerarRelatorio
            // 
            this.tabGerarRelatorio.Controls.Add(this.btnGerarHtml);
            this.tabGerarRelatorio.Controls.Add(this.label9);
            this.tabGerarRelatorio.Controls.Add(this.txtGroupBy);
            this.tabGerarRelatorio.Controls.Add(this.txtID);
            this.tabGerarRelatorio.Controls.Add(this.txtNOME);
            this.tabGerarRelatorio.Controls.Add(this.label8);
            this.tabGerarRelatorio.Controls.Add(this.btnAlterar);
            this.tabGerarRelatorio.Controls.Add(this.btnAdicionar);
            this.tabGerarRelatorio.Controls.Add(this.label5);
            this.tabGerarRelatorio.Controls.Add(this.label4);
            this.tabGerarRelatorio.Controls.Add(this.txtListaHTML2);
            this.tabGerarRelatorio.Controls.Add(this.label3);
            this.tabGerarRelatorio.Controls.Add(this.label2);
            this.tabGerarRelatorio.Controls.Add(this.label1);
            this.tabGerarRelatorio.Controls.Add(this.txtQuery);
            this.tabGerarRelatorio.Controls.Add(this.txtListaHTML1);
            this.tabGerarRelatorio.Controls.Add(this.txtHTML);
            this.tabGerarRelatorio.Location = new System.Drawing.Point(4, 25);
            this.tabGerarRelatorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGerarRelatorio.Name = "tabGerarRelatorio";
            this.tabGerarRelatorio.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGerarRelatorio.Size = new System.Drawing.Size(1021, 607);
            this.tabGerarRelatorio.TabIndex = 1;
            this.tabGerarRelatorio.Text = "Gerar relatório";
            this.tabGerarRelatorio.UseVisualStyleBackColor = true;
            // 
            // btnGerarHtml
            // 
            this.btnGerarHtml.Location = new System.Drawing.Point(412, 82);
            this.btnGerarHtml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGerarHtml.Name = "btnGerarHtml";
            this.btnGerarHtml.Size = new System.Drawing.Size(100, 28);
            this.btnGerarHtml.TabIndex = 25;
            this.btnGerarHtml.Text = "Gerar Html";
            this.btnGerarHtml.UseVisualStyleBackColor = true;
            this.btnGerarHtml.Click += new System.EventHandler(this.BtnGerarHtml_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 553);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Campos para agrupar:";
            // 
            // txtGroupBy
            // 
            this.txtGroupBy.Location = new System.Drawing.Point(13, 574);
            this.txtGroupBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGroupBy.Name = "txtGroupBy";
            this.txtGroupBy.Size = new System.Drawing.Size(523, 22);
            this.txtGroupBy.TabIndex = 23;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(915, 28);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 22;
            this.txtID.Visible = false;
            // 
            // txtNOME
            // 
            this.txtNOME.Location = new System.Drawing.Point(13, 28);
            this.txtNOME.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNOME.Name = "txtNOME";
            this.txtNOME.Size = new System.Drawing.Size(1001, 22);
            this.txtNOME.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Nome do relatório:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlterar.Location = new System.Drawing.Point(899, 558);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(116, 42);
            this.btnAlterar.TabIndex = 19;
            this.btnAlterar.Text = "Cancelar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdicionar.Location = new System.Drawing.Point(775, 558);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(116, 42);
            this.btnAdicionar.TabIndex = 18;
            this.btnAdicionar.Text = "Salvar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.BtnAdicionar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(933, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "String 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "String 1";
            // 
            // txtListaHTML2
            // 
            this.txtListaHTML2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtListaHTML2.Location = new System.Drawing.Point(543, 249);
            this.txtListaHTML2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtListaHTML2.Multiline = true;
            this.txtListaHTML2.Name = "txtListaHTML2";
            this.txtListaHTML2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtListaHTML2.Size = new System.Drawing.Size(471, 160);
            this.txtListaHTML2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "String HTML para cada linha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "String HTML:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "String SQL:";
            // 
            // txtQuery
            // 
            this.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuery.Location = new System.Drawing.Point(13, 430);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuery.Size = new System.Drawing.Size(1001, 121);
            this.txtQuery.TabIndex = 11;
            // 
            // txtListaHTML1
            // 
            this.txtListaHTML1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtListaHTML1.Location = new System.Drawing.Point(543, 80);
            this.txtListaHTML1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtListaHTML1.Multiline = true;
            this.txtListaHTML1.Name = "txtListaHTML1";
            this.txtListaHTML1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtListaHTML1.Size = new System.Drawing.Size(471, 162);
            this.txtListaHTML1.TabIndex = 10;
            // 
            // txtHTML
            // 
            this.txtHTML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHTML.Location = new System.Drawing.Point(13, 80);
            this.txtHTML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHTML.Multiline = true;
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHTML.Size = new System.Drawing.Size(523, 323);
            this.txtHTML.TabIndex = 9;
            // 
            // staUsuario
            // 
            this.staUsuario.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.staUsuario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssErro,
            this.tssMSG});
            this.staUsuario.Location = new System.Drawing.Point(0, 662);
            this.staUsuario.Name = "staUsuario";
            this.staUsuario.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.staUsuario.ShowItemToolTips = true;
            this.staUsuario.Size = new System.Drawing.Size(1049, 22);
            this.staUsuario.SizingGrip = false;
            this.staUsuario.TabIndex = 420;
            this.staUsuario.Text = "statusStrip1";
            // 
            // tssErro
            // 
            this.tssErro.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssErro.ForeColor = System.Drawing.Color.Red;
            this.tssErro.Image = ((System.Drawing.Image)(resources.GetObject("tssErro.Image")));
            this.tssErro.Name = "tssErro";
            this.tssErro.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.tssErro.Size = new System.Drawing.Size(80, 24);
            this.tssErro.Text = "Erro";
            this.tssErro.Visible = false;
            // 
            // tssMSG
            // 
            this.tssMSG.Name = "tssMSG";
            this.tssMSG.Size = new System.Drawing.Size(0, 16);
            this.tssMSG.Visible = false;
            // 
            // frmRelatorioPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 684);
            this.Controls.Add(this.staUsuario);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmRelatorioPesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Pesquisa";
            this.Load += new System.EventHandler(this.FrmRelatorioPesquisa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabListaRelatorios.ResumeLayout(false);
            this.tabListaRelatorios.PerformLayout();
            this.tspFiltros.ResumeLayout(false);
            this.tspFiltros.PerformLayout();
            this.tabGerarRelatorio.ResumeLayout(false);
            this.tabGerarRelatorio.PerformLayout();
            this.staUsuario.ResumeLayout(false);
            this.staUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabListaRelatorios;
        private System.Windows.Forms.TabPage tabGerarRelatorio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtListaHTML2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TextBox txtListaHTML1;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtNOME;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip tspFiltros;
        private System.Windows.Forms.ToolStripButton tsbFiltroPlay;
        private System.Windows.Forms.ToolStripButton tsbFiltroAdd;
        private System.Windows.Forms.ToolStripButton tsbFiltroEdit;
        private System.Windows.Forms.ToolStripButton tsbFiltroDel;
        private System.Windows.Forms.ListView lvwFiltros;
        private System.Windows.Forms.ColumnHeader colFiltros;
        private System.Windows.Forms.StatusStrip staUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tssErro;
        private System.Windows.Forms.ToolStripStatusLabel tssMSG;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGroupBy;
        private System.Windows.Forms.Button btnGerarHtml;
    }
}