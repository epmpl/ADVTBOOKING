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
    /// Summary description for loginAdmin
    /// </summary>
    public class loginAdmin:connection 
    {
        private string _Loginid;
        private string _password;
        private string _IPADRESS;

        public loginAdmin()
        {
            //
            // TODO: Add constructor logic here
            //
            _Loginid = null;
            _password = null;
            _IPADRESS = null;
        }

        public string Loginid { get { return _Loginid; } set { _Loginid = value; } }
        public string password { get { return _password; } set { _password = value; } }
        public string IPADRESS { get { return _IPADRESS; } set { _IPADRESS = value; } }

        public DataSet getUserName()
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
        public DataSet chklogin(string username, string password)
       {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();


            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Websp_LoginEmployee", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;
                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;
                objmysqlcommand.Parameters.Add("password1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["password1"].Value = password;
                objmysqlcommand.Parameters.Add("qbc", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["qbc"].Value = System.DBNull.Value;
                objmysqlcommand.Parameters["qbc"].Value = "null";
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

    }
}