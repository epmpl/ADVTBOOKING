using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for login
    /// </summary>
    /// 

    public class login:connection 
    {
        private string _Loginid;
        private string _password;
        private string _IPADRESS;
        public login()
        {
            _Loginid = null;
            _password = null;
            _IPADRESS = null;
        }
        public DataSet getCenter(string compcode, string agency)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getCenter_Agency", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;
                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = agency;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet getmoduleper(string comcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_getmoduleper", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("COMCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["COMCODE"].Value = comcode;
                objmysqlcommand.Parameters.Add("USERID1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID1"].Value = userid;
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet getUser(string QBC)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
          

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_GETUSER_WEBSP_GETUSER_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("QBC", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["QBC"].Value = QBC;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }



        public DataSet getQBC(string pubcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter=new MySqlDataAdapter ();
            DataSet objDataSet = new DataSet();            
           
          

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("WEBSP_QBC_WEBSP_QBC_P", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("PUBCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PUBCODE"].Value = pubcode;

                //objmysqlcommand.Parameters.Add("PUBCODE", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["PUBCODE"].Value = "";
               
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet getPubCenter()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_pubcenter_websp_pubcenter_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("PCOMPCODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PCOMPCODE"].Value = System.DBNull.Value;
      
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

     

        public DataSet chklogin(string username, string password, string qbc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_LoginEmployee_Websp_LoginEmployee_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("VUSERNAME", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["VUSERNAME"].Value = username;

                objmysqlcommand.Parameters.Add("VPASSWORD", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["VPASSWORD"].Value = password;

                objmysqlcommand.Parameters.Add("VQBC", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["VQBC"].Value = qbc;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        /*new change ankur 28 feb*/
        public DataSet getuser_login(string agencycode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_getuserofagency", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet getPubCenterlogin(string agency)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_pubcenterlogin", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = agency;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }


        public DataSet clsGetTempData()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_Gettempdata", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }

        public DataSet dateshow(string compcode, string userid)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_dateshow", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }

        }

        //getagCenter(compcode, matter, Session["center"].ToString())
        public DataSet getagCenter(string compcode, string matter,string center)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("websp_getagName", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("agency", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agency"].Value = matter;

                objmysqlcommand.Parameters.Add("center", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["center"].Value = center;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet getupuser()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();



            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getUserName", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;


                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objmysqlconnection.Close();

            }
        }
        public DataSet chkpwd(string oldpwd, string code, string usercode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getpassword", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = usercode;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = oldpwd;

                objmysqlcommand.Parameters.Add("pwd", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["pwd"].Value = code;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet cngpwd(string newpwd, string code, string usercode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("cngpassword_cngpassword_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("newpass", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["newpass"].Value = newpwd;

                objmysqlcommand.Parameters.Add("puserid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["puserid"].Value = code;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = usercode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }
        public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string branch1, string adtype, string audittype, string branch2, string abc_cat, string userid, string comp_code)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objdataset = new DataSet();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Bindaudit_grid_Bindaudit_grid_p", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("PDATE1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PDATE1"].Value = dateformat;

                objmysqlcommand.Parameters.Add("PADTYPE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PADTYPE"].Value = adtype;

                objmysqlcommand.Parameters.Add("PBRANCH2", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["PBRANCH2"].Value = branch2;

                objmysqlcommand.Parameters.Add("V_USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["V_USERID"].Value = userid;

                objmysqlcommand.Parameters.Add("V_COMP_CODE", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["V_COMP_CODE"].Value = comp_code;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objdataset);
                return objdataset;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


    }
}