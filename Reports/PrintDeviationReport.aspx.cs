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
using System.Text;
public partial class Reports_PrintDeviationReport : System.Web.UI.Page
{
    string clientname = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string clientname1 = "";
    string agname = "";
    string status = "";
    string status1 = "";
    string hold = "";
    string adtypename = "";
    string editionname = "";
    string agencyname = "";
    string datefrom1 = "";
    string dateto1 = "";
    string city = "";
    //decimal area = 0;
    int ins_no = 0;
    string package = "";
    string sortorder = "";
    string sortvalue = "", agtype = "", agtypetext = "";
    int maxlimit = 17;
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
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
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[9].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


      
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();

        ds = (DataSet)Session["Deviation"];

        string prm = Session["prm_Deviation_print"].ToString();
        string[] prm_Array = new string[41];
        prm_Array = prm.Split('~');


        agname = prm_Array[1];// Request.QueryString["agname"].ToString();
        adtyp = prm_Array[3]; //Request.QueryString["adtype"].ToString();
        adcat = prm_Array[5]; //Request.QueryString["adcategory"].ToString();
        fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();
        edition = prm_Array[19]; //Request.QueryString["edition"].ToString();
        destination = prm_Array[21]; //Request.QueryString["destination"].ToString();
        status1 = prm_Array[23]; //Request.QueryString["status1"].ToString();
        adcatname = prm_Array[25]; //Request.QueryString["adcatname"].ToString();
        status = prm_Array[27]; //Request.QueryString["status"].ToString();
        clientname = prm_Array[29]; //Request.QueryString["clientname"].ToString();
        clientname1 = prm_Array[31]; //Request.QueryString["client"].ToString();
        adtypename = prm_Array[33]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[35]; //Request.QueryString["editionname"].ToString();
        agencyname = prm_Array[37]; //Request.QueryString["agencyname"].ToString();
        agtype = prm_Array[39]; //Request.QueryString["agtype1"].ToString();
        agtypetext = prm_Array[41]; //Request.QueryString["agtypetext"].ToString();


