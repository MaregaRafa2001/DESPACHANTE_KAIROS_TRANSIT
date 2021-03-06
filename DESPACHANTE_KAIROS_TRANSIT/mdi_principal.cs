﻿using System;
using BLL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace APP_UI
{
    public partial class mdi_principal : Form
    {
        public mdi_principal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmCliente(this);
                OpenTela(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenTela(Form Tela, bool Maximized = true)
        {
            try
            {
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == Tela.Name))
                {
                    return;
                }

                foreach (Form form in this.MdiChildren)
                {
                    if (form.Name.ToLower() == Tela.Name.ToLower())
                    {
                        form.WindowState = (Maximized ? FormWindowState.Maximized : FormWindowState.Normal);
                        form.Focus();
                        return;
                    }
                }

                //Valida o perfil do usuário no formulario
                if (SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == Tela.Name))
                {
                    //Instancia o formulário 
                    Tela = SelecionarForm(Tela);
                    //Definindo o mdiPrincial como pai
                    Tela.MdiParent = this;
                    //Mostrando o formulário
                    Tela.Show();
                    //Maximizando o formulário (se for maximizar antes do show utilizar o BringToFront() após o WindowState)
                    Tela.WindowState = (Maximized ? FormWindowState.Maximized : FormWindowState.Normal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao abrir a tela", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form SelecionarForm(Form nomeForm)
        {
            switch (nomeForm.Name)
            {
                case "frmCliente":
                    return new frmCliente(this);
                case "frmFinanceiro":
                    return new frmFinanceiro(this);
                case "frmAdministração":
                    return new frmAdministracao(this);
                case "frmAdministracao":
                    return new frmAdministracao(this);
                case "frmJuridico":
                    return new frmJuridico(this);
                case "frmRelatorios":
                    return new frmRelatorios(this);
                case "frmPermissoes":
                    return new frmPermissoes(this);
                case "frmUsuario":
                    return new frmUsuario(this);
                case "frmFormaPagamento":
                    return new frmFormaPagamento();
            }
            throw new Exception("Não conseguimos localizar a tela. Por favor reinicie o sistema. Caso o problema persista, entre em contato com o suporte");
        }

        private void criarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmUsuario(this);
                OpenTela(frm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void apoioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                //Nome do formulário que será instanciado
                Form frm = new frmPermissoes(this);
                OpenTela(frm, false);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mdi_principal_Load(object sender, EventArgs e)
        {
            try
            {
                SysBLL.grupo_acesso = new GRUPO_ACESSO_BLL().Listar(SysBLL.UserLogin.ID_PERFIL);
                Acesso(clienteToolStripMenuItem);
                Acesso(financeiroToolStripMenuItem);
                Acesso(administracaoToolStrip);
                Acesso(jurídicoToolStripMenuItem);
                Acesso(apoioDoSistemaToolStripMenuItem);
                Acesso(tssRelatorios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao validar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void Acesso(ToolStripMenuItem toolStrip)
        {
            List<ToolStripItem> lista_menus_removidos = new List<ToolStripItem>();
            foreach (ToolStripItem tela in toolStrip.DropDownItems)
            {
                if (SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == tela.Name.Substring(3, tela.Name.Length - 3)))
                    tela.Visible = true;
                else
                    lista_menus_removidos.Add(tela);
            }

            foreach (ToolStripItem tela in lista_menus_removidos)
            {
                toolStrip.DropDownItems.Remove(tela);
            }

            if (toolStrip.DropDownItems.Count == 0)
                toolStrip.Visible = false;

        }

        private void AdminstracaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmAdministracao(this);
                OpenTela(frm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TssfrmRelatorios_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmRelatorios(this);
                OpenTela(frm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TssfrmFinanceiro_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmFinanceiro(this);
                OpenTela(frm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TssfrmJuridico_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmJuridico(this);
                OpenTela(frm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TssFormaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form frm = new frmFormaPagamento();
                OpenTela(frm);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

