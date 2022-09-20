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

public partial class BarterBillview : System.Web.UI.Page
{
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string frmdt = "";
    string todate = "";

    string date = "";
    string day = "";
    string month = "";
    string year = "";
    //string clientn = "";

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

    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    double billarea2 = 0;
    double billablearea = 0;
    int sno = 1;
    int sumsno;
    //string client = "";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "", chk_excel = "";
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

        heading.Text = ds1.Tables[0].Rows[0].ItemArray[29].ToString();

        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        ds = (DataSet)Session["barterbill"];
        string prm = Session["prm_barterbill"].ToString();
        string[] prm_Array = new string[22];
        prm_Array = prm.Split('~');


        region = prm_Array[1];// Request.QueryString["regcode"].ToString();
        regionname = prm_Array[3];//Request.QueryString["region"].ToString();
        frmdt = prm_Array[5];//Request.QueryString["fromdate"].ToString();
        todate = prm_Array[7];//Request.QueryString["dateto"].ToString();
        destination = prm_Array[9];//Request.QueryString["destination"].ToString();
        product = prm_Array[11];//Request.QueryString["product"].ToString();
        productname = prm_Array[13];//Request.QueryString["productname"].ToString();
        agency = prm_Array[15];//Request.QueryString["agency"].ToString();
        agencyname = prm_Array[25];//Request.QueryString["agency"].ToString();
        client = prm_Array[17];//Request.QueryString["client"].ToString();
        clientname = prm_Array[23];
        booktype = prm_Array[19];//Request.QueryString["booktype"].ToString();
        chk_excel = prm_Array[21];
        Ajax.Utility.RegisterTypeForAjax(typeof(BarterBillview));
        hiddendatefrom.Value = fromdt.ToString();

        //  hiddendateto.Value = dateto.ToString();
        // string dateformat = Request.QueryString["dateformat"].ToString();     