        hold = "abc";
        hiddendatefrom.Value = fromdt.ToString();

      
        if (agtype == "0")
        {
            lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = agtypetext.ToString();
        }
        if (publ == "0")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = pubcname.ToString();
        }
        if (pubcen == "0")
        {
            pcenter.Text = "ALL".ToString();
        }
        else
        {
            pcenter.Text = pub2.ToString();
        }


        if (clientname == "0" || clientname=="")
        {

            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname1.ToString();
        }

        if (edition == "0" || edition=="")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();



        }

      

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
        
            onscreen(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
       
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

    private void onscreen(string clientname, string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {

        string page = "";
        string position = "";

        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.spDeviation(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), page, position, agtypetext);
        //}


        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int i1 = 1;
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


              //  tbl.Append("</table>");
                // tbl += "</br>";
               // tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>");
               // tbl.Append("<tr>");
                tbl.Append("<tr valign='top'>");
                tbl.Append("<td class='middle111' align='right' colspan='20'>" + "Page  " + s + "  of  " + pagecount);
                tbl.Append("</td></tr>");

                tbl.Append("<td class='middle31new' width='3%'  >" + "S.No." + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Booking" + "</br>" + "&nbsp;&nbsp;Id" + "</td>");
                tbl.Append("<td class='middle31new' width='3%'  align='left'>" + "&nbsp;&nbsp;Edition" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Publish" + "</br>" + "&nbsp;&nbsp;Date" + "</td>");
                tbl.Append("<td class='middle31new' width='7%' align='left'>" + "&nbsp;&nbsp;Agency" + "</td>");
                tbl.Append("<td class='middle31new' width='10%' align='left'>" + "&nbsp;&nbsp;Client" + "</td>");
                tbl.Append("<td class='middle31new' width='7%' align='left'>" + "Package" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='right'>" + "&nbsp;&nbsp;Area" + "</td>");
                tbl.Append("<td class='middle31new' width='3%'  align='left' >" + "&nbsp;&nbsp;Color" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Book" + "</br>" + "&nbsp;&nbsp;date" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Ro" + "</br>" + "&nbsp;&nbsp;No." + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "Ro" + "</br>" + "Status" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "AdCategory" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Rate" + "</br>" + "&nbsp;&nbsp;Code" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='right'>" + "&nbsp;&nbsp;Card" + "</br>" + "&nbsp;&nbsp;Rate" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='right'>" + "&nbsp;&nbsp;Agreed" + "</br>" + "&nbsp;&nbsp;Rate" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='right'>" + "&nbsp;&nbsp;Dev%" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Status" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Booked" + "</br>" + "&nbsp;&nbsp;By" + "</td>");
                tbl.Append("<td class='middle31new' width='5%'  align='left'>" + "&nbsp;&nbsp;Audit" + "</br>" + "&nbsp;&nbsp;By" + "</td>");
                tbl.Append("</tr>");
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {
                    int a = d;
                    a = a + 1;

                    tbl.Append ("<tr >");
                    tbl.Append("<td class='rep_data'  witdh='3%'>");
                    tbl.Append(i1++.ToString() + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'  width='5%'>");
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

                    tbl.Append(cioid1 + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='3%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["edition"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["Ins.date"] + "</td>");
                    //-------------------------------------------//
                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='7%'>");
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


                   
                    tbl.Append(agency1 + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='10%'>");

                    
                  
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


                    tbl.Append(client1 + "</td>");
                    string Package1 = "";
                    string rrr3 = ds.Tables[0].Rows[d]["Package"].ToString();
                    if (rrr3.Length >= 9)
                    {
                        Package1 = rrr3.Substring(0, 9);
                        if (rrr3.Length - 9 < 9)
                            Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                        else
                            Package1 += "</br>" + rrr3.Substring(9, 9);
                    }
                    else
                        Package1 = rrr3;

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='7%'>");
                    tbl.Append(Package1 + "</td>");


                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
                    tbl.Append(chk_null(ds.Tables[0].Rows[d]["Area"].ToString()) + "</td>");
                
                    //area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                    {
                       
                        if (ds.Tables[0].Rows[d]["uom"].ToString() == "CD" || ds.Tables[0].Rows[d]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());


                    }
                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='3%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");


                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["BookDate"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["RoNo"] + "</td>");

                    string RoStatus1 = "";
                    string rrr4 = ds.Tables[0].Rows[d]["RoStatus"].ToString();
                    if (rrr4.Length >= 9)
                    {
                        RoStatus1 = rrr4.Substring(0, 9);
                        if (rrr4.Length - 9 < 9)
                            RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                        else
                            RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                    }
                    else
                        RoStatus1 = rrr4;

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(RoStatus1 + "</td>");
                    string AdCat1 = "";
                    string rrr5 = ds.Tables[0].Rows[d]["AdCat"].ToString();
                    if (rrr5.Length >= 9)
                    {
                        AdCat1 = rrr5.Substring(0, 9);
                        if (rrr5.Length - 9 < 9)
                            AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                        else
                            AdCat1 += "</br>" + rrr5.Substring(9, 9);
                    }
                    else
                        AdCat1 = rrr5;
                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(AdCat1 + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data'align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["RateCode"] + "</td>");



                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["CardRate"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["Deviation(%)"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["Status"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["booked_by"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='5%'>");
                    tbl.Append(ds.Tables[0].Rows[d]["audit"] + "</td>"); 

                   
                                      
                    tbl.Append ( "</tr>");
 
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }
            tbl.Append("<tr >");

            tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
            tbl.Append ("<td class='middle13new' colspan='2' >&nbsp;</td>");

            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl.Append(chk_null(cal.ToString()) + "</td>");

            if (totrol > 0)
            {
                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl.Append(calf.ToString() + "</td>");
            }
            else
            {
                tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl.Append(calfd.ToString() + "</td>");
            }
            else
            {
                tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl.Append(calft.ToString() + "</td>");
            }
            else
            {
                tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
            }


            ///////////////////////////////////

            tbl.Append("<td  class='middle13new'  colspan='4'>&nbsp;</td>");
            tbl.Append("</tr>");

            // tbl = tbl + ("<td class='middle13new' colspan='8' style='font-size: 13px;'>");
            // tbl = tbl + (amt.ToString() + "</td>");

            if (browser.Browser == "Firefox")
            {
                tbl.Append("</table></P>");

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl.Append( "</table></P>");

                }
                else if (ver == 6.0)
                {
                    tbl.Append("</table>");

                }
            }  
        
            div1.Visible = true;
           
            div1.InnerHtml = tbl.ToString();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }

}
