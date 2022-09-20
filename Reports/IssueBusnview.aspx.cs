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

using iTextSharp.text.pdf.wmf;
using System.Drawing.Printing;
using System.Diagnostics;
using System.IO;
using System.Web.UI.WebControls;





using System.Text.RegularExpressions;

using iTextSharp.text;


using iTextSharp.text.pdf;




public partial class IssueBusnview : System.Web.UI.Page
{

    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string datefrom1 = "";
    string dateto1 = "";
    string pubcode = "";
    string publication = "";
    string edition = "";
    string editioncode = "";
    string destination = "";
    string fromdt = "";
    string reg = "";
    string dateto = "";
    double Netamt=0;
    double Totalads=0;
    string adtypecode = "",adtypename = "",pubcentcode = "",pubcentname = "";
    DataSet ds;
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
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[82].ToString();

        ds = (DataSet)Session["issuebus"];
        string prm = Session["prm_issuebus"].ToString();
        string[] prm_Array = new string[21];
        prm_Array = prm.Split('~');


        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        editioncode = prm_Array[7];// Request.QueryString["edition"].Trim().ToString();
        edition = prm_Array[9];// Request.QueryString["editionname"].Trim().ToString();
        pubcode = prm_Array[11]; //Request.QueryString["publication"].ToString();
        publication = prm_Array[13];// Request.QueryString["publicationname"].ToString();
        adtypecode = prm_Array[15]; //Request.QueryString["adtypecode"].Trim().ToString();
        adtypename = prm_Array[17]; //Request.QueryString["adtypename"].Trim().ToString();
        pubcentcode = prm_Array[19]; //Request.QueryString["pubcentcode"].Trim().ToString();
        pubcentname = prm_Array[21]; //Request.QueryString["pubcentname"].Trim().ToString();
       
        Ajax.Utility.RegisterTypeForAjax(typeof(IssueBusnview));

