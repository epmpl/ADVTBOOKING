using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;
using iTextSharp.text;

public partial class autoreport : System.Web.UI.Page
{
    string center="";
        string userid="" ;
        string branch=""  ;
        string compcode=""  ;
        string agencycode=""  ;
        string client=""  ;
        string executive=""  ;
        string dateformat=""  ;
        int rowcounter = 0;
        int maxlimit = 10;
        string fdate=""  ;
        string todate="";
        string branchname = "Branch";
        string Apvdate = "Approval Date";
        string sno = "S.No";
        string Bookid = "Booking ID";
        string agency = "Agency";
        string city = "City";
        string clientname = "Client";
        string executivename = "Executive";
        string AdCat = "Ad Cat";
        string PagePremium = "Page Premium";
        string Deviation = "Deviation";
        string NetAmount = "NetAmount";
        string team="Team";
        string apby = "Approved By";
        string destination = "";
        string aproovaldate = "Approval Date";
    string day = "", month = "", year = "", date = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        center = Request.QueryString["center"].ToString();
         userid = Request.QueryString["userid"].ToString();
         branch = Request.QueryString["branch"].ToString();
         compcode = Request.QueryString["compcode"].ToString();
         agencycode = Request.QueryString["agencycode"].ToString();
         client = Request.QueryString["client"].ToString();
         executive = Request.QueryString["executive"].ToString();
         dateformat = Request.QueryString["dateformat"].ToString();
         fdate = Request.QueryString["fdate"].ToString();
         todate = Request.QueryString["todate"].ToString();
         destination = Request.QueryString["destination"].ToString();
         if (!Page.IsPostBack)
         {
             if (dateformat == "dd/mm/yyyy".ToString())
             {

                 DateTime dt = System.DateTime.Now;


                 day = dt.Day.ToString();
                 month = dt.Month.ToString();
                 year = dt.Year.ToString();
                 date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;


             }
             else
                 if (dateformat == "mm/dd/yyyy".ToString())
                 {

                     DateTime dt = System.DateTime.Now;


                     day = dt.Day.ToString();
                     month = dt.Month.ToString();
                     year = dt.Year.ToString();
                     date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;


                 }
                 else
                     if (dateformat == "yyyy/mm/dd".ToString())
                     {

                         DateTime dt = System.DateTime.Now;


                         day = dt.Day.ToString();
                         month = dt.Month.ToString();
                         year = dt.Year.ToString();

                         date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);


                     } 




             if (destination == "0")
             {
                 excel();
             }
             else if (destination == "1")
             {
                 pdf();
             }
             else
             {
                 return;
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

    public void excel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AuthorizationRelease binddataforrepo = new NewAdbooking.Classes.AuthorizationRelease();
            ds = binddataforrepo.bindrep(center, userid, branch, compcode, agencycode, client, executive, dateformat, fdate, todate);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AuthorizationRelease binddataforrepo = new NewAdbooking.classesoracle.AuthorizationRelease();
            ds = binddataforrepo.bindrep(center, userid, branch, compcode, agencycode, client, executive, dateformat, fdate, todate);
        }

 
        


        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            int sno1 = 0;
            string tbl = "";
          
