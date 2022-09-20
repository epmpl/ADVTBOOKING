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

public partial class rpt_invoice_register : System.Web.UI.Page
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
    string brkon = "";
    string billtype = "";
    string req_parent_child = "";
    string paymode = "";
    string extra12 = "";
    string extra14 = "";
    string extra15 = "";
    string teamcode = "";
    string adcatNM = "";
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
    int no_ins = 0;
    int Gno_ins = 0;
    int size = 0;
    int Gsize = 0;
    int pagec;
    int pagecount;
    static int ab = 0;
    static int b = 4;
    static int k;
    static int l;
    string Find_date = "";
    string Find_agency = "";
    string Find_Client = "";
    string Find_Region = "";
    string Find_Product = "";
    string Find_category = "";
    string Find_category_sum = "";
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
        region = Session["region"].ToString();
        adcat = Session["adcat"].ToString();
        adtype = Session["adtype"].ToString();
        dest = Session["dest"].ToString();
        dist = Session["dist"].ToString();
        agcat = Session["agcat"].ToString();
        centermame = Session["centername"].ToString();
        adsubcat = Session["adsubcat"].ToString();
        userid = Session["userid"].ToString();
        hdnunit.Value = Session["center"].ToString();
        executiveCd = Session["executiveCd"].ToString();
        product = Session["product"].ToString();
        agtype = Session["agtype"].ToString();
        exename = Session["exename"].ToString();
        agcd = Session["agcd"].ToString();
        agname = Session["agname"].ToString();
        clientcd = Session["clientcd"].ToString();
        clientnm = Session["clientnm"].ToString();
        pcent = Session["pcent"].ToString();
        brkon = Session["brkon"].ToString();
        billtype = Session["billtype"].ToString();
        req_parent_child = Session["req_parent_child"].ToString();
        paymode = Session["paymode"].ToString();


        extra4 = Session["extra4"].ToString();
        extra5 = Session["extra5"].ToString();
        extra12 = Session["extra12"].ToString();
        extra14 = Session["extra14"].ToString();
        extra15 = Session["extra15"].ToString();
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
            if (edtn == "--Select Edition Name--")
            {
                edtn = "";
            }
            if (pcent == "0")
            {
                pcent = "";
            }
            if (pub == "0")
            {
                pub = "";
            }
            if (branch == "0")
            {
                branch = "";
            }
            if (dist == "0")
            {
                dist = "";
            }
            if (adtype == "0")
            {
                adtype = "";
            }
            if (region == "0")
            {
                region = "";
            }
            if (extra3 == "0")
            {
                extra3 = "";
            }
            if (agtype == "0")
            {
                agtype = "";
            }
            if (agcat == "0")
            {
                agcat = "";
            }
            if (adcat == "0" || adcat == "Select AdCat")
            {
                adcat = "";
            }
            if (adsubcat == "0" || adsubcat == "Select AdSubCat")
            {
                adsubcat = "";
            }
            if (product == "0")
            {
                product = "";
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

            string[] parameterValueArray = new string[] { compcode, "", fromdate1, todate1, agcd, pcent, executiveCd, "", branch, hiddendateformat.Value, billtype, userid, brkon, agtype, extra4, extra5, req_parent_child, paymode, clientcd, region, agcat, adcat, adsubcat, product, extra12, dist, extra14, extra15, pub };
            string procedureName = "rpt_billregister.rpt_billregister_p";
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

        ///////////////////Date wise//////////////
        if (brkon == "D")
        {



            ///////////////////////////////////////////

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Date Wise Invoice Register</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                rowcounter = rowcounter + 5;
                Find_date = ds.Tables[0].Rows[0]["BILDT"].ToString();
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
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Date Wise Invoice Register</td></tr>");
                            TBL.Append("</table>");




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
                            if (exename == "")
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                            }
                            else
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                            }
                            TBL.Append("</tr>");

                            TBL.Append("</table>");
                            pgn++;
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");

                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");

                            rowcounter = rowcounter + 5;
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Bill Date:-" + ds.Tables[0].Rows[i]["BILDT"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_date.IndexOf(ds.Tables[0].Rows[i]["BILDT"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='55%'><b>" + "Date Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totgamt1) + "<b></td>");
                            Dtotgamt = Dtotgamt + totgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totsur1) + "<b></td>");
                            Dtotsur = Dtotsur + totsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totcom1) + "<b></td>");
                            Dtotcomm = Dtotcomm + totcom1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", tototh1) + "<b></td>");
                            Dtototh = Dtototh + tototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totnet1) + "<b></td>");
                            Dtotnet = Dtotnet + totnet1;
                            TBL.Append("</tr>");
                            Find_date += ds.Tables[0].Rows[i]["BILDT"].ToString();
                            totgamt1 = 0; totsur1 = 0; totcom1 = 0; tototh1 = 0; totnet1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Bill Date:-" + ds.Tables[0].Rows[i]["BILDT"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }


                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILNO"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["IDNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RONUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Size"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_rate"].ToString()).ToString("f2") + "</td>");
                    if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()).ToString("f2") + "</td>");
                        totgamt1 = totgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        totsur1 = totsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        totcom1 = totcom1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        tototh1 = tototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString()).ToString("f2") + "</td>");
                        totnet1 = totnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }
                    TBL.Append("</tr>");


                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILDT"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["BOOKING_DATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RODATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["INSNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'>" + ds.Tables[0].Rows[i]["CLIENTNAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>" + ds.Tables[0].Rows[i]["ins_date"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    Find_date += ds.Tables[0].Rows[i]["BILDT"].ToString();
                    sno++;
                    rowcounter = rowcounter + 5;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='55%'><b>" + "Date Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totgamt1) + "<b></td>");
                Dtotgamt = Dtotgamt + totgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totsur1) + "<b></td>");
                Dtotsur = Dtotsur + totsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totcom1) + "<b></td>");
                Dtotcomm = Dtotcomm + totcom1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", tototh1) + "<b></td>");
                Dtototh = Dtototh + tototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totnet1) + "<b></td>");
                Dtotnet = Dtotnet + totnet1;
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='18%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + "GRAND TOTAL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Dtotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Dtotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Dtotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Dtototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Dtotnet) + "<b></td>");

                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
            }

            TBL.Append("</table>");
            TBL.Append("</table></p>");
        }//////Date wise













