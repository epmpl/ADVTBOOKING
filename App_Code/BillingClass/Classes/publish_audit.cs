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
/// Summary description for publish_audit
/// </summary>
/// 
namespace NewAdbooking.BillingClass.Classes
{

    /// <summary>
    /// Summary description for billing_save
    /// </summary>

    public class publish_audit : NewAdbooking.Classes.connection
    {
        public publish_audit()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet paymode_bind(string comp_code)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {

                con.Open();
                com = GetCommand("an_payment", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = comp_code;

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

        public DataSet bindbranch()
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
              
                con.Open();
                com = GetCommand("bind_branch", ref con);
                com.CommandType = CommandType.StoredProcedure;




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



        public DataSet updatestatusnew(string bookingid, string insertion, string edition)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
             


                con.Open();
                com = GetCommand("updatestausnew", ref con);
                com.CommandType = CommandType.StoredProcedure;          

              


                com.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                com.Parameters["@ciobookid"].Value = bookingid;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;


                com.Parameters.Add("@edition", SqlDbType.VarChar);
                com.Parameters["@edition"].Value = edition;




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


        public DataSet pubsupply(string comcode, string edit)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("bindsuppliment", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = comcode;

                com.Parameters.Add("@editioncode", SqlDbType.VarChar);
                com.Parameters["@editioncode"].Value = edit;


               



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


        public DataSet websp_updatestatus(string dateformat, string tilldate, string fromdate, string Adtype, string branch, string publication, string edition, string supplement, string booking_audit, string status_value, string pub_centcode, string comp_code, string userid/*,string district,string region*/)

        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("Websp_updatestatus", ref con);
                com.CommandType = CommandType.StoredProcedure;







                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = tilldate;
                }


                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    com.Parameters["@fromdate"].Value = fromdate;
                }


               



                com.Parameters.Add("@Adtype", SqlDbType.VarChar);
                if (Adtype != "0")
                {
                    com.Parameters["@Adtype"].Value = Adtype;
                }
                else
                {
                    com.Parameters["@Adtype"].Value = System .DBNull .Value;
                }


                com.Parameters.Add("@branch", SqlDbType.VarChar);
                if (branch != "0")
                {
                    com.Parameters["@branch"].Value = branch;
                }
                else
                {
                    com.Parameters["@branch"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication != "0")
                {
                    com.Parameters["@publication"].Value = publication;
                }
                else
                {
                    com.Parameters["@publication"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;


                com.Parameters.Add("@v_edition", SqlDbType.VarChar);
                if (edition != "0")
                {
                    com.Parameters["@v_edition"].Value = edition;
                }
                else
                {
                    com.Parameters["@v_edition"].Value = System.DBNull.Value;
                }

                ///
                com.Parameters.Add("@v_supplement", SqlDbType.VarChar);
                if (supplement != "")
                {
                    com.Parameters["@v_supplement"].Value = supplement ;
                }
                else
                {
                    com.Parameters["@v_supplement"].Value = System.DBNull.Value;
                }

                ///
                com.Parameters.Add("@v_booking_audit", SqlDbType.VarChar);
                if (booking_audit != "0")
                {
                    com.Parameters["@v_booking_audit"].Value = booking_audit;
                }
                else
                {
                    com.Parameters["@v_booking_audit"].Value = System.DBNull.Value;
                }

                ////
                com.Parameters.Add("@v_status_value", SqlDbType.VarChar);
                if (status_value != "0")
                {
                    com.Parameters["@v_status_value"].Value = status_value;
                }
                else
                {
                    com.Parameters["@v_status_value"].Value = System.DBNull.Value;
                }





                com.Parameters.Add("@v_pub_cent_code", SqlDbType.VarChar);
                if ( pub_centcode != "0")
                {
                    com.Parameters["@v_pub_cent_code"].Value = pub_centcode;
                }
                else
                {
                    com.Parameters["@v_pub_cent_code"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = comp_code;


                com.Parameters.Add("@v_userid", SqlDbType.VarChar);
                com.Parameters["@v_userid"].Value = userid;


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








            public DataSet clsPackageName(string compcode, string pkg_code)
          {
              SqlConnection con;
              SqlCommand com;
              con = GetConnection();
              SqlDataAdapter da = new SqlDataAdapter();
              DataSet ds = new DataSet();
              try
              {



                  con.Open();
                  com = GetCommand("websp_PackageName", ref con);
                  com.CommandType = CommandType.StoredProcedure;




                  com.Parameters.Add("@compcode", SqlDbType.VarChar);
                  com.Parameters["@compcode"].Value = compcode;

                  com.Parameters.Add("@pkg_code", SqlDbType.VarChar);
                  com.Parameters["@pkg_code"].Value = pkg_code;






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
  



        public DataSet save1(string remarks, string cioid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("saveremark5", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@remarks", SqlDbType.VarChar);
                com.Parameters["@remarks"].Value = remarks;

                com.Parameters.Add("@cioid", SqlDbType.VarChar);
                com.Parameters["@cioid"].Value = cioid;






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





        public DataSet bind_category(string compcode, string ad_type)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("audit_cate", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@v_ad_type", SqlDbType.VarChar);
                com.Parameters["@v_ad_type"].Value = ad_type;






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




        public DataSet update1(string booking_id, string auditname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("updateauditbooking", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@cioid", SqlDbType.VarChar);
                com.Parameters["@cioid"].Value = booking_id;

                com.Parameters.Add("@auditname", SqlDbType.VarChar);
                com.Parameters["@auditname"].Value = auditname;






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




        public DataSet unaudit(string booking_id, string auditname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("unauditbooking", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@cioid", SqlDbType.VarChar);
                com.Parameters["@cioid"].Value = booking_id;

                com.Parameters.Add("@auditname", SqlDbType.VarChar);
                com.Parameters["@auditname"].Value = auditname;






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




        public DataSet bindretainer(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("Sp_Retainerbind", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

            

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





        public DataSet adexec(string comcode, string usid, string tname)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("xlsBindexec", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = comcode;


                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = usid;



                com.Parameters.Add("@name1", SqlDbType.VarChar);
                if (tname=="")
                {
                    com.Parameters["@name1"].Value = System.DBNull.Value;
                }
                else
                {
                com.Parameters["@name1"].Value = tname;
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





        public DataSet agency(string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("bindagencyforcontract", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;



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

        public DataSet websp_bindgridorderwise(string dateformat, string tilldate, string fromdate, string branch, string adtype, string publication, string pub_cent, string edition, string agency, string client, string branchnew, string retainer, string executive, string supplement, string insert_status,string userid,string payment_mode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_bindorderwise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;





                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    com.Parameters["@fromdate"].Value = fromdate;
                }


                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@todate"].Value = tilldate;
                }




                com.Parameters.Add("@branch", SqlDbType.VarChar);
                com.Parameters["@branch"].Value = branch;

                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;


                com.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication == "0")
                {
                    com.Parameters["@publication"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@publication"].Value = publication;
                }




                com.Parameters.Add("@pub_cent", SqlDbType.VarChar);
                if (pub_cent == "0")
                {
                    com.Parameters["@pub_cent"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pub_cent"].Value = pub_cent;
                }






                com.Parameters.Add("@edition", SqlDbType.VarChar);
                if (edition == "0" || edition == "")
                {
                    com.Parameters["@edition"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@edition"].Value = edition;
                }


                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency == "0")
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@agency"].Value = agency;
                }





                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client == "0")
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@client"].Value = client;
                }






                com.Parameters.Add("@branchnew", SqlDbType.VarChar);
                if ((branchnew == "") || (branchnew == "0"))
                {
                    com.Parameters["@branchnew"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@branchnew"].Value = branchnew;
                }





                com.Parameters.Add("@v_retainer", SqlDbType.VarChar);
                if (retainer == "0")
                {
                    com.Parameters["@v_retainer"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_retainer"].Value = branchnew;
                }





                com.Parameters.Add("@v_executive", SqlDbType.VarChar);
                if (executive == "0")
                {
                    com.Parameters["@v_executive"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_executive"].Value = executive;
                }







                com.Parameters.Add("@v_supplement", SqlDbType.VarChar);
                if (supplement == "")
                {
                    com.Parameters["@v_supplement"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_supplement"].Value = supplement;
                }








                com.Parameters.Add("@v_insert_status", SqlDbType.VarChar);
                if (insert_status == "0")
                {
                    com.Parameters["@v_insert_status"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_insert_status"].Value = insert_status;
                }





                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;


                com.Parameters.Add("@v_payment_mode", SqlDbType.VarChar);
                if (payment_mode == "0")
                {
                    com.Parameters["@v_payment_mode"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_payment_mode"].Value = payment_mode;
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

        
    }
}