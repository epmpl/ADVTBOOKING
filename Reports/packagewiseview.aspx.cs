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
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;

public partial class packagewiseview : System.Web.UI.Page
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
    string agencyname1 = "";
    double BillAmt = 0, area = 0;
    int sno = 1;
    string  packagecode = "",packagename = "", adtypecode = "",adtypename = "";
    string pubcode = "", pubname = "", pubcentcode = "", pubcentname = "", editioncode = "", editionname = "";
    double Netamt = 0;
    double Grossamt = 0;
    double ActualBuss = 0, agencyadddisc = 0, agencydisc = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {

        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));

        heading.Text = ds1.Tables[0].Rows[0].ItemArray[92].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

        
        frmdt = Request.QueryString["fromdate"].ToString();
        todate = Request.QueryString["dateto"].ToString();
        destination = Request.QueryString["destination"].ToString();
        agencyname = Request.QueryString["agency"].ToString();
        clientname = Request.QueryString["client"].ToString();
        agencyname1 = Request.QueryString["agencyname"].ToString();
        clientname1 = Request.QueryString["clientname"].ToString();

        packagecode = Request.QueryString["packagecode"].ToString();
        packagename = Request.QueryString["packagename"].ToString();
           adtypecode = Request.QueryString["adtypecode"].ToString();
        adtypename = Request.QueryString["adtypename"].ToString();
           pubcode = Request.QueryString["pubcode"].ToString();
        pubname = Request.QueryString["pubname"].ToString();
           pubcentcode = Request.QueryString["pubcentcode"].ToString();
        pubcentname = Request.QueryString["pubcentname"].ToString();
           editioncode = Request.QueryString["editioncode"].ToString();
        editionname = Request.QueryString["editionname"].ToString();
        hiddendatefrom.Value = fromdt.ToString();

        if (editioncode == "0")
        {
            lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname.ToString();
        }


        if (pubcentcode == "0")
        {
            lblpubcent.Text = "ALL".ToString();
        }
        else
        {
            lblpubcent.Text = pubcentname.ToString();
        }


        if (pubcode == "0")
        {
            lblpublication.Text = "ALL".ToString();
        }
        else
        {
            lblpublication.Text = pubname.ToString();
        }


        if (packagecode == "0")
        {
            lbpackage.Text = "ALL".ToString();
        }
        else
        {
            lbpackage.Text = packagename.ToString();
        }

        if (clientname == "0")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname1.ToString();
        }

        if (agencyname == "0")
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

            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{

            //    string[] arr = fromdt.Split('/');
            //    string dd = arr[0];
            //    string mm = arr[1];
            //    string yy = arr[2];
            //    datefrom1 = mm + "/" + dd + "/" + yy;

            //}
            //else
            //{
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
            // }
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



        if (destination == "1" || destination == "0")
            onscreen(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);
       else if (destination == "4")
            excel(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);
        else if (destination == "3")
            pdf(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);


    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("packagewiseprint.aspx?destination=" + destination + "&fromdate=" + frmdt + "&dateto=" + todate + "&agencyname=" + agencyname1 + "&clientname=" + clientname1 + "&packagecode=" + packagecode + "&packagename=" + packagename + "&agency=" + agencyname + "&client=" + clientname  + "&adtypecode=" + adtypecode + "&adtypename=" + adtypename + "&pubcode=" + pubcode   + "&pubname=" + pubname + "&pubcentcode=" + pubcentcode + "&pubcentname=" + pubcentname  + "&editioncode=" + editioncode + "&editionname=" + editionname);

    }
    private void onscreen(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string packagecode,string adtypecode,string pubcode,string pubcentcode,string editioncode)
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.packagewise(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode,adtypecode,pubcode,pubcentcode,editioncode);
                                
        }
       
        int cont = ds.Tables[0].Rows.Count;
        if(cont>0)
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        string tbl = "";
        tbl = "<table width='90%'align='left' cellpadding='0' cellspacing='0'>";
        tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td class='middle31new' width='15%'>Package</td><td class='middle31new' width='15%' align='right'>GrossAmt</td><td class='middle31new' width='15%' align='right'>Agency</br>TD(%)</td><td class='middle31new' width='15%' align='right'>Agency</br>TD(Amt)</td><td class='middle31new' width='15%'  align='right'>Agency Addl</br>TD(%)</td><td class='middle31new' width='15%'  align='right'>Agency Addl</br>TD(Amt)</td><td class='middle31new' width='15%' align='right'>NETAMT</td><td class='middle31new' width='15%' align='right'>Retainer</br>Commission(%)</td><td class='middle31new' width='15%' align='right'>Retainer</br>Commission(Amt)</td><td class='middle31new' width='10%' align='right'>ActualBuss</td></tr>");
           
          
             
          
          

        int i1 = 1;


        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data' width='15%' >");
            tbl = tbl + (ds.Tables[0].Rows[i]["Package"] + "</td>");

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["GrossAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["GrossAmt"].ToString() != "")
                Grossamt = Grossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["GrossAmt"]);

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Trade_disc"] + "</td>");

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency_DisVal"] + "</td>");
            if (ds.Tables[0].Rows[i]["Agency_DisVal"].ToString() != "")
                agencydisc = agencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["Agency_DisVal"]);

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTD(%)"] + "</td>");

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgencyAddlTDAmt"] + "</td>");
            if (ds.Tables[0].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[0].Rows[i]["AgencyAddlTDAmt"]);


            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["NETAMT"] + "</td>");
            if (ds.Tables[0].Rows[i]["NETAMT"].ToString() != "")
                Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[i]["NETAMT"]);

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RetComm(%)"] + "</td>");

            tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RetCommAmt"] + "</td>");

            tbl = tbl + ("<td class='rep_data' width='10%' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["ActualBuss"] + "</td>");
            if (ds.Tables[0].Rows[i]["ActualBuss"].ToString() != "")
                ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[0].Rows[i]["ActualBuss"]);
            tbl = tbl + "</tr>";

        }

        tbl = tbl + ("<tr ><td colspan='0'>&nbsp;</td></tr>");
        tbl = tbl + ("<tr><td class='middle1212' align='left' colspan='2'><b>Total:</b></td><td id='tdcio~1' width='15%'  class='middle1212' align='right'>" + Grossamt.ToString() + "</td><td width='15%'   class='middle1212'>&nbsp;</td><td width='15%'   class='middle1212' align='right'>" + agencydisc + "</td><td  width='15%'  class='middle1212'>&nbsp;</td><td  width='15%'  class='middle1212' align='right'>" + agencyadddisc + "</td><td class='middle1212' align='right' width='15%' >" + Netamt.ToString() + "</td><td  class='middle1212' width='15%' >&nbsp;</td><td width='15%'  class='middle1212' align='right'>&nbsp;</td><td class='middle1212' align='right' width='10%' >" + ActualBuss.ToString() + "</td></tr>");
        tbl = tbl + ("<table>");
        tblgrid.InnerHtml = tbl;

    }
    private void excel(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string packagecode, string adtypecode, string pubcode, string pubcentcode, string editioncode)
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            // ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.packagewise(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);
        }

        int cont = ds.Tables[0].Rows.Count;

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";

        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        DataGrid1.DataSource = ds;

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        DataGrid1.ShowHeader = true;
        DataGrid1.ShowFooter = true;
        DataGrid1.DataBind();

        hw.Write("<p align=\"left\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b>");
        hw.Write("<p align=\"left\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Package Wise Report<b>");

        hw.WriteBreak();
        DataGrid1.RenderControl(hw);
        //double arr = comm2 / areanew;
        int sno11 = sno - 1;

        Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='2' align='left'><b>Total:</b><td  align='right'>" + Grossamt.ToString() + "</td><td  align='right'></td><td  align='right'>" + agencydisc + "</td><td  align='right'></td><td  align='right'>" + agencyadddisc + "</td><td  align='right'>" + Netamt.ToString() + "</td><td  align='right'></td><td  align='right'></td><td  align='right'>" + ActualBuss.ToString() + "</td></table>")); 
                                                                                                                                                                                                                                                                                                                                                     
       
        Response.Flush();
        Response.End();


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

        string check1 = e.Item.Cells[2].Text;

        if (check1 != "GrossAmt")
        {
            if (check1 != "&nbsp;")
            {
                string grsam = e.Item.Cells[2].Text;
                Grossamt = Grossamt + Convert.ToDouble(grsam);
            }
        }
        string check2 = e.Item.Cells[4].Text;

        if (check2 != "Agency TD(Amt)")
        {
            if (check2 != "&nbsp;")
            {
                string agentdamt = e.Item.Cells[4].Text;
                agencydisc = agencydisc + Convert.ToDouble(agentdamt);
            }
        }

        string check3 = e.Item.Cells[6].Text;

        if (check3 != "AgencyAddl TD(Amt)")
        {
            if (check3 != "&nbsp;")
            {
                string agenaddltdamt = e.Item.Cells[6].Text;
                agencyadddisc = agencyadddisc + Convert.ToDouble(agenaddltdamt);
            }
        }

        string check4 = e.Item.Cells[7].Text;

        if (check4 != "NETAMT")
        {
            if (check4 != "&nbsp;")
            {
                string amtne = e.Item.Cells[7].Text;
                Netamt = Netamt + Convert.ToDouble(amtne);
            }
        }

        string check5 = e.Item.Cells[10].Text;

        if (check5 != "Actual Bussiness")
        {
            if (check5 != "&nbsp;")
            {
                string actbs = e.Item.Cells[10].Text;
                ActualBuss = ActualBuss + Convert.ToDouble(actbs);
            }
        }
    }
    private void pdf(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string packagecode, string adtypecode, string pubcode, string pubcentcode, string editioncode)
    {
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;

        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;

        //--------------------for page numbering---------------------------------------------

        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
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
            DataSet ds = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
                //  ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), region, product, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else
            {
                NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
                ds = obj.packagewise(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);
            }
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

            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[92].ToString(), font9));
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

            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            //tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[0].ToString(), font9));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[83].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[91].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[92].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[93].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[94].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[3].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[95].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[96].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[97].ToString(), font10));

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
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["GrossAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["GrossAmt"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[0].Rows[row]["GrossAmt"]);
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Trade_disc"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency_DisVal"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["Agency_DisVal"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[0].Rows[row]["Agency_DisVal"]);

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgencyAddlTD(%)"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgencyAddlTDAmt"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["AgencyAddlTDAmt"].ToString() != "")
                    agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[0].Rows[row]["AgencyAddlTDAmt"]);

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["NETAMT"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["NETAMT"].ToString() != "")
                    Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[row]["NETAMT"]);

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetComm(%)"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RetCommAmt"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["ActualBuss"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["ActualBuss"].ToString() != "")
                    ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[0].Rows[row]["ActualBuss"]);
          
                row++;

            }





            document.Add(datatable);
            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[38].ToString(), font10));
            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(11);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase(" ", font10));
            tbltotal.addCell(new Phrase("Gross:", font10));
            tbltotal.addCell(new Phrase(Grossamt.ToString(), font11));
            tbltotal.addCell(new Phrase("AgencyTD:", font10));
            tbltotal.addCell(new Phrase(agencydisc.ToString(), font11));
            tbltotal.addCell(new Phrase("AgencyAddlTD:", font10));
            tbltotal.addCell(new Phrase(agencyadddisc.ToString(), font11));
            tbltotal.addCell(new Phrase("Net:", font10));

            tbltotal.addCell(new Phrase(Netamt.ToString(), font11));
            

            tbltotal.addCell(new Phrase("ActBus:", font10));
            tbltotal.addCell(new Phrase(ActualBuss.ToString(), font11));
           
            document.Add(tbltotal);
            document.Close();


            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
}
