using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LOGIN_DAL
    {
        public string strConnection;
        LOGIN_DAL lDAL = null;

        public LOGIN_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public LOGIN_DTO Get_User_By_Login(LOGIN_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                LOGIN_DTO LOGIN = new LOGIN_DTO();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("SELECT ");
                    SQL_.Append("* ");
                    SQL_.Append("FROM ");
                    SQL_.Append("LOGIN ");
                    SQL_.Append("WHERE ");
                    SQL_.Append("LOGIN = @LOGIN ");
                    SQL_.Append("AND ");
                    SQL_.Append("PASS = @PASS ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@LOGIN", DTO.LOGIN);
                    cmd.Parameters.AddWithValue("@PASS", DTO.PASS);

                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        popularDTO(LOGIN, dr);
                    }

                    return LOGIN;
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

        public LOGIN_DTO Seleciona(int Id)
        {
            using (SqlConnection scn = new SqlConnection(this.strConnection))
            {
                SqlDataReader dtr = null;
                LOGIN_DTO LOGIN = new LOGIN_DTO();

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM LOGIN Where (Id = " + Id + " );");
                    scn.Open();
                    SqlCommand scm = new SqlCommand(sb.ToString(), scn);

                    dtr = scm.ExecuteReader();

                    if (dtr.Read())
                    {
                        popularDTO(LOGIN, dtr);
                    }

                    return LOGIN;
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


        void popularDTO(LOGIN_DTO DTO, SqlDataReader dr)
        {
            DTO.ID = Convert.ToInt32(dr["ID"]);
            DTO.LOGIN = dr["LOGIN"].ToString();
            DTO.PASS = dr["PASS"].ToString();
            DTO.NOME = dr["NOME"].ToString();
            DTO.ID_PERFIL = Convert.ToInt32(dr["ID_PERFIL"].ToString());
        }

        public int? Set_Login(LOGIN_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("LOGIN ");
                    SQL_.Append("( ");
                    //DADOS
                    SQL_.Append("NOME, ");
                    SQL_.Append("ID_PERFIL, ");
                    SQL_.Append("LOGIN, ");
                    SQL_.Append("PASS ");
                    SQL_.Append(") VALUES (");
                    SQL_.Append("@NOME, ");
                    SQL_.Append("@ID_PERFIL, ");
                    SQL_.Append("@LOGIN, ");
                    SQL_.Append("@PASS ");
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


        public bool Update_Login(LOGIN_DTO DTO)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("UPDATE ");
                    SQL_.Append("LOGIN ");
                    SQL_.Append("SET ");
                    SQL_.Append("NOME = @NOME, ");
                    SQL_.Append("ID_PERFIL = @ID_PERFIL, ");
                    SQL_.Append("LOGIN = @LOGIN, ");
                    SQL_.Append("PASS = @PASS ");


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
                SqlCommand cmd = new SqlCommand("DELETE FROM LOGIN WHERE ID = " + id, conexao);
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

        public void PopularParametros(LOGIN_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            //DADOS
            cmd.Parameters.AddWithValue("@NOME", DTO.NOME);
            cmd.Parameters.AddWithValue("@ID_PERFIL", DTO.ID_PERFIL);
            cmd.Parameters.AddWithValue("@LOGIN", DTO.LOGIN);
            cmd.Parameters.AddWithValue("@PASS", DTO.PASS);

            //Substitui o null por DBnull
            foreach (SqlParameter Parameter in cmd.Parameters)
            {
                if (Parameter.Value == null)
                {
                    Parameter.Value = DBNull.Value;
                }
            }

        }

    }
}
