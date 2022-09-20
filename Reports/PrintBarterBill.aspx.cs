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

public partial class PrintBarterBill : System.Web.UI.Page
{
    int maxlimit = 19;
    int count1 = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count31 = 0;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string frmdt = "";
    string todate = "";

    string date = "";
    string day = "";
    string month = "";
    string year = "";

    string pdfName1 = "";
    string region = "";
    string regionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    string product = "";
    string productname = "";
    //float area = 0;
    double area = 0;
    double BillAmt = 0;
    double billarea = 0;
    string sortorder = "";
    string sortvalue = "";
    string agency, fromdate, client, publication, adtype, billstatus, payment = "";
    string myrange = "";
    string maxrange = "";
    string clientname = "";
    string agencyname = "";
    string booktype = "";
    decimal paidins = 0;
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;

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
        //maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[43].ToString());

        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        ds = (DataSet)Session["barterbill"];
        string prm = Session["prm_barterbill_print"].ToString();
        string[] prm_Array = new string[20];
        prm_Array = prm.Split('~');

        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        frmdt = prm_Array[3];//Request.QueryString["fromdate"].ToString();
        todate = prm_Array[5];//Request.QueryString["dateto"].ToString();
        product = prm_Array[7];//Request.QueryString["product"].ToString();
        productname = prm_Array[9];//Request.QueryString["productname"].ToString();
        region = prm_Array[11];//Request.QueryString["region"].ToString();
        regionname = prm_Array[13];//Request.QueryString["regionname"].ToString();
        agency = prm_Array[15];//Request.QueryString["agency"].ToString();
        agencyname = prm_Array[21];//Request.QueryString["agency"].ToString();
        client = prm_Array[17];//Request.QueryString["client"].ToString();
        clientname = prm_Array[23];
        booktype = prm_Array[19];//Request.QueryString["booktype"].ToString();
        hiddendatefrom.Value = fromdt.ToString();

