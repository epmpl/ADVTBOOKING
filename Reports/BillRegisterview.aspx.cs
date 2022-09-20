using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text;


public partial class BillRegisterview : System.Web.UI.Page


{
    int sno = 1;
    double average = 0;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;
    string dytbl = "";
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string pdfName1 = "";
    string datefrom1 = "";
    string dateto1 = "";
    string region = "";
    string product = "";
    string product1 = "";
    string category = "";
    float amt = 0;
    float area = 0;
    double BillAmt = 0;
    double billarea = 0;
    double agencomm = 0;
    int i1 = 1;
    string agcattext = "";
    string publicationcd = "";
    string regionname = "";

    string fromdate = "";
    string todate = "";
    string categorytext = "";
    string publb = "";
    string adtypename = "";
    string agency = "";
    string client = "";
    string publication = "";
    string adtype = "";
    string payment = "";
    string billstatus = "";
    string sortorder = "";
    string sortvalue = "";
    string myrange = "";
    string BreakDown = "";
    string agnname = "";
    string maxrange = "", adtypenew="",agencycat="",edition="",editionname="";
    int count1 = 0;
    int count2 = 0;
    string adchk = "",exename="",execode="";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "", chk_excel="";
    int comm_position = 0;
    string insertstatus = "";
    string ReportName = "";
    int rowcount = 0, maxlimit = 15;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }


        ds = (DataSet)Session["billregister"];
        string prm = Session["prm_billregister"].ToString();
        string[] prm_Array = new string[38];
        prm_Array = prm.Split('~');

       
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();
        
        dateto = Session ["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();




        //if (ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString() == "3")
        //{
        //    comm_position = Convert.ToInt16(ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString());
        //}



        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        edition = prm_Array[7]; //Request.QueryString["edition"].ToString();
        editionname = prm_Array[9]; //Request.QueryString["editionname"].ToString();
        region = prm_Array[11]; //Request.QueryString["region"].ToString();
        regionname = prm_Array[13]; //Request.QueryString["regionname"].ToString();
        adtypenew = prm_Array[15]; //Request.QueryString["adtype"].ToString();
        category = prm_Array[17]; //Request.QueryString["agtype"].ToString();
        categorytext = prm_Array[19]; //Request.QueryString["agtypetext"].ToString();
        agencycat = prm_Array[21]; //Request.QueryString["agcat"].ToString();
        agcattext = prm_Array[23]; //Request.QueryString["agcattext"].ToString();
        publicationcd = prm_Array[25]; //Request.QueryString["publicationcd"].ToString();
        publb = prm_Array[27]; //Request.QueryString["publication1"].ToString();
        adtypename = prm_Array[29]; //Request.QueryString["adtypetext"].ToString();
        adchk = prm_Array[31]; //Request.QueryString["adchk"].ToString();
        exename = prm_Array[33]; //Request.QueryString["exename"].ToString();
        execode = prm_Array[35]; //Request.QueryString["execode"].ToString();
        chk_excel = prm_Array[37];
        BreakDown = prm_Array[39];
        agnname = prm_Array[41];
        insertstatus = prm_Array[43];
            hiddendatefrom.Value = fromdt.ToString();

            //if (agnname == "0" || agnname == "")
            //{
            //    lblgrp.Text = "Group By";
            //    lblgroup.Text = "ALL".ToString();
            //}
            //else
            //{
            //    lblgrp.Text = "Group By";
            //    lblgroup.Text = agnname;
            //}


            if (insertstatus == "--Select Insert Status--")
            {
                lblstatus.Text = "ALL".ToString();
            }
            else
            {
                lblstatus.Text = insertstatus.ToString();
            }

            if (execode == "0" || execode=="")
            {
                lblexecutive.Text = "ALL".ToString();
            }
            else
            {
                lblexecutive.Text = exename.ToString();
            }

            if (edition == "0" || edition=="")
            {
                lblproduct.Text = "ALL".ToString();
            }
            else
            {
                lblproduct.Text = editionname.ToString();
            }

            if (publicationcd == "0")
            {
                lblcategory.Text = "ALL".ToString();
            }
            else
            {
                lblcategory.Text = publb.ToString();
            }

        
            if (adtypenew == "0")
            {
                lbladtype.Text = "ALL".ToString();
            }
            else
            {
                lbladtype.Text = adtypename.ToString();
            }


            if (region == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = regionname.ToString();
            }

            if (category == "0")
            {
                lblagtype.Text = "ALL".ToString();
            }
            else
            {
                lblagtype.Text = categorytext.ToString();
            }

            if (agencycat == "0")
            {
                lblagcat.Text = "ALL".ToString();
            }
            else
            {
                lblagcat.Text = agcattext.ToString();
            }
            


            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

                }
                else
                    if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                    {

                        DateTime dt = System.DateTime.Now;


                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                    }
            lbldate.Text = date.ToString();

       
            lblfrom.Text = fromdt;
            lblto.Text = dateto;

            if (!Page.IsPostBack)
            {

                if (destination == "1" || destination == "0")
                {
                    if (BreakDown == "1" )
                {
                    onscreenbrk(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                }
                else
                    {
                        if (Session["compcode"].ToString() != "SU001")
                        {
                            onscreen(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                        }
                        else
                        {
                            onscreen_news7(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                        }
                }
                }
                else if (BreakDown == "1" && destination == "4")
                {
                    excelbrk(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                }
                else if (destination == "4")
                {
                    if (Session["compcode"].ToString() != "SU001")
                    {
                        excel(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                    }
                    else
                    {
                        onscreen_news7(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                    }

                }
                else if (destination == "3")
                    {
                        pdf(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
                    }
                    else if (destination == "5")
                        {
                            onscreenamt();
                        }
              
            }
        
    }


    public string RETURN_LENGTH(string str_decimal)
    {

        string x = "";
        if (str_decimal.Length == 1)
            x =

            "0" + str_decimal;
        else
            x = str_decimal;

        return x;
    }











    public string chk_null(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal == "0.00" || str_decimal == "0.0" || str_decimal == "0")
        {
            final_decimal = "0.00";
        }
        else if (str_decimal.IndexOf(".") > -1)
        {

            double dd = System.Math.Round(Convert.ToDouble(str_decimal), 2);
            string[] oo = dd.ToString().Split('.');
            if (oo.Length == 1)
                final_decimal = dd.ToString() + ".00";
            else if (oo[1].Length == 1)
                final_decimal = dd.ToString() + "0";
            else
                final_decimal = dd.ToString();
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = "0.00";
        }
        return final_decimal;
    }



    private void onscreenamt()
    {
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        //string tbl = "";
        StringBuilder tbl = new StringBuilder();

        tbl.Append("<table width='100%'align='left' cellpadding='0' cellspacing='0' valign='top'>");
       
            tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
                tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Booking</br>Id</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left'>Client</td><td class='middle31' valign='top' align='left'>Publication</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Height</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Width</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Area</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Page</br>No</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Card</br>Rate</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Bill</br>Rate</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Gross</br>Amt</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Agen</br>Comm</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Box</br>Charges</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">NetAmt/</br>ActBuss</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Bill</br>Amt</td></tr>");

            }
       


        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr >");


            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            if (rrr.Length >= 13)
            {
                cioid1 = rrr.Substring(0, 13);
                if (rrr.Length - 13 < 13)
                    cioid1 += "</br>" + rrr.Substring(13, rrr.Length - 13);
                else
                    cioid1 += "</br>" + rrr.Substring(13, 13);
            }
            else
                cioid1 = rrr;
            tbl.Append(cioid1 + "</td>");
            //string cioid1 = "";
            //string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            //char[] cioid = rrr.ToCharArray();
            //int len11 = cioid.Length;

            //int ch_end = 0;
            //int ch_str = 0;
            //for (int ch = 0; ch < len11; ch++)
            //{
            //    /**/
            //    ch_end = ch_end + 9;
            //    ch_str = ch_end;
            //    if (ch_end > len11)
            //        ch_str = len11 - ch;
            //    else
            //        ch_str = ch_end - ch;

            //    cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
            //    cioid1 = cioid1 + "</br>";
            //    ch = ch + 9;
            //    if (ch > len11)
            //        ch = len11;
            //}
            //tbl.Append(cioid1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_No"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_Date"] + "</td>");
            tbl.Append("<td class='rep_data' align='left'>");
            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            char[] agency = rrr1.ToCharArray();
            int len111 = agency.Length;
            int line11 = 0;
            int ch_end1 = 0;
            int ch_str1 = 0;
            for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            {
                /**/
                ch_end1 = ch_end1 + 16;
                ch_str1 = ch_end1;
                if (ch_end1 > len111)
                    ch_str1 = len111 - ch1;
                else
                    ch_str1 = ch_end1 - ch1;

                agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                agency1 = agency1 + "</br>";
                ch1 = ch1 + 16;
                if (ch1 > len111)
                    ch1 = len111;/**/
            }
            tbl.Append(agency1 + "</td>");


            tbl.Append("<td class='rep_data' align='left'>");
            string client1 = "";
            string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            char[] client = rrr11.ToCharArray();
            int len1111 = client.Length;
            int line = 0;
            int ch_end11 = 0;
            int ch_str11 = 0;
            for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            {
                /* */
                ch_end11 = ch_end11 + 16;
                ch_str11 = ch_end11;
                if (ch_end11 > len1111)
                    ch_str11 = len1111 - ch11;
                else
                    ch_str11 = ch_end11 - ch11;

                client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                client1 = client1 + "</br>";
                ch11 = ch11 + 16;
                if (ch11 > len1111)
                    ch11 = len1111;
            }
            tbl.Append(client1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Publication"] + "</td>");

            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["height"] + "</td>");
            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["width"] + "</td>");

            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["Area"] + "</td>");

            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["Page_no"] + "</td>");
            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["Card_Rate"] + "</td>");


            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[i]["Grossamt"]).ToString("F2")), comm_position) + "</td>");

            //tbl = tbl + ("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            //tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[i]["AgencyTDAmt"]).ToString("F2")), comm_position) + "</td>");
            if (ds.Tables[0].Rows[i]["AgencyComm"].ToString() != "")
                agencomm = agencomm + double.Parse(ds.Tables[0].Rows[i]["AgencyComm"].ToString());

            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                count1++;
            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                count2++;

            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["Specialcharge"] + "</td>");


            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            tbl.Append(ds.Tables[0].Rows[i]["ActualBusiness"] + "</td>");

            tbl.Append("<td class='rep_data' align='right' style=\"padding-left:4px\">");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
            {
                tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]).ToString("F2")), comm_position) + "</td>");
            }
            else
                tbl.Append("</td>");


            
            

           tbl.Append("</tr>");
            
           

        }
        tbl.Append("<tr >");
        tbl.Append("<tr >");
        tbl.Append("<td class='middle1212'>");
        tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total Ads:</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");
        tbl.Append("<td class='middle1212'><b>FMG:</b>");
        tbl.Append(count1.ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'><b>HouseAd:</b>");
        tbl.Append(count2.ToString() + "</td>");
        tbl.Append("<td class='middle1212'>&nbsp;");
        
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
      
        tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'><b>Total</b></td>");
        tbl.Append("<td class='middle1212' align='right' colspan='3'>&nbsp;");
        tbl.Append("</td>");
        tbl.Append("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
        tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(cal.ToString()).ToString("F2")), comm_position) + "</td>");
      
        tbl.Append("</tr>");
        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();

    }


    private void onscreen(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew,string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product="";
        SqlDataAdapter da = new SqlDataAdapter();
       
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
//        string tbl = "";
        StringBuilder tbl=new StringBuilder();

        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' valign='top'>");
        if (adchk == "1")
        {
            tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
                tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Booking</br>Id</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left'>Client</td><td class='middle31' valign='top' align='left'>Publication</td><td class='middle31' valign='top' align='left'>Package</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='left'>Revenue</br>Center</td><td class='middle31' valign='top' align='left'>Rate</br>Code</td><td class='middle31' valign='top' align='right'>Premium</td><td class='middle31' valign='top' align='left'>Color</td><td class='middle31' valign='top' align='left'>Catg</br>SubCat</td><td class='middle31' valign='top' align='right'>Rate</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td><td class='middle31' valign='top' align='right'>Agency Addl</br>TD(%)</td><td class='middle31' valign='top' align='right'>Cash</br>Disc</td><td class='middle31' valign='top' align='left'>Bill</br>Remark</td></tr>");

            }
        }
        else
        {
            tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
            tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Booking</br>Id</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left'>Client</td><td class='middle31' valign='top' align='left'>Publication</td><td class='middle31' valign='top' align='left'>Package</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='left'>Revenue</br>Center</td><td class='middle31' valign='top' align='left'>Rate</br>Code</td><td class='middle31' valign='top' align='left'>Color</td><td class='middle31' valign='top' align='left'>Catg</br>SubCat</td><td class='middle31' valign='top' align='right'>Rate</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td><td class='middle31' valign='top' align='right'>Agency Addl</br>TD(%)</td><td class='middle31' valign='top' align='left'>Bill</br>Remark</td></tr>");

            }
        }
       

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl.Append("<tr >");


            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");

            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            if (rrr.Length >= 13)
            {
                cioid1 = rrr.Substring(0, 13);
                if (rrr.Length - 13 < 13)
                    cioid1 += "</br>" + rrr.Substring(13, rrr.Length - 13);
                else
                    cioid1 += "</br>" + rrr.Substring(13, 13);
            }
            else
                cioid1 = rrr;
            tbl.Append(cioid1 + "</td>");
            
            //---------------
            //string cioid1 = "";
            //string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            //char[] cioid = rrr.ToCharArray();
            //int len11 = cioid.Length;

            //int ch_end = 0;
            //int ch_str = 0;
            //for (int ch = 0; ch < len11; ch++)
            //{
            //    /**/
            //    ch_end = ch_end + 9;
            //    ch_str = ch_end;
            //    if (ch_end > len11)
            //        ch_str = len11 - ch;
            //    else
            //        ch_str = ch_end - ch;

            //    cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
            //    cioid1 = cioid1 + "</br>";
            //    ch = ch + 9;
            //    if (ch > len11)
            //        ch = len11;
            //}


            //=============================
            //tbl.Append(cioid1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_No"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_Date"] + "</td>");
            tbl.Append("<td class='rep_data' align='left'>");
            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            char[] agency = rrr1.ToCharArray();
            int len111 = agency.Length;
            int line11 = 0;
            int ch_end1 = 0;
            int ch_str1 = 0;
            for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            {
                /**/
                ch_end1 = ch_end1 + 16;
                ch_str1 = ch_end1;
                if (ch_end1 > len111)
                    ch_str1 = len111 - ch1;
                else
                    ch_str1 = ch_end1 - ch1;

                agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                agency1 = agency1 + "</br>";
                ch1 = ch1 + 16;
                if (ch1 > len111)
                    ch1 = len111;/**/
            }
            tbl.Append(agency1 + "</td>");


            tbl.Append("<td class='rep_data' align='left'>");
            string client1 = "";
            string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            char[] client = rrr11.ToCharArray();
            int len1111 = client.Length;
            int line = 0;
            int ch_end11 = 0;
            int ch_str11 = 0;
            for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            {
                /* */
                ch_end11 = ch_end11 + 16;
                ch_str11 = ch_end11;
                if (ch_end11 > len1111)
                    ch_str11 = len1111 - ch11;
                else
                    ch_str11 = ch_end11 - ch11;

                client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                client1 = client1 + "</br>";
                ch11 = ch11 + 16;
                if (ch11 > len1111)
                    ch11 = len1111;
            }
            tbl.Append(client1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Publication"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Area"] + "</td>");
           

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Rate"] + "</td>");

            if (adchk == "1")
            {
                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["Premium"] + "</td>");
            }


            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Color"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Category"]);// + "</td>");
            tbl.Append("</br>");
            if (ds.Tables[0].Rows[i]["SubCategory"].ToString()=="0")
            tbl.Append("</td>");
            else
            tbl.Append(ds.Tables[0].Rows[i]["SubCategory"] + "</td>");



              tbl.Append("<td class='rep_data' align='right'>");
                 tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

             tbl.Append("<td class='rep_data' align='right'>");
             tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString())).ToString("F2")), comm_position) + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["AgencyComm"] + "</td>");
            if (ds.Tables[0].Rows[i]["AgencyComm"].ToString() != "")
                agencomm = agencomm + double.Parse(ds.Tables[0].Rows[i]["AgencyComm"].ToString());

            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                count1++;
            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                count2++;

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["AddlAgencyTD"] + "</td>");

            if (adchk == "1")
            {
                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["Cash_Disc"] + "</td>");
               
            }
            tbl.Append("<td class='rep_data'>");
            tbl.Append(ds.Tables[0].Rows[i]["BillRemark"] + "</td>");


            tbl.Append("</tr>");
            
            

        }       
        tbl.Append("<tr >");
        tbl.Append("<tr >");
        tbl.Append("<td class='middle1212'>");
        tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total Ads:</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");
        tbl.Append("<td class='middle1212'><b>FMG:</b>");
        tbl.Append(count1.ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'><b>HouseAd:</b>");
        tbl.Append(count2.ToString() + "</td>");
        tbl.Append("<td class='middle1212'>&nbsp;");
        if(adchk=="1")
        tbl.Append("<td class='middle1212' colspan='4'>&nbsp;</td>");
        else
        tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212'>&nbsp;</td><td class='middle1212'><b>Total</b></td>");
        tbl.Append("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
        tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(cal.ToString()).ToString("F2")), comm_position) + "</td>");
        tbl.Append("<td class='middle1212' align='right' colspan='4'>&nbsp;");
        tbl.Append( "</td>");
        tbl.Append("</tr>");
        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();


    }
    //**************************************************************************************************//
    private void onscreen_news7(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew, string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product = "";
        SqlDataAdapter da = new SqlDataAdapter();

        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        int sno = 1;
        StringBuilder tbl = new StringBuilder();

        if (destination == "4")
        {
            tbl.Append("<table cellpadding='0' width='99%' cellspacing='0' border='0' align='center' style='vertical-align:top;margin-left:auto; margin-right:auto;'>");
            tbl.Append("<tr ><td colspan='30' style='font-size:15px;font-family:Verdana;text-align:center;color:black;'><b>" + Session["comp_name"].ToString() + "</b></td></tr>");
            tbl.Append("<tr ><td colspan='30' style='font-size:13px;font-family:Verdana;text-align:center;color:black;'><b>" + ReportName + "</b></td></tr>");

            tbl.Append("<tr><td colspan='10' style='font-size:12px;font-family:Verdana;text-align:left;'><b>FROM DATE : </b>" + fromdt + "</td>");
            tbl.Append("<td colspan='10' style='font-size:12px;font-family:Verdana;text-align:right;'><b>TO DATE : </b>" + dateto + "</td>");
            tbl.Append("<td colspan='10' style='font-size:12px;font-family:Verdana;text-align:right;'><b>RUN DATE : </b>" + date.ToString() + "</td>");
            tbl.Append("</tr>");

            tbl.Append("<tr><td colspan='10' style='font-size:12px;font-family:Verdana;text-align:left;'><b>PUBLICATION : </b>" + fromdt + "</td>");
            tbl.Append("<td colspan='10' style='font-size:12px;font-family:Verdana;text-align:right;'><b>EDITION : </b>" + dateto + "</td>");
            tbl.Append("<td colspan='10' style='font-size:12px;font-family:Verdana;text-align:right;'><b>AD TYPE : </b>" + date.ToString() + "</td>");
            tbl.Append("</tr>");

            tbl.Append("<tr><td colspan='10' style='font-size:12px;font-family:Verdana;text-align:left;'><b>REGION : </b>" + fromdt + "</td>");
            tbl.Append("<td colspan='10' style='font-size:12px;font-family:Verdana;text-align:right;'><b>AGENCY TYPE : </b>" + dateto + "</td>");
            tbl.Append("<td colspan='10' style='font-size:12px;font-family:Verdana;text-align:right;'><b>AGENCY CATEGORY : </b>" + date.ToString() + "</td>");
            tbl.Append("</tr>");
            tbl.Append("</table>");

        }

        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' valign='top'>");
        if (adchk == "1") //Scheduled
        {

            if (hiddenascdesc.Value == "")
            {
                tbl.Append("<tr valign='top'bgcolor='#00FFFF'><td class='header' valign='top'>S.No.</td><td class='header' valign='top'>Branch</td><td class='header' valign='top'  align='left'>Booking</br>Id</td><td class='header' valign='top'  align='left'>Bill</br>No</td><td class='header' valign='top'  align='left'>Bill</br>Date</td><td class='header' valign='top' align='left'>Client</td><td class='header' valign='top' align='left'>Client</br>Place</td><td class='header' valign='top' align='left'>Agency</td><td class='header' valign='top' align='left'>Agency</br>Place</td><td class='header' valign='top' align='left'>Executive</td><td class='header' valign='top' align='left'>Publication</td><td class='header' valign='top' align='left'>Package</td><td class='header' valign='top' align='left'>Ro No</td><td class='header' valign='top' align='left'>Ro Date</td><td class='header' valign='top' align='left'>Hue</td><td class='header' valign='top' align='left'>Page</td><td class='header' valign='top' align='left'>Width</td><td class='header' valign='top' align='left'>Height</td><td class='header' valign='top' align='right'>Area</td><td class='header' valign='top' align='right'>Agreed</br>Rate</td><td class='header' valign='top' align='right'>Page</br>Premium</td><td class='header' valign='top' align='right'>Disc</td><td class='header' valign='top' align='right'>AddlDisc</td><td class='header' valign='top' align='left'>SplDisc</td><td class='header' valign='top' align='left'>Bill Amount</td><td class='header' valign='top' align='left'>Insert No</td><td class='header' valign='top' align='left'>Total</br>Insertion</td><td class='header' valign='top' align='right'>DueDate</td><td class='header' valign='top' align='left'>Product</td><td class='header' valign='top' align='left'>Varient</td></tr>");

            }
        }
        else
        {
            if (hiddenascdesc.Value == "")  // billed
            {
                tbl.Append("<tr valign='top'bgcolor='#00FFFF'><td class='header' valign='top'>S.No.</td><td class='header' valign='top'>Branch</td><td class='header' valign='top'  align='left'>Booking</br>Id</td><td class='header' valign='top'  align='left'>Bill</br>No</td><td class='header' valign='top'  align='left'>Bill</br>Date</td><td class='header' valign='top' align='left'>Client</td><td class='header' valign='top' align='left'>Client</br>Place</td><td class='header' valign='top' align='left'>Agency</td><td class='header' valign='top' align='left'>Agency</br>Place</td><td class='header' valign='top' align='left'>Executive</td><td class='header' valign='top' align='left'>Publication</td><td class='header' valign='top' align='left'>Package</td><td class='header' valign='top' align='left'>Ro No</td><td class='header' valign='top' align='left'>Ro Date</td><td class='header' valign='top' align='left'>Hue</td><td class='header' valign='top' align='left'>Page</td><td class='header' valign='top' align='left'>Width</td><td class='header' valign='top' align='left'>Height</td><td class='header' valign='top' align='right'>Area</td><td class='header' valign='top' align='right'>Agreed</br>Rate</td><td class='header' valign='top' align='right'>Page</br>Premium</td><td class='header' valign='top' align='right'>Disc</td><td class='header' valign='top' align='right'>AddlDisc</td><td class='header' valign='top' align='left'>SplDisc</td><td class='header' valign='top' align='left'>Bill Amount</td><td class='header' valign='top' align='left'>Insert No</td><td class='header' valign='top' align='left'>Total</br>Insertion</td><td class='header' valign='top' align='right'>DueDate</td><td class='header' valign='top' align='left'>Product</td><td class='header' valign='top' align='left'>Varient</td></tr>");

            }
        }


        for (int i = 0; i <= cont - 1; i++)
        {
            if (destination == "1" || destination == "0")
            {
                if (adchk == "1") 
                {
                    if (rowcount == maxlimit)
                    {
                        rowcount = 0;
                        tbl.Append("</table><div style='page-break-after: always;'></div>");
                        tbl.Append("<tr valign='top'bgcolor='#00FFFF'><td class='header' valign='top'>S.No.</td><td class='header' valign='top'>Branch</td><td class='header' valign='top'  align='left'>Booking</br>Id</td><td class='header' valign='top'  align='left'>Bill</br>No</td><td class='header' valign='top'  align='left'>Bill</br>Date</td><td class='header' valign='top' align='left'>Client</td><td class='header' valign='top' align='left'>Client</br>Place</td><td class='header' valign='top' align='left'>Agency</td><td class='header' valign='top' align='left'>Agency</br>Place</td><td class='header' valign='top' align='left'>Executive</td><td class='header' valign='top' align='left'>Publication</td><td class='header' valign='top' align='left'>Package</td><td class='header' valign='top' align='left'>Ro No</td><td class='header' valign='top' align='left'>Ro Date</td><td class='header' valign='top' align='left'>Hue</td><td class='header' valign='top' align='left'>Page</td><td class='header' valign='top' align='left'>Width</td><td class='header' valign='top' align='left'>Height</td><td class='header' valign='top' align='right'>Area</td><td class='header' valign='top' align='right'>Agreed</br>Rate</td><td class='header' valign='top' align='right'>Page</br>Premium</td><td class='header' valign='top' align='right'>Disc</td><td class='header' valign='top' align='right'>AddlDisc</td><td class='header' valign='top' align='left'>SplDisc</td><td class='header' valign='top' align='left'>Bill Amount</td><td class='header' valign='top' align='left'>Insert No</td><td class='header' valign='top' align='left'>Total</br>Insertion</td><td class='header' valign='top' align='right'>DueDate</td><td class='header' valign='top' align='left'>Product</td><td class='header' valign='top' align='left'>Varient</td></tr>");
                    }
                }
                else
                {
                    if (rowcount == maxlimit)
                    {
                        tbl.Append("<tr valign='top'bgcolor='#00FFFF'><td class='header' valign='top'>S.No.</td><td class='header' valign='top'>Branch</td><td class='header' valign='top'  align='left'>Booking</br>Id</td><td class='header' valign='top'  align='left'>Bill</br>No</td><td class='header' valign='top'  align='left'>Bill</br>Date</td><td class='header' valign='top' align='left'>Client</td><td class='header' valign='top' align='left'>Client</br>Place</td><td class='header' valign='top' align='left'>Agency</td><td class='header' valign='top' align='left'>Agency</br>Place</td><td class='header' valign='top' align='left'>Executive</td><td class='header' valign='top' align='left'>Publication</td><td class='header' valign='top' align='left'>Package</td><td class='header' valign='top' align='left'>Ro No</td><td class='header' valign='top' align='left'>Ro Date</td><td class='header' valign='top' align='left'>Hue</td><td class='header' valign='top' align='left'>Page</td><td class='header' valign='top' align='left'>Width</td><td class='header' valign='top' align='left'>Height</td><td class='header' valign='top' align='right'>Area</td><td class='header' valign='top' align='right'>Agreed</br>Rate</td><td class='header' valign='top' align='right'>Page</br>Premium</td><td class='header' valign='top' align='right'>Disc</td><td class='header' valign='top' align='right'>AddlDisc</td><td class='header' valign='top' align='left'>SplDisc</td><td class='header' valign='top' align='left'>Bill Amount</td><td class='header' valign='top' align='left'>Insert No</td><td class='header' valign='top' align='left'>Total</br>Insertion</td><td class='header' valign='top' align='right'>DueDate</td><td class='header' valign='top' align='left'>Product</td><td class='header' valign='top' align='left'>Varient</td></tr>");
                    }
                }
            }
            tbl.Append("<tr >");
            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");

            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
            if (rrr.Length >= 13)
            {
                cioid1 = rrr.Substring(0, 13);
                if (rrr.Length - 13 < 13)
                    cioid1 += "</br>" + rrr.Substring(13, rrr.Length - 13);
                else
                    cioid1 += "</br>" + rrr.Substring(13, 13);
            }
            else
                cioid1 = rrr;
            tbl.Append(cioid1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_No"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_Date"] + "</td>");



            tbl.Append("<td class='rep_data' align='left'>");
            string client1 = "";
            string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            char[] client = rrr11.ToCharArray();
            int len1111 = client.Length;
            int line = 0;
            int ch_end11 = 0;
            int ch_str11 = 0;
            for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            {
                /* */
                ch_end11 = ch_end11 + 16;
                ch_str11 = ch_end11;
                if (ch_end11 > len1111)
                    ch_str11 = len1111 - ch11;
                else
                    ch_str11 = ch_end11 - ch11;

                client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                client1 = client1 + "</br>";
                ch11 = ch11 + 16;
                if (ch11 > len1111)
                    ch11 = len1111;
            }
            tbl.Append(client1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["C_Place"] + "</td>");  // client city


            tbl.Append("<td class='rep_data' align='left'>");
            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
            char[] agency = rrr1.ToCharArray();
            int len111 = agency.Length;
            int line11 = 0;
            int ch_end1 = 0;
            int ch_str1 = 0;
            for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
            {
                /**/
                ch_end1 = ch_end1 + 16;
                ch_str1 = ch_end1;
                if (ch_end1 > len111)
                    ch_str1 = len111 - ch1;
                else
                    ch_str1 = ch_end1 - ch1;

                agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                agency1 = agency1 + "</br>";
                ch1 = ch1 + 16;
                if (ch1 > len111)
                    ch1 = len111;/**/
            }
            tbl.Append(agency1 + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Agency_City"] + "</td>");  // agency city

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["exec_nm"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["publication"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Ro_No"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Ro_Date"] + "</td>");

            //tbl.Append("<td class='rep_data'>");
            //tbl.Append(ds.Tables[0].Rows[i]["bill_remarks"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Color"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["page_no"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["width"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["height"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                areasum = areasum + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());

            //tbl.Append("<td class='rep_data' align='left'>");
            //tbl.Append(ds.Tables[0].Rows[i]["uom"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["agreedRate"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");   // page prium
            tbl.Append(ds.Tables[0].Rows[i]["page_premium"] + "</td>");



            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["AgencyComm"] + "</td>");
            if (ds.Tables[0].Rows[i]["AgencyComm"].ToString() != "")
                agencomm = agencomm + double.Parse(ds.Tables[0].Rows[i]["AgencyComm"].ToString());

            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                count1++;
            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                count2++;

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["AddlAgencyTD"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Spdiscper"] + "</td>");

            //tbl.Append("<td class='rep_data' align='right'>");
            //tbl.Append(ds.Tables[0].Rows[i]["remarks"] + "</td>");  // Spl Instruction

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString())).ToString("F2")), comm_position) + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["no_insert"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["no_of_insert"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["paydate"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["product"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Varient"] + "</td>");

            tbl.Append("</tr>");
            rowcount++;
            sno++;
        }
        tbl.Append("<tr >");
        tbl.Append("<tr >");
        tbl.Append("<td class='middle1212'>");
        tbl.Append("<tr bgcolor='#ffff00'><td class='middle1212' colspan='2'><b>Total Ads:</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");
        tbl.Append("<td class='middle1212'><b>FMG:</b>");
        tbl.Append(count1.ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'><b>HouseAd:</b>");
        tbl.Append(count2.ToString() + "</td>");
        tbl.Append("<td class='middle1212'><b>Yield:</b>");
        average = BillAmt / areasum;
        double avrg = System.Math.Round(Convert.ToDouble(average), 2);
        tbl.Append(avrg.ToString() + "</td>");

        tbl.Append("<td class='middle1212'><b>Total</b></td>");
        tbl.Append("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
        tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(cal.ToString()).ToString("F2")), comm_position) + "</td>");
        tbl.Append("<td class='middle1212' align='right' colspan='20'>&nbsp;");
        tbl.Append("</td>");
        tbl.Append("</tr>");
        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();
        if (destination == "4")
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }


    //************************************************************************************************************//

    private void excel(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew,string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product="";
       
                
                //DataSet ds = new DataSet();
                //NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
               
                //if (adchk == "1")
                //    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat, adchk, execode);
                //else
                //    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, editionname, temp_agency, region, agencycat, adchk, execode);

                string tbl = "";
                int cont = ds.Tables[0].Rows.Count;
                for (int i = 0; i < cont - 1; i++)
                {

                    //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["Rate"])
                    //    count1++;
                    //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Category"].ToString())
                    //    count2++;
                 
                    if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                        count1++;
                
                    if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                        count2++;
              }
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";

                Response.ContentType = "text/csv";
                if (chk_excel == "1")
                {
                    Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
                }
                else
                {
                    Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
                }

                tbl = tbl + ("<table border='1'><tr><td colspan='15' align='center'><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
                tbl = tbl + ("<tr><td colspan='15' align='center'><b>Billing Register</b></td></tr>");
                tbl = tbl + ("<tr><td ><b>Date From:</b></td><td colspan='4' align='left'>" + lblfrom.Text + "</td><td><b>Date To:</b></td><td  colspan='4' align='left'>" + lblto.Text + "</td><td><b>Run Date:</b></td><td  colspan='4' align='left'>" + lbldate.Text + "</td></tr>");
                tbl = tbl + ("<tr><td><b>Publication:</b></td><td colspan='4' align='left'>" + lblcategory.Text + "</td><td><b>Edition:</b></td><td  colspan='4' align='left'>" + lblproduct.Text + "</td><td><b>Adtype:</b></td><td  colspan='4' align='left'>" + lbladtype.Text + "</td></tr>");
                tbl = tbl + ("<tr><td><b>Region:</b></td><td colspan='4' align='left'>" + lblregion.Text + "</td><td><b>Agency Type:</b></td><td colspan='4' align='left'>" + lblagtype.Text + "</td><td><b>Agency Category:</b></td><td colspan='4' align='left'>" + lblagcat.Text + "</td></tr>");
                tbl = tbl + ("<tr><td><b>Executive:</b></td><td  colspan='4' align='left'>" + lblexecutive.Text + "</td><td><b>Insert Status:</b></td><td  colspan='4' align='left'>" + lblstatus.Text + "</td></tr></table>");
                if (adchk == "1")
                {
                    tblgrid.InnerHtml += tbl;

                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    tblgrid.Visible = true;
                    tblgrid.RenderControl(hw);
                    Response.Write(sw.ToString());
                }
        
                BoundColumn nameColumn0 = new BoundColumn();
                nameColumn0.HeaderText = "S.No";
                DataGrid1.Columns.Add(nameColumn0);



                BoundColumn nameColumn = new BoundColumn();
                nameColumn.HeaderText = "Booking ID";
                nameColumn.DataField = "CIOID";
                name1 = name1 + "," + "Booking ID";
                name2 = name2 + "," + "CIOID";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn);

                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Bill No";
                nameColumn1.DataField = "Bill_No";

                name1 = name1 + "," + "Bill No";
                name2 = name2 + "," + "Bill_No";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Bill Date";
                nameColumn2.DataField = "Bill_Date";

                name1 = name1 + "," + "Bill Date";
                name2 = name2 + "," + "Bill_Date";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);

                BoundColumn nameColumn4 = new BoundColumn();
                nameColumn4.HeaderText = "Agency";
                nameColumn4.DataField = "Agency";

                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "Agency";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn4);
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    //BoundColumn nameColumn41 = new BoundColumn();
                    //nameColumn41.HeaderText = "Agency Add";
                    //nameColumn41.DataField = "A_Place";

                    //name1 = name1 + "," + "Agency Add";
                    //name2 = name2 + "," + "A_Place";
                    //name3 = name3 + "," + "G";
                    //DataGrid1.Columns.Add(nameColumn41);
                    BoundColumn nameColumn41 = new BoundColumn();
                    nameColumn41.HeaderText = "Agency City";
                    nameColumn41.DataField = "Agency_City";

                    name1 = name1 + "," + "Agency City";
                    name2 = name2 + "," + "Agency_City";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn41);
                }


                BoundColumn nameColumn6 = new BoundColumn();
                nameColumn6.HeaderText = "Client";
                nameColumn6.DataField = "Client";

                name1 = name1 + "," + "Client";
                name2 = name2 + "," + "Client";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn6);
                //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                //{
                //    BoundColumn nameColumn61 = new BoundColumn();
                //    nameColumn61.HeaderText = "Client Add";
                //    nameColumn61.DataField = "C_Place";

                //    name1 = name1 + "," + "Client Add";
                //    name2 = name2 + "," + "C_Place";
                //    name3 = name3 + "," + "G";
                //    DataGrid1.Columns.Add(nameColumn61);
                //}

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {

                    BoundColumn nameColumn7 = new BoundColumn();
                    nameColumn7.HeaderText = "Publication";
                    nameColumn7.DataField = "Publication";

                    name1 = name1 + "," + "Publication";
                    name2 = name2 + "," + "Publication";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn7);


                    BoundColumn nameColumn9 = new BoundColumn();
                    nameColumn9.HeaderText = "Package";
                    nameColumn9.DataField = "Package";

                    name1 = name1 + "," + "Package";
                    name2 = name2 + "," + "Package";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn9);
                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    BoundColumn nameColumn91 = new BoundColumn();
                    nameColumn91.HeaderText = "Page No";
                    nameColumn91.DataField = "Page_no";

                    name1 = name1 + "," + "Page No";
                    name2 = name2 + "," + "Page_no";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn91);
                }
 //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
 //               {
 //                   BoundColumn nameColumn92 = new BoundColumn();
 //                   nameColumn92.HeaderText = "Uom";
 //                   nameColumn92.DataField = "Uom";

 //                   name1 = name1 + "," + "Uom";
 //                   name2 = name2 + "," + "Uom";
 //                   name3 = name3 + "," + "G";
 //                   DataGrid1.Columns.Add(nameColumn92);
 //               }


                BoundColumn nameColumn10 = new BoundColumn();
                nameColumn10.HeaderText = "Area";
                nameColumn10.DataField = "Area";

                name1 = name1 + "," + "Area";
                name2 = name2 + "," + "Area";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn10);
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    BoundColumn nameColumn11 = new BoundColumn();
                    nameColumn11.HeaderText = "RevenueCenter";
                    nameColumn11.DataField = "RevenueCenter";

                    name1 = name1 + "," + "RevenueCenter";
                    name2 = name2 + "," + "RevenueCenter";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn11);


                    BoundColumn nameColumn12 = new BoundColumn();
                    nameColumn12.HeaderText = "Rate Code";
                    nameColumn12.DataField = "Rate";

                    name1 = name1 + "," + "Rate Code";
                    name2 = name2 + "," + "Rate";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn12);



                    BoundColumn nameColumn13 = new BoundColumn();
                    nameColumn13.HeaderText = "Premium";
                    nameColumn13.DataField = "Premium";

                    name1 = name1 + "," + "Premium";
                    name2 = name2 + "," + "Premium";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn13);
                }


                BoundColumn nameColumn14 = new BoundColumn();
                nameColumn14.HeaderText = "Color";
                nameColumn14.DataField = "Color";

                name1 = name1 + "," + "Color";
                name2 = name2 + "," + "Color";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn14);

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    BoundColumn nameColumn15 = new BoundColumn();
                    nameColumn15.HeaderText = "Category";
                    nameColumn15.DataField = "Category";

                    name1 = name1 + "," + "Category";
                    name2 = name2 + "," + "Category";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn15);



                    BoundColumn nameColumn16 = new BoundColumn();
                    nameColumn16.HeaderText = "SubCategory";
                    nameColumn16.DataField = "SubCategory";

                    name1 = name1 + "," + "SubCategory";
                    name2 = name2 + "," + "SubCategory";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn16);
                }

                BoundColumn nameColumn17 = new BoundColumn();
                nameColumn17.HeaderText = "Rate";
                nameColumn17.DataField = "AgreedRate";

                name1 = name1 + "," + "Rate";
                name2 = name2 + "," + "AgreedRate";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn17);
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    BoundColumn nameColumn171 = new BoundColumn();
                    nameColumn171.HeaderText = "Card Rate";
                    nameColumn171.DataField = "Card_Rate";

                    name1 = name1 + "," + " Card Rate";
                    name2 = name2 + "," + "Card_Rate";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn171);

                }

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    BoundColumn nameColumn19 = new BoundColumn();
                    nameColumn19.HeaderText = "AgencyComm(%)";
                    nameColumn19.DataField = "AgencyComm";

                    name1 = name1 + "," + "AgencyComm(%)";
                    name2 = name2 + "," + "AgencyComm";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn19);
                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    BoundColumn nameColumn190 = new BoundColumn();
                    nameColumn190.HeaderText = "AgencyComm Amt";
                    nameColumn190.DataField = "AgencyTDAmt";

                    name1 = name1 + "," + "AgencyComm Amt";
                    name2 = name2 + "," + "AgencyTDAmt";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn190);

                    BoundColumn nameColumn191 = new BoundColumn();
                    nameColumn191.HeaderText = "Discount";
                    nameColumn191.DataField = "Discper";

                    name1 = name1 + "," + "Discount";
                    name2 = name2 + "," + "Discper";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn191);

                    BoundColumn nameColumn192 = new BoundColumn();
                    nameColumn192.HeaderText = "Special Disc";
                    nameColumn192.DataField = "Spdiscper";

                    name1 = name1 + "," + "Special Disc";
                    name2 = name2 + "," + "Spdiscper";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn192);

                    //BoundColumn nameColumn193 = new BoundColumn();
                    //nameColumn193.HeaderText = "Space Disc";
                    //nameColumn193.DataField = "Spacediscper";

                    //name1 = name1 + "," + "Space Disc";
                    //name2 = name2 + "," + "Spacediscper";
                    //name3 = name3 + "," + "G";
                    //DataGrid1.Columns.Add(nameColumn193);

                    BoundColumn nameColumn194 = new BoundColumn();
                    nameColumn194.HeaderText = "Special charges";
                    nameColumn194.DataField = "Specialcharge";

                    name1 = name1 + "," + "Special charges";
                    name2 = name2 + "," + "Specialcharge";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn194);
                }

                BoundColumn nameColumn20 = new BoundColumn();
                nameColumn20.HeaderText = "AddlAgencyTD(%)";
                nameColumn20.DataField = "AddlAgencyTD";

                name1 = name1 + "," + "AddlAgencyTD(%)";
                name2 = name2 + "," + "AddlAgencyTD";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn20);

                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    BoundColumn nameColumn200 = new BoundColumn();
                    nameColumn200.HeaderText = "AddlAgencyTD Amt";
                    nameColumn200.DataField = "AgencyAddlTDAmt";

                    name1 = name1 + "," + "AddlAgencyTD Amt";
                    name2 = name2 + "," + "AgencyAddlTDAmt";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn200);

                }
                if (adchk == "1")
                {
                    BoundColumn nameColumn201 = new BoundColumn();
                    nameColumn201.HeaderText = "Cash Disc";
                    nameColumn201.DataField = "Cash_Disc";

                    name1 = name1 + "," + "Cash Disc";
                    name2 = name2 + "," + "Cash_Disc";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn201);
                }
                BoundColumn nameColumn18 = new BoundColumn();
                nameColumn18.HeaderText = "BillAmt";
                nameColumn18.DataField = "BillAmt";

                name1 = name1 + "," + "BillAmt";
                name2 = name2 + "," + "BillAmt";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn18);
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    BoundColumn nameColumn181 = new BoundColumn();
                    nameColumn181.HeaderText = "NetAmt/Actual Buss";
                    nameColumn181.DataField = "ActualBusiness";

                    name1 = name1 + "," + "NetAmt/Actual Buss";
                    name2 = name2 + "," + "ActualBusiness";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn181);
                }
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    BoundColumn nameColumn21 = new BoundColumn();
                    nameColumn21.HeaderText = "BillRemark";
                    nameColumn21.DataField = "BillRemark";

                    name1 = name1 + "," + "BillRemark";
                    name2 = name2 + "," + "BillRemark";
                    name3 = name3 + "," + "G";
                    DataGrid1.Columns.Add(nameColumn21);
                }

               

                DataGrid1.DataSource = ds;
                if (chk_excel == "1")
                {
                    
                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    DataGrid1.ShowHeader = true;
                    DataGrid1.ShowFooter = true;
                    DataGrid1.DataBind();


                    //hw.Write("<p align=\"left\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
                    //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Billing Resister<b>");


                    //hw.WriteBreak();

                    DataGrid1.RenderControl(hw);

                    int sno11 = sno - 1;
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                if(adchk=="1")
                    Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td >Fmg:" + count1 + "</td><td >HouseAds:" + count2 + "</td><td align=\"right\" colspan=\"16\">TOTAL</td><td align=\"center\" >" + amtnew + "</td></tr></table>"));
                else
                    Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td >Fmg:" + count1 + "</td><td >HouseAds:" + count2 + "</td><td align=\"right\" colspan=\"15\">TOTAL</td><td align=\"center\" >" + amtnew + "</td></tr></table>"));
                    }
                    else
                    Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td >Fmg:" + count1 + "</td><td >HouseAds:" + count2 + "</td><td align=\"right\" colspan=\"14\">TOTAL</td><td align=\"center\" >" + amtnew + "</td></tr></table>"));
                }
                else
                {

                    string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                    string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                    string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                    string[][] colProperties ={ names, captions, formats };

                    QueryToCSV(ds, colProperties);
                }
                Response.Flush();
                Response.End();
            
          


        
    }
    private void QueryToCSV(DataSet dr, string[][] colProperties)
    {
        if (colProperties.Length > 0)
        {
            int counter;
            Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
            for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
            {
                counter = 0;
                Response.Write("\"");
                foreach (String column in colProperties[0])
                {
                    //dr.Tables[0].Rows[i].
                    Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                    if (counter < colProperties[0].Length - 1)
                    {
                        Response.Write("\",\"");
                    }
                    counter += 1;
                }
                Response.Write("\"\n");
            }
            //dr.Close();
            //tw.Close();
        }
    }
    private int getcolindex(DataSet ds, string col)
    {
        int i;
        for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
        {
            if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
            {
                goto td5;

            }
        }
    td5:
        return i;

    }
    private void pdf(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew,string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product="";

        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



      //  btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //int count = 0;
        //=======================================WATERMARK=========================================

        //try
        //{
        //    //string img = Server.MapPath("") + ("//") + "watermark.jpg";
        //    string img = Server.MapPath("") + ("//") + "DSC_473011.jpg";
        //    Watermark watermark = new Watermark(Image.getInstance(img), 150, 0);
        //    document.Add(watermark);
        //}
        //catch (Exception)
        //{
        //    Console.WriteLine("Are you sure you have the file 'DSC_473011.jpg' in the right path?");
        //}

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
      //  HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("-----------------------------------------------------------------------------  for official use only  ----------------------------------------------------------------------------- " + i2++), true);
     //   footer.Border = Rectangle.NO_BORDER;
    //    footer.Alignment = Element.ALIGN_CENTER;
   //     document.Footer = footer;

        document.Open();
       
        //---------------------------end-------------------------------------------------------
        int NumColumns =0;
        if(adchk=="1")
        NumColumns = 20;
    else 
        NumColumns = 18;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8);

        // ---------------table for heading-------------------------
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "SQL")
            //{
            //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //    ds = obj.billingonscreen(fromdt, dateto, region, product, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}

            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            //    // ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), temp_product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, edition, temp_agency, region, agencycat);
            //    if (adchk == "1")
            //        ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat, adchk, execode);
            //    else
            //        ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, editionname, temp_agency, region, agencycat, adchk, execode);

            //}
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            //Table tbl  = new Table(1);
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[30].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);
            //tbl.DefaultCell.Padding = -5;

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(fromdt.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));

          
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
                datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase("Bill No", font10));
            datatable.addCell(new Phrase("Bill Date", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString() + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[74].ToString(), font10));
            if(adchk=="1")
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[62].ToString(), font10));
            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[65].ToString() + "\n" + pdfxml.Tables[0].Rows[0].ItemArray[66].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[67].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[93].ToString(), font10));
            if(adchk=="1")
            datatable.addCell(new Phrase("Cash Disc", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[63].ToString(), font10));
            datatable.HeaderRows = 1;
            

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);

          
           
            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
                                
                
                
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Bill_No"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Bill_Date"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
             
               

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));

               

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["Area"].ToString()), font11));

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Rate"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                if (adchk == "1")
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Premium"].ToString(), font11));
              
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Color"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString(), font11));
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                if (ds.Tables[0].Rows[row]["SubCategory"].ToString() == "0")
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString() +"\n"+ "", font11));
                else
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Category"].ToString() + "\n" + ds.Tables[0].Rows[row]["SubCategory"].ToString(), font11));
               

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillAmt"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgencyComm"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["AgencyComm"].ToString() != "")
                    agencomm = agencomm + double.Parse(ds.Tables[0].Rows[row]["AgencyComm"].ToString());

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AddlAgencyTD"].ToString(), font11));

                if (adchk == "1")
                {
                    datatable.DefaultCell.VerticalAlignment = Element.ALIGN_RIGHT;
                    datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cash_Disc"].ToString(), font11));
                }

                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillRemark"].ToString(), font11));

                //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[row]["Rate"])
                //    count1++;
                //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[row]["Category"].ToString())
                //    count2++;
              
                if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                    count1++;
               
                if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                    count2++;

                row++;

            }
            
            document.Add(datatable);
             
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));
            document.Add(p3);
           
            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 13, 14, 10, 10, 8, 8, 10, 8, 8, 10,10,16 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1-1).ToString(), font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[68].ToString() + count1.ToString(), font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[69].ToString() + count2.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(chk_null(BillAmt.ToString()), font11));

            tbltotal.addCell(new Phrase("", font10));
           
            tbltotal.addCell(new Phrase("", font11));
           

            document.Add(tbltotal);

           


            document.Close();

            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }

    private iTextSharp.text.Image TextWriter(string p)
    {
        throw new Exception("The method or operation is not implemented.");
    }


    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["prm_billregister_print"] = "dateto~" + dateto + "~fromdate~" + fromdt + "~destination~" + destination + "~region~" + region + "~regionname~" + regionname + "~edition~" + edition + "~editionname~" + editionname + "~agtype~" + category + "~agtypetext~" + categorytext + "~agcat~" + agencycat + "~adtype~" + adtypenew + "~publication1~" + publb + "~adtypetext~" + adtypename + "~agcattext~" + agcattext + "~publicationcd~" + publicationcd + "~adchk~" + adchk + "~execode~" + execode + "~exename~" + exename + "~BreakDown~" + BreakDown + "~insertstatus~" + insertstatus;
            Response.Redirect("printbillregister.aspx");
        //Response.Redirect("printbillregister.aspx?dateto=" + dateto + "&fromdate=" + fromdt + "&destination=" + destination + "&region=" + region + "&regionname=" + regionname + "&edition=" + edition + "&editionname=" + editionname + "&agtype=" + category + "&agtypetext=" + categorytext + "&agcat=" + agencycat + "&adtype=" + adtypenew + "&publication1=" + publb + "&adtypetext=" + adtypename + "&agcattext=" + agcattext + "&publicationcd=" + publicationcd + "&adchk=" + adchk + "&execode="+execode+"&exename="+exename+"");
                
    }


    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (adchk == "1")
            {
                string check = e.Item.Cells[19].Text;
                string amt = e.Item.Cells[19].Text;

                if (check != "BillAmt")
                {
                    if (check != "&nbsp;")
                    {


                        string totalarea = e.Item.Cells[19].Text;
                        amtsum = Convert.ToDouble(totalarea);
                        amtnew = amtnew + amtsum;


                    }
                }
            }
            else
            {
                string check = e.Item.Cells[18].Text;
                string amt = e.Item.Cells[18].Text;

                if (check != "BillAmt")
                {
                    if (check != "&nbsp;")
                    {


                        string totalarea = e.Item.Cells[18].Text;
                        amtsum = Convert.ToDouble(totalarea);
                        amtnew = amtnew + amtsum;


                    }
                }
            }
        }
        else
        {
            if (adchk == "1")
            {
                string check = e.Item.Cells[19].Text;
                string amt = e.Item.Cells[19].Text;

                if (check != "BillAmt")
                {
                    if (check != "&nbsp;")
                    {


                        string totalarea = e.Item.Cells[19].Text;
                        amtsum = Convert.ToDouble(totalarea);
                        amtnew = amtnew + amtsum;


                    }
                }
            }
            else
            {
                string check = e.Item.Cells[18].Text;
                string amt = e.Item.Cells[18].Text;

                if (check != "BillAmt")
                {
                    if (check != "&nbsp;")
                    {


                        string totalarea = e.Item.Cells[18].Text;
                        amtsum = Convert.ToDouble(totalarea);
                        amtnew = amtnew + amtsum;


                    }
                }
            }
        }
      
    }
    private void onscreenbrk(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew, string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product = "";
        SqlDataAdapter da = new SqlDataAdapter();
        
        double agencomm1 = 0, agencomm2 = 0;
        double grossamt1 = 0, grossamt2 = 0;
        double billamt1 = 0, billamt2 = 0;
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        //        string tbl = "";
        StringBuilder tbl = new StringBuilder();

        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' valign='top'>");
        if (adchk == "1")
        {
            //tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
                tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left' colspan='2'>Client</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td><td class='middle31' valign='top' align='right'>Agency Addl</br>TD(%)</td><td class='middle31' valign='top' align='right'>Cash</br>Disc</td></tr>");

            }
        }
        else
        {
            //tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
                if (BreakDown == "1" || BreakDown == "0")
                {

                    tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left' colspan='2'>Client</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='right'>Gross Amt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td><td class='middle31' valign='top' align='right'>Box Charges</td><td class='middle31' valign='top' align='right'>BillAmt</td></tr>");
                    
                }
                else
                    tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left' colspan='2'>Client</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='right'>Agen Comm</td><td class='middle31' valign='top' align='right'>Gross Amt</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Box Charges</td></tr>");

            }
        }

        string breakonvalue = "";
        for (int i = 0; i <= cont - 1; i++)
        {
            if (breakonvalue != ds.Tables[0].Rows[i]["Agency"].ToString())
            {
                if (i != 0)
                {
                    tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total</b>");//</td>");
                    //tbl.Append("<td class='middle1212'>");
                    tbl.Append((i1 - 1).ToString() + "</td>");
                    tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
                    tbl.Append("</td>");

                    //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
                    //tbl.Append("&nbsp;</td>");
                    tbl.Append("<td class='middle1212'>&nbsp;");

                    tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'>" + chk_null(grossamt1.ToString()) + "</td><td class='middle1212' align='right'>" + chk_null(agencomm1.ToString()) + "</b></td>");
                    tbl.Append("<td class='middle1212' align='right'>");
                   
                    tbl.Append( "&nbsp;</td>");
                    grossamt1 = 0;
                    agencomm1 = 0;
                    tbl.Append("<td class='middle1212' align='right' colspan='4'>" + chk_null(billamt1.ToString()));
                    tbl.Append("</td>");
                    tbl.Append("</tr>");
                }
                tbl.Append("<tr  >");
                tbl.Append("<td class='rep_data' colspan='13' style= 'font-size:12px'><b>Agency&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl.Append(ds.Tables[0].Rows[i]["Agency"].ToString() + "</b></td>");
                tbl.Append("</tr >");
            }
                tbl.Append("<tr >");


                tbl.Append("<td class='rep_data'>");
                tbl.Append(i1++.ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left'>");
                tbl.Append(ds.Tables[0].Rows[i]["Bill_No"] + "</td>");

                tbl.Append("<td class='rep_data' align='left'>");
                tbl.Append(ds.Tables[0].Rows[i]["Bill_Date"] + "</td>");
                if (agnname == "0" || agnname == "")
                {
                    if (BreakDown == "1" || BreakDown == "0")
                    {
                    }
                    else
                    {
                        tbl.Append("<td class='rep_data' align='left'>");
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                        char[] agency = rrr1.ToCharArray();
                        int len111 = agency.Length;
                        int line11 = 0;
                        int ch_end1 = 0;
                        int ch_str1 = 0;
                        for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                        {
                            /**/
                            ch_end1 = ch_end1 + 16;
                            ch_str1 = ch_end1;
                            if (ch_end1 > len111)
                                ch_str1 = len111 - ch1;
                            else
                                ch_str1 = ch_end1 - ch1;

                            agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                            agency1 = agency1 + "</br>";
                            ch1 = ch1 + 16;
                            if (ch1 > len111)
                                ch1 = len111;/**/
                        }
                        tbl.Append(agency1 + "</td>");
                    }
                }

                tbl.Append("<td class='rep_data' align='left' colspan='2'>");
                string client1 = "";
                string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
                char[] client = rrr11.ToCharArray();
                int len1111 = client.Length;
                int line = 0;
                int ch_end11 = 0;
                int ch_str11 = 0;
                for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                {
                    /* */
                    ch_end11 = ch_end11 + 25;
                    ch_str11 = ch_end11;
                    if (ch_end11 > len1111)
                        ch_str11 = len1111 - ch11;
                    else
                        ch_str11 = ch_end11 - ch11;

                    client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                    client1 = client1 + "</br>";
                    ch11 = ch11 + 16;
                    if (ch11 > len1111)
                        ch11 = len1111;
                }
                tbl.Append(client1 + "</td>");

                //tbl.Append("<td class='rep_data' align='left'>");
                //tbl.Append(ds.Tables[0].Rows[i]["Publication"] + "</td>");

                //tbl.Append("<td class='rep_data' align='left'>");
                //tbl.Append(ds.Tables[0].Rows[i]["Package"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(chk_null(ds.Tables[0].Rows[i]["Area"].ToString()) + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(chk_null(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()) + "</td>");

                if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() != "")
                {
                    grossamt1 =grossamt1+ Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"]);
                    grossamt2 = grossamt2 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"]);
                }

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["AGCOMM"] + "</td>");

                if (ds.Tables[0].Rows[i]["AGCOMM"].ToString() != "")
                {
                    agencomm1 = agencomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["AGCOMM"]);
                    agencomm2 = agencomm2 + Convert.ToDouble(ds.Tables[0].Rows[i]["AGCOMM"]);
                }

               

                //tbl.Append("<td class='rep_data' align='left'>");
                //tbl.Append(ds.Tables[0].Rows[i]["Rate"] + "</td>");

                //if (adchk == "1")
                //{
                //    tbl.Append("<td class='rep_data' align='right'>");
                //    tbl.Append(ds.Tables[0].Rows[i]["Premium"] + "</td>");
                //}


                //tbl.Append("<td class='rep_data' align='left'>");
                //tbl.Append(ds.Tables[0].Rows[i]["Color"] + "</td>");

                //tbl.Append("<td class='rep_data' align='left'>");
                //tbl.Append(ds.Tables[0].Rows[i]["Category"]);// + "</td>");
                //tbl.Append("</br>");
                //if (ds.Tables[0].Rows[i]["SubCategory"].ToString() == "0")
                //    tbl.Append("</td>");
                //else
                //    tbl.Append(ds.Tables[0].Rows[i]["SubCategory"] + "</td>");



                //tbl.Append("<td class='rep_data' align='right'>");
                //tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["BOXCHRG"] + "</td>");



                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");

                if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                {
                    billamt1 = billamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                    billamt2 = billamt2 + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                }

                //if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                //    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

                //tbl.Append("<td class='rep_data' align='right'>");
                //tbl.Append(ds.Tables[0].Rows[i]["AgencyComm"] + "</td>");
                //if (ds.Tables[0].Rows[i]["AgencyComm"].ToString() != "")
                //    agencomm = agencomm + double.Parse(ds.Tables[0].Rows[i]["AgencyComm"].ToString());

                //if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                //    count1++;
                //if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                //    count2++;

                //tbl.Append("<td class='rep_data' align='right'>");
                //tbl.Append(ds.Tables[0].Rows[i]["BOXCHRG"] + "</td>");

                //if (adchk == "1")
                //{
                //    tbl.Append("<td class='rep_data' align='right'>");
                //    tbl.Append(ds.Tables[0].Rows[i]["Cash_Disc"] + "</td>");

                //}
                //tbl.Append("<td class='rep_data'>");
                //tbl.Append(ds.Tables[0].Rows[i]["BillRemark"] + "</td>");


                tbl.Append("</tr>");

            

            breakonvalue = ds.Tables[0].Rows[i]["Agency"].ToString();


        }
        tbl.Append("<tr >");

        tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");

        //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
        //tbl.Append("&nbsp;</td>");
        tbl.Append("<td class='middle1212'>&nbsp;");

        tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'>" + chk_null(grossamt1.ToString()) + "</td><td class='middle1212' align='right'>" + chk_null(agencomm1.ToString()) + "</b></td>");
        tbl.Append("<td class='middle1212' align='right'>");

        tbl.Append("&nbsp;</td>");
        grossamt1 = 0;
        agencomm1 = 0;
        tbl.Append("<td class='middle1212' align='right' colspan='4'>" +chk_null(billamt1.ToString()));
        tbl.Append("</td>");
        tbl.Append("</tr>");


        tbl.Append("<tr >");
        tbl.Append("<td class='middle1212'>");
        tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total Ads:</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");
       
        //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
        //tbl.Append("&nbsp;</td>");
        tbl.Append("<td class='middle1212'>&nbsp;");

        tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'>" + chk_null(grossamt2.ToString()) + "</td><td class='middle1212'><b>&nbsp;</b></td>");
        tbl.Append("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
        tbl.Append( "&nbsp;</td>");
        tbl.Append("<td class='middle1212' align='right' colspan='4'>" + chk_null(billamt2.ToString()));
        tbl.Append("</td>");
        tbl.Append("</tr>");
        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();


    }




    private void excelbrk(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agcat, string adtypenew, string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product = "";
        SqlDataAdapter da = new SqlDataAdapter();

        double agencomm1 = 0, agencomm2 = 0;
        double grossamt1 = 0, grossamt2 = 0;
        double billamt1 = 0, billamt2 = 0;
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        StringBuilder tbl = new StringBuilder();
        int cont = ds.Tables[0].Rows.Count;

        for (int i = 0; i < cont - 1; i++)
        {

            //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["Rate"])
            //    count1++;
            //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Category"].ToString())
            //    count2++;

            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

                count1++;

            if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

                count2++;
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";

        Response.ContentType = "text/csv";
        if (chk_excel == "1")
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        }
        else
        {
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
        }

        tbl.Append("<table border='1'><tr><td colspan='9' align='center'><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
        tbl.Append("<tr><td colspan='9' align='center'><b>Billing Register</b></td></tr>");
        tbl.Append("<tr><td ><b>Date From:</b></td><td colspan='3' align='left'>" + lblfrom.Text + "</td><td><b>Date To:</b></td><td  colspan='3' align='left'>" + lblto.Text + "</td><td><b>Run Date:</b></td><td  colspan='3' align='left'>" + lbldate.Text + "</td></tr>");
        tbl.Append("<tr><td><b>Publication:</b></td><td colspan='3' align='left'>" + lblcategory.Text + "</td><td><b>Edition:</b></td><td  colspan='3' align='left'>" + lblproduct.Text + "</td><td><b>Adtype:</b></td><td  colspan='3' align='left'>" + lbladtype.Text + "</td></tr>");
        tbl.Append("<tr><td><b>Region:</b></td><td colspan='3' align='left'>" + lblregion.Text + "</td><td><b>Agency Type:</b></td><td colspan='3' align='left'>" + lblagtype.Text + "</td><td><b>Agency Category:</b></td><td colspan='3' align='left'>" + lblagcat.Text + "</td></tr>");
        tbl.Append("<tr><td><b>Executive:</b></td><td  colspan='3' align='left'>" + lblexecutive.Text + "</td></tr></table>");
        //if (adchk == "1")
        //{
        //    tblgrid.InnerHtml += tbl;

        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    tblgrid.Visible = true;
        //    tblgrid.RenderControl(hw);
        //    Response.Write(sw.ToString());
        //}


        //        string tbl = "";


        tbl.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' valign='top' border='1'>");
        if (adchk == "1")
        {
            //tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
                tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left' colspan='2'>Client</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td><td class='middle31' valign='top' align='right'>Agency Addl</br>TD(%)</td><td class='middle31' valign='top' align='right'>Cash</br>Disc</td></tr>");

            }
        }
        else
        {
            //tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");
            if (hiddenascdesc.Value == "")
            {
                if (BreakDown == "1" || BreakDown == "0")
                {

                    tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left' colspan='2'>Client</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='right'>Gross Amt</td><td class='middle31' valign='top' align='right'>Agen</br>Comm</td><td class='middle31' valign='top' align='right'>Box Charges</td><td class='middle31' valign='top' align='right'>BillAmt</td></tr>");

                }
                else
                    tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left' colspan='2'>Client</td><td class='middle31' valign='top' align='right'>Area</td><td class='middle31' valign='top' align='right'>Agen Comm</td><td class='middle31' valign='top' align='right'>Gross Amt</td><td class='middle31' valign='top' align='right'>BillAmt</td><td class='middle31' valign='top' align='right'>Box Charges</td></tr>");

            }
        }

        string breakonvalue = "";
        for (int i = 0; i <= cont - 1; i++)
        {
            if (breakonvalue != ds.Tables[0].Rows[i]["Agency"].ToString())
            {
                if (i != 0)
                {
                    tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total</b>");//</td>");
                    //tbl.Append("<td class='middle1212'>");
                    tbl.Append((i1 - 1).ToString() + "</td>");
                    tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
                    tbl.Append("</td>");

                    //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
                    //tbl.Append("&nbsp;</td>");
                    tbl.Append("<td class='middle1212'>&nbsp;");

                    tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'>" + grossamt1 + "</td><td class='middle1212' align='right'>" + agencomm1 + "</b></td>");
                    tbl.Append("<td class='middle1212' align='right'>");

                    tbl.Append("&nbsp;</td>");
                    grossamt1 = 0;
                    agencomm1 = 0;
                    tbl.Append("<td class='middle1212' align='right' >" + billamt1);
                    tbl.Append("</td>");
                    tbl.Append("</tr>");
                }
                tbl.Append("<tr  >");
                tbl.Append("<td class='rep_data' colspan='9' style= 'font-size:12px'><b>Agency&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl.Append(ds.Tables[0].Rows[i]["Agency"].ToString() + "</b></td>");
                tbl.Append("</tr >");
            }
            tbl.Append("<tr >");


            tbl.Append("<td class='rep_data'>");
            tbl.Append(i1++.ToString() + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_No"] + "</td>");

            tbl.Append("<td class='rep_data' align='left'>");
            tbl.Append(ds.Tables[0].Rows[i]["Bill_Date"] + "</td>");
            if (agnname == "0" || agnname == "")
            {
                if (BreakDown == "1" || BreakDown == "0")
                {
                }
                else
                {
                    tbl.Append("<td class='rep_data' align='left'>");
                    string agency1 = "";
                    string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
                    char[] agency = rrr1.ToCharArray();
                    int len111 = agency.Length;
                    int line11 = 0;
                    int ch_end1 = 0;
                    int ch_str1 = 0;
                    for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                    {
                        /**/
                        ch_end1 = ch_end1 + 16;
                        ch_str1 = ch_end1;
                        if (ch_end1 > len111)
                            ch_str1 = len111 - ch1;
                        else
                            ch_str1 = ch_end1 - ch1;

                        agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                        agency1 = agency1 + "</br>";
                        ch1 = ch1 + 16;
                        if (ch1 > len111)
                            ch1 = len111;/**/
                    }
                    tbl.Append(agency1 + "</td>");
                }
            }

            tbl.Append("<td class='rep_data' align='left' colspan='2'>");
            string client1 = "";
            string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            char[] client = rrr11.ToCharArray();
            int len1111 = client.Length;
            int line = 0;
            int ch_end11 = 0;
            int ch_str11 = 0;
            for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
            {
                /* */
                ch_end11 = ch_end11 + 25;
                ch_str11 = ch_end11;
                if (ch_end11 > len1111)
                    ch_str11 = len1111 - ch11;
                else
                    ch_str11 = ch_end11 - ch11;

                client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                client1 = client1 + "</br>";
                ch11 = ch11 + 16;
                if (ch11 > len1111)
                    ch11 = len1111;
            }
            tbl.Append(client1 + "</td>");

            //tbl.Append("<td class='rep_data' align='left'>");
            //tbl.Append(ds.Tables[0].Rows[i]["Publication"] + "</td>");

            //tbl.Append("<td class='rep_data' align='left'>");
            //tbl.Append(ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["Area"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["GROSS_AMT"] + "</td>");

            if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() != "")
            {
                grossamt1 = grossamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"]);
                grossamt2 = grossamt2 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"]);
            }

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["AGCOMM"] + "</td>");

            if (ds.Tables[0].Rows[i]["AGCOMM"].ToString() != "")
            {
                agencomm1 = agencomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["AGCOMM"]);
                agencomm2 = agencomm2 + Convert.ToDouble(ds.Tables[0].Rows[i]["AGCOMM"]);
            }



            //tbl.Append("<td class='rep_data' align='left'>");
            //tbl.Append(ds.Tables[0].Rows[i]["Rate"] + "</td>");

            //if (adchk == "1")
            //{
            //    tbl.Append("<td class='rep_data' align='right'>");
            //    tbl.Append(ds.Tables[0].Rows[i]["Premium"] + "</td>");
            //}


            //tbl.Append("<td class='rep_data' align='left'>");
            //tbl.Append(ds.Tables[0].Rows[i]["Color"] + "</td>");

            //tbl.Append("<td class='rep_data' align='left'>");
            //tbl.Append(ds.Tables[0].Rows[i]["Category"]);// + "</td>");
            //tbl.Append("</br>");
            //if (ds.Tables[0].Rows[i]["SubCategory"].ToString() == "0")
            //    tbl.Append("</td>");
            //else
            //    tbl.Append(ds.Tables[0].Rows[i]["SubCategory"] + "</td>");



            //tbl.Append("<td class='rep_data' align='right'>");
            //tbl.Append(ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");

            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(ds.Tables[0].Rows[i]["BOXCHRG"] + "</td>");



            tbl.Append("<td class='rep_data' align='right'>");
            tbl.Append(chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");

            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
            {
                billamt1 = billamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
                billamt2 = billamt2 + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
            }

            //if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
            //    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            //tbl.Append("<td class='rep_data' align='right'>");
            //tbl.Append(ds.Tables[0].Rows[i]["AgencyComm"] + "</td>");
            //if (ds.Tables[0].Rows[i]["AgencyComm"].ToString() != "")
            //    agencomm = agencomm + double.Parse(ds.Tables[0].Rows[i]["AgencyComm"].ToString());

            //if (ds.Tables[0].Rows[i]["booktype"].ToString() == "2")

            //    count1++;
            //if (ds.Tables[0].Rows[i]["booktype"].ToString() == "4")

            //    count2++;

            //tbl.Append("<td class='rep_data' align='right'>");
            //tbl.Append(ds.Tables[0].Rows[i]["BOXCHRG"] + "</td>");

            //if (adchk == "1")
            //{
            //    tbl.Append("<td class='rep_data' align='right'>");
            //    tbl.Append(ds.Tables[0].Rows[i]["Cash_Disc"] + "</td>");

            //}
            //tbl.Append("<td class='rep_data'>");
            //tbl.Append(ds.Tables[0].Rows[i]["BillRemark"] + "</td>");


            tbl.Append("</tr>");



            breakonvalue = ds.Tables[0].Rows[i]["Agency"].ToString();


        }
        tbl.Append("<tr >");

        tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");

        //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
        //tbl.Append("&nbsp;</td>");
        tbl.Append("<td class='middle1212'>&nbsp;");

        tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'>" + grossamt1 + "</td><td class='middle1212' align='right'>" + agencomm1 + "</b></td>");
        tbl.Append("<td class='middle1212' align='right'>");

        tbl.Append("&nbsp;</td>");
        grossamt1 = 0;
        agencomm1 = 0;
        tbl.Append("<td class='middle1212' align='left'>" + billamt1);
        tbl.Append("</td>");
        tbl.Append("</tr>");


        tbl.Append("<tr >");
        tbl.Append("<td class='middle1212'>");
        tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total Ads:</b>");//</td>");
        //tbl.Append("<td class='middle1212'>");
        tbl.Append((i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
        tbl.Append("</td>");

        //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
        //tbl.Append("&nbsp;</td>");
        tbl.Append("<td class='middle1212'>&nbsp;");

        tbl.Append("<td class='middle1212'>&nbsp;</td><td class='middle1212' align='right'>" + grossamt2 + "</td><td class='middle1212'><b>&nbsp;</b></td>");
        tbl.Append("<td class='middle1212' align='right'>");
        double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
        tbl.Append("&nbsp;</td>");
        tbl.Append("<td class='middle1212' align='right' colspan='0'>" + billamt2);
        tbl.Append("</td>");
        tbl.Append("</tr>");
        tbl.Append("</table>");
        tblgrid.InnerHtml = tbl.ToString();

        //if (adchk == "1")
        //{
           // tblgrid.InnerHtml += tbl;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            tblgrid.Visible = true;
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
     //   }

        Response.Flush();
        Response.End();



    }
}