using BLL;
using DTO;
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
    public partial class frmCad_Usuario : Form
    {
        mdi_principal mdi_Principal = null;
        LOGIN_DTO usuario = new LOGIN_DTO();
        LOGIN_BLL login_bll = new LOGIN_BLL();
        public frmCad_Usuario(int ID)
        {
            InitializeComponent();
            PopularCombos();
            if (ID == 0)
            {
                 
            }
            else
            {
                usuario = login_bll.Selecione(ID);
                PopularDados();
                usuario.Operacao = SysDTO.Operacoes.Alteracao;
            }

        }

        void PopularDados()
        {
            try
            {
                txtNome.Text = usuario.NOME;
                txtLogin.Text = usuario.LOGIN;
                txtSenha.Text = usuario.PASS;
                cboPerfil.SelectedValue = usuario.ID_PERFIL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmCad_Usuario_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void PopularCombos()
        {
            try
            {
                cboPerfil.ValueMember = "ID";
                cboPerfil.DisplayMember = "DESCRICAO";
                cboPerfil.DataSource = new SYS_PERFIL_BLL().Listar();
                cboPerfil.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                AtualizaDTO();

                if (usuario.PASS != txtConfirmarsenha.Text)
                {
                    MessageBox.Show("Senhas não coincidem. Tente novamente", "Senhas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (usuario.Operacao == SysDTO.Operacoes.Inclusao)
                {
                    int? result = login_bll.Set_Login(usuario);
                    if (result > 0)
                    {
                        MessageBox.Show("Login incluído com sucesso", "Registro incluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        return;
                    }   
                    else
                    {
                        MessageBox.Show("Não foi possível incluir o registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (usuario.Operacao == SysDTO.Operacoes.Alteracao)
                {
                    bool result = login_bll.Update_Login(usuario);
                    if (result)
                    {
                        MessageBox.Show("Login alterado com sucesso", "Registro incluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível alterar o registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AtualizaDTO()
        {
            try
            {
                usuario.ID_PERFIL = Convert.ToInt32(cboPerfil.SelectedValue);
                usuario.LOGIN = txtLogin.Text;
                usuario.NOME = txtNome.Text;
                usuario.PASS = txtSenha.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
