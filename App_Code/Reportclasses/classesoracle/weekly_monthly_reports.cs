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
    /// Summary description for weekly_monthly_reports
    /// </summary>
    public class weekly_monthly_reports : orclconnection
    {
        public weekly_monthly_reports()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet branchbindWithPrintCenter(string compcode, string printbindbranch)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("BRANCHWITHPRINTCEN.BRANCHWITHPRINTCEN_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("printcen", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = printbindbranch;
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

        public DataSet weekwise_billing(string compcode, string printcenter, string branchcode, string publication, string fromdate, string dateto, string useid, string dateformat,string basedon, string ext1, string ext2, string ext3, string ext4, string ext5, string ext6, string ext7, string ext8, string ext9, string ext10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_weekwise_billing_summ", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    prm2.Value = printcenter;
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranchcode", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    prm3.Value = branchcode;
                }
                else
                {
                    prm3.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ppublcode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    prm4.Value = publication;

                }
                else
                {
                    prm4.Value = System.DBNull.Value;

                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pdatefrom", OracleType.VarChar, 50);//pdatefrom
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = fromdate;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateto", OracleType.VarChar, 50);//pdateto
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateto;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("puserid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = useid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pdate_basedon", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = basedon;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = ext1;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra2", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ext2;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ext3;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra4", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = ext4;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra5", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = ext5;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra6", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = ext6;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra7", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = ext7;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pextra8", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = ext8;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pextra9", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = ext9;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pextra10", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = ext10;
                objOraclecommand.Parameters.Add(prm19);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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