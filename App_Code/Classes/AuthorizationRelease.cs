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
/// Summary description for Ad_Barter
/// </summary>
namespace NewAdbooking.Classes
{

    public class AuthorizationRelease : connection
    {
        public AuthorizationRelease()
        {
            //
            // TODO: Add constructor logic here
            //
        }
/////=====================Start Procedure=================================//
        public DataSet findrecord(string userid, string compcode, string agency, string executive, string client, string fdate, string tdate, string dateformat, string cioid, string flag, string basedon, string branch,string orderby)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getapprovalRo_web", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@vusername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vusername"].Value = userid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = executive;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@varFromDate", SqlDbType.VarChar);
                if (fdate == "" || fdate == null)
                {
                    objSqlCommand.Parameters["@varFromDate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@varFromDate"].Value = fdate;
                }

                objSqlCommand.Parameters.Add("@varToDate", SqlDbType.VarChar);
                if (tdate == "" || tdate == null)
                {
                    objSqlCommand.Parameters["@varToDate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@varToDate"].Value = tdate;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@flag", SqlDbType.VarChar);
                objSqlCommand.Parameters["@flag"].Value = flag;

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@pdate_based_on", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdate_based_on"].Value = basedon;

                objSqlCommand.Parameters.Add("@porder", SqlDbType.VarChar);
                objSqlCommand.Parameters["@porder"].Value = orderby;


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
        public DataSet savedata(string remarks, string userid, string appstatus, string insertid, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertRemarks_web", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@remarks"].Value = remarks;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@appstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@appstatus"].Value = appstatus;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.VarChar);
                if (insertid == "" || insertid == null)
                    objSqlCommand.Parameters["@insertid"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@insertid"].Value = insertid;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

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
        public DataSet fetchMailId(string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchMailId_ro", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bkid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bkid"].Value = cioid;

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

        public DataSet bindrep(string center, string userid, string branch, string compcode, string agencycode, string client, string executive, string dateformat, string fdate, string todate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rpt_approvalro", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pcentercode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcentercode"].Value = center;

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfrom_date"].Value = fdate;


                objSqlCommand.Parameters.Add("@pto_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pto_date"].Value = todate;


                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agencycode == "" || agencycode == null)
                {
                    objSqlCommand.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agency"].Value = agencycode;
                }

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                if (executive == "" || executive == null)
                {
                    objSqlCommand.Parameters["@executive"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@executive"].Value = executive;

                }


                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "" || client == null)
                {
                    objSqlCommand.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@client"].Value = client;
                }
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
