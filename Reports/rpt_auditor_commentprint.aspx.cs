using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
//using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics;
using iTextSharp.text;
//using iTextSharp.text.pdf.wmf;
using System.Web.UI.WebControls;
using System.Drawing;
public partial class Reports_rpt_auditor_commentprint : System.Web.UI.Page
{
    string compcode = "";
    string fromdate = "";
    string todate = "";
    string view = "";
    string rundate = "";
    string rdate = "";
    string dateformat = "";
    string rdatefinalhdsmain = "";
    string reportname = "";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 20;
    int pgn = 0;
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string companyname = "";
    string SNo = "";
    string ClientName = "";
    string AgencyName = "";
    //string center = "";
    string userid = "";
    string center = "";
    string centername = "";
    string branchcode = "";
    string branchName = "";
    string adtype = "";
    string adtypename = "";
    string flag = "";
    string AUDIT_COMMENT = "";
    string ro_no = "";
    string rodate = "";
    string cardrate = "";
    string packaje = "";
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script> window.parent.location=\" login.aspx\";</script>)");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        userid = hiddenuserid.Value;
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();
        fromdate = Request.QueryString["fromdate"].ToString();
        todate = Request.QueryString["todate"].ToString();
        center = Request.QueryString["center"].ToString();
        branchcode = Request.QueryString["branch"].ToString();
         adtype = Request.QueryString["adtype"].ToString();
          flag = Request.QueryString["bookingtype"].ToString();
      
        view = Request.QueryString["view"].ToString();
        if (Request.QueryString["branch_name"].ToString() == "-- Select Branch --" || Request.QueryString["branch_name"].ToString() == "" || Request.QueryString["branch_name"].ToString() == "0")
        {
            branchName = "All";
        }
        else
        {
            branchName = Request.QueryString["branch_name"].ToString();
        }
        if (Request.QueryString["center_name"].ToString() == "-Select Center-" || Request.QueryString["center_name"].ToString() == "" || Request.QueryString["center_name"].ToString() == "0")
        {
            centername = "All";
        }
        else
        {
            centername = Request.QueryString["center_name"].ToString();
        }
        if (Request.QueryString["adtype_name"].ToString() == "-Select Ad Type-" || Request.QueryString["adtype_name"].ToString() == "" || Request.QueryString["adtype_name"].ToString() == "0")
        {
            adtypename = "All";
        }
        else
        {
            adtypename = Request.QueryString["adtype_name"].ToString();
        }




        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        rdate = tim[0];
        string[] rdatehdsmaintds = rdate.Split(' ');
        string hdsmainhjrdate = rdatehdsmaintds[0];
        string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
        string hdsmainhjrdate1 = hdsmainhjrdateS[0];
        string hdsmainhjrdate2 = hdsmainhjrdateS[1];
        string hdsmainhjrdate3 = hdsmainhjrdateS[2];
        rdatefinalhdsmain = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;

        reportname = "Auditor Comment Report";
        SNo = "Sno";
        AgencyName = "Agency Name";
        ClientName = "Client Name";
        AUDIT_COMMENT = "AUDITCOMMENT";
        ro_no = "Ro NO";
        rodate = "Ro Date";
        packaje = "PACKAGE NAME";
        cardrate = "CARD RATE";
        if (!Page.IsPostBack)
        {
            
            if (view == "ons")
            {
                gridbind();
            }
            else if (view == "exc")
            {
                gridbind_excel();
            }

            else
            {
                showreportpdf();

            }
            btnPrint.Attributes.Add("onclick", "javascript:return printreport();");

        }
      
    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.auditor_comment(compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = unregistclient.auditor_comment(compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5);
  
        }
        else
        {
            string procedureName = "rpt_auditor_comment";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int pgn = 1;
        page_count = ds.Tables[0].Rows.Count / maxlimit;
        int rem = ds.Tables[0].Rows.Count % maxlimit;
        if (rem > 0)
        {
            page_count = page_count + 2;
        }
        else
        {
            page_count = page_count + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (pgn > page_count)
            {
                page_count = page_count + (pgn - page_count);
            }
       
            int sno1 = 0;
            string tbl = "";
            companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
          
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr width='100%' ><td colspan='8' style='verticle-align:top;' align='right' class = 'middle33'>Page No." + pgn + "  of  " + rem + "</td></tr>";
        
            tbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + companyname + "</td></tr>";
            tbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + reportname + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='3' style='text-align:left'>From Date:" + fromdate + "</td><td colspan='2' style='text-align:right'>ToDate:" + todate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='3' style='text-align:left'> Center Name:" + centername + "</td><td colspan='2' style='text-align:right'>Branch Name:" + branchName + "</td><td style='text-align:right'> Ad Type:" + adtypename + "</td></tr>";
         
            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ro_no + "</td><td  class='middle31new'>" + rodate + "</td><td  class='middle31new'>" + cardrate + "</td><td  class='middle31new'>" + packaje + "</td><td  class='middle31new' >" + AUDIT_COMMENT + "</td></tr>";

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    tbl += "</table><p>";
                    tbl += "</br>";
                    tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                    tbl += "</table><p>";
                    pgn = pgn + 1;
                    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ro_no + "</td><td  class='middle31new'>" + rodate + "</td><td  class='middle31new'>" + cardrate + "</td><td  class='middle31new'>" + packaje + "</td><td  class='middle31new' >" + AUDIT_COMMENT + "</td></tr>";

                }

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                 tbl += "<td class='rep_data' width='12%'>";
                 tbl += ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='12%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["RO_DATE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["CARD_RATE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='12%'>";
                tbl += ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='30%'>";
                tbl += ds.Tables[0].Rows[p]["AUDIT_COMMENT"].ToString() + "</td>";
                

                rowcounter++;

            }

            tbl += "</table></p>";

            report.InnerHtml = tbl;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }



    }
    public void gridbind_excel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.auditor_comment(compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
           ds = unregistclient.auditor_comment(compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5);
        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='3' style='text-align:left'>From Date:" + fromdate + "</td><td colspan='2' style='text-align:right'>ToDate:" + todate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='3' style='text-align:left'> Center Name:" + centername + "</td><td colspan='2' style='text-align:right'>Branch Name:" + branchName + "</td><td style='text-align:right'> Ad Type:" + adtypename + "</td></tr>";
       
            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ro_no + "</td><td  class='middle31new'>" + rodate + "</td><td  class='middle31new'>" + cardrate + "</td><td  class='middle31new'>" + packaje + "</td><td  class='middle31new' align='center'>" + AUDIT_COMMENT + "</td></tr>";

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    tbl += "</table><p>";
                    tbl += "</br>";
                    tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                    tbl += "</table><p>";

                    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ro_no + "</td><td  class='middle31new'>" + rodate + "</td><td  class='middle31new'>" + cardrate + "</td><td  class='middle31new'>" + packaje + "</td><td  class='middle31new' align='center'>" + AUDIT_COMMENT + "</td></tr>";

                }

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='12%'>";
                tbl += ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='12%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["RO_DATE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["CARD_RATE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='12%'>";
                tbl += ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='30%'>";
                tbl += ds.Tables[0].Rows[p]["AUDIT_COMMENT"].ToString() + "</td>";


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
    public void showreportpdf()
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
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.auditor_comment(compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
          //  ds = unregistclient.clint(compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, pextra2, pextra3, pextra4, pextra5);

            ds = unregistclient.auditor_comment(compcode, center, branchcode, fromdate, todate, adtype, flag, userid, dateformat, extra1, extra2, extra3, extra4, extra5);
  
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
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
            tbl.addCell(new iTextSharp.text.Phrase("Auditor Comment Report", font9));
            document.Add(tbl);

            PdfPTable tbl2 = new PdfPTable(3);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl2.WidthPercentage = 100;
            tbl2.addCell(new iTextSharp.text.Phrase("From Date:" + fromdate, font10));
            tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
             tbl2.addCell(new iTextSharp.text.Phrase("To Date: " + todate, font10));
             tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
           
            tbl2.addCell(new iTextSharp.text.Phrase("Run Date: " + rdatefinalhdsmain, font10));

            document.Add(tbl2);

            PdfPTable tb8 = new PdfPTable(3);
            tb8.DefaultCell.BorderWidth = 0;
            tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tb8.WidthPercentage = 100;
            tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
             tb8.addCell(new iTextSharp.text.Phrase("Center: " + centername, font10));
            tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tb8.addCell(new iTextSharp.text.Phrase("Branch Name: " + branchName, font10));
            tb8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
             tb8.addCell(new iTextSharp.text.Phrase("Ad Type: " + adtypename, font10));

            document.Add(tb8);
           
           

               PdfPTable tbl3 = new PdfPTable(8);
            tbl3.DefaultCell.BorderWidth = 0;
            tbl3.WidthPercentage = 100;
            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl3.addCell(new iTextSharp.text.Phrase("SNo", font10));
            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl3.addCell(new iTextSharp.text.Phrase("Agency Name", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Client Name", font10));
            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl3.addCell(new iTextSharp.text.Phrase("Ro NO", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("Ro Date", font10));
            tbl3.addCell(new iTextSharp.text.Phrase("CARD RATE", font10));
                  tbl3.addCell(new iTextSharp.text.Phrase("PACKAGE NAME", font10));
              tbl3.addCell(new iTextSharp.text.Phrase("AUDIT COMMENT", font10));

            document.Add(tbl3);

            PdfPTable tbl4 = new PdfPTable(8);
            tbl4.DefaultCell.BorderWidth = 0;
            tbl4.WidthPercentage = 100;

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                sno1++;
                tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                tbl4.addCell(new iTextSharp.text.Phrase(sno1.ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["RO_NO"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["RO_DATE"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["CARD_RATE"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString(), font8));
                tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[p]["AUDIT_COMMENT"].ToString(), font8));


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
