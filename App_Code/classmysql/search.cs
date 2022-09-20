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
/// Summary description for search
/// </summary>
public class search:connection 
{
	public search()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 public DataSet bindagency(string compcode, string agency)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("bindagencyforsearch", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;



            objSqlCommand.Parameters.Add("agency", MySqlDbType.VarChar);
            objSqlCommand.Parameters["agency"].Value = agency;

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

    public DataSet getClientName(string compcode, string client)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;
            objSqlCommand.Parameters.Add("client1", MySqlDbType.VarChar);
            objSqlCommand.Parameters["client1"].Value = client;
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

    public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("GetAgency_search", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;
            objSqlCommand.Parameters.Add("client", MySqlDbType.VarChar);
            objSqlCommand.Parameters["client"].Value = client;

            objSqlCommand.Parameters.Add("value", MySqlDbType.VarChar);
            objSqlCommand.Parameters["value"].Value = value;

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

    public DataSet Getusername(string username)
    {
        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("getUserName1", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("username", MySqlDbType.VarChar);
            objSqlCommand.Parameters["username"].Value = username;

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

    //public DataSet advance_search( string agency, string sperson, string cust, string fromdate, string todate,string sheldate,string  insertntodate ,string text)
    public DataSet advance_search(string compcode, string agname, string clientname, string username, string fromdate, string dateto, string sheldate, string insertntodate1,string text, string clientcode,string dateformat)
    {



        MySqlConnection objSqlConnection;
        MySqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("advance_search", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("agname", MySqlDbType.VarChar);
            objSqlCommand.Parameters["agname"].Value = agname;
            objSqlCommand.Parameters.Add("clientname", MySqlDbType.VarChar);
            objSqlCommand.Parameters["clientname"].Value = clientname;
            objSqlCommand.Parameters.Add("username", MySqlDbType.VarChar);
            objSqlCommand.Parameters["username"].Value = username;
            objSqlCommand.Parameters.Add("fromdate", MySqlDbType .Datetime);
            if (fromdate == null || fromdate == "" || fromdate == "undefined/undefined/")
            {
                objSqlCommand.Parameters["fromdate"].Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;

                }

                objSqlCommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");
            }
          
            objSqlCommand.Parameters.Add("dateto", MySqlDbType.Datetime);
            if (dateto == null || dateto == "" || dateto == "undefined/undefined/")
            {
                objSqlCommand.Parameters["dateto"].Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto = mm + "/" + dd + "/" + yy;

                }

                objSqlCommand.Parameters["dateto"].Value = Convert.ToDateTime(dateto).ToString("yyyy-MM-dd");
            }

            objSqlCommand.Parameters.Add("sheldate", MySqlDbType.Datetime);
            if (sheldate == null || sheldate == "" || insertntodate1 == "undefined/undefined/")
            {
                objSqlCommand.Parameters["sheldate"].Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = sheldate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    sheldate = mm + "/" + dd + "/" + yy;

                }

                objSqlCommand.Parameters["sheldate"].Value = Convert.ToDateTime(sheldate).ToString("yyyy-MM-dd");
            }



            objSqlCommand.Parameters.Add("insertntodate1", MySqlDbType.Datetime);
            if (insertntodate1 == null || insertntodate1 == "" || insertntodate1 == "undefined/undefined/")
            {
                objSqlCommand.Parameters["insertntodate1"].Value = System.DBNull.Value;
            }
            else
            {

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = insertntodate1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    insertntodate1 = mm + "/" + dd + "/" + yy;

                }

                objSqlCommand.Parameters["insertntodate1"].Value = Convert.ToDateTime(insertntodate1).ToString("yyyy-MM-dd");
            }

            objSqlCommand.Parameters.Add("adtext", MySqlDbType.VarChar);
            objSqlCommand.Parameters["adtext"].Value = text;

            objSqlCommand.Parameters.Add("clientcode", MySqlDbType.VarChar);
            objSqlCommand.Parameters["clientcode"].Value = clientcode;

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