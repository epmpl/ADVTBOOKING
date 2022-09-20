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


/// <summary>
/// Summary description for ROapproval
/// </summary>
/// 
namespace NewAdbooking.Classes
{



    public class ROapproval : connection
    {


        public ROapproval()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet addvalue(string agency, string client, string executive, string compcode, string userid, string fromdate, string todate, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getapprovalRo_Mobile", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@executive", SqlDbType.VarChar);
                objSqlCommand.Parameters["@executive"].Value = executive;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@vusername", SqlDbType.VarChar);
                objSqlCommand.Parameters["@vusername"].Value = userid;

                objSqlCommand.Parameters.Add("@varFromDate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@varFromDate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@varFromDate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@varToDate", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    objSqlCommand.Parameters["@varToDate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@varToDate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (SqlException objException)
            {
                throw (objException);
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