////////////////////////////////////////////////









////////////////Agency Eise

        else if (brkon == "A")
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Agency Wise Invoice Register</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                rowcounter = rowcounter + 5;
                Find_agency = ds.Tables[0].Rows[0]["BK_AGENCY_NAME"].ToString();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (pgn == 1)
                        {
                            maxlimit = maxlimit + 4;
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {


                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Agency Wise Invoice Register</td></tr>");
                            TBL.Append("</table>");




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
                            if (exename == "")
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                            }
                            else
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                            }
                            TBL.Append("</tr>");

                            TBL.Append("</table>");

                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");

                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");
                            pgn++;
                            rowcounter = rowcounter + 5;
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Agency:-" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"] + "," + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "," + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_agency.IndexOf(ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='6' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='47%'><b>" + "Agency Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotgamt1) + "<b></td>");
                            GAtotgamt = GAtotgamt + Atotgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotsur1) + "<b></td>");
                            GAtotsur = GAtotsur + Atotsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotcomm1) + "<b></td>");
                            GAtotcomm = GAtotcomm + Atotcomm1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atototh1) + "<b></td>");
                            GAtototh = GAtototh + Atototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotnet1) + "<b></td>");
                            GAtotnet = GAtotnet + Atotnet1;
                            TBL.Append("</tr>");
                            Find_agency += ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString();
                            Atotgamt1 = 0; Atotsur1 = 0; Atotcomm1 = 0; Atototh1 = 0; Atotnet1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Agency:-" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"] + "," + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "," + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }


                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILNO"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["IDNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RONUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Size"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_rate"].ToString()).ToString("f2") + "</td>");
                    if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()).ToString("f2") + "</td>");
                        Atotgamt1 = Atotgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        Atotsur1 = Atotsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        Atotcomm1 = Atotcomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        Atototh1 = Atototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString()).ToString("f2") + "</td>");
                        Atotnet1 = Atotnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }
                    TBL.Append("</tr>");


                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILDT"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["BOOKING_DATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RODATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["INSNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'>" + ds.Tables[0].Rows[i]["CLIENTNAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>" + ds.Tables[0].Rows[i]["ins_date"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");
                    Find_agency += ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString();
                    sno++;
                    rowcounter = rowcounter + 5;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='6' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='47%'><b>" + "Agency Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotgamt1) + "<b></td>");
                GAtotgamt = GAtotgamt + Atotgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotsur1) + "<b></td>");
                GAtotsur = GAtotsur + Atotsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotcomm1) + "<b></td>");
                GAtotcomm = GAtotcomm + Atotcomm1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atototh1) + "<b></td>");
                GAtototh = GAtototh + Atototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Atotnet1) + "<b></td>");
                GAtotnet = GAtotnet + Atotnet1;
                TBL.Append("</tr>");
                TBL.Append("</tr>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + "GRAND TOTAL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GAtotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GAtotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GAtotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GAtototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GAtotnet) + "<b></td>");

                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
            }

            TBL.Append("</table>");
            TBL.Append("</table></p>");
        }//////Agency wise


