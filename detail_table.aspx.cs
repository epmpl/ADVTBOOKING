using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Text.RegularExpressions;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;

public partial class detail_table : System.Web.UI.Page
{

    string module = "";
    string status = "";
    string userid = "";
    string creationdtfrom = "";
    string creationtodate = "";
    string lastuseddtfrm = "";
    string lastusedtodt = "";
    string extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "";

    string col1 = "", col2 = "", col3 = "", col4 = "", col5 = "", col6 = "", col7 = "", col8 = "", col9 = "", col10 = "", col11 = "";
    string views, view11;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        hdncomp_name.Value = Session["comp_name"].ToString();
        hdndateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/detail_table.xml"));
        col1 = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        col2 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        col3 = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        col4 = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        col5 = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        col6 = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        col7 = ds.Tables[0].Rows[0].ItemArray[6].ToString();
        col8 = ds.Tables[0].Rows[0].ItemArray[7].ToString();
        col9 = ds.Tables[0].Rows[0].ItemArray[8].ToString();
        col10 = ds.Tables[0].Rows[0].ItemArray[9].ToString();
        col11 = ds.Tables[0].Rows[0].ItemArray[10].ToString();

        string rundate1 = Convert.ToString(System.DateTime.Now);
        string rundate = changeformat(rundate1);
        string[] tim = rundate1.Split(' ');
        string rdate = rundate;
        view11 = views;

        module = Request.QueryString["module"].ToString();
        status = Request.QueryString["status"].ToString();
        userid = Request.QueryString["userid"].ToString();
        creationdtfrom = Request.QueryString["creation_date_from"].ToString();
        creationtodate = Request.QueryString["creation_to_date"].ToString();
        lastuseddtfrm = Request.QueryString["last_used_date_from"].ToString();
        lastusedtodt = Request.QueryString["last_used_to_date"].ToString();
        views = Request.QueryString["destination"].ToString();

