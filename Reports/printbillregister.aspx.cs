using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
using System.Text;

public partial class printbillregister : System.Web.UI.Page
{
    int maxlimit = 15;
    string dateto = "", fromdt = "", destination = "", region = "", regionname = "", edition = "", editionname = "", category = "", categorytext = "";
    string agencycat = "", adtypenew = "", publb = "", adtypename = "", agcattext = "", publicationcd = "";
    double BillAmt = 0;
    double agencomm = 0;
    int count1 = 0;
    int count2 = 0;
    int a = 0;
    string day = "", month = "", year = "", date = "",adchk="";
    string execode = "", exename = "";
    string BreakDown = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;

    int comm_position = 0;
    string status = "";

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
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[41].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[30].ToString();


        ds = (DataSet)Session["billregister"];
        string prm = Session["prm_billregister_print"].ToString();
        string[] prm_Array = new string[36];
        prm_Array = prm.Split('~');


        //if (ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString() == "3")
        //{
        //    comm_position = Convert.ToInt16(ConfigurationSettings.AppSettings["COMMA_FORMAT"].ToString());
        //}

        dateto = prm_Array[1];// Request.QueryString["dateto"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        destination = prm_Array[5]; //Request.QueryString["destination"].ToString();
        region = prm_Array[7]; //Request.QueryString["region"].ToString();
        regionname = prm_Array[9]; //Request.QueryString["regionname"].ToString();
        edition = prm_Array[11]; //Request.QueryString["edition"].ToString();
        editionname = prm_Array[13]; //Request.QueryString["editionname"].ToString();
        category = prm_Array[15]; //Request.QueryString["agtype"].ToString();
        categorytext = prm_Array[17]; //Request.QueryString["agtypetext"].ToString();
        agencycat = prm_Array[19]; //Request.QueryString["agcat"].ToString();
        adtypenew = prm_Array[21]; //Request.QueryString["adtype"].ToString();
        publb = prm_Array[23]; //Request.QueryString["publication1"].ToString();
        adtypename = prm_Array[25]; //Request.QueryString["adtypetext"].ToString();
        agcattext = prm_Array[27]; //Request.QueryString["agcattext"].ToString();
        publicationcd = prm_Array[29]; //Request.QueryString["publicationcd"].ToString();
        adchk = prm_Array[31]; //Request.QueryString["adchk"].ToString();
        execode = prm_Array[33]; //Request.QueryString["execode"].ToString();
        exename = prm_Array[35]; //Request.QueryString["exename"].ToString();
        BreakDown = prm_Array[37];
        status = prm_Array[39];


        if (status == "--Select Insert Status--")
        {
            lblstatus.Text = "ALL".ToString();
        }
        else
        {
            lblstatus.Text = status.ToString();
        }

        if (edition == "0" || edition=="")
        {
           lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname.ToString();
        }