        if (pubcode == "0")
        {
            lblpublication.Text = "";
        }
        else
        {
            lblpublication.Text = publication.ToString();

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
     
        hiddendatefrom.Value = fromdt.ToString();
        if (!IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {

                //onscreen(agency);//, fromdt, dateto, subcat, publication, prod, brand, Session["compcode"].ToString(), Session["dateformat"].ToString());
                onscreen(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            else if (destination == "4")
            {
                excel(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode);
            }
            else
                if (destination == "3")
                {
                    pdf(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode,ds);
                }
        }

       
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

    private void onscreen(string fromdt, string dateto,  string pubcode,  string editioncode,  string dateformat,string adtypecode,string pubcentcode)  //, string supplement)
    {

       // SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
       
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    // ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter, adtype, edition, supplement, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.IssueBusnonscreen(fromdt, dateto, pubcode, editioncode, dateformat, adtypecode, pubcentcode,Session["compcode"].ToString());//

        //}
           cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
           int cont = ds.Tables[0].Rows.Count;
            //  int cont1 = ds.Tables[1].Rows.Count;
            string tbl = "";
            tbl = "<table width='100%' cellpadding='5' cellspacing='0' border='0'>";
            //tbl = tbl + "<tr><td class='middle4' width='2px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='5px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
            //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

             //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
            tbl = tbl + ("<tr><td class='middle1212' width='20%'><b>ISSUE</b></td><td class='middle1212' width='20%' align='right'><b>NET AMT</b></td><td class='middle1212' width='10%' align='right'><b>TOTAL ADS</b></td></tr>");
           
          
            int i1 = 1;

            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data' width='20%'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");

                
            
                tbl = tbl + ("<td class='rep_data' align='right' width='20%'>");
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["NETAMT"].ToString()) + "</td>");
                if (ds.Tables[0].Rows[i]["NETAMT"].ToString() != "")
                    Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[i]["NETAMT"]);
                
             

                tbl = tbl + ("<td class='rep_data' align='right' width='10%'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["TotalAds"] + "</td>");
                if (ds.Tables[0].Rows[i]["TotalAds"].ToString() != "")
                    Totalads = Totalads + Convert.ToInt32(ds.Tables[0].Rows[i]["TotalAds"]);
                tblgrid.InnerHtml += tbl;
                tbl = "";
             
        }
      
        tbl = tbl + ("<tr><td class='middle1212' width='20%' ><b>Total:</b>");//</td>");
      
        tbl = tbl + ("</td>");
        tbl = tbl + ("<td class='middle1212' width='20%' align='right' >");
        double cal = System.Math.Round(Convert.ToDouble(Netamt), 2);
        tbl = tbl + (chk_null(cal.ToString()) + "</td>");
      
        tbl = tbl + ("<td class='middle1212' align='right' width='10%'>");
        tbl = tbl + (Totalads.ToString() + "</td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
       // tblgrid.InnerHtml = tbl;
        tblgrid.InnerHtml += tbl;
        
    }


    private void excel(string fromdt, string dateto,  string pubcode,  string editioncode,  string dateformat,string adtypecode,string pubcentcode)
    {





        int cont = ds.Tables[0].Rows.Count;
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
       

        
          cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
         // int cont = ds.Tables[0].Rows.Count;
            
          string tbl = "";
          tbl = "<table width='80%'align='left' cellpadding='5' cellspacing='0' border='1'>";
          //tbl = tbl + "<tr><td class='middle4' width='2px'></td><td class='middle4' width='5px'></td><td class='middle4' width='5px'></td><td class='middle4' width='5px'></td><td class='middle4' width='4px'></td><td class='middle4' width='5px'></td><td class='middle4' width='4px'></td><td class='middle4' width='4px'></td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'></td><td class='middle4' width='4px'></td><td class='middle4' width='4px'></td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'></td><td class='middle4' width='4px'></td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'></td><td class='middle4' width='4px'>-</td></tr>";
         // int cont = ds.Tables[0].Rows.Count;
          tbl = tbl + "<tr><td colspan='3' align='center'><b>"+ ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>";
          tbl = tbl + "<tr><td colspan='3' align='center'><b>Issue Wise Business Report</b></td></tr>";
          tbl = tbl + "<tr><td align='left'><b>DATE FROM:&nbsp;&nbsp;&nbsp;&nbsp;" + lblfrom.Text + "</b></td><td align='center'><b>DATE TO:&nbsp;&nbsp;&nbsp;&nbsp;" + lblto.Text + "</b></td><td align='right'><b>RUN DATE:&nbsp;&nbsp;&nbsp;&nbsp;" + date.ToString() + "</b></td></tr>";
        tbl = tbl + "<tr><td colspan='3'><b>PUBLICATION:&nbsp;&nbsp;&nbsp;&nbsp;" +lblpublication.Text + "</b></td></tr>";
        //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

         // tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td id='tdcio~1' class='middle3'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'>Agency</td><td id='tdcli~4' class='middle3'>Client</td><td id='tdpac~5' class='middle3'>Edition</td><td id='tdro~29' class='middle3'>WH</td><td id='tdro~26' class='middle3'>HT</td><td id='tdro~25' class='middle3'>Area</td><td id='tdro~24' class='middle3'>Hue</td><td id='tdag~32' class='middle3'>Premium</td><td id='tdcard~29' class='midwidth'><table><tr><td>Card</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~31' class='middle3'><table><tr><td>Agg</td></tr><tr><td>Rate</td></tr></table></td><td id='tdag~35' class='middle3'>Status</td><td id='tdag~34' class='middle3'>Instruction</td><td id='tdag~35' class='middle3'>Caption</td><td id='tdag~36' class='middle3'>Keyno</td><td id='tdag~37' class='middle3'>Pageno</td><td id='tdag~38' class='middle3'>AdCat</td></tr>");
        tbl = tbl + ("<tr><b><td class='middle31' width='20%'><b>ISSUE</b></td><td class='middle31' width='20%' align='right'><b>NET AMT</b></td><td class='middle31' width='10%' align='right'><b>TOTAL ADS</b></td></tr>");


          int i1 = 1;

          for (int i = 0; i <= cont - 1; i++)
          {
              tbl = tbl + ("<tr >");
              tbl = tbl + ("<td class='rep_data' width='20%'>");
              tbl = tbl + (ds.Tables[0].Rows[i]["Edition"] + "</td>");



              tbl = tbl + ("<td class='rep_data' align='right' width='20%'>");
              tbl = tbl + (ds.Tables[0].Rows[i]["NETAMT"] + "</td>");
              if (ds.Tables[0].Rows[i]["NETAMT"].ToString() != "")
                  Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[i]["NETAMT"]);



              tbl = tbl + ("<td class='rep_data' align='right' width='10%'>");
              tbl = tbl + (ds.Tables[0].Rows[i]["TotalAds"] + "</td>");
              if (ds.Tables[0].Rows[i]["TotalAds"].ToString() != "")
                  Totalads = Totalads + Convert.ToInt32(ds.Tables[0].Rows[i]["TotalAds"]);
             tblgrid.InnerHtml += tbl;
             tbl = "";

          }

          tbl = tbl + ("<tr><td class='middle1212' width='20%' ><b>Total:</b>");//</td>");

          tbl = tbl + ("</td>");
          tbl = tbl + ("<td class='middle1212' width='20%' align='right' ><b>");
          double cal = System.Math.Round(Convert.ToDouble(Netamt), 2);
          tbl = tbl + (cal.ToString() + "</b></td>");

          tbl = tbl + ("<td class='middle1212' align='right' width='10%'><b>");
          tbl = tbl + (Totalads.ToString() + "</b></td>");
          tbl = tbl + "</tr>";

          tbl = tbl + ("</table>");
         
          tblgrid.InnerHtml += tbl;
          System.IO.StringWriter sw = new System.IO.StringWriter();
          HtmlTextWriter hw = new HtmlTextWriter(sw);
          tblgrid.Visible = true;
          tblgrid.RenderControl(hw);
          Response.Write(sw.ToString());
          Response.Flush();
         Response.End();
          

    }
    //////////////////////////////////////////

