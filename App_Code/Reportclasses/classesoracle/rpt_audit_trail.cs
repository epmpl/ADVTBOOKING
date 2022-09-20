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

/// <summary>
/// Summary description for Roll_mast
/// </summary>
namespace NewAdbooking.Report.classesoracle
{
    public class rpt_audit_trail:orclconnection
    {
        public rpt_audit_trail()
        {

		//
		// TODO: Add constructor logic here
		//
        }

        public DataSet masrep(string compcode, string unit, string cha, string extra1, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_get_report_table_bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("pchannel", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cha;
                objOraclecommand.Parameters.Add(prm5);

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

                OracleParameter prm10 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra4;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = extra5;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra6", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = extra6;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra7", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = extra7;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra8", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = extra8;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra9", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = extra9;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra10", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = extra10;
                objOraclecommand.Parameters.Add(prm16);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

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

        public DataSet bindr(string compcode, string unit, string cha, string repo, string extra2, string extra3, string extra4, string extra5, string extra6, string extra7, string extra8, string extra9, string extra10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_GET_REPORT_TABLE_COL_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("pchannel", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cha;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PTSEQ_NO", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = repo;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra2;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = extra3;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm10 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra4;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra5", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = extra5;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra6", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = extra6;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra7", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = extra7;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra8", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = extra8;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra9", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = extra9;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra10", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = extra10;
                objOraclecommand.Parameters.Add(prm16);

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts4", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts4"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts5", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts5"].Direction = ParameterDirection.Output;

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

        public DataSet bindgrid(string compcode, string pcioid, string pfromdate, string ptodate, string pval)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_data_from_tbl", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcioid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcioid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("pfromdate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = pfromdate;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptodate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ptodate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pval", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pval;
                objOraclecommand.Parameters.Add(prm7);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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
        public DataSet bindlogndetail(string compcode, string pid, string ptcioid, string ptodate, string pfromdate, string pextra3, string pextra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_get_report_login_detail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("ptcioid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = ptcioid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptodate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ptodate;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pfromdate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pfromdate;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pextra2;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm10 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pextra3;
                objOraclecommand.Parameters.Add(prm10);

                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

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
