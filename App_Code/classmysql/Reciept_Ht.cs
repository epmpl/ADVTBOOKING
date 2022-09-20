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

/// <summary>
/// Summary description for Reciept_Ht
/// </summary>
namespace NewAdbooking.classmysql
{
    public class Reciept_Ht:connection
    {
        public Reciept_Ht()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindreceiptdata(string compcode, string booking_id)
        {
            MySqlConnection objSqlConnection;
            MySqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            MySqlDataAdapter objSqlDataAdapter = new MySqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ht_receipt_p", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("comp_code", MySqlDbType.VarChar);
                objSqlCommand.Parameters["comp_code"].Value = compcode;

                objSqlCommand.Parameters.Add("receipt_no", MySqlDbType.VarChar);
                objSqlCommand.Parameters["receipt_no"].Value = booking_id;


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
