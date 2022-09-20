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
/// Summary description for Agencyrolemaster
/// </summary>
public class Agencyrolemaster:connection 
{
	public Agencyrolemaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
 public DataSet bindagencycode(string compcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("bindagencycode_bindagencycode_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;       


            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    public DataSet insertrole(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid,string level)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("insertintorole_insertintorole_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code1"].Value = code;

            objmysqlcommand.Parameters.Add("nameofrole", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nameofrole"].Value = nameofrole;

            objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["agencycode"].Value = agencycode;

            objmysqlcommand.Parameters.Add("subcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcode"].Value = subcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("pLEVEL", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["pLEVEL"].Value = level;
                              

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    public DataSet modifyrole(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid, string level)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("modifyintorole_modifyintorole_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code1"].Value = code;

            objmysqlcommand.Parameters.Add("nameofrole", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nameofrole"].Value = nameofrole;

            objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["agencycode"].Value = agencycode;

            objmysqlcommand.Parameters.Add("subcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcode"].Value = subcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("level", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["level"].Value = level;






           
            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    public DataSet execute(string code, string nameofrole, string agencycode, string subcode, string compcode, string userid, string level)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("executerole_executerole_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("code", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code"].Value = code;

            objmysqlcommand.Parameters.Add("nameofrole", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nameofrole"].Value = nameofrole;

            objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["agencycode"].Value = agencycode;

            objmysqlcommand.Parameters.Add("subcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["subcode"].Value = subcode;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;

            objmysqlcommand.Parameters.Add("plevel", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["plevel"].Value = level; 

         
            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    public DataSet firstdata(string compcode, string userid)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("firstrole_firstrole_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;


            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;


           
            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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

    public DataSet chkroleage(string code, string compcode, string userid, string nameofrole)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("checkrole_checkrole_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;

            objmysqlcommand.Parameters.Add("code1", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["code1"].Value = code;

            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;


            objmysqlcommand.Parameters.Add("nameofrole", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["nameofrole"].Value = nameofrole;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (MySqlException objException)
        {
            throw (objException);
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


    public DataSet deldata(string compcode, string userid, string doccode)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("agroledel_agroledel_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["compcode"].Value = compcode;


            objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["userid"].Value = userid;


            objmysqlcommand.Parameters.Add("doccode", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["doccode"].Value = doccode;

            objmysqlDataAdapter.SelectCommand = objmysqlcommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch(MySqlException objException)
        {
            throw (objException);
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








    public DataSet chksrolecode1(string str)
    {
        MySqlConnection objmysqlconnection;
        MySqlCommand objmysqlcommand;
        objmysqlconnection = GetConnection();
        MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
        DataSet objDataSet = new DataSet();  
        try
        {
            objmysqlconnection.Open();
            objmysqlcommand = GetCommand("chkrolename_chkrolename_p", ref objmysqlconnection);
            objmysqlcommand.CommandType = CommandType.StoredProcedure;

            objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
            objmysqlcommand.Parameters["str"].Value = str;


            objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
            if(str.Length>2)
            {
            objmysqlcommand.Parameters["cod"].Value = str.Substring (0,2);
            }
            else
            {
                objmysqlcommand.Parameters["cod"].Value = str;

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










}
}
