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
/// 
/// Summary description for EncryptPassword
/// </summary>
namespace NewAdbooking.Classes
{
    public class EncryptPassword : connection
    {
        public EncryptPassword()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public DataSet encrypt()
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("encrypt_password", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

                
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        public DataSet encrypt()
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                string query = "SELECT  userid,password,COM_CODE from login";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet update(string compcode, string userid, string password)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                string query = "update login set password ='" + password + "' where  userid = '" + userid + "'  and COM_CODE = '" + compcode + "'";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        //public DataSet update(string compcode, string userid, string password)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("encrypt_password_update", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;

        //        objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@pcompcode"].Value = compcode;

        //        objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@puserid"].Value = userid;


        //        objSqlCommand.Parameters.Add("@ppassword", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@ppassword"].Value = password;


        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);

        //        return objDataSet;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}




    }
}