///////Client Wise
        else if (brkon == "C")
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Client Wise Invoice Register</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                rowcounter = rowcounter + 5;
                Find_Client = ds.Tables[0].Rows[0]["CLIENTNAME"].ToString();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (pgn == 1)
                        {
                            maxlimit = maxlimit + 4;
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {


                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Client Wise Invoice Register</td></tr>");
                            TBL.Append("</table>");




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
                            if (exename == "")
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                            }
                            else
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                            }
                            TBL.Append("</tr>");

                            TBL.Append("</table>");

                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");

                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");
                            pgn++;
                            rowcounter = rowcounter + 5;
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Client:-" + ds.Tables[0].Rows[i]["CLIENTNAME"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_Client.IndexOf(ds.Tables[0].Rows[i]["CLIENTNAME"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Client Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotgamt1) + "<b></td>");
                            GCtotgamt = GCtotgamt + Ctotgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotsur1) + "<b></td>");
                            GCtotsur = GCtotsur + Ctotsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotcomm1) + "<b></td>");
                            GCtotcomm = GCtotcomm + Ctotcomm1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctototh1) + "<b></td>");
                            GCtototh = GCtototh + Ctototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotnet1) + "<b></td>");
                            GCtotnet = GCtotnet + Ctotnet1;
                            TBL.Append("</tr>");
                            Find_Client += ds.Tables[0].Rows[i]["CLIENTNAME"].ToString();
                            Ctotgamt1 = 0; Ctotsur1 = 0; Ctotcomm1 = 0; Ctototh1 = 0; Ctotnet1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Client:-" + ds.Tables[0].Rows[i]["CLIENTNAME"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }


                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILNO"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["IDNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RONUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Size"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_rate"].ToString()).ToString("f2") + "</td>");
                    if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()).ToString("f2") + "</td>");
                        Ctotgamt1 = Ctotgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        Ctotsur1 = Ctotsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        Ctotcomm1 = Ctotcomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        Ctototh1 = Ctototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString()).ToString("f2") + "</td>");
                        Ctotnet1 = Ctotnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }
                    TBL.Append("</tr>");


                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILDT"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["BOOKING_DATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RODATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["INSNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>" + ds.Tables[0].Rows[i]["ins_date"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");
                    Find_Client += ds.Tables[0].Rows[i]["CLIENTNAME"].ToString();
                    sno++;
                    rowcounter = rowcounter + 5;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Client Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotgamt1) + "<b></td>");
                GCtotgamt = GCtotgamt + Ctotgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotsur1) + "<b></td>");
                GCtotsur = GCtotsur + Ctotsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotcomm1) + "<b></td>");
                GCtotcomm = GCtotcomm + Ctotcomm1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctototh1) + "<b></td>");
                GCtototh = GCtototh + Ctototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ctotnet1) + "<b></td>");
                GCtotnet = GCtotnet + Ctotnet1;
                TBL.Append("</tr>");
                TBL.Append("</tr>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='18%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + "GRAND TOTAL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCtotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCtotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCtotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCtototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCtotnet) + "<b></td>");

                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
            }

            TBL.Append("</table>");
            TBL.Append("</table></p>");
        }//////Client wise

            //////////Region

        else if (brkon == "R")
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Region Wise Invoice Register</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                rowcounter = rowcounter + 5;
                Find_Region = ds.Tables[0].Rows[0]["REGION_NAME"].ToString();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (pgn == 1)
                        {
                            maxlimit = maxlimit + 4;
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {


                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Region Wise Invoice Register</td></tr>");
                            TBL.Append("</table>");




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
                            if (exename == "")
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                            }
                            else
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                            }
                            TBL.Append("</tr>");

                            TBL.Append("</table>");

                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");

                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");
                            pgn++;
                            rowcounter = rowcounter + 5;
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Region:-" + ds.Tables[0].Rows[i]["REGION_NAME"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_Region.IndexOf(ds.Tables[0].Rows[i]["REGION_NAME"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Region Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotgamt1) + "<b></td>");
                            GRtotgamt = GRtotgamt + Rtotgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotsur1) + "<b></td>");
                            GRtotsur = GRtotsur + Rtotsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotcomm1) + "<b></td>");
                            GRtotcomm = GRtotcomm + Rtotcomm1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtototh1) + "<b></td>");
                            GRtototh = GRtototh + Rtototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotnet1) + "<b></td>");
                            GRtotnet = GRtotnet + Rtotnet1;
                            TBL.Append("</tr>");
                            Find_Region += ds.Tables[0].Rows[i]["REGION_NAME"].ToString();
                            Rtotgamt1 = 0; Rtotsur1 = 0; Rtotcomm1 = 0; Rtototh1 = 0; Rtotnet1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Region:-" + ds.Tables[0].Rows[i]["REGION_NAME"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }


                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILNO"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["IDNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RONUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Size"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_rate"].ToString()).ToString("f2") + "</td>");
                    if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()).ToString("f2") + "</td>");
                        Rtotgamt1 = Rtotgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        Rtotsur1 = Rtotsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        Rtotcomm1 = Rtotcomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        Rtototh1 = Rtototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString()).ToString("f2") + "</td>");
                        Rtotnet1 = Rtotnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }
                    TBL.Append("</tr>");


                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILDT"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["BOOKING_DATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RODATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["INSNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'>" + ds.Tables[0].Rows[i]["CLIENTNAME"] + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>" + ds.Tables[0].Rows[i]["ins_date"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");
                    Find_Region += ds.Tables[0].Rows[i]["REGION_NAME"].ToString();
                    sno++;
                    rowcounter = rowcounter + 5;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Region Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotgamt1) + "<b></td>");
                GRtotgamt = GRtotgamt + Rtotgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotsur1) + "<b></td>");
                GRtotsur = GRtotsur + Rtotsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotcomm1) + "<b></td>");
                GRtotcomm = GRtotcomm + Rtotcomm1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtototh1) + "<b></td>");
                GRtototh = GRtototh + Rtototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Rtotnet1) + "<b></td>");
                GRtotnet = GRtotnet + Rtotnet1;
                TBL.Append("</tr>");
                TBL.Append("</tr>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='18%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + "GRAND TOTAL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GRtotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GRtotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GRtotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GRtototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GRtotnet) + "<b></td>");

                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
            }

            TBL.Append("</table>");
            TBL.Append("</table></p>");
        }//////Region wise

            ///////////product wise
        else if (brkon == "P")
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Wise Invoice Register</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                rowcounter = rowcounter + 5;
                Find_Product = ds.Tables[0].Rows[0]["product_name"].ToString();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (pgn == 1)
                        {
                            maxlimit = maxlimit + 4;
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {


                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Wise Invoice Register</td></tr>");
                            TBL.Append("</table>");




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
                            TBL.Append("</tr>");

                            TBL.Append("</table>");

                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");

                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");
                            pgn++;
                            rowcounter = rowcounter + 5;
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product:-" + ds.Tables[0].Rows[i]["product_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_Product.IndexOf(ds.Tables[0].Rows[i]["product_name"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Product Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotgamt1) + "<b></td>");
                            GPtotgamt = GPtotgamt + Ptotgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotsur1) + "<b></td>");
                            GPtotsur = GPtotsur + Ptotsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotcomm1) + "<b></td>");
                            GPtotcomm = GPtotcomm + Ptotcomm1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptototh1) + "<b></td>");
                            GPtototh = GPtototh + Ptototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotnet1) + "<b></td>");
                            GPtotnet = GPtotnet + Ptotnet1;
                            TBL.Append("</tr>");
                            Find_Product += ds.Tables[0].Rows[i]["product_name"].ToString();
                            Ptotgamt1 = 0; Ptotsur1 = 0; Ptotcomm1 = 0; Ptototh1 = 0; Ptotnet1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product:-" + ds.Tables[0].Rows[i]["product_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }


                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILNO"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["IDNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RONUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Size"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_rate"].ToString()).ToString("f2") + "</td>");
                    if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()).ToString("f2") + "</td>");
                        Ptotgamt1 = Ptotgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        Ptotsur1 = Ptotsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        Ptotcomm1 = Ptotcomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        Ptototh1 = Ptototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString()).ToString("f2") + "</td>");
                        Ptotnet1 = Ptotnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }
                    TBL.Append("</tr>");


                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILDT"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["BOOKING_DATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RODATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["INSNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'>" + ds.Tables[0].Rows[i]["CLIENTNAME"] + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>" + ds.Tables[0].Rows[i]["ins_date"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");
                    Find_Product += ds.Tables[0].Rows[i]["product_name"].ToString();
                    sno++;
                    rowcounter = rowcounter + 5;
                }

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Product Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotgamt1) + "<b></td>");
                GPtotgamt = GPtotgamt + Ptotgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotsur1) + "<b></td>");
                GPtotsur = GPtotsur + Ptotsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotcomm1) + "<b></td>");
                GPtotcomm = GPtotcomm + Ptotcomm1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptototh1) + "<b></td>");
                GPtototh = GPtototh + Ptototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Ptotnet1) + "<b></td>");
                GPtotnet = GPtotnet + Ptotnet1;
                TBL.Append("</tr>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='18%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + "GRAND TOTAL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GPtotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GPtotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GPtotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GPtototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GPtotnet) + "<b></td>");

                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
            }

            TBL.Append("</table>");
            TBL.Append("</table></p>");
        }//////Product wise
        else if (brkon == "CS")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                brkon = "";

                string[] parameterValueArray = new string[] { compcode, "", fromdate1, todate1, agcd, pcent, executiveCd, "", branch, hiddendateformat.Value, billtype, userid, brkon, agtype, extra4, extra5, req_parent_child, paymode, clientcd, region, agcat, adcat, adsubcat, product, extra12, dist, extra14, extra15,pub};
                string procedureName = "rpt_billregister_cat_p";
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
            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Category Wise Invoice Register Summary</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='15%'><b>" + "Ad Sub Category" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + "Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + "No.Of Ins." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Gross Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                Find_category_sum = ds.Tables[0].Rows[0]["priadctg"].ToString();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (pgn == 1)
                        {
                            maxlimit = maxlimit + 4;
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {



                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Category Wise Invoice Register Summary</td></tr>");
                            TBL.Append("</table>");




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
                            if (exename == "")
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                            }
                            else
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                            }
                            TBL.Append("</tr>");

                            TBL.Append("</table>");
                            pgn++;
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='15%'><b>" + "Ad Sub Category" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + "Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + "No.Of Ins." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Gross Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='9' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Category:-" + ds.Tables[0].Rows[i]["ad_cate_name"] + "</b></td>");
                        TBL.Append("</tr>");
                    }
                    else
                    {
                        if (Find_category_sum.IndexOf(ds.Tables[0].Rows[i]["priadctg"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='19%'><b>" + "Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + size + "<b></td>");
                            Gsize = Gsize + size;
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + no_ins + "<b></td>");
                            Gno_ins = Gno_ins + no_ins;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotgamt1) + "<b></td>");
                            GCatotgamt = GCatotgamt + Catotgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotsur1) + "<b></td>");
                            GCatotsur = GCatotsur + Catotsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotcomm1) + "<b></td>");
                            GCatotcomm = GCatotcomm + Catotcomm1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catototh1) + "<b></td>");
                            GCatototh = GCatototh + Catototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotnet1) + "<b></td>");
                            GCatotnet = GCatotnet + Catotnet1;
                            TBL.Append("</tr>");
                            Find_category_sum += ds.Tables[0].Rows[i]["priadctg"].ToString();
                            Catotgamt1 = 0; Catotsur1 = 0; Catotcomm1 = 0; Catototh1 = 0; Catotnet1 = 0; no_ins = 0; size = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='9' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Category:-" + ds.Tables[0].Rows[i]["ad_cate_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }
                    }

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='15%'>" + ds.Tables[0].Rows[i]["ad_subcate_name"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["siz"].ToString() + "</td>");
                    size = size + Convert.ToInt32(ds.Tables[0].Rows[i]["siz"].ToString());
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["no_ins"].ToString() + "</td>");
                    no_ins = no_ins + Convert.ToInt32(ds.Tables[0].Rows[i]["no_ins"].ToString());
                    if (ds.Tables[0].Rows[i]["gamt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["gamt"].ToString()).ToString("f2") + "</td>");
                        Catotgamt1 = Catotgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["gamt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        Catotsur1 = Catotsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        Catotcomm1 = Catotcomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        Catototh1 = Catototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["amount"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='13%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"].ToString()).ToString("f2") + "</td>");
                        Catotnet1 = Catotnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"].ToString());
                    }
                    TBL.Append("</tr>");
                    sno++;

                    Find_category_sum += ds.Tables[0].Rows[i]["priadctg"].ToString();

                }

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='19%'><b>" + "Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + size + "<b></td>");
                Gsize = Gsize + size;
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + no_ins + "<b></td>");
                Gno_ins = Gno_ins + no_ins;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotgamt1) + "<b></td>");
                GCatotgamt = GCatotgamt + Catotgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotsur1) + "<b></td>");
                GCatotsur = GCatotsur + Catotsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotcomm1) + "<b></td>");
                GCatotcomm = GCatotcomm + Catotcomm1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catototh1) + "<b></td>");
                GCatototh = GCatototh + Catototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", Catotnet1) + "<b></td>");
                GCatotnet = GCatotnet + Catotnet1;
                TBL.Append("</tr>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='19%'><b>" + "Grand Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + Gsize + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'><b>" + Gno_ins + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", GCatotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", GCatotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", GCatotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", GCatototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='13%'><b>" + string.Format("{0:0.00}", GCatotnet) + "<b></td>");
                TBL.Append("</tr>");
                TBL.Append("</table>");
                TBL.Append("</table></p>");
            }

        }

        //////Category Wise
        else
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Category Wise Invoice Register</td></tr>");
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
                if (exename == "")
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                }
                else
                {
                    TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                }
                TBL.Append("</tr>");

                TBL.Append("</table>");
                pgn++;
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                TBL.Append("</tr>");

                rowcounter = rowcounter + 5;
                Find_category = ds.Tables[0].Rows[0]["ad_cate_name"].ToString();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (rowcounter >= maxlimit)
                    {
                        rowcounter = 0;
                        if (pgn == 1)
                        {
                            maxlimit = maxlimit + 4;
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {



                            TBL.Append("</table></p>");
                            TBL.Append("<p style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Category Wise Invoice Register</td></tr>");
                            TBL.Append("</table>");




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
                            if (exename == "")
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + "All" + "</td>");
                            }
                            else
                            {
                                TBL.Append("<td class='mis_hdr1' colspan='5' align='right'style='font-size:15px;'width='10%'><b>" + "Executive Name :</b>" + " " + exename + "</td>");
                            }
                            TBL.Append("</tr>");

                            TBL.Append("</table>");

                            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>" + "Sr.no" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Agency Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='12%'><b>" + "Bill No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO Control No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "RO No." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='8%'><b>" + "Ad Size" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Rate" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Gross Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sur Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Other Amt" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                            TBL.Append("</tr>");

                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'><b>" + "Agency Address" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'><b>" + "Bill Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Booking Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "RO Date." + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'><b>" + "Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'><b>" + "Agency City" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Client Name" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>" + "Pub Date" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                            TBL.Append("</tr>");
                            pgn++;
                            rowcounter = rowcounter + 5;
                        }
                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Category:-" + ds.Tables[0].Rows[i]["ad_cate_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_category.IndexOf(ds.Tables[0].Rows[i]["ad_cate_name"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotgamt1) + "<b></td>");
                            GCatotgamt = GCatotgamt + Catotgamt1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotsur1) + "<b></td>");
                            GCatotsur = GCatotsur + Catotsur1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotcomm1) + "<b></td>");
                            GCatotcomm = GCatotcomm + Catotcomm1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catototh1) + "<b></td>");
                            GCatototh = GCatototh + Catototh1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotnet1) + "<b></td>");
                            GCatotnet = GCatotnet + Catotnet1;
                            TBL.Append("</tr>");
                            Find_category += ds.Tables[0].Rows[i]["ad_cate_name"].ToString();
                            Catotgamt1 = 0; Catotsur1 = 0; Catotcomm1 = 0; Catototh1 = 0; Catotnet1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='11' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Category:-" + ds.Tables[0].Rows[i]["ad_cate_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }


                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_NAME"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILNO"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["IDNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RONUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Size"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_rate"].ToString()).ToString("f2") + "</td>");
                    if (ds.Tables[0].Rows[i]["GROSS_AMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString()).ToString("f2") + "</td>");
                        Catotgamt1 = Catotgamt1 + Convert.ToDouble(ds.Tables[0].Rows[i]["GROSS_AMT"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["sur_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString()).ToString("f2") + "</td>");
                        Catotsur1 = Catotsur1 + Convert.ToDouble(ds.Tables[0].Rows[i]["sur_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");
                        Catotcomm1 = Catotcomm1 + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["oth_amt"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString()).ToString("f2") + "</td>");
                        Catototh1 = Catototh1 + Convert.ToDouble(ds.Tables[0].Rows[i]["oth_amt"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["BILLAMT"].ToString() == "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + "0.00" + "</td>");
                    }
                    else
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString()).ToString("f2") + "</td>");
                        Catotnet1 = Catotnet1 + Convert.ToDouble(ds.Tables[0].Rows[i]["BILLAMT"].ToString());
                    }
                    TBL.Append("</tr>");


                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_ADDR"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["BILDT"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["BOOKING_DATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["RODATE"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='8%'>" + ds.Tables[0].Rows[i]["INSNUM"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");

                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='18%'>" + ds.Tables[0].Rows[i]["BK_AGENCY_CITY"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'>" + ds.Tables[0].Rows[i]["CLIENTNAME"] + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>" + ds.Tables[0].Rows[i]["ins_date"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                    TBL.Append("</tr>");
                    Find_category += ds.Tables[0].Rows[i]["ad_cate_name"].ToString();
                    sno++;
                    rowcounter = rowcounter + 5;
                }

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='7' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='65%'><b>" + "Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotgamt1) + "<b></td>");
                GCatotgamt = GCatotgamt + Catotgamt1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotsur1) + "<b></td>");
                GCatotsur = GCatotsur + Catotsur1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotcomm1) + "<b></td>");
                GCatotcomm = GCatotcomm + Catotcomm1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catototh1) + "<b></td>");
                GCatototh = GCatototh + Catototh1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Catotnet1) + "<b></td>");
                GCatotnet = GCatotnet + Catotnet1;
                TBL.Append("</tr>");
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='4%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='18%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='12%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='8%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + "GRAND TOTAL" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCatotgamt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCatotsur) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCatotcomm) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCatototh) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", GCatotnet) + "<b></td>");

                TBL.Append("</tr>");
                rowcounter = rowcounter + 2;
            }

            TBL.Append("</table>");
            TBL.Append("</table></p>");
        }//////Region wise
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