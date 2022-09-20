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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.Classes
{

    public class Pub_Cent_Box_Add : connection
    {
        public Pub_Cent_Box_Add()
        {
            //
            // TODO: Add constructor logic here
            //
        }
//**************************************Start********************************************//
        public DataSet getPubCenter()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

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
public DataSet pubcent(string compcode, string pubcent)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_chkcenter", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubcent"].Value = pubcent;

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
 public DataSet pubsave(string pubcent, string compcode, string userid, string engbox, string hinbox, string punbox) 
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_savepub_cent", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubcent"].Value = pubcent;

            objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@userid"].Value = userid;

            objSqlCommand.Parameters.Add("@engbox", SqlDbType.VarChar);
            objSqlCommand.Parameters["@engbox"].Value = engbox;

            objSqlCommand.Parameters.Add("@hinbox", SqlDbType.VarChar);
            objSqlCommand.Parameters["@hinbox"].Value = hinbox;

            objSqlCommand.Parameters.Add("@punbox", SqlDbType.VarChar);
            objSqlCommand.Parameters["@punbox"].Value = punbox;

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
public DataSet modifydata(string compcode, string pubcent, string engbox, string hinbox, string punbox)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_update_cent", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubcent"].Value = pubcent;

            objSqlCommand.Parameters.Add("@engbox", SqlDbType.VarChar);
            objSqlCommand.Parameters["@engbox"].Value = engbox;

            objSqlCommand.Parameters.Add("@hinbox", SqlDbType.VarChar);
            objSqlCommand.Parameters["@hinbox"].Value = hinbox;

            objSqlCommand.Parameters.Add("@punbox", SqlDbType.VarChar);
            objSqlCommand.Parameters["@punbox"].Value = punbox;

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
public DataSet execpubbox(string compcode, string pubcent)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_exec_cent", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubcent"].Value = pubcent;

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
public DataSet deletedata(string compcode, string pubcent)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_delete_cent", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@pubcent", SqlDbType.VarChar);
            objSqlCommand.Parameters["@pubcent"].Value = pubcent;

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
