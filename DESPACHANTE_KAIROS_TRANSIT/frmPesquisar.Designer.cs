namespace APP_UI
{
    partial class frmPesquisar
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
            this.cboCampos = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtpMin = new System.Windows.Forms.DateTimePicker();
            this.dtpMax = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.cboValor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboCampos
            // 
            this.cboCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampos.FormattingEnabled = true;
            this.cboCampos.Location = new System.Drawing.Point(12, 39);
            this.cboCampos.Name = "cboCampos";
            this.cboCampos.Size = new System.Drawing.Size(242, 21);
            this.cboCampos.TabIndex = 0;
            this.cboCampos.SelectedIndexChanged += new System.EventHandler(this.cboCampos_SelectedIndexChanged);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 100);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(242, 20);
            this.txtValor.TabIndex = 1;
            this.txtValor.Visible = false;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 81);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Campo:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.Location = new System.Drawing.Point(173, 165);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(81, 36);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtpMin
            // 
            this.dtpMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMin.Location = new System.Drawing.Point(12, 100);
            this.dtpMin.Name = "dtpMin";
            this.dtpMin.Size = new System.Drawing.Size(96, 20);
            this.dtpMin.TabIndex = 5;
            this.dtpMin.Visible = false;
            // 
            // dtpMax
            // 
            this.dtpMax.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMax.Location = new System.Drawing.Point(158, 100);
            this.dtpMax.Name = "dtpMax";
            this.dtpMax.Size = new System.Drawing.Size(96, 20);
            this.dtpMax.TabIndex = 6;
            this.dtpMax.Visible = false;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(120, 104);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(26, 13);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Até:";
            this.lblData.Visible = false;
            // 
            // cboValor
            // 
            this.cboValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValor.FormattingEnabled = true;
            this.cboValor.Location = new System.Drawing.Point(12, 100);
            this.cboValor.Name = "cboValor";
            this.cboValor.Size = new System.Drawing.Size(242, 21);
            this.cboValor.TabIndex = 8;
            this.cboValor.Visible = false;
            // 
            // frmPesquisar
            // 
            this.AcceptButton = this.btnPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 213);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpMax);
            this.Controls.Add(this.dtpMin);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cboCampos);
            this.Controls.Add(this.cboValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPesquisar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar";
            this.Load += new System.EventHandler(this.frmPesquisar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCampos;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DateTimePicker dtpMin;
        private System.Windows.Forms.DateTimePicker dtpMax;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.ComboBox cboValor;
    }
}