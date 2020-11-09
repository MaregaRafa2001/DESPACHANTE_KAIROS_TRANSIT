using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FORMA_PAGAMENTO_DAL
    {
        public string strConnection;

        public FORMA_PAGAMENTO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public int? Set_FormaPagamento(FORMA_PAGAMENTO_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("FORMA_PAGAMENTO ");
                    SQL_.Append("( ");
                    //DADOS
                    SQL_.Append("DESCRICAO, ");
                    SQL_.Append("GERANUMERO, ");
                    SQL_.Append("USUARIO, ");
                    SQL_.Append("ULT_ATUAL ");


                    SQL_.Append(") ");
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");

                    //DADOS
                    SQL_.Append("@DESCRICAO, ");
                    SQL_.Append("@GERANUMERO, ");
                    SQL_.Append("@USUARIO, ");
                    SQL_.Append("@ULT_ATUAL ");
                   
                    SQL_.Append("); SELECT SCOPE_IDENTITY(); ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);

                    if ((DTO.ID = Convert.ToInt32(cmd.ExecuteScalar())) > 0)
                    {
                        return DTO.ID;
                    }

                    return 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
                finally
                {
                    cn.Close();
                }
            }
        }
        public bool Update_FormaPagamento(FORMA_PAGAMENTO_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("FORMA_PAGAMENTO ");
                    SQL_.Append("SET ");
                    //DADOS
                    SQL_.Append("DESCRICAO = @DESCRICAO, ");
                    SQL_.Append("GERANUMERO = @GERANUMERO, ");
                    SQL_.Append("USUARIO = @USUARIO, ");
                    SQL_.Append("ULT_ATUAL = @ULT_ATUAL ");



                    SQL_.Append("WHERE ID = @ID ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    PopularParametros(DTO, cmd);


                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public bool Excluir(int id)
        {
            using (SqlConnection conexao = new SqlConnection(this.strConnection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM FORMA_PAGAMENTO WHERE ID = " + id, conexao);
                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conexao.Close();
                }
            }
        }

        public void PopularParametros(FORMA_PAGAMENTO_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            //DADOS
            cmd.Parameters.AddWithValue("@DESCRICAO", DTO.DESCRICAO);
            cmd.Parameters.AddWithValue("@GERANUMERO", DTO.GERANUMERO);
            cmd.Parameters.AddWithValue("@USUARIO", DTO.USUARIO);
            cmd.Parameters.AddWithValue("@ULT_ATUAL", DTO.ULT_ATUAL);
            
            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

        public FORMA_PAGAMENTO_DTO Seleciona(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                FORMA_PAGAMENTO_DTO DTO = new FORMA_PAGAMENTO_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM FORMA_PAGAMENTO Where (Id = " + Id + " );");

                   
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        PopularDados(dtr, DTO);

                        SysDAL.GuardarDTO((IDTO)DTO.Clone());
                    }

                    return DTO;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (dtr != null) { dtr.Close(); }
                    scn.Close();
                }
            }
        }

        public void PopularDados(SqlDataReader dtr, FORMA_PAGAMENTO_DTO DTO)
        {
            DTO.ID = Convert.ToInt32(dtr["ID"]);
            //DADOS
            DTO.DESCRICAO = dtr["DESCRICAO"] == DBNull.Value ? "" : dtr["DESCRICAO"].ToString();
            DTO.GERANUMERO = dtr["GERANUMERO"] == DBNull.Value ? false : Convert.ToBoolean(dtr["GERANUMERO"]);
            DTO.USUARIO = dtr["USUARIO"] == DBNull.Value ? "" : dtr["USUARIO"].ToString();
            DTO.ULT_ATUAL = dtr["ULT_ATUAL"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dtr["ULT_ATUAL"]);
        }


        public List<FORMA_PAGAMENTO_DTO> Lista_Forma_Pagamento()
        {
            DataTable dtt = new PesquisaGeralDAL(this.strConnection).Pesquisa("SELECT * FROM FORMA_PAGAMENTO ORDER BY DESCRICAO");

            List<FORMA_PAGAMENTO_DTO> List = new List<FORMA_PAGAMENTO_DTO>();

            foreach (DataRow row in dtt.Rows)
            {
                List.Add(new FORMA_PAGAMENTO_DTO() { DESCRICAO = row["DESCRICAO"] == DBNull.Value ? (string)null : row["DESCRICAO"].ToString(), ID = row["ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["ID"]), GERANUMERO = row["GERANUMERO"] == DBNull.Value ? false : Convert.ToBoolean(row["GERANUMERO"]) });
            }

            List<FORMA_PAGAMENTO_DTO> ListaFiltrada = new List<FORMA_PAGAMENTO_DTO>();

            foreach (FORMA_PAGAMENTO_DTO item in List)
            {
                if (item.DESCRICAO != null)
                {
                    ListaFiltrada.Add(item);
                }
            }

            if (ListaFiltrada.Count > 0)
            {
                return ListaFiltrada;
            }
            else
            {
                ListaFiltrada.Add(new FORMA_PAGAMENTO_DTO() { DESCRICAO = "Sem formas de pagamentos.", ID = null, GERANUMERO = false });
                return ListaFiltrada;
            }
        }


    }
}
