using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class GRUPO_ACESSO_DAL
    {
        public string strConnection;

        public GRUPO_ACESSO_DAL(string conn)
        {
            this.strConnection = conn;
        }

        public GRUPO_ACESSO_DTO Listar(int ID_PERFIL)
        {
            using (SqlConnection cn = new SqlConnection(strConnection))
            {
                GRUPO_ACESSO_DTO list = new GRUPO_ACESSO_DTO();

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("select ");
                    SQL_.Append("X.ID,  ");
                    SQL_.Append("X.ID_SYS_MENU, ");
                    SQL_.Append("A.DESCRICAO, ");
                    SQL_.Append("A.NAME, ");
                    SQL_.Append("A.ID AS ID_SYS_MENU ");
                    SQL_.Append("from ");
                    SQL_.Append("GRUPO_ACESSO X ");
                    SQL_.Append("LEFT JOIN SYS_MENU A ");
                    SQL_.Append("ON ");
                    SQL_.Append("X.ID_SYS_MENU = A.ID ");
                    SQL_.Append("WHERE ");
                    SQL_.Append("ID_PERFIL = @ID_PERFIL ");
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_.ToString(), cn);
                    cmd.Parameters.AddWithValue("@ID_PERFIL", ID_PERFIL);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        SYS_MENU_DTO menu = new SYS_MENU_DTO();
                        menu.ID = Convert.ToInt32(dr["ID_SYS_MENU"]);
                        menu.DESCRICAO = Convert.ToString(dr["DESCRICAO"]);
                        menu.NAME = Convert.ToString(dr["NAME"]);
                        list.SYS_MENU.Add(menu);
                    }

                    return list;
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


        public int? Inserir(GRUPO_ACESSO_DTO DTO)
        {

            using (SqlConnection cn = new SqlConnection(strConnection))
            {

                try
                {
                    SqlDataReader dr = null;

                    StringBuilder SQL_ = new StringBuilder();

                    SQL_.Append("INSERT INTO ");
                    SQL_.Append("GRUPO_ACESSO ");
                    SQL_.Append("( ");
                    SQL_.Append("ID_PERFIL, ");
                    SQL_.Append("ID_SYS_MENU ");
                    SQL_.Append(") ");  
                    SQL_.Append("VALUES ");
                    SQL_.Append("( ");
                    SQL_.Append("@ID_PERFIL, ");
                    SQL_.Append("@ID_SYS_MENU ");
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

        public bool Excluir(int ID_PERFIL)
        {
            using (SqlConnection conexao = new SqlConnection(this.strConnection))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM GRUPO_ACESSO WHERE ID_PERFIL = " + ID_PERFIL, conexao);
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


        public void PopularParametros(GRUPO_ACESSO_DTO DTO, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ID", DTO.ID);
            cmd.Parameters.AddWithValue("@ID_PERFIL", DTO.ID_PERFIL);
            cmd.Parameters.AddWithValue("@ID_SYS_MENU", DTO.ID_SYS_MENU);

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
