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
    /// Summary description for AdSubCat5
    /// </summary>
    public class Createuser : connection
    {
        public Createuser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getagency(string userid)
        {

            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("login_getAgencycode", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@userid1", SqlDbType.VarChar);
                com.Parameters["@userid1"].Value = userid;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet currency()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("login_getCurrencycode", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Curr_Name", SqlDbType.VarChar);
                //com.Parameters["@Curr_Name"].Value = currencyname;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet retainer()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("login_getbranchname", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Curr_Name", SqlDbType.VarChar);
                //com.Parameters["@Curr_Name"].Value = currencyname;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet usersave(string username, string pwdencry, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user, string compnamelist, string emailid, string discount, string filter, string rolename, string editlines, string firstname, string lastname, string status, string empcode, string acccode, string MACHINE_IP, string MACHINE_NAME, string MACHINE_MAC_ADDR, string executive, string gaterate, string datestatus, string dateformate, string createdby)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("loginInsert", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;

                com.Parameters.Add("@password", SqlDbType.VarChar);
                com.Parameters["@password"].Value = pwdencry;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@date_format", SqlDbType.VarChar);
                com.Parameters["@date_format"].Value = date_for;

                com.Parameters.Add("@comp_name", SqlDbType.VarChar);
                com.Parameters["@comp_name"].Value = compname;

                com.Parameters.Add("@com_code", SqlDbType.VarChar);
                com.Parameters["@com_code"].Value = compcode;

                com.Parameters.Add("@curr_code", SqlDbType.VarChar);
                com.Parameters["@curr_code"].Value = currname;


                com.Parameters.Add("@agencycode", SqlDbType.VarChar);
                com.Parameters["@agencycode"].Value = agencycode;

                com.Parameters.Add("@retainer_code", SqlDbType.VarChar);
                com.Parameters["@retainer_code"].Value = retainername;


                com.Parameters.Add("@user", SqlDbType.VarChar);
                com.Parameters["@user"].Value = user;

                com.Parameters.Add("@admin", SqlDbType.VarChar);
                com.Parameters["@admin"].Value = admin;


                com.Parameters.Add("@comp_user", SqlDbType.VarChar);
                com.Parameters["@comp_user"].Value = comp_user;

                com.Parameters.Add("@compnamelist", SqlDbType.VarChar);
                com.Parameters["@compnamelist"].Value = compnamelist;

                com.Parameters.Add("@emailid", SqlDbType.VarChar);
                com.Parameters["@emailid"].Value = emailid;

                com.Parameters.Add("@discount", SqlDbType.VarChar);
                com.Parameters["@discount"].Value = discount;

                com.Parameters.Add("@filter", SqlDbType.VarChar);
                com.Parameters["@filter"].Value = filter;


                com.Parameters.Add("@rolename", SqlDbType.VarChar);
                com.Parameters["@rolename"].Value = rolename;

                com.Parameters.Add("@editlines", SqlDbType.VarChar);
                com.Parameters["@editlines"].Value = editlines;

                com.Parameters.Add("firstname", SqlDbType.VarChar);
                com.Parameters["firstname"].Value = firstname;

                com.Parameters.Add("lastname", SqlDbType.VarChar);
                com.Parameters["lastname"].Value = lastname;

                com.Parameters.Add("@pstatus", SqlDbType.VarChar);
                com.Parameters["@pstatus"].Value = status;

                com.Parameters.Add("@p_empcode", SqlDbType.VarChar);
                com.Parameters["@p_empcode"].Value = empcode;



                com.Parameters.Add("@p_MACHINE_IP", SqlDbType.VarChar);
                com.Parameters["@p_MACHINE_IP"].Value = MACHINE_IP;

                com.Parameters.Add("@p_MACHINE_NAME", SqlDbType.VarChar);
                com.Parameters["@p_MACHINE_NAME"].Value = MACHINE_NAME;

                com.Parameters.Add("@p_MACHINE_MAC_ADDR", SqlDbType.VarChar);
                com.Parameters["@p_MACHINE_MAC_ADDR"].Value = MACHINE_MAC_ADDR;

                com.Parameters.Add("@pgetrate", SqlDbType.VarChar);
                com.Parameters["@pgetrate"].Value = gaterate;

                com.Parameters.Add("@p_acccode", SqlDbType.VarChar);
                com.Parameters["@p_acccode"].Value = acccode;

                com.Parameters.Add("@p_executive", SqlDbType.VarChar);
                com.Parameters["@p_executive"].Value = executive;

                com.Parameters.Add("@pdatestaus", SqlDbType.VarChar);
                if (datestatus == "")
                {
                    com.Parameters["@pdatestaus"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = datestatus.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datestatus = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformate == "yyyy/mm/dd")
                    {
                        string[] arr = datestatus.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datestatus = mm + "/" + dd + "/" + yy;
                    }
                    com.Parameters["@pdatestaus"].Value = datestatus;
                }
                com.Parameters.Add("@pcreatedby", SqlDbType.VarChar);
                com.Parameters["@pcreatedby"].Value = createdby;
             //   com.Parameters.Add("@p_mobile", SqlDbType.VarChar);
              //  com.Parameters["@p_mobile"].Value = "";

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet genuserid(string str, string branchname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("userloginauto", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@str", SqlDbType.VarChar);
                com.Parameters["@str"].Value = str;

                com.Parameters.Add("@cod", SqlDbType.VarChar);
                com.Parameters["@cod"].Value = str;

                com.Parameters.Add("@branchname", SqlDbType.VarChar);
                com.Parameters["@branchname"].Value = branchname;

                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet chkuserid(string userid, string username, string branchname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("userloginudefine", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@branchname", SqlDbType.VarChar);
                com.Parameters["@branchname"].Value = branchname;

                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet userexecute(string username, string userid, string compcode,string admin)
         //public DataSet userexecute(string mail)
        
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("loginexecute", ref con);
               // com = GetCommand("mailchk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@emailid", SqlDbType.VarChar);
                //com.Parameters["@emailid"].Value = mail;

                com.Parameters.Add("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@com_code", SqlDbType.VarChar);
                com.Parameters["@com_code"].Value = compcode;

                com.Parameters.Add("@admin", SqlDbType.VarChar);
                com.Parameters["@admin"].Value = admin;


                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet userexecute1(string mail)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                //com = GetCommand("loginexecute", ref con);
                com = GetCommand("mailchk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@emailid", SqlDbType.VarChar);
                com.Parameters["@emailid"].Value = mail;

                //com.Parameters.Add("@username", SqlDbType.VarChar);
                //com.Parameters["@username"].Value = username;

                //com.Parameters.Add("@userid", SqlDbType.VarChar);
                //com.Parameters["@userid"].Value = userid;

                //com.Parameters.Add("@com_code", SqlDbType.VarChar);
                //com.Parameters["@com_code"].Value = compcode;

                //com.Parameters.Add("@admin", SqlDbType.VarChar);
                //com.Parameters["@admin"].Value = admin;


                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet userdelete(string userid, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("loginDelete", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;
                
                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet usermodify(string username, string pwdencry, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user, string companylist, string emailid, string discount, string filter, string rolename, string editlines, string firstname, string lastname, string status, string getrate, string datastaus, string dateform)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("loginModify", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;

                com.Parameters.Add("@password", SqlDbType.VarChar);
                com.Parameters["@password"].Value = pwdencry;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@date_format", SqlDbType.VarChar);
                com.Parameters["@date_format"].Value = date_for;

                com.Parameters.Add("@comp_name", SqlDbType.VarChar);
                com.Parameters["@comp_name"].Value = compname;

                com.Parameters.Add("@com_code", SqlDbType.VarChar);
                com.Parameters["@com_code"].Value = compcode;

                com.Parameters.Add("@curr_code", SqlDbType.VarChar);
                com.Parameters["@curr_code"].Value = currname;


                com.Parameters.Add("@agencycode", SqlDbType.VarChar);
                com.Parameters["@agencycode"].Value = agencycode;

                com.Parameters.Add("@retainer_code", SqlDbType.VarChar);
                com.Parameters["@retainer_code"].Value = retainername;

                com.Parameters.Add("@user", SqlDbType.VarChar);
                com.Parameters["@user"].Value = user;

                com.Parameters.Add("@admin", SqlDbType.VarChar);
                com.Parameters["@admin"].Value = admin;

                com.Parameters.Add("@comp_user", SqlDbType.VarChar);
                com.Parameters["@comp_user"].Value = comp_user;

                
                com.Parameters.Add("@companylist", SqlDbType.VarChar);
                com.Parameters["@companylist"].Value = companylist;


                com.Parameters.Add("@emailid", SqlDbType.VarChar);
                com.Parameters["@emailid"].Value = emailid;

                com.Parameters.Add("@disc", SqlDbType.VarChar);
                com.Parameters["@disc"].Value = discount;

                com.Parameters.Add("@fil", SqlDbType.VarChar);
                com.Parameters["@fil"].Value = filter;

                com.Parameters.Add("@role", SqlDbType.VarChar);
                com.Parameters["@role"].Value = rolename;

                com.Parameters.Add("@editlines", SqlDbType.VarChar);
                com.Parameters["@editlines"].Value = editlines;

                com.Parameters.Add("@firstname", SqlDbType.VarChar);
                com.Parameters["@firstname"].Value = firstname;

                com.Parameters.Add("@lastname", SqlDbType.VarChar);
                com.Parameters["@lastname"].Value = lastname;

                com.Parameters.Add("@pstatus", SqlDbType.VarChar);
                com.Parameters["@pstatus"].Value = status;

                com.Parameters.Add("@pgetrate", SqlDbType.VarChar);
                com.Parameters["@pgetrate"].Value = getrate;

                com.Parameters.Add("@pdatestaus", SqlDbType.VarChar);
                if (datastaus == "")
                {
                    com.Parameters["@pdatestaus"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateform == "dd/mm/yyyy")
                    {
                        string[] arr = datastaus.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        datastaus = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateform == "yyyy/mm/dd")
                    {
                        string[] arr = datastaus.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        datastaus = mm + "/" + dd + "/" + yy;
                    }
                    com.Parameters["@pdatestaus"].Value = datastaus;
                }


                com.Parameters.Add("@int_id ", SqlDbType.VarChar);
                com.Parameters["@int_id "].Value = System.DBNull.Value;

              //  com.Parameters.Add("@p_MACHINE_IP", SqlDbType.VarChar);
              //  com.Parameters["@p_MACHINE_IP"].Value = MACHINE_IP;

              //  com.Parameters.Add("@p_MACHINE_NAME", SqlDbType.VarChar);
              //  com.Parameters["@p_MACHINE_NAME"].Value = MACHINE_NAME;

               // com.Parameters.Add("@p_MACHINE_MAC_ADDR", SqlDbType.VarChar);
              //  com.Parameters["@p_MACHINE_MAC_ADDR"].Value = MACHINE_MAC_ADDR;



              //  com.Parameters.Add("@p_acccode", SqlDbType.VarChar);
               // com.Parameters["@p_acccode"].Value = acccode;

             //   com.Parameters.Add("@p_mobileno", SqlDbType.VarChar);
             //   com.Parameters["@p_mobileno"].Value = mobileno;


             //   com.Parameters.Add("@AD_EXECUTIVE", SqlDbType.VarChar);
             //   com.Parameters["@AD_EXECUTIVE"].Value = "";

              //  com.Parameters.Add("@p_mail", SqlDbType.VarChar);
               // com.Parameters["@p_mail"].Value = "";



                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        //============================== ad by rinki===================================///

        public DataSet bindCompany()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("getCompName", ref con);
                com.CommandType = CommandType.StoredProcedure;




                //com.Parameters.Add("@Curr_Name", SqlDbType.VarChar);
                //com.Parameters["@Curr_Name"].Value = currencyname;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;
                //objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }
        //------------------ --------------------AD NEW FUNCTUION===============================================/
        public DataSet usersavebranch(string username, string branchcode, string userflag, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("loginInsertBranchpermission", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;

                com.Parameters.Add("@branchcode", SqlDbType.VarChar);
                com.Parameters["@branchcode"].Value = branchcode;

                com.Parameters.Add("@userflag", SqlDbType.VarChar);
                com.Parameters["@userflag"].Value = userflag;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;


                 da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }


        public DataSet userupdatebranch(string username, string branchcode, string userflag, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("loginUpdateBranchpermission", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@username", SqlDbType.VarChar);
                com.Parameters["@username"].Value = username;

                com.Parameters.Add("@branchcode", SqlDbType.VarChar);
                com.Parameters["@branchcode"].Value = branchcode;

                com.Parameters.Add("@userflag", SqlDbType.VarChar);
                com.Parameters["@userflag"].Value = userflag;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }

        public DataSet executebranch(string userid, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("brnchpermissionexe", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;

                com.Parameters.Add("@com_code", SqlDbType.VarChar);
                com.Parameters["@com_code"].Value = compcode;

                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }

        //------------ ad by rinki ----------------//

        public DataSet BindRole(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Rolebind", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                da.SelectCommand = com;
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet bindempcode(string compcode, string empname)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                //  objSqlCommand = GetCommand("regionbind", ref objSqlConnection);
                //  objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand = GetCommand("emp_code_bind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("@pname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pname"].Value = empname;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

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




        public DataSet bindcashier(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("chkprefren", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@Pcompcode", SqlDbType.VarChar);
                com.Parameters["@Pcompcode"].Value = compcode;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }





        public DataSet bindcashier_callback(string compcode, string accty, string accname, string userid, string extra1, string extra2)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("fa_account_mast_typewise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@paccty", SqlDbType.VarChar);
                com.Parameters["@paccty"].Value = accty;

                com.Parameters.Add("@paccname", SqlDbType.VarChar);
                com.Parameters["@paccname"].Value = accname;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;


                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
        public DataSet get_agency_name(string comp, string subagecode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = new SqlCommand();
                string query = "select dbo.ad_AGENAME('" + comp + "','" + subagecode + "') as AG_NAME";// from dual"; 
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                objSqlCommand.ExecuteNonQuery();
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

    }
}
