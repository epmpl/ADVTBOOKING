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

public partial class consolidated_sch_reg_view : System.Web.UI.Page
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
    double Dtotgamt = 0, Dtotsur = 0, Dtotcomm = 0, Dtototh = 0, Dtotnet = 0;
    double Ctotgamt1 = 0, Ctotsur1 = 0, Ctotcomm1 = 0, Ctototh1 = 0, Ctotnet1 = 0;
    double GCtotgamt = 0, GCtotsur = 0, GCtotcomm = 0, GCtototh = 0, GCtotnet = 0;
    double totgamt1 = 0, totsur1 = 0, totcom1 = 0, tototh1 = 0, totnet1 = 0, totspace1 = 0, totrate1 = 0;
    double Atotgamt1 = 0, Atotsur1 = 0, Atotcomm1 = 0, Atototh1 = 0, Atotnet1 = 0;
    double GAtotgamt = 0, GAtotsur = 0, GAtotcomm = 0, GAtototh = 0, GAtotnet = 0;
    double Rtotgamt1 = 0, Rtotsur1 = 0, Rtotcomm1 = 0, Rtototh1 = 0, Rtotnet1 = 0;
    double GRtotgamt = 0, GRtotsur = 0, GRtotcomm = 0, GRtototh = 0, GRtotnet = 0;
    double Ptotgamt1 = 0, Ptotsur1 = 0, Ptotcomm1 = 0, Ptototh1 = 0, Ptotnet1 = 0;
    double GPtotgamt = 0, GPtotsur = 0, GPtotcomm = 0, GPtototh = 0, GPtotnet = 0;
    double Catotgamt1 = 0, Catotsur1 = 0, Catotcomm1 = 0, Catototh1 = 0, Catotnet1 = 0;
    double GCatotgamt = 0, GCatotsur = 0, GCatotcomm = 0, GCatototh = 0, GCatotnet = 0;
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
        agcd = Session["agcd"].ToString();
        agname = Session["agname"].ToString();
        clientcd = Session["clientcd"].ToString();
        clientnm = Session["clientnm"].ToString();
     
        extra1 = Session["extra1"].ToString();
        extra2 = Session["extra2"].ToString();
        extra3 = Session["extra3"].ToString();
        extra4 = Session["extra4"].ToString();
        extra5 = Session["extra5"].ToString();

        adcatNM = Session["adcatNM"].ToString();

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
            if (edtn == "--Select Edition Name--"||edtn =="0")
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

            string[] parameterValueArray = new string[] { compcode, branch, pub, edtn, agcd, adtype, fromdate1, todate1, hiddendateformat.Value, extra1, extra2, extra3, extra4, extra5 };
            string procedureName = "advt_consolidated_sch_regi_p";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else
        {
            //string procedureName = "cir_outst_addback_statement";
            //string[] parameterValueArray = new string[] {  compcode, hdnunit.Value, pub,agcd,dpcd, fromdate, hiddendateformat.Value,agtype,dist,userid,  extra1, extra2, extra3, extra4, extra5  };
            //Circulation.Classes.CommonClass exe = new Circulation.Classes.CommonClass();
            //ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
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



        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno = 1;
            StringBuilder tbl = new StringBuilder();
            TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Consolidate Schedule Register</td></tr>");
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
            
            pgn++;
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='10%'><b>" + "Agency Code" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='5%'><b>" + "Rate" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='10%'><b>" + "Gross Amt" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='9%'><b>" + "Bill Amt" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");

            TBL.Append("</tr>");

            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Control Date" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'><b>" + "Client Code" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Client Name" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'><b>" + "Special Ch" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'><b>" + "Trade Disc" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'><b>" + "Special Disc" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");

            TBL.Append("</tr>");


            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "City" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='10%'><b>" + "Ad Cat" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Ad SubCat" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Space Disc" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Prem Per" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='10%'><b>" + "Industry" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='9%'><b>" + "Product Cat" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Edition" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "HTxWT" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "PageNo." + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Scheduled Dt" + "</b></td>");
            TBL.Append("</tr>");
            rowcounter = rowcounter + 5;

           
            Find_branch = ds.Tables[0].Rows[0]["branch"].ToString();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (pgn == 1)
                {
                    maxlimit = maxlimit + 4;
                }

                if (rowcounter >= maxlimit)
                {
                    rowcounter = 0;

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        TBL.Append("</table></p>");
                        TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                        TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

                        TBL.Append("<tr>");
                        TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:15px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                        TBL.Append("</tr>");

                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='10%'><b>" + "Agency Code" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='5%'><b>" + "Rate" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='10%'><b>" + "Gross Amt" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='9%'><b>" + "Bill Amt" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");

                        TBL.Append("</tr>");

                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Control Date" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'><b>" + "Client Code" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Client Name" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'><b>" + "Special Ch" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'><b>" + "Trade Disc" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'><b>" + "Special Disc" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");

                        TBL.Append("</tr>");


                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "City" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='10%'><b>" + "Ad Cat" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Ad SubCat" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Space Disc" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Prem Per" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='10%'><b>" + "Industry" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='9%'><b>" + "Product Cat" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Edition" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "HTxWT" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "PageNo." + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Scheduled Dt" + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 5;
                        pgn++;
                    }
                }
                if (i == 0)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='3' style='text-align:Left;font-size:13px;' width='22%'><b>" + ds.Tables[0].Rows[i]["branch_nm"] + "</b></td>");
                    TBL.Append("</tr>");
                }

                else
                {
                    if (Find_branch.IndexOf(ds.Tables[0].Rows[i]["branch"].ToString()) < 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='6' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='53%'><b>" + "BRANCH TOTAL" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='10%'><b>" + string.Format("{0:0.00}", GAtotgamt) + "<b></td>");
                        Atotgamt1 = Atotgamt1 + GAtotgamt;
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='9%'><b>" + string.Format("{0:0.00}", GAtotnet) + "<b></td>");
                        Atotnet1 = Atotnet1 + GAtotnet;
                        TBL.Append("<td colspan='4' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>&nbsp;<b></td>");
                        TBL.Append("</tr>");
                        GAtotgamt = 0;
                        GAtotnet = 0;
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='3' style='text-align:Left;font-size:13px;' width='22%'><b>" + ds.Tables[0].Rows[i]["branch_nm"] + "</b></td>");
                        TBL.Append("</tr>");
                        Find_branch += ds.Tables[0].Rows[i]["branch"].ToString();
                       

                    }


                }

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["cio_booking_id"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + ds.Tables[0].Rows[i]["Agency_sub_code"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["Agency Name"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["Agrred_rate"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RO_No"].ToString() + "</td>");
                if (ds.Tables[0].Rows[i]["Gross_amount"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Gross_amount"].ToString()).ToString("f2") + "</td>");
                    GAtotgamt = GAtotgamt + Convert.ToDouble(ds.Tables[0].Rows[i]["Gross_amount"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Bill_amount"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_amount"].ToString()).ToString("f2") + "</td>");
                    GAtotnet = GAtotnet + Convert.ToDouble(ds.Tables[0].Rows[i]["Bill_amount"].ToString());
                }
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["booking_dt"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + ds.Tables[0].Rows[i]["Client_code"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["Client Name"].ToString() + "</td>");
                if (ds.Tables[0].Rows[i]["Special_charges"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Special_charges"].ToString()).ToString("f2") + "</td>");

                }
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["ro_dt"].ToString() + "</td>");
                if (ds.Tables[0].Rows[i]["Trade_disc"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Trade_disc"].ToString()).ToString("f2") + "</td>");

                }
                if (ds.Tables[0].Rows[i]["Special_discount"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Special_discount"].ToString()).ToString("f2") + "</td>");

                }
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["City Name"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + ds.Tables[0].Rows[i]["Ad Cat"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["AdSub Cat"].ToString() + "</td>");
                if (ds.Tables[0].Rows[i]["Space_discount"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Space_discount"].ToString()).ToString("f2") + "</td>");

                }
                if (ds.Tables[0].Rows[i]["Prem_per"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + "0.00" + "</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Prem_per"].ToString()).ToString("f2") + "</td>");

                }
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='10%'>" + ds.Tables[0].Rows[i]["Industry"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='9%'>" + ds.Tables[0].Rows[i]["Product Cat"].ToString() + "</td>");

                for (int j = 0; j <= ds.Tables[1].Rows.Count - 1; j++)
                {
                    
                    if (ds.Tables[1].Rows[j]["Cio_Booking_Id"].ToString() == ds.Tables[0].Rows[i]["cio_booking_id"].ToString())
                    {
                        //if (bookingid.IndexOf(ds.Tables[1].Rows[j]["Cio_Booking_Id"].ToString()) < 0)
                        //{
                        //    TBL.Append("<tr font-family='Arial'>");
                        //    TBL.Append("<td colspan='8' style='text-align:Left;font-size:11px;' width='72%'><b>&nbsp;</b></td>");
                        //    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + ds.Tables[1].Rows[j]["Edition"].ToString() + "</b></td>");
                        //    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + ds.Tables[1].Rows[j]["Height"].ToString() + "<b>x</b>" + ds.Tables[1].Rows[j]["Width"].ToString() + "</b></td>");
                        //    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + ds.Tables[1].Rows[j]["Page_No"].ToString() + "</b></td>");
                        //    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + ds.Tables[1].Rows[j]["publish_dt"].ToString() + "</b></td>");
                        //    TBL.Append("</tr>");
                        //    bookingid += ds.Tables[1].Rows[j]["Cio_Booking_Id"].ToString();
                        //}
                        //else
                        //{
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='8' style='text-align:Left;font-size:11px;black;' width='72%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;black;border-bottom:dashed 1px black;' width='7%'><b>" + ds.Tables[1].Rows[j]["Edition"].ToString() + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;black;border-bottom:dashed 1px black;' width='7%'><b>" + ds.Tables[1].Rows[j]["Height"].ToString() + "<b>x</b>" + ds.Tables[1].Rows[j]["Width"].ToString() + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;black;border-bottom:dashed 1px black;' width='7%'><b>" + ds.Tables[1].Rows[j]["Page_No"].ToString() + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;black;border-bottom:dashed 1px black;' width='7%'><b>" + ds.Tables[1].Rows[j]["publish_dt"].ToString() + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 5;
                        
                       // bookingid += ds.Tables[1].Rows[j]["Cio_Booking_Id"].ToString();
                    }
                }
                TBL.Append("</tr>");
                sno++;
                Find_branch += ds.Tables[0].Rows[i]["branch"].ToString();
            }

            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='6' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='53%'><b>" + "BRANCH TOTAL" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='10%'><b>" + string.Format("{0:0.00}", GAtotgamt) + "<b></td>");
            Atotgamt1 = Atotgamt1 + GAtotgamt;
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='9%'><b>" + string.Format("{0:0.00}", GAtotnet) + "<b></td>");
            Atotnet1 = Atotnet1 + GAtotnet;
            TBL.Append("<td colspan='4' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>&nbsp;<b></td>");
            TBL.Append("</tr>");

            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='6' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='53%'><b>" + "GRAND TOTAL" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='10%'><b>" + string.Format("{0:0.00}", Atotgamt1) + "<b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='9%'><b>" + string.Format("{0:0.00}", Atotnet1) + "<b></td>");
            TBL.Append("<td colspan='4' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>&nbsp;<b></td>");
           

            TBL.Append("</tr>");
            rowcounter = rowcounter + 2;
          
        }
        TBL.Append("</table>");
        TBL.Append("</table></p>");
            report.InnerHtml = TBL.ToString();
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