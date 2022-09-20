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
/// Summary description for VarientMaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
public class VarientMaster:connection
{
	public VarientMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet productdes(string compcode)
    {
        SqlConnection con;
        SqlCommand cmd;
        con = GetConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        try
        {
            con.Open();
            cmd = GetCommand("drpbrand", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
            cmd.Parameters["@compcode"].Value = compcode;


            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection(ref con);
        }
    }

    //Check code
    public DataSet chkcode(string code, string compcode)
    {
        SqlConnection con;
        SqlCommand cmd;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            cmd = GetCommand("chkvarientcode", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
            cmd.Parameters["@compcode"].Value = compcode;

            cmd.Parameters.Add("@code", SqlDbType.VarChar);
            cmd.Parameters["@code"].Value = code;


            da.SelectCommand = cmd;
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
    //Insert the value
    public DataSet insertedvalue(string drpbrand, string varientcode, string varientname, string varientalias, string compcode, string userid)
    {
        SqlConnection con;
        SqlCommand cmd;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            cmd = GetCommand("varientinsert", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
            cmd.Parameters["@compcode"].Value = compcode;

            cmd.Parameters.Add("@varientcode", SqlDbType.VarChar);
            cmd.Parameters["@varientcode"].Value = varientcode;

            cmd.Parameters.Add("@varientname", SqlDbType.VarChar);
            cmd.Parameters["@varientname"].Value = varientname;

            cmd.Parameters.Add("@varientalias", SqlDbType.VarChar);
            cmd.Parameters["@varientalias"].Value = varientalias;

            cmd.Parameters.Add("@userid", SqlDbType.VarChar);
            cmd.Parameters["@userid"].Value = userid;

            cmd.Parameters.Add("@drpbrand", SqlDbType.VarChar);
            cmd.Parameters["@drpbrand"].Value = drpbrand;


            da.SelectCommand = cmd;
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

    //Auto generated code
    public DataSet autocode(string str, string brand)
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        con = GetConnection();

        try
        {
            con.Open();
            cmd = GetCommand("varientautocode", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@str", SqlDbType.VarChar);
            cmd.Parameters["@str"].Value = str;

            cmd.Parameters.Add("@cod", SqlDbType.VarChar);
            cmd.Parameters["@cod"].Value = str;

            cmd.Parameters.Add("@brand", SqlDbType.VarChar);
            cmd.Parameters["@brand"].Value = brand;

            da.SelectCommand = cmd;
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

    //Execute Value
    public DataSet prosubexecute(string drpprodes, string varientcode, string varientname, string varientalias, string compcode)
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        con = GetConnection();

        try
        {
            con.Open();
            cmd = GetCommand("varientexe", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@drpbrand", SqlDbType.VarChar);
            cmd.Parameters["@drpbrand"].Value = drpprodes;

            cmd.Parameters.Add("@varientcode", SqlDbType.VarChar);
            cmd.Parameters["@varientcode"].Value = varientcode;

            cmd.Parameters.Add("@varientname", SqlDbType.VarChar);
            cmd.Parameters["@varientname"].Value = varientname;

            cmd.Parameters.Add("@varientalias", SqlDbType.VarChar);
            cmd.Parameters["@varientalias"].Value = varientalias;

            cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
            cmd.Parameters["@compcode"].Value = compcode;

            da.SelectCommand = cmd;
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

    //Delete The Value
    public DataSet deleteproduct(string varientcode, string compcode)
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        con = GetConnection();
        try
        {
            con.Open();
            cmd = GetCommand("varientdel", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@varientcode", SqlDbType.VarChar);
            cmd.Parameters["@varientcode"].Value = varientcode;

            cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
            cmd.Parameters["@compcode"].Value = compcode;

            da.SelectCommand = cmd;
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

    //Modify The Value
    public DataSet updatepro(string drpprodes, string varientcode, string varientname, string varientalias, string compcode)
    {
        SqlConnection con;
        SqlCommand cmd;
        con = GetConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            con.Open();
            cmd = GetCommand("varientmodify", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@drpbrand", SqlDbType.VarChar);
            cmd.Parameters["@drpbrand"].Value = drpprodes;

            cmd.Parameters.Add("@varientcode", SqlDbType.VarChar);
            cmd.Parameters["@varientcode"].Value = varientcode;

            cmd.Parameters.Add("@varientname", SqlDbType.VarChar);
            cmd.Parameters["@varientname"].Value = varientname;

            cmd.Parameters.Add("@varientalias", SqlDbType.VarChar);
            cmd.Parameters["@varientalias"].Value = varientalias;

            cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
            cmd.Parameters["@compcode"].Value = compcode;


            da.SelectCommand = cmd;
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
    }
}
