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
using System.Data.SqlClient;
namespace NewAdbooking.Report.Classes
{
    /// <summary>
    /// Summary description for reporttype
    /// </summary>
    public class reporttype : connection
    {
        public reporttype()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet bindreportview(string compcode, string userid, string username, string roleid, string status, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("login_user_report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcomp_code"].Value = compcode;



                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = userid;

                objSqlCommand.Parameters.Add("@pusername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pusername"].Value = username;

                objSqlCommand.Parameters.Add("@proleid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@proleid"].Value = roleid;

                objSqlCommand.Parameters.Add("@pstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pstatus"].Value = status;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

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



        public DataSet checkemail(string email, string at)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                string query = "Select dbo.EMAIL_VALIDATION('" + email + "','" + at + "') as MESSAGE";
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