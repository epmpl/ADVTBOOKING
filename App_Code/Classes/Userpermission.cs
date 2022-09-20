using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Userpermission
/// </summary>
namespace NewAdbooking.Classes
{
    public class Userpermission : connection
    {
        public Userpermission()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet userchk(string compcode, string user)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkuserforper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@user1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user1"].Value = user;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet savedata(string compcode, string userid, string schedule, string loguser, string permission_desc, string delflag, string keyboard, string keyboardtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("saveuserforper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@user1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user1"].Value = userid;

                objSqlCommand.Parameters.Add("@schedule", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schedule"].Value = schedule;

                objSqlCommand.Parameters.Add("@loguser", SqlDbType.VarChar);
                objSqlCommand.Parameters["@loguser"].Value = loguser;

                objSqlCommand.Parameters.Add("@permission_desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@permission_desc"].Value = permission_desc;

                objSqlCommand.Parameters.Add("@del_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@del_flag"].Value = delflag;

                objSqlCommand.Parameters.Add("@keyboard_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyboard_p"].Value = keyboard;

                objSqlCommand.Parameters.Add("@keyboardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyboardtype"].Value = keyboardtype;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet save_perdetail(string user,string permission_desc,string from_osbal,string to_osbal,string no_oftimes,string period,string allow_flag,string loguser)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("saveuserfor_perdetail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@usercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@usercode"].Value = user;

                objSqlCommand.Parameters.Add("@permission_desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@permission_desc"].Value = permission_desc;

                objSqlCommand.Parameters.Add("@from_osbal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@from_osbal"].Value = from_osbal;

                objSqlCommand.Parameters.Add("@to_osbal", SqlDbType.VarChar);
                objSqlCommand.Parameters["@to_osbal"].Value = to_osbal;

                objSqlCommand.Parameters.Add("@no_oftimes", SqlDbType.VarChar);
                objSqlCommand.Parameters["@no_oftimes"].Value = no_oftimes;

                objSqlCommand.Parameters.Add("@period", SqlDbType.VarChar);
                objSqlCommand.Parameters["@period"].Value = period;

                objSqlCommand.Parameters.Add("@allow_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@allow_flag"].Value = allow_flag;

                objSqlCommand.Parameters.Add("@loguser", SqlDbType.VarChar);
                objSqlCommand.Parameters["@loguser"].Value = loguser;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet execuser(string compcode, string userid, string schedule)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("execuserforper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@user1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user1"].Value = userid;

                objSqlCommand.Parameters.Add("@schedule", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schedule"].Value = schedule;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet modifydata(string compcode, string user, string schedule)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateuserforper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@user1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user1"].Value = user;

                objSqlCommand.Parameters.Add("@schedule", SqlDbType.VarChar);
                objSqlCommand.Parameters["@schedule"].Value = schedule;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet deletedata(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("deluserforper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@user1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user1"].Value = userid;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet get_username(string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "Select dbo.cir_get_login('" + userid + "') AS user_name";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return (objDataSet);


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet Get_Rolename(string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "Select dbo.cir_get_login_role('" + userid + "') AS role_name";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return (objDataSet);


            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet filluser_permission(string userid, string compcode, string login_userid, string per_desc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fill_userpermission", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@comp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@comp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@user_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@user_id"].Value = userid;

                objSqlCommand.Parameters.Add("@loginuserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@loginuserid"].Value = login_userid;

                objSqlCommand.Parameters.Add("@per_desc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@per_desc"].Value = per_desc;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
    }
}
