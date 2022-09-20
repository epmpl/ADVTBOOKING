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

public partial class Reports_ReceiptRegister_View : System.Web.UI.Page
{
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
    string agencyname1 = "", adtypecode = "", adtypename = "";
    double BillAmt = 0, area = 0;
    int sno = 1;
    int x = 0;
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    string companyname = "";
    string reportname = "";

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

        //heading.Text = ds1.Tables[0].Rows[0].ItemArray[90].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        ds = (DataSet)Session["moneyrep"];
        string prm = Session["prm_moneyrep"].ToString();
        string[] prm_Array = new string[24];
        prm_Array = prm.Split('~');



        frmdt = prm_Array[1];
        todate = prm_Array[3];
        destination = prm_Array[5];
        agencyname = prm_Array[7];
        agencyname1 = prm_Array[9];
        clientname = prm_Array[11];
        clientname1 = prm_Array[13];
        paymode = prm_Array[15];
        paymodename = prm_Array[17];
        adtypecode = prm_Array[19];
        adtypename = prm_Array[21];
        chk_excel = prm_Array[23];
        hiddendatefrom.Value = fromdt.ToString();

        if (paymode == "0")
        {
            paymodename = "ALL";
        }
       
        if (clientname == "0" || clientname == "")
        {
            clientname1 = "ALL";
        }
       