        if (product == "0")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = productname.ToString();
        }


        if (client == "0" || client== "")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname.ToString();
        }

        if (agency == "0" || agency=="")
        {
            lbagency.Text = "ALL".ToString();
        }
        else
        {
            lbagency.Text = agencyname.ToString();
        }

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();

            if (day.Length < 2)
                day = "0" + day;

            if (month.Length < 2)
                month = "0" + month;

                date = day + "/" + month + "/" + year;



          

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();

                if (day.Length < 2)
                    day = "0" + day;

                if (month.Length < 2)
                    month = "0" + month;
                date = month + "/" + day + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();

                    if (day.Length < 2)
                        day = "0" + day;

                    if (month.Length < 2)
                        month = "0" + month;
                    date = year + "/" + month + "/" + day;

                }
        lbldate.Text = date.ToString();


        if (fromdt != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                datefrom1 = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = year + "/" + month + "/" + day;
                }
            }
        }
        lblfrom.Text = datefrom1;
        //dateto1 = "";
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto1 = dd + "/" + mm + "/" + yy;

            }


            else
            {

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = day + "/" + month + "/" + year;

                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = year + "/" + month + "/" + day;
                }
            }
        }
        lblto.Text = dateto1;
        onscreen(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString());
    }

    private void onscreen(string frmdt, string todate, string compcode, string clientname, string agencyname, string region, string product, string booktype, string dateformate)
    {

       

        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        //Area.Text = ds.Tables[0].Rows[0]["Area"].ToString("");
        int i1 = 1;
        string tbl = "";
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
       
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }
        //else
        //{
        //    pagecount = pagecount + 1;
        //}

        if (ds.Tables[0].Rows.Count > 0)
        { 
            //if (browser.Browser == "Firefox")
            //{
            //    tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            //}
            //else if (browser.Browser == "IE")
            //{
            //    if ((ver == 7.0) || (ver == 8.0))
            //    {
            //        tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            //    }
            //    else if (ver == 6.0)
            //    {
            //        tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            //    }
            //}    
           // tbl = "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {


                    tbl = tbl + "</table></P>";
                    if (p == pagecount || p == 0)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                }

                else if (browser.Browser == "IE")
                {


                    tbl = tbl + "</table></P>";
                    if (p == pagecount - 1)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";


                } 

                //tbl += "</table>";
                // tbl += "</br>";
               // tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                
                tbl += "<tr cellspacing='0px' cellpadding = '0px'>";
                tbl += "<td class='middle111' align='right' colspan='11'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";
                tbl += "<tr valign='top' cellspacing='0px' cellpadding = '0px'>";
                tbl += "<td class='middle31new' width='5%' >" + "S.No." + "</td>";
                tbl += "<td class='middle31new' width='8%'  align='left'>" + "Booking</br>Id" + "</td>";
               // tbl += "<td class='middle123' width='6%'  align='left'>" + "Ins.Date" + "</td>";
                tbl += "<td class='middle31new' width='12%' align='left'>" + "Agency" + "</td>";
                tbl += "<td class='middle31new' width='12%' align='left'>" + "Client" + "</td>";
                tbl += "<td class='middle31new' width='9%' align='left'>" + "Publication" + "</td>";
                tbl += "<td class='middle31new' width='3%'  align='right'>" + "Edition" + "</td>";
                tbl += "<td class='middle31new' width='3%'  align='right'>" + "Area" + "&nbsp;&nbsp;</td>";
                tbl += "<td class='middle31new' width='5%'  align='right' >" + "BillAmt" + "&nbsp;&nbsp;</td>";
                tbl += "<td class='middle31new' width='9%'  align='left'>" + "Adtype" + "</td>";
                tbl += "<td class='middle31new' width='9%'  align='left'>" + "Adcat" + "</td>";
                tbl += "<td class='middle31new' width='5%'  align='left'>" + "RevenueCenter" + "</td>"; 
                tbl += "</tr>";
                for (int d = ct; d < ds.Tables[0].Rows.Count && d<fr; d++)   //&& d < fr
                {
                   int a = d;
                    a = a + 1;

                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (i1++.ToString() + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
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
                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                    if (rrr.Length >= 10)
                    {
                        cioid1 = rrr.Substring(0, 10);
                        if (rrr.Length - 10 < 10)
                            cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                        else
                            cioid1 += "</br>" + rrr.Substring(10, 10);
                    }
                    else
                        cioid1 = rrr;

                    tbl = tbl + (cioid1 + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    //-------------------------------------------//
                    //string agency1 = "";
                    //string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
                    //char[] agency = rrr1.ToCharArray();
                    //int len111 = agency.Length;
                    //int line11 = 0;
                    //int ch_end1 = 0;
                    //int ch_str1 = 0;
                    //for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                    //{
                    //    /**/
                    //    ch_end1 = ch_end1 + 16;
                    //    ch_str1 = ch_end1;
                    //    if (ch_end1 > len111)
                    //        ch_str1 = len111 - ch1;
                    //    else
                    //        ch_str1 = ch_end1 - ch1;

                    //    agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                    //    agency1 = agency1 + "</br>";
                    //    ch1 = ch1 + 16;
                    //    if (ch1 > len111)
                    //        ch1 = len111;/**/
                    //}
                    string agency1 = "";
                    string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
                    if (rrr1.Length >= 16)
                    {
                        agency1 = rrr1.Substring(0, 16);
                        if (rrr1.Length - 16 < 16)
                            agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                        else
                            agency1 += "</br>" + rrr1.Substring(16, 16);
                    }
                    else
                        agency1 = rrr1;
                    //---------------------------------------------//
                    tbl = tbl + (agency1 + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    //string client1 = "";
                    //string rrr11 = ds.Tables[0].Rows[d]["Client"].ToString();
                    //char[] client = rrr11.ToCharArray();
                    //int len1111 = client.Length;
                    //int line = 0;
                    //int ch_end11 = 0;
                    //int ch_str11 = 0;
                    //for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                    //{
                    //    /* */
                    //    ch_end11 = ch_end11 + 16;
                    //    ch_str11 = ch_end11;
                    //    if (ch_end11 > len1111)
                    //        ch_str11 = len1111 - ch11;
                    //    else
                    //        ch_str11 = ch_end11 - ch11;

                    //    client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                    //    client1 = client1 + "</br>";
                    //    ch11 = ch11 + 16;
                    //    if (ch11 > len1111)
                    //        ch11 = len1111;
                    //}
                    string client1 = "";
                    string rrr2 = ds.Tables[0].Rows[d]["Client"].ToString();
                    if (rrr2.Length >= 16)
                    {
                        client1 = rrr2.Substring(0, 16);
                        if (rrr2.Length - 16 < 16)
                            client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                        else
                            client1 += "</br>" + rrr2.Substring(16, 16);
                    }
                    else
                        client1 = rrr2;
                    //lbclient.Text = rrr2;
                    tbl = tbl + (client1 + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Edition"] + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
                    //tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");
                    tbl += Convert.ToDouble(ds.Tables[0].Rows[d]["Area"]).ToString("F2") + "</td>";
                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                        area = area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                     


                   
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["BillAmt"] + "</td>");
                    if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                        BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());

                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["AdType"] + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Adcat"] + "</td>");
                    tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data'  align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");

                 
                    tbl = tbl + "</tr>";
                    div1.InnerHtml += tbl;
                    tbl = "";
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
                //maxlimit = 61;


            }
          //  tbl = tbl + ("<tr><td class='middle123' colspan='6' align='left'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle123' colspan='5' align='left'>TotalArea:" + area.ToString("F2") + "</td><td id='tdcio~1' class = 'middle123' align='right'>" + BillAmt.ToString() + "</td></tr>"); //<td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td>

            //tbl = tbl + ("<tr><td class='middle123' colspan='4' align='left'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle123'  align='right'>Tot:" + area.ToString("F2") + " " + BillAmt.ToString() + "</td></tr>");

            tbl = tbl + ("<tr><td class='middle123'>TotalAds.</td>");
            tbl = tbl + ("<td class='middle123' colspan='4' align='left'>");
            tbl = tbl + ((i1 - 1).ToString() + "</td>");



            //tbl = tbl + ("<td class='middle13'>&nbsp;");
            tbl = tbl + ("<td class='middle123'>TotalArea</td>");
            tbl = tbl + ("<td class='middle123' align='right'>");
            tbl = tbl + (area.ToString("F2") + "</td>");
            tbl = tbl + ("<td class='middle123' align='right'>");
            tbl = tbl + (BillAmt.ToString("F2") + "</td>");
            //tbl = tbl + ("<td class='middle13'>");
            //tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
            tbl = tbl + "<td class='middle123' colspan='3'>&nbsp;</td></tr>";
            
            if (browser.Browser == "Firefox")
            {
                tbl = tbl + "</table></P>";

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl = tbl + "</table></P>";

                }
                else if (ver == 6.0)
                {
                    tbl = tbl + "</table>";

                }
            }  
            
            
            //  tbl += "</table>";
            div1.Visible = true;
            div1.InnerHtml += tbl;

        }
    }
}
