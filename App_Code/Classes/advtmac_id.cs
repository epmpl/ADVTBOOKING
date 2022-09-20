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
using System.Data.SqlClient;
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for advtmac_id
    /// </summary>
    public class advtmac_id : connection
    {
        public advtmac_id()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static object GetStringOrDBNull(string value)
        {
            object o;
            if (string.IsNullOrEmpty(value))
            {
                o = DBNull.Value;
            }
            else
            {
                o = value;
            }
            return o;
        }
        public DataSet getUser(string QBC)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("websp_getUser", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                cmd.Parameters.Add("@QBC", SqlDbType.VarChar).Value = QBC;
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                con.Close();

            }
        }
        public DataSet getfirstlastname(string compcode, string usercode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("firstlastname", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                cmd.Parameters.Add("@pcom_code", SqlDbType.VarChar).Value = compcode;
                cmd.Parameters.Add("@puserid", SqlDbType.VarChar).Value = GetStringOrDBNull(usercode);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                con.Close();

            }
        }
        public DataSet savedata(string compcode, string usercode, string machinename, string machineip, string macip, string remark, string location, string username, string extra3)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("FA_MACHINE_SECURITY_SAVE_NEW", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                cmd.Parameters.Add("@pcomp_code", SqlDbType.VarChar).Value = compcode;
                cmd.Parameters.Add("@puser_id", SqlDbType.VarChar).Value = GetStringOrDBNull(usercode);
                cmd.Parameters.Add("@pmachine_name", SqlDbType.VarChar).Value = GetStringOrDBNull(machinename);
                cmd.Parameters.Add("@pmachine_ip", SqlDbType.VarChar).Value = GetStringOrDBNull(machineip);
                cmd.Parameters.Add("@pmachine_mac_addr", SqlDbType.VarChar).Value = GetStringOrDBNull(macip);
                cmd.Parameters.Add("@premarks", SqlDbType.VarChar).Value = GetStringOrDBNull(remark);
                cmd.Parameters.Add("@plocation", SqlDbType.VarChar).Value = GetStringOrDBNull(location);
                cmd.Parameters.Add("@pdateformat", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = GetStringOrDBNull(username);
                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra3", SqlDbType.VarChar).Value = GetStringOrDBNull(extra3);   // I FOR insert or U FOR update
                cmd.Parameters.Add("@pextra4", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra5", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra6", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra7", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra8", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra9", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra10",SqlDbType.VarChar).Value = System.DBNull.Value;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                con.Close();

            }

        }
        
        public DataSet executedata(string compcode, string usercode, string machinename, string machineip, string macip, string remark, string location)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("FA_MACHINE_SECURITY_EXECUTE", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                cmd.Parameters.Add("@pcomp_code", SqlDbType.VarChar).Value = compcode;
                cmd.Parameters.Add("@puser_id", SqlDbType.VarChar).Value = GetStringOrDBNull(usercode);
                cmd.Parameters.Add("@pmachine_name", SqlDbType.VarChar).Value = GetStringOrDBNull(machinename);
                cmd.Parameters.Add("@pmachine_ip", SqlDbType.VarChar).Value = GetStringOrDBNull(machineip);
                cmd.Parameters.Add("@pmachine_mac_addr", SqlDbType.VarChar).Value = GetStringOrDBNull(macip);
                cmd.Parameters.Add("@premarks", SqlDbType.VarChar).Value = GetStringOrDBNull(remark);
                cmd.Parameters.Add("@plocation", SqlDbType.VarChar).Value = GetStringOrDBNull(location);
                cmd.Parameters.Add("@pdateformat", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra3", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra4", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra5", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra6", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra7", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra8", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra9", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra10", SqlDbType.VarChar).Value = System.DBNull.Value;

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                con.Close();

            }

        }
        public DataSet datadelete(string compcode,string userid, string machinename, string machineip, string macip)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd = GetCommand("FA_MACHINE_SECURITY_DELETE", ref con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                cmd.Parameters.Add("@pcomp_code", SqlDbType.VarChar).Value = compcode;
                cmd.Parameters.Add("@puser_id", SqlDbType.VarChar).Value = GetStringOrDBNull(userid);
                cmd.Parameters.Add("@pmachine_name", SqlDbType.VarChar).Value = GetStringOrDBNull(machinename);
                cmd.Parameters.Add("@pmachine_ip", SqlDbType.VarChar).Value = GetStringOrDBNull(machineip);
                cmd.Parameters.Add("@pmachine_mac_addr", SqlDbType.VarChar).Value = GetStringOrDBNull(macip);
                cmd.Parameters.Add("@pdateformat", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = System.DBNull.Value;
                cmd.Parameters.Add("@pextra3", SqlDbType.VarChar).Value = System.DBNull.Value;
               
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                con.Close();

            }

        }
        

    }
}