            tbl = "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='12' align='left'>Branch:" + ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString() + "</td></tr>";
            tbl += "<tr class='headingc'><td colspan='12' align='left'>Team:" + ds.Tables[0].Rows[0]["TEAM_NAME"].ToString() + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='12' align='left'>Run Date:" + date + "</td></tr>";
            //tbl += "<tr class='middle33'><td colspan='2' align='center'>ToDate:" + todate + "</td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new'>" + sno + "</td><td class='middle31new'>" + Bookid + "</td><td  class='middle31new'>" + agency + "</td><td  class='middle31new'>" + city + "</td><td  class='middle31new'>" + clientname + "</td><td  class='middle31new'>" + executivename + "</td><td  class='middle31new'>" + AdCat + "</td><td  class='middle31new'>" + PagePremium + "</td><td  class='middle31new'>" + Deviation + "</td><td  class='middle31new'>" + NetAmount + "</td><td  class='middle31new'>" + apby + "</td><td  class='middle31new'>" + aproovaldate + "</td></tr>";

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data'  width='8%'style=padding-left:'1px'>";
                tbl += ds.Tables[0].Rows[p]["CIO_BOOKING_ID"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='3%'style=padding-left:'1px'>";
                tbl += ds.Tables[0].Rows[p]["AGENCY"].ToString() + "</td>";

                tbl += "<td class='rep_data'  width='8%'>";
                tbl += ds.Tables[0].Rows[p]["CITY_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["EXECUTIVE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["AD_CAT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["PAGEPERM"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["DEVIATION"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["BILL_AMOUNT"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["APPROVAL_BY"].ToString() + "</td>";

 
                tbl += "<td class='rep_data' width='8%' aling='center'>";
                tbl += ds.Tables[0].Rows[p]["APP_DATE"].ToString() + "</td>";


                rowcounter++;

            }

            tbl += "</table></p>";

            report.InnerHtml = tbl;
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            report.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();


        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }
    }
    public void pdf()
    {
        string pdfName = "";
        int r;
        int y;

        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;

        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        document.Footer = footer;
        document.Open();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AuthorizationRelease binddataforrepo = new NewAdbooking.Classes.AuthorizationRelease();
            ds = binddataforrepo.bindrep(center, userid, branch, compcode, agencycode, client, executive, dateformat, fdate, todate);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AuthorizationRelease binddataforrepo = new NewAdbooking.classesoracle.AuthorizationRelease();
            ds = binddataforrepo.bindrep(center, userid, branch, compcode, agencycode, client, executive, dateformat, fdate, todate);
        }
      
        if (ds.Tables[0].Rows.Count > 0)
        {
         




            int sno1 = 0;
            string companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
            iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);
            iTextSharp.text.Font font7 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);


            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.WidthPercentage = 100;
            tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl.addCell(new iTextSharp.text.Phrase(companyname, font9));
            tbl.addCell(new iTextSharp.text.Phrase("Approval Report", font9));
            document.Add(tbl);

            PdfPTable tbl2 = new PdfPTable(3);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl2.WidthPercentage = 100;
            tbl2.addCell(new iTextSharp.text.Phrase("Branch:" + ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString(), font10));
            //tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl2.addCell(new iTextSharp.text.Phrase("Team: " + ds.Tables[0].Rows[0]["TEAM_NAME"].ToString(), font10));
            tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;

            tbl2.addCell(new iTextSharp.text.Phrase("Run Date: " + date, font10));

            document.Add(tbl2);

          


            PdfPTable tbl3 = new PdfPTable(12);
            tbl3.DefaultCell.BorderWidth = 1;
            tbl3.WidthPercentage = 100;
            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl3.addCell(new iTextSharp.text.Phrase("SNo", font10));
            //tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl3.addCell(new iTextSharp.text.Phrase("Booking ID", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Agency", font10));
            //tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl3.addCell(new iTextSharp.text.Phrase("City", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Client", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Executive", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Ad Cat", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Page Premium", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Deviation", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("NetAmount", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Approved By", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Approved Date", font10));
            document.Add(tbl3);

            PdfPTable tbl4 = new PdfPTable(12);
            tbl4.DefaultCell.BorderWidth = 1;
            tbl4.WidthPercentage = 100;

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                sno1++;
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase(sno1.ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["CIO_BOOKING_ID"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["AGENCY"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["CITY_NAME"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["CLIENT"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["EXECUTIVE"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["AD_CAT_NAME"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["PAGEPERM"].ToString(), font8));
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["DEVIATION"].ToString(), font8));
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["BILL_AMOUNT"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["APPROVAL_BY"].ToString(), font8));
         

               tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["APP_DATE"].ToString(), font8));
            }
            document.Add(tbl4);

            document.Close();
            Response.Redirect(pdfName);

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }
}
