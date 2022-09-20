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

namespace NewAdbooking.BillingClass.Classes
{

    /// <summary>
    /// Summary description for biling_acknowledge
    /// </summary>
    public class biling_acknowledge : NewAdbooking.Classes.connection
    {
        public biling_acknowledge()
        {
            //
            // TODO: Add constructor logic here
            //
        }










        public DataSet updatestatusnew(string bill_number, string delivery_man_name, string delivery_date, string acknowledge_date, string remarks, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {



                con.Open();
                com = GetCommand("ACKNOWLEDGE_UPDATE", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@BILL_NO", SqlDbType.VarChar);
                com.Parameters["@BILL_NO"].Value = bill_number;

                com.Parameters.Add("@DELIVERY_MAN_NAME", SqlDbType.VarChar);
                if (delivery_man_name == "")
                {
                    com.Parameters["@DELIVERY_MAN_NAME"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@DELIVERY_MAN_NAME"].Value = delivery_man_name;
                }


                com.Parameters.Add("@DELIVERY_DATE", SqlDbType.VarChar);
                if (delivery_date == "")
                {
                    com.Parameters["@DELIVERY_DATE"].Value = System.DBNull.Value;
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = delivery_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        delivery_date = mm + "/" + dd + "/" + yy;
                    }
                    com.Parameters["@DELIVERY_DATE"].Value = delivery_date;
                }



                com.Parameters.Add("@ACKNOWLEDGE_DATE", SqlDbType.VarChar);
                if (acknowledge_date == "")
                {
                    com.Parameters["@ACKNOWLEDGE_DATE"].Value = System.DBNull.Value;

                }

                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = acknowledge_date.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        acknowledge_date = mm + "/" + dd + "/" + yy;
                    }


                    com.Parameters["@ACKNOWLEDGE_DATE"].Value = acknowledge_date;
                }



                com.Parameters.Add("@ACKNOWLEDGE_REMARK", SqlDbType.VarChar);
                com.Parameters["@ACKNOWLEDGE_REMARK"].Value = remarks;




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



        public DataSet fetchdata_acknow(string fromdate, string tilldate, string branch, string pubcent, string user, string agency, string edition, string adtype, string acknowledege,string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("webs_bills_acknowledgement", ref con);
                com.CommandType = CommandType.StoredProcedure;


                com.Parameters.Add("@p_fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@p_fromdate"].Value = System.DBNull.Value;
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

                    com.Parameters["@p_fromdate"].Value = fromdate;
                }


                com.Parameters.Add("@p_todate", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@p_todate"].Value = System.DBNull.Value;
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

                    com.Parameters["@p_todate"].Value = tilldate;
                }




                com.Parameters.Add("@p_branch", SqlDbType.VarChar);
                if (branch != "0" || branch != "")
                {
                    com.Parameters["@p_branch"].Value = branch;
                }
                else
                {
                    com.Parameters["@p_branch"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@p_pub_cent", SqlDbType.VarChar);
                if (pubcent != "0" || pubcent != "")
                {
                    com.Parameters["@p_pub_cent"].Value = pubcent;
                }
                else
                {
                    com.Parameters["@p_pub_cent"].Value = System.DBNull.Value;
                }





                com.Parameters.Add("@p_user", SqlDbType.VarChar);
                if (user!= "0")
                {
                    com.Parameters["@p_user"].Value =user;
                }
                else
                {
                    com.Parameters["@p_user"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@p_agency", SqlDbType.VarChar);
                if (agency != "0" || agency != "")
                {
                    com.Parameters["@p_agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@p_agency"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@p_editon", SqlDbType.VarChar);
                if (edition != "" || edition != "0")
                {
                    com.Parameters["@p_editon"].Value = edition;
                }
                else
                {
                    com.Parameters["@p_editon"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@p_adtype", SqlDbType.VarChar);
                if (adtype != "0" || adtype != "")
                {
                    com.Parameters["@p_adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@p_adtype"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@p_acknowledege", SqlDbType.VarChar);
                if (acknowledege != "0")
                {
                    com.Parameters["@p_acknowledege"].Value = acknowledege;
                }
                else
                {
                    com.Parameters["@p_acknowledege"].Value = System.DBNull.Value;
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