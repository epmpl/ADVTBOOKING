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
    /// Summary description for targetanalisis
    /// </summary>
    public class targetanalisis : orclconnection
    {
        public targetanalisis()
        {
            //
            // TODO: Add constructor logic here
            //
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

        public DataSet edition(string pubcode, string centercode, string compcode)
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
                prm3.Value = pubcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm2 = new OracleParameter("centercode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = centercode;
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

        public DataSet adname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("RA_adbindcategory.RA_adbindcategory_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

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
        public DataSet uombind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("binduomfortarget", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                
                objOraclecommand.Parameters.Add("P_ACCOUNTS", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNTS"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return (objDataSet);

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


        public DataSet paymode(string compcode ,string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("payfill.payfill_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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


        public DataSet getbussinessreport(string compcode, string pub_center, string branch, string publication, string edition, string agencycode, string client_code, string exec_code, string adtype, string uom, string agency_pay, string datefrom, string todate, string dateformat, string userid, string chkaccess, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_rep_bussiness.ad_rep_bussiness_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppub_center", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (pub_center == "" || pub_center == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = pub_center;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branch;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("ppublication", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (publication == "" || publication == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (edition == "" || edition == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pagency_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agencycode == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = agencycode;
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pclient_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (client_code == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = client_code;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pexecutive_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (exec_code == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {

                    prm8.Value = exec_code;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pad_typecode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pumo_code", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (uom == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = uom;
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pagency_pay", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (agency_pay == "")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = agency_pay;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = datefrom;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = todate;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = userid;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pchk_access", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = chkaccess;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = extra1;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = extra2;
                objOraclecommand.Parameters.Add(prm18);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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



        public DataSet getbussinessamtreport(string compcode, string pub_center, string branch, string publication, string edition, string agencycode, string client_code, string exec_code, string adtype, string uom, string agency_pay, string datefrom, string todate, string dateformat, string userid, string chkaccess, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {


                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_rep_bussiness.ad_rep_bussiness_amt_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppub_center", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (pub_center == "" || pub_center == "0")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = pub_center;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branch;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("ppublication", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (publication == "" || publication == "0")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                    prm4.Value = publication;
                }
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pedition", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (edition == "" || edition == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = edition;
                }
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("pagency_code", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (agencycode == "")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = agencycode;
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("pclient_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (client_code == "")
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = client_code;
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pexecutive_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (exec_code == "")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {

                    prm8.Value = exec_code;
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pad_typecode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (adtype == "")
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                {
                    prm9.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("pumo_code", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (uom == "")
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                {
                    prm10.Value = uom;
                }
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pagency_pay", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                if (agency_pay == "")
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                {
                    prm11.Value = agency_pay;
                }
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = datefrom;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = todate;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm14 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = dateformat;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = userid;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("pchk_access", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = chkaccess;
                objOraclecommand.Parameters.Add(prm16);


                OracleParameter prm17 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = extra1;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = extra2;
                objOraclecommand.Parameters.Add(prm18);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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

        public DataSet getlastday(string frmdate, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getlastday", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pfrmdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = frmdate;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = dateformat;
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