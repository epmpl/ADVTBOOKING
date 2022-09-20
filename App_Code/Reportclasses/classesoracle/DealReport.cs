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
namespace NewAdbooking.Report.classesoracle
{

/// <summary>
/// Summary description for DealReport
/// </summary>
    public class DealReport : orclconnection
{
	public DealReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet getdealdata(string pcompcode,string padtype,string padcat,string pdeal_type,string pag_maincode,string pag_subcode,string pclient,string papproved,string ppackage,string pratecode,string pfromdt,string ptilldt,string pdate_flag,string puserid,string pdateformat)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {


            objOracleConnection.Open();
            objOraclecommand = GetCommand("rpt_deal_detail", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter top1 = new OracleParameter("pcompcode", OracleType.VarChar);
            top1.Direction = ParameterDirection.Input;
            top1.Value = pcompcode;
            objOraclecommand.Parameters.Add(top1);

            OracleParameter top2 = new OracleParameter("padtype", OracleType.VarChar);
            top2.Direction = ParameterDirection.Input;
            if (padtype == "0" || padtype == "")
                top2.Value = System.DBNull.Value;
            else
                top2.Value = padtype;
            objOraclecommand.Parameters.Add(top2);

            OracleParameter prm1 = new OracleParameter("padcat", OracleType.VarChar, 50);
            prm1.Direction = ParameterDirection.Input;
            if (padcat == "0" || padcat == "")
                prm1.Value = System.DBNull.Value;
            else
                prm1.Value = padcat;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pdeal_type", OracleType.VarChar, 50);
            prm2.Direction = ParameterDirection.Input;
            if (pdeal_type == "0" || pdeal_type == "")
                prm2.Value = System.DBNull.Value;
            else
                prm2.Value = pdeal_type;
            objOraclecommand.Parameters.Add(prm2);


            OracleParameter prm3 = new OracleParameter("pag_maincode", OracleType.VarChar, 50);
            prm3.Direction = ParameterDirection.Input;
            if (pag_maincode != "0" && pag_maincode != "")
            {
                prm3.Value = pag_maincode;
            }
            else
            {
                prm3.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(prm3);

            OracleParameter e4 = new OracleParameter("pag_subcode", OracleType.VarChar, 50);
            e4.Direction = ParameterDirection.Input;
            if (pag_subcode != "0" && pag_subcode != "")
            {
                e4.Value = pag_subcode;
            }
            else
            {
                e4.Value = System.DBNull.Value;
            }
            objOraclecommand.Parameters.Add(e4);



            OracleParameter prm4 = new OracleParameter("pclient", OracleType.VarChar, 50);
            prm4.Direction = ParameterDirection.Input;
            if (pclient == "")
                prm4.Value = System.DBNull.Value;
            else
                prm4.Value = pclient;
            objOraclecommand.Parameters.Add(prm4);

            OracleParameter prm5 = new OracleParameter("papproved", OracleType.VarChar, 50);
            prm5.Direction = ParameterDirection.Input;
            if (papproved != "0" && papproved != "")
                prm5.Value = papproved;
            else
                prm5.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm5);

            OracleParameter prm6 = new OracleParameter("pfromdt", OracleType.VarChar, 50);
            prm6.Direction = ParameterDirection.Input;
            if (pfromdt != "0" && pfromdt != "")
            {
                if (pdateformat == "dd/mm/yyyy")
                {
                    string[] arr = pfromdt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    pfromdt = mm + "/" + dd + "/" + yy;
                }
                prm6.Value = Convert.ToDateTime(pfromdt).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm6.Value = System.DBNull.Value;
            }

            objOraclecommand.Parameters.Add(prm6);

            OracleParameter prm7 = new OracleParameter("ptilldt", OracleType.VarChar, 50);
            prm7.Direction = ParameterDirection.Input;
            if (ptilldt != "0" && ptilldt != "")
            {
                if (pdateformat == "dd/mm/yyyy")
                {
                    string[] arr = ptilldt.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    ptilldt = mm + "/" + dd + "/" + yy;
                }
                prm7.Value = Convert.ToDateTime(ptilldt).ToString("dd-MMMM-yyyy");
            }
            else
            {
                prm7.Value = System.DBNull.Value;
            }

            objOraclecommand.Parameters.Add(prm7);

            OracleParameter prm8 = new OracleParameter("ppackage", OracleType.VarChar, 50);
            prm8.Direction = ParameterDirection.Input;
            if (ppackage == "0" || ppackage == "")
            {
                prm8.Value = System.DBNull.Value;
            }
            else
            {
                prm8.Value = ppackage;
            }

            objOraclecommand.Parameters.Add(prm8);

            OracleParameter prm9 = new OracleParameter("pratecode", OracleType.VarChar, 50);
            prm9.Direction = ParameterDirection.Input;
            if (pratecode == "0" || pratecode == "")
            {
                prm9.Value = System.DBNull.Value;
            }
            else
            {
                prm9.Value = pratecode;
            }

            objOraclecommand.Parameters.Add(prm9);

            OracleParameter prm10 = new OracleParameter("pdate_flag", OracleType.VarChar, 50);
            prm10.Direction = ParameterDirection.Input;
            if (pdate_flag == "")
            {
                prm10.Value = System.DBNull.Value;
            }
            else
            {
                prm10.Value = pdate_flag;
            }
            objOraclecommand.Parameters.Add(prm10);

            OracleParameter prm11 = new OracleParameter("puserid", OracleType.VarChar, 50);
            prm11.Direction = ParameterDirection.Input;
            prm11.Value = puserid;
            objOraclecommand.Parameters.Add(prm11);

            OracleParameter prm12 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
            prm12.Direction = ParameterDirection.Input;
            prm12.Value = pdateformat;
            objOraclecommand.Parameters.Add(prm12);



            OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
            prm13.Direction = ParameterDirection.Input;
            prm13.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm13);

            OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
            prm14.Direction = ParameterDirection.Input;
            prm14.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm14);

            OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar, 50);
            prm15.Direction = ParameterDirection.Input;
            prm15.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm15);

            OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar, 50);
            prm16.Direction = ParameterDirection.Input;
            prm16.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm16);

            OracleParameter prm17 = new OracleParameter("pextra5", OracleType.VarChar, 50);
            prm17.Direction = ParameterDirection.Input;
            prm17.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm17);

            OracleParameter prm18 = new OracleParameter("pextra6", OracleType.VarChar, 50);
            prm18.Direction = ParameterDirection.Input;
            prm18.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm18);

            OracleParameter prm19 = new OracleParameter("pextra7", OracleType.VarChar, 50);
            prm19.Direction = ParameterDirection.Input;
            prm19.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm19);

            OracleParameter prm20 = new OracleParameter("pextra8", OracleType.VarChar, 50);
            prm20.Direction = ParameterDirection.Input;
            prm20.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm20);

            OracleParameter prm21 = new OracleParameter("pextra9", OracleType.VarChar, 50);
            prm21.Direction = ParameterDirection.Input;
            prm21.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm21);

            OracleParameter prm22 = new OracleParameter("pextra10", OracleType.VarChar, 50);
            prm22.Direction = ParameterDirection.Input;
            prm22.Value = System.DBNull.Value;
            objOraclecommand.Parameters.Add(prm22);

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
    public DataSet bindratecode(string compcode)
    {
        OracleConnection objOracleConnection;
        OracleCommand objOraclecommand;
        DataSet objDataSet = new DataSet();
        objOracleConnection = GetConnection();
        OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
        try
        {
            objOracleConnection.Open();
            objOraclecommand = GetCommand("adb_bindratecode", ref objOracleConnection);
            objOraclecommand.CommandType = CommandType.StoredProcedure;

            OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
            prm1.Direction = ParameterDirection.Input;
            prm1.Value = compcode;
            objOraclecommand.Parameters.Add(prm1);

            OracleParameter prm2 = new OracleParameter("pextra1", OracleType.VarChar);
            prm2.Direction = ParameterDirection.Input;
            prm2.Value = compcode;
            objOraclecommand.Parameters.Add(prm2);

            OracleParameter prm3 = new OracleParameter("pextra2", OracleType.VarChar);
            prm3.Direction = ParameterDirection.Input;
            prm3.Value = compcode;
            objOraclecommand.Parameters.Add(prm3);

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
}
}
