using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for Pub_Cent_Box_Add
/// </summary>
public class Pub_Cent_Box_Add : orclconnection
{
	public Pub_Cent_Box_Add()
	{
		//
		// TODO: Add constructor logic here
		//
	}
//*******************************************************************************************************************//
    public DataSet getPubCenter()
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_pubcenter.websp_pubcenter_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            //OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
            //prm2.Direction = ParameterDirection.Input;
            //prm2.Value = compcode;
            //objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
    public DataSet pubcent(string compcode, string pubcent)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_chkcenter", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pubcent", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pubcent;
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
    public DataSet pubsave(string pubcent, string compcode, string userid, string engbox, string hinbox, string punbox) 
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_savepub_cent", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pubcent", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pubcent;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = userid;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("engbox", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = engbox;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("hinbox", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = hinbox;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("punbox", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = punbox;
            objOraclecommand.Parameters.Add(prm6);

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
    public DataSet modifydata(string compcode, string pubcent, string engbox, string hinbox, string punbox)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_update_cent", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pubcent", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pubcent;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm4 = new OracleParameter("engbox", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = engbox;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("hinbox", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = hinbox;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("punbox", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = punbox;
            objOraclecommand.Parameters.Add(prm6);

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
    public DataSet execpubbox(string compcode, string pubcent)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_exec_cent", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pubcent", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pubcent;
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
    public DataSet deletedata(string compcode, string pubcent)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("websp_delete_cent", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pubcent", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = pubcent;
            objOraclecommand.Parameters.Add(prm2);

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception objException)
        {
            throw (objException);
        }
        finally
        {
            objOracleConnection.Close();
        }
    }
}
}
