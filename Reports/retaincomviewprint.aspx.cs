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
using System.Data.SqlClient;
using System.Data.OracleClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;

public partial class retaincomviewprint : System.Web.UI.Page
{
    int maxlimit = 10;
    int a = 0;
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

    string regionname = "";
    string editioncode = "";
    string editionname = "";
    string branchcode = "";
    string branchname = "";
    string Adtypecode = "";
    string Adtypename = "";
    string Retainercode = "";
    string Retainername = "";
    string product = "";
    string productname = "";

    string todate, fromdate, client, publication, adtype, billstatus, payment, agency = "";
    string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "", temp6 = "", temp7 = "", temp8 = "";
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
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[47].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[41].ToString();


        ds = (DataSet)Session["retaincom"];
        string prm = Session["prm_retaincom_print"].ToString();
        string[] prm_Array = new string[30];
        prm_Array = prm.Split('~');



        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3];//Request.QueryString["dateto"].ToString();
        region = prm_Array[5];//Request.QueryString["regioncode"].ToString();
        regionname = prm_Array[7];//Request.QueryString["regionname"].ToString();
        product = prm_Array[9];//Request.QueryString["productcode"].ToString();
        productname = prm_Array[11];//Request.QueryString["productname"].ToString();
        editioncode = prm_Array[13];//Request.QueryString["editioncode"].ToString();
        editionname = prm_Array[15];//Request.QueryString["editionname"].ToString();
        branchcode = prm_Array[17];//Request.QueryString["branchcode"].ToString();
        branchname = prm_Array[19];//Request.QueryString["branchname"].ToString();
        Adtypecode = prm_Array[21];//Request.QueryString["Adtypecode"].ToString();
        Adtypename = prm_Array[23];//Request.QueryString["Adtypename"].ToString();
        Retainercode = prm_Array[25];//Request.QueryString["Retainercode"].ToString();
        Retainername = prm_Array[27];//Request.QueryString["Retainername"].ToString();

        

        lblfrom.Text = fromdt;
        lblto.Text = dateto;


        if (product == "0")
            {
                lblproduct.Text = "ALL".ToString();
            }
            else
            {
                lblproduct.Text = productname.ToString();
            }


            if (region == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = regionname.ToString();
            }

            if (editioncode == "0" || editioncode == "")
            {
                lbledition.Text = "ALL".ToString();
            }
            else
            {
                lbledition.Text = editionname.ToString();
            }

            if (branchcode == "0")
            {
                lblbranch.Text = "ALL".ToString();
            }
            else
            {
                lblbranch.Text = branchname.ToString();
            }

            if (Adtypecode == "0")
            {
                lbladtype11.Text = "ALL".ToString();
            }
            else
            {
                lbladtype11.Text = Adtypename.ToString();
            }

            if (Retainercode == "0" || Retainercode=="")
            {
                lblretainer.Text = "ALL".ToString();
            }
            else
            {
                lblretainer.Text = Retainername.ToString();
            }

            if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = day + "/" + month + "/" + year;

            }
            else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = month + "/" + day + "/" + year;

             }
             else if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
             {

                        DateTime dt = System.DateTime.Now;


                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
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
                            datefrom1 = mm + "/" + dd + "/" + yy;

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


            if (dateto != "")
            {


                if (hiddendateformat.Value == "dd/mm/yyyy")
                {

                    string[] arr = dateto.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    dateto1 = mm + "/" + dd + "/" + yy;

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

            
        onscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString());
       
    }

    private void onscreen(string fromdt, string dateto, string region, string product, string compcode, string dateformat)
    {


        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
      
        //NewAdbooking.Report.classesoracle.billreport obj = new NewAdbooking.Report.classesoracle.billreport();

        //ds = obj.retainonscreen(fromdt, dateto, region, product, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp1, temp2, temp3, temp4, temp5, temp6, branchcode, editionname, Retainercode, Adtypecode);


        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int cont = ds.Tables[0].Rows.Count;
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        string tbl = "";
     
        int i1 = 1;
        float area = 0;
        double BillAmt = 0.00;
        double subBillAmt = 0.00;
        double totalretainercomm = 0.00;
        double subretainercomm = 0.00;

        double totalretainercommamt = 0.00;
        double subretainercommamt = 0.00;
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
                tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
            //tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;


             //   tbl += "</table>";
               // tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";

                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table></P>";
                    if (p == pagecount - 1)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl = tbl + "</table></P>";
                        if (p == pagecount - 1)
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else

                            if(p!=0)

                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1)
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  
                
                tbl += "<tr valign='top'>";
                tbl += "<td class='middle111' align='right' colspan='18'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";
                tbl += "<tr></tr>";

               // tbl = tbl + ("<tr><td  class='middle31new' width='1%' >S.</br>No</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='9%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='9%' align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp;HT</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='7%' align='left'>Ro No.</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Ro </br>&nbsp;&nbsp;Status</td> <td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;&nbsp;Amt</td><td class='middle31new' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No.</td></tr>");
                tbl = tbl + ("<tr><td class='middle31new' align='left' >S.</br>No</td><td id='tdret~7' class='middle31new' align='left'>&nbsp;&nbsp;Retainer</br>&nbsp;&nbsp;Name</td><td id='tdro~28' class='middle31new' align='left' >&nbsp;&nbsp;CIOID</td><td id='tdag~2' class='middle31new' align='left'  >&nbsp;&nbsp;Agency</td><td id='tdcli~3' class='middle31new' align='left' >&nbsp;&nbsp;Client</td><td id='tdpub~4' class='middle31new' align='left' >&nbsp;&nbsp;Publication</td><td id='tdpub~4' class='middle31new' align='left' >&nbsp;&nbsp;Edition</td>  <td id='tdro~25' class='middle31new' align='right' >&nbsp;&nbsp;Area</td><td id='tdbill~11' class='middle31new' align='left'>&nbsp;&nbsp;Bill</br>&nbsp;&nbsp;Status</td><td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Gross</br>&nbsp;&nbsp;Amt</td><td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Agency</br>&nbsp;&nbsp;TD(%)</td><td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Agency</br>&nbsp;&nbsp;TD(Amt)</td><td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Agency</br>&nbsp;&nbsp;AddlTD(%)</td> <td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Agency</br>&nbsp;&nbsp;AddlTD(Amt)</td>  <td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Bill</br>&nbsp;&nbsp;Amt</td> <td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Retcomm(%)</td><td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;RetComm(Amt)</td><td id='td~291' class='middle31new' align='right' >&nbsp;&nbsp;Act</br>Buss</td><td id='trevec~13' class='middle31new' align='left' >&nbsp;&nbsp;Revenue</br>&nbsp;&nbsp;Center</td></tr>");


             
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                   


                    if (ds.Tables[0].Rows[d]["RetainName"].ToString() != "")
                    {



                        if (d > 0)
                        {
                            if ((ds.Tables[0].Rows[d]["RetainName"].ToString()) == (ds.Tables[0].Rows[(d - 1)]["RetainName"].ToString()))
                            {





                                tbl = tbl + ("<tr >");


                                //tbl = tbl + ("<td class='rep_data'>");
                                //tbl = tbl + (i1++.ToString() + "</td>");
                                tbl = tbl + ("<td  class='rep_data'>");
                                tbl = tbl + (a.ToString() + "</td>");

                                tbl = tbl + ("<td class='rep_data'>");
                                tbl = tbl + "</td>";
                                string cioid1 = "";
                                string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                                char[] cioid = rrr.ToCharArray();
                                int len11 = cioid.Length;

                                int ch_end = 0;
                                int ch_str = 0;
                                for (int ch = 0; ch < len11; ch++)
                                {
                                    /**/
                                    ch_end = ch_end + 9;
                                    ch_str = ch_end;
                                    if (ch_end > len11)
                                        ch_str = len11 - ch;
                                    else
                                        ch_str = ch_end - ch;

                                    cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                                    cioid1 = cioid1 + "</br>";
                                    ch = ch + 9;
                                    if (ch > len11)
                                        ch = len11;
                                }
                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                                tbl = tbl + (cioid1 + "</td>");


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
                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                                tbl = tbl + (agency1 + "</td>");

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
                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                                tbl = tbl + (client1 + "</td>");



                                string Package1 = "";
                                string rrr111111 = ds.Tables[0].Rows[d]["Publication"].ToString();
                                char[] Package = rrr111111.ToCharArray();
                                int len11111111 = Package.Length;
                                int line1111111 = 0;
                                int ch_end111 = 0;
                                int ch_str111 = 0;
                                for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
                                {
                                    /**/
                                    ch_end111 = ch_end111 + 9;
                                    ch_str111 = ch_end111;
                                    if (ch_end111 > len11111111)
                                        ch_str111 = len11111111 - ch111111;
                                    else
                                        ch_str111 = ch_end111 - ch111111;

                                    Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
                                    Package1 = Package1 + "</br>";
                                    ch111111 = ch111111 + 9;
                                    if (ch111111 > len11111111)
                                        ch111111 = len11111111;
                                }
                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                                tbl = tbl + (Package1 + "</td>");






                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["Edition"] + "</td>");

                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");
                                if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                    area = area + float.Parse(ds.Tables[0].Rows[d]["Area"].ToString());



                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["BillStatus"] + "</td>");

                                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["grossamt"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyTD(%)"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyTDAmt"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTD(%)"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTDAmt"] + "</td>");




                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"]);
                                tbl = tbl + bill11.ToString("F2") + "</td>";
                                if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                                {
                                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                                    subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                                }



                                tbl = tbl + ("<td class='rep_data' align='right' >");
                                tbl = tbl + (ds.Tables[0].Rows[d]["RetainerCommision"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");

                                Double ret_comm_amt;
                                if (ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString() != "")
                                {
                                    ret_comm_amt = Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"]);
                                }
                                else
                                {
                                    ret_comm_amt = 0;
                                }
                                tbl = tbl + ret_comm_amt.ToString("F2") + "</td>";

                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["ActualBusiness"] + "</td>");

                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");
                                tbl = tbl + "</tr>";

                                if (ds.Tables[0].Rows[d]["RetainerCommision"].ToString() != "")
                                {
                                    subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[d]["RetainerCommision"].ToString());
                                    totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[d]["RetainerCommision"].ToString());
                                }

                                if (ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString() != "")
                                {
                                    subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString());
                                    totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString());
                                }




                            }
                            else
                            {

                                tbl = tbl + ("<tr valign='top' height='25'>");


                                tbl = tbl + ("<td class='rep_data2' colspan='2' valign='top'>");
                                tbl = tbl + "<b>" + "Sub Total:" + "</b>" + "</td>";

                                tbl = tbl + ("<td class='rep_data' colspan='12'>");
                                tbl = tbl + "</td>";

                                //tbl = tbl + ("<td class='rep_data' >");
                                //tbl = tbl + "</td>";

                                //tbl = tbl + ("<td class='rep_data' >");
                                //tbl = tbl + "</td>";

                                //tbl = tbl + ("<td class='rep_data'>");
                                //tbl = tbl + "</td>";
                                //tbl = tbl + ("<td class='rep_data'>");
                                //tbl = tbl + "</td>";


                                //tbl = tbl + ("<td class='rep_data' >");
                                //tbl = tbl + "</td>";

                                tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subBillAmt.ToString("F2") + "</b>";
                                tbl = tbl + "</td>";


                                //tbl = tbl + ("<td class='rep_data'>");
                                //tbl = tbl + "</td>";

                                //tbl = tbl + ("<td class='rep_data'>");
                                //tbl = tbl + "</td>";

                                tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercomm + "</b>";
                                tbl = tbl + "</td>";

                                tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercommamt.ToString("F2") + "</b>";
                                tbl = tbl + "</td>";

                                tbl = tbl + ("<td class='rep_data'>");
                                tbl = tbl + "</td>";

                                tbl = tbl + "</tr>";


                                subretainercomm = 0.00;
                                subBillAmt = 0.00;
                                subretainercommamt = 0.00;

                                tbl = tbl + ("<tr class='pagebreaknot'>");


                                //tbl = tbl + ("<td class='rep_data'>");
                                //tbl = tbl + (i1++.ToString() + "</td>");
                                tbl = tbl + ("<td class='rep_data'>");
                                tbl = tbl + (a.ToString() + "</td>");

                                string retname = "";
                                string retname11 = ds.Tables[0].Rows[d]["RetainName"].ToString();
                                char[] retname111 = retname11.ToCharArray();
                                int length11 = retname111.Length;

                                for (int chnew = 0; chnew < length11; chnew++)
                                {

                                    if (chnew == 0)
                                    {
                                        retname = retname + retname111[chnew];
                                    }
                                    else if (chnew % 15 != 0)
                                    {
                                        retname = retname + retname111[chnew];
                                    }
                                    else
                                    {
                                        retname = retname + "</br>" + retname111[chnew];
                                    }
                                }


                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + "<b>" + (retname + "</b></td>");
                                string cioid1 = "";
                                string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                                char[] cioid = rrr.ToCharArray();
                                int len11 = cioid.Length;

                                int ch_end = 0;
                                int ch_str = 0;
                                for (int ch = 0; ch < len11; ch++)
                                {
                                    /**/
                                    ch_end = ch_end + 9;
                                    ch_str = ch_end;
                                    if (ch_end > len11)
                                        ch_str = len11 - ch;
                                    else
                                        ch_str = ch_end - ch;

                                    cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                                    cioid1 = cioid1 + "</br>";
                                    ch = ch + 9;
                                    if (ch > len11)
                                        ch = len11;
                                }

                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (cioid1 + "</td>");


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
                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (agency1 + "</td>");

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
                      

                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (client1 + "</td>");



                                string Package1 = "";
                                string rrr111111 = ds.Tables[0].Rows[d]["Publication"].ToString();
                                char[] Package = rrr111111.ToCharArray();
                                int len11111111 = Package.Length;
                                int line1111111 = 0;
                                int ch_end111 = 0;
                                int ch_str111 = 0;
                                for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
                                {
                                    /**/
                                    ch_end111 = ch_end111 + 9;
                                    ch_str111 = ch_end111;
                                    if (ch_end111 > len11111111)
                                        ch_str111 = len11111111 - ch111111;
                                    else
                                        ch_str111 = ch_end111 - ch111111;

                                    Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
                                    Package1 = Package1 + "</br>";
                                    ch111111 = ch111111 + 9;
                                    if (ch111111 > len11111111)
                                        ch111111 = len11111111;
                                }
                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (Package1 + "</td>");


                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["Edition"] + "</td>");

                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");
                                if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                    area = area + float.Parse(ds.Tables[0].Rows[d]["Area"].ToString());


                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["BillStatus"] + "</td>");

                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["grossamt"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyTD(%)"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyTDAmt"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTD(%)"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTDAmt"] + "</td>");




                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"]);
                                tbl = tbl + bill11.ToString("F2") + "</td>";
                                if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                                {
                                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                                    subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                                }



                                tbl = tbl + ("<td class='rep_data' align='right' >");
                                tbl = tbl + (ds.Tables[0].Rows[d]["RetainerCommision"] + "</td>");
                                tbl = tbl + ("<td class='rep_data' align='right'>");

                                Double ret_comm_amt;
                                if (ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString() != "")
                                {
                                    ret_comm_amt = Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"]);
                                }
                                else
                                {
                                    ret_comm_amt = 0;
                                }
                                tbl = tbl + ret_comm_amt.ToString("F2") + "</td>";

                                tbl = tbl + ("<td class='rep_data' align='right'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["ActualBusiness"] + "</td>");

                                tbl = tbl + ("<td class='rep_data' align='left'>");
                                tbl = tbl + (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");
                                tbl = tbl + "</tr>";


                                if (ds.Tables[0].Rows[d]["RetainerCommision"].ToString() != "")
                                {
                                    subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[d]["RetainerCommision"].ToString());
                                    totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[d]["RetainerCommision"].ToString());
                                }

                                if (ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString() != "")
                                {
                                    subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString());
                                    totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString());
                                }

                            }

                        }
                        else
                        {

                            tbl = tbl + ("<tr >");


                            //tbl = tbl + ("<td class='rep_data'>");
                            //tbl = tbl + (i1++.ToString() + "</td>");
                            tbl = tbl + ("<td class='rep_data'>");
                            tbl = tbl + (a.ToString() + "</td>");

                            string retname = "";
                            string retname11 = ds.Tables[0].Rows[d]["RetainName"].ToString();
                            char[] retname111 = retname11.ToCharArray();
                            int length11 = retname111.Length;

                            for (int chnew = 0; chnew < length11; chnew++)
                            {

                                if (chnew == 0)
                                {
                                    retname = retname + retname111[chnew];
                                }
                                else if (chnew % 15 != 0)
                                {
                                    retname = retname + retname111[chnew];
                                }
                                else
                                {
                                    retname = retname + "</br>" + retname111[chnew];
                                }
                            }


                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + "<b>" + (retname + "</b></td>");
                            string cioid1 = "";
                            string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                            char[] cioid = rrr.ToCharArray();
                            int len11 = cioid.Length;

                            int ch_end = 0;
                            int ch_str = 0;
                            for (int ch = 0; ch < len11; ch++)
                            {
                                /**/
                                ch_end = ch_end + 9;
                                ch_str = ch_end;
                                if (ch_end > len11)
                                    ch_str = len11 - ch;
                                else
                                    ch_str = ch_end - ch;

                                cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                                cioid1 = cioid1 + "</br>";
                                ch = ch + 9;
                                if (ch > len11)
                                    ch = len11;
                            }

                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (cioid1 + "</td>");


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
                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (agency1 + "</td>");

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

                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (client1 + "</td>");

                            string Package1 = "";
                            string rrr111111 = ds.Tables[0].Rows[d]["Publication"].ToString();
                            char[] Package = rrr111111.ToCharArray();
                            int len11111111 = Package.Length;
                            int line1111111 = 0;
                            int ch_end111 = 0;
                            int ch_str111 = 0;
                            for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
                            {
                                /**/
                                ch_end111 = ch_end111 + 9;
                                ch_str111 = ch_end111;
                                if (ch_end111 > len11111111)
                                    ch_str111 = len11111111 - ch111111;
                                else
                                    ch_str111 = ch_end111 - ch111111;

                                Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
                                Package1 = Package1 + "</br>";
                                ch111111 = ch111111 + 9;
                                if (ch111111 > len11111111)
                                    ch111111 = len11111111;
                            }
                            tbl = tbl + ("<td class='rep_data'  align='left'>");
                            tbl = tbl + (Package1 + "</td>");


                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["Edition"] + "</td>");


                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");
                            if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                area = area + float.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["BillStatus"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["grossamt"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["AgencyTD(%)"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["AgencyTDAmt"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTD(%)"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTDAmt"] + "</td>");




                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            Double bill11 = Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"]);
                            tbl = tbl + bill11.ToString("F2") + "</td>";
                            if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                            {
                                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                                subBillAmt = subBillAmt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());
                            }



                            tbl = tbl + ("<td class='rep_data' align='right' >");
                            tbl = tbl + (ds.Tables[0].Rows[d]["RetainerCommision"] + "</td>");
                            tbl = tbl + ("<td class='rep_data' align='right'>");

                            Double ret_comm_amt;
                            if (ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString() != "")
                            {
                                ret_comm_amt = Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"]);
                            }
                            else
                            {
                                ret_comm_amt = 0;
                            }
                            tbl = tbl + ret_comm_amt.ToString("F2") + "</td>";

                            tbl = tbl + ("<td class='rep_data' align='right'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["ActualBusiness"] + "</td>");

                            tbl = tbl + ("<td class='rep_data' align='left'>");
                            tbl = tbl + (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");

                            tbl = tbl + "</tr>";

                            if (ds.Tables[0].Rows[d]["RetainerCommision"].ToString() != "")
                            {
                                subretainercomm = subretainercomm + Convert.ToDouble(ds.Tables[0].Rows[d]["RetainerCommision"].ToString());
                                totalretainercomm = totalretainercomm + Convert.ToDouble(ds.Tables[0].Rows[d]["RetainerCommision"].ToString());
                            }

                            if (ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString() != "")
                            {
                                subretainercommamt = subretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString());
                                totalretainercommamt = totalretainercommamt + Convert.ToDouble(ds.Tables[0].Rows[d]["retainer_comm_amount"].ToString());
                            }

                        }


                    }


                     tbl = tbl + "</tr>";

                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";
                    tbl += "<tr></tr>";

                    tblgrid.InnerHtml += tbl;
                    tbl = "";

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
            }
            tbl = tbl + ("<tr valign='top' height='25'>");


            tbl = tbl + ("<td class='rep_data2' colspan='2' valign='top'>");
            tbl = tbl + "<b>" + "Sub Total:" + "</b>" + "</td>";


            tbl = tbl + ("<td class='rep_data' colspan='12'>");
            tbl = tbl + "</td>";

            //tbl = tbl + ("<td class='rep_data' >");
            //tbl = tbl + "</td>";

            //tbl = tbl + ("<td class='rep_data' >");
            //tbl = tbl + "</td>";
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + "</td>";
            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + "</td>";


            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + "</td>";

            tbl = tbl + ("<td class='rep_data2' align='right' valign='top' >") + "<b>" + subBillAmt.ToString("F2") + "</b>";
            tbl = tbl + "</td>";


            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + "</td>";

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + "</td>";

            tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercomm + "</b>";
            tbl = tbl + "</td>";

            tbl = tbl + ("<td class='rep_data2' align='right' valign='top'>") + "<b>" + subretainercommamt.ToString("F2") + "</b>";
            tbl = tbl + "</td>";

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + "</td>";


            tbl = tbl + "</tr>";



           tbl = tbl + ("<tr >");
           // tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='middle31new' colspan='7' valign='top'>");
            tbl = tbl + "<b>" + "Total" + "</b>" + "</td>";


            tbl = tbl + ("<td class='middle31new' colspan='6'>&nbsp;");
            tbl = tbl + "</td>";

           
            tbl = tbl + ("<td class='middle31new' style='font-size: 13px;' align='right' colspan='2' valign='top'>");
            tbl = tbl + "<b>" + "Bill Amount: " + "<b>" + BillAmt.ToString("F2") + "</b>" + "</b>" + "</td>";
            tbl = tbl + "</td>";

            tbl = tbl + ("<td class='middle31new' style='font-size: 13px;' align='right' colspan='2' valign='top'>");
            tbl = tbl + "<b>" + "Retainer Commision Amount: " + "<b>" + totalretainercommamt.ToString("F2") + "</b>" + "</b>" + "</td>";




            tbl = tbl + ("<td class='middle31new'>&nbsp;");
            tbl = tbl + "</td>";

            tbl = tbl + ("<td class='middle31new' style='font-size: 11px;' align='right'>&nbsp;");
            tbl = tbl + "</td>";


            tbl = tbl + ("<td class='middle31new' colspan='7'>&nbsp;");
            tbl = tbl + "</td>";

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

           // tbl = tbl + "<tr><td class='middle4' colspan='4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";


          //  tbl = tbl + ("</table>");
            tblgrid.InnerHtml += tbl;
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }

}
