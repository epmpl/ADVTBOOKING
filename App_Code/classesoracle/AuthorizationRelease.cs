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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.classesoracle
{

    public class AuthorizationRelease : orclconnection
    {
        public AuthorizationRelease()
        {
            //
            // TODO: Add constructor logic here
            //
        }
//=========================Start Procedure===============================//
        public DataSet findrecord(string userid, string compcode, string agency, string executive, string client, string fdate, string tdate, string dateformat, string cioid, string flag, string basedon, string branch, string orderby)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getapprovalRo_web", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("vusername", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("executive", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = executive;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("varFromDate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm6.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("varToDate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = dateformat;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = cioid;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = flag;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm13 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = branch;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pdate_based_on", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = basedon;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("porder", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = orderby;
                objOraclecommand.Parameters.Add(prm15);

                


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




        public DataSet findrecord123(string userid, string compcode, string agency, string executive, string client, string retainer, string fdate, string tdate, string dateformat, string flag, string adtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getquotationapproval", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("executiv", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = executive;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("retainer", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = retainer;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("varFromDate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    prm7.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("varToDate", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (tdate == "" || tdate == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    prm8.Value = Convert.ToDateTime(tdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("dateformat", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                //OracleParameter prm9 = new OracleParameter("cioid", OracleType.VarChar, 50);
                //prm9.Direction = ParameterDirection.Input;
                //prm9.Value = cioid;
                //objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("flag", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = flag;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("padtype", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = adtype;
                objOraclecommand.Parameters.Add(prm11);



                //OracleParameter prm15 = new OracleParameter("porder", OracleType.VarChar, 50);
                //prm15.Direction = ParameterDirection.Input;
                //prm15.Value = orderby;
                //objOraclecommand.Parameters.Add(prm15);




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







        public DataSet savedata(string remarks, string userid, string appstatus, string insertid, string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertRemarks_web", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("remarks", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = remarks;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("appstatus", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = appstatus;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("insertid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (insertid == "" || insertid == null)
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = insertid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = cioid;
                objOraclecommand.Parameters.Add(prm5);
    
                //objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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
        public DataSet fetchMailId(string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetchMailId_ro", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("bkid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = cioid;
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
//=================GEt login mail id====================//
        public DataSet findloginid(string vusername, string vpassword)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getlogindata", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("vusername", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = vusername;
                objOraclecommand.Parameters.Add(prm1);

                //OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = compcode;
                //objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("vpassword", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = vpassword;
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

        public DataSet bindrep(string center, string userid, string branch, string compcode, string agencycode, string client, string executive, string dateformat, string fdate, string todate)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_approvalro", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcentercode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = center;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pbranch", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branch;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pdateformat", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = dateformat;
                objOraclecommand.Parameters.Add(prm5);
     

                OracleParameter prm6 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (fdate == "" || fdate == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = fdate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    fdate = mm + "/" + dd + "/" + yy;
                    //}
                    prm6.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pto_date", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (todate == "" || todate == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                {
                    //if (dateformat == "dd/mm/yyyy")
                    //{
                    //    string[] arr = todate.Split('/');
                    //    string dd = arr[0];
                    //    string mm = arr[1];
                    //    string yy = arr[2];
                    //    todate = mm + "/" + dd + "/" + yy;
                    //}
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (agencycode == "" || agencycode == null)
                    prm8.Value = System.DBNull.Value;
                else
                    prm8.Value = agencycode;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("executive", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                if (executive == "" || executive == null)
                    prm9.Value = System.DBNull.Value;
                else
                prm9.Value = executive;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("client", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                if (client == "" || client == null)
                    prm10.Value = System.DBNull.Value;
                else
                    prm10.Value = client;
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
    }
}
