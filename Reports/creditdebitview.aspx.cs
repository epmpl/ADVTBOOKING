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
using System.Text;
using System.IO;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

public partial class Reports_creditdebitview : System.Web.UI.Page
{
    string compcode = "", userid = "", dateformate = "", todate = "", frdate = "", edition = "", extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "", basedon = "";
    string destination = "", reportype = "", currentdate = "", reportfor = "", publi = "", branch = "", comanyname = "";
    string view12 = "";
    string pubname = "";
    int pgn = 1;
    int rowcounter = 0;
    int p;
    static int current = 1;
    int ll;
    int pagewidth = 20;
    int jj = 1;
    int kk;
    int j;
    int pagec;
    int pagecount;
    static int ab = 0;
    static int b = 4;
    static int k;
    static int l;
    int pgno = 1;
    string day = "";
    string month = "";
    string year = "";
    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    static string MDYToDMY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
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
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        compcode = Request.QueryString["compcode"].ToString();
        userid = Request.QueryString["userid"].ToString();
        dateformate = Request.QueryString["dateformat"].ToString();
        frdate = Request.QueryString["frdate"].ToString();
        todate = Request.QueryString["todate"].ToString();
        publi = Request.QueryString["publication"].ToString();
        branch = Request.QueryString["branch"].ToString();
        reportype = Request.QueryString["reporttype"].ToString();
        destination = Request.QueryString["destination"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        extra2 = Request.QueryString["extra2"].ToString();
        extra3 = Request.QueryString["extra3"].ToString();
        extra4 = Request.QueryString["extra4"].ToString();
        extra5 = Request.QueryString["extra5"].ToString();
        comanyname = Request.QueryString["comanyname"].ToString();
        view12 = Request.QueryString["destination"].ToString();
        pubname = Request.QueryString["center_name"].ToString();
        DateTime dt = System.DateTime.Now;
        if (dateformate == "dd/mm/yyyy")
        {
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            year = dt.Year.ToString();
            currentdate = day + "/" + month + "/" + year;

        }
        else if (dateformate == "mm/dd/yyyy")
        {

            day = dt.Day.ToString();
            month = dt.Month.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            year = dt.Year.ToString();
            currentdate = month + "/" + day + "/" + year;

        }
        else if (dateformate == "yyyy/mm/dd")
        {

            day = dt.Day.ToString();
            month = dt.Month.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            year = dt.Year.ToString();
            currentdate = year + "/" + month + "/" + day;
        }
        if (!Page.IsPostBack)
        {

            //=============for paging================

            if (Request.QueryString["page"] != null)
            {
                p = Convert.ToInt16(Request.QueryString["page"].ToString());
                current = p;
                ll = p;
                p = (p * pagewidth) - pagewidth;
            }
            else
            {
                current = 1;
                p = 0;
                jj = 0;
                kk = 0;

            }
            if (destination == "0")
            {

               showreport();
            }
            else if (destination == "1")
            {
               shoexecl();
            }
        }
    }
    public string createheader(DataSet ds)
    {
        string Hearder1 = "";
        string reportname1 = "Statement for Credit /Debit Notes";

        Hearder1 += "<tr><td align='center'colspan='14'><b> ";
        Hearder1 += comanyname;
        Hearder1 += "</b></td></tr>";
        Hearder1 += "<tr><td align='center'colspan='14'><b> ";
        if (reportype == "C")
        {
            Hearder1 += "Statement for Credit Notes" + " " + "From" + " " + frdate + " " + "To" + " " + todate;
        }
        else
        {
            Hearder1 += "Statement for Debit Notes" + " " + "From" + " " + frdate + " " + "To" + " " + todate;
        }

        Hearder1 += "</b></td></tr>";
        if (destination == "1")
        {
            if (reportype == "C")
            {
                Hearder1 += "<tr colspan='16'><td  align='right' style='font-family:Arial;font-size:14px;' colspan='16'><b>Run Date:</b>" + currentdate + "</td></tr>";
            }
            else
            {
                Hearder1 += "<tr colspan='14'><td  align='right' style='font-family:Arial;font-size:14px;' colspan='14'><b>Run Date:</b>" + currentdate + "</td></tr>";
            }
        }
        else
        {
            Hearder1 += "<tr><td  align='right' style='font-family:Arial;font-size:14px;'><b>Run Date:</b>" + currentdate + "</td></tr>";
        }
        if (reportype == "C")
        {
            Hearder1 += "<tr><td  align='left' style='font-family:Arial;font-size:14px;' colspan='4'><b>Revenue Collected For:</b>" + " " + pubname + "</td></tr>";
        }
        else
        {
            Hearder1 += "<tr><td  align='left' style='font-family:Arial;font-size:14px;' colspan='4'><b>Revenue Collected at:</b>" + " " + pubname + "</td></tr>";
        }
        return Hearder1;
    }
    public void showreport()
    {
        
        double grandtotal = 0;
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, publi, branch, frdate, todate, reportype, userid, dateformate, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "CR_DR_Notes_statement_branch";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            //string procedureName = "rpt_unit_bulletwise_business";
            //NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }

        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        int rowcounter = 0;
        int srno = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
            string topheader = createheader(ds);
            tbl = tbl + topheader;
            tbl = tbl + "</table>";
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
            tbl = tbl + "<tr ><td colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Sr. No.</b></td>";
            tbl = tbl + "<td  colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Booking Id<b></td>";
            tbl = tbl + "<td   colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ro No.<b></td>";
            tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ro Date<b></td>";
            if (reportype == "C")
            {
                tbl = tbl + "<td  align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Collection Center</td>";
            }
            tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Party Name</td>";
            tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Reciept No.</td>";
            if (reportype == "D")
            {
                tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Branch Name<b></td>";
            }
            tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Amount<b></td></tr>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                //if (rowcounter >= maxlimit)
                //{
                //    tbl = tbl + "</table></p>";
                //    rowcounter = 0;
                //    tbl = tbl + "<p style='page-break-after:always;'><table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                //    pgno++;
                //    string header = createheader(ds);
                //    tbl = tbl + header;
                //    tbl = tbl + "</table>";
                //    tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                //    tbl = tbl + "<tr ><td colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Sr. No.</b></td>";
                //    tbl = tbl + "<td  colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Booking Id<b></td>";
                //    tbl = tbl + "<td   colspan='2'  align='left' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ro No.<b></td>";
                //    tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Ro Date<b></td>";
                //    if (reportype == "C")
                //    {
                //        tbl = tbl + "<td  align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Collection Center</td>";
                //    }
                //    tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Party Name</td>";
                //    tbl = tbl + "<td   align='left' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Reciept No.</td>";
                //    tbl = tbl + "<td   align='right' colspan='2' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Amount<b></td></tr>";
                //}
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (srno + "</td>");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Booking_ID"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ro_No"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ro_Date"] + "</td>");
                if (reportype == "C")
                {
                    tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px-family:Arial;;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["PUBLISHING_CENTER"] + "</td>");
                }
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency_sub_code"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Receipt_no"] + "</td>");
                if (reportype == "D")
                {
                    tbl = tbl + ("<td align='left' colspan='2' style='font-size:14px;font-family:Arial;'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["BRANCHNAME"] + "</td>");
                }
                tbl = tbl + ("<td align='right' colspan='2' style='font-size:14px;font-family:Arial;'>");
                double amount = Convert.ToDouble(ds.Tables[0].Rows[i]["SHARE_NET_AMOUNT"]);
                tbl = tbl + (amount.ToString("F2") + "</td>");
                if (ds.Tables[0].Rows[i]["SHARE_NET_AMOUNT"].ToString() != "")
                    grandtotal = grandtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["SHARE_NET_AMOUNT"]);
               
                rowcounter++;
                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td  colspan='14'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Total:</b></td>");
                    tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>" + Math.Round(grandtotal, 0) + "</b></td>");
                    tbl = tbl + ("</tr>");
                }
                srno++;
               
            }

        }

        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        view.InnerHtml += tbl;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        view.Visible = true;
        view.RenderControl(hw);
        //Response.Write(sw.ToString());
       // Response.Flush();
       // Response.End();
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_criedit_print"] = "compcode~" + compcode + "~userid~" + userid + "~dateformate~" + dateformate + "~frdate~" + frdate + "~todate~" + todate + "~publi~" + publi + "~branch~" + branch + "~reportype~" + reportype + "~destination~" + destination + "~extra1~" + extra1 + "~extra2~" + extra2 + "~extra3~" + extra3 + "~extra4~" + extra4 + "~extra5~" + extra5 + "~comanyname~" + comanyname + "~view12~" + view12 + "~pubname~" + pubname;
        Response.Redirect("creditdebitprint.aspx");
    }
    public void shoexecl()
    {
       
        double grandtotal = 0;
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, publi, branch, frdate, todate, reportype, userid, dateformate, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "CR_DR_Notes_statement_branch";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            //string procedureName = "rpt_unit_bulletwise_business";
            //NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }

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
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        int srno = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl = tbl + "<p ><table width='50%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";

            string topheader = createheader(ds);
            tbl = tbl + topheader;
            tbl = tbl + "</table>";
            tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='1' style='vertical-align:top;'>";
            tbl = tbl + "<tr ><td colspan='2'  align='left' ><b>Sr. No.</b></td>";
            tbl = tbl + "<td  colspan='2'  align='left' ><b>Booking Id<b></td>";
            tbl = tbl + "<td   colspan='2'  align='left' ><b>Ro No.<b></td>";
            tbl = tbl + "<td   align='left' colspan='2'><b>Ro Date<b></td>";
            if (reportype == "C")
            {
                tbl = tbl + "<td  align='left' colspan='2' ><b>Collection Center</td>";
            }
            tbl = tbl + "<td   align='left' colspan='2' ><b>Party Name</td>";
            tbl = tbl + "<td   align='left' colspan='2' ><b>Reciept No.</td>";
            if (reportype == "D")
            {
                tbl = tbl + "<td   align='left' colspan='2'><b>Branch Name<b></td>";
            }
            tbl = tbl + "<td   align='right' colspan='2'><b>Amount<b></td></tr>";
            tbl = tbl + "</table>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tbl = tbl + "<table width='100%' cellpadding='0' cellsapcing='0' border='0' style='vertical-align:top;'>";
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td align='left' colspan='2'>");
                tbl = tbl + (srno + "</td>");
                tbl = tbl + ("<td align='left' colspan='2'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Booking_ID"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ro_No"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Ro_Date"] + "</td>");
                if (reportype == "C")
                {
                    tbl = tbl + ("<td align='left' colspan='2'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["PUBLISHING_CENTER"] + "</td>");
                }
                tbl = tbl + ("<td align='left' colspan='2'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Agency_sub_code"] + "</td>");
                tbl = tbl + ("<td align='left' colspan='2'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["Receipt_no"] + "</td>");
                if (reportype == "D")
                {
                    tbl = tbl + ("<td align='left' colspan='2'>");
                    tbl = tbl + (ds.Tables[0].Rows[i]["BRANCHNAME"] + "</td>");
                }
                tbl = tbl + ("<td align='right' colspan='2'>");
                double amount = Convert.ToDouble(ds.Tables[0].Rows[i]["SHARE_NET_AMOUNT"]);
                tbl = tbl + (amount.ToString("F2") + "</td>");
                if (ds.Tables[0].Rows[i]["SHARE_NET_AMOUNT"].ToString() != "")
                    grandtotal = grandtotal + Convert.ToDouble(ds.Tables[0].Rows[i]["SHARE_NET_AMOUNT"]);


                if (i == (ds.Tables[0].Rows.Count - 1))
                {
                    tbl = tbl + ("<tr>");
                    tbl = tbl + ("<td  colspan='15'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>Total:</b></td>");

                    tbl = tbl + ("<td  colspan='1'align='right'class='rep_datatotal_vouchdata' style='border-bottom:solid 1px black;border-top:solid 1px black;'><b>" + Math.Round(grandtotal, 0) + "</b></td>");
                    tbl = tbl + ("</tr>");
                }
                srno++;
                tbl = tbl + "</tr>";
                tbl = tbl + ("</table>");
            }

        }

        view.InnerHtml = tbl.ToString();
        hw.WriteBreak();
        view.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
}