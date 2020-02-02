using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    public partial class frmCad_Cliente : Form
    {
        public CLIENTE_DTO CLIENTE_DTO = null;
        CLIENTE_BLL CLIENTE_BLL = new CLIENTE_BLL();
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();
        List<FINANCEIRO_DTO> lista_financeiro = new List<FINANCEIRO_DTO>();
        bool popularGrid = false;
        public frmCad_Cliente(int ID = 0)
        {
            InitializeComponent();
            PopularCombos();
            if (ID == 0)
            {
                CLIENTE_DTO = new CLIENTE_DTO();

            }
            else
            {
                CLIENTE_DTO = CLIENTE_BLL.Selecione(ID);
                PopularDados();
                CLIENTE_DTO.Operacao = SysDTO.Operacoes.Alteracao;
                popularGrid = true;
            }
        }


        public void PopularCombos()
        {
            try
            {
                cboUF.DataSource = null;
                cboUF.ValueMember = "Value";
                cboUF.DisplayMember = "Text";
                cboUF.DataSource = FormFuncoes.ListaEstados();
                cboUF.SelectedIndex = -1;

                cboUFCNH.DataSource = null;
                cboUFCNH.ValueMember = "Value";
                cboUFCNH.DisplayMember = "Text";
                cboUFCNH.DataSource = FormFuncoes.ListaEstados();
                cboUFCNH.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

            }
        }

        void PopularGrid(int ID_SERVICO = 0)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();

                sbSql.Append("SELECT X.ID AS ID_INVISIBLE, B.NOME AS SERVIÇO, A.DESCRICAO AS [STATUS], A.COR FROM FINANCEIRO X LEFT JOIN STATUS_FINANCEIRO A ON X.ID_STATUS = A.ID LEFT JOIN SERVICOS B ON X.ID_SERVICO = B.ID WHERE ID_CLIENTE = " + CLIENTE_DTO.ID + " ORDER BY  DATA_ALTERACAO DESC");
                //Monta o grid e recupera as colunas utilizadas para pesquisa
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(sbSql.ToString(), ListaCampos);
                dtgContrato.DataSource = null;
                dtgContrato.DataSource = dtt;
                foreach (DataGridViewRow item in dtgContrato.Rows)
                {
                    if (!String.IsNullOrEmpty(item.Cells["COR"].ToString()))
                    {
                        int[] coresArgb = new int[3];
                        for (int i = 0; i < item.Cells["COR"].Value.ToString().Split(';').Length; i++)
                        {
                            coresArgb[i] = Convert.ToInt32(item.Cells["COR"].Value.ToString().Split(';')[i]);
                        }

                        item.DefaultCellStyle.BackColor = Color.FromName("lightGreen");
                        dtgContrato.Columns["COR"].Visible = false;
                        if (coresArgb.Length == 3)
                            item.DefaultCellStyle.BackColor = Color.FromArgb(coresArgb[0], coresArgb[1], coresArgb[2]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCad_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (popularGrid)
                    PopularGrid();

                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Insert"))
                    tsbDocAdd.Enabled = false;
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Delete"))
                    tsbDocDel.Enabled = false;
                if (!SysBLL.grupo_acesso.SYS_MENU.Exists(x => x.NAME == "frmFinanceiro.Update"))
                    tsbDocEdit.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }


        public void PopularDados()
        {
            //ENDEREÇO
            txtBairro.Text = CLIENTE_DTO.BAIRRO;
            txtComplemento.Text = CLIENTE_DTO.COMPLEMENTO;
            txtLogradouro.Text = CLIENTE_DTO.LOGRADOURO;
            txtMunicipio.Text = CLIENTE_DTO.MUNICIPIO;
            cboUF.Text = CLIENTE_DTO.UF;
            mskCEP.Text = CLIENTE_DTO.CEP;
            txtNumeroResidencial.Text = CLIENTE_DTO.NUMERO_RES;

            //CONTATO
            txtEmail.Text = CLIENTE_DTO.EMAIL;
            txtEmail2.Text = CLIENTE_DTO.EMAIL2;
            mskCelular.Text = CLIENTE_DTO.CELULAR;
            mskTelelefone.Text = CLIENTE_DTO.TELEFONE;
            txtObs.Text = CLIENTE_DTO.OBSERVACAO;
            //DADOS
            txtNome.Text = CLIENTE_DTO.NOME_COMPLETO;
            mskCPF.Text = CLIENTE_DTO.CPF;
            txtRG.Text = CLIENTE_DTO.RG;
            mskNascimento.Text = CLIENTE_DTO.DATA_NASCIMENTO;
            txtCNH.Text = CLIENTE_DTO.CNH.ToString();
            cboUFCNH.Text = CLIENTE_DTO.CNH_UF;
            nupPontuacao.Value = CLIENTE_DTO.CNH_PONTUACAO;
            mskDataVencimentoCNH.Text = CLIENTE_DTO.CNH_DATA_VENCIMENTO.ToString();
            if (CLIENTE_DTO.PORTARIA)
                radPortariaSim.Checked = true;
            else
                radPortariaNao.Checked = true;
        }


        public void AtualizaDTO()
        {
            try
            {
                //DADOS
                CLIENTE_DTO.NOME_COMPLETO = txtNome.Text;
                CLIENTE_DTO.CPF = mskCPF.Text.Replace(".", "").Replace("-", "").Replace(",", "");
                CLIENTE_DTO.RG = txtRG.Text;
                CLIENTE_DTO.DATA_NASCIMENTO = mskNascimento.Text;
                CLIENTE_DTO.CNH = Convert.ToString(txtCNH.Text);
                CLIENTE_DTO.CNH_UF = cboUFCNH.Text;
                CLIENTE_DTO.CNH_PONTUACAO = Convert.ToInt32(nupPontuacao.Value);
                CLIENTE_DTO.CNH_DATA_VENCIMENTO = Convert.ToDateTime(mskDataVencimentoCNH.Text);
                //ENDEREÇO
                CLIENTE_DTO.CEP = mskCEP.Text.Replace("-", "");
                CLIENTE_DTO.BAIRRO = txtBairro.Text;
                CLIENTE_DTO.LOGRADOURO = txtLogradouro.Text;
                CLIENTE_DTO.UF = cboUF.Text;
                CLIENTE_DTO.MUNICIPIO = txtMunicipio.Text;
                CLIENTE_DTO.COMPLEMENTO = txtComplemento.Text;
                CLIENTE_DTO.NUMERO_RES = txtNumeroResidencial.Text;
                //CONTATO
                CLIENTE_DTO.EMAIL = txtEmail.Text;
                CLIENTE_DTO.EMAIL2 = txtEmail2.Text;
                CLIENTE_DTO.CELULAR = mskCelular.Text;
                CLIENTE_DTO.TELEFONE = mskTelelefone.Text;
                CLIENTE_DTO.OBSERVACAO = txtObs.Text;
                CLIENTE_DTO.PORTARIA = (radPortariaSim.Checked ? true : false);
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarDados(CLIENTE_DTO))
            {
                AtualizaDTO();

                if (CLIENTE_DTO.Operacao == SysDTO.Operacoes.Inclusao)
                {
                    int? id = CLIENTE_BLL.Set_Cliente(CLIENTE_DTO);
                    if (id > 0)
                    {
                        foreach (var financeiro in lista_financeiro)
                        {
                            if (financeiro.ID == 0)
                            {
                                financeiro.ID_CLIENTE = (int)id;
                                new FINANCEIRO_BLL().Set_Financeiro(financeiro);
                            }
                        }
                        MessageBox.Show("Cliente inserido com sucesso !");
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (CLIENTE_DTO.Operacao == SysDTO.Operacoes.Alteracao)
                {
                    if (CLIENTE_BLL.Update_Cliente(CLIENTE_DTO))
                        MessageBox.Show("Cliente alterado com sucesso !");
                    this.DialogResult = DialogResult.OK;

                }
            }
        }
        private bool ValidarDados(CLIENTE_DTO DTO)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                result.Add("NOME COMPLETO");
                txtNome.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(mskCelular.Text))
            {
                result.Add("CELULAR");
                txtRG.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(txtBairro.Text))
            {
                result.Add("BAIRRO");
                txtBairro.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(mskCEP.Text))
            {
                result.Add("CEP");
                mskCEP.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(mskCPF.Text))
            {
                result.Add("CPF");
                mskCPF.ForeColor = System.Drawing.Color.Red;
            }
            //if (string.IsNullOrEmpty(cboUF.Text))
            //{
            //    result.Add("UF");
            //    cboUF.ForeColor = System.Drawing.Color.Red;
            //}
            if (string.IsNullOrEmpty(mskNascimento.Text))
            {
                result.Add("NASCIMENTO");
                cboUF.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(txtMunicipio.Text))
            {
                result.Add("MUNICIPIO");
                txtMunicipio.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(txtRG.Text))
            {
                result.Add("RG");
                txtRG.ForeColor = System.Drawing.Color.Red;
            }
            if (string.IsNullOrEmpty(txtLogradouro.Text))
            {
                result.Add("LOGRADOURO");
                txtLogradouro.ForeColor = System.Drawing.Color.Red;
            }
            if (result.Count == 0)
                return true;
            var msg = "";
            foreach (var item in result)
            {
                msg += item + ", ";
            }
            if (msg.Length > 2)
                msg = msg.Substring(0, msg.Length - 2);
            if (result.Count > 1)
                MessageBox.Show("Campos " + msg + " são obrigatórios!", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (result.Count == 1)
                MessageBox.Show("Campo " + msg + " é obrigatório!", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            return false;
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string Cep = FormFuncoes.SomenteNumeros(mskCEP.Text);

                if (Cep.Length < 8)
                {
                    MessageBox.Show("Cep incorreto,favor informar no minímo 8 números", "Cep incorreto...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskCEP.Focus();
                    return;
                }

                txtBairro.Text = "";
                txtLogradouro.Text = "";
                cboUF.SelectedIndex = -1;
                txtMunicipio.Text = "";
                txtComplemento.Text = "";

                Dictionary<string, string> Endereco = new CLIENTE_BLL().Localizar(mskCEP.Text);
                if (Convert.ToBoolean(Endereco["STATUS"]))
                {

                    txtBairro.Text = Endereco["BAIRRO"].ToString().Trim();
                    txtLogradouro.Text = Endereco["LOGRADOURO"].ToString().Trim();
                    cboUF.Text = (Endereco["UF"].ToString().Trim());
                    txtMunicipio.Text = Endereco["CIDADE"].ToString().Trim();
                    txtComplemento.Text = Endereco["COMPLEMENTO"].ToString().Trim();
                    txtNumeroResidencial.Focus();
                }
                else
                {
                    MessageBox.Show(Endereco["ERRO"], "Erro ao buscar CEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao localizar o Cep", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Setando o mousepointer para a posição original.
                Cursor.Current = Cursors.Default;
            }
        }

        private void mskCEP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisarCep_Click(sender, e);
            }
        }

        private void tsbDocAdd_Click(object sender, EventArgs e)
        {
            int ID_CLIENTE = CLIENTE_DTO.ID == null ? -1 : Convert.ToInt32(CLIENTE_DTO.ID);
            frmCad_Financeiro frmCad_Financeiro = new frmCad_Financeiro(ID_CLIENTE: ID_CLIENTE);
            DialogResult dialogResult = frmCad_Financeiro.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                lista_financeiro.Add(frmCad_Financeiro.FINANCEIRO_DTO);
                if (CLIENTE_DTO.ID != null)
                    PopularGrid();
                else
                {
                    DataTable dtt = new DataTable();
                    dtt.Columns.Add("Nº Contrato");
                    dtt.Columns.Add("Serviço");
                    foreach (var item in lista_financeiro)
                    {
                        if (item.ID == null)
                            item.ID = 0;
                        dtt.Rows.Add(item.INDICACAO, item.SERVICO.NOME);
                    }



                    dtgContrato.DataSource = null;
                    dtgContrato.DataSource = dtt; //Vincula o datatable ao datagrid
                    dtgContrato.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); //Redimenciona as colunas de acordo com o conteúdo do campo

                }

            }
        }

        private void tsbDocEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgContrato.CurrentRow == null)
                {
                    MessageBox.Show("Selecione uma linha ta tabela", "Registro não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FINANCEIRO_DTO FinanceiroDTO = new FINANCEIRO_DTO();

                FinanceiroDTO.ID = Convert.ToInt32(dtgContrato.CurrentRow.Cells["ID_INVISIBLE"].Value.ToString());

                frmCad_Financeiro frmProfissional_Servico = new frmCad_Financeiro((int)FinanceiroDTO.ID);
                frmProfissional_Servico.ShowDialog(this);
                PopularGrid();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Selecione um ítem válido na lista clicando sobre o mesmo!", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void tsbDocDel_Click(object sender, EventArgs e)
        {
            try
            {
                //Checando se há algum registro selecionado
                if (dtgContrato.SelectedRows.Count == 0)
                {
                    return;
                }

                //Recuperando os ids selecionados para exclusão
                string strIds = "";
                for (int i = 0; i < dtgContrato.SelectedRows.Count; i++)
                {
                    if (dtgContrato["ID_INVISIBLE", dtgContrato.SelectedRows[i].Index].Value != null)
                    {
                        strIds += dtgContrato["ID_INVISIBLE", dtgContrato.SelectedRows[i].Index].Value.ToString() + ",";
                    }
                    else
                    {
                        strIds = "0";
                    }
                }

                if (strIds.Length == 0)
                {
                    throw new Exception("Nenhum registro com Descricao válido foi informado para exclusão!");
                }
                strIds = strIds.Substring(0, strIds.Length - 1);
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;
                string strRows = "";
                string strmsg = (dtgContrato.SelectedRows.Count > 1 ? dtgContrato.SelectedRows.Count + " registros selecionados" : strIds);
                for (int i = 0; i < dtgContrato.SelectedRows.Count; i++)
                {
                    strRows += (dtgContrato.CurrentRow.Index + 1) + ", ";
                }
                if (dtgContrato.CurrentRow != null)
                {
                    //Confirmando a exclusão
                    if (MessageBox.Show("Você confirma a exclusão " + (strmsg != "" ? "do registro " + strmsg + "? " : "da linha " + strRows.Substring(0, strRows.Length - 2) + "?"),
                                    "Excluir registro(s)?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                                    == DialogResult.Yes)
                    {
                        //Excluindo o registro
                        if (strmsg != "0")
                        {
                            string[] ids = strmsg.Split(',');
                            for (int i = 0; i < ids.Length; i++)
                            {
                                if (ids[i].Trim() != "")
                                    new FINANCEIRO_BLL().Excluir(Convert.ToInt32(ids[i]));

                            }

                            //Setando o mousepointer para default.
                            Cursor.Current = Cursors.Default;

                            MessageBox.Show("Registro(s) excluído(s) com sucesso!", "Registro(s) excluído(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //Popular_Grid_Especialidades();
                        PopularGrid();
                    }
                }
            }
            catch (NullReferenceException)
            {
                //Setando o mousepointer para default.
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Nenhum registro válido foi selecionado para exclusão!", "Não é possível excluir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                //Setando o mousepointer para default.
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult escolha = MessageBox.Show("Tem a certeza que deseja sair?", "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (escolha == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DtgContrato_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ToolStrip4_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TxtObs_Leave(object sender, EventArgs e)
        {
            try
            {
                this.AcceptButton = btnRegistrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtObs_Enter(object sender, EventArgs e)
        {
            try
            {
                this.AcceptButton = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboUFCNH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DtgContrato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgContrato.CurrentRow == null)
                {
                    MessageBox.Show("Selecione uma linha da tabela", "Registro não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                FINANCEIRO_DTO FinanceiroDTO = new FINANCEIRO_DTO();

                FinanceiroDTO.ID = Convert.ToInt32(dtgContrato.CurrentRow.Cells["ID_INVISIBLE"].Value.ToString());

                FinanceiroDTO = new FINANCEIRO_BLL().Seleciona((int)FinanceiroDTO.ID);

                txtObs.Text = FinanceiroDTO.OBSERVACAO;

            }

                catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MskCEP_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void MskCEP_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnRegistrar;
        }
    }
}