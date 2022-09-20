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


/// <summary>
/// Summary description for stoptime
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class stoptime1 : connection
    {
        public stoptime1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet saveaddeduct(string compcode, string unitcode, string days, string hour, string createdby,string seq, string extra1, string extra2, string extra3, string extra4)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {

                con.Open();
                cmd = GetCommand("AD_STOPTIME_INSERT", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pcompcode", SqlDbType.VarChar).Value = compcode;
                cmd.Parameters.Add("@punitcode", SqlDbType.VarChar).Value = unitcode;
                cmd.Parameters.Add("@pdays", SqlDbType.VarChar).Value = days;
                cmd.Parameters.Add("@ptime", SqlDbType.VarChar).Value = hour;
                cmd.Parameters.Add("@pcreatedby", SqlDbType.VarChar).Value = createdby;
                cmd.Parameters.Add("@pseqno", SqlDbType.VarChar).Value = seq;
                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = extra1;
                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = extra2;
                cmd.Parameters.Add("@pextra3", SqlDbType.VarChar).Value = extra3;
                cmd.Parameters.Add("@pextra4", SqlDbType.VarChar).Value = extra4;                 
                cmd.ExecuteNonQuery();
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


        public DataSet execdata(string compcode, string unitcode, string days, string hour, string createdby, string seq, string extra1, string extra2, string extra3, string extra4)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_STOPTIME_EXEC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar).Value = compcode;
                objSqlCommand.Parameters.Add("@punitcode", SqlDbType.VarChar).Value = unitcode;
                objSqlCommand.Parameters.Add("@pdays", SqlDbType.VarChar).Value = days;
                objSqlCommand.Parameters.Add("@ptime", SqlDbType.VarChar).Value = hour;
                objSqlCommand.Parameters.Add("@pcreatedby", SqlDbType.VarChar).Value = createdby;
                objSqlCommand.Parameters.Add("@pseq", SqlDbType.VarChar).Value = seq;
                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = extra1;
                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = extra2;
                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar).Value = extra3;
                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar).Value = extra4;    
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



        public DataSet autoseq()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("AD_STOPTIME_AUTOGEN", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
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


        public DataSet exec_modify(string compcode, string unitcode, string days, string hour, string createdby, string seq, string extra1, string extra2, string extra3, string extra4)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {

                con.Open();
                cmd = GetCommand("AD_STOPTIME_MODIFY", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pcompcode", SqlDbType.VarChar).Value = compcode;
                cmd.Parameters.Add("@punitcode", SqlDbType.VarChar).Value = unitcode;
                cmd.Parameters.Add("@pdays", SqlDbType.VarChar).Value = days;
                cmd.Parameters.Add("@ptime", SqlDbType.VarChar).Value = hour;
                cmd.Parameters.Add("@pcreatedby", SqlDbType.VarChar).Value = createdby;
                cmd.Parameters.Add("@pseq", SqlDbType.VarChar).Value = seq;
                cmd.Parameters.Add("@pextra1", SqlDbType.VarChar).Value = extra1;
                cmd.Parameters.Add("@pextra2", SqlDbType.VarChar).Value = extra2;
                cmd.Parameters.Add("@pextra3", SqlDbType.VarChar).Value = extra3;
                cmd.Parameters.Add("@pextra4", SqlDbType.VarChar).Value = extra4;
                cmd.ExecuteNonQuery();
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
