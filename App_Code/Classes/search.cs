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
namespace NewAdbooking.Classes
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

        string zonename = "";
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter=new SqlDataAdapter ();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_getagName", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
            objSqlCommand.Parameters["@center"].Value = System.DBNull.Value;

            objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agency"].Value = agency;

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
        string zonename = "";
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_getclientName", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;
            objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
            objSqlCommand.Parameters["@client"].Value = client;
            objSqlDataAdapter = new SqlDataAdapter();
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
        string zonename = "";
        SqlConnection objSqlConnection;//GetAgency_search
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("GetAgency_search", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;
            objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
            objSqlCommand.Parameters["@client"].Value = client;

            objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
            objSqlCommand.Parameters["@value"].Value = value;

            objSqlDataAdapter = new SqlDataAdapter();
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
        string zonename = "";
        SqlConnection objSqlConnection;//GetAgency_search
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("websp_getsperson", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
            objSqlCommand.Parameters["@username"].Value = username;

            objSqlDataAdapter = new SqlDataAdapter();
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
    public DataSet advance_search(string compcode, string agname, string clientname, string username, string fromdate, string dateto, string sheldate, string insertntodate1, string text, string clientcode, string rostatus, string dateformat)
    {
        
       

        string zonename = "";
        SqlConnection objSqlConnection;//GetAgency_search
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter;
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("ctr_advance_search", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

            objSqlCommand.Parameters.Add("@agname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@agname"].Value = agname;
            objSqlCommand.Parameters.Add("@clientname", SqlDbType.VarChar);
            objSqlCommand.Parameters["@clientname"].Value = clientname;
            objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
            objSqlCommand.Parameters["@username"].Value = username;
            objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
            if (fromdate != "")
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split("/".ToCharArray());
                    fromdate = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();
                }
                if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = fromdate.Split("/".ToCharArray());
                    fromdate = arr[1].ToString() + "/" + arr[2].ToString() + "/" + arr[0].ToString();
                }
            }
            objSqlCommand.Parameters["@fromdate"].Value = fromdate;

            objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
            if (dateto != "")
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = dateto.Split("/".ToCharArray());
                    dateto = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();
                }
                if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = dateto.Split("/".ToCharArray());
                    dateto = arr[1].ToString() + "/" + arr[2].ToString() + "/" + arr[0].ToString();
                }
            }

            objSqlCommand.Parameters["@dateto"].Value = dateto;

            objSqlCommand.Parameters.Add("@sheldate", SqlDbType.VarChar);
            if (sheldate != "")
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = sheldate.Split("/".ToCharArray());
                    sheldate = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();
                }
                if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = sheldate.Split("/".ToCharArray());
                    sheldate = arr[1].ToString() + "/" + arr[2].ToString() + "/" + arr[0].ToString();
                }
            }
            objSqlCommand.Parameters["@sheldate"].Value = sheldate;
            objSqlCommand.Parameters.Add("@insertntodate1", SqlDbType.VarChar);
            if (insertntodate1 != "")
            {
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = insertntodate1.Split("/".ToCharArray());
                    insertntodate1 = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();
                }
                if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = insertntodate1.Split("/".ToCharArray());
                    insertntodate1 = arr[1].ToString() + "/" + arr[2].ToString() + "/" + arr[0].ToString();
                }
            }
            objSqlCommand.Parameters["@insertntodate1"].Value = insertntodate1;
            objSqlCommand.Parameters.Add("@adtext", SqlDbType.VarChar);
            objSqlCommand.Parameters["@adtext"].Value = text;
            objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
            objSqlCommand.Parameters["@rostatus"].Value = rostatus;
            objSqlCommand.Parameters.Add("@clientcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@clientcode"].Value = clientcode;


            objSqlDataAdapter = new SqlDataAdapter();
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