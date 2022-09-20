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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;

public partial class moneyrecievedview : System.Web.UI.Page
{
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string frmdt = "";
    string todate = "", datefrom1 = "", dateto1="";
    string paymodename = "", paymode = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string clientname = "";
    string agencyname = "";
    string clientname1 = "";
    string incluest = "";
    string agencyname1 = "", adtypecode = "", adtypename="",reporttype="",reptype="",find_pay="";
    double BillAmt = 0,area=0;
    double BillAmt1 = 0, area1 = 0;
    int sno = 1;
    int i2 = 1;
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
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
       

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));

        heading.Text = ds1.Tables[0].Rows[0].ItemArray[90].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        ds = (DataSet)Session["moneyrep"];
        string prm = Session["prm_moneyrep"].ToString();
        string[] prm_Array = new string[24];
        prm_Array = prm.Split('~');



        frmdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        todate = prm_Array[3];//Request.QueryString["dateto"].ToString();
        destination = prm_Array[5];//Request.QueryString["destination"].ToString();
        agencyname = prm_Array[7];//Request.QueryString["agency"].ToString();
        agencyname1 = prm_Array[9];//Request.QueryString["agencyname"].ToString();
        clientname = prm_Array[11];//Request.QueryString["client"].ToString();
        clientname1 = prm_Array[13];//Request.QueryString["clientname"].ToString();
        paymode = prm_Array[15];//Request.QueryString["paymode"].ToString();
        paymodename = prm_Array[17];//Request.QueryString["paymodename"].ToString();
        adtypecode = prm_Array[19];//Request.QueryString["adtypecode"].ToString();
        adtypename = prm_Array[21];//Request.QueryString["adtypename"].ToString();
        chk_excel = prm_Array[23];
        reporttype = prm_Array[25];
        incluest = prm_Array[26];
        reptype = prm_Array[28];
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

        if (!Page.IsPostBack)
        {

            if (destination == "1" || destination == "0")
                onscreen(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode, adtypecode);
            else if (destination == "4")
                excel(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode, adtypecode);
            else if (destination == "3")
                pdf(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode, adtypecode);
        }

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


    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }

    private void onscreen(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string paymode, string adtypecode)
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
            //    ds = obj.money_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(),paymode,adtypecode);
            //}
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
            int cont = ds.Tables[0].Rows.Count;

            string tbl = "";
            tbl = "<table width='100%'align='left' cellpadding='0' cellspacing='0'>";
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

            int i1 = 1;


            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data' align='left'>");
                string cioid1 = "";
                string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
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
                tbl = tbl + (ds.Tables[0].Rows[i]["ReceiptNo"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["User"] + "&nbsp</td>");
                if (reporttype == "N")
                {
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["RO_No"] + "&nbsp</td>");
                }
                tbl = tbl + ("<td class='rep_data' align='left'width='160px' >");
                //-------------------------------------------//
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
                    agency1 = agency1;
                    ch1 = ch1 + 16;
                    if (ch1 > len111)
                        ch1 = len111;/**/
                }
                //---------------------------------------------//
                tbl = tbl + (agency1 + "</td>");
                tbl = tbl + ("<td class='rep_data' align='left' width='100px'>");
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
                    client1 = client1;
                    ch11 = ch11 + 16;
                    if (ch11 > len1111)
                        ch11 = len1111;
                }
                tbl = tbl + (client1 + "</td>");
                tbl = tbl + ("<td class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Branch"] + "</td>");
                if (reporttype == "O")
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
                }
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["uom"] + "</td>");
                if (reporttype == "O")
                {
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillableArea"].ToString()) + "</td>");

                    if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                        area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["BillableArea"].ToString());
                }
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["TradeDisc%"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                if (reporttype == "N")
                {
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["Bill_remarks"].ToString() + "</td>");

                }

                tbl = tbl + "</tr>";
                tblgrid.InnerHtml += tbl;
                tbl = "";

            }

            tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
            tbl = tbl + ("<td class='middle31new'  align='left'>");
            tbl = tbl + ((i1 - 1).ToString() + "</td>");
            if (reporttype == "O")
            {
                tbl = tbl + ("<td class='middle31new'  colspan='7'>&nbsp;</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle31new'  colspan='6'>&nbsp;</td>");
            }
            tbl = tbl + ("<td class='middle31new'>Total</td>");
            tbl = tbl + ("<td class='middle31new' align='right'>");
            tbl = tbl + (string.Format("{0:0.00}", area) + "</td>");
            if (reporttype == "O")
            {
                tbl = tbl + ("<td class='middle31new'>&nbsp;</td>");
            }
            tbl = tbl + ("<td class='middle31new' align='right'>");
            tbl = tbl + (string.Format("{0:0.00}", BillAmt) + "</td>");
            tbl = tbl + "</tr>";
            tbl = tbl + ("</table>");
            tblgrid.InnerHtml += tbl;

        }
        else
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
            //    ds = obj.money_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(),paymode,adtypecode);
            //}
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
            int cont = ds.Tables[0].Rows.Count;

            string tbl = "";
            tbl = "<table width='100%'align='left' cellpadding='0' cellspacing='0'>";
            tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td class='middle31new' align='left' >BookingId</td><td class='middle31new' align='left'>MR.No.</td><td class='middle31new' align='left'>User</td><td class='middle31new' align='left'>Agency</td><td class='middle31new' align='left'>Client</td><td class='middle31new' align='left'>Branch</td><td  class='middle31new' align='right'>CardRate</td><td  class='middle31new' align='right'>AgreedRate</td><td  class='middle31new' align='right'>UOM</td><td class='middle31new' align='right'>BillableArea</td><td  class='middle31new' align='right'>TradeDisc.(%)</td><td class='middle31new' align='right'>BillAmt</td></tr>");

            int i1 = 1;
            find_pay = ds.Tables[0].Rows[0]["paymode"].ToString();

            for (int i = 0; i <= cont - 1; i++)
            {
                if (i == 0)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'><b>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["payname"].ToString() + "</b></td>");
                    tbl = tbl + "</tr>";

                }
                else
                {
                    if (find_pay.IndexOf(ds.Tables[0].Rows[i]["paymode"].ToString()) < 0)
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

                        find_pay += ds.Tables[0].Rows[i]["paymode"].ToString();
                        area = 0; BillAmt = 0; i1 = 1;
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_data'><b>");
                        tbl = tbl + (ds.Tables[0].Rows[i]["payname"].ToString() + "</b></td>");
                        tbl = tbl + "</tr>";


                    }
                }

                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");
                tbl = tbl + ("<td class='rep_data' align='left' >");

                tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"].ToString() + "</td>");

                tbl = tbl + ("<td class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["ReceiptNo"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["User"] + "&nbsp</td>");

                tbl = tbl + ("<td class='rep_data' align='left'width='160px' >");
                //-------------------------------------------//
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
                    agency1 = agency1;
                    ch1 = ch1 + 16;
                    if (ch1 > len111)
                        ch1 = len111;/**/
                }
                //---------------------------------------------//
                tbl = tbl + (agency1 + "</td>");
                tbl = tbl + ("<td class='rep_data' align='left' width='100px'>");
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
                    client1 = client1;
                    ch11 = ch11 + 16;
                    if (ch11 > len1111)
                        ch11 = len1111;
                }
                tbl = tbl + (client1 + "</td>");
                tbl = tbl + ("<td class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Branch"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["CardRate"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["uom"] + "</td>");

                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillableArea"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["BillableArea"].ToString() != "")
                    area = area + Convert.ToDouble(ds.Tables[0].Rows[i]["BillableArea"].ToString());

                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["TradeDisc%"] + "</td>");
                tbl = tbl + ("<td class='rep_data' align='right'>");
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());
                i2++;
                find_pay += ds.Tables[0].Rows[i]["paymode"].ToString();
                tbl = tbl + "</tr>";
                tblgrid.InnerHtml += tbl;
                tbl = "";

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
            tbl = tbl + "</tr>";
            tbl = tbl + ("</table>");
            tblgrid.InnerHtml += tbl;
        }

    }
    private void pdf(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string paymode,string adtypecode)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
         string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        name = Server.MapPath("") + "//" + pdfName;

        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new Phrase("Page No." + i2++), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        document.Footer = footer;
        footer.Border = 0;
        document.Open();


      
       
       
        int NumColumns=0;
        //---------------------------end-------------------------------------------------------
        if (reporttype == "O")
        {
             NumColumns = 12;
        }
        else
        {
             NumColumns = 11;
        }
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 9);

        // ---------------table for heading-------------------------
        try
        {
            //DataSet ds = new DataSet();

            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //    //  ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}
            //else
            //{
            //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            //    ds = obj.money_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode,adtypecode);
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

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[90].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
           
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 3; i++)
            {
                document.Add(tbl1);
            }
            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.WidthPercentage = 100;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(),font10));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font10));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font10));
            document.Add(tbl2);

            PdfPTable tbl91111 = new PdfPTable(6);
            tbl91111.DefaultCell.BorderWidth = 0;
            tbl91111.WidthPercentage = 100;
            tbl91111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl91111.addCell(new Phrase("Agency:", font10));
            tbl91111.addCell(new Phrase(lbagency.Text, font10));
            tbl91111.addCell(new Phrase("Client:", font10));
            tbl91111.addCell(new Phrase(lbclient.Text, font10));
            tbl91111.addCell(new Phrase("Pay Mode:", font10));
            tbl91111.addCell(new Phrase(lbpaymode.Text, font10));
            document.Add(tbl91111);


            PdfPTable tbl91 = new PdfPTable(NumColumns);
            tbl91.DefaultCell.BorderWidth = 0;
            tbl91.WidthPercentage = 100;
            tbl91.DefaultCell.Colspan = NumColumns;
            tbl91.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl91);

            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
           
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[99].ToString(), font10));
            datatable.addCell(new Phrase("User", font10));
            if (reporttype == "N")
            {
                datatable.addCell(new Phrase("RO NO.", font10));
            }
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase("Branch", font10));
            if (reporttype == "O")
            {
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
                datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));
            }
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[100].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            if (reporttype == "N")
            {
                datatable.addCell(new Phrase("Remarks", font10));
            }
            datatable.HeaderRows = 1;
           // Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            //document.Add(p2);

            datatable.DefaultCell.Colspan = NumColumns;
            datatable.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            //------------------//-------------------------------------------------------------------   


            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {


                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ReceiptNo"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["User"].ToString(), font11));
                if (reporttype == "N")
                {
                  datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RO_No"].ToString(), font11));
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Branch"].ToString(), font11));
                if (reporttype=="O")
                {
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillableArea"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                area = area + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["TradeDisc%"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillAmt"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                  if (reporttype=="N")
                  {
                      datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Bill_remarks"].ToString(), font11));
                  }
               
                row++;

            }





            document.Add(datatable);
            PdfPTable tbl9111 = new PdfPTable(12);
            tbl9111.DefaultCell.BorderWidth = 0;
            tbl9111.WidthPercentage = 100;
            tbl9111.DefaultCell.Colspan = 12;
            tbl9111.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl9111);
            //Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            //document.Add(p3);
            //float[] totl = {10,10,10,10,10,10,10,10,10,10,20 };
            //PdfPTable tbltotal = new PdfPTable(12);
            float[] totl = { 10, 10, 5, 5, 5, 5, 5, 5, 5, 20, 10, 15 };
            PdfPTable tbltotal = new PdfPTable(12);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
          
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString() + (i1 - 1).ToString(), font10));
            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.DefaultCell.Colspan = 1;
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.Colspan = 2;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase("Area" + chk_null(area.ToString()), font10));
            tbltotal.DefaultCell.Colspan = 1;
            //tbltotal.addCell(new Phrase(chk_null(area.ToString()), font11));
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.DefaultCell.Colspan = 2;
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("BillAmt" + BillAmt.ToString(), font10));
            tbltotal.DefaultCell.Colspan = 1;

            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));

            document.Add(tbltotal);
            PdfPTable tbl911 = new PdfPTable(12);
            tbl911.DefaultCell.BorderWidth = 0;
            tbl911.WidthPercentage = 100;
            tbl911.DefaultCell.Colspan = 12;
            tbl911.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbl911);
            document.Close();
            document.Close();
            document.Close();

            
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    private void excel(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string paymode,string adtypecode)
    {

        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        //   // ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.money_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode,adtypecode);
        //}

        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
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

        

    //    tbl = tbl + "<table width='100%' id='tab2' align='left' cellpadding='5' cellspacing='1'>";
    //    tbl = tbl + ("<tr><td class='middle4' colspan='5'></td><td class='middle4' colspan='3' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
    //    tbl = tbl + ("<tr><td class='middle4' colspan='5'></td><td class='middle4' colspan='3' ><b>Money Recieved Report</b></td></tr>");
    //    tbl = tbl + ("<tr></tr><tr></tr><tr><td class='middle4' >AGENCY</td><td class='middle4' >" + lbagency.Text + "</td><td class='middle4' ></td><td class='middle4' >CLIENT</td><td class='middle4' align='left' >" + lbclient.Text + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >PAYMODE:</td><td class='middle4' >" + lbpaymode.Text + "</td></tr>");
    //    tbl = tbl + ("<tr><td class='middle4' >Date From:</td><td class='middle4' align='left' >" + fromdt + "</td><td class='middle4' ></td><td class='middle4' >Date To:</td><td class='middle4' align='left' >" + dateto + "</td><td class='middle4' ></td><td class='middle4' ></td></td><td class='middle4' >Run Date:</td><td class='middle4' >" + date.ToString() + "</td></tr>");
    ////    tbl = tbl + ("<tr><td class='middle4' >Publication:</td><td class='middle4' align='left' >" + lblpublication.Text + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >Publication Center:</td><td class='middle4' >" + lblpublicationcenter.Text + "</td><td class='middle4' ></td><td class='middle4' ></td></tr>");
    // //   tbl = tbl + ("<tr><td class='middle4' >ADTYPE</td><td class='middle4' >" + adtype + "</td><td class='middle4' ></td><td class='middle4' >Adcategory</td><td class='middle4' >" + lbadcategory.Text + "</td><td class='middle4' ></td><td class='middle4' ></td><td class='middle4' >Edition:</td><td class='middle4' >" + lbedition.Text + "</td></tr>");
    //    tbl = tbl + ("<tr></tr></table>");
        //tblgrid.InnerHtml += tbl;

        //if (chk_excel == "1")
        //{
        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    tblgrid.Visible = true;
        //    tblgrid.RenderControl(hw);
        //    Response.Write(sw.ToString());
        //}



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
        nameColumn1.HeaderText = "MR.No.";
        nameColumn1.DataField = "ReceiptNo";

        name1 = name1 + "," + "MR.No.";
        name2 = name2 + "," + "ReceiptNo";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn1);

        BoundColumn nameColumn2 = new BoundColumn();
        nameColumn2.HeaderText = "User";
        nameColumn2.DataField = "User";

        name1 = name1 + "," + "User";
        name2 = name2 + "," + "User";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn2);

        if (reporttype == "N")
        {
            BoundColumn nameColumn14= new BoundColumn();
            nameColumn14.HeaderText = "RO No.";
            nameColumn14.DataField = "RO_No";

            name1 = name1 + "," + "RO No.";
            name2 = name2 + "," + "RO_No";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn14);

        }


        BoundColumn nameColumn4 = new BoundColumn();
        nameColumn4.HeaderText = "Agency";
        nameColumn4.DataField = "Agency";

        name1 = name1 + "," + "Agency";
        name2 = name2 + "," + "Agency";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn4);



        BoundColumn nameColumn6 = new BoundColumn();
        nameColumn6.HeaderText = "Client";
        nameColumn6.DataField = "Client";

        name1 = name1 + "," + "Client";
        name2 = name2 + "," + "Client";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn6);

        BoundColumn nameColumn7 = new BoundColumn();
        nameColumn7.HeaderText = "Branch";
        nameColumn7.DataField = "Branch";

        name1 = name1 + "," + "Branch";
        name2 = name2 + "," + "Branch";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn7);

 if (reporttype=="O")
            {
        BoundColumn nameColumn9 = new BoundColumn();
        nameColumn9.HeaderText = "CardRate";
        nameColumn9.DataField = "CardRate";

        name1 = name1 + "," + "CardRate";
        name2 = name2 + "," + "CardRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn9);

        BoundColumn nameColumn10 = new BoundColumn();
        nameColumn10.HeaderText = "AgreedRate";
        nameColumn10.DataField = "AgreedRate";

        name1 = name1 + "," + "AgreedRate";
        name2 = name2 + "," + "AgreedRate";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn10);

        BoundColumn nameColumn11 = new BoundColumn();
        nameColumn11.HeaderText = "BillableArea";
        nameColumn11.DataField = "BillableArea";

        name1 = name1 + "," + "BillableArea";
        name2 = name2 + "," + "BillableArea";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn11);
 }

        BoundColumn nameColumn12 = new BoundColumn();
        nameColumn12.HeaderText = "TradeDisc%";
        nameColumn12.DataField = "TradeDisc%";

        name1 = name1 + "," + "TradeDisc%";
        name2 = name2 + "," + "TradeDisc%";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn12);


        BoundColumn nameColumn13 = new BoundColumn();
        nameColumn13.HeaderText = "BillAmt";
        nameColumn13.DataField = "BillAmt";

        name1 = name1 + "," + "BillAmt";
        name2 = name2 + "," + "BillAmt";
        name3 = name3 + "," + "G";
        DataGrid1.Columns.Add(nameColumn13);
        if (reporttype == "N")
        {

            BoundColumn nameColumn15 = new BoundColumn();
            nameColumn15.HeaderText = "Remarks";
            nameColumn15.DataField = "Bill_remarks";

            name1 = name1 + "," + "Remarks";
            name2 = name2 + "," + "Bill_remarks";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn15);
        }


        DataGrid1.DataSource = ds;
        if (chk_excel == "1")
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            DataGrid1.ShowHeader = true;
            DataGrid1.ShowFooter = true;
            DataGrid1.DataBind();
            hw.Write("<p <table border=\"1\"><tr><td colspan=\"12\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");

            hw.Write("<p <tr><td colspan=\"12\"align=\"center\"><b>" + "Money Recieved Report" + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>AGENCY:" + lbagency.Text + "</b></td><td colspan=\"4\"align=\"left\"><b>CLIENT:" + lbclient.Text + "</b></td><td colspan=\"4\"align=\"left\" ><b>PAYMODE:" + lbpaymode.Text + "</b></td></tr>");
            hw.Write("<p <tr><td colspan=\"4\"align=\"left\"><b>Date From:" + fromdt + "</b></td><td colspan=\"4\"align=\"left\"><b>Date To:" + dateto + "</b></td><td colspan=\"4\"align=\"left\"><b>Run Date:" + date.ToString() + "</b></td></tr>");
              
            //hw.Write("<p align=\"left\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
            //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Money Recieved Report<b>");

            hw.WriteBreak();
            DataGrid1.RenderControl(hw);
            //double arr = comm2 / areanew;
            int sno11 = sno - 1;
         
            Response.Write(sw.ToString().Replace("</table>", "<tr><td align='left'><b>TotalAds :" + sno11 + "</b></td><td colspan='8' align='right'></td><td colspan=\"1\" align='right'><b>TotalArea:" + (string.Format("{0:0.00}", area)) + "</b></td><td colspan=\"1\">" + "" + "</td><td colspan=\"1\"><b>BillAmt:" + (string.Format("{0:0.00}", BillAmt)) + "</b></td></table>")); //align=\"center\" colspan=\"7\"
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
    
    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["prm_moneyrep_print"] = "destination~" + destination + "~fromdate~" + frmdt + "~dateto~" + todate + "~agencyname~" + agencyname1 + "~clientname~" + clientname1 + "~paymode~" + paymode + "~paymodename~" + paymodename + "~agency~" + agencyname + "~client~" + clientname + "~adtypename~" + adtypename + "~adtypecode~" + adtypecode + "~Reporttype~" + reporttype + "~incluestatus~" + incluest;
         Response.Redirect("moneyrecievedprint.aspx");
       // Response.Redirect("moneyrecievedprint.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + todate + "&agencyname=" + agencyname1 + "&clientname=" + clientname1 + "&paymode=" + paymode + "&paymodename=" + paymodename + "&agency=" + agencyname + "&client=" + clientname + "&adtypename=" + adtypename + "&adtypecode=" + adtypecode);

    }
    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {

        double sumamt = 0;
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;
        string arean = "";
        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }
        
            string check1 = e.Item.Cells[9].Text;
        
        if (reporttype == "O")
        {
            if (check1 != "BillableArea")
            {
                if (check1 != "&nbsp;")
                {
                     arean = e.Item.Cells[9].Text;
                    area = area + Convert.ToDouble(arean);
                }
            }
        }
        string check2 = "";
       
        if (reporttype == "O")
        {
             check2 = e.Item.Cells[11].Text;
        }
        else
        {
             check2 = e.Item.Cells[9].Text;
        }

        if (check2 != "BillAmt")
        {
            if (check2 != "&nbsp;")
            {
                if (reporttype == "O")
                {
                     arean = e.Item.Cells[11].Text;
                }
                else
                {
                     arean = e.Item.Cells[9].Text;
                }
                BillAmt = BillAmt + Convert.ToDouble(arean);
            }
        }
    }
    
}
