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
/// Summary description for RateMaster
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class Createuser:orclconnection
    {
        public Createuser()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getagency(string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_getAgencycode.login_getAgencycode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("userid1", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = userid;
                objOraclecommand.Parameters.Add(prm1);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


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
        public DataSet currency()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_getCurrencycode.login_getCurrencycode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts1"].Direction = ParameterDirection.Output;


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
        public DataSet retainer()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_getRetainername.login_getRetainername_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Curr_Name", SqlDbType.VarChar);
                //com.Parameters["@Curr_Name"].Value = currencyname;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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
        public DataSet bindCompany()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getCompName.getCompName_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                //com.Parameters.Add("@Curr_Name", SqlDbType.VarChar);
                //com.Parameters["@Curr_Name"].Value = currencyname;

                //com.Parameters.Add("@Curr_Code", SqlDbType.VarChar);
                //com.Parameters["@Curr_Code"].Value = currencycode;
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
        public DataSet usersave(string username, string pwdencry, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user, string compnamelist, string emailid, string discount, string filter, string rolename, string editlines, string firstname, string lastname, string status, string empcode, string acccode, string MACHINE_IP, string MACHINE_NAME, string MACHINE_MAC_ADDR, string executive, string getrate, string datestaus, string dateform,string createdby)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("loginInsert.loginInsert_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("password", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pwdencry;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm4 = new OracleParameter("userid1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("date_format", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = date_for;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("comp_name", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compname;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("com_code", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("curr_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = currname;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agencycode;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("retainer_code", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = retainername;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("USER", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = user;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("ADMIN1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = admin;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("comp_user", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = comp_user;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("compnamelist", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = compnamelist;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("emailid", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = emailid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("disc", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = discount;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("fil", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = filter;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("role", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = rolename;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("editlines", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = editlines;
                objOraclecommand.Parameters.Add(prm19);
              
                OracleParameter prm20 = new OracleParameter("firstname", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = firstname;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("lastname", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = lastname;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pstatus", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = status;
                objOraclecommand.Parameters.Add(prm22);


                OracleParameter prm50 = new OracleParameter("p_empcode", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = empcode;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm52 = new OracleParameter("p_MACHINE_IP", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = MACHINE_IP;
                objOraclecommand.Parameters.Add(prm52);



                OracleParameter prm53 = new OracleParameter("p_MACHINE_NAME", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = MACHINE_NAME;
                objOraclecommand.Parameters.Add(prm53);


                OracleParameter prm54 = new OracleParameter("p_MACHINE_MAC_ADDR", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = MACHINE_MAC_ADDR;
                objOraclecommand.Parameters.Add(prm54);


                OracleParameter prm55 = new OracleParameter("p_executive", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = executive;
                objOraclecommand.Parameters.Add(prm55);

                OracleParameter prm23 = new OracleParameter("pgetrate", OracleType.VarChar, 50);
                prm23.Direction = ParameterDirection.Input;
                prm23.Value = getrate;
                objOraclecommand.Parameters.Add(prm23);


                OracleParameter prm51 = new OracleParameter("p_acccode", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = acccode;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm56 = new OracleParameter("p_mobileno", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm56);

                OracleParameter prm57 = new OracleParameter("p_mail", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm57);

                OracleParameter prm571 = new OracleParameter("p_user_type", OracleType.VarChar);
                prm571.Direction = ParameterDirection.Input;
                prm571.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm571);

                OracleParameter prm571e = new OracleParameter("pdatestaus", OracleType.VarChar);
                prm571e.Direction = ParameterDirection.Input;
                if (datestaus=="")
                {
                    prm571e.Value = System.DBNull.Value;
                }
                else{
               
                if (dateform == "dd/mm/yyyy")
                {
                    string[] arr = datestaus.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datestaus = mm + "/" + dd + "/" + yy;


                }

                prm571e.Value = Convert.ToDateTime(datestaus).ToString("dd-MMMM-yyyy");
                }
               objOraclecommand.Parameters.Add(prm571e);

               OracleParameter prm571k = new OracleParameter("pcreatedby", OracleType.VarChar);
               prm571k.Direction = ParameterDirection.Input;
               prm571k.Value = createdby;
               objOraclecommand.Parameters.Add(prm571k);

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

        public DataSet chkuserid(string userid, string username, string branchname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand(" userloginudefine.userloginudefine_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("branchname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchname;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                
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

        public DataSet genuserid(string str, string branchname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("userloginauto.userloginauto_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("str", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = str;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                     prm2.Value  = str.Substring(0, 2);
                else
                    prm2.Value = str;
               
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("branchname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = branchname;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;
               


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

        public DataSet userexecute(string username, string userid, string compcode, string admin)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Loginexecute.Loginexecute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("com_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("admin1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = admin;
                objOraclecommand.Parameters.Add(prm4);


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
        public DataSet userdelete(string userid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("loginDelete.loginDelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                
                OracleParameter prm2 = new OracleParameter("userid1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);
                
                
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
        public DataSet usermodify(string username, string pwdencry, string userid, string date_for, string compname, string compcode, string currname, string retainername, string agencycode, string user, string admin, string comp_user, string companylist, string emailid, string discount, string filter, string rolename, string editlines, string firstname, string lastname, string status, string getrate, string datestatus, string dateform)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("loginModify.loginModify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("password", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pwdencry;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm4 = new OracleParameter("userid1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("date_format", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = date_for;
                objOraclecommand.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("comp_name", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compname;
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = compcode;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("curr_code", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = currname;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("agencycode", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = agencycode;
                objOraclecommand.Parameters.Add(prm9);


                OracleParameter prm10 = new OracleParameter("retainer_code", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = retainername;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("USER", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = user;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("ADMIN1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = admin;
                objOraclecommand.Parameters.Add(prm12);


                OracleParameter prm13 = new OracleParameter("comp_user", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = comp_user;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("companylist", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = companylist;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("emailid", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = emailid;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("disc", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = discount;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("fil", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = filter;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("prole", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = rolename;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("editlines", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = editlines;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("fname", OracleType.VarChar, 50);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = firstname;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("lname", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = lastname;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pstatus", OracleType.VarChar, 50);
                prm22.Direction = ParameterDirection.Input;
                prm22.Value = status;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm50 = new OracleParameter("p_empcode", OracleType.VarChar);
                prm50.Direction = ParameterDirection.Input;
                prm50.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm50);

                OracleParameter prm56 = new OracleParameter("p_mobileno", OracleType.VarChar);
                prm56.Direction = ParameterDirection.Input;
                prm56.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm56);



                OracleParameter prm52 = new OracleParameter("p_MACHINE_IP", OracleType.VarChar);
                prm52.Direction = ParameterDirection.Input;
                prm52.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm52);


                OracleParameter prm53 = new OracleParameter("p_MACHINE_NAME", OracleType.VarChar);
                prm53.Direction = ParameterDirection.Input;
                prm53.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm53);


                OracleParameter prm54 = new OracleParameter("p_MACHINE_MAC_ADDR", OracleType.VarChar);
                prm54.Direction = ParameterDirection.Input;
                prm54.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm54);



                OracleParameter prm55 = new OracleParameter("p_executive", OracleType.VarChar);
                prm55.Direction = ParameterDirection.Input;
                prm55.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm55);


                OracleParameter prm553 = new OracleParameter("pgetrate", OracleType.VarChar);
                prm553.Direction = ParameterDirection.Input;
                prm553.Value = getrate;
                objOraclecommand.Parameters.Add(prm553);





                OracleParameter prm51 = new OracleParameter("p_acccode", OracleType.VarChar);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm51);

                OracleParameter prm57 = new OracleParameter("p_mail", OracleType.VarChar);
                prm57.Direction = ParameterDirection.Input;
                prm57.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm57);

           

                OracleParameter prm573 = new OracleParameter("p_usertype", OracleType.VarChar);
                prm573.Direction = ParameterDirection.Input;
                prm573.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm573);



                OracleParameter prm573s = new OracleParameter("pdatestaus", OracleType.VarChar);
                prm573s.Direction = ParameterDirection.Input;
                if (datestatus=="")
                {
                    prm573s.Value = System.DBNull.Value;
                }
                else{
                
                if (dateform == "dd/mm/yyyy")
                {
                    string[] arr = datestatus.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    datestatus = mm + "/" + dd + "/" + yy;


                }
                     prm573s.Value = Convert.ToDateTime(datestatus).ToString("dd-MMMM-yyyy");
                }


                objOraclecommand.Parameters.Add(prm573s);


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

        public DataSet getbranch()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("login_getbranchname.login_getbranchname_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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


        public DataSet userexecute(string mail)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("mailchk.mailchk_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("emailid", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = mail;
                objOraclecommand.Parameters.Add(prm1);

                

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

        public DataSet usersavebranch(string username, string branchcode, string userflag, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("loginInsertBranchpermission", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branchcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm4 = new OracleParameter("userflag", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userflag;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

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

        public DataSet userupdatebranch(string username, string branchcode, string userflag, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("loginUpdateBranchpermission", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("username", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = username;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("branchcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = branchcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm4 = new OracleParameter("userflag", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userflag;
                objOraclecommand.Parameters.Add(prm4);


                OracleParameter prm5 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = compcode;
                objOraclecommand.Parameters.Add(prm5);

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

        public DataSet executebranch(string userid, string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("brnchpermissionexe", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("com_code", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = compcode;
                objOraclecommand.Parameters.Add(prm3);

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

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

        public DataSet bindempcode(string compcode, string empname)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("emp_code_bind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pname", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = empname;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("pextra3", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pextra4", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm16);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_accounts3", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts3"].Direction = ParameterDirection.Output;
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





        public DataSet bindcashier(string compcode)
        {
             OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("chkprefren", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm11 = new OracleParameter("Pcompcode", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);



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



        public DataSet bindcashier_callback(string compcode, string accty, string accname, string userid, string extra1, string extra2)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();

                objOraclecommand = GetCommand("fa_account_mast_typewise", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("paccty", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = accty;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("paccname", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = accname;
                objOraclecommand.Parameters.Add(prm3);


                OracleParameter prm4 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = userid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra1", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra2", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm6);


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

        public DataSet get_agency_name(string comp, string subagecode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                string codes = "";

                codes = "select ad_AGENAME('" + comp + "', '" + subagecode + "') as AG_NAME  from dual";
                cmd.CommandText = codes;
                cmd.Connection = con;
                con.Open();
                da.SelectCommand = cmd;
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


    }

}