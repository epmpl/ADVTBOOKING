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
    public class ad_masterreport : orclconnection
    {
        public ad_masterreport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindunit(string extra1)
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
                objOraclecommand = GetCommand("AD_GET_REPORT_TABLE_BIND", ref objOracleConnection);
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
                objOraclecommand = GetCommand("AD_GET_REPT_TABLE_COL_BINDNEW", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("COMPCODE", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PUNIT", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unit;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("PCHANNEL", OracleType.VarChar, 50);
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
        public DataSet masterreport(string compcode, string unitcode, string channel, string seqno, string tablename, string tablecol, string tablefilter, string order, string ext2, string ext3, string ext4, string ext5, string ext6, string ext7, string ext8, string ext9, string ext10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("cir_get_table_report", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("punit", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = unitcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pchannel", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = channel;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ptseq_no", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = seqno;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("ptable_name", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tablename;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptable_col", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = tablecol;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ptable_filter", OracleType.VarChar);//pdatefrom
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = tablefilter;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("porder", OracleType.VarChar);//pdateto
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = order;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra2", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = ext2;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra3", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = ext3;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra4", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ext4;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra5", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ext5;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra6", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = ext6;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra7", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = ext7;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra8", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = ext8;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra9", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ext9;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pextra10", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = ext10;
                objOraclecommand.Parameters.Add(prm17);


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
        public DataSet getdatatype1(string compcode, string col, string table, string owner)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getdatype", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("columnname", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = col;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm5 = new OracleParameter("tablename", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = table;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("owner", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = owner;
                objOraclecommand.Parameters.Add(prm6);

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