using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for status_master
/// </summary>

namespace NewAdbooking.Classes
{
    public class status_master : connection
    {
        public status_master()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet chkcode(string statuscode, string compcode, string statusname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("check_status_code", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@statuscode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statuscode"].Value = statuscode;

                objSqlCommand.Parameters.Add("@statusname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusname"].Value = statusname;


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
        public DataSet executequery(string statuscode, string statusname, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("execute_status_master", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@statuscode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statuscode"].Value = statuscode;

                objSqlCommand.Parameters.Add("@statusname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusname"].Value = statusname;

                //objSqlCommand.Parameters.Add("@statusalias", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@statusalias"].Value = statusalias;

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

        public DataSet autocode(string str,string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("status_autocode", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                //cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@str", SqlDbType.VarChar);
                cmd.Parameters["@str"].Value = str;

                cmd.Parameters.Add("@cod", SqlDbType.VarChar);
                cmd.Parameters["@cod"].Value = str;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;


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

        public DataSet insert_status_master(string statuscode, string statusname, string statusalias, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insert_status_master", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@statuscode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statuscode"].Value = statuscode;

                objSqlCommand.Parameters.Add("@statusname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusname"].Value = statusname;

                objSqlCommand.Parameters.Add("@statusalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusalias"].Value = statusalias;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



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

        public DataSet update_status_master(string statuscode, string statusname, string statusalias, string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("update_status_master", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@statuscode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statuscode"].Value = statuscode;

                objSqlCommand.Parameters.Add("@statusname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusname"].Value = statusname;

                objSqlCommand.Parameters.Add("@statusalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@statusalias"].Value = statusalias;

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
        public DataSet delete_status_master(string statuscode, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            con = GetConnection();

            try
            {
                con.Open();
                cmd = GetCommand("delete_status_master", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@statuscode", SqlDbType.VarChar);
                cmd.Parameters["@statuscode"].Value = statuscode;

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
