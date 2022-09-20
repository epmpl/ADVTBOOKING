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
/// Summary description for billnorevised
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class billnorevised : connection
    {
        public billnorevised()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void insertCioDetail(string billno, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();

            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertCioDetailinTemp", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@billno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billno"].Value = billno;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.ExecuteNonQuery();

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
        public DataSet getBill(string billno,string COMPCODE)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getBillNoBooking_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@billno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billno"].Value = billno;

                objSqlCommand.Parameters.Add("@PCOMPCODE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@PCOMPCODE"].Value = COMPCODE;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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
        public DataSet insertbook_ins_Bill_Classified(string insertdate, string edition, string premium1, string premium2, string premallow, string adcategory, string latestdate, string material, string cardrate, string matfilename, string discrate, string insertstatus, string billstatus, string adsubcat, string compcode, string userid, string cioid, string height, string width, string totalsize, string pagepost, string premper1, string premper2, string colid, string repeat, string insertno, string paid, string agrrate, string solorate, string grossrate, string insert_pageno, string insert_remarks, string page_code, string page_per, string noofcol, string billamt, string billrate, string logo_h, string logo_w, string logo_name, string dateformat, string adcat3, string adcat4, string adcat5, string pkgcode, string gridins, string pkgalias, string insertid, string oldbillno, string oldbilldate, string cirvts, string cirpub, string ciredi, string cirrate, string cirdate, string ciragency, string ciragencysubcode, string center, string branch, string splboldsizevalue, string vatrate, string boxcharge, string vat_inc_p, string grossamtlocal_p, string billamtlocal_p, string sectioncode_p, string resourceno_p, string caption_inserts, string dealerheight, string dealerwidth, string subedidata)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("insertintobookchild_Bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@insertdate", SqlDbType.DateTime);
                if (insertdate == "" || insertdate == null || insertdate == "null")
                {
                    objSqlCommand.Parameters["@insertdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        insertdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = insertdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        insertdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@insertdate"].Value = Convert.ToDateTime(insertdate);
                }
                objSqlCommand.Parameters.Add("@edition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@edition"].Value = edition;

                objSqlCommand.Parameters.Add("@premium1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium1"].Value = premium1;

                objSqlCommand.Parameters.Add("@premium2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premium2"].Value = premium2;

                objSqlCommand.Parameters.Add("@premallow", SqlDbType.VarChar);
                objSqlCommand.Parameters["@premallow"].Value = premallow;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@latestdate", SqlDbType.DateTime);
                if (latestdate == "" || latestdate == null || latestdate == "null")
                {
                    objSqlCommand.Parameters["@latestdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        latestdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = latestdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        latestdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@latestdate"].Value = Convert.ToDateTime(latestdate);
                }
                //,,,,,,,,,,,,,

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null || cardrate == "null")
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@matfilename", SqlDbType.VarChar);
                objSqlCommand.Parameters["@matfilename"].Value = matfilename;

                objSqlCommand.Parameters.Add("@discrate", SqlDbType.Decimal);
                if (discrate == "" || discrate == null || discrate == "null")
                {
                    objSqlCommand.Parameters["@discrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discrate"].Value = Convert.ToDecimal(discrate);
                }

                objSqlCommand.Parameters.Add("@insertstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertstatus"].Value = insertstatus;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@adsubcat1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsubcat1"].Value = adsubcat;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;


                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

                objSqlCommand.Parameters.Add("@height", SqlDbType.Decimal);
                if (height == "" || height == null || height == "null")
                {
                    objSqlCommand.Parameters["@height"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@height"].Value = Convert.ToDecimal(height);
                }

                objSqlCommand.Parameters.Add("@width", SqlDbType.Decimal);
                if (width == "" || width == null || width == "null")
                {
                    objSqlCommand.Parameters["@width"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@width"].Value = Convert.ToDecimal(width);
                }

                objSqlCommand.Parameters.Add("@totalsize", SqlDbType.Decimal);
                if (totalsize == "" || totalsize == null || totalsize == "null")
                {
                    objSqlCommand.Parameters["@totalsize"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totalsize"].Value = Convert.ToDecimal(totalsize);
                }

                objSqlCommand.Parameters.Add("@pagepost", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagepost"].Value = pagepost;

                objSqlCommand.Parameters.Add("@premper1", SqlDbType.Decimal);
                if (premper1 == "" || premper1 == null || premper1 == "null")
                {
                    objSqlCommand.Parameters["@premper1"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper1"].Value = Convert.ToDecimal(premper1);
                }

                objSqlCommand.Parameters.Add("@premper2", SqlDbType.Decimal);
                if (premper2 == "" || premper2 == null || premper2 == "null")
                {
                    objSqlCommand.Parameters["@premper2"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper2"].Value = Convert.ToDecimal(premper2);
                }

                objSqlCommand.Parameters.Add("@colid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@colid"].Value = colid;

                objSqlCommand.Parameters.Add("@repeat", SqlDbType.DateTime);
                if (repeat == "" || repeat == null || repeat == "null")
                {
                    objSqlCommand.Parameters["@repeat"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        repeat = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = repeat.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        repeat = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@repeat"].Value = Convert.ToDateTime(repeat);
                }




                objSqlCommand.Parameters.Add("@insertno", SqlDbType.Int);
                if (insertno == "" || insertno == null || insertno == "null")
                {
                    objSqlCommand.Parameters["@insertno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertno"].Value = Convert.ToInt32(insertno);
                }

                objSqlCommand.Parameters.Add("@paid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paid"].Value = paid;

                objSqlCommand.Parameters.Add("@agrrate", SqlDbType.Decimal);
                if (agrrate == "" || agrrate == null || agrrate == "null")
                {
                    objSqlCommand.Parameters["@agrrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agrrate"].Value = Convert.ToDecimal(agrrate);
                }

                objSqlCommand.Parameters.Add("@solorate", SqlDbType.Decimal);
                if (solorate == "" || solorate == null || solorate == "null")
                {
                    objSqlCommand.Parameters["@solorate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@solorate"].Value = Convert.ToDecimal(solorate);
                }

                objSqlCommand.Parameters.Add("@grossrate", SqlDbType.Decimal);
                if (grossrate == "" || grossrate == null || grossrate == "null")
                {
                    objSqlCommand.Parameters["@grossrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossrate"].Value = Convert.ToDecimal(grossrate);
                }

                objSqlCommand.Parameters.Add("@insert_remarks", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insert_remarks"].Value = insert_remarks;

                objSqlCommand.Parameters.Add("@insert_pageno", SqlDbType.Int);
                if (insert_pageno == "" || insert_pageno == null || insert_pageno == "null")
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32("0");
                }
                else
                {
                    objSqlCommand.Parameters["@insert_pageno"].Value = Convert.ToInt32(insert_pageno);
                }

                objSqlCommand.Parameters.Add("@page_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@page_code"].Value = page_code;

                objSqlCommand.Parameters.Add("@page_per", SqlDbType.Decimal);
                if (page_per == "" || page_per == null || page_per == "null")
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal("0");
                }
                else
                {
                    objSqlCommand.Parameters["@page_per"].Value = Convert.ToDecimal(page_per);
                }

                objSqlCommand.Parameters.Add("@noofcol", SqlDbType.Decimal);
                if (noofcol == "" || noofcol == null || noofcol == "null")
                {
                    objSqlCommand.Parameters["@noofcol"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@noofcol"].Value = Convert.ToDecimal(noofcol);
                }

                objSqlCommand.Parameters.Add("@billamt", SqlDbType.Decimal);
                if (billamt == "" || billamt == null || billamt == "null")
                {
                    objSqlCommand.Parameters["@billamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billamt"].Value = Convert.ToDecimal(billamt);
                }


                objSqlCommand.Parameters.Add("@billrate", SqlDbType.Decimal);
                if (billrate == "" || billrate == null || billrate == "null")
                {
                    objSqlCommand.Parameters["@billrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billrate"].Value = Convert.ToDecimal(billrate);
                }

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_name"].Value = logo_name;

                objSqlCommand.Parameters.Add("@ad_cat_3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_3"].Value = adcat3;

                objSqlCommand.Parameters.Add("@ad_cat_4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_4"].Value = adcat4;

                objSqlCommand.Parameters.Add("@ad_cat_5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ad_cat_5"].Value = adcat5;

                objSqlCommand.Parameters.Add("@pkgcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgcode"].Value = pkgcode;

                objSqlCommand.Parameters.Add("@gridins", SqlDbType.Int);
                if (gridins == "" || gridins == null || gridins == "null")
                {
                    objSqlCommand.Parameters["@gridins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@gridins"].Value = gridins;
                }

                objSqlCommand.Parameters.Add("@pkgalias", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pkgalias"].Value = pkgalias;

                objSqlCommand.Parameters.Add("@oldbillno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@oldbillno"].Value = oldbillno;

                objSqlCommand.Parameters.Add("@oldbilldate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@oldbilldate"].Value = oldbilldate;

                objSqlCommand.Parameters.Add("@insertid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@insertid"].Value = insertid;

                 objSqlCommand.Parameters.Add("@cirvts", SqlDbType.VarChar);
                if (cirvts == "null" || cirvts == null)
                    objSqlCommand.Parameters["@cirvts"].Value= System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirvts"].Value = cirvts;
                

                objSqlCommand.Parameters.Add("@cirpub", SqlDbType.VarChar);
                if (cirpub == "null" || cirpub == null)
                     objSqlCommand.Parameters["@cirpub"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirpub"].Value = cirpub;
               

                objSqlCommand.Parameters.Add("@ciredi", SqlDbType.VarChar);
                if (ciredi == "null" || ciredi == null)
                    objSqlCommand.Parameters["@ciredi"].Value =  System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@ciredi"].Value = ciredi;
                

                objSqlCommand.Parameters.Add("@cirrate", SqlDbType.VarChar);
                if (cirrate == "null" && cirrate == null)
                    objSqlCommand.Parameters["@cirrate"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@cirrate"].Value = cirrate;

                objSqlCommand.Parameters.Add("@cirdate_v", SqlDbType.VarChar);
                if (cirdate == "" || cirdate == null || cirdate == "null")
                {
                    objSqlCommand.Parameters["@cirdate_v"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = cirdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        cirdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@cirdate_v"].Value = Convert.ToDateTime(cirdate);
                }



                objSqlCommand.Parameters.Add("@ciragency_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragency_v"].Value = ciragency;

                objSqlCommand.Parameters.Add("@ciragencysubcode_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciragencysubcode_v"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@center_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@center_v"].Value = center;

                objSqlCommand.Parameters.Add("@branch_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch_v"].Value = branch;

                objSqlCommand.Parameters.Add("@splboldsizevalue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@splboldsizevalue"].Value = splboldsizevalue;

                objSqlCommand.Parameters.Add("@vatrate_p", SqlDbType.VarChar);

                if (vatrate == "" || vatrate == "undefined" || vatrate == "null" || vatrate == null)
                    objSqlCommand.Parameters["@vatrate_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vatrate_p"].Value = Convert.ToDecimal(vatrate);


                objSqlCommand.Parameters.Add("@boxcharge_p", SqlDbType.Float);
                if (boxcharge == "" || boxcharge == "null" || boxcharge == null || boxcharge == "0")
                    objSqlCommand.Parameters["@boxcharge_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@boxcharge_p"].Value = Convert.ToDecimal(boxcharge);

                objSqlCommand.Parameters.Add("@vat_inc_p", SqlDbType.Float);
                if (vat_inc_p == "" || vat_inc_p == "null" || vat_inc_p == null)
                    objSqlCommand.Parameters["@vat_inc_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@vat_inc_p"].Value = vat_inc_p;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.Float);
                if (grossamtlocal_p == "" || grossamtlocal_p == "null" || grossamtlocal_p == null)
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.Float);
                if (billamtlocal_p == "" || billamtlocal_p == "null" || billamtlocal_p == null)
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;

                objSqlCommand.Parameters.Add("@sectioncode_p", SqlDbType.VarChar);
                if (sectioncode_p == "" || sectioncode_p == "null" || sectioncode_p == null)
                    objSqlCommand.Parameters["@sectioncode_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@sectioncode_p"].Value = sectioncode_p;

                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.VarChar);
                if (resourceno_p == "" || resourceno_p == "null" || resourceno_p == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = resourceno_p;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.VarChar);
                if (caption_inserts == "" || caption_inserts == "null" || caption_inserts == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = caption_inserts;

                objSqlCommand.Parameters.Add("@resourceno_p", SqlDbType.Decimal);
                if (dealerheight == "" || dealerheight == "null" || dealerheight == null)
                    objSqlCommand.Parameters["@resourceno_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@resourceno_p"].Value = dealerheight;

                objSqlCommand.Parameters.Add("@caption_inserts_p", SqlDbType.Decimal);
                if (dealerwidth == "" || dealerwidth == "null" || dealerwidth == null)
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@caption_inserts_p"].Value = dealerwidth;

                objSqlCommand.Parameters.Add("@subedidata", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subedidata"].Value = subedidata;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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
        public DataSet executebooking_bill(string compcode, string ciobookid, string docno, string keyno, string rono, string agencycode, string client, string booking, string dateformat, string revenue)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("executebookingdispbill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;

                objSqlCommand.Parameters.Add("@docno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@docno"].Value = docno;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@booking", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booking"].Value = booking;

                objSqlCommand.Parameters.Add("@dateformat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dateformat"].Value = dateformat;

                objSqlCommand.Parameters.Add("@revenue", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenue"].Value = revenue;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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
        public DataSet fetchdataforexeBill(string ciobid, string compcode)
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
                objSqlCommand = GetCommand("getdataforexecuteBill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ciobid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobid"].Value = ciobid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;


            }
            catch (SqlException objException)
            {
                throw (objException);
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

        public DataSet getPackageInsertBILL(string pckcode, string cioid)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Getpackageinsert_BILL", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Parameters.Add("@packagecode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@packagecode"].Value = pckcode;

                objSqlCommand.Parameters.Add("@cioid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cioid"].Value = cioid;

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
        public DataSet updatebookingdisp_bill(string adsizetype, string branch, string booked_by, string prevbook, string date_time, string ciobookid, string approvedby, string audit, string rono, string rodate, string caption, string billstatus, string rostatus, string agency, string client, string agencyaddress, string clientaddresses, string agencycode, string dockitno, string execname, string execzone, string product, string brand, string keyno, string billremark, string printremark, string package, string insertion, string startdate, string repeatdate, string adtype, string adcategory, string subcategory, string color, string uom, string pageposition, string pagetype, string pageno, string adsizheight, string adsizwidth, string ratecode, string scheme, string currency, string agreedrate, string agreedamt, string spedisc, string spacedisx, string compcode, string userid, string specialcharges, string agencytype, string agencystatus, string paymode, string agencredit, string cardrate, string cardamount, string discount, string discountper, string billaddress, string totarea, string billcycle, string revenuecenter, string billpay, string billheight, string billwidth, string billto, string invoices, string vts, string tradedisc, string agencyout, string boxcode, string boxno, string boxaddress, string boxagency, string boxclient, string bookingtype, string tfn, string coupan, string campaign, string bill_amt, string pageprem, string pageamt, string premper, string grossamt, string adsizcolumn, string billcolumn, Decimal billarea, string specdiscper, string spacediscper, string paidins, string dealrate, string deviation, string varient, string contractname, string dealtype, string cardname, string cardtype, string cardmonth, string cardyear, string cardno, string receiptno, string adscat3, string adscat4, string adscat5, string bgcolor, string bulletcode, string bulletprm, string material, string region, string varient_name, string coltype, string logo_h, string logo_w, string logo_col, string logo_uom, string status, string dateformat, string retainer, string addagencyrate, string mobileno, string addlamt, string retamt, string retper, string cashrecieved, string ciragency, string cirrate, string ciredition, string cirpublication, string ciragencysubcode, string bartertype, string cashdiscount, string cashdiscper, string attach1, string attach2, string drpdiscprem, string doctype, string chktradeval, string sharepub, string fmginsert, string chkno, string chkdate, string chkamt, string chkbankname, string ourbank, string dealerpanel, string dealerh, string dealerw, string dealertype, string multicode, string agreedrate_active, string agreedamt_active, string grossamtlocal_p, string billamtlocal_p, string chkadon, string refid, string rcpt_currency, string cur_convrate, string revisedate, string clienttype, string translation, string translationcharge, string fmgreasons, string canclecharge)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("updatebooking_bill", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@approvedby", SqlDbType.VarChar);
                objSqlCommand.Parameters["@approvedby"].Value = approvedby;

                objSqlCommand.Parameters.Add("@audit1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@audit1"].Value = audit;

                objSqlCommand.Parameters.Add("@rono", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rono"].Value = rono;

                objSqlCommand.Parameters.Add("@rodate", SqlDbType.DateTime);
                if (rodate == "" || rodate == null)
                {
                    objSqlCommand.Parameters["@rodate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = rodate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        rodate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@rodate"].Value = rodate;
                }

                objSqlCommand.Parameters.Add("@caption", SqlDbType.VarChar);
                objSqlCommand.Parameters["@caption"].Value = caption;

                objSqlCommand.Parameters.Add("@billstatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billstatus"].Value = billstatus;

                objSqlCommand.Parameters.Add("@rostatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rostatus"].Value = rostatus;

                objSqlCommand.Parameters.Add("@agency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agency"].Value = agency;

                objSqlCommand.Parameters.Add("@client", SqlDbType.VarChar);
                objSqlCommand.Parameters["@client"].Value = client;

                objSqlCommand.Parameters.Add("@agencyaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyaddress"].Value = agencyaddress;

                objSqlCommand.Parameters.Add("@clientaddresses", SqlDbType.VarChar);
                objSqlCommand.Parameters["@clientaddresses"].Value = clientaddresses;

                objSqlCommand.Parameters.Add("@agencycode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencycode"].Value = agencycode;

                objSqlCommand.Parameters.Add("@dockitno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dockitno"].Value = dockitno;

                objSqlCommand.Parameters.Add("@execname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execname"].Value = execname;

                objSqlCommand.Parameters.Add("@execzone", SqlDbType.VarChar);
                objSqlCommand.Parameters["@execzone"].Value = execzone;

                objSqlCommand.Parameters.Add("@product", SqlDbType.VarChar);
                objSqlCommand.Parameters["@product"].Value = product;

                objSqlCommand.Parameters.Add("@brand", SqlDbType.VarChar);
                objSqlCommand.Parameters["@brand"].Value = brand;

                objSqlCommand.Parameters.Add("@keyno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@keyno"].Value = keyno;

                objSqlCommand.Parameters.Add("@billremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billremark"].Value = billremark;

                objSqlCommand.Parameters.Add("@printremark", SqlDbType.VarChar);
                objSqlCommand.Parameters["@printremark"].Value = printremark;

                objSqlCommand.Parameters.Add("@package1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@package1"].Value = package;

                objSqlCommand.Parameters.Add("@insertion", SqlDbType.Int);
                if (insertion == "" || insertion == null)
                {
                    objSqlCommand.Parameters["@insertion"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@insertion"].Value = Convert.ToInt32(insertion);
                }

                objSqlCommand.Parameters.Add("@startdate", SqlDbType.DateTime);
                if (startdate == "" || startdate == null)
                {
                    objSqlCommand.Parameters["@startdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = startdate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        startdate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@startdate"].Value = startdate;
                }

                objSqlCommand.Parameters.Add("@repeatdate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@repeatdate"].Value = repeatdate;

                objSqlCommand.Parameters.Add("@adtype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adtype1"].Value = adtype;

                objSqlCommand.Parameters.Add("@adcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adcategory"].Value = adcategory;

                objSqlCommand.Parameters.Add("@subcategory", SqlDbType.VarChar);
                objSqlCommand.Parameters["@subcategory"].Value = subcategory;

                objSqlCommand.Parameters.Add("@color", SqlDbType.VarChar);
                objSqlCommand.Parameters["@color"].Value = color;

                objSqlCommand.Parameters.Add("@uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@uom"].Value = uom;

                objSqlCommand.Parameters.Add("@pageposition", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageposition"].Value = pageposition;

                objSqlCommand.Parameters.Add("@pagetype1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pagetype1"].Value = pagetype;

                objSqlCommand.Parameters.Add("@pageno", SqlDbType.Int);
                if (pageno == "" || pageno == null)
                {
                    objSqlCommand.Parameters["@pageno"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageno"].Value = Convert.ToInt32(pageno);
                }

                objSqlCommand.Parameters.Add("@adsizheight", SqlDbType.Decimal);
                if (adsizheight == "" || adsizheight == null)
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizheight"].Value = Convert.ToDecimal(adsizheight);
                }

                objSqlCommand.Parameters.Add("@adsizwidth", SqlDbType.Decimal);
                if (adsizwidth == "" || adsizwidth == null)
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizwidth"].Value = Convert.ToDecimal(adsizwidth);
                }

                objSqlCommand.Parameters.Add("@ratecode11", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ratecode11"].Value = ratecode;

                objSqlCommand.Parameters.Add("@scheme1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@scheme1"].Value = scheme;

                objSqlCommand.Parameters.Add("@currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@currency"].Value = currency;

                objSqlCommand.Parameters.Add("@agreedrate", SqlDbType.Decimal);
                if (agreedrate == "" || agreedrate == null)
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedrate"].Value = Convert.ToDecimal(agreedrate);
                }
                //    , , ,Session["compcode"].ToString(),Session["userid"].ToString()
                objSqlCommand.Parameters.Add("@agreedamt", SqlDbType.Decimal);
                if (agreedamt == "" || agreedamt == null)
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agreedamt"].Value = Convert.ToDecimal(agreedamt);
                }

                objSqlCommand.Parameters.Add("@spedisc", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spedisc"].Value = Convert.ToDecimal(spedisc);
                }
                objSqlCommand.Parameters.Add("@spacedisx", SqlDbType.Decimal);
                if (spedisc == "" || spedisc == null)
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacedisx"].Value = Convert.ToDecimal(spacedisx);
                }

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@ciobookid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ciobookid"].Value = ciobookid;


                objSqlCommand.Parameters.Add("@date_time", SqlDbType.DateTime);
                if (date_time == "" || date_time == null)
                {
                    objSqlCommand.Parameters["@date_time"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = date_time.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        date_time = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@date_time"].Value = date_time;
                }

                objSqlCommand.Parameters.Add("@branch", SqlDbType.VarChar);
                objSqlCommand.Parameters["@branch"].Value = branch;

                objSqlCommand.Parameters.Add("@booked_by", SqlDbType.VarChar);
                objSqlCommand.Parameters["@booked_by"].Value = booked_by;

                objSqlCommand.Parameters.Add("@prevbook", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prevbook"].Value = prevbook;

                objSqlCommand.Parameters.Add("@adsizetype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adsizetype"].Value = adsizetype;

                objSqlCommand.Parameters.Add("@specialcharges", SqlDbType.Decimal);
                if (specialcharges == "" || specialcharges == null)
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specialcharges"].Value = Convert.ToDecimal(specialcharges);
                }

                objSqlCommand.Parameters.Add("@agencytype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencytype"].Value = agencytype;

                objSqlCommand.Parameters.Add("@agencystatus", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencystatus"].Value = agencystatus;

                objSqlCommand.Parameters.Add("@paymode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@paymode"].Value = paymode;

                objSqlCommand.Parameters.Add("@agencredit", SqlDbType.Int);
                if (agencredit == "" || agencredit == null)
                {
                    objSqlCommand.Parameters["@agencredit"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@agencredit"].Value = Convert.ToInt32(agencredit);
                }

                objSqlCommand.Parameters.Add("@cardrate", SqlDbType.Decimal);
                if (cardrate == "" || cardrate == null)
                {
                    objSqlCommand.Parameters["@cardrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardrate"].Value = Convert.ToDecimal(cardrate);
                }

                objSqlCommand.Parameters.Add("@cardamount", SqlDbType.Decimal);
                if (cardamount == "" || cardamount == null)
                {
                    objSqlCommand.Parameters["@cardamount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@cardamount"].Value = Convert.ToDecimal(cardamount);
                }

                objSqlCommand.Parameters.Add("@discount", SqlDbType.Decimal);
                if (discount == "" || discount == null)
                {
                    objSqlCommand.Parameters["@discount"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discount"].Value = Convert.ToDecimal(discount);
                }


                objSqlCommand.Parameters.Add("@discountper", SqlDbType.Decimal);
                if (discountper == "" || discountper == null)
                {
                    objSqlCommand.Parameters["@discountper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@discountper"].Value = Convert.ToDecimal(discountper);
                }

                objSqlCommand.Parameters.Add("@billaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billaddress"].Value = billaddress;

                objSqlCommand.Parameters.Add("@totarea", SqlDbType.Decimal);
                if (totarea == "" || totarea == null)
                {
                    objSqlCommand.Parameters["@totarea"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@totarea"].Value = Convert.ToDecimal(totarea);
                }


                objSqlCommand.Parameters.Add("@billcycle", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billcycle"].Value = billcycle;

                objSqlCommand.Parameters.Add("@revenuecenter", SqlDbType.VarChar);
                objSqlCommand.Parameters["@revenuecenter"].Value = revenuecenter;

                objSqlCommand.Parameters.Add("@billpay", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billpay"].Value = billpay;

                objSqlCommand.Parameters.Add("@billheight", SqlDbType.Decimal);
                if (billheight == "" || billheight == null)
                {
                    objSqlCommand.Parameters["@billheight"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billheight"].Value = Convert.ToDecimal(billheight);
                }

                objSqlCommand.Parameters.Add("@billwidth", SqlDbType.Decimal);
                if (billwidth == "" || billwidth == null)
                {
                    objSqlCommand.Parameters["@billwidth"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billwidth"].Value = Convert.ToDecimal(billwidth);
                }

                //////, , , , , , , , , , , , , , , , , , , 

                objSqlCommand.Parameters.Add("@billto", SqlDbType.VarChar);
                objSqlCommand.Parameters["@billto"].Value = billto;

                objSqlCommand.Parameters.Add("@invoices", SqlDbType.Int);
                if (invoices == "" || invoices == null)
                {
                    objSqlCommand.Parameters["@invoices"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@invoices"].Value = Convert.ToInt32(invoices);
                }

                objSqlCommand.Parameters.Add("@vts", SqlDbType.Int);
                if (vts == "" || vts == null)
                {
                    objSqlCommand.Parameters["@vts"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@vts"].Value = Convert.ToInt32(vts);
                }

                objSqlCommand.Parameters.Add("@tradedisc", SqlDbType.Decimal);
                if (tradedisc == "" || tradedisc == null)
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@tradedisc"].Value = Convert.ToDecimal(tradedisc);
                }

                objSqlCommand.Parameters.Add("@agencyout", SqlDbType.VarChar);
                objSqlCommand.Parameters["@agencyout"].Value = agencyout;

                objSqlCommand.Parameters.Add("@boxcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxcode"].Value = boxcode;

                objSqlCommand.Parameters.Add("@boxno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxno"].Value = boxno;

                objSqlCommand.Parameters.Add("@boxaddress", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxaddress"].Value = boxaddress;

                objSqlCommand.Parameters.Add("@boxagency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxagency"].Value = boxagency;

                objSqlCommand.Parameters.Add("@boxclient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@boxclient"].Value = boxclient;

                objSqlCommand.Parameters.Add("@bookingtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bookingtype"].Value = bookingtype;

                objSqlCommand.Parameters.Add("@tfn", SqlDbType.VarChar);
                objSqlCommand.Parameters["@tfn"].Value = tfn;

                objSqlCommand.Parameters.Add("@coupan", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coupan"].Value = coupan;

                objSqlCommand.Parameters.Add("@campaign", SqlDbType.VarChar);
                objSqlCommand.Parameters["@campaign"].Value = campaign;


                objSqlCommand.Parameters.Add("@bill_amt", SqlDbType.Decimal);
                if (bill_amt == "" || bill_amt == null)
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@bill_amt"].Value = Convert.ToDecimal(bill_amt);
                }

                objSqlCommand.Parameters.Add("@pageprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pageprem"].Value = pageprem;


                objSqlCommand.Parameters.Add("@pageamt", SqlDbType.Decimal);
                if (pageamt == "" || pageamt == null)
                {
                    objSqlCommand.Parameters["@pageamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@pageamt"].Value = Convert.ToDecimal(pageamt);
                }

                objSqlCommand.Parameters.Add("@premper", SqlDbType.Decimal);
                if (premper == "" || premper == null)
                {
                    objSqlCommand.Parameters["@premper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@premper"].Value = Convert.ToDecimal(premper);
                }

                objSqlCommand.Parameters.Add("@grossamt", SqlDbType.Decimal);
                if (grossamt == "" || grossamt == null)
                {
                    objSqlCommand.Parameters["@grossamt"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@grossamt"].Value = Convert.ToDecimal(grossamt);
                }

                objSqlCommand.Parameters.Add("@adsizcolumn", SqlDbType.Decimal);
                if (adsizcolumn == "" || adsizcolumn == null)
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@adsizcolumn"].Value = Convert.ToDecimal(adsizcolumn);
                }

                objSqlCommand.Parameters.Add("@billcolumn", SqlDbType.Decimal);
                if (billcolumn == "" || billcolumn == null)
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@billcolumn"].Value = Convert.ToDecimal(billcolumn);
                }

                objSqlCommand.Parameters.Add("@billarea", SqlDbType.Decimal);

                objSqlCommand.Parameters["@billarea"].Value = Convert.ToDecimal(billarea);

                objSqlCommand.Parameters.Add("@specdiscper", SqlDbType.Decimal);
                if (specdiscper == "" || specdiscper == null)
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@specdiscper"].Value = Convert.ToDecimal(specdiscper);
                }

                objSqlCommand.Parameters.Add("@spacediscper", SqlDbType.Decimal);
                if (spacediscper == "" || spacediscper == null)
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@spacediscper"].Value = Convert.ToDecimal(spacediscper);
                }

                objSqlCommand.Parameters.Add("@paidins", SqlDbType.Int);
                if (paidins == "" || paidins == null)
                {
                    objSqlCommand.Parameters["@paidins"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@paidins"].Value = Convert.ToInt32(paidins);
                }

                objSqlCommand.Parameters.Add("@dealrate", SqlDbType.Decimal);
                if (dealrate == "" || dealrate == null)
                {
                    objSqlCommand.Parameters["@dealrate"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@dealrate"].Value = Convert.ToDecimal(dealrate);
                }

                objSqlCommand.Parameters.Add("@deviation", SqlDbType.Decimal);
                if (deviation == "" || deviation == null)
                {
                    objSqlCommand.Parameters["@deviation"].Value = System.DBNull.Value;
                }
                else
                {
                    objSqlCommand.Parameters["@deviation"].Value = Convert.ToDecimal(deviation);
                }

                objSqlCommand.Parameters.Add("@varient", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient"].Value = varient;

                objSqlCommand.Parameters.Add("@contractname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@contractname"].Value = contractname;


                objSqlCommand.Parameters.Add("@dealtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@dealtype"].Value = dealtype;

                objSqlCommand.Parameters.Add("@cardname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardname"].Value = cardname;

                objSqlCommand.Parameters.Add("@cardtype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardtype"].Value = cardtype;

                objSqlCommand.Parameters.Add("@cardmonth", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardmonth"].Value = cardmonth;

                objSqlCommand.Parameters.Add("@cardyear", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardyear"].Value = cardyear;

                objSqlCommand.Parameters.Add("@cardno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cardno"].Value = cardno;

                objSqlCommand.Parameters.Add("@receiptno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@receiptno"].Value = receiptno;

                objSqlCommand.Parameters.Add("@adscat3", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat3"].Value = adscat3;

                objSqlCommand.Parameters.Add("@adscat4", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat4"].Value = adscat4;

                objSqlCommand.Parameters.Add("@adscat5", SqlDbType.VarChar);
                objSqlCommand.Parameters["@adscat5"].Value = adscat5;

                objSqlCommand.Parameters.Add("@bgcolor", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bgcolor"].Value = bgcolor;

                objSqlCommand.Parameters.Add("@bulletcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@bulletcode"].Value = bulletcode;

                objSqlCommand.Parameters.Add("@bulletprm", SqlDbType.Decimal);
                if (bulletprm == "" || bulletprm == null)
                {
                    objSqlCommand.Parameters["@bulletprm"].Value = System.DBNull.Value;
                }
                else
                {
                    bulletprm = bulletprm.Replace("%", "");
                    objSqlCommand.Parameters["@bulletprm"].Value = Convert.ToDecimal(bulletprm);
                }

                objSqlCommand.Parameters.Add("@material", SqlDbType.VarChar);
                objSqlCommand.Parameters["@material"].Value = material;

                objSqlCommand.Parameters.Add("@region1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@region1"].Value = region;

                objSqlCommand.Parameters.Add("@varient_name", SqlDbType.VarChar);
                objSqlCommand.Parameters["@varient_name"].Value = varient_name;
                /*new change ankur 9 feb*/
                objSqlCommand.Parameters.Add("@coltype", SqlDbType.VarChar);
                objSqlCommand.Parameters["@coltype"].Value = coltype;

                objSqlCommand.Parameters.Add("@logo_h", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_h"].Value = logo_h;

                objSqlCommand.Parameters.Add("@logo_w", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_w"].Value = logo_w;

                objSqlCommand.Parameters.Add("@logo_col", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_col"].Value = logo_col;

                objSqlCommand.Parameters.Add("@logo_uom", SqlDbType.VarChar);
                objSqlCommand.Parameters["@logo_uom"].Value = logo_uom;

                objSqlCommand.Parameters.Add("@retainer1", SqlDbType.VarChar);
                if (retainer.IndexOf("(") >= 0)
                {
                    retainer = retainer.Substring(retainer.IndexOf("(") + 1, retainer.Length - retainer.IndexOf("(") - 2);
                }
                objSqlCommand.Parameters["@retainer1"].Value = retainer;

                objSqlCommand.Parameters.Add("@addagencyrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addagencyrate"].Value = addagencyrate;

                objSqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@mobileno"].Value = mobileno;

                objSqlCommand.Parameters.Add("@addlamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@addlamt"].Value = addlamt;

                objSqlCommand.Parameters.Add("@retamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retamt"].Value = retamt;

                objSqlCommand.Parameters.Add("@retper", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retper"].Value = retper;

                objSqlCommand.Parameters.Add("@cashrecieved", SqlDbType.VarChar);
                if (cashrecieved == "" || cashrecieved == null)
                {
                    objSqlCommand.Parameters["@cashrecieved"].Value = System.DBNull.Value;
                }
                else
                {

                    objSqlCommand.Parameters["@cashrecieved"].Value = Convert.ToDecimal(cashrecieved);
                }
                objSqlCommand.Parameters.Add("@CIRAGENCY_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCY_V"].Value = ciragency;

                objSqlCommand.Parameters.Add("@CIRRATE_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRRATE_V"].Value = cirrate;

                objSqlCommand.Parameters.Add("@CIREDITION_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIREDITION_V"].Value = ciredition;

                objSqlCommand.Parameters.Add("@CIRPUBLICATION_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRPUBLICATION_V"].Value = cirpublication;

                objSqlCommand.Parameters.Add("@CIRAGENCYSUBCODE_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CIRAGENCYSUBCODE_V"].Value = ciragencysubcode;

                objSqlCommand.Parameters.Add("@BARTERTYPE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@BARTERTYPE"].Value = bartertype;

                objSqlCommand.Parameters.Add("@CASHDISCOUNT_V", SqlDbType.VarChar);
                if (cashdiscount == "")
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@CASHDISCOUNT_V"].Value = cashdiscount;

                objSqlCommand.Parameters.Add("@CASHDISCOUNTPER_V", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CASHDISCOUNTPER_V"].Value = cashdiscper;

                objSqlCommand.Parameters.Add("@attach1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach1"].Value = attach1;

                objSqlCommand.Parameters.Add("@attach2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@attach2"].Value = attach2;

                objSqlCommand.Parameters.Add("@drpdiscprem", SqlDbType.VarChar);
                objSqlCommand.Parameters["@drpdiscprem"].Value = drpdiscprem;
                objSqlCommand.Parameters.Add("@doctype_v", SqlDbType.VarChar);
                objSqlCommand.Parameters["@doctype_v"].Value = doctype;

                objSqlCommand.Parameters.Add("@CHKTRADE", SqlDbType.VarChar);
                objSqlCommand.Parameters["@CHKTRADE"].Value = chktradeval;
                objSqlCommand.Parameters.Add("@sharepub_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@sharepub_p"].Value = sharepub;

                objSqlCommand.Parameters.Add("@fmginsert", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmginsert"].Value = fmginsert;

                objSqlCommand.Parameters.Add("@chkno", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkno"].Value = chkno;

                objSqlCommand.Parameters.Add("@chkdate", SqlDbType.DateTime);
                if (chkdate == "" || chkdate == null)
                {
                    objSqlCommand.Parameters["@chkdate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = chkdate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        chkdate = mm + "/" + dd + "/" + yy;
                    }
                    objSqlCommand.Parameters["@chkdate"].Value = chkdate;
                }


                objSqlCommand.Parameters.Add("@chkamt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkamt"].Value = chkamt;

                objSqlCommand.Parameters.Add("@chkbankname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkbankname"].Value = chkbankname;
                objSqlCommand.Parameters.Add("@ourbank", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ourbank"].Value = ourbank;

                objSqlCommand.Parameters.Add("@DEALERPANEL_P", SqlDbType.VarChar);
                if (dealerpanel == "")
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERPANEL_P"].Value = dealerpanel;

                objSqlCommand.Parameters.Add("@DEALERH_P", SqlDbType.VarChar);
                if (dealerh == "")
                    objSqlCommand.Parameters["@DEALERH_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERH_P"].Value = dealerh;

                objSqlCommand.Parameters.Add("@DEALERW_P", SqlDbType.VarChar);
                if (dealerw == "")
                    objSqlCommand.Parameters["@DEALERW_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERW_P"].Value = dealerw;

                objSqlCommand.Parameters.Add("@DEALERTYPE_P", SqlDbType.VarChar);
                if (dealertype == "")
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@DEALERTYPE_P"].Value = dealertype;

                objSqlCommand.Parameters.Add("@multiselect", SqlDbType.VarChar);
                objSqlCommand.Parameters["@multiselect"].Value = multicode;

                objSqlCommand.Parameters.Add("@AGREEDRATE_ACTIVE", SqlDbType.VarChar);
                if (agreedrate_active == "")
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDRATE_ACTIVE"].Value = agreedrate_active;

                objSqlCommand.Parameters.Add("@AGREEDAMT_ACTIVE", SqlDbType.VarChar);
                if (agreedamt_active == "")
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@AGREEDAMT_ACTIVE"].Value = agreedamt_active;

                objSqlCommand.Parameters.Add("@grossamtlocal_p", SqlDbType.VarChar);
                if (grossamtlocal_p == "")
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@grossamtlocal_p"].Value = grossamtlocal_p;


                objSqlCommand.Parameters.Add("@billamtlocal_p", SqlDbType.VarChar);
                if (billamtlocal_p == "")
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@billamtlocal_p"].Value = billamtlocal_p;



                objSqlCommand.Parameters.Add("@chkadon_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@chkadon_p"].Value = chkadon;

                objSqlCommand.Parameters.Add("@refid_p", SqlDbType.VarChar);
                objSqlCommand.Parameters["@refid_p"].Value = refid;


                objSqlCommand.Parameters.Add("@rcpt_currency", SqlDbType.VarChar);
                objSqlCommand.Parameters["@rcpt_currency"].Value = rcpt_currency;

                objSqlCommand.Parameters.Add("@cur_convrate", SqlDbType.VarChar);
                objSqlCommand.Parameters["@cur_convrate"].Value = cur_convrate;

                objSqlCommand.Parameters.Add("@p_revisedate", SqlDbType.VarChar);
                if (revisedate == "" || revisedate == null)
                {
                    objSqlCommand.Parameters["@p_revisedate"].Value = System.DBNull.Value;
                }
                else
                {
                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[0];
                        string mm = arr[1];
                        string yy = arr[2];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    else if (dateformat == "yyyy/mm/dd")
                    {
                        string[] arr = revisedate.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        revisedate = mm + "/" + dd + "/" + yy;


                    }
                    objSqlCommand.Parameters["@p_revisedate"].Value = revisedate;
                }

                objSqlCommand.Parameters.Add("@clienttype", SqlDbType.VarChar);
                if (clienttype == "0")
                    objSqlCommand.Parameters["@clienttype"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@clienttype"].Value = clienttype;

                objSqlCommand.Parameters.Add("@translation", SqlDbType.VarChar);
                if (translation == "0")
                    objSqlCommand.Parameters["@translation"].Value = System.DBNull.Value;
                else
                    objSqlCommand.Parameters["@translation"].Value = translation;

                objSqlCommand.Parameters.Add("@translationcharge", SqlDbType.Decimal);
                if (translationcharge == "" || translationcharge == null)
                {
                    objSqlCommand.Parameters["@translationcharge"].Value = System.DBNull.Value;
                }
                else
                {
                    translationcharge = translationcharge.Replace("%", "");
                    objSqlCommand.Parameters["@translationcharge"].Value = Convert.ToDecimal(translationcharge);
                }
                objSqlCommand.Parameters.Add("@fmgreasons", SqlDbType.VarChar);
                objSqlCommand.Parameters["@fmgreasons"].Value = fmgreasons;

                objSqlCommand.Parameters.Add("@canclecharge", SqlDbType.VarChar);
                objSqlCommand.Parameters["@canclecharge"].Value = canclecharge;

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
        
    }
}
