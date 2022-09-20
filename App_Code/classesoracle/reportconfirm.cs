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
    /// Summary description for reportconfirm
    /// </summary>
    public class reportconfirm : orclconnection
    {
        public reportconfirm()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindGrid(string fromDate, string toDate, string status, string cid, string ascdesc, string dateformat, string filter, string agencyname)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();

            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("report_booking_confirm", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromDate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromDate = mm + "/" + dd + "/" + yy;


                }
                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.DateTime);
                prm1.Direction = ParameterDirection.Input;
                fromDate = Convert.ToDateTime(fromDate).ToString("dd-MMMM-yyyy");
                prm1.Value = fromDate;
                
                objoraclecommand.Parameters.Add(prm1);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = toDate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    toDate = mm + "/" + dd + "/" + yy;


                }
                OracleParameter prm2 = new OracleParameter("todate", OracleType.DateTime);
                prm2.Direction = ParameterDirection.Input;
                //toDate = Convert.ToDateTime(toDate).AddDays(1).ToString("dd-MMMM-yyyy");
                prm2.Value = toDate;
                objoraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("status1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = status;
                objoraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "0";
                objoraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = "0";
                objoraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = cid;
                objoraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ascdesc;
                objoraclecommand.Parameters.Add(prm7);

                OracleParameter prm71 = new OracleParameter("filter", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = filter;
                objoraclecommand.Parameters.Add(prm71);

                OracleParameter prm72 = new OracleParameter("agency", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                if (agencyname != "0" && agencyname != "")
                {
                    prm72.Value = agencyname;
                }
                else
                {
                    prm72.Value = System.DBNull.Value;
                }
                objoraclecommand.Parameters.Add(prm72);

                objoraclecommand.Parameters.Add("p_recordset", OracleType.Cursor);
                objoraclecommand.Parameters["p_recordset"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
        }
        public DataSet bindGridUser(string fromDate, string toDate, string userid, string cid, string ascdesc,string dateformat,string agencyname)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();

            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("report_booking_confirm", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromDate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromDate = mm + "/" + dd + "/" + yy;


                }
                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.DateTime);
                prm1.Direction = ParameterDirection.Input;
                fromDate = Convert.ToDateTime(fromDate).ToString("dd-MMMM-yyyy");
                prm1.Value = fromDate;

                objoraclecommand.Parameters.Add(prm1);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = toDate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    toDate = mm + "/" + dd + "/" + yy;


                }
                OracleParameter prm2 = new OracleParameter("todate", OracleType.DateTime);
                prm2.Direction = ParameterDirection.Input;
                //toDate = Convert.ToDateTime(toDate).AddDays(1).ToString("dd-MMMM-yyyy");
                prm2.Value = toDate;
                objoraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("status1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "0";
                objoraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "2";
                objoraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objoraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = cid;
                objoraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ascdesc;
                objoraclecommand.Parameters.Add(prm7);

                OracleParameter prm71 = new OracleParameter("filter", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = "0";
                objoraclecommand.Parameters.Add(prm71);


                OracleParameter prm72 = new OracleParameter("agency", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                if (agencyname != "0" && agencyname != "")
                {
                    prm72.Value = agencyname;
                }
                else
                {
                    prm72.Value = System.DBNull.Value;
                }
                objoraclecommand.Parameters.Add(prm72);

                objoraclecommand.Parameters.Add("p_recordset", OracleType.Cursor);
                objoraclecommand.Parameters["p_recordset"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
        }

        public DataSet Getusername()
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
           
                objoracleconnection.Open();
                objoraclecommand = GetCommand("getUserName.getUserName_P", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;


                objoraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objoraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }


        }
        public DataSet griddisplay(string fromdate, string todate, string cid, string ascdesc,string dateformat,string agencyname)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();

            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("report_booking_confirm", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;


                }
                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.DateTime);
                prm1.Direction = ParameterDirection.Input;
                fromdate = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                prm1.Value = fromdate;
                objoraclecommand.Parameters.Add(prm1);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;


                }

                OracleParameter prm2 = new OracleParameter("todate", OracleType.DateTime);
                prm2.Direction = ParameterDirection.Input;
                todate = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                prm2.Value = todate;
                objoraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("status1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "0";
                objoraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("flag", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "1";
                objoraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("userid", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = "0";
                objoraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("descid", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = cid;
                objoraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("ascdesc", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = ascdesc;
                objoraclecommand.Parameters.Add(prm7);

                OracleParameter prm71 = new OracleParameter("filter", OracleType.VarChar);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = "0";
                objoraclecommand.Parameters.Add(prm71);


                OracleParameter prm72 = new OracleParameter("agency", OracleType.VarChar);
                prm72.Direction = ParameterDirection.Input;
                if (agencyname != "0" && agencyname != "")
                {
                    prm72.Value = agencyname;
                }
                else
                {
                    prm72.Value = System.DBNull.Value;
                }
                objoraclecommand.Parameters.Add(prm72);

                objoraclecommand.Parameters.Add("p_recordset", OracleType.Cursor);
                objoraclecommand.Parameters["p_recordset"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
        }
        public DataSet advance_search(string compcode, string agname, string clientname, string username, string fromdate, string dateto, string sheldate, string insertntodate1, string text, string clientcode, string rostatus, string dateformat)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("ctr_advance_search", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("agname", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (agname == "")
                {
                    agname = "0";
                    prm1.Value = agname;
                }
                else
                {
                    prm1.Value = agname;//.Substring(0, 2);
                }
                objoraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objoraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("clientname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (clientname == "")
                {
                    clientname = "0";
                    prm3.Value = clientname;
                }
                else
                {
                    prm3.Value = clientname;
                }
                objoraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("username", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (username == "")
                {
                    username = "0";
                    prm4.Value = username;
                }
                else
                {
                    prm4.Value = username;
                }
                objoraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("fromdate", OracleType.VarChar);
                if (fromdate == null || fromdate == "" || fromdate == "undefined/undefined/")
                {

                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;

                    }
                    prm5.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy"); ; ;
                }
                objoraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("dateto", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (dateto == null || dateto == "" || dateto == "undefined/undefined/")
                {

                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;

                    }
                    prm6.Value = Convert.ToDateTime(dateto).AddDays(1).ToString("dd-MMMM-yyyy");
                }
                objoraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("sheldate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (sheldate == null || sheldate == "" || sheldate == "undefined/undefined/")
                {

                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = sheldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        sheldate = mm + "/" + dd + "/" + yy;

                    }
                    prm7.Value = Convert.ToDateTime(sheldate).ToString("dd-MMMM-yyyy"); ; ;
                }
                objoraclecommand.Parameters.Add(prm7);


                 OracleParameter prm8 = new OracleParameter("insertntodate1", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                if (insertntodate1 == null || insertntodate1 == "" || insertntodate1 == "undefined/undefined/")
                {

                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertntodate1.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertntodate1 = mm + "/" + dd + "/" + yy;

                    }
                    prm8.Value = Convert.ToDateTime(insertntodate1).ToString("dd-MMMM-yyyy"); ; ;
                }
                objoraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("adtext", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (text == "")
                {
                    text = "0";
                    prm9.Value = text;
                }
                else
                {
                    prm9.Value = text;
                }
                objoraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("rostatus", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = rostatus;
                objoraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("clientcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = clientcode;
                objoraclecommand.Parameters.Add(prm11);

               

                objoraclecommand.Parameters.Add("p_recordset", OracleType.Cursor);
                objoraclecommand.Parameters["p_recordset"].Direction = ParameterDirection.Output;





                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;

                //return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }

        }

        public DataSet givepermission(string usercode, string userid, string formname)
        { 
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("deletepermition_new.deletepermition_new_p", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
               objoraclecommand.Parameters.Add(prm1);


               OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usercode;
                objoraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("formname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = formname;
                objoraclecommand.Parameters.Add(prm3);

                objoraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objoraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                
                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
  
            //compcode
        }
        public DataSet chkdate(string fdate, string tdate)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("websp_chkdate.websp_chkdate_P", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fdate1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fdate;
                objoraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("tdate1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = tdate;
                objoraclecommand.Parameters.Add(prm2);


                objoraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objoraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }

            //compcode
        }
        public DataSet bindagency(string compcode, string agency)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("websp_getagName.websp_getagName_p", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objoraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objoraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objoraclecommand.Parameters.Add(prm3);

                objoraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objoraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
        }


        public DataSet getClientName(string compcode, string client)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("websp_getclientname.websp_getclientname_p", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objoraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objoraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "0";
                objoraclecommand.Parameters.Add(prm3);

                objoraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objoraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
        }
        public DataSet deletestatus(string fdate, string tdate,string status)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("statusdelete_TEST", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = fdate;
                objoraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("tdate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = tdate;
                objoraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("status1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = status;
                objoraclecommand.Parameters.Add(prm3);

                //objoraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
               // objoraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;
                
                
                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }

            //compcode
        }
        public DataSet Getusername(string username)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {
                objoracleconnection.Open();
                objoraclecommand = GetCommand("websp_getsperson.websp_getsperson_p", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objoraclecommand.Parameters.Add(prm1);

                objoraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objoraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }
        }
        public DataSet bindSapEdition(string agencycode)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {

                objoracleconnection.Open();
                objoraclecommand = GetCommand("bindSapReportEdition", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

               /* OracleParameter prm4 = new OracleParameter("agencycode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (agencycode == "" || agencycode == "0")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = agencycode;
                objoraclecommand.Parameters.Add(prm4);*/

                objoraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objoraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }


        }
        public DataSet bindSapAdReport(string fromdate, string todate, string edition, string agencycode,string dateformat)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {

                objoracleconnection.Open();
                objoraclecommand = GetCommand("bindSapAdReport", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("fromdate", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (fromdate == "" || fromdate == null)
                {
                    prm1.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    prm1.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
             
                objoraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("todate", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if (todate == "" || todate == null)
                {
                    prm2.Value = System.DBNull.Value;

                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;


                    }
                    prm2.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
               
                objoraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sedition", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (edition == "" || edition == "0")
                    prm3.Value = System.DBNull.Value;
                else
                    prm3.Value = edition;
                objoraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("agencycode", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (agencycode == "" || agencycode == "0")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = agencycode;
                objoraclecommand.Parameters.Add(prm4);

                objoraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objoraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objoracleDataAdapter.SelectCommand = objoraclecommand;
                objoracleDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objoracleconnection);
            }


        }
    }
}