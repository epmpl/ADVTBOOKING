using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewAdbooking.Classes
{
    public class fmg_transaction : connection
    {
        public fmg_transaction()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet gbind(string compcode, string todate, string fromdate, string bookingid, string client, string date, string agency, string insertid, string padtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fmgdatabid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@pubdate", SqlDbType.VarChar);
                //if (dateformat == "dd/mm/yyyy")
                //{

                //    if (pubdate.IndexOf('-') < 0)
                //    {
                //        string[] arr = pubdate.Split('/');
                //        string dd = arr[0];
                //        string mm = arr[1];
                //        string yy = arr[2];
                //        pubdate = mm + "/" + dd + "/" + yy;

                //    }

                //}
                //else if (dateformat == "yyyy/mm/dd")
                //{
                //    string[] arr = pubdate.Split('/');
                //    string dd = arr[2];
                //    string mm = arr[1];
                 //    string yy = arr[0];
                //    pubdate = mm + "/" + dd + "/" + yy;
                //}
                //objSqlCommand.Parameters["@pubdate"].Value = pubdate;

                objSqlCommand.Parameters.Add("@todate", SqlDbType.VarChar);
                if (todate != "")
                {
                    if (date == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    else if (date == "yyyy/mm/dd")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@todate"].Value = todate;
                }
                else
                {
                    objSqlCommand.Parameters["@todate"].Value = System.DBNull.Value;
                }

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    if (date == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (date == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
                }
                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertid"].Value = insertid;

                objSqlCommand.Parameters.Add("@p_adtye", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_adtye"].Value = padtype;

                objSqlCommand.Parameters.Add("@extra", SqlDbType.VarChar);
                objSqlCommand.Parameters["@extra"].Value = System.DBNull.Value;

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