        if (!Page.IsPostBack)
        {


            if (views == "ons")
            {
                showreport();
            }
            else if (views == "exc")
            {
                showreportexcel();
            }
            else if (views == "pdf")
            {
                showreportpdf();
            }

        }
    }
    public string date_chk(string acc_date)
    {

        if (acc_date != "")
        {
            if (acc_date.IndexOf(" ") > -1)
            {
                string[] chk_str = acc_date.Split(' ');
                acc_date = chk_str[0];
            }
        }
        if (hdndateformat.Value == "dd/mm/yyyy" && acc_date != "")
        {
            string[] arr = acc_date.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            if (arr[0].Length < 2)
                dd = "0" + arr[0];
            if (arr[1].Length < 2)
                mm = "0" + arr[1];
            acc_date = mm + "/" + dd + "/" + yy;
        }
        else if (acc_date != "")
        {
            string[] arr = acc_date.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            if (arr[0].Length < 2)
                dd = "0" + arr[0];
            if (arr[1].Length < 2)
                mm = "0" + arr[1];
            acc_date = dd + "/" + mm + "/" + yy;
        }
        else if (acc_date == "")
        {
            acc_date = "";
        }
        return acc_date;
    }

    public string changeformat(string userdate)
    {
        string[] arr = userdate.Split('/');
        string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
        return change;
    }
    public void showreport()
    {
        DataSet ds = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), module, status, userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt,"MM/DD/YYYY", extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "adm_get_user_detail";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), module, status, userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt, hdndateformat.Value, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "adm_get_user_detail";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "adm_get_user_detail";
            string[] parameterValueArray = { Session["compcode"].ToString(), module, "", userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt, "mm/dd/yyyy", extra1, extra2, extra3, extra4, extra5 };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }






        string TBL = "";
        /*********************************/

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");

            return;

        }



        /*******************************************************************************/

        TBL += "<table cellpadding='0' cellspacing='0' border='0'  width='100%'>";
        TBL += "<tr>";
        TBL += "<td style='font-size:16px; ' colspan='10' align='center' ><b>" + Session["comp_name"].ToString() + "</b></td></tr>";
        string uname = "";



        TBL += "<tr>";
        TBL += "<td style='font-size:16px; ' colspan='10' align='center' ><b>" + "Get User Detail" + "</b></td></tr>";
        TBL += "<tr>";
        TBL += "<td style='font-size:16px; ' colspan='10' align='center' ><b>" + "Creation Date from:" + "&nbsp;&nbsp;" + creationdtfrom + "&nbsp;&nbsp;&nbsp;" + "Last Used Date From :" + "&nbsp;&nbsp;" + lastuseddtfrm + "&nbsp;&nbsp;&nbsp;" + "Creation To Date: " + creationtodate + "&nbsp;&nbsp;" + "Last Used To Date:" + "&nbsp;&nbsp;" + lastusedtodt + "</b></td>";

        TBL += "</tr>";
        TBL += "</table>";

        TBL += "<table width='100%' cellspacing='0px'  cellpadding = '0px' border='0' style='border-bottom:solid 1px black;border-top:solid 1px black;'>";

        TBL += "<tr>";
        TBL += "<td  style='font-size:15px;' align='left' width='3%'><b>S.No.</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='3%'><b>User Id</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>User Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>First Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>Last Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='3%'><b>Module Id</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>Module Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='3%'><b>Status</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>Status Change Date</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>User Creation Date</b></td>";
        TBL += "<td  style='font-size:15px;' align='left' width='5%'><b>Last Used Date</b></td>";
        TBL += "</tr>";
        TBL += "</table>";

        TBL += "<table width='100%' cellspacing='0px'  cellpadding = '0px' border='1'>";



        //================================================ For values ===================================================
        int sno = 1;

        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        {




            TBL += "<tr><td width='3%'  style='font-size:14px;' align='left'>" + sno + "</td>";
            TBL += "<td width='3%' style='font-size:14px;'  align='left'>" + ds.Tables[0].Rows[m]["USERID"].ToString() + "</td>";
            TBL += "<td width='5%'  style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["USERNAME"].ToString() + "</td>";
            TBL += "<td width='5%'  style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["FIRSTNAME"].ToString() + "</td>";
            TBL += "<td width='5%' style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["LASTNAME"].ToString() + "</td>";
            TBL += "<td width='3%'  style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["module_id"].ToString() + "</td>";
            TBL += "<td width='5%' style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["MODULE_NAME"].ToString() + "</td>";
            TBL += "<td width='3%' style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["STATUS"].ToString() + "</td>";
            TBL += "<td width='5%'  style='font-size:14px;' align='left'>" + date_chk(ds.Tables[0].Rows[m]["STATUS_CHANGE_DATE"].ToString()) + "</td>";
            TBL += "<td width='5%' style='font-size:14px;'  align='left'>" + date_chk(ds.Tables[0].Rows[m]["USER_CREATION_DATE"].ToString()) + "</td>";
            TBL += "<td width='5%' style='font-size:14px;' align='left'>" + date_chk(ds.Tables[0].Rows[m]["LAST_USED_DATE"].ToString()) + "</td></tr>";
            sno++;
        }
        TBL += "</table>";
        report.InnerHtml = TBL;
    }

    public void showreportexcel()
    {
        DataSet ds = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), module, status, userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt, "MM/DD/YYYY", extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "adm_get_user_detail";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), module, status, userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt, hdndateformat.Value, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "adm_get_user_detail";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }



        string TBL = "";
        /*********************************/

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");

            return;

        }





        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        TBL += "<table cellpadding='0' cellspacing='0' border='1'  width='100%'>";
        TBL += "<tr>";
        TBL += "<td style='font-size:16px;' colspan='10' align='center' ><b>" + Session["comp_name"].ToString() + "</b></td></tr>";
        string uname = "";



        TBL += "<tr>";
        TBL += "<td style='font-size:16px; ' colspan='10' align='center' ><b>" + "Get User Detail" + "</b></td></tr>";
        TBL += "<tr>";
        TBL += "<td style='font-size:16px; ' colspan='13' align='center' ><b>" + "Creation Date from:" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + creationdtfrom + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Last Used Date From :" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + lastuseddtfrm + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Creation To Date: " + creationtodate + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Last Used To Date:" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + lastusedtodt + "</b></td>";

        TBL += "</tr>";
        TBL += "</table>";

        TBL += "<table width='100%' cellspacing='0px' colspan='10' cellpadding = '0px' border='0'>";
        TBL += "<tr>";
        TBL += "<td  style='font-size:15px;' align='left' width='3%'><b>S.No.</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='3%'><b>User Id</b></td>";
        TBL += "<td style='font-size:15px;' align='left' colspan='2'><b>User Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' colspan='2'><b>First Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' colspan='2'><b>Last Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='3%'><b>Module Id</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>Module Name</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='3%'><b>Status</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>Status Change Date</b></td>";
        TBL += "<td style='font-size:15px;' align='left' width='5%'><b>User Creation Date</b></td>";
        TBL += "<td  style='font-size:15px;' align='left' width='5%'><b>Last Used Date</b></td>";
        TBL += "</tr>";



        //================================================ For values ===================================================
        int sno = 1;

        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        {



            TBL += "<tr><td width='3%'  style='font-size:14px;' align='left'>" + sno + "</td>";
            TBL += "<td width='3%' style='font-size:14px;'  align='left'>" + ds.Tables[0].Rows[m]["USERID"].ToString() + "</td>";
            TBL += "<td colspan='2'  style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["USERNAME"].ToString() + "</td>";
            TBL += "<td colspan='2'  style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["FIRSTNAME"].ToString() + "</td>";
            TBL += "<td colspan='2' style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["LASTNAME"].ToString() + "</td>";
            TBL += "<td width='3%'  style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["module_id"].ToString() + "</td>";
            TBL += "<td width='5%' style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["MODULE_NAME"].ToString() + "</td>";
            TBL += "<td width='3%' style='font-size:14px;' align='left'>" + ds.Tables[0].Rows[m]["STATUS"].ToString() + "</td>";
            TBL += "<td width='5%'  style='font-size:14px;' align='left'>" + date_chk(ds.Tables[0].Rows[m]["STATUS_CHANGE_DATE"].ToString()) + "</td>";
            TBL += "<td width='5%' style='font-size:14px;'  align='left'>" + date_chk(ds.Tables[0].Rows[m]["USER_CREATION_DATE"].ToString()) + "</td>";
            TBL += "<td width='5%' style='font-size:14px;' align='left'>" + date_chk(ds.Tables[0].Rows[m]["LAST_USED_DATE"].ToString()) + "</td></tr>";
            sno++;

        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");








        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        report.InnerHtml = TBL;
        report.Visible = true;
        report.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();



    }

    public void showreportpdf()
    {
        int page = 1;
        
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        //Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);

        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 1;
        //iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        //footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        //document.Footer = footer;
        document.Open();

        DataSet ds = new DataSet();

        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), module, status, userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt, "MM/DD/YYYY", extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "adm_get_user_detail";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), module, status, userid, creationdtfrom, creationtodate, lastuseddtfrm, lastusedtodt, hdndateformat.Value, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "adm_get_user_detail";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }


        int rowcount = ds.Tables[0].Rows.Count;
        int columncount = ds.Tables[0].Rows.Count;
        int NumColumns = ds.Tables[0].Rows.Count;

         
        iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 12, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 10);
        iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 20, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font12 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 10, iTextSharp.text.Font.BOLD);
        iTextSharp.text.Font font13 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_NEW_ROMAN, 10, iTextSharp.text.Font.ITALIC);
        float[] arr1 = { 0.2f, 0.3f, 0.6f, 0.3f, 0.3f, 0.3f, 0.3f, 0.4f, 0.3f, 0.3f };

           PdfPTable tblcomp = new PdfPTable(1);
        tblcomp.DefaultCell.BorderWidth = 0;
        tblcomp.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        tblcomp.addCell(new iTextSharp.text.Phrase(Session["comp_name"].ToString(), font8));
        tblcomp.WidthPercentage = 100;
        document.Add(tblcomp);

          PdfPTable tblcomp11 = new PdfPTable(1);
        tblcomp11.DefaultCell.BorderWidth = 0;
        tblcomp11.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        tblcomp11.addCell(new iTextSharp.text.Phrase("User Detail", font9));
        tblcomp11.WidthPercentage = 100;
        document.Add(tblcomp11);

          PdfPTable tbl1 = new PdfPTable(1);
        tbl1.DefaultCell.BorderWidth = 0;
        
        tbl1.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
        tbl1.addCell(new iTextSharp.text.Phrase("Creation Date From :" + creationdtfrom +" " + "Creation To Date :" +  creationtodate+" "+"Last Used Date From :" +lastuseddtfrm + " "+"Last Used To Date :" + lastusedtodt, font10));
      
        tbl1.WidthPercentage = 100;
        document.Add(tbl1);

             PdfPTable tablP = new PdfPTable(2);
        tablP.DefaultCell.BorderWidth = 0;
        tablP.WidthPercentage = 100;   
        tablP.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
        tablP.addCell(new iTextSharp.text.Phrase("Page No:  " + page, font10));
        document.Add(tablP);
      
         
        PdfPTable tbl2 = new PdfPTable(5);
        tbl2.DefaultCell.BorderWidth = 0;
        tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl2.WidthPercentage = 100;

           document.Add(tbl2);

          PdfPTable tbl3 = new PdfPTable(11);
        tbl3.DefaultCell.BorderWidth = 0;
       int[] width={ 5,15,25,20,20,10,30,15,15,15,15};
        tbl3.setWidths(width);
        tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl3.WidthPercentage = 100;
        tbl3.DefaultCell.Colspan = 11;
        tbl3.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________"));
        tbl3.DefaultCell.Colspan = 1;
        tbl3.addCell(new iTextSharp.text.Phrase("S.NO.", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("User Id", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("User Name", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("First Name", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("Last Name", font10)); 
        tbl3.addCell(new iTextSharp.text.Phrase("Module Id", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("Module Name", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("Status", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("Status Change Date", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("User CreationDate", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("Last Used Date", font10));
        tbl3.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________"));
        document.Add(tbl3);

           int sno = 1;
           for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
           { 
           
          PdfPTable tbl4 = new PdfPTable(11);
        tbl3.DefaultCell.BorderWidth = 0;
        int[] wid = { 5, 15, 25, 20, 20, 10, 30, 15, 15, 15, 15 };
        tbl4.setWidths(wid);
        tbl4.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
        tbl4.WidthPercentage = 100;
        tbl4.DefaultCell.Colspan = 11;
        tbl4.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________"));
        tbl4.DefaultCell.Colspan = 1;
        tbl4.addCell(new iTextSharp.text.Phrase(sno.ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["USERID"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase (ds.Tables[0].Rows[m]["USERNAME"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[m]["FIRSTNAME"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase( ds.Tables[0].Rows[m]["LASTNAME"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase( ds.Tables[0].Rows[m]["module_id"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase( ds.Tables[0].Rows[m]["MODULE_NAME"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase( ds.Tables[0].Rows[m]["STATUS"].ToString(), font10));
        tbl4.addCell(new iTextSharp.text.Phrase(date_chk(ds.Tables[0].Rows[m]["STATUS_CHANGE_DATE"].ToString()), font10));
        tbl4.addCell(new iTextSharp.text.Phrase( date_chk(ds.Tables[0].Rows[m]["USER_CREATION_DATE"].ToString()), font10));
        tbl4.addCell(new iTextSharp.text.Phrase(date_chk(ds.Tables[0].Rows[m]["LAST_USED_DATE"].ToString()), font10));
        tbl4.addCell(new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________"));
        document.Add(tbl4);
           
           sno++;
           
           }
           

          document.Close();
        Response.Redirect(pdfName);

}
}
          