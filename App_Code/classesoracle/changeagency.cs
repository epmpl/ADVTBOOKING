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
/// Summary description for changeagency
/// </summary>
public class changeagency:orclconnection
{
	public changeagency()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet executeauditmast1(string bookingid, string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("executebookingdispaudit.executebookingdispaudit_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("ciobookid", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = bookingid;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            //OracleParameter prm3 = new OracleParameter("booking", OracleType.VarChar);
            //prm3.Direction = ParameterDirection.Input;
            //prm3.Value = adtype;
            //objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("docno", OracleType.VarChar);
            prm4.Direction = ParameterDirection.Input;
            prm4.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("keyno", OracleType.VarChar);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("rono", OracleType.VarChar);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("agencycode", OracleType.VarChar);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("client", OracleType.VarChar);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm8);

            //OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar);
            //prm9.Direction = ParameterDirection.Input;
            //prm9.Value = dateformat;
            //objOraclecommand.Parameters.Add(prm9);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;

            objOraclecommand.Parameters.Add("p_Accounts3", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts3"].Direction = ParameterDirection.Output;

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
}
}