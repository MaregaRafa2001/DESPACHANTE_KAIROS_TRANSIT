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
                PopularTelefoneCelular();
            }
            else
            {
                CLIENTE_DTO = CLIENTE_BLL.Selecione(ID);
                PopularTelefoneCelular();
                PopularDados();
                CLIENTE_DTO.OPERACAO = SysDTO.Operacoes.Alteracao;
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

        void PopularTelefoneCelular()
        {
            cboTelefone.SelectedValueChanged -= CboTelefone_SelectedValueChanged;
            CLIENTE_DTO.TELEFONE.Insert(0, new TELEFONE_DTO() { NUMERO = "(Adicionar...)", OPERACAO = SysDTO.Operacoes.Leitura, ID = -1 });
            cboTelefone.DataSource = null;
            cboTelefone.DisplayMember = "NUMERO";
            cboTelefone.ValueMember = "ID";
            cboTelefone.DataSource = CLIENTE_DTO.TELEFONE;
            cboTelefone.SelectedIndex = -1;
            mskTelefone.Visible = false;
            btnExcluirTelefone.Visible = false;
            cboTelefone.Visible = true;
            cboTelefone.SelectedValueChanged += CboTelefone_SelectedValueChanged;

            cboCelular.SelectedValueChanged -= CboCelular_SelectedValueChanged;
            CLIENTE_DTO.CELULAR.Insert(0, new CELULAR_DTO() { NUMERO = "(Adicionar...)", OPERACAO = SysDTO.Operacoes.Leitura, ID = -1 });
            cboCelular.DataSource = null;
            cboCelular.DisplayMember = "NUMERO";
            cboCelular.ValueMember = "ID";
            cboCelular.DataSource = CLIENTE_DTO.CELULAR;
            cboCelular.SelectedIndex = -1;
            mskCelular.Visible = false;
            btnExcluirCelular.Visible = false;
            cboCelular.Visible = true;
            cboCelular.SelectedValueChanged += CboCelular_SelectedValueChanged;
        }

        void PopularGrid(int ID_SERVICO = 0)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();

                sbSql.Append("SELECT X.ID AS ID_INVISIBLE, X.DATA, B.NOME AS SERVIÇO, A.DESCRICAO AS [STATUS], A.COR FROM FINANCEIRO X LEFT JOIN STATUS_FINANCEIRO A ON X.ID_STATUS = A.ID LEFT JOIN SERVICOS B ON X.ID_SERVICO = B.ID WHERE ID_CLIENTE = " + CLIENTE_DTO.ID + " ORDER BY  DATA_ALTERACAO DESC");
                //Monta o grid e recupera as colunas utilizadas para pesquisa
                DataTable dtt = new PesquisaGeralBLL().Pesquisa(sbSql.ToString(), ListaCampos);
                dtgContrato.DataSource = null;
                dtgContrato.DataSource = dtt;
                dtgContrato.Columns["ID_INVISIBLE"].Visible = false;
                foreach (DataGridViewRow item in dtgContrato.Rows)
                {
                    if (!String.IsNullOrEmpty(item.Cells["COR"].ToString()))
                    {
                        int[] coresArgb = new int[3];
                        for (int i = 0; i < item.Cells["COR"].Value.ToString().Split(';').Length; i++)
                        {
                            if (item.Cells["COR"].Value.ToString() != "")
                                coresArgb[i] = Convert.ToInt32(item.Cells["COR"].Value.ToString().Split(';')[i]);
                            else
                                coresArgb[i] = 255;
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

                if (CLIENTE_DTO.ID != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP (100) PERCENT ID, DATAHORA AS 'Data', USUARIO AS Usuário, ASSUNTO, HISTORICO,ID_REGISTRO ");
                    sb.Append(" FROM LOG_SISTEMA WHERE (TABELA = N'CLIENTE') ");
                    sb.Append(" and (id_registro = " + CLIENTE_DTO.ID + ")");
                    //Carregando o Histórico
                    if (CLIENTE_DTO.ID != 0)
                    {
                        DataTable dtt = new PesquisaGeralBLL().Pesquisa(sb.ToString());

                        dtt.DefaultView.Sort = "Data Desc";
                        dtgHistorico.DataSource = dtt;
                        dtgHistorico.Columns["Historico"].Visible = false;
                        dtgHistorico.RowHeadersVisible = false;
                        dtgHistorico.Columns["id_registro"].Visible = false;
                        dtgHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                else
                {
                    tabControl1.TabPages.Remove(tabHistórico);
                }
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
            mskCEP.Text = CLIENTE_DTO.CEP;
            txtNumeroResidencial.Text = CLIENTE_DTO.NUMERO_RES;

            //CONTATO
            txtEmail.Text = CLIENTE_DTO.EMAIL;
            txtEmail2.Text = CLIENTE_DTO.EMAIL2;

            //cboTelefone.SelectedValueChanged -= CboTelefone_SelectedValueChanged;
            //if (CLIENTE_DTO.TELEFONE != null)
            //{
            //    CLIENTE_DTO.TELEFONE = new List<TELEFONE_DTO>();
            //    CLIENTE_DTO.TELEFONE.Insert(0, new TELEFONE_DTO() { NUMERO = "(Adicionar...)", OPERACAO = SysDTO.Operacoes.Leitura, ID = -1 });
            //}
            //cboTelefone.DataSource = null;
            //cboTelefone.DisplayMember = "NUMERO";
            //cboTelefone.ValueMember = "ID";
            //cboTelefone.DataSource = CLIENTE_DTO.TELEFONE;
            //cboTelefone.SelectedIndex = -1;
            //cboTelefone.SelectedValueChanged += CboTelefone_SelectedValueChanged;

            //cboCelular.SelectedValueChanged -= CboCelular_SelectedValueChanged;
            //if (CLIENTE_DTO.CELULAR != null)
            //{
            //    CLIENTE_DTO.CELULAR = new List<CELULAR_DTO>();
            //    CLIENTE_DTO.CELULAR.Insert(0, new CELULAR_DTO() { NUMERO = "(Adicionar...)", OPERACAO = SysDTO.Operacoes.Leitura, ID = -1 });
            //}
            //cboCelular.DataSource = null;
            //cboCelular.DisplayMember = "NUMERO";
            //cboCelular.ValueMember = "ID";
            //cboCelular.DataSource = CLIENTE_DTO.CELULAR;
            //cboCelular.SelectedIndex = -1;
            //cboCelular.SelectedValueChanged += CboCelular_SelectedValueChanged;

            txtObs.Text = CLIENTE_DTO.OBSERVACAO;
            //DADOS
            txtNome.Text = CLIENTE_DTO.NOME_COMPLETO;
            mskCPF.Text = CLIENTE_DTO.CPF;
            txtRG.Text = CLIENTE_DTO.RG;
            mskNascimento.Text = CLIENTE_DTO.DATA_NASCIMENTO;
            txtCNH.Text = CLIENTE_DTO.CNH.ToString();
            cboUFCNH.Text = CLIENTE_DTO.CNH_UF;
            nupPontuacao.Value = CLIENTE_DTO.CNH_PONTUACAO == null ? 0 : Convert.ToInt32(CLIENTE_DTO.CNH_PONTUACAO);
            mskDataVencimentoCNH.Text = CLIENTE_DTO.CNH_DATA_VENCIMENTO.ToString();
            if (CLIENTE_DTO.PORTARIA)
                radPortariaSim.Checked = true;
            else
                radPortariaNao.Checked = true;
            if (CLIENTE_DTO.IMPEDIMENTO)
                radImpedimentoSim.Checked = true;
            else
                radImpedimentoNao.Checked = true;
            if (CLIENTE_DTO.CNH_VENCIDA)
                radCNHVencidaSim.Checked = true;
            else
                radCNHVencidaNao.Checked = true;
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

                CLIENTE_DTO.CNH_DATA_VENCIMENTO = FormFuncoes.GetMskDate(mskDataVencimentoCNH);
                CLIENTE_DTO.CNH_VENCIDA = radCNHVencidaSim.Checked ? true : false;
                //ENDEREÇO
                CLIENTE_DTO.CEP = mskCEP.Text.Replace("-", "");
                CLIENTE_DTO.BAIRRO = txtBairro.Text;
                CLIENTE_DTO.LOGRADOURO = txtLogradouro.Text;
                CLIENTE_DTO.MUNICIPIO = txtMunicipio.Text;
                CLIENTE_DTO.COMPLEMENTO = txtComplemento.Text;
                CLIENTE_DTO.NUMERO_RES = txtNumeroResidencial.Text;
                //CONTATO
                CLIENTE_DTO.EMAIL = txtEmail.Text;
                CLIENTE_DTO.EMAIL2 = txtEmail2.Text;



                //CLIENTE_DTO.CELULAR = mskCelular.Text;
                //CLIENTE_DTO.TELEFONE = mskTelelefone.Text;
                CLIENTE_DTO.OBSERVACAO = txtObs.Text;
                CLIENTE_DTO.PORTARIA = (radPortariaSim.Checked ? true : false);
                CLIENTE_DTO.IMPEDIMENTO = (radImpedimentoSim.Checked ? true : false);
                CLIENTE_DTO.ULT_ATUAL = DateTime.Now;
                CLIENTE_DTO.USUARIO = SysBLL.UserLogin.NOME;


                //LIMPO AS DTOs DE ADICIONAR TELEFONE/CELULAR
                if (CLIENTE_DTO.CELULAR.Exists(x => x.ID == -1))
                    CLIENTE_DTO.CELULAR.RemoveAll(x => x.ID == -1);
                if (CLIENTE_DTO.TELEFONE.Exists(x => x.ID == -1))
                    CLIENTE_DTO.TELEFONE.RemoveAll(x => x.ID == -1);
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDados(CLIENTE_DTO))
                {
                    AtualizaDTO();

                    if (CLIENTE_DTO.OPERACAO == SysDTO.Operacoes.Inclusao)
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
                            MessageBox.Show("Cliente alterado com sucesso!", "Cliente inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (CLIENTE_DTO.OPERACAO == SysDTO.Operacoes.Alteracao)
                    {
                        if (CLIENTE_BLL.Update_Cliente(CLIENTE_DTO))
                            MessageBox.Show("Cliente alterado com sucesso!", "Cliente alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao localizar o Cep", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDados(CLIENTE_DTO DTO)
        {
            //VALIDAR CAMPOS VAZIOS
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                result.Add("NOME COMPLETO");
                txtNome.ForeColor = System.Drawing.Color.Red;
            }
            //if (string.IsNullOrEmpty(mskCelular.Text))
            //{
            //    result.Add("CELULAR");
            //    txtRG.ForeColor = System.Drawing.Color.Red;
            //}
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


            //VALIDAR CAMPOS COM ERROS
            List<string> erros = new List<string>();
            if (mskNascimento.Text.Replace("/", "").Trim().Length > 0)
            {
                try
                {
                    Convert.ToDateTime(mskNascimento.Text);
                }
                catch
                {
                    erros.Add("DATA DE NASCIMENTO");
                    mskNascimento.ForeColor = System.Drawing.Color.Red;
                }
            }

            if (mskDataVencimentoCNH.Text.Replace("/", "").Trim().Length > 0)
            {
                try
                {
                    Convert.ToDateTime(mskDataVencimentoCNH.Text);
                }
                catch
                {
                    erros.Add("DATA DE VENCIMENTO");
                    mskDataVencimentoCNH.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (result.Count == 0 && erros.Count == 0)
                return true;


            var msg = "";
            foreach (var item in result)
            {
                msg += item + ", ";
            }
            if (msg.Length > 2)
            {
                msg = msg.Substring(0, msg.Length - 2);
                if (result.Count > 1)
                    msg = msg.Substring(0, msg.LastIndexOf(',')) + " e" + msg.Substring(msg.LastIndexOf(',') + 1, (msg.Length - msg.LastIndexOf(',')) - 1);
            }
            if (result.Count > 1)
                MessageBox.Show("Campos " + msg + " são obrigatórios!", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (result.Count == 1)
                MessageBox.Show("Campo " + msg + " é obrigatório!", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            msg = "";
            foreach (var item in erros)
            {
                msg += item + ", ";
            }
            if (msg.Length > 2)
            {
                msg = msg.Substring(0, msg.Length - 2);
                if (erros.Count > 1)
                    msg = msg.Substring(0, msg.LastIndexOf(',')) + " e" + msg.Substring(msg.LastIndexOf(',') + 1, (msg.Length - msg.LastIndexOf(',')) - 1);
            }
            if (erros.Count > 1)
                MessageBox.Show("Campos " + msg + " estão com valores inválidos!", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (erros.Count == 1)
                MessageBox.Show("Campo " + msg + " está com valor inválido!", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }


        #region CEP
        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            try
            {
                if (mskCEP.Focused)
                {
                    btnPesquisarCep.Focus();
                }
                else
                {
                    BuscarCep();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mskCEP_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisarCep_Click(sender, e);
            }
        }

        private void MskCEP_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void MskCEP_Leave(object sender, EventArgs e)
        {
            BuscarCep();
            this.AcceptButton = btnRegistrar;
        }

        void BuscarCep()
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

        #endregion
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

        private void DtgContrato_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DtgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgHistorico.Rows.Count != 0)
                {
                    string strAssunto = dtgHistorico.CurrentRow.Cells["Assunto"].Value.ToString();
                    StringBuilder stbDetalhes = new StringBuilder();
                    stbDetalhes.Append(strAssunto + "\r\n");
                    stbDetalhes.Append(string.Join("", Enumerable.Repeat("-", strAssunto.Length)) + "\r\n");
                    stbDetalhes.Append("Id do Registro: " + dtgHistorico.CurrentRow.Cells["ID_REGISTRO"].Value.ToString() + "\r\n");
                    stbDetalhes.Append("Usuário: " + dtgHistorico.CurrentRow.Cells["Usuário"].Value.ToString() + "\r\n");
                    stbDetalhes.Append("Data: " + dtgHistorico.CurrentRow.Cells["Data"].Value.ToString() + "\r\n");
                    stbDetalhes.Append("\r\n");
                    stbDetalhes.Append("---------- Dados" + (dtgHistorico.CurrentRow.Cells["Assunto"].Value.ToString() != "Criação" ? " Anteriores" : "") + ": ----------\r\n");
                    stbDetalhes.Append(dtgHistorico.CurrentRow.Cells["historico"].Value.ToString().Replace("|", "\r\n"));
                    stbDetalhes.Append("---------------------------------------\r\n");
                    stbDetalhes.Append("---------------------------------------\r\n");
                    stbDetalhes.Append("---------------------------------------\r\n");
                    txtMaisDetalhes.Text = stbDetalhes.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao mostrar detalhes do Histórico!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DtgContrato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        #region TELEFONE
        private void CboTelefone_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTelefone.SelectedValue == null)
                    return;
                if (Convert.ToInt32(cboTelefone.SelectedValue) == -1)
                {
                    btnTelefone.Click -= BtnEditTelefone_Click;
                    btnTelefone.Click -= BtnAddTelefone_Click;
                    btnTelefone.Click += BtnAddTelefone_Click;
                    cboTelefone.Visible = false;
                    mskTelefone.Visible = true;
                    mskTelefone.Focus();
                    btnExcluirTelefone.Visible = false;
                }
                else
                {
                    btnTelefone.Click -= BtnAddTelefone_Click;
                    btnTelefone.Click -= BtnEditTelefone_Click;
                    btnTelefone.Click += BtnEditTelefone_Click;
                    cboTelefone.Visible = false;
                    mskTelefone.Visible = true;
                    mskTelefone.Text = cboTelefone.Text;
                    btnExcluirTelefone.Visible = true;
                    btnExcluirTelefone.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (mskTelefone.Text.Replace("_", "").Length >= 8)
                {
                    TELEFONE_DTO TELEFONE = new TELEFONE_DTO();
                    TELEFONE.NUMERO = mskTelefone.Text;
                    TELEFONE.OPERACAO = SysDTO.Operacoes.Inclusao;
                    TELEFONE.ID = Convert.ToInt32(new Random().Next().ToString().Substring(0, 5));
                    CLIENTE_DTO.TELEFONE.Add(TELEFONE);
                    PopularTelefone();
                    cboTelefone.Visible = true;
                    mskTelefone.Visible = false;
                    mskTelefone.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTelefone_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (CLIENTE_DTO.TELEFONE.Exists(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue)))
                {
                    TELEFONE_DTO TELEFONE = CLIENTE_DTO.TELEFONE.Find(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue));
                    TELEFONE.NUMERO = mskTelefone.Text;
                    if (TELEFONE.OPERACAO != SysDTO.Operacoes.Inclusao)
                        TELEFONE.OPERACAO = SysDTO.Operacoes.Alteracao;

                    foreach (TELEFONE_DTO TEL in CLIENTE_DTO.TELEFONE.Where(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue)))
                    {
                        TEL.NUMERO = TELEFONE.NUMERO;
                        if (TEL.OPERACAO != SysDTO.Operacoes.Inclusao)
                            TEL.OPERACAO = SysDTO.Operacoes.Alteracao;
                    }

                    PopularTelefone();
                    cboTelefone.Visible = true;
                    mskTelefone.Visible = false;
                    mskTelefone.Text = "";
                    btnExcluirTelefone.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PicExcluirTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (CLIENTE_DTO.TELEFONE.Exists(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue)))
                {
                    foreach (TELEFONE_DTO TEL in CLIENTE_DTO.TELEFONE.Where(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue)))
                    {
                        TEL.OPERACAO = SysDTO.Operacoes.Exclusao;
                    }

                    PopularTelefone();
                    cboTelefone.Visible = true;
                    mskTelefone.Visible = false;
                    mskTelefone.Text = "";
                    btnExcluirTelefone.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PopularTelefone()
        {
            try
            {
                cboTelefone.SelectedValueChanged -= CboTelefone_SelectedValueChanged;
                cboTelefone.DataSource = null;
                cboTelefone.DisplayMember = "NUMERO";
                cboTelefone.ValueMember = "ID";
                cboTelefone.DataSource = CLIENTE_DTO.TELEFONE.FindAll(x => x.OPERACAO != SysDTO.Operacoes.Exclusao);
                cboTelefone.SelectedIndex = -1;
                cboTelefone.SelectedValueChanged += CboTelefone_SelectedValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluirTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboTelefone.SelectedValue) != -1 && CLIENTE_DTO.TELEFONE.Exists(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue)))
                {
                    foreach (TELEFONE_DTO TEL in CLIENTE_DTO.TELEFONE.Where(x => x.ID == Convert.ToInt32(cboTelefone.SelectedValue)))
                    {
                        TEL.OPERACAO = SysDTO.Operacoes.Exclusao;
                    }

                    PopularTelefone();
                    cboTelefone.Visible = true;
                    mskTelefone.Visible = false;
                    mskTelefone.Text = "";
                    btnExcluirTelefone.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MskTelefone_Leave(object sender, EventArgs e)
        {
            try
            {
                btnTelefone.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CELULAR
        private void BtnCelular_Click(object sender, EventArgs e)
        {
            try
            {
                if (CLIENTE_DTO.CELULAR.Exists(x => x.ID == Convert.ToInt32(cboCelular.SelectedValue)))
                {
                    CELULAR_DTO CELULAR = CLIENTE_DTO.CELULAR.Find(x => x.ID == Convert.ToInt32(cboCelular.SelectedValue));
                    CELULAR.NUMERO = mskCelular.Text;
                    if (CELULAR.OPERACAO != SysDTO.Operacoes.Inclusao)
                        CELULAR.OPERACAO = SysDTO.Operacoes.Alteracao;

                    foreach (CELULAR_DTO TEL in CLIENTE_DTO.CELULAR.Where(x => x.ID == Convert.ToInt32(cboCelular.SelectedValue)))
                    {
                        TEL.NUMERO = CELULAR.NUMERO;
                        if (TEL.OPERACAO != SysDTO.Operacoes.Inclusao)
                            TEL.OPERACAO = SysDTO.Operacoes.Alteracao;
                    }

                    PopularCelular();
                    cboCelular.Visible = true;
                    mskCelular.Visible = false;
                    mskCelular.Text = "";
                    btnExcluirCelular.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PopularCelular()
        {
            try
            {
                cboCelular.SelectedValueChanged -= CboCelular_SelectedValueChanged;
                cboCelular.DataSource = null;
                cboCelular.DisplayMember = "NUMERO";
                cboCelular.ValueMember = "ID";
                cboCelular.DataSource = CLIENTE_DTO.CELULAR.FindAll(x => x.OPERACAO != SysDTO.Operacoes.Exclusao);
                cboCelular.SelectedIndex = -1;
                cboCelular.SelectedValueChanged += CboCelular_SelectedValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboCelular_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCelular.SelectedValue == null)
                    return;
                if (Convert.ToInt32(cboCelular.SelectedValue) == -1)
                {
                    btnCelular.Click -= BtnCelular_Click;
                    btnCelular.Click -= BtnAddCelular_Click;
                    btnCelular.Click += BtnAddCelular_Click;
                    cboCelular.Visible = false;
                    mskCelular.Visible = true;
                    mskCelular.Focus();
                    btnExcluirCelular.Visible = false;
                }
                else
                {
                    btnCelular.Click -= BtnAddCelular_Click;
                    btnCelular.Click -= BtnCelular_Click;
                    btnCelular.Click += BtnCelular_Click;
                    cboCelular.Visible = false;
                    mskCelular.Visible = true;
                    mskCelular.Text = cboCelular.Text;
                    btnExcluirCelular.Visible = true;
                    btnExcluirCelular.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddCelular_Click(object sender, EventArgs e)
        {
            try
            {
                if (mskCelular.Text.Replace("_", "").Length >= 8)
                {
                    CELULAR_DTO CELULAR = new CELULAR_DTO();
                    CELULAR.NUMERO = mskCelular.Text;
                    CELULAR.OPERACAO = SysDTO.Operacoes.Inclusao;
                    CELULAR.ID = Convert.ToInt32(new Random().Next().ToString().Substring(0, 5));
                    CLIENTE_DTO.CELULAR.Add(CELULAR);
                    PopularCelular();
                    cboCelular.Visible = true;
                    mskCelular.Visible = false;
                    mskCelular.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluirCelular_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboCelular.SelectedValue) != -1 && CLIENTE_DTO.CELULAR.Exists(x => x.ID == Convert.ToInt32(cboCelular.SelectedValue)))
                {
                    foreach (CELULAR_DTO TEL in CLIENTE_DTO.CELULAR.Where(x => x.ID == Convert.ToInt32(cboCelular.SelectedValue)))
                    {
                        TEL.OPERACAO = SysDTO.Operacoes.Exclusao;
                    }

                    PopularCelular();
                    cboCelular.Visible = true;
                    mskCelular.Visible = false;
                    mskCelular.Text = "";
                    btnExcluirCelular.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MskCelular_Leave(object sender, EventArgs e)
        {
            try
            {
                btnCelular.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        private void MskCPF_Enter(object sender, EventArgs e)
        {
            GLOBAL_FORMS.InicioIndex(mskCPF);
        }
    }
}