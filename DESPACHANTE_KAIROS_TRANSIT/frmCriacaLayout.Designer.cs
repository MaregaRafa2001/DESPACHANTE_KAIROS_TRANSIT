namespace DESPACHANTE_KAIROS_TRANSIT
{
    partial class frmCriacaLayout
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
            this.pnlLayout9 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fase8_mskDataBaixaDePontos = new System.Windows.Forms.MaskedTextBox();
            this.fase8_mskDataFinalizacao = new System.Windows.Forms.MaskedTextBox();
            this.cboFase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLayout9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLayout9
            // 
            this.pnlLayout9.Controls.Add(this.groupBox8);
            this.pnlLayout9.Location = new System.Drawing.Point(6, 50);
            this.pnlLayout9.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLayout9.Name = "pnlLayout9";
            this.pnlLayout9.Size = new System.Drawing.Size(379, 68);
            this.pnlLayout9.TabIndex = 2;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.fase8_mskDataBaixaDePontos);
            this.groupBox8.Controls.Add(this.fase8_mskDataFinalizacao);
            this.groupBox8.Location = new System.Drawing.Point(6, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(360, 61);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Finalização";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(133, 18);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Data de baixa de pontos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data de finalização:";
            // 
            // fase8_mskDataBaixaDePontos
            // 
            this.fase8_mskDataBaixaDePontos.Location = new System.Drawing.Point(135, 35);
            this.fase8_mskDataBaixaDePontos.Margin = new System.Windows.Forms.Padding(2);
            this.fase8_mskDataBaixaDePontos.Mask = "00/00/0000";
            this.fase8_mskDataBaixaDePontos.Name = "fase8_mskDataBaixaDePontos";
            this.fase8_mskDataBaixaDePontos.Size = new System.Drawing.Size(124, 20);
            this.fase8_mskDataBaixaDePontos.TabIndex = 5;
            this.fase8_mskDataBaixaDePontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fase8_mskDataBaixaDePontos.ValidatingType = typeof(System.DateTime);
            // 
            // fase8_mskDataFinalizacao
            // 
            this.fase8_mskDataFinalizacao.Location = new System.Drawing.Point(7, 35);
            this.fase8_mskDataFinalizacao.Margin = new System.Windows.Forms.Padding(2);
            this.fase8_mskDataFinalizacao.Mask = "00/00/0000";
            this.fase8_mskDataFinalizacao.Name = "fase8_mskDataFinalizacao";
            this.fase8_mskDataFinalizacao.Size = new System.Drawing.Size(124, 20);
            this.fase8_mskDataFinalizacao.TabIndex = 4;
            this.fase8_mskDataFinalizacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fase8_mskDataFinalizacao.ValidatingType = typeof(System.DateTime);
            // 
            // cboFase
            // 
            this.cboFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFase.FormattingEnabled = true;
            this.cboFase.Location = new System.Drawing.Point(15, 26);
            this.cboFase.Margin = new System.Windows.Forms.Padding(2);
            this.cboFase.Name = "cboFase";
            this.cboFase.Size = new System.Drawing.Size(277, 21);
            this.cboFase.TabIndex = 537;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 536;
            this.label1.Text = "Fase:";
            // 
            // frmCriacaLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 430);
            this.Controls.Add(this.cboFase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlLayout9);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCriacaLayout";
            this.Text = "frmCriacaLayout";
            this.pnlLayout9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLayout9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox fase8_mskDataBaixaDePontos;
        private System.Windows.Forms.MaskedTextBox fase8_mskDataFinalizacao;
        private System.Windows.Forms.ComboBox cboFase;
        private System.Windows.Forms.Label label1;
    }
}