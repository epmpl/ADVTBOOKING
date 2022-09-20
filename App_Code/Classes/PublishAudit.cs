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


/// <summary>
/// Summary description for PublishAudit
/// </summary>
namespace NewAdbooking.Classes
{
    public class PublishAudit : connection
    {
        public PublishAudit()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindgrid(string comcode, string dateformat, string tilldate, string fromdate, string publication, string adtype, string branch)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

      

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpublishert", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = comcode;

                objSqlCommand.Parameters.Add("@date1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@date1"].Value = dateformat;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] tilldatearr = tilldate.Split('/');
                    string dd1 = tilldatearr[0].ToString();
                    string mm1 = tilldatearr[1].ToString();
                    string yy1 = tilldatearr[2].ToString();
                    tilldate = mm1 + "/" + dd1 + "/" + yy1;
                }
                objSqlCommand.Parameters["@todate"].Value = tilldate;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] fromdatearr = fromdate.Split('/');
                    string dd1 = fromdatearr[0].ToString();
                    string mm1 = fromdatearr[1].ToString();
                    string yy1 = fromdatearr[2].ToString();
                    fromdate = mm1 + "/" + dd1 + "/" + yy1;
                }
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@branch1", SqlDbType.VarChar);
                String BRANCHNAME = branch;
                if (branch == "Select Branch" || branch == "" || branch == "0")
                {
                    objSqlCommand.Parameters["@branch1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@branch1"].Value = branch;
                }
                //objSqlCommand.Parameters["@branch1"].Value = branch;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

                objSqlCommand.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication == "Select Center" || publication == "" || publication == "0")
                {
                   objSqlCommand.Parameters["@publication"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@publication"].Value = publication;
                }
                //objSqlCommand.Parameters["@publication"].Value = publication;



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

        public DataSet update(string insert_id)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

      

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updateStatus2", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@insert_id1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_id1"].Value = insert_id;

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
