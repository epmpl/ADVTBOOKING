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
/// Summary description for Zonemaster
/// </summary>
namespace NewAdbooking.Classes
{
public class Zonemaster:connection
{
	public Zonemaster()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public DataSet Advsave1(string companycode, string zonecode, string zonename, string alias, string UserId)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("ZONE_SAVE", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = companycode;

            com.Parameters.Add("@zonecode", SqlDbType.VarChar);
            com.Parameters["@zonecode"].Value = zonecode;

            com.Parameters.Add("@zonename", SqlDbType.VarChar);
            com.Parameters["@zonename"].Value = zonename;

            com.Parameters.Add("@zonealias", SqlDbType.VarChar);
            com.Parameters["@zonealias"].Value = alias;

            com.Parameters.Add("@userid", SqlDbType.VarChar);
            com.Parameters["@userid"].Value = UserId;

            da.SelectCommand = com;
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

    public DataSet Advmodify1(string companycode, string zonecode, string zonename, string alias, string UserId)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("ZONE_MODIFY", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = companycode;

            com.Parameters.Add("@zonecode", SqlDbType.VarChar);
            com.Parameters["@zonecode"].Value = zonecode;

            com.Parameters.Add("@zonename", SqlDbType.VarChar);
            com.Parameters["@zonename"].Value = zonename;

            com.Parameters.Add("@zonealias", SqlDbType.VarChar);
            com.Parameters["@zonealias"].Value = alias;

            //com.Parameters.Add("@userid", SqlDbType.VarChar);
            //com.Parameters["@userid"].Value = UserId;

            da.SelectCommand = com;
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

    public DataSet Advdelete(string companycode, string zonecode, string zonename, string alias, string UserId)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("Zone_Delete", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
            com.Parameters["@Comp_Code"].Value = companycode;

            com.Parameters.Add("@Zone_Code", SqlDbType.VarChar);
            com.Parameters["@Zone_Code"].Value = zonecode;

            com.Parameters.Add("@Zone_Name", SqlDbType.VarChar);
            com.Parameters["@Zone_Name"].Value = zonename;

            com.Parameters.Add("@Zone_Alias", SqlDbType.VarChar);
            com.Parameters["@Zone_Alias"].Value = alias;

            //com.Parameters.Add("@UserId", SqlDbType.VarChar);
            //com.Parameters["@UserId"].Value = UserId;

            da.SelectCommand = com;
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

    public DataSet Advexecute1(string companycode, string zonecode, string zonename, string alias, string UserId)
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("Zone_Execute", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
            com.Parameters["@Comp_Code"].Value = companycode;

            com.Parameters.Add("@Zone_Code", SqlDbType.VarChar);
            //if (zonecode != "" && zonecode != null)
            //{
              com.Parameters["@Zone_Code"].Value = zonecode;
            //}
            //else
            //{
             //   com.Parameters["@Zone_Code"].Value = "%%";
          //  }

            com.Parameters.Add("@Zone_Name", SqlDbType.VarChar);
            //if (zonename != "" && zonename != null)
            //{
           com.Parameters["@Zone_Name"].Value = zonename;
            //}
            //else
            //{
                //com.Parameters["@Zone_Name"].Value = "%%";
            //}

            com.Parameters.Add("@Zone_Alias", SqlDbType.VarChar);
            //if (alias != "" && alias != null)
            //{
             com.Parameters["@Zone_Alias"].Value = alias;
            //}
            //else
            //{
              //  com.Parameters["@Zone_Alias"].Value = "%%";
           // }


            //com.Parameters.Add("@UserId", SqlDbType.VarChar);
            //com.Parameters["@UserId"].Value = UserId;

            da.SelectCommand = com;
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

    public DataSet Advexecute2(string companycode, string zonecode, string zonename, string alias, string UserId)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("Zone_Execute", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@Comp_Code", SqlDbType.VarChar);
            com.Parameters["@Comp_Code"].Value = companycode;

            com.Parameters.Add("@Zone_Code", SqlDbType.VarChar);
            if (zonecode != "" && zonecode != null)
            {
                com.Parameters["@Zone_Code"].Value = zonecode;
            }
            else
            {
                com.Parameters["@Zone_Code"].Value = "%%";
            }

            com.Parameters.Add("@Zone_Name", SqlDbType.VarChar);
            if (zonename != "" && zonename != null)
            {
                com.Parameters["@Zone_Name"].Value = zonename;
            }
            else
            {
                com.Parameters["@Zone_Name"].Value = "%%";
            }

            com.Parameters.Add("@Zone_Alias", SqlDbType.VarChar);
            if (alias != "" && alias != null)
            {
                com.Parameters["@Zone_Alias"].Value = alias;
            }
            else
            {
                com.Parameters["@Zone_Alias"].Value = "%%";
            }

            com.Parameters.Add("@UserId", SqlDbType.VarChar);
            com.Parameters["@UserId"].Value = UserId;

            da.SelectCommand = com;
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


    public DataSet Zonefpnl()
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("Zonefpnl", ref con);
            com.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = com;
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

    public DataSet chkzonecode(string companycode, string UserId, string zonecode,string zonename)
    {
        SqlConnection con;
        SqlCommand com;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            com = GetCommand("zonechk", ref con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@compcode", SqlDbType.VarChar);
            com.Parameters["@compcode"].Value = companycode;

            com.Parameters.Add("@zonecode", SqlDbType.VarChar);
            com.Parameters["@zonecode"].Value = zonecode;

            com.Parameters.Add("@userid", SqlDbType.VarChar);
            com.Parameters["@userid"].Value = UserId;

            com.Parameters.Add("@zonename", SqlDbType.VarChar);
            com.Parameters["@zonename"].Value = zonename;

            da.SelectCommand = com;
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

    public DataSet countzonecode(string str,string compcode)
    {
        SqlConnection objSqlConnection;
        SqlCommand objSqlCommand;
        objSqlConnection = GetConnection();
        SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        try
        {
            objSqlConnection.Open();
            objSqlCommand = GetCommand("chkzonecodename", ref objSqlConnection);
            objSqlCommand.CommandType = CommandType.StoredProcedure;

            objSqlCommand.Parameters.Add("@str", SqlDbType.VarChar);
            objSqlCommand.Parameters["@str"].Value = str;

            objSqlCommand.Parameters.Add("@cod", SqlDbType.VarChar);
            objSqlCommand.Parameters["@cod"].Value = str;

            objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
            objSqlCommand.Parameters["@compcode"].Value = compcode;

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
