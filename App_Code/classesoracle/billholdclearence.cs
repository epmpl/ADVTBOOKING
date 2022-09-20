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

/// <summary>
/// Summary description for billholdclearence
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class billholdclearence : orclconnection
    {
        public billholdclearence()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet Fetchdata(string fdate, string todate, string bookingcenter, string holdtype, string bookini, string compcode, string dateformat, string logincenter, string userid, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("WEBSP_BIND_BILLHOLD", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm5 = new OracleParameter("FROMDATE", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                if (fdate == "")
                    prm5.Value = fdate;
                else
                    prm5.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("TODATE", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;
                if (todate == "")
                    prm6.Value = todate;
                else
                    prm6.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("BOOKINGCENTER", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (bookingcenter == "0" || bookingcenter == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = bookingcenter;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("BILLSTATUS", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = holdtype;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("BOOKINGID", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookini;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm7 = new OracleParameter("P_CENTERLOGIN", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = logincenter;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm11 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = dateformat;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm8 = new OracleParameter("puserid", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = userid;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                objOraclecommand.Parameters.Add(prm10);




                objOraclecommand.Parameters.Add("P_RECORDSET", OracleType.Cursor);
                objOraclecommand.Parameters["P_RECORDSET"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("P_RECORDSET1", OracleType.Cursor);
                objOraclecommand.Parameters["P_RECORDSET1"].Direction = ParameterDirection.Output;

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

        public DataSet savedata(string compcode, string bookingcenter, string bookingid, string billcycle, string usid, string billdate, string billno, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bill_update_data", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;




                OracleParameter prm5 = new OracleParameter("pbill_date", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                if (billdate == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = Convert.ToDateTime(billdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pbill_no", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;

                prm6.Value = billno;
               
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pcenter", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (bookingcenter == "0" || bookingcenter == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = bookingcenter;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("porderno", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = bookingid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pbill_cycle", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = billcycle;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm7 = new OracleParameter("puserid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = usid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm12 = new OracleParameter("pextra3", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = extra3;
                objOraclecommand.Parameters.Add(prm12);



                OracleParameter prm13 = new OracleParameter("pextra4", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = extra4;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pextra5", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = extra5;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm11 = new OracleParameter("pprefix", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);






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