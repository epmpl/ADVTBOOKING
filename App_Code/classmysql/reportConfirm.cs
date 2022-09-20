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
    /// Summary description for reportConfirm
    /// </summary>
    public class reportConfirm:connection
    {
        public reportConfirm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindGrid(string fromDate, string toDate, string status, string cid, string ascdesc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("report_booking_confirm",ref objmysqlconnection);
                //objmysqlcommand = GetCommand("report_test", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = status;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = "0";

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = "0";

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = cid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = ascdesc;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

        public DataSet bindGridUser(string fromDate, string toDate,string userid,string cid,string ascdesc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("report_booking_confirm", ref objmysqlconnection);
                //objmysqlcommand = GetCommand("report_test", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = "0";//This is now use for this;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = "2";

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = userid;//

                objmysqlcommand.Parameters.Add("descid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["descid"].Value = cid;

                objmysqlcommand.Parameters.Add("ascdesc", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["ascdesc"].Value = ascdesc;

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

    }
}
