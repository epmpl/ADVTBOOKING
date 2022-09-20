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
    /// Summary description for login
    /// </summary>
    /// 
    //public delegate int MyDelegate(int x, int y);

    public class login : orclconnection
    {
        private string _Loginid;
        private string _password;
        private string _IPADRESS;
        public login()
        {
            //
            // TODO: Add constructor logic here
            //
            _Loginid = null;
            _password = null;
            _IPADRESS = null;
        }
        //public static int Add(int x, int y)
        //{

        //    return x + y;

        //}

        //public static int Multiply(int x, int y)
        //{

        //    return x * y;

        //}
        public DataSet getMessageCenterWise(string center)
        {
            OracleConnection objoracleconnection;
            OracleCommand objoraclecommand;
            OracleDataAdapter objoracleDataAdapter = new OracleDataAdapter();
            DataSet objDataSet = new DataSet();
            objoracleconnection = GetConnection();
            try
            {

                objoracleconnection.Open();
                objoraclecommand = GetCommand("getMessageCenterWise", ref objoracleconnection);
                //objoraclecommand = GetCommand("report_test", ref objoracleconnection);
                objoraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm3 = new OracleParameter("center_p", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objoraclecommand.Parameters.Add(prm3);


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
        public DataSet fetchKey(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetchKey", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();

            }
        }
        public DataSet fetchLicenseKeyDate(string compcode,string key)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fetchLicenseKeyDate", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm11 = new OracleParameter("key", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = key;
                objOraclecommand.Parameters.Add(prm11);


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
        public DataSet saveLoginInfo(string compcode, string userid, string ip, string filter, string session_p)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("saveLoginInfo", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode_p", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid_p", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("ip_p", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = ip;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("filter_p", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = filter;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("session_p", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = session_p;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("module_id", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = "1";
                objOraclecommand.Parameters.Add(prm6);

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
        public DataSet bindbranchDJ(string username, string publication, string loginth,string pcenter)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_filter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("puser", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_publ", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = publication;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("P_local_ho", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = loginth;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_cent", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pcenter;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_publication", OracleType.Cursor);
                objOraclecommand.Parameters["p_publication"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_center", OracleType.Cursor);
                objOraclecommand.Parameters["p_center"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_branch", OracleType.Cursor);
                objOraclecommand.Parameters["p_branch"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_ho_local", OracleType.Cursor);
                objOraclecommand.Parameters["p_ho_local"].Direction = ParameterDirection.Output;


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
        public DataSet bindcenterDJ(string username, string publication)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_filter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("puser", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_publ", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = publication;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("P_local_ho", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_cent", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_publication", OracleType.Cursor);
                objOraclecommand.Parameters["p_publication"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_center", OracleType.Cursor);
                objOraclecommand.Parameters["p_center"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_branch", OracleType.Cursor);
                objOraclecommand.Parameters["p_branch"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_ho_local", OracleType.Cursor);
                objOraclecommand.Parameters["p_ho_local"].Direction = ParameterDirection.Output;


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
        public DataSet bindpublicationDJ(string username)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_filter", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("puser", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("p_publ", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("P_local_ho", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("p_cent", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_publication", OracleType.Cursor);
                objOraclecommand.Parameters["p_publication"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_center", OracleType.Cursor);
                objOraclecommand.Parameters["p_center"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_branch", OracleType.Cursor);
                objOraclecommand.Parameters["p_branch"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_ho_local", OracleType.Cursor);
                objOraclecommand.Parameters["p_ho_local"].Direction = ParameterDirection.Output;


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
        public DataSet getUser(string QBC)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getUser.websp_getUser_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
               
                OracleParameter prm1 = new OracleParameter("QBC", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = QBC;
                objOraclecommand.Parameters.Add(prm1);
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
        public DataSet getCenter(string compcode,string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getCenter_Agency.getCenter_Agency_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("Compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
                objOraclecommand.Parameters.Add(prm2);

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
        public DataSet getQBC(string pubcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_QBC.websp_QBC_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                
                OracleParameter prm1 = new OracleParameter("pubcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = pubcode;
                objOraclecommand.Parameters.Add(prm1);
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
        public DataSet getPubCenterAgency(string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_pubcenter_Agency", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("center", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = center;
                objOraclecommand.Parameters.Add(prm2);

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
        public DataSet getPubCenter()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_pubcenter.websp_pubcenter_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //OracleParameter prm2 = new OracleParameter("company_code", OracleType.VarChar);
                //prm2.Direction = ParameterDirection.Input;
                //prm2.Value = compcode;
                //objOraclecommand.Parameters.Add(prm2);
                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet getPubCenter_company(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Bind_PubCentName.Bind_PubCentName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
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
        public DataSet chkpwd(string oldpwd,string code,string usercode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {               
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getpassword.getpassword_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usercode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("pwd", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = oldpwd;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_password", OracleType.Cursor);
                objOraclecommand.Parameters["p_password"].Direction = ParameterDirection.Output;


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

        public DataSet cngpwd(string newpwd, string code,string usercode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("cngpassword.cngpassword_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("newpass", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = newpwd;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm1 = new OracleParameter("userid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm3 = new OracleParameter("compcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = usercode;
                objOraclecommand.Parameters.Add(prm3);

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

        public DataSet chklogin(string username, string password, string qbc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_LoginEmployee.Websp_LoginEmployee_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("vusername", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("vpassword", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = password;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("vqbc", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;

                if (qbc == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = qbc;
                }
                objOraclecommand.Parameters.Add(prm3);                

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("P_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts2"].Direction = ParameterDirection.Output;

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



        public DataSet getuser_login(string agencycode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getuserofagency.websp_getuserofagency_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;                

                OracleParameter prm1 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agencycode;
                objOraclecommand.Parameters.Add(prm1);
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



        public DataSet dateshow(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_dateshow.Websp_dateshow_p", ref objOracleConnection);
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
        public DataSet getagCenter(string compcode,string matter,string center)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getagName.websp_getagName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = matter;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("center", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = center;
                objOraclecommand.Parameters.Add(prm3);

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

        public DataSet getupuser()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getUserName.getUserName_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        public void clsInsertintoBookingTable(string compcode,string cio_bookingid,string insnum,string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            //DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
           // OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_InsertintoBookingTable", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cio_bookingid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cio_bookingid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("insnum", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = insnum;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.ExecuteNonQuery();
                
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

        public void clsdeletetempbooking()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            //DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            // OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Deletetempbooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;                

                objOraclecommand.ExecuteNonQuery();

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

        public DataSet clschkBookingTable(string compcode, string cio_bookingid, string insnum, string edition)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_chkBookingTable.websp_chkBookingTable_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cio_bookingid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cio_bookingid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("insnum", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = insnum;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("edition", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = edition;
                objOraclecommand.Parameters.Add(prm4);

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


        public DataSet clsGetTempData()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getTempData.websp_getTempData_P", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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

        public DataSet getPubCenterlogin(string agency)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_pubcenterlogin.websp_pubcenterlogin_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agency;
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
        public DataSet getmoduleper(string comcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("websp_getmoduleper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
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
        public DataSet getmodule()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("user_privileges.module_bind_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pmodule_code", OracleType.VarChar, 2000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = "";
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pdateformat", OracleType.VarChar, 2000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = "";
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pextra1", OracleType.VarChar, 2000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = "";
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra2", OracleType.VarChar, 2000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = "";
                objOraclecommand.Parameters.Add(prm4);

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
        public string Loginid { get { return _Loginid; } set { _Loginid = value; } }
        public string password { get { return _password; } set { _password = value; } }
        public string IPADRESS { get { return _IPADRESS; } set { _IPADRESS = value; } }
    }
}