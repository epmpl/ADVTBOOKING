using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;



/// <summary>
/// Summary description for clsconnection
/// </summary>
public class clsconnection
{
    public clsconnection()
    {

    }
    public string getagencyname(string agcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            ds = executequery("select \"Agency_Name\" from agency_mast where \"code_subcode\"='" + agcode + "'");
        }
        else
            ds = executequery("select Agency_Name from agency_mast where code_subcode='" + agcode + "'");
        return ds.Tables[0].Rows[0].ItemArray[0].ToString();

    }

    public string getusername(string ucode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            ds = executequery("select \"username\" from login where \"userid\"='" + ucode + "'");
        else
            ds = executequery("select username from login where userid='" + ucode + "'");
        return ds.Tables[0].Rows[0].ItemArray[0].ToString();

    }
    public DataSet executequery(String query)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            query = query.Replace("$date", "sysdate");
            OracleCommand objSqlCommand = new OracleCommand();
            OracleConnection objOracleConnection = new OracleConnection(ConfigurationSettings.AppSettings["orclconnectionstring"]);
            OracleDataAdapter objSqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objOracleConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
                objOracleConnection.Dispose();
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
          //  query = query.Replace("$date", "getdate()");
            
           //query = "select getdate() dt";
            SqlCommand objSqlCommand = new SqlCommand();
            SqlConnection objsqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["sqlConnectionString"]);
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            try
            {
                objsqlConnection.Open();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objsqlConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objsqlConnection.Close();
                objsqlConnection.Dispose();
            }
        }
        else
        {
            query = query.Replace("$date", "now()");
            query = query.Replace("and rownum=", " limit ");
            MySqlCommand objSqlCommand = new MySqlCommand();
            MySqlConnection objOracleConnection = new MySqlConnection(ConfigurationSettings.AppSettings["mysqlconnectionstring"]);
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            try
            {
                objOracleConnection.Open();
                objSqlCommand.CommandText = query.Replace("\\", "\\\\");
                objSqlCommand.Connection = objOracleConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(ds);

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
                objOracleConnection.Dispose();
            }
        }
        
        return ds;
    } 
    public void executenonquery1(String query)
    {
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            query = query.Replace("$date", "sysdate");
            OracleCommand objSqlCommand = new OracleCommand();
            OracleConnection objOracleConnection = new OracleConnection(ConfigurationSettings.AppSettings["orclconnectionstring"]);
            try
            {
                objOracleConnection.Open();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objOracleConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlCommand.ExecuteNonQuery();

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
                objOracleConnection.Dispose();
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            query = query.Replace("$date", "getdate()");
            SqlCommand objSqlCommand = new SqlCommand();
            SqlConnection objsqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["sqlConnectionString"]);
            
            try
            {
                objsqlConnection.Open();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objsqlConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objsqlConnection.Close();
                objsqlConnection.Dispose();
            }
        }
        else
        {
            query = query.Replace("$date", "now()");
            MySqlCommand objSqlCommand = new MySqlCommand();
            MySqlConnection objOracleConnection = new MySqlConnection(ConfigurationSettings.AppSettings["mysqlconnectionstring"]);
            try
            {
                objOracleConnection.Open();
                objSqlCommand.CommandText = query.Replace("\\", "\\\\");
                objSqlCommand.Connection = objOracleConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlCommand.ExecuteNonQuery();

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
                objOracleConnection.Dispose();
            }
        }
        
    }
    public string executenonqueryd(String query)
    {
        string err = "";
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            query = query.Replace("$date", "sysdate");
            OracleCommand objSqlCommand = new OracleCommand();
            OracleConnection objOracleConnection = new OracleConnection(ConfigurationSettings.AppSettings["orclconnectionstring"]);
            try
            {
                objOracleConnection.Open();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objOracleConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlCommand.ExecuteNonQuery();

            }
            catch (Exception objException)
            {
                err = objException.Message;
            }
            finally
            {
                objOracleConnection.Close();
                objOracleConnection.Dispose();
            }
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            query = query.Replace("$date", "getdate()");
            SqlCommand objSqlCommand = new SqlCommand();
            SqlConnection objsqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["sqlConnectionString"]);
            
            try
            {
                objsqlConnection.Open();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objsqlConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objsqlConnection.Close();
                objsqlConnection.Dispose();
            }
        }
        else
        {
            query = query.Replace("$date", "now()");
            MySqlCommand objSqlCommand = new MySqlCommand();
            MySqlConnection objOracleConnection = new MySqlConnection(ConfigurationSettings.AppSettings["mysqlconnectionstring"]);
            try
            {
                objOracleConnection.Open();
                objSqlCommand.CommandText = query.Replace("\\", "\\\\");
                objSqlCommand.Connection = objOracleConnection;
                objSqlCommand.CommandType = CommandType.Text;
                objSqlCommand.ExecuteNonQuery();

            }
            catch (Exception objException)
            {
                err = objException.Message;
            }
            finally
            {
                objOracleConnection.Close();
                objOracleConnection.Dispose();
            }
        }
        
        return err;
    }


}
