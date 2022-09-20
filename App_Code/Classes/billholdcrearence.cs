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
/// Summary description for billholdcrearence
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class billholdcrearence :connection
    {
        public billholdcrearence()
        {
            //
            // TODO: Add constructor logic here
            //
        }




        public DataSet Fetchdata(string fdate, string todate, string bookingcenter, string holdtype, string bookini, string compcode, string dateformat, string logincenter,string userid,string extra1,string extra2)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("WEBSP_BIND_BILLHOLD", ref con);
                com.CommandType = CommandType.StoredProcedure;

               

                com.Parameters.Add("@FROMDATE", SqlDbType.DateTime);
                if (fdate == "" || fdate == null || fdate == "undefined")
                {
                    com.Parameters["@FROMDATE"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@FROMDATE"].Value = Convert.ToDateTime(fdate);
                }


                com.Parameters.Add("@TODATE", SqlDbType.DateTime);

                if (todate == "" || todate == null || todate == "undefined")
                {
                    com.Parameters["@TODATE"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@TODATE"].Value = Convert.ToDateTime(todate);
                }


             

                com.Parameters.Add("@BOOKINGCENTER", SqlDbType.VarChar);
                if (bookingcenter == "0" || bookingcenter == "")
                {
                    com.Parameters["@BOOKINGCENTER"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@BOOKINGCENTER"].Value = bookingcenter;
                }
                com.Parameters.Add("@BILLSTATUS", SqlDbType.VarChar);
                com.Parameters["@BILLSTATUS"].Value = holdtype;

                com.Parameters.Add("@BOOKINGID", SqlDbType.VarChar);
                com.Parameters["@BOOKINGID"].Value = bookini;

                com.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                com.Parameters["@PCOMPCODE"].Value = compcode;

                com.Parameters.Add("@P_CENTERLOGIN", SqlDbType.VarChar);
                com.Parameters["@P_CENTERLOGIN"].Value = logincenter;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = extra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = extra2;

              
                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }
        public DataSet savedata(string compcode, string bookingcenter, string bookingid, string billcycle, string usid, string billdate, string billno, string dateformat, string extra1, string extra2, string extra3, string extra4, string extra5)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("WEBSP_BIND_BILLHOLD", ref con);
                com.CommandType = CommandType.StoredProcedure;



                com.Parameters.Add("@pcenter", SqlDbType.VarChar);
                if (bookingcenter == "0" || bookingcenter == "")
                {
                    com.Parameters["@pcenter"].Value =  System.DBNull.Value;
                }
                else
                {com.Parameters["@pcenter"].Value = bookingcenter;
                }


                com.Parameters.Add("@pbill_date", SqlDbType.DateTime);

                if (billdate == "" || billdate == null || billdate == "undefined")
                {
                    com.Parameters["@pbill_date"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pbill_date"].Value = Convert.ToDateTime(billdate);
                }




                com.Parameters.Add("@porderno", SqlDbType.VarChar);
                if (bookingid == "0" || bookingid == "")
                {
                    com.Parameters["@porderno"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@porderno"].Value = bookingid;
                }
                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = billcycle;

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = usid;

                com.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                com.Parameters["@PCOMPCODE"].Value = compcode;

                com.Parameters.Add("@pbill_no", SqlDbType.VarChar);
                com.Parameters["@pbill_no"].Value = billno;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                     com.Parameters.Add("@pprefix", SqlDbType.VarChar);
                com.Parameters["@pprefix"].Value =  System.DBNull.Value;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = extra1;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = extra2;

                  com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = extra1;

                  com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = extra1;

                  com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = extra1;
              
                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }

        }

    }
}