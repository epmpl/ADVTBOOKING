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
/// Summary description for Userpermission
/// </summary>
    public class Userpermission : orclconnection
    {
        public Userpermission()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet userchk(string compcode, string user)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkuserforper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = user;
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
        public DataSet savedata(string compcode, string userid, string schedule, string loguser, string permission_desc, string delflag, string keyboard, string keyboardtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("saveuserforper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("schedule", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = schedule;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("loguser", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = loguser;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("permission_desc", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = permission_desc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("del_flag", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = delflag;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm61 = new OracleParameter("keyboard_p", OracleType.VarChar);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = keyboard;
                objOraclecommand.Parameters.Add(prm61);

                OracleParameter prm7 = new OracleParameter("keyboardtype", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = keyboardtype;
                objOraclecommand.Parameters.Add(prm7);

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

        public DataSet save_perdetail(string user, string permission_desc, string from_osbal, string to_osbal, string no_oftimes, string period, string allow_flag, string loguser)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("saveuserfor_perdetail", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("usercode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = user;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("permission_desc", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = permission_desc;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("from_osbal", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = from_osbal;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("to_osbal", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = to_osbal;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("no_oftimes", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = no_oftimes;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("period", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = period;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("allow_flag", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = allow_flag;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("loguser", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = loguser;
                objOraclecommand.Parameters.Add(prm8);


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

        public DataSet execuser(string compcode, string userid, string schedule)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("execuserforper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("schedule", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = schedule;
                objOraclecommand.Parameters.Add(prm3);

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
        public DataSet deletedata(string compcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("deluserforper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

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
        public DataSet modifydata(string compcode, string user, string schedule)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateuserforper", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user1", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = user;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("schedule", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = schedule;
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
        public DataSet get_username(string userid)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            string ank = "";
            try
            {
                ank = "Select cir_get_login('" + userid + "') AS user_name from dual";
                cmd.CommandText = ank;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

            return ds;
        }

        public DataSet Get_Rolename(string userid)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            string ank = "";
            try
            {
                ank = "Select cir_get_login_role('" + userid + "') AS role_name from dual";
                cmd.CommandText = ank;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

            return ds;
        }

        public DataSet filluser_permission(string userid, string compcode, string login_userid, string per_desc)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("fill_userpermission", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("user_id", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("loginuserid", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = login_userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("per_desc", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (per_desc == "")
                    prm4.Value = System.DBNull.Value;
                else
                    prm4.Value = per_desc;
                objOraclecommand.Parameters.Add(prm4);

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

    }

   
}
