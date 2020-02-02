using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace APP_UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        int intTentativas = 0;
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                LOGIN_DTO login = new LOGIN_DTO();
                login.LOGIN = txtLogin.Text.Trim();
                login.PASS = txtSenha.Text;

                //Recuperando dados
                login = new LOGIN_BLL().Get_User_By_Login(login);

                if (login.ID != 0)
                {
                    SysBLL.UserLogin = login;
                    this.DialogResult = (DialogResult.OK);

                }
                else
                {
                    intTentativas += 1;
                    if (intTentativas <= 3)
                    {
                        MessageBox.Show("Usuário e/ou senha inválida!", "Erro de acesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Focus();
                        txtSenha.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("Usuário e/ou senha inválida\nNúmero de tentativas excedidas!", "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro no Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem a certeza que deseja sair?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (escolha == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnEntrar;
        }
    }
}
