using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;

/// <summary>
/// Summary description for rateauditlog
/// </summary>
namespace NewAdbooking.Classes
{
    public class rateauditlog : connection
    {
        public rateauditlog()
        {
            //
            // TODO: Add constructor logic here
            //
        }






        public DataSet bindbooking(string compcode, string bokingid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("binbookingid", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@p_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@p_bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_bookingid"].Value = bokingid;

                

            
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

        public DataSet bindrep(string fromdate, string todate, string compcode, string bookingcenter, string branch, string dateformate, string adtype, string uom, string agency, string client, string bookingid, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rate_audit_logreport", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = mm + "/" + dd + "/" + yy;
                objSqlCommand.Parameters["@pfromdate"].Value = Convert.ToDateTime(fromdate);

                objSqlCommand.Parameters.Add("@pdateto", SqlDbType.VarChar);
                string[] arr1 = todate.Split('/');
                string dd1 = arr1[0];
                string mm1= arr1[1];
                string yy1 = arr1[2];
                todate = mm1 + "/" + dd1 + "/" + yy1;
                objSqlCommand.Parameters["@pdateto"].Value = Convert.ToDateTime(todate); ;

                objSqlCommand.Parameters.Add("@ppub_cent", SqlDbType.VarChar);
                if (bookingcenter == "" || bookingcenter == "0")
                {
                    objSqlCommand.Parameters["@ppub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppub_cent"].Value = bookingcenter;
                }
                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);

                if (branch == "" || branch == "0")
                {
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pbranch"].Value = branch;
                }
                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformate;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@padtyp", SqlDbType.VarChar);
                if (adtype == "" || adtype == "0")
                {
                    objSqlCommand.Parameters["@padtyp"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@padtyp"].Value = adtype;
                }
                objSqlCommand.Parameters.Add("@puom", SqlDbType.VarChar);

                if (uom == "" || uom == "0")
                {
                    objSqlCommand.Parameters["@puom"].Value =System.DBNull.Value;
                }

                else
                {
                    objSqlCommand.Parameters["@puom"].Value = uom;
                }
                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agency;

                objSqlCommand.Parameters.Add("@pclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclient"].Value = client;

                objSqlCommand.Parameters.Add("@pbkid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbkid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;



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

        public DataSet binddaily(string fromdate, string todate, string compcode, string pubcent, string dateformat, string adtype, string umo, string userid, string area, string publication, string edition, string supliment)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("dailymis_report", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pfrom_date", SqlDbType.VarChar);
                string[] arr = fromdate.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                fromdate = mm + "/" + dd + "/" + yy;
                objSqlCommand.Parameters["@pfrom_date"].Value = Convert.ToDateTime(fromdate);

                objSqlCommand.Parameters.Add("@ptill_date", SqlDbType.VarChar);
                string[] arr1 = todate.Split('/');
                string dd1 = arr1[0];
                string mm1 = arr1[1];
                string yy1 = arr1[2];
                todate = mm1 + "/" + dd1 + "/" + yy1;
                objSqlCommand.Parameters["@ptill_date"].Value = Convert.ToDateTime(todate); ;

                objSqlCommand.Parameters.Add("@ppubcenter", SqlDbType.VarChar);
                if (pubcent == "" || pubcent == "0")
                {
                    objSqlCommand.Parameters["@ppubcenter"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@ppubcenter"].Value = pubcent;
                }
                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@padtype", SqlDbType.VarChar);
                if (adtype == "" || adtype == "0")
                {
                    objSqlCommand.Parameters["@padtype"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@padtype"].Value = adtype;
                }
                objSqlCommand.Parameters.Add("@puomcode", SqlDbType.VarChar);

                if (umo == "" || umo == "0")
                {
                    objSqlCommand.Parameters["@puomcode"].Value = System.DBNull.Value;
                }

                else
                {
                    objSqlCommand.Parameters["@puomcode"].Value = umo;
                }
                objSqlCommand.Parameters.Add("@pmin_size", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pmin_size"].Value = area;



                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;


                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                if (publication == "" || publication == "0")
                {
                    objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra1"].Value = publication;
                }

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                if (edition == "" || edition == "0")
                {
                    objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra2"].Value = edition;
                }

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                if (supliment == "" || supliment == "0")
                {
                    objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pextra3"].Value = supliment;
                }



                objSqlCommand.Parameters.Add("@pextra4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra4"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra5"].Value = System.DBNull.Value;



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
