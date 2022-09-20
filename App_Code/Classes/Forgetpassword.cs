using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{

/// <summary>
/// Summary description for Forgetpassword
/// </summary>
public class Forgetpassword : connection
{
	public Forgetpassword()
	{
	
	}


    public DataSet userexecute(string mail)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();

        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("mailchk", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            
            
            
            objSqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@emailid"].Value = mail;
            
            
            
            
            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
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


    public DataSet fetchData(string mail)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();

        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("forgetpassword", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;


            objSqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar);
            objSqlCommand.Parameters["@emailid"].Value = mail;
            
            
            objSqlDataAdapter = new SqlDataAdapter();
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);
            return objDataSet;
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


}
}