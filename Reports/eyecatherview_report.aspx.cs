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

public partial class Reports_eyecatherview_report : System.Web.UI.Page
{

    string compcode = "", userid = "", dateformate = "", todate = "", frdate = "", edition = "", adtype = "", uom = "", bullet = "", extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "", basedon = "";
    string destination = "", categ = "", reportype = "", currentdate = "", reportfor = "", unitcode = "", branch = "", comanyname="";
    string view12 = "";
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
    string ratecode = "";
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
        unitcode = Request.QueryString["unit"].ToString();
        branch = Request.QueryString["branch"].ToString();
        adtype = Request.QueryString["adtype"].ToString();
        uom = Request.QueryString["uom"].ToString();
        bullet = Request.QueryString["bullet"].ToString();
        categ = Request.QueryString["catg"].ToString();
        reportype = Request.QueryString["reporttype"].ToString();
        reportfor = Request.QueryString["reportfor"].ToString();
        destination = Request.QueryString["destination"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        extra2 = Request.QueryString["extra2"].ToString();
        extra3 = Request.QueryString["extra3"].ToString();
        extra4 = Request.QueryString["extra4"].ToString();
        extra5 = Request.QueryString["extra5"].ToString();
        comanyname = Request.QueryString["comanyname"].ToString();
        view12 = Request.QueryString["destination"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        DateTime dt = System.DateTime.Now;
        if (dateformate == "dd/mm/yyyy")
        {
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            if (day.Length == 1)
            {
                day="0"+day;
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
            if (destination == "1")
            {
               
                showreport();
            }
            else if (destination == "2")
            {
                shoexecl();
            }
        }
    }
    

    public void showreport()
    {
        int lenth = 0;
        int break1 = 0;
        int grandtotal = 0;
        int sr = 1;
        int sr_page = 1;
        int max_limit = 40;
        int max_page = 1;
        int sr_unit = 0;
        int sr_publ = 0;
        string rcoden = "";
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, unitcode, branch, frdate, todate, adtype, uom, bullet, categ, reportype, reportfor, userid, dateformate, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "rpt_unit_bulletwise_business";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "rpt_unit_bulletwise_business";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }
       
     
        StringBuilder TBL = new StringBuilder();
        double[] arr = new double[ds.Tables[0].Columns.Count];
        double[] arr_edtn = new double[ds.Tables[0].Columns.Count];
        double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
        double gg = 0;
        int rcount = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {

            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr><td style='text-align:center' class='mishdr'><b>" + comanyname + "</b></td></tr>");
            TBL.Append("<tr><td style='text-align:center' class='mis_hdr2'><b>" + "Eyecather Business Report" + "</b></td></tr>");
            TBL.Append("</table>");
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr>");
            if (reportype == "B")
            {
                string reportype2 = "Branch Wise";
                TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            else
            {
                string reportype2 = "Center Wise";
                TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            if (reportfor == "E")
            {
                string reportfor2 = "Eyecather Wise";
                TBL.Append("<td class='mis_hdr1'   align='left' width='10%'><b>" + "Report For :</b>" + " " + reportfor2 + "</td>");
            }
            else
            {
                string reportfor2 = "Category Wise";
                TBL.Append("<td class='mis_hdr1'  align='left 'width='10%' ><b>" + "Report For :</b>" + " " + reportfor2 + "</td>");
            }
           
            TBL.Append("</tr>");
            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' align='left' width='10%'><b>" + "From Date : </b>" + " " + frdate + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "To Date : </b>" + " " + todate + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='right' width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
            TBL.Append("</tr>");
            TBL.Append("</table>");
        }
        
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'>");
       
        for (int l = 4; l < ds.Tables[0].Columns.Count; l++)
        {
            if (ds.Tables[0].Columns[l].Caption.ToString() == "REMARKS")
            {
                if (reportfor == "E")
                {
                    TBL.Append("<td   class='quotationnam' align='center' style='font-size:13px;' ><b>EYECATHER</b></td>");
                }
                else
                {
                    TBL.Append("<td   class='quotationnam' align='center' style='font-size:13px;' ><b>CATEGORY</b></td>");
                }
            }
            else
            {
                TBL.Append("<td   class='quotationnam' align='center' style='font-size:13px;' ><b>" + ds.Tables[0].Columns[l].Caption.ToString() + "</b></td>");
            }
        }
            
        for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        {
            TBL.Append("<tr style='height:30px;'>");
            for (int v = 4; v < ds.Tables[0].Columns.Count; v++)
            {
                if (ds.Tables[0].Rows[z].ItemArray[v].ToString() == "0")
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='left' style='font-size:15px'>&nbsp;</td>");
                }
                else if (ds.Tables[0].Rows[z].ItemArray[v].ToString() == "Count" || ds.Tables[0].Rows[z].ItemArray[v].ToString() == "Revenue" || ds.Tables[0].Rows[z].ItemArray[v].ToString() == "Volume")
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='center' style='font-size:15px;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                }

                else
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='right' style='font-size:13px;'><b>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</b></td>");

                }

            }
            for (var x = 5; x < ds.Tables[0].Columns.Count; x++)
            {

                if (ds.Tables[0].Rows[z]["REMARKS"].ToString() == "Revenue")
                {
                    if (ds.Tables[0].Rows[z].ItemArray[x].ToString() == "" || ds.Tables[0].Rows[z].ItemArray[x].ToString() == null)
                    {
                        arr_Grand[x] += 0;
                    }
                    else
                    {

                        arr_Grand[x] += Convert.ToDouble(ds.Tables[0].Rows[z].ItemArray[x].ToString());
                    }
                }
            }
            //if (ds.Tables[0].Rows[z]["TOTAL"].ToString() == "" || ds.Tables[0].Rows[z]["TOTAL"].ToString() == null || ds.Tables[0].Rows[z]["TOTAL"].ToString()=="NULL")
            //{
            //    gg += 0;
            //}
            //else
            //{
            //    gg += Convert.ToDouble(ds.Tables[0].Rows[z]["TOTAL"].ToString());
            //}
        }
        TBL.Append("<tr>");
       
        TBL.Append("<td  align='center'  style='padding-right:5px;'><b>Grand Total</b>");
        for (var x = 5; x < ds.Tables[0].Columns.Count; x++)
        {
            
            TBL.Append("<td  align='right'  style='padding-right:5px;font-size:13;'><b>" + string.Format("{0:0.00}", arr_Grand[x]) + "</b></td>");
            gg = 0;
        }
        
        TBL.Append("</tr>");
        TBL.Append("</table>");
      
            view.InnerHtml = TBL.ToString();
        
    }

    public void shoexecl()
    {
        int lenth = 0;
        int break1 = 0;
        int grandtotal = 0;
        int sr = 1;
        int sr_page = 1;
        int max_limit = 40;
        int max_page = 1;
        int sr_unit = 0;
        int sr_publ = 0;
        string rcoden = "";
        string edition = "", edition_print = "";
        string find_unit = "";
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { compcode, unitcode, branch, frdate, todate, adtype, uom, bullet, categ, reportype, reportfor, userid, dateformate, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "rpt_unit_bulletwise_business";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "rpt_unit_bulletwise_business";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
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
        
        StringBuilder TBL = new StringBuilder();
        double[] arr = new double[ds.Tables[0].Columns.Count];
        double[] arr_edtn = new double[ds.Tables[0].Columns.Count];
        double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
        double gg = 0;
        int rcount = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {

            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr><td style='text-align:center' class='mishdr' colspan='2'><td style='text-align:center' class='mishdr' colspan='4'><b>" + comanyname + "</b></td></tr>");
            TBL.Append("<tr><td style='text-align:center' class='mishdr' colspan='2'><td style='text-align:center' class='mis_hdr2' colspan='4'><b>" + "Eyecather Business Report" + "</b></td></tr>");
            TBL.Append("</table>");
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'>");
            TBL.Append("<tr>");
            if (reportype == "B")
            {
                string reportype2 = "Branch Wise";
                TBL.Append("<td class='mis_hdr1'  align='left' colspan='2'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            else
            {
                string reportype2 = "Center Wise";
                TBL.Append("<td class='mis_hdr1'  align='left' colspan='2'><b>" + "Report Type :</b>" + " " + reportype2 + "</td>");
            }
            if (reportfor == "E")
            {
                string reportfor2 = "Eyecather Wise";
                TBL.Append("<td class='mis_hdr1'   align='left' colspan='2'><b>" + "Report For :</b>" + " " + reportfor2 + "</td>");
            }
            else
            {
                string reportfor2 = "Category Wise";
                TBL.Append("<td class='mis_hdr1'  align='left 'width='10%' ><b>" + "Report For :</b>" + " " + reportfor2 + "</td>");
            }

            TBL.Append("</tr>");
            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' align='left' colspan='2'><b>" + "From Date : </b>" + " " + frdate + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='left' colspan='2'><b>" + "To Date : </b>" + " " + todate + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='right' colspan='2'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
            TBL.Append("</tr>");
            TBL.Append("</table>");
        }

        TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'>");

        for (int l = 4; l < ds.Tables[0].Columns.Count; l++)
        {
            if (ds.Tables[0].Columns[l].Caption.ToString() == "REMARKS")
            {
                if (reportfor == "E")
                {
                    TBL.Append("<td   class='quotationnam' align='center' colspan='2' style='font-size:13px;border-right:solid 1px black;border-left:solid 1px black;border-top:solid 1px black;' ><b>EYECATHER</b></td>");
                }
                else
                {
                    TBL.Append("<td   class='quotationnam' align='center' colspan='2' style='font-size:13px;border-right:solid 1px black;border-top:solid 1px black;' ><b>CATEGORY</b></td>");
                }
            }
            else
            {
                TBL.Append("<td   class='quotationnam' align='center'  colspan='2' style='font-size:13px;border-right:solid 1px black;border-top:solid 1px black;' ><b>" + ds.Tables[0].Columns[l].Caption.ToString() + "</b></td>");
            }
        }

        for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
        {
            TBL.Append("<tr style='height:30px;'>");
            for (int v = 4; v < ds.Tables[0].Columns.Count; v++)
            {
                if (ds.Tables[0].Rows[z].ItemArray[v].ToString() == "0")
                {
                    TBL.Append("<td   align='center' style='font-size:15px;'></td>");
                }
                else if (ds.Tables[0].Rows[z].ItemArray[v].ToString() == "Count" || ds.Tables[0].Rows[z].ItemArray[v].ToString() == "Revenue" || ds.Tables[0].Rows[z].ItemArray[v].ToString() == "Volume")
                {
                    TBL.Append("<td    align='center' style='font-size:15px;' colspan='2'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                }

                else
                {
                    TBL.Append("<td  align='center' style='font-size:13px;' colspan='2'><b>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</b></td>");

                }

            }
            for (var x = 5; x < ds.Tables[0].Columns.Count; x++)
            {

                if (ds.Tables[0].Rows[z]["REMARKS"].ToString() == "Revenue")
                {
                    if (ds.Tables[0].Rows[z].ItemArray[x].ToString() == "" || ds.Tables[0].Rows[z].ItemArray[x].ToString() == null)
                    {
                        arr_Grand[x] += 0;
                    }
                    else
                    {

                        arr_Grand[x] += Convert.ToDouble(ds.Tables[0].Rows[z].ItemArray[x].ToString());
                    }
                }
            }
        }
        TBL.Append("<tr>");
        TBL.Append("<td align='right'  colspan='2'></td>");
        TBL.Append("<td  align='center' colspan='2'><b>Grand Total</b>");
        for (var x = 5; x < ds.Tables[0].Columns.Count; x++)
        {
            TBL.Append("<td  align='center' colspan='2'><b>" + string.Format("{0:0.00}", arr_Grand[x]) + "</b></td>");
            gg = 0;
        }

        TBL.Append("</tr>");
        TBL.Append("</table>");
            view.InnerHtml = TBL.ToString();
            hw.WriteBreak();
            view.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
       

    }

}