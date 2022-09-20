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
/// Summary description for delition
/// </summary>
public class delition:connection
{
	public delition()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet statusdelete(string txtformdate, string txttodate,string status)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("statusdelete", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("fdate", MySqlDbType.DateTime);
            objmysqlcommand.Parameters["fdate"].Value =Convert.ToDateTime(txtformdate).ToString("yyyy-MM-dd");


            objmysqlcommand.Parameters.Add("tdate", MySqlDbType.DateTime);
            objmysqlcommand.Parameters["tdate"].Value = Convert.ToDateTime(txttodate).ToString("yyyy-MM-dd");


            objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
            if (status == "Confim")
            {
                objmysqlcommand.Parameters["status1"].Value = 1;
            }
            else
            {
                objmysqlcommand.Parameters["status1"].Value = 2;
            }

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }
    }


    public DataSet chkdate1(string fromdate, string todate)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkdate", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("fdate", MySqlDbType.DateTime);
            objmysqlcommand.Parameters["fdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");


            objmysqlcommand.Parameters.Add("tdate", MySqlDbType.DateTime);
            objmysqlcommand.Parameters["tdate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");


            

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objmysqlconnection);
        }
    }

}


}
