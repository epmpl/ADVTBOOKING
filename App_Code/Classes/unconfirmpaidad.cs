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
/// Summary description for unconfirmpaidad
/// </summary>
namespace NewAdbooking.Classes
{
    public class unconfirmpaidad : connection
    {
        public unconfirmpaidad()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void AUTOtag(string cioid, string agency)
        {
              SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("AGENCY_AMOUNT_AUTOTAG_TRANS", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CIOID", SqlDbType.VarChar);
                cmd.Parameters["@CIOID"].Value = cioid;
                cmd.Parameters.Add("@QBCCODE", SqlDbType.VarChar);
                cmd.Parameters["@QBCCODE"].Value = agency;

                da.SelectCommand = cmd;
                da.Fill(ds);

              
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
        public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string agency, string flag, string rostatus, string center,string adtype)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("bindaudit_ht", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@date1", SqlDbType.VarChar);
                cmd.Parameters["@date1"].Value = dateformat;

                cmd.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "" && tilldate != null)
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                }
                cmd.Parameters["@todate"].Value = tilldate;

                cmd.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "" && fromdate != null)
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }
                }
                cmd.Parameters["@fromdate"].Value = fromdate;

                cmd.Parameters.Add("@agency", SqlDbType.VarChar);
                cmd.Parameters["@agency"].Value = agency;

                cmd.Parameters.Add("@flag", SqlDbType.VarChar);
                cmd.Parameters["@flag"].Value = flag;

                cmd.Parameters.Add("@rostatus", SqlDbType.VarChar);
                cmd.Parameters["@rostatus"].Value = rostatus;

                cmd.Parameters.Add("@center", SqlDbType.VarChar);
                cmd.Parameters["@center"].Value = center;

                cmd.Parameters.Add("@adtype", SqlDbType.VarChar);
                cmd.Parameters["@adtype"].Value = adtype;

                da.SelectCommand = cmd;
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

        public DataSet executeauditmast1(string bookingid, string compcode, string adtype,string datformate)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("executebooking", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                cmd.Parameters["@ciobookid"].Value = bookingid;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

                cmd.Parameters.Add("@booking", SqlDbType.VarChar);
                cmd.Parameters["@booking"].Value = adtype;

                cmd.Parameters.Add("@docno", SqlDbType.VarChar);
                cmd.Parameters["@docno"].Value = System.DBNull.Value;

                cmd.Parameters.Add("@keyno", SqlDbType.VarChar);
                cmd.Parameters["@keyno"].Value = System.DBNull.Value;

                cmd.Parameters.Add("@rono", SqlDbType.VarChar);
                cmd.Parameters["@rono"].Value = System.DBNull.Value;

                cmd.Parameters.Add("@agencycode", SqlDbType.VarChar);
                cmd.Parameters["@agencycode"].Value = System.DBNull.Value;

                cmd.Parameters.Add("@client", SqlDbType.VarChar);
                cmd.Parameters["@client"].Value = System.DBNull.Value;

                cmd.Parameters.Add("@dateformat", SqlDbType.VarChar);
                cmd.Parameters["@dateformat"].Value = datformate;

                cmd.Parameters.Add("@revenue", SqlDbType.VarChar);
                cmd.Parameters["@revenue"].Value = System.DBNull.Value;


                da.SelectCommand = cmd;
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

        public DataSet bindsh(string userid, string compcode)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("bindschhead", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userid1", SqlDbType.VarChar);
                cmd.Parameters["@userid1"].Value = userid;

                cmd.Parameters.Add("@compcode", SqlDbType.VarChar);
                cmd.Parameters["@compcode"].Value = compcode;

               
                da.SelectCommand = cmd;
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

        public DataSet update1(string booking_id, string userid)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("updaterostatusbillpay", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cioid", SqlDbType.VarChar);
                cmd.Parameters["@cioid"].Value = booking_id;

                cmd.Parameters.Add("@userid", SqlDbType.VarChar);
                cmd.Parameters["@userid"].Value = userid;


                da.SelectCommand = cmd;
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

        public DataSet update2(string booking_id)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                cmd = GetCommand("getmailid", ref con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cioid", SqlDbType.VarChar);
                cmd.Parameters["@cioid"].Value = booking_id;

                da.SelectCommand = cmd;
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