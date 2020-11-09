using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public partial class frmObservacoes : Form
    {
        public frmObservacoes(string Observacao)
        {
            InitializeComponent();
            txtObservacoes.AppendText(Observacao);
            txtObservacoes.Select(txtObservacoes.TextLength + 1, 0);
        }
    }
}
