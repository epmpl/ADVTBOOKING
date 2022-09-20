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
    /// Summary description for Help_Page
    /// </summary>
    public class Help_Page:connection
    {
        public Help_Page()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet getPubCenter()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_pubcenter", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                //objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlDataAdapter = new SqlDataAdapter();
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

        public DataSet getQBC(string pubcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_QBC", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@pubcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcode"].Value = pubcode;
                objSqlDataAdapter = new SqlDataAdapter();
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
        public DataSet getCompany()
        {
            SqlConnection con;
            con = GetConnection();
            SqlCommand cmd = new SqlCommand();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                string query = "select * from comp_mst";
                cmd.CommandText = query;
                cmd.Connection = con;
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

        public DataSet mis_health_chk(string compcode, string unit, string branch, string difftype, string datformat, string extra1, string extra2, string differenceofvalue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("mis_health_chk_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;


                objSqlCommand.Parameters.Add("@punit_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@punit_code"].Value = unit;

                objSqlCommand.Parameters.Add("@pbran_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbran_code"].Value = branch;

                objSqlCommand.Parameters.Add("@pdiff_type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdiff_type"].Value = difftype;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = datformat;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = differenceofvalue;

                objSqlCommand.CommandTimeout = 0;
                objSqlDataAdapter = new SqlDataAdapter();
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
