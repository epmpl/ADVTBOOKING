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
/// Summary description for clientexecmastr
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class dealprovision1 : connection
    {
        public dealprovision1()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet Fetchdata(string compcode, string fdate, string todate, string deal, string agency, string client, string pub, string Filter, string uid, string dateformat, string adtype, string uom)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Fetchbookingdealdata", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = compcode;

                com.Parameters.Add("@pfrdt", SqlDbType.DateTime);
                if (fdate == "" || fdate == null || fdate == "undefined")
                {
                    com.Parameters["@pfrdt"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pfrdt"].Value = Convert.ToDateTime(fdate);
                }


                com.Parameters.Add("@ptodt", SqlDbType.DateTime);

                if (todate == "" || todate == null || todate == "undefined")
                {
                    com.Parameters["@ptodt"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@ptodt"].Value = Convert.ToDateTime(todate);
                }
                com.Parameters.Add("@pdeal", SqlDbType.VarChar);
                com.Parameters["@pdeal"].Value = deal;

                com.Parameters.Add("@pagency", SqlDbType.VarChar);
                com.Parameters["@pagency"].Value = agency;

                com.Parameters.Add("@pclient", SqlDbType.VarChar);
                com.Parameters["@pclient"].Value = client;

                com.Parameters.Add("@ppub", SqlDbType.VarChar);
                com.Parameters["@ppub"].Value = pub;

                com.Parameters.Add("@pFilter", SqlDbType.VarChar);
                com.Parameters["@pFilter"].Value = Filter;

                com.Parameters.Add("@puid", SqlDbType.VarChar);
                com.Parameters["@puid"].Value = uid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

               

                com.Parameters.Add("@pFilter", SqlDbType.VarChar);
                com.Parameters["@pFilter"].Value = Filter;

                com.Parameters.Add("@padtype", SqlDbType.VarChar);
                if (adtype == "" || adtype == "0")
                {
                    com.Parameters["@padtype"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@padtype"].Value = adtype;
                }

                com.Parameters.Add("@puomcode", SqlDbType.VarChar);
                if (uom == "" || uom == "0")
                {
                    com.Parameters["@puomcode"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@puomcode"].Value = uom;
                }



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

        public DataSet adddealprovisionsave(string compcode, string agencycode, string clientcode, string contractid, string billno, string billdate, string billamt, string billrate, string discrate, string creditnoterate, string totalinsertion, string userid, string insertid, string reamarks, string bookingid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("dealprovisionsave", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcomp_code", SqlDbType.VarChar);
                com.Parameters["@pcomp_code"].Value = compcode;

                com.Parameters.Add("@pagcode", SqlDbType.VarChar);
                com.Parameters["@pagcode"].Value = agencycode;

                com.Parameters.Add("@pclientcode", SqlDbType.VarChar);
                com.Parameters["@pclientcode"].Value = clientcode;

                com.Parameters.Add("@pcontractid", SqlDbType.VarChar);
                com.Parameters["@pcontractid"].Value = contractid;

                com.Parameters.Add("@pbillno", SqlDbType.VarChar);
                com.Parameters["@pbillno"].Value = billno;

                com.Parameters.Add("@pbilldate", SqlDbType.DateTime);
                if (billdate == "" || billdate == null || billdate == "undefined")
                {
                    com.Parameters["@pbilldate"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pbilldate"].Value = Convert.ToDateTime(billdate);
                }

                com.Parameters.Add("@pbillamt", SqlDbType.VarChar);
                com.Parameters["@pbillamt"].Value = billamt;

                com.Parameters.Add("@pbillrate", SqlDbType.VarChar);
                com.Parameters["@pbillrate"].Value = billrate;

                com.Parameters.Add("@pdicrate", SqlDbType.VarChar);
                com.Parameters["@pdicrate"].Value = discrate;

                com.Parameters.Add("@pcrednotrate", SqlDbType.VarChar);
                com.Parameters["@pcrednotrate"].Value = creditnoterate;

                com.Parameters.Add("@ptotalinsertion", SqlDbType.VarChar);
                com.Parameters["@ptotalinsertion"].Value = totalinsertion;


                com.Parameters.Add("@puesrid", SqlDbType.VarChar);
                com.Parameters["@puesrid"].Value = userid;

                com.Parameters.Add("@pinsertid", SqlDbType.VarChar);
                com.Parameters["@pinsertid"].Value = insertid;

                com.Parameters.Add("@premarks", SqlDbType.VarChar);
                com.Parameters["@premarks"].Value = reamarks;

                com.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                com.Parameters["@pbookingid"].Value = bookingid;

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
