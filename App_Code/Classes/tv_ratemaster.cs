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
using System.Data.Sql;
using System.Data.SqlClient;
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for tv_ratemaster
    /// </summary>
    /// 
    public class tv_ratemaster:connection
    {
        public tv_ratemaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       

        public DataSet btbbind(string compcode, string btbdes, string extra1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("tv_bindbtbcode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pbtbdesc", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbtbdesc"].Value = btbdes;

                objSqlCommand.Parameters.Add("@extra", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra"].Value = extra1;

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

        public DataSet get_btb_name(string compcode, string id)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "Select dbo.tv_get_btb_name('" + compcode + "','" + id + "') AS REASON";
                //  string query = "select  dbo.CRM_GET_CENTER_NAME('" + locid + "','" + cid + "')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return (objDataSet);


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

        public DataSet get_prog_name(string compcode, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("TV_PROGRAMME_BIND", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = extra1;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = extra2;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = extra3;

                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = extra4;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = extra5;

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


        public DataSet get_progname(string compcode, string id)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "Select dbo.tv_get_prog_name('" + compcode + "','" + id + "') AS REASON";
                //  string query = "select  dbo.CRM_GET_CENTER_NAME('" + locid + "','" + cid + "')";
                objSqlCommand.CommandText = query;
                objSqlCommand.Connection = objSqlConnection;
                //cmd.ExecuteNonQuery();

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return (objDataSet);


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