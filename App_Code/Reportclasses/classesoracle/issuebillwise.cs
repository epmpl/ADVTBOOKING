using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OracleClient;
namespace NewAdbooking.Report.classesoracle
{
/// <summary>
/// Summary description for issuebillwise
/// </summary>
public class issuebillwise  : orclconnection
{
	public issuebillwise()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet pub_cent_NEW(string compcode, string chk_access, string useid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("Bind_PubCentName_r.Bind_PubCentName_r_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;



            OracleParameter prm1 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = useid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("chk_access", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = chk_access;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);


            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (OracleException objException)
        {
            throw (objException);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }


    public DataSet district(string compcode, string userid)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("CityMst_District.CityMst_District_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = userid;
            objOraclecommand.Parameters.Add(prm2);
            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objmysqlDataAdapter.SelectCommand = objOraclecommand;
            objmysqlDataAdapter.Fill(objDataSet);
            return objDataSet;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }
    }

    public DataSet adbranch(string compcode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();

            objOraclecommand = GetCommand("branchbind_adv.branchbind_adv_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = compcode;
            objOraclecommand.Parameters.Add(prm11);

            objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
            objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;

        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }

    public DataSet advpub(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {



            objOracleConnection.Open();
            objOraclecommand = GetCommand("Bind_PubName.Bind_PubName_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);


            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (OracleException objException)
        {
            throw (objException);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }

    public DataSet pub_Edtn(string compcode, string publ_code, string dateformat, string extra1, string extra2)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("edition_proc.edition_proc_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;


            OracleParameter prm3 = new OracleParameter("pubcode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = publ_code;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = extra1;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

            objorclDataAdapter.SelectCommand = objOraclecommand;
            objorclDataAdapter.Fill(objDataSet);
            return objDataSet;


        }
        catch (OracleException objException)
        {
            throw (objException);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            CloseConnection(ref objOracleConnection);
        }

    }


}
}

