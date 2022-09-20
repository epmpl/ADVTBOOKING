using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for cat_seq_no
/// </summary>
public class cat_seq_no: orclconnection
{
	public cat_seq_no()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet addcategoryname(string compcode)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("adcat.adcat_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("company_code", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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
    public DataSet cat_seq(string compcode, string pcenter, string pdays, string padtype, string puserid,string dateformate, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("fetch_ad_cat_flow_sequence", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (pcenter == "0")
            {
                prm2.Value = "";
         
            }
            else
            {
                prm2.Value = pcenter;
            }
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pday", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if (pdays=="0")
            {
                prm3.Value = "";
          
            }
            else
            {
            prm3.Value = pdays;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("padtype", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            if (padtype == "0")
            {
                prm4.Value = "";
       
            }
            else
            {
                prm4.Value = padtype;
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = puserid;          
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm11 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = dateformate;
            objOraclecommand.Parameters.Add(prm11);


            OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = pextra1;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = pextra2;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("pextra3", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = pextra3;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("pextra4", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = pextra4;
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pextra5", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value = pextra5;
            objOraclecommand.Parameters.Add(prm10);




            objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
    public DataSet save(string compcode, string center, string days, string adtype, string catcode,int cat_seqno,string userid, string flag, string ins_upd, string datformate, string extra1, string extra2, string extra3, string extra4, string extra5)
    {

        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("ad_cat_flow_sequence_dml", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = center;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pday", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = days;
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter prm4 = new OracleParameter("padtype", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            if (adtype == "0")
            {
                prm4.Value = "";

            }
            else
            {
                prm4.Value = adtype;
            }
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm13 = new OracleParameter("pcatcode", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = catcode;
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm12 = new OracleParameter("pcat_seqno", OracleType.Int32, 50);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value =cat_seqno;
            objOraclecommand.Parameters.Add(prm12);

            OracleParameter prm14 = new OracleParameter("pflag", OracleType.VarChar, 50);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = flag;
            objOraclecommand.Parameters.Add(prm14);

           



            OracleParameter prm5 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            prm5.Value = userid;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm15 = new OracleParameter("pins_upd", OracleType.VarChar, 50);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = ins_upd;
            objOraclecommand.Parameters.Add(prm15);


            OracleParameter prm11 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = datformate;
            objOraclecommand.Parameters.Add(prm11);


            OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            prm6.Value = extra1;
            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            prm7.Value = extra2;
            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("pextra3", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            prm8.Value = extra3;
            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("pextra4", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            prm9.Value = extra4;
            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pextra5", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            prm10.Value =extra5;
            objOraclecommand.Parameters.Add(prm10);




           // objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
            //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
    public DataSet adtypbind(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
    public DataSet getPubCenter_company(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("Bind_PubCentName.Bind_PubCentName_p", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
            objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


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
