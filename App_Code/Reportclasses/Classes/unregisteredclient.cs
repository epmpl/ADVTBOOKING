using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
namespace NewAdbooking.Report.Classes
{

    /// <summary>
    /// Summary description for unregisteredclient
    /// </summary>
    public class unregisteredclient : connection
    {
        public unregisteredclient()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet adbranch(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("branchbind_adv", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet clsUsername(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Username", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet Updatedata(string bkd, string clientname, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("clientupdttrasac2", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_cod"].Value = compcode;

                objSqlCommand.Parameters.Add("@pciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pciobookid"].Value = bkd;


                objSqlCommand.Parameters.Add("@pclientcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclientcod"].Value = clientname;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet Updatenotregisterd(string bkd, string clientname, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_client_mark_nonregistered", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_cod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_cod"].Value = compcode;

                objSqlCommand.Parameters.Add("@pciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pciobookid"].Value = bkd;


                objSqlCommand.Parameters.Add("@pclientcod", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclientcod"].Value = clientname;


                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }


        public DataSet clint(string compcode, string branch, string fromdate, string todate, string dateformat, string padtype, string puomcode, string pdate_flag, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_unregistered_client", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                if (branch == "0")
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = branch;
                }

                objSqlCommand.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdatefrom"].Value = changeformate(fromdate);

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateto"].Value = changeformate(todate);


                objSqlCommand.Parameters.Add("@pdateformate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformate"].Value = dateformat;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = padtype;


                objSqlCommand.Parameters.Add("@puomcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puomcode"].Value = puomcode;


                objSqlCommand.Parameters.Add("@pdate_flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_flag"].Value = pdate_flag;


                objSqlCommand.Parameters.Add("pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["pextra1"].Value = pextra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = pextra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = pextra3;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = pextra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = pextra5;

               




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
          
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public string changeformate(string userdate)
        {
            string[] arr = userdate.Split('/');
            string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
            if (arr[1].Length < 2)
            {
                arr[1] = "0" + arr[1];
            }
            if (arr[0].Length < 2)
            {
                arr[0] = "0" + arr[0];
            }
            change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
            return change;
        }
        public DataSet ad_rep_roapproval_detail(string compcode, string center, string branch, string agencycode, string client, string excutive, string pdate_flag, string fromdate, string todate, string dateformat, string userid, string status, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_rep_roapproval_detail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ppcenter", SqlDbType.VarChar);
                if (center == "0")
                {
                    objSqlCommand.Parameters["@ppcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppcenter"].Value = center;
                }

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch == "0")
                {
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranch"].Value = branch;
                }
                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agencycode;


                objSqlCommand.Parameters.Add("@pclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclient"].Value = client;

                objSqlCommand.Parameters.Add("@pexecutive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecutive"].Value = excutive;


                objSqlCommand.Parameters.Add("@pdate_based_on", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_based_on"].Value = pdate_flag;


                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfrom_date"].Value = changeformate(fromdate);

                objSqlCommand.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptill_date"].Value = changeformate(todate);

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = changeformate(dateformat);

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pflag"].Value = status;

                objSqlCommand.Parameters.Add("pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["pextra1"].Value = pextra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = pextra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = pextra3;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = pextra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = pextra5;






                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
       
        public DataSet boxno(string compcode, string fromdate, string todate, string dateformate, string center, string ciod, string userid, string extra1, string extra2, string extra3, string extra4, string extra5)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_boxno_register", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;



                objSqlCommand.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdatefrom"].Value = changeformate(fromdate);

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateto"].Value = changeformate(todate);


                objSqlCommand.Parameters.Add("@pdateformate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformate"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pcenter_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcenter_code"].Value = center;


                objSqlCommand.Parameters.Add("@pbooking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbooking_id"].Value = ciod;


                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;


                objSqlCommand.Parameters.Add("pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;






                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet auditor_comment(string compcode, string center, string branchcode, string fromdate, string todate, string adtype, string flag, string userid, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_auditor_comment", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcenter_code", SqlDbType.VarChar);
                if (center == "0")
                {
                    objSqlCommand.Parameters["@pcenter_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter_code"].Value = center;
                }

                objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                if (branchcode == "0")
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = branchcode;
                }

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfromdate"].Value = changeformate(fromdate);

                objSqlCommand.Parameters.Add("@ptilldate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptilldate"].Value = changeformate(todate);


               
                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                if (adtype == "0")
                {
                    objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@padtype"].Value = adtype;
                }

                objSqlCommand.Parameters.Add("@pdateflag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateflag"].Value = flag;


                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

              
               
                objSqlCommand.Parameters.Add("pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;






                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet categorybind(string compcode)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("rptagencytype", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }

        }
        public DataSet execute_maingrp_child(string compcode, string agency)
        {
            SqlConnection sqlcon;
            SqlCommand sqlcom;
            sqlcon = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                sqlcon.Open();
                sqlcom = GetCommand("bindagencyforxls_child", ref sqlcon);
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add("@compcode", SqlDbType.VarChar);
                sqlcom.Parameters["@compcode"].Value = compcode;

                sqlcom.Parameters.Add("@agency", SqlDbType.VarChar);
                sqlcom.Parameters["@agency"].Value = agency;


                da.SelectCommand = sqlcom;
                da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                CloseConnection(ref sqlcon);
            }
        }

        public DataSet execute_maingrp(string compcode, string client)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_CUS_FTWO", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;



                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = client;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet executivexls(string comcode, string usid, string tname, string ext)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("xlsBindexecnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = usid;
                objSqlCommand.Parameters.Add("@name1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@name1"].Value = tname;
                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = ext;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet retainerxls(string compcode, string ret)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("xlsRetainerbind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@retainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer"].Value = ret;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }
        public DataSet monthbill(string pcompcode, string pcentercode, string pbranchcode, string padtype, string puomcode, string pcatcode, string psubcatcode, string pagency_type, string pag_main_code, string pag_sub_code, string pexecode, string pretcode, string pclientcode, string pdatefrom, string pdateto, string puserid, string pdateformat, string prep_type, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string pextra6, string pextra7, string pextra8, string pextra9, string pextra10)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_monthwise_billing", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = pcompcode;

                objSqlCommand.Parameters.Add("@pcentercode", SqlDbType.VarChar);
                if (pcentercode == "0")
                {
                    objSqlCommand.Parameters["@pcenter_code"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pcenter_code"].Value = pcentercode;
                }

                objSqlCommand.Parameters.Add("@pbranchcode", SqlDbType.VarChar);
                if (pbranchcode == "")
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranchcode"].Value = pbranchcode;
                }

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@padtype"].Value = padtype;


                objSqlCommand.Parameters.Add("@puomcode", SqlDbType.VarChar);
                if (puomcode == "" || puomcode == "--Select UOM Name--")
                {

                    objSqlCommand.Parameters["@puomcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@puomcode"].Value = puomcode;
                }

              

                objSqlCommand.Parameters.Add("@pcatcode", SqlDbType.VarChar);
                if (pcatcode == "" || pcatcode == "Select AdCat")
                {
                    objSqlCommand.Parameters["@pcatcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pcatcode"].Value = pcatcode;
                }

                objSqlCommand.Parameters.Add("@psubcatcode", SqlDbType.VarChar);
                if (psubcatcode == "" || psubcatcode == "Select AdCat")
                {
                    objSqlCommand.Parameters["@psubcatcode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@psubcatcode"].Value = psubcatcode;
                }

                objSqlCommand.Parameters.Add("@pagency_type", SqlDbType.VarChar);
                if (pagency_type == "0" || pagency_type == "")
                {

                    objSqlCommand.Parameters["@pagency_type"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pagency_type"].Value = pagency_type;
                }
                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code "].Value = pag_main_code;


                objSqlCommand.Parameters.Add("@pag_main_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pag_main_code "].Value = pag_main_code;

                objSqlCommand.Parameters.Add("@pag_sub_code", SqlDbType.VarChar);
                if (pag_sub_code == " ")
                {
                    objSqlCommand.Parameters["@pag_sub_code "].Value ="";
                }
                else
                {
                    objSqlCommand.Parameters["@pag_sub_code "].Value = pag_sub_code;
                }

                objSqlCommand.Parameters.Add("@pexecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexecode"].Value = pexecode;

                objSqlCommand.Parameters.Add("@pretcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pretcode"].Value = pretcode;

                objSqlCommand.Parameters.Add("@pclientcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclientcode"].Value = pclientcode;



                objSqlCommand.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdatefrom"].Value = changeformate(pdatefrom);

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateto"].Value = changeformate(pdateto);




                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = puserid;


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = pdateformat;

                objSqlCommand.Parameters.Add("@prep_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prep_type"].Value = prep_type;



                objSqlCommand.Parameters.Add("pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["pextra1"].Value = pextra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = pextra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = pextra3;


                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = pextra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = pextra5;

                objSqlCommand.Parameters.Add("pextra6", SqlDbType.VarChar);
                objSqlCommand.Parameters["pextra6"].Value = pextra6;

                objSqlCommand.Parameters.Add("@pextra7", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra7"].Value = pextra7;

                objSqlCommand.Parameters.Add("@pextra8", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra8"].Value = pextra8;


                objSqlCommand.Parameters.Add("@pextra9", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra9"].Value = pextra9;

                objSqlCommand.Parameters.Add("@pextra10", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra10"].Value = pextra10;




                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
            }

            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

    }
}
