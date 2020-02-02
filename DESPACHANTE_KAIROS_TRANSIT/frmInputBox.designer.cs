namespace APP_UI
{
    partial class frmInputBox
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
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.combo = new System.Windows.Forms.ComboBox();
            this.mskValor = new System.Windows.Forms.MaskedTextBox();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.cboBoolean = new System.Windows.Forms.ComboBox();
            this.cboConsulta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 80);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(397, 20);
            this.txtValor.TabIndex = 5;
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Location = new System.Drawing.Point(12, 11);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(318, 63);
            this.txtMsg.TabIndex = 7;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(348, 40);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(61, 23);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(348, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(61, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // combo
            // 
            this.combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(12, 79);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(397, 21);
            this.combo.TabIndex = 9;
            this.combo.Visible = false;
            // 
            // mskValor
            // 
            this.mskValor.Location = new System.Drawing.Point(12, 80);
            this.mskValor.Name = "mskValor";
            this.mskValor.Size = new System.Drawing.Size(397, 20);
            this.mskValor.TabIndex = 4;
            this.mskValor.Visible = false;
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.Location = new System.Drawing.Point(39, 79);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(160, 20);
            this.dtpDataInicio.TabIndex = 10;
            this.dtpDataInicio.Visible = false;
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.Location = new System.Drawing.Point(246, 80);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(163, 20);
            this.dtpDataFim.TabIndex = 11;
            this.dtpDataFim.Visible = false;
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(12, 83);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(21, 13);
            this.lblDe.TabIndex = 13;
            this.lblDe.Text = "De";
            this.lblDe.Visible = false;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(217, 83);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(23, 13);
            this.lblAte.TabIndex = 454;
            this.lblAte.Text = "Até";
            this.lblAte.Visible = false;
            // 
            // cboBoolean
            // 
            this.cboBoolean.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoolean.FormattingEnabled = true;
            this.cboBoolean.Location = new System.Drawing.Point(12, 78);
            this.cboBoolean.Name = "cboBoolean";
            this.cboBoolean.Size = new System.Drawing.Size(397, 21);
            this.cboBoolean.TabIndex = 455;
            this.cboBoolean.Visible = false;
            // 
            // cboConsulta
            // 
            this.cboConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsulta.FormattingEnabled = true;
            this.cboConsulta.Location = new System.Drawing.Point(12, 78);
            this.cboConsulta.Name = "cboConsulta";
            this.cboConsulta.Size = new System.Drawing.Size(397, 21);
            this.cboConsulta.TabIndex = 456;
            this.cboConsulta.Visible = false;
            // 
            // frmInputBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 110);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.dtpDataInicio);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.cboConsulta);
            this.Controls.Add(this.cboBoolean);
            this.Controls.Add(this.dtpDataFim);
            this.Controls.Add(this.mskValor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInputBox";
            this.Load += new System.EventHandler(this.frmInputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtValor;
        public System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.ComboBox combo;
        public System.Windows.Forms.MaskedTextBox mskValor;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.ComboBox cboBoolean;
        private System.Windows.Forms.ComboBox cboConsulta;
    }
}