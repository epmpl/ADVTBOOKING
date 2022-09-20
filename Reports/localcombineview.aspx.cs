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
using System.Text;
using System.Globalization;
using System.IO;
using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;


public partial class Reports_localcombineview : System.Web.UI.Page
{

    string compcode = "";
    string rprttype = "";
    string frdt = "";
    string tbl1 = "";
    string todt = "";
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string branch = "";
    string ReportName = "";
    string dateformat = "";
    string currentdate = "";
    string unitcode = "";
    string pub = "";
    string agency = "";
    string dest = "";
    string extra = "";
    string extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "", extra6 = "", extra7 = "", extra8 = "", extra9 = "", userid = "", view12 = "", compname = "";
    string datetype = "";
    string ratetype = "", agmaincode = "", codesubcode = "", pubname = "", branchname = "";
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

    string SNo = "";
    string AgencyName = "";
    string Receipt_No = "";
    string Receipt_Date = "";
    string PRT_No = "";
    string PRT_Date = "";
    string Amt = "";
    string frdt1 = "";
    string todt1 = "";
    int i1 = 1;
    double amt = 0;
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
            hdndateformat.Value = Session["dateformat"].ToString();
        }
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }
        compcode = Session["compcode"].ToString();
        frdt = Session["frdt"].ToString();
        todt = Session["todt"].ToString();
        branch = Session["branch"].ToString();
        unitcode = Session["center"].ToString();
        pub = Session["pub"].ToString();
        //agency = Session["agency"].ToString();
        dest = Session["dest"].ToString();
        dateformat = Session["dateformat"].ToString();
        rprttype = Session["rprttype"].ToString();
        ratetype = Session["ratetype"].ToString();
        //agmaincode = Session["agmaincode"].ToString();
        //codesubcode = Session["codesubcode"].ToString();
        //subagcode = Session["subagcode"].ToString();
        extra1 = Session["extra1"].ToString();
        extra2 = Session["extra2"].ToString();
        extra3 = Session["extra3"].ToString();
        extra4 = Session["extra4"].ToString();
        extra5 = Session["extra5"].ToString();
        //branchname = Session["branchname"].ToString();
        //pubname = Session["pubname"].ToString();
        // view12 = Request.QueryString["dest"].ToString();
        compname = Session["comp_name"].ToString();
        userid = Session["userid"].ToString();


        DateTime dt = System.DateTime.Now;
        if (dateformat == "dd/mm/yyyy")
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
        else if (dateformat == "mm/dd/yyyy")
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
        else if (dateformat == "yyyy/mm/dd")
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

        if (dateformat == "dd/mm/yyyy")
        {
            string[] arr = frdt.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            frdt = mm + "/" + dd + "/" + yy;
            // frdt = Convert.ToDateTime(frdt1).ToString("dd-MMMM-yyyy");
        }


        if (dateformat == "dd/mm/yyyy")
        {
            string[] arr = todt.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            todt = mm + "/" + dd + "/" + yy;
            // todt = Convert.ToDateTime(todt1).ToString("dd-MMMM-yyyy");
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
            if (dest == "1")
            {

                showreport();
            }
            else if (dest == "2")
            {
                shoexecl();
            }
            //else if (dest == "3")
            //{
            //    showreportpdf();
            //}
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
        if (branch == "" || branch == "0")
        {
            branch = null;
        }
        else
        {
            branch = branch;
        }
        if (extra1 == "" || extra1 == "0")
        {
            extra1 = null;
        }
        else
        {
            extra1 = extra1;
        }
        if (extra2 == "" || extra2 == "0")
        {
            extra2 = null;
        }
        else
        {
            extra2 = extra2;
        }
        if (extra3 == "" || extra3 == "0")
        {
            extra3 = null;
        }
        else
        {
            extra3 = extra3;
        }
        if (extra4 == "" || extra4 == "0")
        {
            extra4 = null;
        }
        else
        {
            extra4 = extra4;
        }
        if (extra5 == "" || extra5 == "0")
        {
            extra5 = null;
        }
        else
        {
            extra5 = extra5;
        }
        string[] parameterValueArray = new string[] { compcode, unitcode, branch, frdt, todt, ratetype, userid, dateformat, rprttype, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "RPT_MONTHWISE_QBC_BUSINESS";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "RPT_MONTHWISE_QBC_BUSINESS";
            NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }

        StringBuilder TBL = new StringBuilder();
        double[] arr = new double[ds.Tables[0].Columns.Count];
        double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
        double[] arr_tot = new double[ds.Tables[0].Columns.Count];
        double gg = 0;
        int rcount = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno = 0;
            StringBuilder tbl = new StringBuilder();
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr><td colspan=8 style='text-align:center' class='mis_hdr2'><b>" + compname + "</b></td></tr>");
            TBL.Append("<tr><td colspan=8 style='text-align:center' class='mis_hdr2'>&nbsp;&nbsp</td></tr>");
            TBL.Append("<tr><td style='text-align:center' class='mis_hdr2'><b>" + "Local/Combine Report" + "</b></td></tr>");
            TBL.Append("</table>");
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr>");
             if (rprttype == "1")
            {
                string reportype2 = "Branch Wise";
                TBL.Append("<td class='mis_hdr1'  align='left'style='font-size:15px;' width='10%'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            else
            {
                string reportype2 = "Printing Center Wise";
                TBL.Append("<td class='mis_hdr1'  align='left'style='font-size:15px;' width='10%'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            //TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Branch : </b>" + " " + branchname + "</td>");
            if (pub == "0")
            {

                TBL.Append("<td class='mis_hdr1'  align='left'style='font-size:15px;' width='10%'><b>" + "Publication : </b>" + "All " + "</td>");
            }
            else
            {

                TBL.Append("<td class='mis_hdr1'  align='left'style='font-size:15px;' width='10%'><b>" + "Publication : </b>" + " " + pubname + "</td>");
            }


            if (ratetype == "D")
            {
                string ratetype2 = "LOCAL";
                TBL.Append("<td class='mis_hdr1'  align='right'style='font-size:15px;' width='10%'><b>" + "Rate Type : </b>" + " " + ratetype2 + "</td>");
            }
            else
            {
                string ratetype2 = "COMBINED";
                TBL.Append("<td class='mis_hdr1'  align='right'style='font-size:15px;' width='10%'><b>" + "Rate Type : </b>" + " " + ratetype2 + "</td>");
            }

            TBL.Append("</tr>");
            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' align='left' style='font-size:15px;' width='10%'><b>" + "From Date : </b>" + " " + frdt + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='left'style='font-size:15px;' width='10%'><b>" + "To Date : </b>" + " " + todt + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
           
            TBL.Append("</tr>");
            TBL.Append("</table>");

            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'>");
            //for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            //{
            TBL.Append("<tr>");
            for (int v = 3; v < ds.Tables[0].Columns.Count; v++)
            {
                if (ds.Tables[0].Columns[v].ToString() == "PUB_CENT_NAME")
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='left' style='font-size:13px;'><b>" + ds.Tables[0].Columns[v].ToString() + "</b></td>");
                }
                else
                TBL.Append("<td  width='6%' class='quotationnam' align='right' style='font-size:13px;'><b>" + ds.Tables[0].Columns[v].ToString() + "</b></td>");
            }
            
            TBL.Append("</tr>");


            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                TBL.Append("<tr>");


                for (int v = 3; v < ds.Tables[0].Columns.Count; v++)
                {
                    if (ds.Tables[0].Columns[v].ToString() == "PUB_CENT_NAME")
                    {
                        TBL.Append("<td  width='6%' class='quotationnam' align='left' style='font-size:13px;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                    }
                    else
                     
                        TBL.Append("<td  width='6%' class='quotationnam' align='right' style='font-size:13px;'>"  + string.Format("{0:0.00}", ds.Tables[0].Rows[z].ItemArray[v].ToString()) + "</td>");
                }
                TBL.Append("</tr>");
                for (var x = 4; x < ds.Tables[0].Columns.Count; x++)
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




                TBL.Append("<tr>");

                TBL.Append("<td  align='left'  style='padding-right:5px;'><b>TOTAL</b>");
                for (var x = 4; x < ds.Tables[0].Columns.Count; x++)
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='right' center='font-size:13px;'><b>" + string.Format("{0:0.00}", arr_Grand[x]) + "</b></td>");
                    gg = 0;
                }
                TBL.Append("</tr>");



            }

            view.InnerHtml = TBL.ToString();
        }
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
        DataSet ds = new DataSet();
        if (branch == "" || branch == "0")
        {
            branch = null;
        }
        else
        {
            branch = branch;
        }
        if (extra1 == "" || extra1 == "0")
        {
            extra1 = null;
        }
        else
        {
            extra1 = extra1;
        }
        if (extra2 == "" || extra2 == "0")
        {
            extra2 = null;
        }
        else
        {
            extra2 = extra2;
        }
        if (extra3 == "" || extra3 == "0")
        {
            extra3 = null;
        }
        else
        {
            extra3 = extra3;
        }
        if (extra4 == "" || extra4 == "0")
        {
            extra4 = null;
        }
        else
        {
            extra4 = extra4;
        }
        if (extra5 == "" || extra5 == "0")
        {
            extra5 = null;
        }
        else
        {
            extra5 = extra5;
        }
        string[] parameterValueArray = new string[] { compcode, unitcode, branch, frdt, todt, ratetype, userid, dateformat, rprttype, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "RPT_MONTHWISE_QBC_BUSINESS";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            string procedureName = "RPT_MONTHWISE_QBC_BUSINESS";
            NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
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
        double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
        double[] arr_tot = new double[ds.Tables[0].Columns.Count];
        double gg = 0;
        int rcount = ds.Tables[0].Rows.Count;
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno = 0;
            StringBuilder tbl = new StringBuilder();
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr><td colspan=8 style='text-align:center' class='mis_hdr2'><b>" + compname + "</b></td></tr>");
            TBL.Append("<tr><td colspan=8 style='text-align:center' class='mis_hdr2'>&nbsp;&nbsp </td></tr>");
            TBL.Append("<tr><td style='text-align:center' class='mis_hdr2'><b>" + "Local/Combine Report" + "</b></td></tr>");
            TBL.Append("</table>");
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr>");
             if (rprttype == "1")
            {
                string reportype2 = "Branch Wise";
                TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            else
            {
                string reportype2 = "Printing Center Wise";
                TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Report Type : </b>" + " " + reportype2 + "</td>");
            }
            //TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Branch : </b>" + " " + branchname + "</td>");
            if (pub == "0")
            {

                TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Publication : </b>" + "All " + "</td>");
            }
            else
            {

                TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "Publication : </b>" + " " + pubname + "</td>");
            }


            if (ratetype == "D")
            {
                string ratetype2 = "LOCAL";
                TBL.Append("<td class='mis_hdr1'  align='right' width='10%'><b>" + "Rate Type : </b>" + " " + ratetype2 + "</td>");
            }
            else
            {
                string ratetype2 = "COMBINED";
                TBL.Append("<td class='mis_hdr1'  align='right' width='10%'><b>" + "Rate Type : </b>" + " " + ratetype2 + "</td>");
            }

            TBL.Append("</tr>");
            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' align='left' width='10%'><b>" + "From Date : </b>" + " " + frdt + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='left' width='10%'><b>" + "To Date : </b>" + " " + todt + "</td>");
            TBL.Append("<td class='mis_hdr1'  align='right' width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
           
            TBL.Append("</tr>");
            TBL.Append("</table>");

            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1'>");
            //for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            //{
            TBL.Append("<tr>");
            for (int v = 3; v < ds.Tables[0].Columns.Count; v++)
            {
                if (ds.Tables[0].Columns[v].ToString() == "PUB_CENT_NAME")
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='left' style='font-size:13px;'><b>" + ds.Tables[0].Columns[v].ToString() + "</b></td>");
                }
                else
                TBL.Append("<td  width='6%' class='quotationnam' align='right' style='font-size:13px;'><b>" + ds.Tables[0].Columns[v].ToString() + "</b></td>");
            }
            //TBL.Append("<td  width='10%' align='center'  style='padding-right:5px;'><b>TOTAL</b>");
            TBL.Append("</tr>");


            for (int z = 0; z < ds.Tables[0].Rows.Count; z++)
            {
                TBL.Append("<tr>");


                for (int v = 3; v < ds.Tables[0].Columns.Count; v++)
                {
                    if (ds.Tables[0].Columns[v].ToString() == "PUB_CENT_NAME")
                    {
                        TBL.Append("<td  width='6%' class='quotationnam' align='left' style='font-size:13px;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                    }
                    else
                        TBL.Append("<td  width='6%' class='quotationnam' align='right' style='font-size:13px;'>" + ds.Tables[0].Rows[z].ItemArray[v].ToString() + "</td>");
                }
                TBL.Append("</tr>");
                for (var x = 4; x < ds.Tables[0].Columns.Count; x++)
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




                TBL.Append("<tr>");
                TBL.Append("<td  align='left'  style='padding-right:5px;'><b>TOTAL</b>");
                for (var x = 4; x < ds.Tables[0].Columns.Count; x++)
                {
                    TBL.Append("<td  width='6%' class='quotationnam' align='right' center='font-size:13px;'><b>" + string.Format("{0:0.00}", arr_Grand[x]) + "</b></td>");
                    gg = 0;
                }
                TBL.Append("</tr>");



            }

              view.InnerHtml = TBL.ToString();
            hw.WriteBreak();
            view.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}
