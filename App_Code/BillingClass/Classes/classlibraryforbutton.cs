using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;/// <summary>
/// Summary description for classlibraryforbutton
/// </summary>
/// 

/// <summary>
/// Summary description for bill_format
/// </summary>
/// 
namespace NewAdbooking.BillingClass.Classes
{
    public class classlibraryforbutton : NewAdbooking.Classes.connection
{
	public classlibraryforbutton()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   public DataSet getbuttonpermission(string compcode,string userid,string formname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_showpermission", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


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

