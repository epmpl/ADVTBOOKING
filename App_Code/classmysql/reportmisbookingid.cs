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
    /// Summary description for reportmisbookingid
    /// </summary>
    public class reportmisbookingid : connection
    {
        public reportmisbookingid()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindbookingid(string fromDate, string toDate)
        {
            MySqlConnection objmysqlconnection;
            MySqlCommand objmysqlcommand;
            MySqlDataAdapter objmysqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            objmysqlconnection = GetConnection();

            try
            {
                objmysqlconnection.Open();
                objmysqlcommand = GetCommand("getMissingId", ref objmysqlconnection);
                //objmysqlcommand = GetCommand("report_test", ref objmysqlconnection);
                objmysqlcommand.CommandType = CommandType.StoredProcedure;

                objmysqlcommand.Parameters.Add("fromdate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["fromdate"].Value = Convert.ToDateTime(fromDate).ToString("yyyy-MM-dd");

                objmysqlcommand.Parameters.Add("todate", MySqlDbType.Datetime);
                objmysqlcommand.Parameters["todate"].Value = Convert.ToDateTime(toDate).ToString("yyyy-MM-dd");

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