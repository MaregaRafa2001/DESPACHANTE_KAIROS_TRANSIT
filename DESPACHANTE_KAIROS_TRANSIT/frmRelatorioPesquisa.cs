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
    public partial class frmRelatorioPesquisa : Form
    {
        RELATORIOS_DTO relatorios = new RELATORIOS_DTO();
        RELATORIOS_BLL RELATORIOS_BLL = new RELATORIOS_BLL();
        frmRelatorios frmRelatorios;
        string[] split;
        bool AlterarRegistro = false;

        public frmRelatorioPesquisa(frmRelatorios frmRelatorios)
        {
            InitializeComponent();
            this.frmRelatorios = frmRelatorios;
        }

        private void FrmRelatorioPesquisa_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (RELATORIOS_DTO relatorio in RELATORIOS_BLL.Listar())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = relatorio.NOME;
                    item.Tag = relatorio.ID;
                    item.ImageKey = "consulta"; //Icone

                    if (item.Tag.ToString() == frmRelatorios.relatorio_dto.ID.ToString())
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                    }
                    lvwFiltros.Items.Add(item);
                }
                lvwFiltros.Select();

                txtNOME.Text = frmRelatorios.relatorio_dto.NOME;
                txtHTML.Text = frmRelatorios.relatorio_dto.HTML;
                txtListaHTML1.Text = frmRelatorios.relatorio_dto.LISTAHTML1;
                txtListaHTML2.Text = frmRelatorios.relatorio_dto.LISTAHTML2;
                txtQuery.Text = frmRelatorios.relatorio_dto.QUERY;


                for (int ix = 0; ix < lvwFiltros.Items.Count; ++ix)
                {
                    var item = lvwFiltros.Items[ix];
                    item.BackColor = (ix % 2 == 0) ? Color.AliceBlue : SystemColors.Window;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizaDTO();
                if (AlterarRegistro)
                    relatorios.Operacao = SysDTO.Operacoes.Alteracao;
                int result = RELATORIOS_BLL.Registrar(relatorios);
                if (relatorios.Operacao == SysDTO.Operacoes.Inclusao)
                {
                    if (result > 0)
                        MessageBox.Show("Relatório incluído com sucesso", "Registro incluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Não foi possível incluir o relatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (relatorios.Operacao == SysDTO.Operacoes.Alteracao)
                {
                    if (result > 0)
                        MessageBox.Show("Relatório alterado com sucesso", "Registro alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Não foi possível alterado o relatório", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                try
                {
                    lvwFiltros.Items.Clear();
                    foreach (RELATORIOS_DTO relatorio in RELATORIOS_BLL.Listar())
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = relatorio.NOME;
                        item.Tag = relatorio.ID;
                        item.ImageKey = "consulta"; //Icone

                        if (item.Tag.ToString() == frmRelatorios.relatorio_dto.ID.ToString())
                        {
                            item.Selected = true;
                            item.EnsureVisible();
                        }
                        lvwFiltros.Items.Add(item);
                    }
                    lvwFiltros.Select();

                    txtNOME.Text = frmRelatorios.relatorio_dto.NOME;
                    txtHTML.Text = frmRelatorios.relatorio_dto.HTML;
                    txtListaHTML1.Text = frmRelatorios.relatorio_dto.LISTAHTML1;
                    txtListaHTML2.Text = frmRelatorios.relatorio_dto.LISTAHTML2;
                    txtQuery.Text = frmRelatorios.relatorio_dto.QUERY;
                    txtGroupBy.Text = frmRelatorios.relatorio_dto.COLUNAS_GROUP;
                    txtID.Text = frmRelatorios.relatorio_dto.ID.ToString();


                    for (int ix = 0; ix < lvwFiltros.Items.Count; ++ix)
                    {
                        var item = lvwFiltros.Items[ix];
                        item.BackColor = (ix % 2 == 0) ? Color.AliceBlue : SystemColors.Window;
                    }

                    tabControl1.SelectedTab = tabListaRelatorios;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizaDTO()
        {
            try
            {
                relatorios.ID = txtID.Text == "" ? 0 : Convert.ToInt32(txtID.Text);
                relatorios.NOME = txtNOME.Text;
                relatorios.GERARHTML = true;
                relatorios.HTML = txtHTML.Text;
                relatorios.LISTAHTML1 = txtListaHTML1.Text;
                relatorios.LISTAHTML2 = txtListaHTML2.Text;
                relatorios.QUERY = txtQuery.Text;
                relatorios.COLUNAS_GROUP = txtGroupBy.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void LimparAbaRelatorios()
        {
            try
            {
                txtNOME.Text = "";
                txtHTML.Text = "";
                txtListaHTML1.Text = "";
                txtListaHTML2.Text = "";
                txtQuery.Text = "";
                txtGroupBy.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void TsbFiltroAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AlterarRegistro = false;
                LimparAbaRelatorios();
                tabGerarRelatorio.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbFiltroDel_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("Tem certeza que deseja excluir o relatório " + frmRelatorios.relatorio_dto.NOME + "?", "Exclusão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)) == DialogResult.Yes)
                {
                    bool result = new RELATORIOS_BLL().Excluir(frmRelatorios.relatorio_dto.ID);
                    if (result)
                        MessageBox.Show("Relatório excluído com sucesso.", "Relatório excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Não foi possível excluir o relatório.", "Ação inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lvwFiltros.SelectedItems[0].Remove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbFiltroEdit_Click(object sender, EventArgs e)
        {
            try
            {
                AlterarRegistro = true;
                if (lvwFiltros.Items.Count == 0)
                {
                    return;
                }
                PopularGrid(int.Parse(lvwFiltros.SelectedItems[0].Tag.ToString()), true);
                tabControl1.SelectedTab = tabGerarRelatorio;
                txtListaHTML1.Text = frmRelatorios.relatorio_dto.LISTAHTML1;
                txtListaHTML2.Text = frmRelatorios.relatorio_dto.LISTAHTML2;
                txtNOME.Text = frmRelatorios.relatorio_dto.NOME;
                txtQuery.Text = frmRelatorios.relatorio_dto.QUERY;
                txtHTML.Text = frmRelatorios.relatorio_dto.HTML;
                txtGroupBy.Text = frmRelatorios.relatorio_dto.COLUNAS_GROUP;
                txtID.Text = frmRelatorios.relatorio_dto.ID.ToString();
                txtHTML.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível alterar o filtro" + Environment.NewLine + "Erro: " + ex.Message, "Erro ao alterar filtro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GeraInput(string Sql)
        {
            StringBuilder strMsgClear = new StringBuilder();
            string strLetter;
            int intLastPosition;
            string strSqlClear;
            bool comentario = false;
            strSqlClear = Sql;
            for (int i = 0; i < Sql.Trim().Length; i++)
            {
                strLetter = Sql.Trim().Substring(i, 1);
                strMsgClear.Append(strLetter);
                if (strLetter == "/")
                {
                    if (Sql.Trim().Substring(i, 2) == "/*")
                        comentario = true;
                    else if (Sql.Trim().Substring(i - 1, 2) == "*/")
                    {
                        comentario = false;
                        i++;
                        strLetter = Sql.Trim().Substring(i, 1);
                    }
                }
                if (!comentario)
                {
                    if (strLetter == "[")
                    {
                        strMsgClear.Clear();
                    }
                    if (strLetter == "]")
                    {
                        intLastPosition = i;
                        string tipo = "";
                        try
                        {
                            tipo = strMsgClear.ToString().Replace("]", "").Split(')')[1];
                        }
                        catch
                        {
                            tipo = "string";
                        }
                        frmInputBox frmInputBox = new frmInputBox(strMsgClear.ToString().Replace("]", ""), "Parâmetros", (string.IsNullOrEmpty(tipo) ? "string" : tipo));
                        frmInputBox.Valor = "";
                        if (frmInputBox.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        {
                            return ""; // Aborta Sql
                        }
                        if (!(tipo.ToUpper().Contains("TIPODATETIME")))
                            strSqlClear = strSqlClear.Replace("[" + strMsgClear.ToString().Replace("]", "") + "]", frmInputBox.Valor).Replace("\n", "").Replace("/n", "");
                        else
                        {
                            strSqlClear = strSqlClear.Replace("[" + strMsgClear.ToString().Replace("]", "") + "]", frmInputBox.Valor).Replace("\n", "").Replace("/n", "").Replace("TipoDatetime2", "").Replace("TipoDatetime", "");
                            strSqlClear = strSqlClear.Replace("[" + strMsgClear.ToString().Replace(tipo, "").Replace("]", "") + "]", frmInputBox.Valor).Replace("\n", "").Replace("/n", "").Replace("TipoDatetime2", "").Replace("TipoDatetime", "");
                        }
                    }
                }
            }
            return strSqlClear;
        }

        private void PopularGrid(int Id, bool SomenteCarregaDto = false, bool ReloadSql = false)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                this.Cursor = Cursors.WaitCursor;

                RELATORIOS_DTO relatorios = new RELATORIOS_DTO();

                tssMSG.Text = "Aguarde. Processando Dados...";
                tssMSG.Visible = true;
                Application.DoEvents();

                if (Id != 0)
                {
                    relatorios = new RELATORIOS_BLL().Get_Relatorio_By_Id(Id);
                    if (ReloadSql == true)
                    {
                        relatorios.ID = Id;
                        relatorios.LISTAHTML1 = txtListaHTML1.Text;
                        relatorios.LISTAHTML2 = txtListaHTML2.Text;
                        relatorios.NOME = txtNOME.Text;
                        relatorios.QUERY = txtQuery.Text;
                        relatorios.HTML = txtHTML.Text;
                        relatorios.COLUNAS_GROUP = txtGroupBy.Text;
                    }
                }
                else //String sql
                {
                    relatorios.LISTAHTML1 = txtListaHTML1.Text;
                    relatorios.LISTAHTML2 = txtListaHTML2.Text;
                    relatorios.NOME = txtNOME.Text;
                    relatorios.QUERY = txtQuery.Text;
                    relatorios.HTML = txtHTML.Text;
                    relatorios.COLUNAS_GROUP = txtGroupBy.Text;
                }

                //Atribui os inputbox a string sql
                if (SomenteCarregaDto == true)
                {
                    relatorios.SqlChanged = relatorios.QUERY;
                }
                else
                {
                    relatorios.SqlChanged = GeraInput(relatorios.QUERY);
                }
                //Se voltar o GeraInput = "" aborta a rotina
                if (relatorios.SqlChanged == "")
                {
                    return;
                }

                //Tranfere a DTO recuperada para a página main
                frmRelatorios.relatorio_dto = relatorios;

                //Se for apenas para carregar a DTO
                if (SomenteCarregaDto == true)
                {
                    return;
                }

                ////Monta o grid e recupera as colunas utilizadas para pesquisa
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(frmRelatorios.relatorio_dto.SqlChanged);
                frmRelatorios.dtgDados.DataSource = dtt; //Vincula o datatable ao datagrid

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                tssMSG.Visible = false;
            }
        }

        private void TsbFiltroPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwFiltros.Items.Count == 0)
                {
                    return;
                }
                //Se não houver nenhum item selecionado, seleciona o primeiro da lista
                if (lvwFiltros.SelectedItems.Count == 0)
                {
                    lvwFiltros.Items[0].Selected = true;
                }

                PopularGrid(int.Parse(lvwFiltros.SelectedItems[0].Tag.ToString()));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível executar o filtro selecionado" + Environment.NewLine + "Erro: " + ex.Message, "Erro ao executar filtro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LvwFiltros_DoubleClick(object sender, EventArgs e)
        {
            TsbFiltroPlay_Click(sender, e);
        }

        private void BtnGerarHtml_Click(object sender, EventArgs e)
        {
            if (txtHTML.Text.Length > 0)
            {
                if ((MessageBox.Show("Gerar um corpo html irá sobreescrever o que estiver escrito dentro desta caixa. Tem certeza que deseja continuar?", "Gerar html", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes))
                {
                    return;
                }
            }

            txtHTML.Text = "<html>" + System.Environment.NewLine;
            txtHTML.Text += "<head>" + System.Environment.NewLine;
            txtHTML.Text += "<title> </title>" + System.Environment.NewLine;
            txtHTML.Text += "    <style>" + System.Environment.NewLine;
            txtHTML.Text += "    </style>" + System.Environment.NewLine;
            txtHTML.Text += "</head>" + System.Environment.NewLine;
            txtHTML.Text += "<body>" + System.Environment.NewLine;
            txtHTML.Text += "" + System.Environment.NewLine;
            txtHTML.Text += "<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js\"></script>" + System.Environment.NewLine;
            txtHTML.Text += "<script>" + System.Environment.NewLine;
            txtHTML.Text += "</script>" + System.Environment.NewLine;
            txtHTML.Text += "</body>" + System.Environment.NewLine;
            txtHTML.Text += "</html>";
        }
    }
}
