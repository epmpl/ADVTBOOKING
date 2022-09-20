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
/// Summary description for chk_password
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{
    public class chk_password : orclconnection
    {
        public chk_password()
        {
            //
            // TODO: Add constructor logic here
            //          
        }
        public DataSet check_password(string username, string password, string oldpassword)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = new OracleCommand();
                objOraclecommand.Connection = objOracleConnection;
                objOraclecommand.CommandType = CommandType.Text;
                string query = " select password_check('" + password + "','" + username + "','" + oldpassword +"') as PASSWORD from dual";
                objOraclecommand.CommandText = query;
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

        public DataSet user_cngpass(string compcode, string userid, string dateformat, string extra1, string extra2)
        { 
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            { 
                con.Open();
                cmd = GetCommand("usr_change_password_alert", ref con);
               cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pdateformate", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = dateformat;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra3", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra4", OracleType.VarChar, 1000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra5", OracleType.VarChar, 1000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm8);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

               }
            catch(Exception ex)
            {
                throw (ex);
            }
            finally
                {
                    con.Close();
                }
        }

        public DataSet get_pass(string compCode, string userid, string unkno, string extra1, string extra2)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("get_password_attempt", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 1000);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compCode;
                cmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 1000);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                cmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("punk_no", OracleType.VarChar, 1000);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = unkno;
                cmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pextra1", OracleType.VarChar, 1000);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = extra1;
                cmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pextra2", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = extra2;
                cmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pextra3", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra4", OracleType.VarChar, 1000);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra5", OracleType.VarChar, 1000);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = System.DBNull.Value;
                cmd.Parameters.Add(prm8);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;


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
                con.Close();
            }
        }
        public DataSet get_seq()
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                cmd = GetCommand("get_attemp_seq", ref con);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("ptype_code", OracleType.Cursor);
                cmd.Parameters["ptype_code"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("ptype_code1", OracleType.Cursor);
                cmd.Parameters["ptype_code1"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("ptype_code2", OracleType.Cursor);
                cmd.Parameters["ptype_code2"].Direction = ParameterDirection.Output;

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
                con.Close();
            }
        }
        }
    }
