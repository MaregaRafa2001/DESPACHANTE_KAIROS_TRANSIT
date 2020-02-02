using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_UI
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new frmLogin());
                //Instancia as propriedades estáticas do login
                SysBLL.UserLogin = new LOGIN_DTO();

                //Ler os parametros do Arquivo appconfig.xml para montar a string de conexão com o Sql Server e guarda StringConection
                AppSettingsReader readerSettings = new AppSettingsReader();

                SysBLL.strConexao = new Connection().Get_Connection();


                //Recuperando atributos e versão do módulo
                Assembly Modulo = Assembly.GetExecutingAssembly();
                //SysBLL.InfoModuloDTO = RecursosGlobaisBLL.InfoModulo(ref Modulo);

                /*Ler os parametros de entrada da aplicação e verifica se foi definido um usuário,caso positivo o sistema tenta fazer login com o usuário informado.
                * Se não existe parametro de entrada, o sistema abre a tela de login para que possa ser informado o usuário e senha
                */
                //foreach (string p in Parametros)
                //{
                //    if (p.Trim() != "")
                //    {
                //        string[] s = p.Split('=');
                //        if (s[0].Trim().ToUpper() == "C")
                //        {
                //            LoginDTO LoginDtoRetorno = new LoginDTO();
                //            LoginDtoRetorno.Login = s[1].Replace(";", "").Trim();
                //            LoginDtoRetorno.Senha = "";
                //            LoginDtoRetorno.viaAdmex = true;
                //            //Recuperando dados
                //            LoginDtoRetorno = LoginBLL.Logar(LoginDtoRetorno, SysBLL.InfoModuloDTO.Modulo, SysBLL.strConexao);
                //            if (LoginDtoRetorno.Id != 0)
                //            {
                //                SysBLL.UserLogin = LoginDtoRetorno; //Guardando as propriedades do usuário logado, ficando disponível em todo o projeto
                //                                                    /////Usuário para teste
                //                                                    //SysBLL.UserLogin.Login = "TESTE";
                //                                                    //SysBLL.UserLogin.Tipo = "O";
                //                                                    //SysBLL.UserLogin.DescricaoTipo = "Operador";
                //                                                    //SysBLL.UserLogin.PermiteAlteracao = false;
                //                                                    /////
                //                Application.Run(new mdiPrincipal());
                //                return;
                //            }
                //            else
                //            {
                //                MessageBox.Show("Usuário não encontrado!", "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                return;
                //            }
                //        }
                //    }
                //}
                frmLogin frmLogin = new frmLogin();
                DialogResult result = frmLogin.ShowDialog();
                if (result == DialogResult.OK)
                {
                    frmLogin.Close();
                    frmLogin.Dispose();

                    Application.Run(new mdi_principal());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
