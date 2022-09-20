using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OracleClient;
namespace NewAdbooking.Report.classesoracle
{

    /// <summary>
    /// Summary description for reotype
    /// </summary>
    public class reotype : orclconnection
    {
        public reotype()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataSet bindagencyname(string compcode, string userid, string agency, string pubcenter)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("bindagencyforbooking", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("agency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objorclcmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubcenter", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubcenter;
                objorclcmd.Parameters.Add(prm4);

                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }



        public DataSet bindreportview(string compcode, string userid ,string username,string roleid,string status,string dateformat,string extra1,string extra2,string extra3,string extra4,string extra5)
        {
            OracleConnection objorclcon;
            OracleCommand objorclcmd;
            DataSet objds = new DataSet();
            objorclcon = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objorclcon.Open();
                objorclcmd = GetCommand("login_user_report ", ref objorclcon);
                objorclcmd.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objorclcmd.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pbranch", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objorclcmd.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pusername", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = username;
                objorclcmd.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("proleid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = roleid;
                objorclcmd.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pstatus", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = status;
                objorclcmd.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = dateformat;
                objorclcmd.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("pextra1", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = extra1;
                objorclcmd.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("pextra2", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = extra2;
                objorclcmd.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("pextra3", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = extra3;
                objorclcmd.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pextra4", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = extra4;
                objorclcmd.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("pextra5", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = extra5;
                objorclcmd.Parameters.Add(prm11);




                objorclcmd.Parameters.Add("p_accounts", OracleType.Cursor);
                objorclcmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objorclcmd;
                objorclDataAdapter.Fill(objds);
                return objds;

            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objorclcon.Close();

            }

        }




        public DataSet checkemail(string email, string at)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                string query = "select EMAIL_VALIDATION('" + email + "','" + at + "') as MESSAGE from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

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