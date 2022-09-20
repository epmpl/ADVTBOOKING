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

namespace NewAdbooking.Classes
{
    /// <summary>
    /// Summary description for cash_recipt
    /// </summary>
    public class cash_recipt : connection
    {
        public cash_recipt()
        {
            //
            // TODO: Add constructor logic here
            //
        }






        public DataSet mulcashrcpt123(string dateformat, string fromdate, string todate, string bookingid, string agency, string executive, string compcode, string adtype, string booking_id, string rostatus)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adjustedunadjusted1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;
                }



                com.Parameters["@fromdate"].Value = fromdate;

                com.Parameters.Add("@todate", SqlDbType.VarChar);

                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }



                com.Parameters["@todate"].Value = todate;


                com.Parameters.Add("@date1", SqlDbType.VarChar);
                com.Parameters["@date1"].Value = dateformat;

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                com.Parameters["@agency"].Value = agency;



                com.Parameters.Add("@Adtype", SqlDbType.VarChar);
                com.Parameters["@Adtype"].Value = adtype;

                com.Parameters.Add("@pexecutive", SqlDbType.VarChar);
                com.Parameters["@pexecutive"].Value = System.DBNull.Value;


                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = compcode;



                com.Parameters.Add("@pbooking_id", SqlDbType.VarChar);
                com.Parameters["@pbooking_id"].Value = booking_id;

                com.Parameters.Add("@prostatus", SqlDbType.VarChar);
                com.Parameters["@prostatus"].Value = rostatus;


              




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





        public DataSet executeauditmast1(string bookingid, string compcode, string adtype, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("executebooking_new1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                com.Parameters["@ciobookid"].Value = bookingid;

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;


                com.Parameters.Add("@docno", SqlDbType.VarChar);
                com.Parameters["@docno"].Value = System.DBNull.Value;

                com.Parameters.Add("@keyno", SqlDbType.VarChar);
                com.Parameters["@keyno"].Value = System.DBNull.Value;



                com.Parameters.Add("@rono", SqlDbType.VarChar);
                com.Parameters["@rono"].Value = System.DBNull.Value;

                com.Parameters.Add("@agencycode", SqlDbType.VarChar);
                com.Parameters["@agencycode"].Value = System.DBNull.Value;


                com.Parameters.Add("@client", SqlDbType.VarChar);
                com.Parameters["@client"].Value = System.DBNull.Value;



                com.Parameters.Add("@booking", SqlDbType.VarChar);
                com.Parameters["@booking"].Value = adtype;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;


                com.Parameters.Add("@revenue", SqlDbType.VarChar);
                com.Parameters["@revenue"].Value = System.DBNull.Value;





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





        public string updaterostatus(string compcode, string paymode, string booking_id, string rcptno, string cardmonth, string cardyear, string cardname, string cardtype, string cardnumber, string chkno, string chkdate, string chkamt, string chkbankname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            //  SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatecashrcpt", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@booking_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking_id"].Value = booking_id;

                objSqlCommand.Parameters.Add("@rcptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcptno"].Value = rcptno;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;



                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardnumber", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardnumber"].Value = cardnumber;


                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkdate"].Value = cardmonth;


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;






                objSqlCommand.ExecuteNonQuery();
                return "True";

              
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








        public DataSet bindpub(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpay", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


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














        public DataSet InsertCashDetailExternalSource(string cioid, string receipt, string compcode, string userid, string ip)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("InsertCashDetailExternalSource", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@receipt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receipt"].Value = receipt;

                objSqlCommand.Parameters.Add("@compcode_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode_p"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;

                objSqlCommand.Parameters.Add("@ip", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ip"].Value = ip;


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
        public DataSet InsertCashDetail(string cioid,string bankcode1)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("InsertCashDetail1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@bankcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bankcode"].Value = bankcode1;


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
        public DataSet chkreci(string cioid, string compcode,string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("chkrecifrombooking", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;


                objSqlCommand.Parameters.Add("@userid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid_p"].Value = userid;


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
        public DataSet reciptget(string compcode, string bkid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("findrecieptno", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@pCompCode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pCompCode"].Value = compcode;

                objSqlCommand.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pbookingid"].Value = bkid;

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