        if (publicationcd == "0")
        {
            lblpublication.Text= "ALL".ToString();
        }
        else
        {
            lblpublication.Text = publb.ToString();
        }

      
        if (adtypenew == "0")
        {
            lbladtype.Text= "ALL".ToString();
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
           lblagcat.Text= "ALL".ToString();
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
        lblfrom.Text = fromdt;
        lblto.Text = dateto;
        lbldate.Text = date;

        if (destination == "5")
            onscreenamt();
        else
            if (BreakDown == "1")
            {
                screenbrk(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
            }
            else
            {
                screen(fromdt, dateto, region, edition, category, Session["compcode"].ToString(), Session["dateformat"].ToString(), agencycat, adtypenew, execode);
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
       // string tbl = "";
        StringBuilder tbl = new StringBuilder();
        
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
               tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if (ver == 6.0)
                {
                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
            }    
            //tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");
                    if (p == pagecount - 1)
                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl.Append("</table></P>");
                        if (p == pagecount - 1)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table>");
                        if (p == pagecount - 1)
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                    }
                }



                tbl.Append("<tr valign='top'>");

                tbl.Append("<td class='middle111' align='right' colspan='19'>" + "Page  " + s + "  of  " + pagecount);

                tbl.Append("</td></tr>");

                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");

                tbl.Append("<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>");

                tbl.Append("<tr valign='top'><td class='middle31' valign='top'>S.No.</td><td class='middle31' valign='top'  align='left'>Booking</br>Id</td><td class='middle31' valign='top'  align='left'>Bill</br>No</td><td class='middle31' valign='top'  align='left'>Bill</br>Date</td><td class='middle31' valign='top' align='left'>Agency</td><td class='middle31' valign='top' align='left'>Client</td><td class='middle31' valign='top' align='left'>Publication</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Height</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Width</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Area</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Page</br>No</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Card</br>Rate</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Bill</br>Rate</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Gross</br>Amt</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Agen</br>Comm</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Box</br>Charges</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">NetAmt/</br>ActBuss</td><td class='middle31' valign='top' align='right' style=\"padding-left:4px\">Bill</br>Amt</td></tr>");


                for (int i = ct; i < ds.Tables[0].Rows.Count && i < fr; i++)
                {


                    a = i;
                    a = a + 1;


                    tbl.Append("<tr >");


                    tbl.Append("<td class='rep_data'>");
                    tbl.Append(a.ToString() + "</td>");

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
                    tbl.Append(ds.Tables[0].Rows[i]["AgencyTDAmt"] + "</td>");
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
                        tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString())).ToString("F2")), comm_position) + "</td>");
                    }
                    else
                        tbl.Append("</td>");





                    tbl.Append("</tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                   

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }



            tbl.Append("<tr >");
            tbl.Append("<tr >");
            tbl.Append("<td class='middle1212'>");
            tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total Ads:</b>");//</td>");
            //tbl.Append("<td class='middle1212'>");
            tbl.Append(cont.ToString() + "</td>");
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
            div1.InnerHtml = tbl.ToString();
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }

    }
    public void screen(string fromdt,string dateto,string region,string edition,string category,string compcode,string dateformat,string agencycat,string adtypenew,string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product = "";
       
        //DataSet ds = new DataSet();
        //NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //if (adchk == "1")
        //    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat, adchk, execode);
        //else
        //    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, editionname, temp_agency, region, agencycat, adchk, execode);
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
     
      //  string tbl = "";
        StringBuilder tbl = new StringBuilder();
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            //if (browser.Browser == "Firefox")
            //{
            //    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            //}
            //else if (browser.Browser == "IE")
            //{
            //    if ((ver == 7.0) || (ver == 8.0))
            //    {
            //        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            //    }
            //    else if (ver == 6.0)
            //    {
            //        tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            //    }
            //}    
            //tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {


                    tbl.Append( "</table></P>");
                    if (p == pagecount || p == 0)
                        tbl.Append("<P><table cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        tbl.Append("<P style='page-break-after:always;'><table cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                }

                else if (browser.Browser == "IE")
                {


                    tbl.Append( "</table></P>");
                    if (p == pagecount - 1)
                       tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");


                }

               
                  //  tbl += "</table>";
                    //tbl += "</br>";
                  //  tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                //    if (p==0)
                //{
                //     tbl += "<tr><td class='p_head' colspan='15'>Billing Register</td></tr>";
                   
                //}
                    tbl.Append( "<tr valign='top'>");
                    if (adchk == "1")
                    tbl.Append( "<td class='middle111' align='right' colspan='20'>" + "Page  " + s + "  of  " + pagecount);
                    else
                    tbl.Append( "<td class='middle111' align='right' colspan='18'>" + "Page  " + s + "  of  " + pagecount);
                    tbl.Append( "</td></tr>");

                    tbl.Append("<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append( "<tr></tr>");
                    tbl.Append("<tr></tr>");

                    tbl.Append( "<tr>");
                    tbl.Append( "<td class='middle31new' valign='top'>" + "S.No." + "</td>");
                    tbl.Append( "<td class='middle31new' align='left' valign='top'>" + "Booking"+"</br>"+"Id" + "</td>");
                    tbl.Append( "<td class='middle31new' align='left' valign='top'>" + "Bill" + "</br>" + "No" + "</td>");
                    tbl.Append( "<td class='middle31new' align='left' valign='top'>" + "Bill" + "</br>" + "Date" + "</td>");
                    tbl.Append( "<td class='middle31new' align='left' valign='top'>" + "Agency" + "</td>");
                    tbl.Append( "<td class='middle31new' align='left' valign='top'>" + "Client" + "</td>");
                    tbl.Append( "<td class='middle31new' align='left' valign='top'>" + "Publication" + "</td>");
                    tbl.Append( "<td class='middle31new' valign='top' align='left'>" + "Package" + "</td>");
                    tbl.Append( "<td class='middle31new' align='right' valign='top'>" + "Area" + "&nbsp;&nbsp;</td>");
                    tbl.Append( "<td class='middle31new' valign='top' align='left'>" + "Revenue" + "</br>" + "Center" + "</td>");
                    tbl.Append( "<td class='middle31new' valign='top' align='left'>" + "Rate" + "</br>" + "Code" + "</td>");
                if(adchk=="1")
                    tbl.Append( "<td class='middle31new' align='right' valign='top'>" + "Premium" + "&nbsp;&nbsp;</td>");

                    tbl.Append( "<td class='middle31new' valign='top' align='left'>" + "Color" + "</td>");
                    tbl.Append( "<td class='middle31new' valign='top' align='left'>" + "Catg" + "</br>" + "Subcat" + "</td>");
                    
                    tbl.Append( "<td class='middle31new' align='right' valign='top'>" +"Rate" + "</td>");
                    tbl.Append( "<td class='middle31new' align='right' valign='top'>" + "Bill" + "</br>" + "Amt" + "</td>");
                    tbl.Append( "<td class='middle31new' align='right' valign='top'>" + "Agen" + "</br>" + "Comm" + "</td>");
                    tbl.Append( "<td class='middle31new' align='right' valign='top'>" + "Agency Addl&nbsp;&nbsp;" + "</br>" + "TD(%)&nbsp;&nbsp;" + "</td>");
                    if (adchk == "1")
                        tbl.Append( "<td class='middle31new' align='right' valign='top'>" + "Cash&nbsp;&nbsp;" + "</br>" + "Disc&nbsp;&nbsp;" + "</td>");

                    tbl.Append( "<td class='middle31new' valign='top' align='left'>" + "Bill" + "</br>" + "Remark" + "</td>");
                    tbl.Append( "</tr>");
                
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {
                    
                         a = d;
                        a = a + 1;

                       tbl.Append( "<tr>");
                       tbl.Append("<td class='rep_data'>");
                       tbl.Append(a.ToString() + "</td>");
                       tbl.Append("<td class='rep_data' align='left'>");

                       string cioid1 = "";
                       string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
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
                        //string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
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
                        tbl.Append(ds.Tables[0].Rows[d]["Bill_No"] + "</td>");
                        tbl.Append("<td class='rep_data' align='left'>");
                        tbl.Append(ds.Tables[0].Rows[d]["Bill_Date"] + "</td>");
                        //tbl = tbl + (ds.Tables[0].Rows[d]["Agency"] + "</td>");
                        tbl.Append("<td class='rep_data' align='left'>");
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
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
                       //tbl = tbl + (ds.Tables[0].Rows[d]["Client"] + "</td>");
                        string client1 = "";
                        string rrr11 = ds.Tables[0].Rows[d]["Client"].ToString();
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
                        tbl.Append (client1 + "</td>");
                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["Package"] + "</td>");
                        tbl.Append ("<td class='rep_data' align='right'>");
                        tbl.Append (ds.Tables[0].Rows[d]["Area"] + "&nbsp;&nbsp;</td>");
                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");
                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["Rate"] + "</td>");
                        if (adchk == "1")
                        {
                            tbl.Append ("<td class='rep_data' align='right'>");
                            tbl.Append (ds.Tables[0].Rows[d]["Premium"] + "&nbsp;&nbsp;</td>");
                        }




                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["Color"] + "</td>");

                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["Category"]);// + "</td>");
                        tbl.Append("</br>");
                        if (ds.Tables[0].Rows[d]["SubCategory"].ToString() == "0")
                            tbl.Append ("</td>");
                        else
                            tbl.Append (ds.Tables[0].Rows[d]["SubCategory"] + "</td>");


                        tbl.Append ("<td class='rep_data' align='right'>");
                        tbl.Append (ds.Tables[0].Rows[d]["AgreedRate"] + "&nbsp</td>");
                        tbl.Append ("<td class='rep_data' align='right'>");
                        tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(ds.Tables[0].Rows[d]["BillAmt"].ToString())).ToString("F2")), comm_position) + "</td>");
                        if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                            BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());

                        tbl.Append ("<td class='rep_data' align='right'>");
                        tbl.Append (ds.Tables[0].Rows[d]["AgencyComm"] + "</td>");
                        if (ds.Tables[0].Rows[d]["AgencyComm"].ToString() != "")
                            agencomm = agencomm + double.Parse(ds.Tables[0].Rows[d]["AgencyComm"].ToString());
                        tbl.Append ("<td class='rep_data' align='right'>");
                        tbl.Append (ds.Tables[0].Rows[d]["AddlAgencyTD"] + "&nbsp;&nbsp;</td>");
                        if (adchk == "1")
                        {
                            tbl.Append ("<td class='rep_data' align='right'>");
                            tbl.Append (ds.Tables[0].Rows[d]["Cash_Disc"] + "&nbsp;&nbsp;</td>");
                            
                        }

                        tbl.Append ("<td class='rep_data' align='left'>");
                        tbl.Append (ds.Tables[0].Rows[d]["BillRemark"] + "</td>");

                        //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["Rate"])
                        //    count1++;
                        //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Category"].ToString())
                        //    count2++;
                        //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[i]["Rate"])
                        if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")

                            count1++;
                        //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[i]["Category"].ToString())
                        if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")

                            count2++;
                        tbl.Append( "</tr>");

                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        tbl.Append( "<tr></tr>");
                        
                      
                  
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
               

            }
           
            //tbl += "</table>";
            //tbl += "<table>";

           // tbl = tbl + ("<tr >");

           
           // tbl = tbl + ("<tr >");
          //  tbl = tbl + ("<td class='middle13'>");
            tbl.Append ("<tr><td class='middle1212' align='left' ><b>Total Ads.</b></td>");
            tbl.Append ("<td class='middle1212'>");
            tbl.Append (a.ToString() + "</td>");
            tbl.Append ("<td class='middle1212'>&nbsp;</td>");
            tbl.Append ("<td class='middle1212'>&nbsp;</td>");
            tbl.Append ("<td class='middle1212'><b>FMG:</b>");
            tbl.Append (count1.ToString() + "</td>");
            tbl.Append ("<td class='middle1212' ><b>HouseAd:</b>");
            tbl.Append (count2.ToString() + "</td>");
            if(adchk=="1")
            tbl.Append ("<td class='middle1212' colspan='9'>&nbsp;</td>");
            else
            tbl.Append ("<td class='middle1212' colspan='7'>&nbsp;</td>");
           
          


            tbl.Append ("<td class='middle1212'><b>Total:</b></td>");
            tbl.Append ("<td class='middle1212' align='right'>");
            double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
            tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(cal.ToString()).ToString("F2")), comm_position) + "</td>");
            tbl.Append ("<td class='middle1212'>&nbsp;</td>");
            tbl.Append ("<td class='middle1212'>&nbsp;</td>");
            tbl.Append ("<td class='middle1212' align='right'  >&nbsp;");
            tbl.Append ("</td>");
            tbl.Append ("</tr>");
            if (browser.Browser == "Firefox")
            {
                tbl.Append ( "</table></P>");

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl.Append ( "</table></P>");

                }
                else if (ver == 6.0)
                {
                    tbl.Append ("</table>");

                }
            }  
           // tbl += "</table>";
          
            div1.Visible = true;
            div1.InnerHtml = tbl.ToString();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }


    public void screenbrk(string fromdt, string dateto, string region, string edition, string category, string compcode, string dateformat, string agencycat, string adtypenew, string execode)
    {
        string temp_agname = "", temp_adtype = "", temp_pubcent = "", temp_edition = "", temp_agency = "", temp_product = "";

        //DataSet ds = new DataSet();
        //NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //if (adchk == "1")
        //    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, categorytext, edition, temp_agency, region, agencycat, adchk, execode);
        //else
        //    ds = obj.billreg(fromdt, dateto, Session["compcode"].ToString(), publicationcd, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtypenew, temp_pubcent, category, editionname, temp_agency, region, agencycat, adchk, execode);
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        //  string tbl = "";
        StringBuilder tbl = new StringBuilder();
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        double agencomm1 = 0, agencomm2 = 0;
        double grossamt1 = 0, grossamt2 = 0;
        double billamt1 = 0, billamt2 = 0;
        int d1 = 0;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if (ver == 6.0)
                {
                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
            }
            //tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");
                    if (p == pagecount - 1)
                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl.Append("</table></P>");
                        if (p == pagecount - 1)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table>");
                        if (p == pagecount - 1)
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                    }
                }


                //  tbl += "</table>";
                //tbl += "</br>";
                //  tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                //    if (p==0)
                //{
                //     tbl += "<tr><td class='p_head' colspan='15'>Billing Register</td></tr>";

                //}
                tbl.Append("<tr valign='top'>");
                if (adchk == "1")
                    tbl.Append("<td class='middle111' align='right' colspan='20'>" + "Page  " + s + "  of  " + pagecount);
                else
                    tbl.Append("<td class='middle111' align='right' colspan='20'>" + "Page  " + s + "  of  " + pagecount);
                tbl.Append("</td></tr>");

                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");
                tbl.Append("<tr></tr>");

                tbl.Append("<tr>");
                tbl.Append("<td class='middle31new' valign='top'>" + "S.No." + "</td>");
                //tbl.Append("<td class='middle31new' align='left' valign='top'>" + "Booking" + "</br>" + "Id" + "</td>");
                tbl.Append("<td class='middle31new' align='left' valign='top'>" + "Bill" + "</br>" + "No" + "</td>");
                
                tbl.Append("<td class='middle31new' align='left' valign='top'>" + "Bill" + "</br>" + "Date" + "</td>");
                if (BreakDown != "1")
                {
                    tbl.Append("<td class='middle31new' align='left' valign='top'>" + "Agency" + "</td>");
                }
                tbl.Append("<td class='middle31new' align='left' valign='top'>" + "Client" + "</td>");
                //tbl.Append("<td class='middle31new' align='left' valign='top'>" + "Publication" + "</td>");
               // tbl.Append("<td class='middle31new' valign='top' align='left'>" + "Package" + "</td>");
                tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Area" + "&nbsp;&nbsp;</td>");
                tbl.Append("<td class='middle31new' valign='top' align='right'>" + "Gross" + "</br>" + "Amt" + "</td>");
                tbl.Append("<td class='middle31new' valign='top' align='right'>" + "Agen" + "</br>" + "Comm" + "</td>");
                
                //tbl.Append("<td class='middle31new' valign='top' align='left'>" + "Rate" + "</br>" + "Code" + "</td>");
                //if (adchk == "1")
                //    tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Premium" + "&nbsp;&nbsp;</td>");

                //tbl.Append("<td class='middle31new' valign='top' align='left'>" + "Color" + "</td>");
                //tbl.Append("<td class='middle31new' valign='top' align='left'>" + "Catg" + "</br>" + "Subcat" + "</td>");

                //tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Rate" + "</td>");
                tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Box" + "</br>" + "Charges" + "</td>");
                tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Bill" + "</br>" + "Amt" + "</td>");
                
                //tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Agency Addl&nbsp;&nbsp;" + "</br>" + "TD(%)&nbsp;&nbsp;" + "</td>");
                //if (adchk == "1")
                //    tbl.Append("<td class='middle31new' align='right' valign='top'>" + "Cash&nbsp;&nbsp;" + "</br>" + "Disc&nbsp;&nbsp;" + "</td>");

                //tbl.Append("<td class='middle31new' valign='top' align='left'>" + "Bill" + "</br>" + "Remark" + "</td>");
                tbl.Append("</tr>");
                string breakonvalue = "";
                
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                    if (breakonvalue != ds.Tables[0].Rows[d]["Agency"].ToString())
                    {
                        if (d != 0)
                        {
                            tbl.Append("<tr><td class='middle1212'><b>Total&nbsp;&nbsp;</b>");//</td>");
                            //tbl.Append("<td class='middle1212'>");
                            tbl.Append((d).ToString() + "</td>");
                            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
                            tbl.Append("</td>");

                            //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
                            //tbl.Append("&nbsp;</td>");
                            tbl.Append("<td class='middle1212'>&nbsp;");

                            tbl.Append("<td class='middle1212'  align='right'>&nbsp;</td><td class='middle1212' align='right'>" + chk_null(grossamt1.ToString()) + "</td><td class='middle1212' align='right'>" + chk_null(agencomm1.ToString()) + "</b></td>");
                           
                            grossamt1 = 0;
                            agencomm1 = 0;
                            tbl.Append("<td class='middle1212' align='right' colspan='4'>" + chk_null(billamt1.ToString()));
                            tbl.Append("</td>");
                            tbl.Append("</tr>");
                        }
                        tbl.Append("<tr  >");
                        tbl.Append("<td class='rep_data' colspan='13' align='left' style= 'font-size:12px'><b>Agency&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                        tbl.Append(ds.Tables[0].Rows[d]["Agency"].ToString() + "</b></td>");
                        tbl.Append("</tr >");
                    }

                    tbl.Append("<tr>");
                    tbl.Append("<td class='rep_data'>");
                    tbl.Append(a.ToString() + "</td>");
                   
                   


                    tbl.Append("<td class='rep_data' align='left'>");
                    tbl.Append(ds.Tables[0].Rows[d]["Bill_No"] + "</td>");
                    tbl.Append("<td class='rep_data' align='left'>");
                    tbl.Append(ds.Tables[0].Rows[d]["Bill_Date"] + "</td>");
                    



                    tbl.Append("<td class='rep_data' align='left'>");
                    //tbl = tbl + (ds.Tables[0].Rows[d]["Client"] + "</td>");
                    string client1 = "";
                    string rrr11 = ds.Tables[0].Rows[d]["Client"].ToString();
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
                    //tbl.Append("<td class='rep_data' align='left'>");
                    //tbl.Append(ds.Tables[0].Rows[d]["Publication"] + "</td>");
                    //tbl.Append("<td class='rep_data' align='left'>");
                    //tbl.Append(ds.Tables[0].Rows[d]["Package"] + "</td>");
                    tbl.Append("<td class='rep_data' align='right'>");
                    tbl.Append(chk_null(ds.Tables[0].Rows[d]["Area"].ToString()) + "&nbsp;&nbsp;</td>");
                    tbl.Append("<td class='rep_data' align='right'>");
                    tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(ds.Tables[0].Rows[d]["GROSS_AMT"].ToString())).ToString("F2")), comm_position) + "</td>");
                    if (ds.Tables[0].Rows[d]["GROSS_AMT"].ToString() != "")
                    {
                        grossamt1 = grossamt1 + Convert.ToDouble(ds.Tables[0].Rows[d]["GROSS_AMT"]);
                        grossamt2 = grossamt2 + Convert.ToDouble(ds.Tables[0].Rows[d]["GROSS_AMT"]);
                    }

                    tbl.Append("<td class='rep_data' align='right'>");
                    tbl.Append(ds.Tables[0].Rows[d]["AGCOMM"] + "</td>");
                    if (ds.Tables[0].Rows[d]["AGCOMM"].ToString() != "")
                    {
                        agencomm1 = agencomm1 + Convert.ToDouble(ds.Tables[0].Rows[d]["AGCOMM"]);
                        agencomm2 = agencomm2 + Convert.ToDouble(ds.Tables[0].Rows[d]["AGCOMM"]);
                    }

                   
                   

                    tbl.Append("<td class='rep_data' align='right'>");
                    tbl.Append(ds.Tables[0].Rows[d]["BOXCHRG"] + "</td>");


                    tbl.Append("<td class='rep_data' align='right'>");
                    tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(ds.Tables[0].Rows[d]["BillAmt"].ToString())).ToString("F2")), comm_position) + "</td>");
                    if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                    {
                        billamt1 = billamt1 + Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"]);
                        billamt2 = billamt2 + Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"]);
                    }

                    
                    breakonvalue = ds.Tables[0].Rows[d]["Agency"].ToString();
                        count2++;
                    tbl.Append("</tr>");

                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");
                    tbl.Append("<tr></tr>");

                    d1 = d;

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }

            //tbl += "</table>";
            //tbl += "<table>";

            // tbl = tbl + ("<tr >");


            // tbl = tbl + ("<tr >");
            //  tbl = tbl + ("<td class='middle13'>");

            tbl.Append("<tr><td class='middle1212' colspan='2'><b>Total</b>");//</td>");
            //tbl.Append("<td class='middle1212'>");
            tbl.Append((d1).ToString() + "</td>");
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;");
            tbl.Append("</td>");

            //tbl.Append("<td class='middle1212' colspan='2'><b>&nbsp;</b>");
            //tbl.Append("&nbsp;</td>");
            tbl.Append("<td class='middle1212'>&nbsp;");

            tbl.Append("<td class='middle1212' align='right'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(grossamt1.ToString())).ToString("F2")), comm_position) + "</td><td class='middle1212' align='right'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(agencomm1.ToString())).ToString("F2")), comm_position) + "</td><td class='middle1212' align='right'>&nbsp;</b></td>");
            
            grossamt1 = 0;
            agencomm1 = 0;
            tbl.Append("<td class='middle1212' align='right' colspan='4'>" + Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(billamt1.ToString())).ToString("F2")), comm_position));
            tbl.Append("</td>");
            tbl.Append("</tr>");

            tbl.Append("<tr><td class='middle1212' align='left' ><b>Total Ads.</b></td>");
            tbl.Append("<td class='middle1212'>");
            tbl.Append(a.ToString() + "</td>");
           // tbl.Append("<td class='middle1212'>&nbsp;</td>");
          //  tbl.Append("<td class='middle1212'>&nbsp;</td>");
            tbl.Append("<td class='middle1212'><b>&nbsp;</b>");
            tbl.Append("&nbsp;</td>");
            tbl.Append("<td class='middle1212' ><b>&nbsp;</b>");
            tbl.Append("&nbsp;</td>");
            if (adchk == "1")
                tbl.Append("<td class='middle1212' colspan='9'>&nbsp;</td>");
           // else
              //  tbl.Append("<td class='middle1212' colspan='7'>&nbsp;</td>");




            tbl.Append("<td class='middle1212'>&nbsp;</td>");
            tbl.Append("<td class='middle1212' align='right'>");
           // double cal = System.Math.Round(Convert.ToDouble(BillAmt), 2);
            tbl.Append(Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(grossamt2.ToString())).ToString("F2")), comm_position) + "</td>");
            tbl.Append("<td class='middle1212'>&nbsp;</td>");
            tbl.Append("<td class='middle1212'>&nbsp;</td>");
            tbl.Append("<td class='middle1212' align='right'  >" +Amitlibrary.Changeamount.comma(Convert.ToDecimal(Convert.ToDouble(chk_null(billamt2.ToString())).ToString("F2")), comm_position));
            tbl.Append("</td>");
            tbl.Append("</tr>");
            if (browser.Browser == "Firefox")
            {
                tbl.Append("</table></P>");

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl.Append("</table></P>");

                }
                else if (ver == 6.0)
                {
                    tbl.Append("</table>");

                }
            }
            // tbl += "</table>";

            div1.Visible = true;
            div1.InnerHtml = tbl.ToString();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }


}
