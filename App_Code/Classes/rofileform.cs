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
/// Summary description for rofileform
/// </summary>
namespace NewAdbooking.Classes
{
    public class rofileform : connection
    {
        public rofileform()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        ////=================================================================================================================/////////////////////
        public DataSet payment(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("paymentmode", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

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
//**********************************************************
 public DataSet fetchamt(string bookingid ,string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetch_reciptamt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pbkid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbkid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

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
 public DataSet executeauditmast2(string cioid,string compcode ,string tick)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updaterofile", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@tick", SqlDbType.VarChar);
                if (tick == "0" || tick == "")
                {
                    objSqlCommand.Parameters["@tick"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tick"].Value = tick;
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
//===================================================================================
 public DataSet gbind(string comecode1, string paymode, string todate, string fromdate, string client, string taluka, string agency, string publication, string exename, string district, string retainer, string branch, string dateformate, string rostatus, string rono, string bookingid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("ad_ro_filing", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pcompcode"].Value = comecode1;

                objSqlCommand.Parameters.Add("@ppaymode", SqlDbType.VarChar);
                if (paymode == "0" || paymode == "")
                    objSqlCommand.Parameters["@ppaymode"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@ppaymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@ptodate", SqlDbType.VarChar);
                if (todate == "" || todate == null)
                {
                    objSqlCommand.Parameters["@ptodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformate == "yyyy/mm/dd")
                    {
                        string[] arr = todate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        todate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@ptodate"].Value = todate;
                }

                objSqlCommand.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@pfromdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformate == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformate == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@pfromdate"].Value = fromdate;
                }
              
                objSqlCommand.Parameters.Add("@pclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pclient"].Value = client;

                objSqlCommand.Parameters.Add("@ptaluka", SqlDbType.VarChar);
                if (taluka == "0" || taluka == "")
                    objSqlCommand.Parameters["@ptaluka"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ptaluka"].Value = taluka;

                objSqlCommand.Parameters.Add("@pagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagency"].Value = agency;

                objSqlCommand.Parameters.Add("@ppcenter", SqlDbType.VarChar);
                if (publication == "All" || publication == "")
                    objSqlCommand.Parameters["@ppcenter"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ppcenter"].Value = publication;

                objSqlCommand.Parameters.Add("@pexename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pexename"].Value = exename;

                objSqlCommand.Parameters.Add("@pdistrict", SqlDbType.VarChar);
                if (district == "0" || district == "")
                    objSqlCommand.Parameters["@pdistrict"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@pdistrict"].Value = district;

                objSqlCommand.Parameters.Add("@pretainer", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pretainer"].Value = retainer;

                objSqlCommand.Parameters.Add("@pbranch", SqlDbType.VarChar);
                if (branch == "0" || branch == "")
                    objSqlCommand.Parameters["@pbranch"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@pbranch"].Value = branch;

                objSqlCommand.Parameters.Add("@pdateformate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pdateformate"].Value = dateformate;

                objSqlCommand.Parameters.Add("@prodocstatus", SqlDbType.VarChar);
                if (rostatus == "0" || rostatus == "")
                    objSqlCommand.Parameters["@prodocstatus"].Value = System.DBNull.Value;
                else
                objSqlCommand.Parameters["@prodocstatus"].Value = rostatus;


                objSqlCommand.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                if (bookingid == "0" || bookingid == "")
                    objSqlCommand.Parameters["@pbookingid"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pbookingid"].Value = bookingid;



                objSqlCommand.Parameters.Add("@prono", SqlDbType.VarChar);
                if (rono == "0" || rono == "")
                    objSqlCommand.Parameters["@prono"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@prono"].Value = rono;


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
 public DataSet savecomment(string cioid, string compcode, string comment)
 {
     SqlConnection objSqlConnection;
     SqlCommand objSqlCommand;
     objSqlConnection = GetConnection();
     SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
     DataSet objDataSet = new DataSet();
     try
     {
         objSqlConnection.Open();
         objSqlCommand = GetCommand("updaterofile_comment", ref objSqlConnection);
         objSqlCommand.CommandType = CommandType.StoredProcedure;

         objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
         objSqlCommand.Parameters["@cioid"].Value = cioid;

         objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
         objSqlCommand.Parameters["@compcode"].Value = compcode;

         objSqlCommand.Parameters.Add("@comment", SqlDbType.VarChar);
         objSqlCommand.Parameters["@comment"].Value = comment;

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
 //======================It will get all Exec active and Inactive===================================//
 public DataSet getExec(string compcode, string execname, string value)
 {
     SqlConnection objSqlConnection;
     SqlCommand objSqlCommand;
     objSqlConnection = GetConnection();
     SqlDataAdapter objSqlDataAdapter;
     DataSet objDataSet = new DataSet();
     try
     {
         objSqlConnection.Open();
         objSqlCommand = GetCommand("websp_getExec_rofile", ref objSqlConnection);
         objSqlCommand.CommandType = CommandType.StoredProcedure;
         objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
         objSqlCommand.Parameters["@compcode"].Value = compcode;

         objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
         objSqlCommand.Parameters["@execname"].Value = execname;

         objSqlCommand.Parameters.Add("@value", SqlDbType.VarChar);
         objSqlCommand.Parameters["@value"].Value = value;
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
 //======================It will get all Retainer active and Inactive===================================//
 public DataSet getretainer(string compcode, string center)
 {
     SqlConnection objSqlConnection;
     SqlCommand objSqlCommand;
     objSqlConnection = GetConnection();
     SqlDataAdapter objSqlDataAdapter;
     DataSet objDataSet = new DataSet();
     try
     {
         objSqlConnection.Open();
         objSqlCommand = GetCommand("GETRETAINER_ROFILE", ref objSqlConnection);
         objSqlCommand.CommandType = CommandType.StoredProcedure;

         objSqlCommand.Parameters.Add("@COMPCODE1", SqlDbType.VarChar);
         objSqlCommand.Parameters["@COMPCODE1"].Value = compcode;

         objSqlCommand.Parameters.Add("@PUBCENTER", SqlDbType.VarChar);
         objSqlCommand.Parameters["@PUBCENTER"].Value = center;

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
//======================It will get all AGency active and Inactive===================================//
 public DataSet bindagency(string compcode, string userid, string agency)
 {
     SqlConnection objSqlConnection;
     SqlCommand objSqlCommand;
     objSqlConnection = GetConnection();
     SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
     DataSet objDataSet = new DataSet();
     try
     {
         objSqlConnection.Open();
         objSqlCommand = GetCommand("bindagencyforbooking_rofile", ref objSqlConnection);
         objSqlCommand.CommandType = CommandType.StoredProcedure;

         objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
         objSqlCommand.Parameters["@compcode"].Value = compcode;

         objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
         objSqlCommand.Parameters["@userid"].Value = userid;

         objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
         objSqlCommand.Parameters["@agency"].Value = agency;

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