        if (product == "0" || product == "")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = productname.ToString();
        }


        if (client == "0" || client == "")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname.ToString();
        }

        if (agency == "0" || agency == "")
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
            date = day + "/" + month + "/" + year;


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
                date = month + "/" + day + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + month + "/" + day;

                }
        //DateTime expirationDate = new DateTime(1/11/2011); // random date
        //string lastTwoDigitsOfYear = expirationDate.ToString("dd");
        //lastTwoDigitsOfYear = lbldate.Text;
        lbldate.Text = date.ToString();
        //datefrom1 = "";
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


        if (!IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString());
            }
            else if (destination == "4")
            {
                excel(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString());

            }
            else
                if (destination == "3")
                {
                    pdf(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString());
                }

        }

    }

    private void onscreen(string frmdt, string todate, string compcode, string clientname, string agencyname, string region, string product, string booktype, string dateformate)
    {

        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
        //    ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    // ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //     ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(),clientname, agencyname,  region, product,booktype, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;

        string tbl = "";
        tbl = "<table width='90%'align='left' cellpadding='0' cellspacing='0'>";
        //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";



        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td class='middle31new' align='left'>Booking</br>Id</td><td class='middle31new' align='left'>Agency</td><td  class='middle31new'   align='left'>Client</td><td  class='middle31new' align='left'>Publication</td><td  class='middle31new' align='left'>Edition</td><td class='middle31new' align='right'>Area</td><td  class='middle31new' align='right'>BillAmt&nbsp;&nbsp;</td><td class='middle31new' align='left'>AdType</td><td class='middle31new' align='left'>Adcat</td><td class='middle31new'  align='left'>RevenueCenter</td></tr>"); //<td id='tdpay~6' class='middle3'   onclick=sorting('Adcat',this.id)>Adcat<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td>
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>"); <td class='middle31'>BillAmt</td><td class='middle31'>BillableArea</td>   
            // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");







        }



        //else if (hiddenascdesc.Value == "asc")
        //{
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tded~4' class='middle3' onclick=sorting('edition',this.id)>Edition<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillAmt<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillAmt</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
        //}
        //else if (hiddenascdesc.Value == "desc")
        //{
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tded~4' class='middle3' onclick=sorting('edition',this.id)>Edition<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillAmt<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>BillAmt</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");
        //}




        int i1 = 1;


        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
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
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
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
            //string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
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
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
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
            //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
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
            string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
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
            // lbclient.Text = rrr2;
            tbl = tbl + (client1 + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                tbl += Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2") + "</td>";
            else
                tbl = tbl + ( "</td>");

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());

            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Adcat"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data'  align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");


            tbl = tbl + "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";

        }

        // tbl = tbl + ("<tr>");
        // tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        // tbl = tbl + ("<tr>");
        //  tbl = tbl + ("<td class='middle123'>");
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
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;



    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {


        double sumamt = 0;
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check1 = e.Item.Cells[6].Text;
        string amt1 = e.Item.Cells[6].Text;
        // string areanew1 = "";
        // string check2 = e.Item.Cells[6].Text;


        //area
        if (check1 != "Area")
        {
            if (check1 != "&nbsp;")
            {
                string arean = e.Item.Cells[6].Text;
                arean = Convert.ToDouble(e.Item.Cells[6].Text.ToString()).ToString("F2");
                areanew = areanew + Convert.ToDouble(arean);
                // areanew1 = "'" + areanew;
            }
            string check2 = e.Item.Cells[7].Text;
            string billarean = e.Item.Cells[7].Text;

            if (check2 != "BillAmt")
            {
                if (check2 != "&nbsp;")
                {
                    string billarea1 = e.Item.Cells[7].Text;
                    billarea2 = Convert.ToDouble(billarea1);
                    billablearea = billablearea + billarea2;
                }
            }
        }
    }

    private void excel(string frmdt, string todate, string compcode, string clientname, string agencyname, string region, string product, string booktype, string dateformate)
    {

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        SqlDataAdapter da = new SqlDataAdapter();

        int cont = ds.Tables[0].Rows.Count;

        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='0' cellspacing='0'border='1' align='center'>";

        string compname1 = cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        string reportname1 = "Booking Type Wise Report";


        //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

        tbl = tbl + "<tr><td>";
        tbl = tbl + "<table style='width:100%' border='1'>";
        tbl = tbl + "<tr><td></td><td align='center' style='height: 20px;padding-right:130px; font-weight:bolder; color :Black;' colspan='10' > ";
        tbl = tbl + compname1;
        tbl = tbl + "</td></tr>";

        tbl = tbl + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
        tbl = tbl + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px; font-weight:lighter;' colspan='10' ><b>";
        tbl = tbl + reportname1;
        tbl = tbl + "</b></td></tr>";

        //tbl = tbl + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
        //tbl = tbl + "<td align='center' style='height: 20px;padding-right:130px; font-family:Arial;font-size:12px' colspan='7'><b>From Date  </b>" + frmdt + "<b>    To   </b>" + todate + "</td>";
        //tbl = tbl + "</tr>";

        tbl = tbl + "<tr><td style='width: 69px'> </td></tr></table>";
        // tbl = tbl + "</td></tr>";
        tbl = tbl + "<table  cellpadding='0' cellspacing='0' align='center' border='1' width='100%' >";


        string pub_name = "";
        if (product == "0" || product == null)
        {
            pub_name = "All";

        }
        else
        {
            // pub_name = product;
            pub_name = productname.ToString();
        }
        tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;' ColSpan='3'><b>Publication:</b>" + pub_name + "</td>";

        string printingname = "";
        if (agencyname == "" || agencyname == null)
        {
            printingname = "All";

        }
        else
        {
            printingname = agencyname;
        }

        tbl = tbl + "<td  align='left' style='font-family:Arial;font-size:12px;' ColSpan='2'><b>Agency:</b>" + printingname + "</td>";
        string brname = "";
        if (clientname == "" || clientname == null)
        {
            brname = "All";

        }
        else
        {
            brname = clientname;
        }
        tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;' ColSpan='6'><b>Client:</b>" + brname + "</td></tr>";


        //string adt = "";
        //if (frmdt == "" || frmdt == null)
        //{
        //    adt = "All";

        //}
        //else
        //{
        //    adt = adtype_name;
        //}
        tbl = tbl + "<tr><td  align='left'style='font-family:Arial;font-size:12px;' ColSpan='3'><b>Date From:</b>" + frmdt + "</td>";

        //string adcatname = "";
        //if (adv_category == "" || adv_category == null)
        //{
        //    adcatname = "All";

        //}
        //else
        //{
        //    adcatname = adv_category;
        //}
        tbl = tbl + "<td  align='left'style='font-family:Arial;font-size:12px;' ColSpan='2'><b>Date To:</b>" + todate + "</td>";

        tbl = tbl + "<td  align='right'style='font-family:Arial;font-size:12px;' ColSpan='6'><b>Run Date:</b>" + date + "</td></tr>";
        //string pno = 1;
        //tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Taluka Name:</b>" + pno + "</td></tr>";

        tbl = tbl + " </table>";


        if (hiddenascdesc.Value == "")
        {
            tbl = tbl + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='1' width='100%' >";

            tbl = tbl + ("<tr><td style='font-family:Arial;font-weight:bold; font-size:12px;'>S.No.</td><td style='font-family:Arial;font-size:12px;font-weight:bold;' align='left'>Booking</br>Id</td><td style='font-family:Arial;font-weight:bold; font-size:12px; align='left'>Agency</td><td  style='font-family:Arial;font-weight:bold; font-size:12px;   align='left'>Client</td><td  style='font-family:Arial;font-weight:bold; font-size:12px; align='left'>Publication</td><td  style='font-family:Arial;font-weight:bold; font-size:12px; align='left'>Edition</td><td style='font-family:Arial;font-weight:bold; font-size:12px; align='right'>Area</td><td  style='font-family:Arial;font-weight:bold; font-size:12px; align='right'>BillAmt&nbsp;&nbsp;</td><td style='font-family:Arial;font-weight:bold; font-size:12px;' align='left'>AdType</td><td style='font-family:Arial;font-weight:bold; font-size:12px; align='left'>Adcat</td><td style='font-family:Arial;font-weight:bold; font-size:12px;  align='left'>RevenueCenter</td></tr>"); //<td id='tdpay~6' class='middle3'   onclick=sorting('Adcat',this.id)>Adcat<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td>
            //tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td class='middle3'>PaymentType</td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td class='middle3'>BillStatus</td><td class='middle3'>BillableArea</td><td class='middle3'>RevenueCenter</td>"); <td class='middle31'>BillAmt</td><td class='middle31'>BillableArea</td>   
            // tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' >CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>AdType</td><td id='tdpay~6' class='middle3'   onclick=sorting('PaymentType',this.id)>PaymentType<img id='imgpaydown' src='Images\\down.gif' style='display:block;'><img id='imgpayup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>Area</td><td class='middle3'>BillAmt</td><td id='tdpayt~9' class='middle3' onclick=sorting('BillStatus',this.id)>BillStatus<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle3'>BillableArea</td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td>");
        }
        //else if (hiddenascdesc.Value == "asc")
        //{
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:block;'><img id='imgcliup' src='Images\\up.gif' style='display:none;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td id='tded~4' class='middle3' onclick=sorting('edition',this.id)>Edition<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillAmt<img id='imgbillstdown' src='Images\\down.gif' style='display:block;'><img id='imgbillstup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>BillAmt</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:block;'><img id='imgadtypeup' src='Images\\up.gif' style='display:none;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:block;'><img id='imgrevcup' src='Images\\up.gif' style='display:none;'></td></tr>");
        //}
        //else if (hiddenascdesc.Value == "desc")
        //{
        //    tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td id='tdag~2' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:none;'><img id='imgagup' src='Images\\up.gif' style='display:block;'></td><td id='tdcli~3' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgclidown' src='Images\\down.gif' style='display:none;'><img id='imgcliup' src='Images\\up.gif' style='display:block;'></td><td id='tdpub~4' class='middle3' onclick=sorting('publication',this.id)>Publication<img id='imgpubdown' src='Images\\down.gif' style='display:none;'><img id='imgpubup' src='Images\\up.gif' style='display:block;'></td><td id='tded~4' class='middle3' onclick=sorting('edition',this.id)>Edition<img id='imgpubdown' src='Images\\down.gif' style='display:block;'><img id='imgpubup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Area</td><td id='tdbill~6' class='middle3' onclick=sorting('BillStatus',this.id)>BillAmt<img id='imgbillstdown' src='Images\\down.gif' style='display:none;'><img id='imgbillstup' src='Images\\up.gif' style='display:block;'></td><td class='middle31'>BillAmt</td><td id='tadtype~10' class='middle3' onclick=sorting('AdType',this.id)>AdType<img id='imgadtypedown' src='Images\\down.gif' style='display:none;'><img id='imgadtypeup' src='Images\\up.gif' style='display:block;'></td><td id='trevec~11' class='middle3' onclick=sorting('RevenueCenter',this.id)>RevenueCenter<img id='imgrevcdown' src='Images\\down.gif' style='display:none;'><img id='imgrevcup' src='Images\\up.gif' style='display:block;'></td></tr>");
        //}




        int i1 = 1;


        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
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
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
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
            //string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
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
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
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
            //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
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
            string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
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
            tbl = tbl + (client1 + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Area"] + "</td>");
            tbl += Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2") + "</td>";

            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
                area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());

            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AdType"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Adcat"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data'  align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");


            tbl = tbl + "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";

        }

        // tbl = tbl + ("<tr>");
        // tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
        //tbl = tbl + ("<table>");
        tbl = tbl + ("<td style='font-family:Arial;font-weight:bold; font-size:11px;' border='1'></td>");
        tbl = tbl + ("<tr><td style='font-family:Arial;font-weight:bold; font-size:11px;' colspan='1'>TotalAds.</td>");
        tbl = tbl + ("<td style='font-weight:bold;' colspan='3' align='left'>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");



        //tbl = tbl + ("<td class='middle13'>&nbsp;");
        //tbl = tbl + ("<td style='font-family:Arial;font-weight:bold; font-size:11px;'>TotalArea</td>");
        tbl = tbl + ("<td style='font-weight:bold;' colspan='3' align='right'>");
        tbl = tbl + (string.Format("{0}", area.ToString("#.00")) + "</td>");
        tbl = tbl + ("<td style='font-weight:bold;' align='right'>");
        tbl = tbl + (BillAmt.ToString("F2") + "</td>");
        //tbl = tbl + ("<td class='middle13'>");
        //tbl = tbl + (billarea.ToString() + "<td class='middle13'> </td></td>");
        //tbl = tbl + "<td class='middle123' colspan='3'>&nbsp;</td></tr>";
        // tbl = tbl + ("</table>");

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;


        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

        //    DataGrid1.DataSource = ds;
        //     if (chk_excel == "1")
        //    {
        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    DataGrid1.ShowHeader = true;
        //    DataGrid1.ShowFooter = true;
        //    DataGrid1.DataBind();

        //    hw.Write("<p align='center'><b>"  + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></p>");
        //    hw.Write("<p align='center'><b>Booking Type Wise Report</b></p>");



        //    //hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Booking Type Wise Report<b>");

        //    hw.WriteBreak();
        //    DataGrid1.RenderControl(hw);
        //    double arr = comm2 / areanew;
        //    int sno11 = sno - 1;
        //    //double bil_am = comm2 / billablearea;

        //    Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds :" + sno11 + "</td><td colspan=\"6\" align=\"right\">Total:" + string.Format("{0}", areanew.ToString("#.00")) + "</td><td colspan=\"1\" align=\"right\">" + string.Format("{0}", billablearea.ToString("#.00")) + "</td></table>")); //align=\"center\" colspan=\"7\"
        //}

        //else

        //{

        //    string[] names = name2.Substring(1, name2.Length - 1).Split(',');
        //    string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
        //    string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
        //    string[][] colProperties ={ names, captions, formats };

        //    QueryToCSV(ds, colProperties);
        //}

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
    private void pdf(string frmdt, string todate, string compcode, string clientname, string agencyname, string region, string product, string booktype, string dateformate)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;



        // btnprint.Attributes.Add("onclick", "javascript:window.print();");

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

        //--------------------for page numbering---------------------------------------------

        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        //HeaderFooter footer = new HeaderFooter(new Phrase("01",true));
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();

        //---------------------------end-------------------------------------------------------

        int NumColumns = 11;
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
            //    // ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //    ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
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

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[29].ToString(), font9));
            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);

            string pub_name = "";
            if (product == "0" || product == null)
            {
                pub_name = "All";

            }
            else
            {
                // pub_name = product;
                pub_name = productname.ToString();
            }
            string printingname = "";
            if (agencyname == "" || agencyname == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = agencyname;
            }


            string brname = "";
            if (clientname == "" || clientname == null)
            {
                brname = "All";

            }
            else
            {
                brname = clientname;
            }

            //-----------------table for spacing------------------------------
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            //tbl.addCell("List of ADS -Hold/Cancelled");
            //float[] headerwidths2 = { 15 };
            //tbl1.setWidths(headerwidths2);
            tbl1.WidthPercentage = 100;
            //tbl1.DefaultCell.Padding = -5;
            int i;
            for (i = 0; i < 3; i++)
            {
                document.Add(tbl1);
            }
            PdfPTable tbl2 = new PdfPTable(6);

            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            tbl2.addCell(new Phrase(pub_name, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[1].ToString(), font10));
            tbl2.addCell(new Phrase(printingname, font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            tbl2.addCell(new Phrase(brname, font11));
            tbl2.WidthPercentage = 100;


            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(datefrom1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto1.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);



            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            //it's set according to 23 fields in the table---//float[] headerwidths = { 14, 15, 14, 16, 14, 16, 7, 7, 10, 18, 18, 15, 18,18, 14, 16, 16, 18, 14, 14, 12, 14, 16, 10, 10 }; // percentage
            //it's set according to 25 fields in the table---//float[] headerwidths = { 14, 15, 14, 18, 15, 16, 7, 7, 14, 18, 18, 15, 20, 20, 14, 16, 16, 18, 14, 14, 12, 14, 16, 8, 9 }; // percentage
            float[] headerwidths = { 12, 18, 18, 20, 16, 18, 12, 14, 18, 18, 17 }; // percentage
            //float[] headerwidths = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }; // percentage
            datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            //datatable.addCell(new Phrase("City"));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[56].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));

            datatable.HeaderRows = 1;
            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);


            //------------------//-------------------------------------------------------------------   


            int row = 0;
            //int count = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {


                datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;

                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Publication"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Edition"].ToString(), font11));
                // datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Area"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                {
                    //area = Convert.ToDouble(ds.Tables[0].Rows[row]["Area"].ToString("F2"));
                    datatable.addCell(new Phrase(Convert.ToDouble(ds.Tables[0].Rows[row]["Area"].ToString()).ToString("F2"), font11));
                    area = area + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                {
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Adcat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));

                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillableArea"].ToString(), font11));
                //if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                //    billarea = billarea + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());

                row++;

            }


            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[53].ToString(), font10));
            document.Add(p3);

            float[] arr = { 0.2f, 0.1f, 0.8f, 0.3f, 0.3f, 0.2f, 0.3f, 0.3f, 0.3f, 0.3f, 0.4f };

            PdfPTable tbltotal = new PdfPTable(arr);
            tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));
            tbltotal.addCell(new Phrase(area.ToString("F2"), font11));
            tbltotal.addCell(new Phrase(BillAmt.ToString("F2"), font11));

            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));

            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));

            document.Add(tbltotal);
            document.Close();

            //document.PageCount=0;
            //count = i2;
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

        Session["prm_barterbill_print"] = "destination~" + destination + "~fromdate~" + frmdt + "~dateto~" + todate + "~product~" + product + "~productname~" + productname + "~region~" + region + "~regionname~" + regionname + "~agency~" + agency + "~client~" + client + "~booktype~" + booktype + "~agencyname~" + agencyname + "~clientname~" + clientname;
        Response.Redirect("PrintBarterBill.aspx");
        //        Response.Redirect("PrintBarterBill.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + todate + "&product=" + product + "&productname=" + productname + "&region=" + region + "&regionname=" + regionname + "&agency=" + agencyname + "&client=" + clientname + "&booktype=" + booktype);

    }



}
