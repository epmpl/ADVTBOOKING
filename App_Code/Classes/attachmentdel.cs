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
    /// Summary description for attachmentdel
    /// </summary>
    public class attachmentdel : connection
    {
        public attachmentdel()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet selectval(string compcode, string reptno)
        {
             SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try

           
            {
             
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Attachment_select11", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

            

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

            

                objSqlCommand.Parameters.Add("@pcompno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompno"].Value = reptno;



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
                CloseConnection(ref objSqlConnection);

            }
        }


        public DataSet receiptdel(string compcode, string reptno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
               
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Attachment_delete111", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                


                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;


       


                objSqlCommand.Parameters.Add("@pcompid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompid"].Value = reptno;



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
                CloseConnection(ref objSqlConnection);

            }
        }
    }
}