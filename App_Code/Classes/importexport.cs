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
/// Summary description for importexport
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class importexport:connection
    {
        public importexport()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet getData(string adtype, string fromdate, string todate, string dateformat, string solo, string ratecode, string pubcent, string edition, string packagecode, string adcategary, string uom)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getData_Export", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlDataAdapter = new SqlDataAdapter();
                objSqlCommand.Parameters.Add("@adtype_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype_p"].Value = adtype;

                objSqlCommand.Parameters.Add("@fromdate_p", SqlDbType.VarChar);
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
                objSqlCommand.Parameters["@fromdate_p"].Value = fromdate;

                objSqlCommand.Parameters.Add("@todate_p", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    todate = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@todate_p"].Value = todate;

                objSqlCommand.Parameters.Add("@p_solo", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_solo"].Value = solo;


                objSqlCommand.Parameters.Add("@p_ratecode", SqlDbType.VarChar);
                if (ratecode == "")
                {
                    objSqlCommand.Parameters["@p_ratecode"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@p_ratecode"].Value = ratecode;
                }




                objSqlCommand.Parameters.Add("@p_pubcent", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_pubcent"].Value = pubcent;


                objSqlCommand.Parameters.Add("@pedtn_flag", SqlDbType.VarChar);
                if (edition == "")
                {
                    objSqlCommand.Parameters["@pedtn_flag"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pedtn_flag"].Value = edition;
                }

               

                //objSqlCommand.Parameters.Add("@p_packagecode", SqlDbType.VarChar);
                //if (edition == "")
                //{
                //    objSqlCommand.Parameters["@p_packagecode"].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@p_packagecode"].Value = edition;
                //}


                objSqlCommand.Parameters.Add("@p_packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_packagecode"].Value = System.DBNull.Value;




                objSqlCommand.Parameters.Add("@padcatg", SqlDbType.VarChar);
                if (adcategary == "")
                {
                    objSqlCommand.Parameters["@padcatg"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@padcatg"].Value = adcategary;
                }






                //objSqlCommand.Parameters.Add("@puom_code ", SqlDbType.VarChar);
                //if (edition == "")
                //{
                //    objSqlCommand.Parameters["@puom_code "].Value = System.DBNull.Value;
                //}
                //else
                //{
                //    objSqlCommand.Parameters["@puom_code "].Value = edition;
                //}


                objSqlCommand.Parameters.Add("@puom_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puom_code"].Value = System.DBNull.Value;




                objSqlCommand.Parameters.Add("@pextra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra2"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@pextra3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pextra3"].Value = System.DBNull.Value;

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
        //======================================**** Insert into Rate Detail form Excel ****=================================//
        public DataSet InsertRatedetailfrExcel(string compcode, string packagecode, string weekrate, string focusrate, string txtratecode, string drpadtype, string drpadcategory, string drpsubcategory, string drpcolor, string drpcurrency, string validfromdate1, string validtill1, string weekendrate, string decimalvalue, string uom, string adscat4, string adscat5, string adscat6, string premium, string sizefrom, string sizeto, string frominsert, string toinsert, string clientcat, string minadarea, string type, string agencycode, string dateformat, string pubcenter, string rate_sun, string rate_mon, string rate_tue, string rate_wed, string rate_thu, string rate_fri, string rate_sat, string rate_sun_extra, string rate_mon_extra, string rate_tue_extra, string rate_wed_extra, string rate_thu_extra, string rate_fri_extra, string rate_sat_extra, string extrarate, string rateid, string userid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("rate_grid_from_detail", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = packagecode;


                objSqlCommand.Parameters.Add("@txtratecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@txtratecode"].Value = txtratecode;

                objSqlCommand.Parameters.Add("@drpadtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadtype"].Value = drpadtype;

                objSqlCommand.Parameters.Add("@drpadcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpadcategory"].Value = drpadcategory;

                objSqlCommand.Parameters.Add("@drpsubcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpsubcategory"].Value = drpsubcategory;

                objSqlCommand.Parameters.Add("@drpcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcolor"].Value = drpcolor;

                objSqlCommand.Parameters.Add("@drpcurrency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpcurrency"].Value = drpcurrency;


                objSqlCommand.Parameters.Add("@validfromdate1", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validfromdate1 = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = validfromdate1.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validfromdate1 = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@validfromdate1"].Value = validfromdate1;

                objSqlCommand.Parameters.Add("@validtill1", SqlDbType.VarChar);
                if (dateformat == "dd/mm/yyyy")
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    validtill1 = mm + "/" + dd + "/" + yy;
                }
                else if (dateformat == "yyyy/mm/dd")
                {
                    string[] arr = validtill1.Split('/');
                    string dd = arr[2];
                    string mm = arr[1];
                    string yy = arr[0];
                    validtill1 = mm + "/" + dd + "/" + yy;
                }
                objSqlCommand.Parameters["@validtill1"].Value = validtill1;



                objSqlCommand.Parameters.Add("@weekrate", SqlDbType.Decimal);
                if (weekrate == "" || weekrate == null)
                {
                    objSqlCommand.Parameters["@weekrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekrate"].Value = Convert.ToDecimal(weekrate);
                }

                objSqlCommand.Parameters.Add("@focusrate", SqlDbType.Decimal);
                if (focusrate == "" || focusrate == null)
                {
                    objSqlCommand.Parameters["@focusrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@focusrate"].Value = Convert.ToDecimal(focusrate);
                }

                objSqlCommand.Parameters.Add("@weekendrate", SqlDbType.Decimal);
                if (weekendrate == "" || weekendrate == null)
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@weekendrate"].Value = Convert.ToDecimal(weekendrate);
                }

                objSqlCommand.Parameters.Add("@decimalvalue", SqlDbType.Int);
                if (decimalvalue == "" || decimalvalue == null)
                {
                    objSqlCommand.Parameters["@decimalvalue"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@decimalvalue"].Value = Convert.ToInt32(decimalvalue);
                }


                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@adscat6", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat6"].Value = adscat6;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@premium", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium"].Value = premium;

                objSqlCommand.Parameters.Add("@sizefrom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizefrom"].Value = sizefrom;


                objSqlCommand.Parameters.Add("@sizeto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sizeto"].Value = sizeto;

                objSqlCommand.Parameters.Add("@frominsert", SqlDbType.VarChar);

                objSqlCommand.Parameters["@frominsert"].Value = frominsert;


                objSqlCommand.Parameters.Add("@toinsert", SqlDbType.VarChar);

                objSqlCommand.Parameters["@toinsert"].Value = toinsert;


                objSqlCommand.Parameters.Add("@clientcat", SqlDbType.VarChar);

                objSqlCommand.Parameters["@clientcat"].Value = clientcat;



                objSqlCommand.Parameters.Add("@minadarea", SqlDbType.VarChar);
                if (minadarea == "")
                {
                    objSqlCommand.Parameters["@minadarea"].Value = "0";
                }
                else
                {
                    objSqlCommand.Parameters["@minadarea"].Value = minadarea;
                }

                /*new change ankur for agency*/
                objSqlCommand.Parameters.Add("@type", SqlDbType.VarChar);
                objSqlCommand.Parameters["@type"].Value = type;


                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@pubcenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pubcenter"].Value = pubcenter;

                objSqlCommand.Parameters.Add("@pkg_sun_rate", SqlDbType.Decimal);
                if (rate_sun == "")
                    objSqlCommand.Parameters["@pkg_sun_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_sun_rate"].Value = Convert.ToDecimal(rate_sun);

                objSqlCommand.Parameters.Add("@pkg_mon_rate", SqlDbType.Decimal);
                if (rate_mon == "")
                    objSqlCommand.Parameters["@pkg_mon_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_mon_rate"].Value = Convert.ToDecimal(rate_mon);

                objSqlCommand.Parameters.Add("@pkg_tue_rate", SqlDbType.Decimal);
                if (rate_tue == "")
                    objSqlCommand.Parameters["@pkg_tue_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_tue_rate"].Value = Convert.ToDecimal(rate_tue);

                objSqlCommand.Parameters.Add("@pkg_wed_rate", SqlDbType.Decimal);
                if (rate_wed == "")
                    objSqlCommand.Parameters["@pkg_wed_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_wed_rate"].Value = Convert.ToDecimal(rate_wed);

                objSqlCommand.Parameters.Add("@pkg_thu_rate", SqlDbType.Decimal);
                if (rate_thu == "")
                    objSqlCommand.Parameters["@pkg_thu_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_thu_rate"].Value = Convert.ToDecimal(rate_thu);


                objSqlCommand.Parameters.Add("@pkg_fri_rate", SqlDbType.Decimal);
                if (rate_fri == "")
                    objSqlCommand.Parameters["@pkg_fri_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_fri_rate"].Value = Convert.ToDecimal(rate_fri);

                objSqlCommand.Parameters.Add("@pkg_sat_rate", SqlDbType.Decimal);
                if (rate_sat == "")
                    objSqlCommand.Parameters["@pkg_sat_rate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_sat_rate"].Value = Convert.ToDecimal(rate_sat);


                /////////////////////////////////////////////////////////
                objSqlCommand.Parameters.Add("@pkg_sun_rate_ex", SqlDbType.Decimal);
                if (rate_sun_extra == "")
                    objSqlCommand.Parameters["@pkg_sun_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_sun_rate_ex"].Value = Convert.ToDecimal(rate_sun_extra);

                objSqlCommand.Parameters.Add("@pkg_mon_rate_ex", SqlDbType.Decimal);
                if (rate_mon_extra == "")
                    objSqlCommand.Parameters["@pkg_mon_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_mon_rate_ex"].Value = Convert.ToDecimal(rate_mon_extra);

                objSqlCommand.Parameters.Add("@pkg_tue_rate_ex", SqlDbType.Decimal);
                if (rate_tue_extra == "")
                    objSqlCommand.Parameters["@pkg_tue_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_tue_rate_ex"].Value = Convert.ToDecimal(rate_tue_extra);

                objSqlCommand.Parameters.Add("@pkg_wed_rate_ex", SqlDbType.Decimal);
                if (rate_wed_extra == "")
                    objSqlCommand.Parameters["@pkg_wed_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_wed_rate_ex"].Value = Convert.ToDecimal(rate_wed_extra);

                objSqlCommand.Parameters.Add("@pkg_thu_rate_ex", SqlDbType.Decimal);
                if (rate_thu_extra == "")
                    objSqlCommand.Parameters["@pkg_thu_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_thu_rate_ex"].Value = Convert.ToDecimal(rate_thu_extra);


                objSqlCommand.Parameters.Add("@pkg_fri_rate_ex", SqlDbType.Decimal);
                if (rate_fri_extra == "")
                    objSqlCommand.Parameters["@pkg_fri_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_fri_rate_ex"].Value = Convert.ToDecimal(rate_fri_extra);

                objSqlCommand.Parameters.Add("@pkg_sat_rate_ex", SqlDbType.Decimal);
                if (rate_sat_extra == "")
                    objSqlCommand.Parameters["@pkg_sat_rate_ex"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@pkg_sat_rate_ex"].Value = Convert.ToDecimal(rate_sat_extra);

                objSqlCommand.Parameters.Add("@extrarate", SqlDbType.Decimal);
                if (extrarate == "")
                    objSqlCommand.Parameters["@extrarate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@extrarate"].Value = Convert.ToDecimal(extrarate);

                objSqlCommand.Parameters.Add("@ratemastid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratemastid"].Value = rateid;

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


        

        public DataSet advcategory(string compcode, string adtype)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            NewAdbooking.Classes.connection clscon = new NewAdbooking.Classes.connection();
            objSqlConnection = clscon.GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = clscon.GetCommand("adcategory", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@adtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype"].Value = adtype;

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
                clscon.CloseConnection(ref objSqlConnection);
            }
        }
    }
}
