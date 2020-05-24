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

    public partial class frmRelatorios : Form
    {
        List<PesquisaGeralDTO> ListaCampos = new List<PesquisaGeralDTO>();
        public RELATORIOS_DTO relatorio_dto = new RELATORIOS_DTO();

        Dictionary<string, string> campos = new Dictionary<string, string>();

        public frmRelatorios(mdi_principal mdi)
        {
            InitializeComponent();
        }

        private void TsbFilter_Click(object sender, EventArgs e)
        {
            try
            {
                //Setando o mousepointer para ocupado.
                Cursor.Current = Cursors.WaitCursor;

                //Valida o perfil do usuário no formulario
                //if (LoginBLL.ValidaPerfil("frmPesquisaGeral_Filtro", SysBLL.InfoModuloDTO.Modulo, SysBLL.strConexao, SysBLL.UserLogin.id, SysBLL.UserLogin.Tipo) == true)
                //{
                //    //Instancia o formulário 
                Form frm = new frmRelatorioPesquisa(this);
                //Mostrando o formulário
                DialogResult result = frm.ShowDialog();
                //}
                if (result == DialogResult.OK)
                {
                    if (relatorio_dto.GERARHTML)
                    {
                        if (string.IsNullOrEmpty(relatorio_dto.COLUNAS_GROUP))
                        {
                            string DadosListados = "";
                            foreach (DataGridViewRow rowView in dtgDados.Rows)
                            {
                                DadosListados += relatorio_dto.LISTAHTML1;

                                foreach (DataGridViewCell item in rowView.Cells)
                                {
                                    DadosListados = DadosListados.Replace("@@" + item.OwningColumn.Name, item.Value.ToString());
                                    relatorio_dto.HTML = relatorio_dto.HTML.Replace("[@@" + item.OwningColumn.Name + "@@]", item.Value.ToString());
                                }

                            }

                            relatorio_dto.HTML = relatorio_dto.HTML.Replace("[@@LISTADADOS]", DadosListados);
                            if (dtgDados.Rows.Count > 0)
                                AbrirHtml(relatorio_dto.HTML);
                            else
                                MessageBox.Show("Nenhum registro listado para a impressão", "Sem registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string listahtml1 = "";
                            string DadosListados = "";
                            string DadosListados2 = "";
                            string valorGroup = "";
                            DadosListados += relatorio_dto.LISTAHTML1;
                            listahtml1 = relatorio_dto.LISTAHTML1;
                            int index = 0;
                            relatorio_dto.LISTAHTML1 = "";
                            foreach (DataGridViewRow rowView in dtgDados.Rows)
                            {
                                string valorGroupThisRow = "";
                                string[] Colunas = relatorio_dto.COLUNAS_GROUP.Split(',');

                                for (int i = 0; i < Colunas.Length; i++)
                                {
                                    valorGroupThisRow += rowView.Cells[Colunas[i]].Value.ToString() + ",";
                                }

                                if (valorGroup != valorGroupThisRow)
                                {
                                    if (valorGroup != "")
                                    {
                                        valorGroup = valorGroupThisRow;
                                        relatorio_dto.LISTAHTML1 += DadosListados.Replace("[@@LISTADADOS2]", DadosListados2);
                                        DadosListados = listahtml1;
                                        DadosListados2 = "";
                                    }
                                    else
                                    {
                                        valorGroup = valorGroupThisRow;
                                    }
                                }
                                DadosListados2 += relatorio_dto.LISTAHTML2;


                                foreach (DataGridViewCell item in rowView.Cells)
                                {
                                    DadosListados2 = DadosListados2.Replace("@@" + item.OwningColumn.Name, item.Value.ToString());
                                    DadosListados = DadosListados.Replace("[@@" + item.OwningColumn.Name + "@@]", item.Value.ToString());
                                }

                                //if (valorGroup != valorGroupThisRow)
                                //{
                                //    valorGroup = valorGroupThisRow;
                                //        relatorio_dto.LISTAHTML1 += DadosListados.Replace("[@@LISTADADOS2]", DadosListados2);
                                //    DadosListados2 = "";
                                //}
                                index++;

                                if (index == dtgDados.Rows.Count)
                                {
                                    relatorio_dto.LISTAHTML1 += DadosListados.Replace("[@@LISTADADOS2]", DadosListados2);
                                }
                            }

                            relatorio_dto.HTML = relatorio_dto.HTML.Replace("[@@LISTADADOS]", relatorio_dto.LISTAHTML1);
                            if (dtgDados.Rows.Count > 0)
                                AbrirHtml(relatorio_dto.HTML);
                            else
                                MessageBox.Show("Nenhum registro listado para a impressão", "Sem registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void AbrirHtml(string HTML, string NomeArquivo = "print.html")
        {
            try
            {
                string nomeArq = Application.StartupPath + NomeArquivo;
                System.IO.StreamWriter arquivo;
                arquivo = new System.IO.StreamWriter(nomeArq, false);
                arquivo.WriteLine(HTML);
                arquivo.Close();

                //Abrindo o arquivo
                using (System.Diagnostics.Process p = new System.Diagnostics.Process())
                {
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo(nomeArq);
                    p.Start();
                    //Excluir após visualizacao
                    //p.WaitForExit();
                    //File.Delete(strCaminho + txtNome_Arquivo.Text.Trim()); //Exclui o arquivo após a vizualização
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsbPrint_Click(object sender, EventArgs e)
        {

        }
    }
}