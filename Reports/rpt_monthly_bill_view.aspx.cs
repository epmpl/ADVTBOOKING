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
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

public partial class Reports_rpt_monthly_bill_view : System.Web.UI.Page
{
    string compcode = "";

    string branch = "";
    string fromdate = "";
    string todate = "";
    string currentdate = "";
    string todate1 = "";
    string fromdate1 = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string compname = "";
    string pubname = "";
    string dist = "";
    string centermame = "";
    string dest = "";
    string reptype = "";
    string pub = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string DATEFORMAT = "";
    string userid = "";
    string amnt = "";
    string unit = "";
    string agtype = "";
    string agclass = "";
    string adcat = "";
    string adtype = "";
    string agtypenm = "";
    string edtn = "";
    string region = "";
    string adsubcat5 = "";
    string execode = "";
    string adsubcat = "";
    string adsubcat3 = "";
    string adsubcat4 = "";
    string edtnnm = "";
    string agcd = "";
    string dpcd = "";
    string pcent = "";
    string agcat = "";
    string executiveCd = "";
    string product = "";
    string exename = "";
    string agname = "";
    string clientcd = "";
    string clientnm = "";
    string bookingid = "";
    string billtype = "";
    string req_parent_child = "";
    string paymode = "";
    string extra12 = "";
    string extra14 = "";
    string extra15 = "";
    string teamcode = "";
    string adcatNM = "";
    string branch_nm = "";
    string pub_nm = "";

    int maxlimit = 40;
    int area = 0;
    int i1 = 0;
    double amt_u = 0;
    double amt_t = 0;
    double amt_s = 0;
    double amt_0 = 0;
    double camt_1 = 0;
    double camt_2 = 0;
    string last_comm = "";
    string last_edtn = "";
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
    string Find_branch = "";
    string Find_agency = "";
    string Find_Client = "";
    string Find_Region = "";
    string Find_Product = "";
    string Find_category = "";
    double jan = 0, feb = 0, mar = 0, apr = 0, may = 0, june = 0, july = 0, aug = 0, sept = 0, oct = 0, nov = 0, dec = 0, total = 0;
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

        hdncompcode.Value = Session["compcode"].ToString();
        compname = Session["comp_name"].ToString();
        compcode = Session["compcode"].ToString();
        pcent = Session["pcent"].ToString();
        branch = Session["branch"].ToString();
        fromdate = Session["fromdate"].ToString();
        todate = Session["todate"].ToString();
        fromdate1 = Session["fromdate"].ToString();
        todate1 = Session["todate"].ToString();
        pub = Session["pub"].ToString();
        edtn = Session["edtn"].ToString();
        adcat = Session["adcat"].ToString();
        adtype = Session["adtype"].ToString();
        dest = Session["dest"].ToString();
        centermame = Session["centername"].ToString();
        hdnunit.Value = Session["center"].ToString();
        agtype = Session["agtype"].ToString();
        dist = Session["dist"].ToString();
        reptype = Session["reptype"].ToString();

        extra1 = Session["extra1"].ToString();
        extra2 = Session["extra2"].ToString();
        extra3 = Session["extra3"].ToString();
        extra4 = Session["extra4"].ToString();
        extra5 = Session["extra5"].ToString();


        adcatNM = Session["adcatNM"].ToString();
        branch_nm = Session["branch_nm"].ToString();
        pub_nm = Session["pub_nm"].ToString();

