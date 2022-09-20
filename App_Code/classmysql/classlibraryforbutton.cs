using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
/// <summary>
/// Summary description for classlibraryforbutton
/// </summary>
public class classlibraryforbutton:connection
{
	public classlibraryforbutton()
	{
		//
		// TODO: Add constructor logic here
		//
	}

     public DataSet getbuttonpermission(string compcode,string userid,string formname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_Showpermission_Websp_Showpermission_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("Compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("Vuserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Vuserid"].Value = userid;
                objmysqlcommand.Parameters.Add("Formname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["Formname"].Value = formname;
               
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
                //objSqlConnection.Open();
                //objSqlCommand = GetCommand("websp_showpermission", ref objSqlConnection);
                //objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlCommand.Parameters.Add("@formname", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["@formname"].Value = formname;

                //objSqlCommand.Parameters.Add("@compcode", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", MySqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;


                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlDataAdapter.Fill(objDataSet);

                //return objDataSet;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }

        }
}
}