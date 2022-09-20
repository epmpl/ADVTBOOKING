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
    /// Summary description for Createuser
    /// </summary>
    public class Createuser : connection
    {
        public Createuser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet currency()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("login_getCurrencycode", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlconnection.Parameters.Add("Curr_Name", MySqlDbType.VarChar);
                //objmysqlconnection.Parameters["Curr_Name"].Value = currencyname;

                //objmysqlconnection.Parameters.Add("Curr_Code", MySqlDbType.VarChar);
                //objmysqlconnection.Parameters["Curr_Code"].Value = currencycode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet retainer()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("login_getbranchname", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlconnection.Parameters.Add("Curr_Name", MySqlDbType.VarChar);
                //objmysqlconnection.Parameters["Curr_Name"].Value = currencyname;

                //objmysqlconnection.Parameters.Add("Curr_Code", MySqlDbType.VarChar);
                //objmysqlconnection.Parameters["Curr_Code"].Value = currencycode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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
        public bool checkuser(string username)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand = new MySqlCommand();
            bool a = false;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand.Connection = objmysqlconnection;
                objmysqlcommand.CommandText = "select * from login where username='" + username + "'";
                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                if (objDataSet.Tables[0].Rows.Count > 0)
                    a = true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
            return a;
        }
        public DataSet usersave(string username, string password, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user, string compnamelist, string emailid, string discount, string filter, string rolename, string editlines,string firstname, string lastname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
          
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("loginInsert", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;

                objmysqlcommand.Parameters.Add("password1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["password1"].Value = password;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("date_format1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date_format1"].Value = date_for;

                objmysqlcommand.Parameters.Add("comp_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_name"].Value = compname;

                objmysqlcommand.Parameters.Add("com_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["com_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("curr_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["curr_code"].Value = currname;


                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("retainer_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retainer_code"].Value = retainername;


                objmysqlcommand.Parameters.Add("user1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["user1"].Value = user;

                objmysqlcommand.Parameters.Add("admin", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["admin"].Value = admin;


                objmysqlcommand.Parameters.Add("comp_user", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_user"].Value = comp_user;

                objmysqlcommand.Parameters.Add("compnamelist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compnamelist"].Value = compnamelist;

                objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["emailid"].Value = emailid;

                objmysqlcommand.Parameters.Add("discount", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["discount"].Value = discount;

                objmysqlcommand.Parameters.Add("filter", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["filter"].Value = filter;


                objmysqlcommand.Parameters.Add("rolename", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["rolename"].Value = rolename;

                objmysqlcommand.Parameters.Add("editlines", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editlines"].Value = editlines;

                objmysqlcommand.Parameters.Add("firstname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["firstname"].Value = firstname;

                objmysqlcommand.Parameters.Add("lastname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["lastname"].Value = lastname;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet genuserid(string str, string branchname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("userloginauto", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("str", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["str"].Value = str;

                objmysqlcommand.Parameters.Add("cod", MySqlDbType.VarChar);
                if (str.Length > 2)
                {
                    objmysqlcommand.Parameters["cod"].Value =str.Substring(0, 2);
                }

                else
                {
                    objmysqlcommand.Parameters["cod"].Value =str;
                }

                objmysqlcommand.Parameters.Add("branchname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchname"].Value = branchname;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

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

        public DataSet chkuserid(string userid, string username, string branchname)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("userloginudefine", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("USERNAME", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERNAME"].Value = username;

                objmysqlcommand.Parameters.Add("USERID", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["USERID"].Value = userid;

                objmysqlcommand.Parameters.Add("BRANCHNAME", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["BRANCHNAME"].Value = branchname;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

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

        public DataSet userexecute(string username, string userid, string compcode, string admin)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("loginexecute", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("username1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username1"].Value = username;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("com_code1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["com_code1"].Value = compcode;

                objmysqlcommand.Parameters.Add("admin1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["admin1"].Value = admin;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;

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

        public DataSet userdelete(string userid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("loginDelete", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        //public DataSet usermodify(string username, string password, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user)
        public DataSet usermodify(string username, string password, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user, string companylist, string emailid, string discount, string filter, string rolename, string editlines, string firstname, string lastname)
       
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            //string err = "";
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("loginModify", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;

                objmysqlcommand.Parameters.Add("password1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["password1"].Value = password;

                objmysqlcommand.Parameters.Add("userid1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid1"].Value = userid;

                objmysqlcommand.Parameters.Add("date_format1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["date_format1"].Value = date_for;

                objmysqlcommand.Parameters.Add("comp_name", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_name"].Value = compname;

                objmysqlcommand.Parameters.Add("com_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["com_code"].Value = compcode;

                objmysqlcommand.Parameters.Add("curr_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["curr_code"].Value = currname;


                objmysqlcommand.Parameters.Add("agencycode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["agencycode"].Value = agencycode;

                objmysqlcommand.Parameters.Add("retainer_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["retainer_code"].Value = retainername;

                objmysqlcommand.Parameters.Add("user1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["user1"].Value = user;

                objmysqlcommand.Parameters.Add("admin1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["admin1"].Value = admin;

                objmysqlcommand.Parameters.Add("comp_user", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["comp_user"].Value = comp_user;





                objmysqlcommand.Parameters.Add("companylist", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["companylist"].Value = companylist;


                objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["emailid"].Value = emailid;

                objmysqlcommand.Parameters.Add("disc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["disc"].Value = discount;

                objmysqlcommand.Parameters.Add("fil", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["fil"].Value = filter;

                objmysqlcommand.Parameters.Add("role", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["role"].Value = rolename;

                objmysqlcommand.Parameters.Add("editlines", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["editlines"].Value = editlines;

                objmysqlcommand.Parameters.Add("firstname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["firstname"].Value = firstname;

                objmysqlcommand.Parameters.Add("lastname", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["lastname"].Value = lastname;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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


        public DataSet bindCompany()
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getCompName", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet BindRole(string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("Rolebind", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet usersavebranch(string username, string branchcode, string userflag, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("loginInsertBranchpermission", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("userflag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userflag"].Value = userflag;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet userupdatebranch(string username, string branchcode, string userflag, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("loginUpdateBranchpermission", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("username", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["username"].Value = username;

                objmysqlcommand.Parameters.Add("branchcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["branchcode"].Value = branchcode;

                objmysqlcommand.Parameters.Add("userflag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userflag"].Value = userflag;

                objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet executebranch(string userid, string compcode)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("brnchpermissionexe", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;

                objmysqlcommand.Parameters.Add("com_code", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["com_code"].Value = compcode;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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

        public DataSet userexecute1(string mail)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("mailchk", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("emailid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["emailid"].Value = mail;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
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