        DateTime dt = System.DateTime.Now;
        if (hiddendateformat.Value == "dd/mm/yyyy")
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
        else if (hiddendateformat.Value == "dd/mm/yyyy")
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
        if (hiddendateformat.Value == "dd/mm/yyyy")
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

        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            string[] arr = fromdate.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            //fromdate1 = mm + "/" + dd + "/" + yy;
            fromdate = dd + "/" + mm + "/" + yy;
        }


        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            string[] arr = todate.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            //todate1 = mm + "/" + dd + "/" + yy;
            todate = dd + "/" + mm + "/" + yy;
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
            if (edtn == "--Select Edition Name--" || edtn == "0")
            {
                edtn = "";
            }
            if (pub == "0")
            {
                pub = "";
            }
            if (branch == "0")
            {
                branch = "";
            }
            if (adtype == "0")
            {
                adtype = "";
            }

            if (extra3 == "0")
            {
                extra3 = "";
            }
            if (adcat == "0" || adcat == "Select AdCat")
            {
                adcat = "";
            }
            if (adsubcat == "0" || adsubcat == "Select AdSubCat")
            {
                adsubcat = "";
            }
            //btnprint.Focus();
            btnprint.Attributes.Add("onclick", "javascript:return forclick();");
            if (dest == "1" || dest == "2")
            {

                onscreen();

            }

        }
    }

    private void onscreen()
    {
        string find_dist = "";
        string find_agcode = "";
        DataSet ds = new DataSet();


        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {

            string[] parameterValueArray = new string[] { compcode, pcent, branch, pub, edtn, agtype, adtype, dist, fromdate1, todate1, hiddendateformat.Value, reptype, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "RPT_DIST_MONWISE_P";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {

            string[] parameterValueArray = new string[] { compcode, pcent, branch, pub, edtn, agtype, adtype, dist, fromdate1, todate1, hiddendateformat.Value, reptype, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "RPT_DIST_MONWISE_P";
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
        //int rcount = ds.Tables[0].Rows.Count;
        //int ct = 0;
        //int fr = maxlimit;
        //int pagec = rcount % maxlimit;
        //int pagecount = rcount / maxlimit;
        //if (pagec > 0)
        //    pagecount = pagecount + 1;


     if(reptype=="D"){

        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno = 1;
            StringBuilder tbl = new StringBuilder();
            TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>District Wise Monthly Billing Report</td></tr>");
            TBL.Append("</table>");


            int i1 = 1;

            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' colspan='10'  align='center' style='font-size:15px; '><b>" + " From Date :" + " " + fromdate + "-" + "To Date:" + todate + "</b></td>");
            TBL.Append("</tr>");

            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
            TBL.Append("</tr>");

            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Center Name :</b>" + " " + centermame + "</td>");
            TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
            TBL.Append("</tr>");

            TBL.Append("<tr>");
            if (branch_nm == "")
            {
                TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + "All" + "</td>");
            }
            else
            {
                TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + branch_nm + "</td>");
            }
            if (pub_nm == "")
            {
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + "All" + "</td>");
            }
            else
            {
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + pub_nm + "</td>");
            }
            TBL.Append("</tr>");

            TBL.Append("<tr>");
            if (adcatNM == "")
            {
                TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + "All" + "</td>");
            }
            else
            {
                TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + adcatNM + "</td>");
            }
            //if (pub_nm == "")
            //{
            //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
            //}
            //else
            //{
            //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + pub_nm + "</td>");
            //}
            TBL.Append("</tr>");
            TBL.Append("</table>");
            pgn++;
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='2%'><b>" + "Sno" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "District" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "APR" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAY" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUN" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUL" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "AUG" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "SEP" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "OCT" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "NOV" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "DEC" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JAN" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "FEB" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAR" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "TOTAL" + "</b></td>");
            TBL.Append("</tr>");

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;' width='2%'>" + sno + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["District_Name"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString()).ToString("f2") + "</td>");
                apr = apr + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString()).ToString("f2") + "</td>");
                may = may + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString()).ToString("f2") + "</td>");
                june = june + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString()).ToString("f2") + "</td>");
                july = july + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString()).ToString("f2") + "</td>");
                aug = aug + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString()).ToString("f2") + "</td>");
                sept = sept + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString()).ToString("f2") + "</td>");
                oct = oct + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString()).ToString("f2") + "</td>");
                nov = nov + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString()).ToString("f2") + "</td>");
                dec = dec + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString()).ToString("f2") + "</td>");
                jan = jan + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString()).ToString("f2") + "</td>");
                feb = feb + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString()).ToString("f2") + "</td>");
                mar = mar + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString());
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString()).ToString("f2") + "</td>");
                total = total + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString());
                sno++;

            }

            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='2' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='9%'><b>" + "Grand Total" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", apr) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", may) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", june) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", july) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", aug) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", sept) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", oct) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", nov) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", dec) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", jan) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", feb) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", mar) + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", total) + "</b></td>");
            TBL.Append("</tr>");
           
            TBL.Append("</table>");
            report.InnerHtml = TBL.ToString();
        }
     }

        else if (reptype == "A")
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Agency Type Wise Monthly Billing Report</td></tr>");
                TBL.Append("</table>");


                int i1 = 1;

                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

                TBL.Append("<tr>");
                TBL.Append("<td class='mis_hdr1' colspan='10'  align='center' style='font-size:15px; '><b>" + " From Date :" + " " + fromdate + "-" + "To Date:" + todate + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Center Name :</b>" + " " + centermame + "</td>");
                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
                TBL.Append("</tr>");

                TBL.Append("<tr>");
                if (branch_nm == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + branch_nm + "</td>");
                }
                if (pub_nm == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + pub_nm + "</td>");
                }
                TBL.Append("</tr>");
                TBL.Append("<tr>");
                if (adcatNM == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + adcatNM + "</td>");
                }
                //if (exename == "")
                //{
                //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                //}
                //else
                //{
                //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                //}
                TBL.Append("</tr>");
                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='2%'><b>" + "Sno" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "Agency Type" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "APR" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAY" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUN" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "AUG" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "SEP" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "OCT" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "NOV" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "DEC" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JAN" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "FEB" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAR" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "TOTAL" + "</b></td>");
                TBL.Append("</tr>");

                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;' width='2%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["agtype"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString()).ToString("f2") + "</td>");
                    apr = apr + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString()).ToString("f2") + "</td>");
                    may = may + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString()).ToString("f2") + "</td>");
                    june = june + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString()).ToString("f2") + "</td>");
                    july = july + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString()).ToString("f2") + "</td>");
                    aug = aug + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString()).ToString("f2") + "</td>");
                    sept = sept + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString()).ToString("f2") + "</td>");
                    oct = oct + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString()).ToString("f2") + "</td>");
                    nov = nov + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString()).ToString("f2") + "</td>");
                    dec = dec + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString()).ToString("f2") + "</td>");
                    jan = jan + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString()).ToString("f2") + "</td>");
                    feb = feb + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString()).ToString("f2") + "</td>");
                    mar = mar + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString()).ToString("f2") + "</td>");
                    total = total + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString());
                    sno++;

                }

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='9%'><b>" + "Grand Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", apr) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", may) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", june) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", july) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", aug) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", sept) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", oct) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", nov) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", dec) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", jan) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", feb) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", mar) + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", total) + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("</table>");
                report.InnerHtml = TBL.ToString();
            }
        }

     else if (reptype == "C")
     {

         if (ds.Tables[0].Rows.Count > 0)
         {
             int sno = 1;
             StringBuilder tbl = new StringBuilder();
             TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
             TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
             TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Wise Monthly Billing Report</td></tr>");
             TBL.Append("</table>");


             int i1 = 1;

             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='10'  align='center' style='font-size:15px; '><b>" + " From Date :" + " " + fromdate + "-" + "To Date:" + todate + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Center Name :</b>" + " " + centermame + "</td>");
             TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
             TBL.Append("</tr>");
             TBL.Append("<tr>");
             if (branch_nm == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + branch_nm + "</td>");
             }
             if (pub_nm == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + pub_nm + "</td>");
             }
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             if (adcatNM == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + adcatNM + "</td>");
             }
             //if (exename == "")
             //{
             //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
             //}
             //else
             //{
             //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
             //}
             TBL.Append("</table>");
             pgn++;
             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
             TBL.Append("<tr font-family='Arial'>");
             TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='2%'><b>" + "Sno" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "Ad Category" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "APR" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAY" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUN" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUL" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "AUG" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "SEP" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "OCT" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "NOV" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "DEC" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JAN" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "FEB" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAR" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "TOTAL" + "</b></td>");
             TBL.Append("</tr>");

             for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
             {
                 TBL.Append("<tr font-family='Arial'>");
                 TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;' width='2%'>" + sno + "</td>");
                 TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["adcat"].ToString() + "</td>");
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString()).ToString("f2") + "</td>");
                 apr = apr + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString()).ToString("f2") + "</td>");
                 may = may + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString()).ToString("f2") + "</td>");
                 june = june + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString()).ToString("f2") + "</td>");
                 july = july + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString()).ToString("f2") + "</td>");
                 aug = aug + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString()).ToString("f2") + "</td>");
                 sept = sept + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString()).ToString("f2") + "</td>");
                 oct = oct + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString()).ToString("f2") + "</td>");
                 nov = nov + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString()).ToString("f2") + "</td>");
                 dec = dec + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString()).ToString("f2") + "</td>");
                 jan = jan + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString()).ToString("f2") + "</td>");
                 feb = feb + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString()).ToString("f2") + "</td>");
                 mar = mar + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString()).ToString("f2") + "</td>");
                 total = total + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString());
                 sno++;

             }

             TBL.Append("<tr font-family='Arial'>");
             TBL.Append("<td colspan='2' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='9%'><b>" + "Grand Total" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", apr) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", may) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", june) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", july) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", aug) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", sept) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", oct) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", nov) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", dec) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", jan) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", feb) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", mar) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", total) + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("</table>");
             report.InnerHtml = TBL.ToString();
         }
     }
     else if (reptype == "E")
     {

         if (ds.Tables[0].Rows.Count > 0)
         {
             int sno = 1;
             StringBuilder tbl = new StringBuilder();
             TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
             TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
             TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Edition Wise Monthly Billing Report</td></tr>");
             TBL.Append("</table>");


             int i1 = 1;

             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='10'  align='center' style='font-size:15px; '><b>" + " From Date :" + " " + fromdate + "-" + "To Date:" + todate + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Center Name :</b>" + " " + centermame + "</td>");
             TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             if (branch_nm == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + branch_nm + "</td>");
             }
             if (pub_nm == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + pub_nm + "</td>");
             }
             TBL.Append("</tr>");
             TBL.Append("<tr>");
             if (adcatNM == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + adcatNM + "</td>");
             }
             //if (exename == "")
             //{
             //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
             //}
             //else
             //{
             //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
             //}
             TBL.Append("</tr>");
             TBL.Append("</table>");
             pgn++;
             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
             TBL.Append("<tr font-family='Arial'>");
             TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='2%'><b>" + "Sno" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "Edition" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "APR" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAY" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUN" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUL" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "AUG" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "SEP" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "OCT" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "NOV" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "DEC" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JAN" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "FEB" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAR" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "TOTAL" + "</b></td>");
             TBL.Append("</tr>");

             for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
             {
                 TBL.Append("<tr font-family='Arial'>");
                 TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;' width='2%'>" + sno + "</td>");
                 TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["edition_name"].ToString() + "</td>");
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString()).ToString("f2") + "</td>");
                 apr = apr + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString()).ToString("f2") + "</td>");
                 may = may + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString()).ToString("f2") + "</td>");
                 june = june + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString()).ToString("f2") + "</td>");
                 july = july + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString()).ToString("f2") + "</td>");
                 aug = aug + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString()).ToString("f2") + "</td>");
                 sept = sept + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString()).ToString("f2") + "</td>");
                 oct = oct + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString()).ToString("f2") + "</td>");
                 nov = nov + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString()).ToString("f2") + "</td>");
                 dec = dec + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString()).ToString("f2") + "</td>");
                 jan = jan + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString()).ToString("f2") + "</td>");
                 feb = feb + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString()).ToString("f2") + "</td>");
                 mar = mar + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString()).ToString("f2") + "</td>");
                 total = total + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString());
                 sno++;

             }

             TBL.Append("<tr font-family='Arial'>");
             TBL.Append("<td colspan='2' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='9%'><b>" + "Grand Total" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", apr) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", may) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", june) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", july) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", aug) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", sept) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", oct) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", nov) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", dec) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", jan) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", feb) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", mar) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", total) + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("</table>");
             report.InnerHtml = TBL.ToString();
         }
     }
     else 
     {

         if (ds.Tables[0].Rows.Count > 0)
         {
             int sno = 1;
             StringBuilder tbl = new StringBuilder();
             TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
             TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
             TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Region Wise Monthly Billing Report</td></tr>");
             TBL.Append("</table>");


             int i1 = 1;

             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='10'  align='center' style='font-size:15px; '><b>" + " From Date :" + " " + fromdate + "-" + "To Date:" + todate + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Center Name :</b>" + " " + centermame + "</td>");
             TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Run Date :</b>" + " " + currentdate + "</td>");
             TBL.Append("</tr>");

             TBL.Append("<tr>");
             if (branch_nm == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Branch Name :</b>" + " " + branch_nm + "</td>");
             }
             if (pub_nm == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Publication :</b>" + " " + pub_nm + "</td>");
             }
             TBL.Append("</tr>");
             TBL.Append("<tr>");
             if (adcatNM == "")
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + "All" + "</td>");
             }
             else
             {
                 TBL.Append("<td class='mis_hdr1' colspan='5' align='left'style='font-size:15px;'width='10%'><b>" + "Ad Category Name :</b>" + " " + adcatNM + "</td>");
             }
             //if (exename == "")
             //{
             //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
             //}
             //else
             //{
             //    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
             //}
             TBL.Append("</table>");
             pgn++;
             TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
             TBL.Append("<tr font-family='Arial'>");
             TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='2%'><b>" + "Sno" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "Region" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "APR" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAY" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUN" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JUL" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "AUG" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "SEP" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "OCT" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "NOV" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "DEC" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "JAN" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "FEB" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "MAR" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + "TOTAL" + "</b></td>");
             TBL.Append("</tr>");

             for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
             {
                 TBL.Append("<tr font-family='Arial'>");
                 TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;' width='2%'>" + sno + "</td>");
                 TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["region"].ToString() + "</td>");
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString()).ToString("f2") + "</td>");
                 apr = apr + Convert.ToDouble(ds.Tables[0].Rows[i]["APR"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString()).ToString("f2") + "</td>");
                 may = may + Convert.ToDouble(ds.Tables[0].Rows[i]["MAY"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString()).ToString("f2") + "</td>");
                 june = june + Convert.ToDouble(ds.Tables[0].Rows[i]["JUN"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString()).ToString("f2") + "</td>");
                 july = july + Convert.ToDouble(ds.Tables[0].Rows[i]["JUL"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString()).ToString("f2") + "</td>");
                 aug = aug + Convert.ToDouble(ds.Tables[0].Rows[i]["AUG"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString()).ToString("f2") + "</td>");
                 sept = sept + Convert.ToDouble(ds.Tables[0].Rows[i]["SEP"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString()).ToString("f2") + "</td>");
                 oct = oct + Convert.ToDouble(ds.Tables[0].Rows[i]["OCT"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString()).ToString("f2") + "</td>");
                 nov = nov + Convert.ToDouble(ds.Tables[0].Rows[i]["NOV"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString()).ToString("f2") + "</td>");
                 dec = dec + Convert.ToDouble(ds.Tables[0].Rows[i]["DEC"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString()).ToString("f2") + "</td>");
                 jan = jan + Convert.ToDouble(ds.Tables[0].Rows[i]["JAN"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString()).ToString("f2") + "</td>");
                 feb = feb + Convert.ToDouble(ds.Tables[0].Rows[i]["FEB"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString()).ToString("f2") + "</td>");
                 mar = mar + Convert.ToDouble(ds.Tables[0].Rows[i]["MAR"].ToString());
                 TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString()).ToString("f2") + "</td>");
                 total = total + Convert.ToDouble(ds.Tables[0].Rows[i]["TOTAL"].ToString());
                 sno++;

             }

             TBL.Append("<tr font-family='Arial'>");
             TBL.Append("<td colspan='2' style='text-align:Left;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='9%'><b>" + "Grand Total" + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", apr) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", may) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", june) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", july) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", aug) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", sept) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", oct) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", nov) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", dec) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", jan) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", feb) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", mar) + "</b></td>");
             TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-bottom:solid 1px black;border-top:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", total) + "</b></td>");
             TBL.Append("</tr>");

             TBL.Append("</table>");
             report.InnerHtml = TBL.ToString();
         }
     }
            if (dest == "2")
            {
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment; filename=exls.xls");

                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                report.InnerHtml = TBL.ToString();
                report.Visible = true;
                report.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

    }
