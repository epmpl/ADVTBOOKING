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
    /// Summary description for transferreport
    /// </summary>
    public class transferreport:connection
    {
        public transferreport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet griddisplay(string fromdate, string todate, string cid, string ascdesc)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("report_booking_confirm", ref objmysqlconnection);
                //objmysqlcommand = GetCommand("report_test", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");
             
                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = null;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = "1";

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
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }


        public DataSet gridview(string fromdate, string todate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            objmysqlconnection = GetConnection();
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("report_booking_confirm", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                //objmysqlcommand.Parameters.Add("compcode", MySqlDbType.VarChar);
                //objmysqlcommand.Parameters["compcode"].Value = compcode;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.DateTime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("status1", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["status1"].Value = null;

                objmysqlcommand.Parameters.Add("flag", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["flag"].Value = "1";

                objmysqlcommand.Parameters.Add("userid", MySqlDbType.VarChar);
                objmysqlcommand.Parameters["userid"].Value = "0";

                objmysqlDataAdapter.SelectCommand = objmysqlcommand;
                objmysqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objmysqlconnection);
            }
        }

    }
}