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
namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for deletion
    /// </summary>
    public class deletion:connection
    {
        public deletion()
        {
            //
            // TODO: Add constructor logic here
            //
        }

     

        public DataSet statusdelete(string txtformdate, string txttodate, string status)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("statusdelete", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("fdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["fdate"].Value = Convert.ToDateTime(txtformdate).ToString("yyyy-MM-dd");


                objSqlCommand.Parameters.Add("tdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["tdate"].Value = Convert.ToDateTime(txttodate).ToString("yyyy-MM-dd");


                objSqlCommand.Parameters.Add("status1", SqlDbType.VarChar);
                if (status == "Confim")
                {
                    objSqlCommand.Parameters["status1"].Value = 1;
                }
                else
                {
                    objSqlCommand.Parameters["status1"].Value = 2;
                }


                objSqlDataAdapter = new SqlDataAdapter();
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


        public DataSet chkdate1(string fromdate, string todate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkdate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("fdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["fdate"].Value = Convert.ToDateTime(fromdate).ToString("yyyy-MM-dd");


                objSqlCommand.Parameters.Add("tdate", SqlDbType.DateTime);
                objSqlCommand.Parameters["tdate"].Value = Convert.ToDateTime(todate).ToString("yyyy-MM-dd");



                objSqlDataAdapter = new SqlDataAdapter();
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