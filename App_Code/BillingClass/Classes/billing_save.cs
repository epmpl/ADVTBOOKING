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
    /// Summary description for billing_save
    /// </summary>
    public class billing_save : NewAdbooking.Classes.connection
    {
        public billing_save()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void abc()
        {
        }




        public DataSet selectclassified_billed(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_classified_billed", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }




                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                if (Client == "")
                {
                    objSqlCommand.Parameters["@Client"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@Client"].Value = Client;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;









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

        public DataSet selectlastnew_billed(string bookingid, string dateformat, string fromdate, string dateto, string v_invoice, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Websp_Orderlastnew_b", ref con);
                com.CommandType = CommandType.StoredProcedure;








                com.Parameters.Add("@bookingid", SqlDbType.VarChar);
                com.Parameters["@bookingid"].Value = bookingid;

                com.Parameters.Add("@dateformat", SqlDbType.VarChar);
                com.Parameters["@dateformat"].Value = dateformat;








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


                com.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    com.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@dateto"].Value = dateto;
                }









                com.Parameters.Add("@v_invoice", SqlDbType.VarChar);
                com.Parameters["@v_invoice"].Value = v_invoice;

                com.Parameters.Add("@v_compcode", SqlDbType.VarChar);
                com.Parameters["@v_compcode"].Value = compcode;








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

        public DataSet saveorderwise(string width, string height, string color, string volume, string packgerate, string package, string adcat1, string pageposition, string rono_date, string insertion, string agency, string publication, string orderno1, string packagecode, string amount, string boxch, string discount, string edition1, string Client, string agddxt1, string city, string agencycode, string invoice1, double amountforvat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_insertionwise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@width", SqlDbType.VarChar);
                com.Parameters["@width"].Value = width;


                com.Parameters.Add("@height", SqlDbType.VarChar);
                com.Parameters["@height"].Value = height;

                com.Parameters.Add("@color", SqlDbType.VarChar);
                com.Parameters["@color"].Value = color;

                com.Parameters.Add("@volume", SqlDbType.VarChar);
                com.Parameters["@volume"].Value = volume;

                com.Parameters.Add("@packgerate", SqlDbType.VarChar);
                com.Parameters["@packgerate"].Value = packgerate;

                com.Parameters.Add("@package", SqlDbType.VarChar);
                com.Parameters["@package"].Value = package;



                com.Parameters.Add("@adcat1", SqlDbType.VarChar);
                com.Parameters["@adcat1"].Value = adcat1;

                com.Parameters.Add("@pageposition", SqlDbType.VarChar);
                com.Parameters["@pageposition"].Value = pageposition;

                com.Parameters.Add("@rono_date", SqlDbType.VarChar);
                com.Parameters["@rono_date"].Value = rono_date;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = Convert.ToDouble(insertion);

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                com.Parameters["@agency"].Value = agency;

                com.Parameters.Add("@publication", SqlDbType.VarChar);
                com.Parameters["@publication"].Value = publication;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno1;

                com.Parameters.Add("@packagecode", SqlDbType.VarChar);
                com.Parameters["@packagecode"].Value = packagecode;

                com.Parameters.Add("@amount", SqlDbType.VarChar);
                com.Parameters["@amount"].Value = Convert.ToDouble(amount);

                com.Parameters.Add("@boxch", SqlDbType.VarChar);
                com.Parameters["@boxch"].Value = boxch;

                com.Parameters.Add("@discount", SqlDbType.VarChar);
                com.Parameters["@discount"].Value = discount;



                com.Parameters.Add("@edition1", SqlDbType.VarChar);
                com.Parameters["@edition1"].Value = edition1;

                com.Parameters.Add("@Client", SqlDbType.VarChar);
                com.Parameters["@Client"].Value = Client;



                com.Parameters.Add("@agddxt1", SqlDbType.VarChar);
                com.Parameters["@agddxt1"].Value = agddxt1;

                com.Parameters.Add("@city", SqlDbType.VarChar);
                com.Parameters["@city"].Value = city;

                com.Parameters.Add("@agencycode", SqlDbType.VarChar);
                com.Parameters["@agencycode"].Value = agencycode;

                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;

                com.Parameters.Add("@amountforvat", SqlDbType.VarChar);
                com.Parameters["@amountforvat"].Value = amountforvat;






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


        public DataSet saveinsertiowise(string orderno, string invoice1, string amountforvat, string amt3, int totinsert, double boxchg1, string noofinsertion, string edicode, double finalamount, double discountint, double premium)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_saveinsertionwise", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;

                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;


                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                if (amountforvat == "")
                {
                    com.Parameters["@amountforvat"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@amountforvat"].Value = Convert.ToSingle(amountforvat);
                }


                com.Parameters.Add("@amt3", SqlDbType.Float);
                if (amt3 == "")
                {
                    com.Parameters["@amt3"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@amt3"].Value = Convert.ToDecimal(amt3);
                }

                com.Parameters.Add("@totinsert", SqlDbType.Float);
                if (totinsert == 0)
                {
                    com.Parameters["@totinsert"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@totinsert"].Value = Convert.ToSingle(totinsert);
                }

                com.Parameters.Add("@boxchg1", SqlDbType.Float);

                if (boxchg1 == 0)
                {
                    com.Parameters["@boxchg1"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@boxchg1"].Value = Convert.ToSingle(boxchg1);
                }

                com.Parameters.Add("@noofinsertion", SqlDbType.Int);
                if (noofinsertion == "")
                {
                    com.Parameters["@noofinsertion"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@noofinsertion"].Value = Convert.ToInt16(noofinsertion);
                }

                com.Parameters.Add("@edicode", SqlDbType.VarChar);
                if (edicode == "")
                {
                    com.Parameters["@edicode"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@edicode"].Value = edicode;

                }

                com.Parameters.Add("@finalamount", SqlDbType.Float);
                if (finalamount == 0)
                {
                    com.Parameters["@finalamount"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@finalamount"].Value = Convert.ToSingle(finalamount);
                }



                com.Parameters.Add("@discountint", SqlDbType.Float);
                if (discountint == 0)
                {
                    com.Parameters["@discountint"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@discountint"].Value = Convert.ToSingle(discountint);
                }



                com.Parameters.Add("@premium", SqlDbType.VarChar);
                com.Parameters["@premium"].Value = premium;


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





        public DataSet revnue_center(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_revenue_new_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }

        public DataSet center(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_center_new_BILL", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }
        /// <summary>
        /// ///////////////
        /// </summary>
        /// <param name="invoiceno"></param>
        /// <returns></returns>
        public DataSet updatebillprintstatus(string invoiceno)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatestatusprintbill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@invoice", SqlDbType.VarChar);
                objSqlCommand.Parameters["@invoice"].Value = invoiceno;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objSqlConnection.Close();

            }
        }


        //public DataSet printcount()
        //{
        //    SqlConnection objSqlConnection;
        //    SqlCommand objSqlCommand;
        //    objSqlConnection = GetConnection();
        //    SqlDataAdapter objSqlDataAdapter;
        //    DataSet objDataSet = new DataSet();

		//    try
		//    {
		//        objSqlConnection.Open();
		//        objSqlCommand = GetCommand("updatestatusprintbill", ref objSqlConnection);
		//        objSqlCommand.CommandType = CommandType.StoredProcedure;

		//        objSqlDataAdapter = new SqlDataAdapter();
		//        objSqlDataAdapter.SelectCommand = objSqlCommand;
		//        objSqlDataAdapter.Fill(objDataSet);
		//        return objDataSet;
		//    }
		//    catch (Exception objException)
        //    {
        //        throw (objException);
        //    }
        //    finally
        //    {
        //        objSqlConnection.Close();

        //    }
        //}

        public DataSet websp_bindciobookingid(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string comcode, string BILL_GEN_PRIOR, string PUB_CENT_HO, string billno, string centerlogin, string fmg_bills, string scheme_type,string userid)
        {
            SqlConnection con;
            SqlCommand com=new SqlCommand ();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
				
                com = GetCommand("websp_bindcioidlatest12", ref con);
                com.CommandTimeout = 0;
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






                com.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication != "0")
                {


                    com.Parameters["@publication"].Value = publication;
                }
                else
                {
                    com.Parameters["@publication"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;
                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;
                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if (billcycle =="" )
                {
                    com.Parameters["@billcycle"].Value = "0";
                }
                else
                {
                com.Parameters["@billcycle"].Value = billcycle;
                }




                com.Parameters.Add("@v_retainer_name", SqlDbType.VarChar);
                if (retainer_name != "")
                {
                    com.Parameters["@v_retainer_name"].Value = retainer_name;
                }
                else
                {
                    com.Parameters["@v_retainer_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_executive_name", SqlDbType.VarChar);
                if (executive_name != "")
                {
                    com.Parameters["@v_executive_name"].Value = executive_name;
                }
                else
                {
                    com.Parameters["@v_executive_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_branch_name", SqlDbType.VarChar);
                if (branch_name != "-Select Branch-")
                {
                    com.Parameters["@v_branch_name"].Value = branch_name;
                }
                else
                {
                    com.Parameters["@v_branch_name"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_ad_category", SqlDbType.VarChar);
                if (ad_category != "0")
                {
                    com.Parameters["@v_ad_category"].Value = ad_category;
                }
                else
                {
                    com.Parameters["@v_ad_category"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                if (district != "0")
                {
                    com.Parameters["@v_district"].Value = district;
                }
                else
                {
                    com.Parameters["@v_district"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka != "0")
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;


                com.Parameters.Add("@billno", SqlDbType.VarChar);
                if (billno != "")
                {
                    com.Parameters["@billno"].Value = billno;
                }
                else
                {
                    com.Parameters["@billno"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@BILL_GEN_PRIOR", SqlDbType.VarChar);
                if (BILL_GEN_PRIOR == "")
                {
                    com.Parameters["@BILL_GEN_PRIOR"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@BILL_GEN_PRIOR"].Value = BILL_GEN_PRIOR;
                }


                com.Parameters.Add("@PUB_CENT_HO", SqlDbType.VarChar);
                if (PUB_CENT_HO == "")
                {
                    com.Parameters["@PUB_CENT_HO"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@PUB_CENT_HO"].Value = PUB_CENT_HO;
                }


                com.Parameters.Add("@centerlogin", SqlDbType.VarChar);
                com.Parameters["@centerlogin"].Value = centerlogin;



                com.Parameters.Add("@fmg_bills", SqlDbType.VarChar);
                com.Parameters["@fmg_bills"].Value = fmg_bills;




                com.Parameters.Add("@scheme_type", SqlDbType.VarChar);
                com.Parameters["@scheme_type"].Value = scheme_type;

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









        public DataSet bindagencycode(string compcode, string agency)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindagencycode1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

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


        public DataSet GetAgencyNameAdd_agency(string client, string compcode, string value)
        {
            string zonename = "";
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("GetAgency_agencybill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

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

        public DataSet selectinvoicefmadbills(string ciobooking, string editionname, string insertion, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectinvoiceno", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;

                com.Parameters.Add("@editionname", SqlDbType.VarChar);
                com.Parameters["@editionname"].Value = editionname;
                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = compcode;

                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



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









        public DataSet selectinvoicefmadbills_ins(string ciobooking, string insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectinvoiceno_insertion", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;




                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



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





        public DataSet selectinvoicefmclassi(string ciobooking, string insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectinvoiceno_clasiified", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;




                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



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



        //

        public DataSet packagebind(string compcode, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("bindpackage1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;



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

        /////////////



        public DataSet fetchpackagename(string packagecode, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchpackagename", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;

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

        ///procedure for classified
        ///



        public DataSet selectclassified(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_classified", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }




                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                if (Client == "")
                {
                    objSqlCommand.Parameters["@Client"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@Client"].Value = Client;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;









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

        public DataSet chkadbills(string agcode, string maxdate)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_chk", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@agcode", SqlDbType.VarChar);
                com.Parameters["@agcode"].Value = agcode;


                com.Parameters.Add("@maxdate", SqlDbType.VarChar);
                com.Parameters["@maxdate"].Value = maxdate;





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


        public DataSet selectmonthly(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string bookingn)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectmonthly", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }


                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }




                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                if (Client == "")
                {
                    objSqlCommand.Parameters["@Client"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@Client"].Value = Client;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;


                objSqlCommand.Parameters.Add("@bookingtot", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtot"].Value = bookingn;









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




        public DataSet websp_bookclassified(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_classifiedgridlatest", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "")
                {
                    com.Parameters["@todate"].Value = tilldate;
                }
                else
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    com.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;

                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;

                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
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




        ///



        public DataSet maxdate(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string comp_code, string userid, string DISP_CLSBILL, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string DISP_CASHBILL, string FMG_BILL_DIS, string BILL_DISP_CASHBILL, string centername, string ROWISE_CASHBOOKING, string bill_no)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("selectmax_latest", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@ptodate", SqlDbType.VarChar);
                if (tilldate != "")
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = tilldate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        tilldate = mm + "/" + dd + "/" + yy;


                    }
                    com.Parameters["@ptodate"].Value = tilldate;
                }
                else
                {
                    com.Parameters["@ptodate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pfromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = fromdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        fromdate = mm + "/" + dd + "/" + yy;


                    }

                    com.Parameters["@pfromdate"].Value = fromdate;
                }
                else
                {
                    com.Parameters["@pfromdate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@ppublication", SqlDbType.VarChar);
                if (publication != "0")
                {


                    com.Parameters["@ppublication"].Value = publication;
                }
                else
                {
                    com.Parameters["@ppublication"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pbookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@pbookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@pbookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@prevenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@prevenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@prevenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pagencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@pagencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@pagencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@ppckage", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@ppckage"].Value = package;
                }
                else
                {
                    com.Parameters["@ppckage"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@padtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@padtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@padtype"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@pagency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@pagency"].Value = agency;
                }
                else
                {
                    com.Parameters["@pagency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pclient", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@pclient"].Value = client;
                }
                else
                {
                    com.Parameters["@pclient"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }





                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;

                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;

                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
                }

                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = comp_code;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;



                com.Parameters.Add("@DISP_CLSBILL", SqlDbType.VarChar);
                com.Parameters["@DISP_CLSBILL"].Value = DISP_CLSBILL;

                com.Parameters.Add("@v_retainer_name", SqlDbType.VarChar);
                if (retainer_name == "0")
                {
                    com.Parameters["@v_retainer_name"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_retainer_name"].Value = retainer_name;
                }

                com.Parameters.Add("@v_executive_name", SqlDbType.VarChar);
                if (retainer_name == "0")
                {
                    com.Parameters["@v_executive_name"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_executive_name"].Value = executive_name;
                }


                com.Parameters.Add("@v_branch_name", SqlDbType.VarChar);
                if (branch_name == "-Select Branch-")
                {
                    com.Parameters["@v_branch_name"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_branch_name"].Value = branch_name;
                }

                com.Parameters.Add("@v_ad_category", SqlDbType.VarChar);
                if (ad_category == "0")
                {
                    com.Parameters["@v_ad_category"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_ad_category"].Value = ad_category;
                }




                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                if (district == "0")
                {
                    com.Parameters["@v_district"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_district"].Value = district;
                }



                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka == "0")
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }


                com.Parameters.Add("@V_DISP_CASHBILL", SqlDbType.VarChar);
                com.Parameters["@V_DISP_CASHBILL"].Value = DISP_CLSBILL;


                com.Parameters.Add("@V_FMG_BILL_DIS", SqlDbType.VarChar);
                com.Parameters["@V_FMG_BILL_DIS"].Value = FMG_BILL_DIS;


                com.Parameters.Add("@V_BILL_DISP_CASHBILL", SqlDbType.VarChar);
                com.Parameters["@V_BILL_DISP_CASHBILL"].Value = BILL_DISP_CASHBILL;


                com.Parameters.Add("@v_centername", SqlDbType.VarChar);
                com.Parameters["@v_centername"].Value = centername;

                com.Parameters.Add("@v_ROWISE_CASHBOOKING", SqlDbType.VarChar);
                com.Parameters["@v_ROWISE_CASHBOOKING"].Value = ROWISE_CASHBOOKING;

                com.Parameters.Add("@pbillno", SqlDbType.VarChar);
                if (bill_no == "")
                {
                    com.Parameters["@pbillno"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@pbillno"].Value = bill_no;
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

        //






        /* public string save_det_monthly(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name, string maxdate, string dateformat, string insert_id)
         {
             OracleConnection con;
             OracleCommand com;
             DataSet objDataSet = new DataSet();
             con = GetConnection();
             OracleDataAdapter da = new OracleDataAdapter();
             try
             {

                 con.Open();
                 com = GetCommand("bill_save_det_monthly", ref con);
                 com.CommandType = CommandType.StoredProcedure;



                 OracleParameter prm21 = new OracleParameter("orderno1", OracleType.VarChar);
                 prm21.Direction = ParameterDirection.Input;
                 prm21.Value = orderno;
                 com.Parameters.Add(prm21);



                 OracleParameter prm22 = new OracleParameter("invoice1", OracleType.VarChar);
                 prm22.Direction = ParameterDirection.Input;
                 prm22.Value = invoice1;
                 com.Parameters.Add(prm22);


                 OracleParameter prm23 = new OracleParameter("amountforvat", OracleType.VarChar);
                 prm23.Direction = ParameterDirection.Input;
                 prm23.Value = Convert.ToDecimal(grossamt);
                 com.Parameters.Add(prm23);



                 OracleParameter prm113 = new OracleParameter("edition_name", OracleType.VarChar);
                 prm113.Direction = ParameterDirection.Input;
                 prm113.Value = edition_name;
                 com.Parameters.Add(prm113);




                 OracleParameter prm25 = new OracleParameter("boxchg1", OracleType.VarChar);
                 prm25.Direction = ParameterDirection.Input;
                 prm25.Value = Convert.ToDecimal(boxchg1);
                 com.Parameters.Add(prm25);







                 OracleParameter prm114 = new OracleParameter("noofinsert", OracleType.VarChar);
                 prm114.Direction = ParameterDirection.Input;
                 prm114.Value = Convert.ToDecimal(ins_num);
                 com.Parameters.Add(prm114);





                 OracleParameter prm24 = new OracleParameter("todate", OracleType.VarChar);
                 prm24.Direction = ParameterDirection.Input;
                 if (maxdate == "")
                 {
                     prm24.Value = System.DBNull.Value;
                 }
                 else
                 {
                     if (dateformat == "dd/mm/yyyy")
                     {
                         string[] arr = maxdate.Split('/');
                         string dd = arr[0];
                         string mm = arr[1];
                         string yy = arr[2];
                         maxdate = mm + "/" + dd + "/" + yy;
                     }
                     prm24.Value = Convert.ToDateTime(maxdate).ToString("dd-MMMM-yyyy");

                 }

                 com.Parameters.Add(prm24);


                 OracleParameter prm115 = new OracleParameter("v_insert_id", OracleType.VarChar);
                 prm115.Direction = ParameterDirection.Input;
                 prm115.Value = insert_id;
                 com.Parameters.Add(prm115);




                 da.SelectCommand = com;
                 com.ExecuteNonQuery();

                 return "Success";
             }
             catch (Exception ex)
             {
                 return "Fail";
             }
             finally
             {
                 CloseConnection(ref con);
             }
         }


         */



        public DataSet save_det(string orderno, string invoice1, string grossamt, double billamt, double boxchg1, string ins_num, string edition_name)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_save_det", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;

                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;


                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDouble(grossamt);



                com.Parameters.Add("@boxchg1", SqlDbType.Float);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.Int);
                com.Parameters["@noofinsert"].Value = Convert.ToInt16(ins_num);

                com.Parameters.Add("@edition_name", SqlDbType.VarChar);
                com.Parameters["@edition_name"].Value = edition_name;








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




        public DataSet saveinclassified(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_saveclassified", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;

                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;


                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDouble(amountforvat);


                com.Parameters.Add("@amt3", SqlDbType.VarChar);
                com.Parameters["@amt3"].Value = Convert.ToDouble(amountforvat);

                com.Parameters.Add("@boxchg1", SqlDbType.Float);
                com.Parameters["@boxchg1"].Value = boxchg1;





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
        ///


        public DataSet fetchstatus(string ciobooking, int insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("fetchstatus", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@bookingid", SqlDbType.VarChar);
                com.Parameters["@bookingid"].Value = ciobooking;

                com.Parameters.Add("@insertion_no", SqlDbType.VarChar);
                com.Parameters["@insertion_no"].Value = insertion;




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

        //////


        public DataSet selectprintcount(string ciobooking, string insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_selectprintcount", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;




                com.Parameters.Add("@insertion", SqlDbType.VarChar);
                com.Parameters["@insertion"].Value = insertion;



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

        //

        public DataSet mothly_billing(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string comp_code, string userid)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("mothly_billing", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "")
                {
                    com.Parameters["@todate"].Value = tilldate;
                }
                else
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    com.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;

                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;

                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
                }
                ///////////


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


        public DataSet packagecode(string ciobookingid, string compcode)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_packagecode", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobookingid;


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

        public DataSet vatrate(string bookingdate, string compcode)
        {

            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {


                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_getvatrate", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;






                objSqlCommand.Parameters.Add("@bookingdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingdate"].Value = bookingdate;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;
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

        //



        ///








        public DataSet fetchstatusmon(string ciobooking, string insertion, string maxdate)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusmon", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@bookingid", SqlDbType.VarChar);
                com.Parameters["@bookingid"].Value = ciobooking;

                com.Parameters.Add("@insertion_no", SqlDbType.VarChar);
                com.Parameters["@insertion_no"].Value = insertion;

                com.Parameters.Add("@maxdate", SqlDbType.DateTime);
                com.Parameters["@maxdate"].Value = maxdate;





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






        public DataSet fetchstatusmonthly(string agcode, string maxdate)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusmon", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@agcode", SqlDbType.VarChar);
                com.Parameters["@agcode"].Value = agcode;


                com.Parameters.Add("@maxdate", SqlDbType.VarChar);
                com.Parameters["@maxdate"].Value = maxdate;





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


        public DataSet updatemonthly(string bookingid, string ins_no, string edition)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_updatemonthly", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                //objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                //objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ins_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ins_no"].Value = ins_no;

                objSqlCommand.Parameters.Add("@edition_new", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_new"].Value = edition;


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




        public DataSet selectlast(string bookingid, string dateformat/*,string fromdate,string dateto,string compcode*/)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Orderlastnew", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;







                /*
                                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                                if (fromdate == "" || fromdate == null)
                                {
                                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                                }


                                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                                if (dateto == "" || dateto == null)
                                {
                                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                                }
                                else
                                {
                                    if (dateformat == "dd/mm/yyyy")
                                    {
                                        string[] arr = dateto.Split('/');
                                        string dd = arr[0];
                                        string mm = arr[1];
                                        string yy = arr[2];
                                        dateto = mm + "/" + dd + "/" + yy;
                                    }

                                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                                }











                                objSqlCommand.Parameters.Add("@v_compcode", SqlDbType.VarChar);
                                objSqlCommand.Parameters["@v_compcode"].Value = compcode;

       



                                */


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



        public DataSet selectlastnew(string bookingid, string dateformat, string fromdate, string dateto)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectlast_latest", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;



                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;






                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }




                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
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




        public DataSet selectlastnew1(string bookingid, string dateformat, string fromdate, string dateto, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Websp_Orderlastnew1", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;




                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;



                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;






                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    objSqlCommand.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                    objSqlCommand.Parameters["@fromdate"].Value = fromdate;
                }




                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
                }


                objSqlCommand.Parameters.Add("@v_compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@v_compcode"].Value = compcode;











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













        public DataSet fetchlast_monthly_adbil(string ciobooking, string dateto, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {

                objSqlConnection.Open();
                objSqlCommand = GetCommand("chklast", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;



                objSqlCommand.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobooking"].Value = ciobooking;





                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                if (dateto == "" || dateto == null)
                {
                    objSqlCommand.Parameters["@dateto"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto = mm + "/" + dd + "/" + yy;
                    }

                    objSqlCommand.Parameters["@dateto"].Value = dateto;
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




        public DataSet fetchlast(string ciobooking)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Websp_last", ref con);
                com.CommandType = CommandType.StoredProcedure;




                com.Parameters.Add("@ciobooking", SqlDbType.VarChar);
                com.Parameters["@ciobooking"].Value = ciobooking;





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






        public DataSet fetchinsertid(string insert_id)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {

                con.Open();
                com = GetCommand("fetchsinsert_id", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@insert_id_v", SqlDbType.VarChar);
                com.Parameters["@insert_id_v"].Value = insert_id;


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


        public DataSet selectclassifiedmonthly(string agcode, string fromdate, string dateto, string bookingid, string Client, string dateformat, string booking)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("selectmonthly", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;


                objSqlCommand.Parameters.Add("@agcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agcode"].Value = agcode;

                objSqlCommand.Parameters.Add("@fromdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fromdate"].Value = fromdate;

                objSqlCommand.Parameters.Add("@dateto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateto"].Value = dateto;

                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;

                objSqlCommand.Parameters.Add("@Client", SqlDbType.VarChar);
                if (Client == "")
                {
                    objSqlCommand.Parameters["@Client"].Value = System.DBNull.Value;

                }
                else
                {
                    objSqlCommand.Parameters["@Client"].Value = Client;
                }

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@bookingtot", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtot"].Value = booking;











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


        public DataSet updatemonthlynew(string bookingid, string ins_no, string edition, string bill_no, string billdate)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("websp_updatemonthly", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@bookingid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingid"].Value = bookingid;


                objSqlCommand.Parameters.Add("@ins_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ins_no"].Value = ins_no;


                objSqlCommand.Parameters.Add("@bill_no", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_no"].Value = bill_no;


                objSqlCommand.Parameters.Add("@bill_date", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bill_date"].Value = billdate;

                objSqlCommand.Parameters.Add("@edition_new", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition_new"].Value = edition;


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

        public DataSet save_monthly(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int total_ins_num, string maxins, string date_time, string maxdate)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_save_monthly", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno;

                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;


                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDouble(amountforvat);


                com.Parameters.Add("@amt3", SqlDbType.VarChar);
                com.Parameters["@amt3"].Value = Convert.ToDouble(amt3);

                com.Parameters.Add("@boxchg1", SqlDbType.Float);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.Int);
                com.Parameters["@noofinsert"].Value = total_ins_num;

                com.Parameters.Add("@maxinsert", SqlDbType.Int);
                com.Parameters["@maxinsert"].Value = maxins;


                com.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    com.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@date_time"].Value = date_time;
                }

                com.Parameters.Add("@maxdate", SqlDbType.DateTime);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@maxdate"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@maxdate"].Value = maxdate;
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









        public DataSet websp_bookclassified1(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Websp_Classifiedgrid1", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "")
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
                else
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
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
                else
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;

                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;

                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
                }




                com.Parameters.Add("@v_retainer_name", SqlDbType.VarChar);
                if (retainer_name != "")
                {
                    com.Parameters["@v_retainer_name"].Value = retainer_name;
                }
                else
                {
                    com.Parameters["@v_retainer_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_executive_name", SqlDbType.VarChar);
                if (executive_name != "")
                {
                    com.Parameters["@v_executive_name"].Value = executive_name;
                }
                else
                {
                    com.Parameters["@v_executive_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_branch_name", SqlDbType.VarChar);
                if (branch_name != "-Select Branch-")
                {
                    com.Parameters["@v_branch_name"].Value = branch_name;
                }
                else
                {
                    com.Parameters["@v_branch_name"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_ad_category", SqlDbType.VarChar);
                if (ad_category != "0")
                {
                    com.Parameters["@v_ad_category"].Value = ad_category;
                }
                else
                {
                    com.Parameters["@v_ad_category"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                if (district != "0")
                {
                    com.Parameters["@v_district"].Value = district;
                }
                else
                {
                    com.Parameters["@v_district"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka != "0")
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }
                //v_retainer_name
                //    v_executive_name
                //v_branch_name
                //    v_ad_category
                //v_district

                //    v_taluka



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



        /////////////




        public DataSet fetchstatusfororderfirst(string ciobooking, int insertion)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("fetchstatusfororderfirst", ref con);
                com.CommandType = CommandType.StoredProcedure;



                com.Parameters.Add("@bookingid", SqlDbType.VarChar);
                com.Parameters["@bookingid"].Value = ciobooking;



                com.Parameters.Add("@insertion_no", SqlDbType.VarChar);
                com.Parameters["@insertion_no"].Value = insertion;





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




        public DataSet mothly_billing(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string comp_code, string userid, string DISP_CLSBILL, string exe_code, string ret_code, string ad_category, string district, string taluka, string CLA_CASHBILL, string BILL_CLA_CASHBILL, string center, string bill_no, string from_date_new, string dateto_new)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("monthlynew_retainer2", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "")
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
                else
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
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
                else
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;

                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;

                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0"))
                {
                    com.Parameters["@billcycle"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
                }


                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = comp_code;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;


                com.Parameters.Add("@DISP_CLSBILL", SqlDbType.VarChar);
                com.Parameters["@DISP_CLSBILL"].Value = DISP_CLSBILL;

                com.Parameters.Add("@exe_code", SqlDbType.VarChar);
                if (exe_code == "" || exe_code == "0")
                {
                    com.Parameters["@exe_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@exe_code"].Value = exe_code;
                }

                com.Parameters.Add("@ret_code", SqlDbType.VarChar);
                if (ret_code == "" || ret_code == "0")
                {
                    com.Parameters["@ret_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@ret_code"].Value = ret_code;
                }

                com.Parameters.Add("@v_ad_catogry", SqlDbType.VarChar);
                com.Parameters["@v_ad_catogry"].Value = System.DBNull.Value;

                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                com.Parameters["@v_district"].Value = System.DBNull.Value;

                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka == "0" || taluka == "")
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }

                com.Parameters.Add("@v_center", SqlDbType.VarChar);
                com.Parameters["@v_center"].Value = center;

                com.Parameters.Add("@v_CLA_CASHBILL", SqlDbType.VarChar);
                com.Parameters["@v_CLA_CASHBILL"].Value = DISP_CLSBILL;

                com.Parameters.Add("@v_BILL_CLA_CASHBILL", SqlDbType.VarChar);
                com.Parameters["@v_BILL_CLA_CASHBILL"].Value = BILL_CLA_CASHBILL;

                com.Parameters.Add("@bill_no", SqlDbType.VarChar);
                if (bill_no == "")
                {
                    com.Parameters["@bill_no"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@bill_no"].Value = bill_no;
                }




                com.Parameters.Add("@fromdate_new", SqlDbType.VarChar);
                if (from_date_new != "")
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = from_date_new.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        from_date_new = mm + "/" + dd + "/" + yy;
                    }

                    com.Parameters["@fromdate_new"].Value = from_date_new;
                }
                else
                {
                    com.Parameters["@fromdate_new"].Value = System.DBNull.Value;
                }

                ///////
                com.Parameters.Add("@todate_new", SqlDbType.VarChar);
                if (dateto_new != "")
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = dateto_new.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        dateto_new = mm + "/" + dd + "/" + yy;
                    }
                    com.Parameters["@todate_new"].Value = dateto_new;
                }
                else
                {
                    com.Parameters["@todate_new"].Value = System.DBNull.Value;
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



        public DataSet mothly_billingnew(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string comp_code, string userid, string DISP_CLSBILL, string exe_code, string ret_code, string ad_category, string district, string taluka, string CLA_CASHBILL, string BILL_CLA_CASHBILL, string center, string bill_no)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("monthlynew_retainer3", ref con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "")
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
                else
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
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
                else
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;

                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;

                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
                }


                com.Parameters.Add("@compcode", SqlDbType.VarChar);
                com.Parameters["@compcode"].Value = comp_code;

                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;


                com.Parameters.Add("@DISP_CLSBILL", SqlDbType.VarChar);
                com.Parameters["@DISP_CLSBILL"].Value = DISP_CLSBILL;

                com.Parameters.Add("@exe_code", SqlDbType.VarChar);
                if (exe_code == "" || exe_code == "0")
                {
                    com.Parameters["@exe_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@exe_code"].Value = exe_code;
                }

                com.Parameters.Add("@ret_code", SqlDbType.VarChar);
                if (ret_code == "" || ret_code == "0")
                {
                    com.Parameters["@ret_code"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@ret_code"].Value = ret_code;
                }

                com.Parameters.Add("@v_ad_catogry", SqlDbType.VarChar);
                com.Parameters["@v_ad_catogry"].Value = System.DBNull.Value;

                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                com.Parameters["@v_district"].Value = System.DBNull.Value;

                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka == "0" || taluka == "")
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }

                com.Parameters.Add("@v_center", SqlDbType.VarChar);
                com.Parameters["@v_center"].Value = center;

                com.Parameters.Add("@v_CLA_CASHBILL", SqlDbType.VarChar);
                com.Parameters["@v_CLA_CASHBILL"].Value = DISP_CLSBILL;

                com.Parameters.Add("@v_BILL_CLA_CASHBILL", SqlDbType.VarChar);
                com.Parameters["@v_BILL_CLA_CASHBILL"].Value = BILL_CLA_CASHBILL;

                com.Parameters.Add("@bill_no", SqlDbType.VarChar);
                if (bill_no == "")
                {
                    com.Parameters["@bill_no"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@bill_no"].Value = bill_no;
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

        public DataSet save_last(string orderno, string invoice1, string amountforvat, string amt3, double boxchg1, int total_ins_num, string maxins, string date_time, string maxdate)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("bill_save_last", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                com.Parameters["@orderno1"].Value = orderno.ToString(); ;

                com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                com.Parameters["@invoice1"].Value = invoice1;


                com.Parameters.Add("@amountforvat", SqlDbType.Float);
                com.Parameters["@amountforvat"].Value = Convert.ToDouble(amountforvat);


                com.Parameters.Add("@amt3", SqlDbType.VarChar);
                com.Parameters["@amt3"].Value = Convert.ToDouble(amt3);

                com.Parameters.Add("@boxchg1", SqlDbType.Float);
                com.Parameters["@boxchg1"].Value = boxchg1;

                com.Parameters.Add("@noofinsert", SqlDbType.Int);
                com.Parameters["@noofinsert"].Value = total_ins_num;

                com.Parameters.Add("@maxinsert", SqlDbType.Int);
                com.Parameters["@maxinsert"].Value = maxins;


                com.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    com.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@date_time"].Value = date_time;
                }

                com.Parameters.Add("@maxdate", SqlDbType.DateTime);
                if (maxdate == "" || maxdate == null)
                {
                    com.Parameters["@maxdate"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@maxdate"].Value = maxdate;
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



        public DataSet summary_insertion(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("websp_bindcioidlatest12", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                if (tilldate != "")
                {





                    com.Parameters["@todate"].Value = tilldate;
                }
                else
                {
                    com.Parameters["@todate"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                if (fromdate != "")
                {
                    com.Parameters["@fromdate"].Value = fromdate;
                }
                else
                {
                    com.Parameters["@fromdate"].Value = System.DBNull.Value;
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

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;
                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;
                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if ((billcycle == "0") || (billcycle == "1"))
                {
                    com.Parameters["@billcycle"].Value = "0" + "','" + "1";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
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




        /* public DataSet saveinsertiowise(string orderno, string invoice1,string amountforvat, string amt3, int totinsert, double boxchg1,string noofinsertion, string edicode, double finalamount, double discountint, double premium)
         {
             SqlConnection con;
             SqlCommand com;
             con = GetConnection();
             SqlDataAdapter da = new SqlDataAdapter();
             DataSet ds = new DataSet();
             try
             {
                 con.Open();
                 com = GetCommand("bill_saveinsertionwise", ref con);
                 com.CommandType = CommandType.StoredProcedure;

                 com.Parameters.Add("@orderno1", SqlDbType.VarChar);
                 com.Parameters["@orderno1"].Value = orderno;

                 com.Parameters.Add("@invoice1", SqlDbType.VarChar);
                 com.Parameters["@invoice1"].Value = invoice1;


                 com.Parameters.Add("@amountforvat",SqlDbType.Float);
                 if (amountforvat == "")
                 {
                     com.Parameters["@amountforvat"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@amountforvat"].Value =Convert.ToSingle(amountforvat);
                 }


                 com.Parameters.Add("@amt3", SqlDbType.Float);
                 if (amt3 == "")
                 {
                     com.Parameters["@amt3"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@amt3"].Value =Convert.ToDecimal(amt3);
                 }

                 com.Parameters.Add("@totinsert", SqlDbType.Float);
                 if (totinsert == 0)
                 {
                     com.Parameters["@totinsert"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@totinsert"].Value =Convert.ToSingle(totinsert);
                 }

                 com.Parameters.Add("@boxchg1", SqlDbType.Float);

                 if (boxchg1 == 0)
                 {
                     com.Parameters["@boxchg1"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@boxchg1"].Value =Convert.ToSingle(boxchg1);
                 }

                 com.Parameters.Add("@noofinsertion", SqlDbType.Int);
                 if (noofinsertion == "")
                 {
                     com.Parameters["@noofinsertion"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@noofinsertion"].Value =Convert.ToInt16(noofinsertion);
                 }

                 com.Parameters.Add("@edicode", SqlDbType.VarChar);
                 if (edicode == "")
                 {
                     com.Parameters["@edicode"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@edicode"].Value = edicode;

                 }

                 com.Parameters.Add("@finalamount", SqlDbType.Float);
                 if (finalamount == 0)
                 {
                     com.Parameters["@finalamount"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@finalamount"].Value =Convert.ToSingle(finalamount);
                 }



                 com.Parameters.Add("@discountint", SqlDbType.Float);
                 if (discountint == 0)
                 {
                     com.Parameters["@discountint"].Value =System.DBNull.Value;
                 }
                 else
                 {
                     com.Parameters["@discountint"].Value =Convert.ToSingle(discountint);
                 }



                 com.Parameters.Add("@premium", SqlDbType.VarChar);
                 com.Parameters["@premium"].Value = premium;


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

 */




        ///
        public DataSet settemprec(string comcode, string bookid, string insert, string bill_cycle, string fromdate, string tilldate, string pubdate, string bill_process_id, string userid, string dateformat)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("ad_for_bill_process", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;

                com.Parameters.Add("@pbookingid", SqlDbType.VarChar);
                if (bookid == "" || bookid == null)
                {
                    com.Parameters["@pbookingid"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbookingid"].Value =Convert.ToInt32(bookid);
                    com.Parameters["@pbookingid"].Value = bookid;
                }

                com.Parameters.Add("@pbkid_no_insert", SqlDbType.VarChar);
                com.Parameters["@pbkid_no_insert"].Value = insert;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = bill_cycle;


                com.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@pdatefrom"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdatefrom"].Value = fromdate;
                }


                com.Parameters.Add("@pdateto", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@pdateto"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdateto"].Value = tilldate;
                }

                com.Parameters.Add("@ppubdate", SqlDbType.VarChar);
                com.Parameters["@ppubdate"].Value = pubdate;

                com.Parameters.Add("@pbill_process_id", SqlDbType.VarChar);
                if (bill_process_id == "" || bill_process_id == null)
                {
                    com.Parameters["@pbill_process_id"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@pbill_process_id"].Value = bill_process_id;
                }

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;

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
        public DataSet billproces(string comcode, string bill_cycle, string fromdate, string tilldate, string bill_process_id, string userid, string dateformat, string adtype)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("adbill_monthly_insert_process", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;

                com.Parameters.Add("@pbill_cycle", SqlDbType.VarChar);
                com.Parameters["@pbill_cycle"].Value = bill_cycle;


                com.Parameters.Add("@pdatefrom", SqlDbType.VarChar);
                if (fromdate == "" || fromdate == null)
                {
                    com.Parameters["@pdatefrom"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdatefrom"].Value = fromdate;
                }


                com.Parameters.Add("@pdateto", SqlDbType.VarChar);
                if (tilldate == "" || tilldate == null)
                {
                    com.Parameters["@pdateto"].Value = System.DBNull.Value;
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

                    com.Parameters["@pdateto"].Value = tilldate;
                }

                com.Parameters.Add("@pbill_process_id", SqlDbType.VarChar);
                if (bill_process_id == "" || bill_process_id == null)
                {
                    com.Parameters["@pbill_process_id"].Value = System.DBNull.Value;
                }
                else
                {
                    //com.Parameters["@pbill_process_id"].Value =Convert.ToInt32(bill_process_id);
                    com.Parameters["@pbill_process_id"].Value = bill_process_id;
                }

                com.Parameters.Add("@puserid", SqlDbType.VarChar);
                com.Parameters["@puserid"].Value = userid;

                com.Parameters.Add("@pdateformat", SqlDbType.VarChar);
                com.Parameters["@pdateformat"].Value = dateformat;

                com.Parameters.Add("@padtype", SqlDbType.VarChar);
                com.Parameters["@padtype"].Value = adtype;

                com.Parameters.Add("@pextra1", SqlDbType.VarChar);
                com.Parameters["@pextra1"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra2", SqlDbType.VarChar);
                com.Parameters["@pextra2"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra3", SqlDbType.VarChar);
                com.Parameters["@pextra3"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra4", SqlDbType.VarChar);
                com.Parameters["@pextra4"].Value = System.DBNull.Value;

                com.Parameters.Add("@pextra5", SqlDbType.VarChar);
                com.Parameters["@pextra5"].Value = System.DBNull.Value;

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

        public DataSet websp_bindciobookingid1(string dateformat, string tilldate, string fromdate, string publication, string bookingcenter, string revenuecenter, string agencytype, string package, string adtype, string agency, string client, string billstatus, string rate_audit, string billmode, string billcycle, string retainer_name, string executive_name, string branch_name, string ad_category, string district, string taluka, string comcode, string BILL_GEN_PRIOR, string PUB_CENT_HO, string billno, string centerlogin, string fmg_bills, string scheme_type, string userid)
        {
            SqlConnection con;
            SqlCommand com = new SqlCommand();
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();

                com = GetCommand("websp_bind_editionwisegrid", ref con);
                com.CommandTimeout = 0;
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






                com.Parameters.Add("@publication", SqlDbType.VarChar);
                if (publication != "0")
                {


                    com.Parameters["@publication"].Value = publication;
                }
                else
                {
                    com.Parameters["@publication"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@bookingcenter", SqlDbType.VarChar);
                if (bookingcenter != "")
                {

                    com.Parameters["@bookingcenter"].Value = bookingcenter;
                }
                else
                {
                    com.Parameters["@bookingcenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                if (revenuecenter != "")
                {

                    com.Parameters["@revenuecenter"].Value = revenuecenter;
                }
                else
                {
                    com.Parameters["@revenuecenter"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agencytype", SqlDbType.VarChar);
                if (agencytype != "")
                {

                    com.Parameters["@agencytype"].Value = agencytype;
                }
                else
                {
                    com.Parameters["@agencytype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@package", SqlDbType.VarChar);
                if (package != "")
                {
                    com.Parameters["@package"].Value = package;
                }
                else
                {
                    com.Parameters["@package"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                if (adtype != "0")
                {
                    com.Parameters["@adtype"].Value = adtype;
                }
                else
                {
                    com.Parameters["@adtype"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@agency", SqlDbType.VarChar);
                if (agency != "")
                {
                    com.Parameters["@agency"].Value = agency;
                }
                else
                {
                    com.Parameters["@agency"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@client", SqlDbType.VarChar);
                if (client != "")
                {
                    com.Parameters["@client"].Value = client;
                }
                else
                {
                    com.Parameters["@client"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@billstatus", SqlDbType.VarChar);
                if (billstatus != "0")
                {
                    com.Parameters["@billstatus"].Value = billstatus;
                }
                else
                {
                    com.Parameters["@billstatus"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@rate_audit", SqlDbType.VarChar);
                com.Parameters["@rate_audit"].Value = rate_audit;
                com.Parameters.Add("@billmode", SqlDbType.VarChar);
                com.Parameters["@billmode"].Value = System.DBNull.Value;
                com.Parameters.Add("@billcycle", SqlDbType.VarChar);
                if (billcycle == "")
                {
                    com.Parameters["@billcycle"].Value = "0";
                }
                else
                {
                    com.Parameters["@billcycle"].Value = billcycle;
                }




                com.Parameters.Add("@v_retainer_name", SqlDbType.VarChar);
                if (retainer_name != "")
                {
                    com.Parameters["@v_retainer_name"].Value = retainer_name;
                }
                else
                {
                    com.Parameters["@v_retainer_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_executive_name", SqlDbType.VarChar);
                if (executive_name != "")
                {
                    com.Parameters["@v_executive_name"].Value = executive_name;
                }
                else
                {
                    com.Parameters["@v_executive_name"].Value = System.DBNull.Value;
                }




                com.Parameters.Add("@v_branch_name", SqlDbType.VarChar);
                if (branch_name != "-Select Branch-")
                {
                    com.Parameters["@v_branch_name"].Value = branch_name;
                }
                else
                {
                    com.Parameters["@v_branch_name"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_ad_category", SqlDbType.VarChar);
                if (ad_category != "0")
                {
                    com.Parameters["@v_ad_category"].Value = ad_category;
                }
                else
                {
                    com.Parameters["@v_ad_category"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@v_district", SqlDbType.VarChar);
                if (district != "0")
                {
                    com.Parameters["@v_district"].Value = district;
                }
                else
                {
                    com.Parameters["@v_district"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@v_taluka", SqlDbType.VarChar);
                if (taluka != "0")
                {
                    com.Parameters["@v_taluka"].Value = taluka;
                }
                else
                {
                    com.Parameters["@v_taluka"].Value = System.DBNull.Value;
                }

                com.Parameters.Add("@pcompcode", SqlDbType.VarChar);
                com.Parameters["@pcompcode"].Value = comcode;


                com.Parameters.Add("@billno", SqlDbType.VarChar);
                if (billno != "")
                {
                    com.Parameters["@billno"].Value = billno;
                }
                else
                {
                    com.Parameters["@billno"].Value = System.DBNull.Value;
                }


                com.Parameters.Add("@BILL_GEN_PRIOR", SqlDbType.VarChar);
                if (BILL_GEN_PRIOR == "")
                {
                    com.Parameters["@BILL_GEN_PRIOR"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@BILL_GEN_PRIOR"].Value = BILL_GEN_PRIOR;
                }


                com.Parameters.Add("@PUB_CENT_HO", SqlDbType.VarChar);
                if (PUB_CENT_HO == "")
                {
                    com.Parameters["@PUB_CENT_HO"].Value = System.DBNull.Value;
                }
                else
                {
                    com.Parameters["@PUB_CENT_HO"].Value = PUB_CENT_HO;
                }


                com.Parameters.Add("@centerlogin", SqlDbType.VarChar);
                com.Parameters["@centerlogin"].Value = centerlogin;



                com.Parameters.Add("@fmg_bills", SqlDbType.VarChar);
                com.Parameters["@fmg_bills"].Value = fmg_bills;




                com.Parameters.Add("@scheme_type", SqlDbType.VarChar);
                com.Parameters["@scheme_type"].Value = scheme_type;

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
    }
}