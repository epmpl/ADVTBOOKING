using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for login.
    /// </summary>
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
        
         public DataSet getMessageCenterWise(string center)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("getMessageCenterWise", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;

                 objSqlCommand.Parameters.Add("@center_p", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@center_p"].Value = center;



                 objSqlDataAdapter = new SqlDataAdapter();
                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return objDataSet;
             }
             catch (Exception objException)
             {
                 throw (objException);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }
         }
         public DataSet fetchKey(string compcode)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("fetchKey", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;

                 objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@compcode"].Value = compcode;



                 objSqlDataAdapter = new SqlDataAdapter();
                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return objDataSet;
             }
             catch (Exception objException)
             {
                 throw (objException);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }
         }
         public DataSet fetchLicenseKeyDate(string compcode,string key)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("fetchLicenseKeyDate", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;

                 objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@compcode"].Value = compcode;

                 objSqlCommand.Parameters.Add("@key", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@key"].Value = key;

                 objSqlDataAdapter = new SqlDataAdapter();
                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return objDataSet;
             }
             catch (Exception objException)
             {
                 throw (objException);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }
         }
         public DataSet saveLoginInfo(string compcode, string userid, string ip, string filter, string session_p)
         {
             SqlConnection objSqlConnection;
             SqlCommand objSqlCommand;
             objSqlConnection = GetConnection();
             SqlDataAdapter objSqlDataAdapter;
             DataSet objDataSet = new DataSet();
             try
             {
                 objSqlConnection.Open();
                 objSqlCommand = GetCommand("saveLoginInfo", ref objSqlConnection);
                 objSqlCommand.CommandType = CommandType.StoredProcedure;

                 objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                 objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@userid_p"].Value = userid;

                 objSqlCommand.Parameters.Add("@ip_p", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@ip_p"].Value = ip;

                 objSqlCommand.Parameters.Add("@filter_p", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@filter_p"].Value = filter;

                 objSqlCommand.Parameters.Add("@session_p", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@session_p"].Value = session_p;

                 objSqlCommand.Parameters.Add("@module_id", SqlDbType.VarChar);
                 objSqlCommand.Parameters["@module_id"].Value = "1";

                 objSqlDataAdapter = new SqlDataAdapter();
                 objSqlDataAdapter.SelectCommand = objSqlCommand;
                 objSqlDataAdapter.Fill(objDataSet);
                 return objDataSet;
             }
             catch (Exception objException)
             {
                 throw (objException);
             }
             finally
             {
                 CloseConnection(ref objSqlConnection);
             }
         }
        public DataSet getCenter(string compcode, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getCenter_Agency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

           
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getagCenter(string compcode, string matter, string center)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getagName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = matter;

                objSqlCommand.Parameters.Add("@center", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center"].Value = center;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getUser(string QBC)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getUser", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@QBC", SqlDbType.VarChar);
                objSqlCommand.Parameters["@QBC"].Value = QBC;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        public DataSet getQBC( string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        public DataSet getPubCenter()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet clsGetTempData()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
               objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Gettempdata", ref objSqlConnection);

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        //========================= Ad by rinki ========================================//
        public DataSet chkpwd(string oldpwd, string code, string usercode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getpassword", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = usercode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = code;

                objSqlCommand.Parameters.Add("@pwd", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pwd"].Value = oldpwd;

             
                //objOraclecommand.Parameters.Add("p_password", OracleType.Cursor);
                //objOraclecommand.Parameters["p_password"].Direction = ParameterDirection.Output;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet getupuser()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getUserName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet cngpwd(string newpwd, string code, string usercode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cngpassword", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@newpass", SqlDbType.VarChar);
                objSqlCommand.Parameters["@newpass"].Value = newpwd;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = code;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = usercode;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        public DataSet clschkBookingTable(string compcode, string cio_bookingid, string insnum, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_chkBookingTable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cio_bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_bookingid"].Value = cio_bookingid;

                objSqlCommand.Parameters.Add("@insnum", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insnum"].Value = insnum;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public void clsInsertintoBookingTable(string compcode, string cio_bookingid, string insnum, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            //SqlDataAdapter objSqlDataAdapter;
           // DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_InsertintoBookingTable", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cio_bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cio_bookingid"].Value = cio_bookingid;

                objSqlCommand.Parameters.Add("@insnum", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insnum"].Value = insnum;

                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.ExecuteNonQuery();
                //objSqlDataAdapter = new SqlDataAdapter();
                //objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlDataAdapter.Fill(objDataSet);
                //return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public void clsdeletetempbooking()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            //SqlDataAdapter objSqlDataAdapter;
            // DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Deletetempbooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                //objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.ExecuteNonQuery();
             //   objSqlDataAdapter.SelectCommand = objSqlCommand;
                //objSqlDataAdapter.Fill(objDataSet);
                //return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        public DataSet getmoduleper(string comcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getmoduleper", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getPubCenterlogin(string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenterlogin", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;


                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
        public DataSet getmodule()
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("user_privileges_module_bind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();


                objSqlCommand.Parameters.Add("@pmodule_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmodule_code"].Value = "";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = "";

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = "";

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = "";

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }


        }
        public DataSet getUserlogin(string extra1)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("cir_login_bind_p", ref objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();


                objSqlCommand.Parameters.Add("@plogin_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@plogin_code"].Value = "";

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = "";

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = "";

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }


        }
        //=============================================================================///
        public string Loginid { get { return _Loginid; } set { _Loginid = value; } }
        public string password { get { return _password; } set { _password = value; } }
        public string IPADRESS { get { return _IPADRESS; } set { _IPADRESS = value; } }
        #region Check login user  return - DataSet
        public DataSet chklogin(string username, string password,string qbc)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_LoginEmployee", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                objSqlCommand.Parameters["@username"].Value = username;
                objSqlCommand.Parameters.Add("@password", SqlDbType.VarChar);
                objSqlCommand.Parameters["@password"].Value = password;
                objSqlCommand.Parameters.Add("@qbc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@qbc"].Value = qbc;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet sessiondate(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_sessiondate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }


        public DataSet dateshow(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_dateshow", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }

        public DataSet getuser_login(string agencycode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getuserofagency", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }




       



        #endregion
        #region "del logtrack"
        public void deletelogtrack(string Loginid, string IPADRESS)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_deletefromlogtrack", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@empcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@empcode"].Value = Loginid;
                objSqlCommand.Parameters.Add("@ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ip"].Value = IPADRESS;
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        #endregion
        #region "get userlogin"
        public DataSet FillLogin()
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_fillLoginName", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        #endregion
    }
}