    public void pdf(string fromdt, string dateto, string pubcode, string editioncode, string dateformat, string adtypecode, string pubcentcode, DataSet ds) 
    {

        double TotalAds = 0;
        double NETAMT = 0;
        DataSet pdfxml = new DataSet();
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
        footer.Border = 0;
        document.Footer = footer;

        //DataSet ds = new DataSet();
        Double total = 0;
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.careport obj = new NewAdbooking.Report.classesoracle.careport();
        //    ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.careport obj = new NewAdbooking.Report.Classes.careport();
        //    ds = obj.ctreport_main(Session["compcode"].ToString(), des_printcent, Branch_Code, des_adty1, des_adcat1, des_adcat2, des_adcat3, pad_subcat4, pad_subcat5, des_district, fromdate, dateto, Session["dateformat"].ToString(), puserid, pextra1, pextra2, pextra3, pextra4, pextra5, pubcode, edicode, teamcode, execcode);

        //}
        //else
        //{
        //}
        int cont = ds.Tables[0].Rows.Count;
        //-==============================end here=======================================

        document.Open();

       
        Font font1 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD);
        Font font2 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 12, Font.NORMAL);
        Font font3 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font21 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 14, Font.NORMAL);
        Font font31 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL);
        Font font4 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        try
        {
            PdfPTable tbl1 = new PdfPTable(1);
            float[] xy1 = { 50 };
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.WidthPercentage = 100;
            tbl1.setWidths(xy1);
            tbl1.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER; tbl1.addCell(new Phrase("HINDUSTAN TIMES", font1));
            tbl1.WidthPercentage = 50;
            document.Add(tbl1);


            //////////////////////////////////////////////////////////////////////////////

            PdfPTable tbl2 = new PdfPTable(1);
            float[] xy2 = { 50 };
            tbl2.setWidths(xy2);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl1.WidthPercentage = 100;
            tbl2.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase("Issue Wise Business Report".ToString(), font3));
            document.Add(tbl2);


            //////////////////////////////////////////////////////////////////////////////

            PdfPTable tbl6 = new PdfPTable(3);
            float[] abc = { 15, 20, 15 };
            tbl6.DefaultCell.BorderWidth = 0;
            tbl6.WidthPercentage = 100;
            tbl6.DefaultCell.Padding = 0;
            tbl6.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.setWidths(abc);
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl6.addCell(new Phrase("From Date:" + fromdt, font2));
            tbl6.addCell(new Phrase("To Date:" + dateto, font2));
            tbl6.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbl6.addCell(new Phrase("Run Date:" + date.ToString(), font2));
            document.Add(tbl6);


            PdfPTable tbl37 = new PdfPTable(1);
            float[] xy37 = { 20 };
            tbl37.DefaultCell.BorderWidth = 0;
            tbl37.WidthPercentage = 100;
            tbl37.DefaultCell.Padding = 0;
            tbl37.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl37.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbl37.setWidths(xy37);
            if (pubcode == "0")
            {
                lblpublication.Text = "";
            }
            else
            {
                lblpublication.Text = publication.ToString();

            }

            tbl37.addCell(new Phrase("Publication Name:" + lblpublication.Text, font2));
            document.Add(tbl37);




            PdfPTable tb89 = new PdfPTable(6);
            tb89.DefaultCell.BorderWidth = 0;
            tb89.WidthPercentage = 100;
            tb89.DefaultCell.Colspan = 6;

            tb89.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font3));
       
            document.Add(tb89);





            PdfPTable datatable111 = new PdfPTable(3);
            float[] headerwidths = { 15, 15, 15 };// percentage
            datatable111.setWidths(headerwidths);
            datatable111.WidthPercentage = 100; // percentage
            datatable111.DefaultCell.BorderWidth = 0;
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable111.addCell(new Phrase("ISSUE", font3));
            datatable111.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            datatable111.addCell(new Phrase("NET AMT", font3));
            datatable111.addCell(new Phrase("TOTAL ADS", font3));

            document.Add(datatable111);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                PdfPTable datatable = new PdfPTable(3);
                datatable.DefaultCell.BorderWidth = 0;
                float[] abhg = { 15, 15, 15 };// percentage
                datatable.setWidths(abhg);
                datatable.WidthPercentage = 100;
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                

                datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["Edition"].ToString(), font31));
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[i]["NETAMT"].ToString()), font31));
                Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[i]["NETAMT"]);
                datatable.addCell(new Phrase(ds.Tables[0].Rows[i]["TotalAds"].ToString(), font31));
                Totalads = Totalads + Convert.ToInt32(ds.Tables[0].Rows[i]["TotalAds"]);



                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    datatable.DefaultCell.Colspan = 3;
                    datatable.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font3));

                    datatable.DefaultCell.Colspan = 1;
                    datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    datatable.addCell(new iTextSharp.text.Phrase("Total:", font3));
                    //datatable.DefaultCell.Colspan = 1;

                    datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    datatable.addCell(new iTextSharp.text.Phrase(chk_null(Netamt.ToString("F2")), font3));
                    datatable.addCell(new iTextSharp.text.Phrase(Totalads.ToString(), font3));
                    datatable.DefaultCell.Colspan = 3;
                    datatable.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font3));
                    datatable.DefaultCell.Colspan = 1;

                }
                

                document.Add(datatable);

            }




            document.Close();
            Response.Redirect(pdfName);
        }
         catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }




    



















    protected void btnprint_Click(object sender, EventArgs e)
    {

        Session["prm_issuebus_print"] = "destination~" + destination + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + pubcode + "~publicationname~" + publication + "~edition~" + editioncode + "~editionname~" + edition + "~adtypecode~" + adtypecode + "~adtypename~" + adtypename + "~pubcentcode~" + pubcentcode + "~pubcentname~" + pubcentname;
        Response.Redirect("PrintIssueBsns.aspx");
        //Response.Redirect("PrintIssueBsns.aspx?destination=" + destination + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + pubcode + "&publicationname=" + publication + "&edition=" + editioncode + "&editionname=" + edition + "&adtypecode=" + adtypecode + "&adtypename=" + adtypename + "&pubcentcode=" + pubcentcode + "&pubcentname=" + pubcentname);

    }
}
