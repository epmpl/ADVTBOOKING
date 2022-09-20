using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for loginAdmin
    /// </summary>
    public class loginAdmin:orclconnection 
    {
        public loginAdmin()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet getUserName()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("ref_cursor_test.get_accounts_procedure", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                //OracleParameter prm1 = new OracleParameter("p_accounts", OracleType.VarChar,50);
                //prm1.Direction = ParameterDirection.Output;
                //objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;
               //OracleParameter prm2 = new OracleParameter("vusername", OracleType.VarChar,50);
               // prm2.Direction = ParameterDirection.Output;
               // objOraclecommand.Parameters.Add(prm2);

                objmysqlDataAdapter.SelectCommand = objOraclecommand;
                objmysqlDataAdapter.Fill(objDataSet);
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

        public DataSet chklogin(string username, string password)
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
                prm1.Direction = ParameterDirection.Input ;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("vpassword", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = password;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("vqbc", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;




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
        //public DataSet Advsave(string companycode, string adtypecode, string adtypename, string alias, string UserId)
        //{
        //    OracleConnection objOracleConnection;
        //    OracleCommand objOracleCommand;
        //    DataSet objDataSet = new DataSet();
        //    objOracleConnection = GetConnection();
        //    try
        //    {

        //        objOracleConnection.Open();
        //        //string sql = "select user_name,password,COMP_CODE, DATE_FORMAT,ID from  user_mst where user_name='" + username + "' and password='" + password + "' ";               
        //        string sql = "insert into adtype (COMP_CODE,ENTCD,DESCR,ADV_TYPE_ALIAS,USERID)values ('" + companycode + "','" + adtypecode + "','" + adtypename + "','" + alias + "','" + UserId + "')";
        //        objOracleCommand = GetCommand(sql, ref  objOracleConnection);
        //        objOracleCommand.CommandType = CommandType.Text;
        //        OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter();
        //        objOracleDataAdapter.SelectCommand = objOracleCommand;
        //        objOracleDataAdapter.Fill(objDataSet);
        //        return objDataSet;


        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        objOracleConnection.Close();
        //        objOracleConnection.Dispose();



        //    }

        //}
        //public string Loginid { get { return _Loginid; } set { _Loginid = value; } }
        //public string password { get { return _password; } set { _password = value; } }
        //public string IPADRESS { get { return _IPADRESS; } set { _IPADRESS = value; } }

        ////**********This function is used to GET the User Name using stored procedure getUserName*************
        //public DataSet getUserName()
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();

        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("getUserName", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objSqlConnection.Close();

        //    }
        //}
        ////**********************************************************************************************************

        //#region Check login user  return - DataSet
        //public DataSet chklogin(string username, string password)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Websp_LoginEmployee", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@username"].Value = username;
        //        objSqlCommand.Parameters.Add("@password", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@password"].Value = password;
        //        objSqlCommand.Parameters.Add("@qbc", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@qbc"].Value = System.DBNull.Value;

        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}

        ////******This function is used to GET the User Right Code using stored procedure userRCodeAuto For AutoGen***
        //public DataSet getuserRCode()
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();

        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("userRCodeAuto", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objSqlConnection.Close();

        //    }
        //}
        ////********************************************************************************************************** 


        //public DataSet sessiondate(string compcode, string userid)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Websp_sessiondate", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;
        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;
        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}


        //public DataSet dateshow(string compcode, string userid)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("Websp_dateshow", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@compcode"].Value = compcode;
        //        objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@userid"].Value = userid;

        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        CloseConnection(ref objSqlConnection);
        //    }
        //}



        //#endregion
        //#region "del logtrack"
        //public void deletelogtrack(string Loginid, string IPADRESS)
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    DataSet objDataSet = new DataSet();
        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("websp_deletefromlogtrack", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlCommand.Parameters.Add("@empcode", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@empcode"].Value = Loginid;
        //        objSqlCommand.Parameters.Add("@ip", SqlDbType.VarChar);
        //        objSqlCommand.Parameters["@ip"].Value = IPADRESS;
        //        objSqlCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objSqlConnection.Close();

        //    }
        //}
        //#endregion
        //#region "get userlogin"
        //public DataSet FillLogin()
        //{

        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();

        //    try
        //    {
        //        objSqlConnection.Open();
        //        objSqlCommand = GetCommand("websp_fillLoginName", ref objSqlConnection);
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlDataAdapter = new SqlDataAdapter();
        //        objSqlDataAdapter.SelectCommand = objSqlCommand;
        //        objSqlDataAdapter.Fill(objDataSet);
        //        return objDataSet;
        //    }
        //    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objSqlConnection.Close();

        //    }
        //}
        //#endregion
    }
}
