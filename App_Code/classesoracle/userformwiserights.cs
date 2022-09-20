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
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for userformwiserights
/// </summary>
    public class userformwiserights : orclconnection
{
	public userformwiserights()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet binduserid(string logincode, string dateformat,string extra1,string extra2)
    {
        OracleConnection con;
        OracleCommand cmd;
        con = GetConnection();
        DataSet ds = new DataSet();
        OracleDataAdapter da = new OracleDataAdapter();
        try
        {
           con.Open();
           cmd = GetCommand("cir_login_bind.cir_login_bind_p", ref con);
           cmd.CommandType = CommandType.StoredProcedure;

             OracleParameter prm1 = new OracleParameter("plogin_code", OracleType.VarChar, 1000);
             prm1.Direction = ParameterDirection.Input;
             prm1.Value = logincode;
             cmd.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 1000);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = dateformat;
            cmd.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = extra1;
            cmd.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = extra2;
            cmd.Parameters.Add(prm4);

             cmd.Parameters.Add("p_accounts", OracleType.Cursor);
             cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

             da.SelectCommand = cmd;
             da.Fill(ds);
             return ds;
        }
        catch(Exception ex)
        {
         throw ex;
        }
        finally
        {
        CloseConnection(ref con);
        }
    }

    public DataSet bindcompname(string usercode,string dateformat,string extra1,string extra2)
    {
         OracleConnection con;
         OracleCommand cmd;
         con = GetConnection();
        DataSet ds = new DataSet();
        OracleDataAdapter da = new OracleDataAdapter();
        try
        {
            con.Open();
            cmd = GetCommand("cir_change_company.cir_change_company_p", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("puser_code",OracleType.VarChar, 1000);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = usercode;
            cmd.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pdateformat",OracleType.VarChar, 1000);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = dateformat;
            cmd.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra1",OracleType.VarChar, 1000);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = extra1;
            cmd.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pextra2",OracleType.VarChar, 1000);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = extra2;
            cmd.Parameters.Add(prm4);

            cmd.Parameters.Add("p_accounts",OracleType.Cursor);
             cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet bindunit()
        {
        OracleConnection con;
         OracleCommand cmd;
         con = GetConnection();
        DataSet ds = new DataSet();
        OracleDataAdapter da = new OracleDataAdapter();

        try
        {
            con.Open();
            cmd = GetCommand("websp_pubcenter.websp_pubcenter_p", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_accounts", OracleType.Cursor);
            cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
            cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet bindmodule(string modulecode,string dateformat,string extra1,string extra2)
        {
        OracleConnection con;
         OracleCommand cmd;
         con = GetConnection();
         DataSet ds = new DataSet();
         OracleDataAdapter da = new OracleDataAdapter();
             try
        {
            con.Open();
            cmd = GetCommand("user_privileges.module_bind_p", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pmodule_code",OracleType.VarChar, 1000);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = modulecode;
            cmd.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pdateformat",OracleType.VarChar, 1000);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = dateformat;
            cmd.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra1",OracleType.VarChar, 1000);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = extra1;
            cmd.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pextra2",OracleType.VarChar, 1000);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = extra2;
            cmd.Parameters.Add(prm4);

             cmd.Parameters.Add("p_accounts", OracleType.Cursor);
            cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
        public DataSet reportdata(string compcode, string unitcode, string usercode, string modulecode, string dateformat, string extra1, string extra2)
         {
         OracleConnection con;
         OracleCommand cmd;
         con = GetConnection();
         DataSet ds = new DataSet();
         OracleDataAdapter da = new OracleDataAdapter();
             try
        {
            con.Open();
            cmd = GetCommand("ad_rep_user_form_rights", ref con);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcomp_code",OracleType.VarChar, 1000);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            cmd.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("punit_code",OracleType.VarChar, 1000);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = unitcode;
            cmd.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("puser_code",OracleType.VarChar, 1000);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = usercode;
            cmd.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("pmodule_code",OracleType.VarChar, 1000);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = modulecode;
            cmd.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("pdateformat",OracleType.VarChar, 1000);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = dateformat;
            cmd.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("pextra1",OracleType.VarChar, 1000);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = extra1;
            cmd.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pextra2",OracleType.VarChar, 1000);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = extra2;
            cmd.Parameters.Add(prm7);

            cmd.Parameters.Add("p_accounts", OracleType.Cursor);
            cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            cmd.Parameters.Add("p_accounts1", OracleType.Cursor);
            cmd.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
         }
    


}