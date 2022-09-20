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

public partial class Reports_moneyrecievedprint : System.Web.UI.Page
{
    string currency = "";
    int maxlimit = 20;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string frmdt = "";
    string todate = "", datefrom1 = "", dateto1 = "";
    string paymodename = "", paymode = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string clientname = "";
    string agencyname = "";
    string clientname1 = "";
    string incluesta = ""; 
    string agencyname1 = "", adtypecode = "", adtypename="", reporttype="",reptype="",find_pay="";
    double BillAmt = 0,area=0;
    double BillAmt1 = 0, area1 = 0;
    int sno = 1;
    int i2 = 1;
   
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[49].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));

        heading.Text = ds1.Tables[0].Rows[0].ItemArray[90].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        ds = (DataSet)Session["moneyrep"];
        string prm = Session["prm_moneyrep_print"].ToString();
        string[] prm_Array = new string[22];
        prm_Array = prm.Split('~');



        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        frmdt = prm_Array[3];// Request.QueryString["fromdate"].ToString();
        todate = prm_Array[5];// Request.QueryString["dateto"].ToString();
        agencyname1 = prm_Array[7];// Request.QueryString["agencyname"].ToString();
        clientname1 = prm_Array[9];// Request.QueryString["clientname"].ToString();
        paymode = prm_Array[11];// Request.QueryString["paymode"].ToString();
        paymodename = prm_Array[13];// Request.QueryString["paymodename"].ToString();
        agencyname = prm_Array[15];// Request.QueryString["agency"].ToString();
        clientname = prm_Array[17];// Request.QueryString["client"].ToString();
        adtypename = prm_Array[19];// Request.QueryString["adtypename"].ToString();
        adtypecode = prm_Array[21];// Request.QueryString["adtypecode"].ToString();
        reporttype = prm_Array[23];
        incluesta = prm_Array[24];
        reptype= prm_Array[26];
        hiddendatefrom.Value = fromdt.ToString();

        if (paymode == "0")
        {
            lbpaymode.Text = "ALL".ToString();
        }
        else
        {
            lbpaymode.Text = paymodename.ToString();
        }

        if (clientname == "0" || clientname=="")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname1.ToString();
        }

        if (agencyname == "0" || agencyname=="")
        {
            lbagency.Text = "ALL".ToString();
        }
        else
        {
            lbagency.Text = agencyname1.ToString();
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

        onscreen(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode,adtypecode,currency);
     

    }
    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
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


    private void onscreen(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string paymode,string adtypecode,string currency)
    {

        if (reptype == "S")
        {
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //    //ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString());
            //}
            //else
            //{
            //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            //    ds = obj.money_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode,adtypecode);
            //}
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (browser.Browser == "Firefox")
                {
                    tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 7.0) || (ver == 8.0))
                    {
                        tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                    }
                    else if (ver == 6.0)
                    {
                        tbl += ("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                    }
                }
                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    if (browser.Browser == "Firefox")
                    {
                        tbl += ("</table></P>");
                        if (p == pagecount || p == 0)
                            tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl += ("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                        if ((ver == 8.0) || (ver == 7.0))
                        {
                            tbl += ("</table></P>");
                            if (p == pagecount - 1)
                                tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl += ("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                        else if (ver == 6.0)
                        {
                            tbl += ("</table>");
                            if (p == pagecount - 1)
                                tbl += ("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl += ("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                        }
                    }


                    tbl += "<tr>";
                    tbl += "<td class='middle111' align='right' colspan='12'>" + "Page  " + s + "  of  " + pagecount;
                    tbl += "</td></tr>";

                    //tbl += "<tr><td class='rep_datatotal_vouchdata' width='3%'>S.No.</td><td class='rep_datatotal_vouchdata' align='left' width='7%'>Booking</br>Id</td><td class='rep_datatotal_vouchdata' align='left' width='7%'>MR.No.</td><td class='rep_datatotal_vouchdata' align='left' width='7%'>User</td><td class='rep_datatotal_vouchdata' align='left' width='10%'>Agency</td><td class='rep_datatotal_vouchdata' align='left' width='10%'>Client</td><td class='rep_datatotal_vouchdata' align='left' width='7%'>Branch</td><td  class='rep_datatotal_vouchdata' align='right' width='10%'>&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td  class='rep_datatotal_vouchdata' align='right' width='10%'>&nbsp;&nbsp;Agreed</br>&nbsp;&nbsp;Rate</td><td  class='rep_datatotal_vouchdata' align='right' width='10%'>&nbsp;&nbsp;UOM</br></td><td class='rep_datatotal_vouchdata' align='right' width='10%'>&nbsp;&nbsp;Billable</br>&nbsp;&nbsp;Area</td><td  class='rep_datatotal_vouchdata' align='right' width='10%'>&nbsp;&nbsp;Trade</br>&nbsp;&nbsp;Disc(%)</td><td class='rep_datatotal_vouchdata' align='right' width='9%'>&nbsp;&nbsp;Bill</br>&nbsp;&nbsp;Amt</td><td class='rep_datatotal_vouchdata' align='right' width='9%'>&nbsp;&nbsp;currency</td></tr>";

                    tbl = tbl + ("<tr><td class='middle31new' width='5%'>S.No.</td><td class='middle31new' align='left' width='8%'>BookingId</td><td class='middle31new' align='left'>MR.No.</td><td class='middle31new' align='left'>User</td>");
                    if (reporttype == "N")
                    {
                        tbl = tbl + ("<td class='middle31new' align='left'>Ro No.</td>");
                    }

                    tbl = tbl + ("<td class='middle31new' align='left'>Agency</td><td class='middle31new' align='left'>Client</td><td class='middle31new' align='left'>Branch</td>");
                    if (reporttype == "O")
                    {
                        tbl = tbl + ("<td  class='middle31new' align='right'>CardRate</td><td  class='middle31new' align='right'>AgreedRate</td>");
                    }
                    tbl = tbl + ("<td  class='middle31new' align='right'>UOM</td>");
                    if (reporttype == "O")
                    {
                        tbl = tbl + ("<td class='middle31new' align='right'>BillableArea</td>");
                    }
                    tbl = tbl + ("<td  class='middle31new' align='right'>TradeDisc.(%)</td><td class='middle31new' align='right'>BillAmt</td>");
                    if (reporttype == "N")
                    {
                        tbl = tbl + ("<td class='middle31new' align='center' width='15%' >Remark</td>");
                    }
                    tbl = tbl + ("</tr>");
                    //tbl += "</tr>";
                    for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                    {
                        int a = d;
                        a = a + 1;

                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (i1++.ToString() + "</td>");

                        ////////////////////////////////////////////////////////////////////
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        string cioid1 = "";
                        string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                        char[] cioid = rrr.ToCharArray();
                        int len11 = cioid.Length;

                        int ch_end = 0;
                        int ch_str = 0;
                        for (int ch = 0; ch < len11; ch++)
                        {
                            /**/
                            ch_end = ch_end + 10;
                            ch_str = ch_end;
                            if (ch_end > len11)
                                ch_str = len11 - ch;
                            else
                                ch_str = ch_end - ch;

                            cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                            cioid1 = cioid1 + "</br>";
                            ch = ch + 10;
                            if (ch > len11)
                                ch = len11;
                        }
                        tbl = tbl + (cioid1 + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["ReceiptNo"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["User"] + "</td>");

                        if (reporttype == "N")
                        {
                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["RO_No"] + "</td>");
                        }

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        //-------------------------------------------//
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
                            agency1 = agency1;
                            ch1 = ch1 + 16;
                            if (ch1 > len111)
                                ch1 = len111;/**/
                        }
                        //---------------------------------------------//
                        tbl = tbl + (agency1 + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
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
                            client1 = client1;
                            ch11 = ch11 + 16;
                            if (ch11 > len1111)
                                ch11 = len1111;
                        }
                        tbl = tbl + (client1 + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Branch"] + "</td>");
                        if (reporttype == "O")
                        {
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["CardRate"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                        }

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["uom"] + "</td>");

                        if (reporttype == "O")
                        {
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["BillableArea"].ToString()) + "</td>");
                            if (ds.Tables[0].Rows[d]["BillableArea"].ToString() != "")
                                area = area + Convert.ToDouble(ds.Tables[0].Rows[d]["BillableArea"].ToString());
                        }
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["TradeDisc%"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["BillAmt"].ToString()) + "</td>");
                        if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                            BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                        if (reporttype == "N")
                        {
                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["Bill_remarks"] + "</td>");
                        }

                        string crncy = "";
                        //if (ds.Tables[0].Rows[d]["Currency"].ToString() == "DO0")
                        //{
                        //    crncy = "USD";

                        //}
                        //else
                        //{
                        //    crncy = "KYAT";

                        //}
                        //tbl = tbl + ("<td class='rep_data' align='right'>");
                        //tbl = tbl + (crncy + "</td>");

                        ///////////////////////////////////////////////////////////////////

                        tbl = tbl + "</tr>";
                        div1.InnerHtml += tbl;
                        tbl = "";
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;


                }
                tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
                tbl = tbl + ("<td class='middle31new'  align='left'>");
                tbl = tbl + ((i1 - 1).ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new'  colspan='7'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new'>Total</td>");
                tbl = tbl + ("<td class='middle31new' align='right'>");
                tbl = tbl + (string.Format("{0:0.00}", area) + "</td>");
                tbl = tbl + ("<td class='middle31new'>&nbsp;</td>");

                string r = "";
                r = Session["currency"].ToString();
                if (r != "All")
                {
                    //tbl = tbl + ("<td class='middle31new' align='right'>");
                    tbl = tbl + ("<td class='middle31new' align='right'>");
                    tbl = tbl + (string.Format("{0:0.00}", BillAmt) + "</td>");
                    tbl = tbl + ("<td class='middle31new' align='right'>");
                }
                else
                {
                    tbl = tbl + ("<td class='middle31new' align='right'>");
                    tbl = tbl + ("<td class='middle31new' align='right'>");
                }
                tbl = tbl + ("<td class='middle31new' align='right'>");
                tbl = tbl + "</tr>";
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
                //  tbl = tbl + ("</table>");
                div1.InnerHtml += tbl;

                //tbl = tbl + ("<tr><td class='middle123' colspan='6' align='left'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle123' colspan='5' align='left'>TotalArea:" + area.ToString() + "</td></tr>"); //<td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td>
                //tbl += "</table>";
                //div1.Visible = true;
                //div1.InnerHtml = tbl;

            }
        }

          else
        {
           
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (browser.Browser == "Firefox")
                {
                    tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 7.0) || (ver == 8.0))
                    {
                        tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                    }
                    else if (ver == 6.0)
                    {
                        tbl += ("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                    }
                }
                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    if (browser.Browser == "Firefox")
                    {
                        tbl += ("</table></P>");
                        if (p == pagecount || p == 0)
                            tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl += ("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                        if ((ver == 8.0) || (ver == 7.0))
                        {
                            tbl += ("</table></P>");
                            if (p == pagecount - 1)
                                tbl += ("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl += ("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                        else if (ver == 6.0)
                        {
                            tbl += ("</table>");
                            if (p == pagecount - 1)
                                tbl += ("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl += ("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                        }
                    }


                    tbl += "<tr>";
                    tbl += "<td class='middle111' align='right' colspan='12'>" + "Page  " + s + "  of  " + pagecount;
                    tbl += "</td></tr>";

                    tbl += "<tr><td class='rep_datatotal_vouchdata' width='3%'>S.No.</td><td class='rep_datatotal_vouchdata' align='left' width='7%'>Booking</br>Id</td><td class='rep_datatotal_vouchdata' align='left' width='15%'>MR.No.</td><td class='rep_datatotal_vouchdata' align='left' width='7%'>User</td><td class='rep_datatotal_vouchdata' align='left' width='10%'>Agency</td><td class='rep_datatotal_vouchdata' align='left' width='10%'>Client</td><td class='rep_datatotal_vouchdata' align='left' width='15%'>Branch</td><td  class='rep_datatotal_vouchdata' align='right' width='5%'>&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td  class='rep_datatotal_vouchdata' align='right' width='5%'>&nbsp;&nbsp;Agreed</br>&nbsp;&nbsp;Rate</td><td  class='rep_datatotal_vouchdata' align='right' width='7%'>&nbsp;&nbsp;UOM</br></td><td class='rep_datatotal_vouchdata' align='right' width='7%'>&nbsp;&nbsp;Billable</br>&nbsp;&nbsp;Area</td><td  class='rep_datatotal_vouchdata' align='center' width='7%'>&nbsp;&nbsp;Trade</br>&nbsp;&nbsp;Disc(%)</td><td class='rep_datatotal_vouchdata' align='right' width='7%'>&nbsp;&nbsp;Bill</br>&nbsp;&nbsp;Amt</td></tr>";//<td class='rep_datatotal_vouchdata' align='right' width='6%'>&nbsp;&nbsp;currency</td>

                    find_pay = ds.Tables[0].Rows[0]["paymode"].ToString();
                    //tbl += "</tr>";
                    for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                    {
                        int a = d;
                        a = a + 1;
                        if (d == 0)
                        {
                            tbl = tbl + ("<tr >");
                            tbl = tbl + ("<td class='rep_data'><b>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["payname"].ToString() + "</b></td>");
                            tbl = tbl + "</tr>";

                        }
                        else
                        {
                            if (find_pay.IndexOf(ds.Tables[0].Rows[d]["paymode"].ToString()) < 0)
                            {

                                tbl = tbl + ("<tr><td class='middle31new'><b>TotalAds.</b></td>");
                                tbl = tbl + ("<td class='middle31new'  align='left'><b>");
                                tbl = tbl + ((i1 - 1).ToString() + "</b></td>");
                                tbl = tbl + ("<td class='middle31new'  colspan='7'>&nbsp;</td>");
                                tbl = tbl + ("<td class='middle31new'><b>Total</b></td>");
                                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                                tbl = tbl + (string.Format("{0:0.00}", area) + "</b></td>");
                                area1 = area1 + area;
                                tbl = tbl + ("<td class='middle31new'>&nbsp;</td>");
                                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                                tbl = tbl + (string.Format("{0:0.00}", BillAmt) + "</b></td>");
                                BillAmt1 = BillAmt1 + BillAmt;
                                tbl = tbl + "</tr>";

                                find_pay += ds.Tables[0].Rows[d]["paymode"].ToString();
                                area = 0; BillAmt = 0; i1 = 1;
                                tbl = tbl + ("<tr >");
                                tbl = tbl + ("<td class='rep_data'><b>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["payname"].ToString() + "</b></td>");
                                tbl = tbl + "</tr>";


                            }
                        }





                        tbl = tbl + ("<tr>");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (i1++.ToString() + "</td>");

                        ////////////////////////////////////////////////////////////////////
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                       
                        tbl = tbl + (ds.Tables[0].Rows[d]["CIOID"].ToString() + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["ReceiptNo"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["User"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        //-------------------------------------------//
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
                            agency1 = agency1;
                            ch1 = ch1 + 16;
                            if (ch1 > len111)
                                ch1 = len111;/**/
                        }
                        //---------------------------------------------//
                        tbl = tbl + (agency1 + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
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
                            client1 = client1;
                            ch11 = ch11 + 16;
                            if (ch11 > len1111)
                                ch11 = len1111;
                        }
                        tbl = tbl + (client1 + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Branch"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["CardRate"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["uom"] + "</td>");

                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["BillableArea"].ToString()) + "</td>");
                        if (ds.Tables[0].Rows[d]["BillableArea"].ToString() != "")
                            area = area + Convert.ToDouble(ds.Tables[0].Rows[d]["BillableArea"].ToString());

                        tbl = tbl + ("<td class='rep_data' align='center'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["TradeDisc%"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='right'>");
                        tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["BillAmt"].ToString()) + "</td>");
                        if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                            BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"].ToString());

                        i2++;
                        find_pay += ds.Tables[0].Rows[d]["paymode"].ToString();
                        tbl = tbl + "</tr>";
                        div1.InnerHtml += tbl;
                        tbl = "";
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;


                }

                tbl = tbl + ("<tr><td class='middle31new'><b>TotalAds.</b></td>");
                tbl = tbl + ("<td class='middle31new'  align='left'><b>");
                tbl = tbl + ((i1 - 1).ToString() + "</b></td>");
                tbl = tbl + ("<td class='middle31new'  colspan='7'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new'><b>Total</b></td>");
                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                tbl = tbl + (string.Format("{0:0.00}", area) + "</b></td>");
                area1 = area1 + area;
                tbl = tbl + ("<td class='middle31new'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                tbl = tbl + (string.Format("{0:0.00}", BillAmt) + "</b></td>");
                BillAmt1 = BillAmt1 + BillAmt;
                tbl = tbl + "</tr>";

                tbl = tbl + ("<tr><td class='middle31new'><b>Grand TotalAds.</b></td>");
                tbl = tbl + ("<td class='middle31new'  align='left'><b>");
                tbl = tbl + ((i2 - 1).ToString() + "</b></td>");
                tbl = tbl + ("<td class='middle31new'  colspan='7'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new'><b>Grand Total</b></td>");
                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                tbl = tbl + (string.Format("{0:0.00}", area1) + "</b></td>");
                tbl = tbl + ("<td class='middle31new'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                tbl = tbl + (string.Format("{0:0.00}", BillAmt1) + "</b></td>");
               
                tbl = tbl + ("<td class='middle31new' align='right'>");
                tbl = tbl + "</tr>";
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
                //  tbl = tbl + ("</table>");
                div1.InnerHtml += tbl;

                //tbl = tbl + ("<tr><td class='middle123' colspan='6' align='left'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle123' colspan='5' align='left'>TotalArea:" + area.ToString() + "</td></tr>"); //<td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td>
                //tbl += "</table>";
                //div1.Visible = true;
                //div1.InnerHtml = tbl;

            }
        //int cont = ds.Tables[0].Rows.Count;

        //string tbl = "";
        //tbl = "<table width='90%'align='left' cellpadding='0' cellspacing='0'>";
        //tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td class='middle31new' align='left'>BookingId</td><td class='middle31new' align='left'>MR.No.</td><td class='middle31new' align='left'>Agency</td><td class='middle31new' align='left'>Client</td><td  class='middle31new' align='right'>CardRate</td><td  class='middle31new' align='right'>AgreedRate</td><td class='middle31new' align='right'>BillableArea</td><td  class='middle31new' align='right'>TradeDisc.(%)</td><td class='middle31new' align='right'>BillAmt</td></tr>");

        //int i1 = 1;


        //for (int i = 0; i <= cont - 1; i++)
        //{
        //    tbl = tbl + ("<tr >");
        //    tbl = tbl + ("<td class='rep_data'>");
        //    tbl = tbl + (i1++.ToString() + "</td>");
        //    tbl = tbl + ("<td class='rep_data' align='left'>");
        //    string cioid1 = "";
        //    string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();//ds.Tables[0].Rows[i].ItemArray[0].ToString();
        //    char[] cioid = rrr.ToCharArray();
        //    int len11 = cioid.Length;

        //    for (int ch = 0; ch < len11; ch++)
        //    {

        //        if (ch == 0)
        //        {
        //            cioid1 = cioid1 + cioid[ch];
        //        }
        //        else if (ch % 10 != 0)
        //        {
        //            cioid1 = cioid1 + cioid[ch];
        //        }
        //        else
        //        {
        //            cioid1 = cioid1 + "</br>" + cioid[ch];
        //        }
        //    }
        //    tbl = tbl + (cioid1 + "</td>");

        //    tbl = tbl + ("<td class='rep_data' align='left'>");
        //    tbl = tbl + (ds.Tables[0].Rows[i]["ReceiptNo"] + "</td>");

        //    tbl = tbl + ("<td class='rep_data' align='left'>");
        //    //-------------------------------------------//
        //    string Agency1 = "";
        //    string Agency11 = "";
        //    string AA = ds.Tables[0].Rows[i]["Agency"].ToString();
        //    char[] Agency = AA.ToCharArray();
        //    int len12 = Agency.Length;
        //    int line1 = 0;

        //    for (int ch = 0; ch < len12; ch++)
        //    {
        //        if (Agency[ch] != ' ')
        //        {
        //            Agency1 = Agency1 + Agency[ch];
        //        }
        //    }
        //    char[] AA1 = Agency1.ToCharArray();

        //    for (int ch = 0; ((ch < AA1.Length) && (line1 < 2)); ch++)
        //    {

        //        if (ch == 0)
        //        {
        //            Agency11 = Agency11 + AA1[ch];
        //        }
        //        else if (ch % 16 != 0)
        //        {
        //            Agency11 = Agency11 + AA1[ch];
        //        }
        //        else
        //        {

        //            line1 = line1 + 1;
        //            if (line1 != 2)
        //            {
        //                Agency11 = Agency11 + "</br>" + AA1[ch];
        //            }

        //        }
        //    }
        //    //---------------------------------------------//
        //    tbl = tbl + (Agency11 + "</td>");
        //    tbl = tbl + ("<td class='rep_data' align='left'>");
        //    string Client1 = "";
        //    string Client11 = "";
        //    string BB = ds.Tables[0].Rows[i]["Client"].ToString();
        //    char[] Client = BB.ToCharArray();
        //    int len13 = Client.Length;
        //    int line2 = 0;

        //    for (int ch = 0; ch < len13; ch++)
        //    {
        //        if (Client[ch] != ' ')
        //        {
        //            Client1 = Client1 + Client[ch];
        //        }
        //    }
        //    char[] BB1 = Client1.ToCharArray();

        //    for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
        //    {

        //        if (ch == 0)
        //        {
        //            Client11 = Client11 + BB1[ch];
        //        }
        //        else if (ch % 16 != 0)
        //        {
        //            Client11 = Client11 + BB1[ch];
        //        }
        //        else
        //        {

        //            line2 = line2 + 1;
        //            if (line2 != 2)
        //            {
        //                Client11 = Client11 + "</br>" + BB1[ch];
        //            }

        //        }
        //    }
        //    tbl = tbl + (Client11 + "</td>");
        //    tbl = tbl + ("<td class='rep_data' align='right'>");
        //    tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
        //    tbl = tbl + ("<td class='rep_data' align='right'>");
        //    tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
        //    tbl = tbl + ("<td class='rep_data' align='right'>");
        //    tbl = tbl + (ds.Tables[0].Rows[i]["BillableArea"] + "</td>");
        //    if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
        //        area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["BillableArea"].ToString());

        //    tbl = tbl + ("<td class='rep_data' align='right'>");
        //    tbl = tbl + (ds.Tables[0].Rows[i]["TradeDisc%"] + "</td>");
        //    tbl = tbl + ("<td class='rep_data' align='right'>");
        //    tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
        //    if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
        //        BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());


        //    tbl = tbl + "</tr>";

        //}

        //tbl = tbl + ("<tr><td class='middle123'>TotalAds.</td>");
        //tbl = tbl + ("<td class='middle123'  align='left'>");
        //tbl = tbl + ((i1 - 1).ToString() + "</td>");
        //tbl = tbl + ("<td class='middle123'  colspan='4'>&nbsp;</td>");
        //tbl = tbl + ("<td class='middle123'>Total</td>");
        //tbl = tbl + ("<td class='middle123' align='right'>");
        //tbl = tbl + (area.ToString() + "</td>");
        //tbl = tbl + ("<td class='middle123'>&nbsp;</td>");
        //tbl = tbl + ("<td class='middle123' align='right'>");
        //tbl = tbl + (BillAmt.ToString() + "</td>");
        //tbl = tbl + "</tr>";
        //tbl = tbl + ("</table>");
        //tblgrid.InnerHtml = tbl;

    }
}