        if (agencyname == "0" || agencyname == "")
        {
            agencyname1 = "ALL";
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

        if (!Page.IsPostBack)
        {

            if (destination == "1" || destination == "0" || destination == "3")
                onscreen();
            else //if (destination == "4")
                excel();
            //else if (destination == "3")
            //    pdf(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), paymode, adtypecode);
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
    private string header()
    {
        string hdrtbl = "";
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px' style='vertical-align:top;'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + reportname + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date :</b>" + datefrom1 + "</td><td colspan='2' style='text-align:left'><b>ToDate :</b>" + dateto1 + "</td><td colspan='2' style='text-align:right'><b>Run Date :</b>" + date + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>AGENCY :</b>" + agencyname1 + "</td><td colspan='2' style='text-align:left'><b>CLIENT :</b>" + clientname1 + "</td><td colspan='2' style='text-align:right'><b>PAYMODE :</b>" + paymodename + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Ad Category :</b>" + adcat_nam + "</td><td colspan='2' style='text-align:left'><b>Edition :</b>" + edition_nam + "</td><td colspan='2' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    private void onscreen()
    {

        companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
//==========================********** To Fill Header From Header **********************=======================//
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/ReceiptRegister.xml"));

        string tbl = "";
        double tbill = 0;
        int maxlimit =Convert.ToInt32(dsxml.Tables[1].Rows[0].ItemArray[1].ToString());
        int x1=1;
        reportname = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
        tbl = tbl + "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
        tbl = tbl + "<tr><td>";
        tbl = tbl + header();
        tbl = tbl + "<table width='100%'align='left' cellpadding='1' cellspacing='0' style='vertical-align:top;'>";

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString()+ "</td>");
        tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
        tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
        tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
        tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
        tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
        tbl = tbl + ("</tr>");

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString()+"</b>");
        tbl = tbl + (ds.Tables[0].Rows[0]["USERNAME"].ToString() + "</td>");
        tbl = tbl + ("</tr>");

        for (int i = 0; i <= cont - 1; i++)
        {
            x1++;
            if ((i > 0) && (ds.Tables[0].Rows[i]["USERNAME"].ToString() != ds.Tables[0].Rows[i - 1]["USERNAME"].ToString()))
            {
                x1++;
                //tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
                //tbl = tbl + ("<td class='middle31new'  align='left'>");
                //tbl = tbl + (sno.ToString() + "</td>");
                tbl = tbl + ("<td  colspan='5'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new'>Total</td>");
                tbl = tbl + ("<td class='middle31new' align='right'>");
                tbl = tbl + (tbill.ToString("F2") + "</td>");
                tbl = tbl + "</tr>";

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</b>");
                tbl = tbl + (ds.Tables[0].Rows[i]["USERNAME"].ToString() + "</td>");
                tbl = tbl + ("</tr>");
                tbill = 0;
                sno = 1;
            }
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (sno++.ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ReceiptNo"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left' >");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left' >");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Branch"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");

            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbill = tbill + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());
            tbl = tbl + "</tr>";

            if (x1 > maxlimit)
            {
                x1 = 1;

                tbl = tbl + "</table></td><tr></table></p>";
                tbl = tbl + "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
                tbl = tbl + "<tr><td>";
                tbl = tbl + header();

                tbl = tbl + "<table width='100%'align='left' cellpadding='1' cellspacing='0' style='vertical-align:top;'>";

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>");
                tbl = tbl + ("<td class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                tbl = tbl + ("</tr>");

            }
            
        }

        //tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
        //tbl = tbl + ("<td class='middle31new'  align='left'>");
        //tbl = tbl + (sno.ToString() + "</td>");
        tbl = tbl + ("<td colspan='5'>&nbsp;</td>");
        tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;border-top:solid;border-top-color:Black;border-top-width:thin;'><b>Total</b></td>");
        tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;border-top:solid;border-top-color:Black;border-top-width:thin;' align='right'><b>");
        tbl = tbl + (tbill.ToString("F2") + "</b></td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
        tbl = tbl + ("<td class='middle31new'  align='left'>");
        tbl = tbl + ((cont - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle31new'  colspan='3'>&nbsp;</td>");
        tbl = tbl + ("<td class='middle31new'>Grand Total</td>");
        tbl = tbl + ("<td class='middle31new' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", BillAmt) + "</td>");
        tbl = tbl + "</table></td><tr></table></p>";
        report.InnerHtml = tbl;

    }
   /* private void pdf(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string paymode, string adtypecode)
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






        //---------------------------end-------------------------------------------------------

        int NumColumns = 12;
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
            tbl2.addCell(new Phrase(datefrom1.ToString(), font10));
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
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase("Branch", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[21].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[22].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[1].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[100].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));

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

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Branch"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CardRate"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillableArea"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["BillableArea"].ToString() != "")
                    area = area + float.Parse(ds.Tables[0].Rows[row]["BillableArea"].ToString());
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["TradeDisc%"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillAmt"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() != "")
                    BillAmt = BillAmt + double.Parse(ds.Tables[0].Rows[row]["BillAmt"].ToString());


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


    }*/
    private string header_excel()
    {
        string hdrtbl = "";
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px' style='vertical-align:top;'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;font-size:15px;font-family:Verdana;'><b>" + companyname + "</b></td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;font-size:10px;font-family:Verdana;'><b>" + reportname + "</b></td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left;font-size:9px;font-family:Verdana;'><b>From Date :</b>" + datefrom1 + "</td><td colspan='2' style='text-align:left;font-size:9px;font-family:Verdana;'><b>ToDate :</b>" + dateto1 + "</td><td colspan='2' style='text-align:right;font-size:9px;font-family:Verdana;'><b>Run Date :</b>" + date + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left;font-size:9px;font-family:Verdana;'><b>AGENCY :</b>" + agencyname1 + "</td><td colspan='2' style='text-align:left;font-size:9px;font-family:Verdana;'><b>CLIENT :</b>" + clientname1 + "</td><td colspan='2' style='text-align:right;font-size:9px;font-family:Verdana;'><b>PAYMODE :</b>" + paymodename + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Ad Category :</b>" + adcat_nam + "</td><td colspan='2' style='text-align:left'><b>Edition :</b>" + edition_nam + "</td><td colspan='2' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    private void excel()
    {
        companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

//==========================********** To Fill Header From Header **********************=======================//
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/ReceiptRegister.xml"));

        string tbl = "";
        double tbill = 0;
        int maxlimit =Convert.ToInt32(dsxml.Tables[1].Rows[0].ItemArray[1].ToString());
        int x1=1;
        reportname = dsxml.Tables[1].Rows[0].ItemArray[0].ToString();
        tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
        tbl = tbl + "<tr><td>";
        tbl = tbl + header_excel();
        tbl = tbl + "<table width='100%'align='left' cellpadding='1' cellspacing='0' style='vertical-align:top;'>";

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td></b>");
        tbl = tbl + ("<td class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td></b>");
        tbl = tbl + ("<td class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td></b>");
        tbl = tbl + ("<td class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td></b>");
        tbl = tbl + ("<td class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td></b>");
        tbl = tbl + ("<td class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td></b>");
        tbl = tbl + ("<td class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
        tbl = tbl + ("</tr>");

        tbl = tbl + ("<tr>");
        tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString()+"</b>");
        tbl = tbl + (ds.Tables[0].Rows[0]["USERNAME"].ToString() + "</td>");
        tbl = tbl + ("</tr>");

        for (int i = 0; i <= cont - 1; i++)
        {
            x1++;
            if ((i > 0) && (ds.Tables[0].Rows[i]["USERNAME"].ToString() != ds.Tables[0].Rows[i - 1]["USERNAME"].ToString()))
            {
                x1++;
                //tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
                //tbl = tbl + ("<td class='middle31new'  align='left'>");
                //tbl = tbl + (sno.ToString() + "</td>");
                tbl = tbl + ("<td  colspan='5'>&nbsp;</td>");
                tbl = tbl + ("<td class='middle31new'><b>Total</td></b>");
                tbl = tbl + ("<td class='middle31new' align='right'><b>");
                tbl = tbl + (tbill.ToString("F2") + "</td></b>");
                tbl = tbl + "</tr>";

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</b>");
                tbl = tbl + (ds.Tables[0].Rows[i]["USERNAME"].ToString() + "</td>");
                tbl = tbl + ("</tr>");
                tbill = 0;
                sno = 1;
            }
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (sno++.ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["CIOID"].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ReceiptNo"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left' >");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left' >");
            tbl = tbl + (ds.Tables[0].Rows[i]["Client"].ToString() + "</td>");

            tbl = tbl + ("<td class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Branch"] + "</td>");

            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");

            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() != "")
                BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());

            tbill = tbill + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"].ToString());
            tbl = tbl + "</tr>";

           
        }

        //tbl = tbl + ("<tr><td class='middle31new'>TotalAds.</td>");
        //tbl = tbl + ("<td class='middle31new'  align='left'>");
        //tbl = tbl + (sno.ToString() + "</td>");
        tbl = tbl + ("<td colspan='5'>&nbsp;</td>");
        tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;border-top:solid;border-top-color:Black;border-top-width:thin;'><b>Total</b></td>");
        tbl = tbl + ("<td style='font-size:9px;vertical-align:top;font-family:Verdana;border-top:solid;border-top-color:Black;border-top-width:thin;' align='right'><b>");
        tbl = tbl + (tbill.ToString("F2") + "</b></td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("<tr><td class='middle31new'><b>TotalAds.</b></td>");
        tbl = tbl + ("<td class='middle31new'  align='left'><b>");
        tbl = tbl + ((cont - 1).ToString() + "</b></td>");
        tbl = tbl + ("<td class='middle31new'  colspan='3'>&nbsp;</td>");
        tbl = tbl + ("<td class='middle31new'><b>Grand Total</b></td>");
        tbl = tbl + ("<td class='middle31new' align='right'><b>");
        tbl = tbl + (string.Format("{0:0.00}", BillAmt) + "</b></td>");
        tbl = tbl + "</table></td><tr></table>";
        
        report.InnerHtml = tbl;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteBreak();
        report.RenderControl(hw);
        Response.Write(sw.ToString());
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

        Session["prm_moneyrep_print"] = "destination~" + destination + "~fromdate~" + frmdt + "~dateto~" + todate + "~agencyname~" + agencyname1 + "~clientname~" + clientname1 + "~paymode~" + paymode + "~paymodename~" + paymodename + "~agency~" + agencyname + "~client~" + clientname + "~adtypename~" + adtypename + "~adtypecode~" + adtypecode;
        Response.Redirect("moneyrecievedprint.aspx");
        // Response.Redirect("moneyrecievedprint.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + todate + "&agencyname=" + agencyname1 + "&clientname=" + clientname1 + "&paymode=" + paymode + "&paymodename=" + paymodename + "&agency=" + agencyname + "&client=" + clientname + "&adtypename=" + adtypename + "&adtypecode=" + adtypecode);

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

        string check1 = e.Item.Cells[9].Text;

        if (check1 != "BillableArea")
        {
            if (check1 != "&nbsp;")
            {
                string arean = e.Item.Cells[9].Text;
                area = area + Convert.ToDouble(arean);
            }
        }
        string check2 = e.Item.Cells[11].Text;

        if (check2 != "BillAmt")
        {
            if (check2 != "&nbsp;")
            {
                string arean = e.Item.Cells[11].Text;
                BillAmt = BillAmt + Convert.ToDouble(arean);
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printrow.Attributes.Add("style", "display:none");
        bdy.Attributes.Add("onload", "window.print()");
    }
}
