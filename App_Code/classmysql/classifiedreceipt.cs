using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace NewAdbooking.classmysql
{
    /// <summary>
    /// Summary description for classifiedreceipt
    /// </summary>
    public class classifiedreceipt : connection
    {
        public classifiedreceipt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet selectreceipt(string cio_booking_id, string dateformat)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Receiptnew2", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("cio_booking_id1", MySqlDbType.VarChar);
                objSqlCommand.Parameters["cio_booking_id1"].Value = cio_booking_id;

                objSqlCommand.Parameters.Add("dateformat", MySqlDbType.VarChar);
                objSqlCommand.Parameters["dateformat"].Value = dateformat;

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


        public DataSet selectcenterlogo(string comp_code, string centercode)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GET_PUBCENT_LOGO", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("pcompcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["pcompcode"].Value = comp_code;

                objSqlCommand.Parameters.Add("punitcode", MySqlDbType.VarChar);
                objSqlCommand.Parameters["punitcode"].Value = centercode;

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

        public DataSet clsreceiptmatter(string comp_code, string booking_id)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_clsmatter_websp_clsmatter_p_multi", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("p_comp_cd", MySqlDbType.VarChar);
                objSqlCommand.Parameters["p_comp_cd"].Value = comp_code;

                objSqlCommand.Parameters.Add("booking_id", MySqlDbType.VarChar);
                objSqlCommand.Parameters["booking_id"].Value = booking_id;

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

    }
}