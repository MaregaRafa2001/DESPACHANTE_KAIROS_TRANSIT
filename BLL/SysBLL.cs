using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Reflection;
using DAL;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BLL
{
    public static class SysBLL
    {   
        //String de conexão, váriaveis de servidor e módulo
        public static string strConexao;
        //Lista de telas disponiveis do sistema
        public static GRUPO_ACESSO_DTO grupo_acesso;
        //Propriedades do perfil do usuário logado
        public static LOGIN_DTO UserLogin;

        public class CustomException : Exception
        {
            public string Value { get; set; }
            public string Title { get; set; }
            public CustomException(string Message, string Value, string Title = "")
                : base(Message)
            {
                this.Value = Value;
                this.Title = Title;
            }
        }

        /// <summary>
        /// Método para gravar o histórico de alterações realizadas pelos usuários do sistema nas tabelas do banco de dados.
        /// </summary>
        /// <param name="ClasseDTO">Uma classe DTO que representa a tabela que foi alterada.</param>
        /// <param name="Conexao">Uma string de conexão com o bando de dados</param>
        /// <returns>Retorna true caso o histórico seja gravado com sucesso,e false caso ocorra algum problema durante a gravação do histórico.</returns>
        /// <remarks>Este método só aceita classes que implementaram a Interface IDTO.</remarks>
        public static bool Grava_Historico(IDTO ClasseDTO, string Usuario)
        {
            try
            {
                return SysDAL.Grava_Historico(ClasseDTO, SysBLL.strConexao, Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
