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
namespace NewAdbooking.Report.classesoracle
{

    /// <summary>
    /// Summary description for unregisteredclient
    /// </summary>
    public class unregisteredclient : orclconnection
    {
        public unregisteredclient()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public DataSet clint(string compcode, string branch, string fromdate, string todate, string dateformat, string padtype, string puomcode, string pdate_flag, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("rpt_unregistered_client", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                 prm1.Value = compcode;
                 objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pbranchcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (branch == "0")
                {
                    prm2.Value = "";
                }
                else
                {
                    prm2.Value = branch;
                }

                
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pdatefrom", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pdateto", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = todate;

                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pdateformate", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;

                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (padtype == "0")
                {
                    prm6.Value = "";
                }
                else
                {
                    prm6.Value = padtype;
                }
               
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("puomcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                
                if (puomcode == "0")
                {
                    prm7.Value = "";
                }
                else
                {
                    prm7.Value = puomcode;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pdate_flag", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pdate_flag;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 200000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pextra1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 500);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pextra2;
                objOraclecommand.Parameters.Add(prm10);
                
                OracleParameter prm11 = new OracleParameter("pextra3", OracleType.VarChar, 500);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pextra3;
                objOraclecommand.Parameters.Add(prm11);
                
                OracleParameter prm12 = new OracleParameter("pextra4", OracleType.VarChar, 500);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra4;
                objOraclecommand.Parameters.Add(prm12);
                
                OracleParameter prm13 = new OracleParameter("pextra5", OracleType.VarChar, 500);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra5;
                objOraclecommand.Parameters.Add(prm13);






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
        public DataSet Updatedata(string bkd, string clientname, string compcode)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientupdttrasac2", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pciobookid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bkd;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pclientcod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = clientname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcomp_cod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);




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

        public DataSet Updatenotregisterd(string bkd, string clientname, string compcode)
        {


            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("ad_client_mark_nonregistered", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pciobookid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = bkd;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pclientcod", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = clientname;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pcomp_cod", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);




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
        public DataSet getclint(string compcode, string puserid, string pper_desc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = new OracleCommand();
                objOraclecommand.Connection = objOracleConnection;
                objOraclecommand.CommandType = CommandType.Text;
                string query = " select cir_get_userpermission('" + compcode + "','','','','','" + puserid + "','" + pper_desc + "','','','','','','','','','','') as clientname from dual";
                objOraclecommand.CommandText = query;
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
        public DataSet ad_rep_roapproval_detail(string compcode, string center, string branch, string agencycode, string client, string excutive, string pdate_flag, string fromdate,string todate,string dateformat,string userid,string status,  string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("ad_rep_roapproval_detail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("ppcenter", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (center == "0")
                {
                    prm2.Value = "";
                }
                else
                {
                    prm2.Value = center;
                }


                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (branch == "0")
                {
                    prm3.Value = "";
                }
                else
                {
                    prm3.Value = branch;
                }

                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("pagency", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agencycode;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("pclient", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client;

                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pexecutive", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = excutive;
                 objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pdate_based_on", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (pdate_flag == "0")
                {
                    prm7.Value = "";
                }
                else
                {
                    prm7.Value = pdate_flag;
                }
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fromdate;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm15 = new OracleParameter("ptill_date", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = todate;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = dateformat;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = userid;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("pflag", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                if (status == "0")
                {
                    prm18.Value = "";
                }
                else
                {
                    prm18.Value = status;
                }
                objOraclecommand.Parameters.Add(prm18);



                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = pextra1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 500);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pextra2;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra3", OracleType.VarChar, 500);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pextra3;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra4", OracleType.VarChar, 500);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra4;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra5", OracleType.VarChar, 500);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra5;
                objOraclecommand.Parameters.Add(prm13);






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


        public DataSet adtypbind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("advtypbind.advtypbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                objOracleConnection.Close();
            }
        }

        public DataSet boxno(string compcode, string fromdate, string todate, string dateformate, string center, string ciod, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_boxno_register", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdatefrom", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = fromdate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdateto", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = todate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdateformate", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateformate;
                objOraclecommand.Parameters.Add(prm4);
     

                OracleParameter prm5 = new OracleParameter("pcenter_code", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = center;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pbooking_id", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = ciod;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("puserid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = extra1;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra3", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = extra3;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra4", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = extra4;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = extra5;
                objOraclecommand.Parameters.Add(prm13);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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
                objOracleConnection.Close();
            }
        }
        public DataSet auditor_comment(string compcode, string center, string branchcode, string fromdate, string todate, string adtype, string flag, string userid, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("rpt_auditor_comment", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pcenter_code", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (center == "0")
                {
                    prm2.Value = "";
                }
                else
                {
                    prm2.Value = center;
                }


                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm7 = new OracleParameter("pbranchcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (branchcode == "0")
                {
                    prm7.Value = "";
                }
                else
                {
                    prm7.Value = branchcode;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm3 = new OracleParameter("pfromdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("ptilldate", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = todate;

                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (adtype == "0")
                {
                    prm6.Value = "";
                }
                else
                {
                    prm6.Value = adtype;
                }

                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm8 = new OracleParameter("pdateflag", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = flag;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm14 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = userid;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm9 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra1;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar, 500);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra2;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra3", OracleType.VarChar, 500);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = extra3;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra4", OracleType.VarChar, 500);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = extra4;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra5", OracleType.VarChar, 500);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = extra5;
                objOraclecommand.Parameters.Add(prm13);


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
        public DataSet categorybind(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rptagencytype.rptagencytype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;



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
        public DataSet execute_maingrp_child(string compcode, string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindagencyforxls_child.bindagencyforxls_child_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
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

        public DataSet execute_maingrp(string compcode, string client)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("AD_CUS_FTWO.AD_CUS_FTWO_BIND", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
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

        public DataSet executivexls(string comcode, string usid, string tname, string ext)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("xlsBindexecnew.xlsBindexecnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("name1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = tname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("executive", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ext;
                objOraclecommand.Parameters.Add(prm4);


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
        public DataSet retainerxls(string compcode, string ret)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {



                objOracleConnection.Open();
                objOraclecommand = GetCommand("xlsRetainerbind.xlsRetainerbind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter pr1 = new OracleParameter("retainer", OracleType.VarChar, 50);
                pr1.Direction = ParameterDirection.Input;
                pr1.Value = ret;
                objOraclecommand.Parameters.Add(pr1);


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
        public DataSet monthbill(string pcompcode, string pcentercode, string pbranchcode, string padtype, string puomcode,string pcatcode, string psubcatcode, string pagency_type, string pag_main_code, string pag_sub_code, string pexecode, string pretcode, string pclientcode, string pdatefrom, string pdateto, string puserid, string pdateformat, string prep_type, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pextra6, string pextra7, string pextra8, string pextra9, string pextra10)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_monthwise_billing", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pcompcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcentercode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pcentercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranchcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (pbranchcode == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = pbranchcode;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("padtype", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if(padtype=="")
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                {
                prm4.Value = padtype;
                }
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm29 = new OracleParameter("puomcode", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (puomcode == "" || puomcode == "--Select UOM Name--")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                {
                prm29.Value = puomcode;
                }
                objOraclecommand.Parameters.Add(prm29);


                OracleParameter prm5 = new OracleParameter("pcatcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (pcatcode == "" || pcatcode == "Select AdCat")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = pcatcode;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("psubcatcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = psubcatcode;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pagency_type", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (pagency_type == "0" || pagency_type == "")
                {

                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = pagency_type;
                }
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm14 = new OracleParameter("pag_main_code", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = pag_main_code;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pag_sub_code", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (pag_sub_code==" ")
                {
                prm15.Value = System.DBNull.Value;
                }
                else
                {
                     prm15.Value = pag_sub_code;
                }
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pexecode", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = pexecode;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("pretcode", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = pretcode;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pclientcode", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = pclientcode;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pdatefrom", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = pdatefrom;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pdateto", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = pdateto;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("puserid", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = puserid;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = pdateformat;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("prep_type", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = prep_type;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm8 = new OracleParameter("pextra1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = pextra1;
                objOraclecommand.Parameters.Add(prm8);



                OracleParameter prm10 = new OracleParameter("pextra2", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = pextra2;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra3", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = pextra3;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra4", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = pextra4;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("pextra5", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pextra5;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm24 = new OracleParameter("pextra6", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = pextra6;
                objOraclecommand.Parameters.Add(prm24);



                OracleParameter prm25 = new OracleParameter("pextra7", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = pextra7;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("pextra8", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = pextra8;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("pextra9", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = pextra9;
                objOraclecommand.Parameters.Add(prm27);


                OracleParameter prm28 = new OracleParameter("pextra10", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = pextra10;
                objOraclecommand.Parameters.Add(prm28);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
                objOracleConnection.Close();
            }
        }
        public DataSet clsUsername(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Username.Websp_Username_p", ref objOracleConnection);
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
        public DataSet Admatriallog(string fdate, string center, string user, string filename, string datformate, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOracleCommand;
            objOracleConnection = GetConnection();
            OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objOracleConnection.Open();
                objOracleCommand = GetCommand("websp_rep_material_log", ref objOracleConnection);
                objOracleCommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pinsdate", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if (fdate != "0" && fdate != "")
                {
                    if (datformate == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm1.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOracleCommand.Parameters.Add(prm1);

                OracleParameter prm5 = new OracleParameter("pcenter", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = center;
                objOracleCommand.Parameters.Add(prm5);

                OracleParameter prm2 = new OracleParameter("pusername", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (user == "0" || user == "")
                {
                    prm2.Value = System.DBNull.Value;
                }
                else
                {
                    prm2.Value = user;
                }
                objOracleCommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pfilename", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (filename == "")
                {
                    prm3.Value = "0";
                }
                else
                {
                    prm3.Value = filename;
                }
                objOracleCommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = datformate;
                objOracleCommand.Parameters.Add(prm4);

                OracleParameter prm6 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = extra1;
                objOracleCommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra2;
                objOracleCommand.Parameters.Add(prm7);

                objOracleCommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOracleCommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOracleDataAdapter.SelectCommand = objOracleCommand;
                objOracleDataAdapter.Fill(objDataSet);

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

