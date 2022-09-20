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

public partial class Reports_ad_cat_prodcatwise_view : System.Web.UI.Page
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
    string prodcat = "";
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
    string prodsubcat = "";
    string executiveCd = "";
    string product = "";
    string exename = "";
    string agname = "";
    string clientcd = "";
    string clientnm = "";
    string bookingid = "";
    string datebasedon = "";
    string req_parent_child = "";
    string paymode = "";
    string extra12 = "";
    string extra14 = "";
    string extra15 = "";
    string teamcode = "";
    string adcatNM = "";
    string branch_nm = "";
    string pub_nm = "";

    int maxlimit = 28;
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
    double book_amt = 0, book_amt1 = 0, book_amt2 = 0, tot_book_amt = 0, publish_amt = 0, publish_amt1 = 0, publish_amt2 = 0, tot_publish_amt, billed_amt = 0, billed_amt1 = 0, billed_amt2 = 0, tot_billed_amt = 0, tot_amt = 0, tot_amt1 = 0, tot_amt2 = 0, tot_tot_amt = 0;
    double book_area = 0, book_area1 = 0, book_area2 = 0, tot_book_area = 0, publish_area = 0, publish_area1 = 0, publish_area2 = 0, tot_publish_area, billed_area = 0, billed_area1 = 0, billed_area2 = 0, tot_billed_area = 0, tot_area = 0, tot_area1 = 0, tot_area2 = 0, tot_tot_area = 0;
    double book_no = 0, book_no1 = 0, book_no2 = 0, tot_book_no = 0, publish_no = 0, publish_no1 = 0, publish_no2 = 0, tot_publish_no, billed_no = 0, billed_no1 = 0, billed_no2 = 0, tot_billed_no = 0, tot_no = 0, tot_no1 = 0, tot_no2 = 0, tot_tot_no = 0;

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
        prodcat = Session["prodcat"].ToString();
        prodsubcat = Session["prodsubcat"].ToString();
        reptype = Session["reptype"].ToString();
        datebasedon = Session["datebasedon"].ToString();
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
        string find_cat2 = "";
        DataSet ds = new DataSet();
        StringBuilder TBL = new StringBuilder();
        if (reptype == "C")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_category_status_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_category_status_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
           
            double[] arr = new double[ds.Tables[0].Columns.Count];
            double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
            double[] arr_tot = new double[ds.Tables[0].Columns.Count];
            double gg = 0;


            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Wise Summary</td></tr>");
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
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='3' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Ad SubCat" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "AdCat3" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                TBL.Append("</tr>");


                rowcounter = rowcounter + 2;
                Find_category = ds.Tables[0].Rows[0]["ad_cat_code"].ToString();
                find_cat2 = ds.Tables[0].Rows[0]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[0]["subcat_name"].ToString();
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
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Wise Summary</td></tr>");
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
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Ad SubCat" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "AdCat3" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 2;
                        }


                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Ad Category:-" + ds.Tables[0].Rows[i]["cat_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {

                        if (find_cat2.IndexOf(ds.Tables[0].Rows[i]["ad_cat_code"].ToString() + ds.Tables[0].Rows[i]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[i]["subcat_name"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Sub Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                            billed_no1 = billed_no1 + billed_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                            billed_area1 = billed_area1 + billed_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                            billed_amt1 = billed_amt1 + billed_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                            publish_no1 = publish_no1 + publish_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                            publish_area1 = publish_area1 + publish_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                            publish_amt1 = publish_amt1 + publish_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                            book_no1 = book_no1 + book_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                            book_area1 = book_area1 + book_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                            book_amt1 = book_amt1 + book_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                            tot_no1 = tot_no1 + tot_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                            tot_area1 = tot_area1 + tot_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                            tot_amt1 = tot_amt1 + tot_amt;
                            TBL.Append("</tr>");
                            find_cat2 += ds.Tables[0].Rows[i]["ad_cat_code"].ToString() + ds.Tables[0].Rows[i]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[i]["subcat_name"].ToString();
                            billed_no = 0; billed_area = 0; billed_amt = 0; publish_no = 0; publish_area = 0; publish_amt = 0; book_no = 0; book_area = 0; book_amt = 0; tot_no = 0; tot_area = 0; tot_amt = 0;
                           
                            rowcounter = rowcounter + 1;
                        }
                        if (Find_category.IndexOf(ds.Tables[0].Rows[i]["ad_cat_code"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no1) + "<b></td>");
                            tot_billed_no = tot_billed_no + billed_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area1) + "<b></td>");
                            tot_billed_area = tot_billed_area + billed_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt1) + "<b></td>");
                            tot_billed_amt = tot_billed_amt + billed_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no1) + "<b></td>");
                            tot_publish_no = tot_publish_no + publish_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area1) + "<b></td>");
                            tot_publish_area = tot_publish_area + publish_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt1) + "<b></td>");
                            tot_publish_amt = tot_publish_amt + publish_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no1) + "<b></td>");
                            tot_book_no = tot_book_no + book_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area1) + "<b></td>");
                            tot_book_area = tot_book_area + book_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt1) + "<b></td>");
                            tot_book_amt = tot_book_amt + book_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no1) + "<b></td>");
                            tot_tot_no = tot_tot_no + tot_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area1) + "<b></td>");
                            tot_tot_area = tot_tot_area + tot_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt1) + "<b></td>");
                            tot_tot_amt = tot_tot_amt + tot_amt1;
                            Find_category += ds.Tables[0].Rows[i]["ad_cat_code"].ToString();
                            billed_no1 = 0; billed_area1 = 0; billed_amt1 = 0; publish_no1 = 0; publish_area1 = 0; publish_amt1 = 0; book_no1 = 0; book_area1 = 0; book_amt1 = 0; tot_no1 = 0; tot_area1 = 0; tot_amt1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Ad Category:-" + ds.Tables[0].Rows[i]["cat_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }
                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["subcat_name"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["subsubcat_name"].ToString() + "</td>");
                    if (ds.Tables[0].Rows[i]["no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["no_ins"].ToString() + "</td>");
                        billed_no = billed_no + Convert.ToDouble(ds.Tables[0].Rows[i]["no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["display_area"].ToString() + "</td>");
                        billed_area = billed_area + Convert.ToDouble(ds.Tables[0].Rows[i]["display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["amount"].ToString() + "</td>");
                        billed_amt = billed_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"].ToString());
                    }

                    /////publish//////
                    if (ds.Tables[0].Rows[i]["publish_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_no_ins"].ToString() + "</td>");
                        publish_no = publish_no + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["publish_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_display_area"].ToString() + "</td>");
                        publish_area = publish_area + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["publish_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["publish_amount"].ToString() + "</td>");
                        publish_amt = publish_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_amount"].ToString());
                    }
                    /////booked////
                    if (ds.Tables[0].Rows[i]["book_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_no_ins"].ToString() + "</td>");
                        book_no = book_no + Convert.ToDouble(ds.Tables[0].Rows[i]["book_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["book_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_display_area"].ToString() + "</td>");
                        book_area = book_area + Convert.ToDouble(ds.Tables[0].Rows[i]["book_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["book_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["book_amount"].ToString() + "</td>");
                        book_amt = book_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["book_amount"].ToString());
                    }
                    /////total////
                    if (ds.Tables[0].Rows[i]["total_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_no_ins"].ToString() + "</td>");
                        tot_no = tot_no + Convert.ToDouble(ds.Tables[0].Rows[i]["total_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["total_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_area"].ToString() + "</td>");
                        tot_area = tot_area + Convert.ToDouble(ds.Tables[0].Rows[i]["total_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["total_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["total_amount"].ToString() + "</td>");
                        tot_amt = tot_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["total_amount"].ToString());
                    }

                    Find_category += ds.Tables[0].Rows[i]["ad_cat_code"].ToString();
                    find_cat2 += ds.Tables[0].Rows[i]["ad_cat_code"].ToString() + ds.Tables[0].Rows[i]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[i]["subcat_name"].ToString();
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Sub Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                billed_no1 = billed_no1 + billed_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                billed_area1 = billed_area1 + billed_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                billed_amt1 = billed_amt1 + billed_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                publish_no1 = publish_no1 + publish_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                publish_area1 = publish_area1 + publish_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                publish_amt1 = publish_amt1 + publish_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                book_no1 = book_no1 + book_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                book_area1 = book_area1 + book_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                book_amt1 = book_amt1 + book_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                tot_no1 = tot_no1 + tot_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                tot_area1 = tot_area1 + tot_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                tot_amt1 = tot_amt1 + tot_amt;
                TBL.Append("</tr>");



                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no1) + "<b></td>");
                tot_billed_no = tot_billed_no + billed_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area1) + "<b></td>");
                tot_billed_area = tot_billed_area + billed_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt1) + "<b></td>");
                tot_billed_amt = tot_billed_amt + billed_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no1) + "<b></td>");
                tot_publish_no = tot_publish_no + publish_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area1) + "<b></td>");
                tot_publish_area = tot_publish_area + publish_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt1) + "<b></td>");
                tot_publish_amt = tot_publish_amt + publish_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no1) + "<b></td>");
                tot_book_no = tot_book_no + book_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area1) + "<b></td>");
                tot_book_area = tot_book_area + book_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt1) + "<b></td>");
                tot_book_amt = tot_book_amt + book_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no1) + "<b></td>");
                tot_tot_no = tot_tot_no + tot_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area1) + "<b></td>");
                tot_tot_area = tot_tot_area + tot_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt1) + "<b></td>");
                tot_tot_amt = tot_tot_amt + tot_amt1;
               

                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Grand Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_billed_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_publish_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_book_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_tot_amt) + "<b></td>");
        
                TBL.Append("</tr>");

                TBL.Append("</table>");
                TBL.Append("</table></p>");
            }

            report.InnerHtml = TBL.ToString();
        }
        else if (reptype == "R")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_category_status_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_category_status_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }

            double[] arr = new double[ds.Tables[0].Columns.Count];
            double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
            double[] arr_tot = new double[ds.Tables[0].Columns.Count];
            double gg = 0;


            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Wise Summary</td></tr>");
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
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='3' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Ad SubCat" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "AdCat3" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                TBL.Append("</tr>");


                rowcounter = rowcounter + 2;
                Find_Region= ds.Tables[0].Rows[0]["region_nm"].ToString();
                Find_category = ds.Tables[0].Rows[0]["ad_cat_code"].ToString();
                find_cat2 = ds.Tables[0].Rows[0]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[0]["subcat_name"].ToString();
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
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Ad Category Wise Summary</td></tr>");
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
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                            TBL.Append("</tr>");


                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Ad SubCat" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "AdCat3" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 2;
                        }


                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Region:-" + ds.Tables[0].Rows[i]["region_nm"] + "</b></td>");
                        TBL.Append("</tr>");
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Ad Category:-" + ds.Tables[0].Rows[i]["cat_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {

                        if (find_cat2.IndexOf(ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["ad_cat_code"].ToString() + ds.Tables[0].Rows[i]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[i]["subcat_name"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Sub Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                            billed_no1 = billed_no1 + billed_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                            billed_area1 = billed_area1 + billed_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                            billed_amt1 = billed_amt1 + billed_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                            publish_no1 = publish_no1 + publish_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                            publish_area1 = publish_area1 + publish_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                            publish_amt1 = publish_amt1 + publish_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                            book_no1 = book_no1 + book_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                            book_area1 = book_area1 + book_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                            book_amt1 = book_amt1 + book_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                            tot_no1 = tot_no1 + tot_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                            tot_area1 = tot_area1 + tot_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                            tot_amt1 = tot_amt1 + tot_amt;
                            TBL.Append("</tr>");
                            find_cat2 +=ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["ad_cat_code"].ToString() + ds.Tables[0].Rows[i]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[i]["subcat_name"].ToString();
                            billed_no = 0; billed_area = 0; billed_amt = 0; publish_no = 0; publish_area = 0; publish_amt = 0; book_no = 0; book_area = 0; book_amt = 0; tot_no = 0; tot_area = 0; tot_amt = 0;

                            rowcounter = rowcounter + 1;
                        }
                        if (Find_category.IndexOf(ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["ad_cat_code"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no1) + "<b></td>");
                            billed_no2 = billed_no2 + billed_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area1) + "<b></td>");
                            billed_area2 = billed_area2 + billed_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt1) + "<b></td>");
                            billed_amt2 = billed_amt2 + billed_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no1) + "<b></td>");
                            publish_no2 = publish_no2 + publish_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area1) + "<b></td>");
                            publish_area2 = publish_area2 + publish_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt1) + "<b></td>");
                            publish_amt2 = publish_amt2 + publish_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no1) + "<b></td>");
                            book_no2 = book_no2 + book_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area1) + "<b></td>");
                            book_area2 = book_area2 + book_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt1) + "<b></td>");
                            book_amt2 = book_amt2 + book_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no1) + "<b></td>");
                            tot_no2 = tot_no2 + tot_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area1) + "<b></td>");
                            tot_area2 = tot_area2 + tot_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt1) + "<b></td>");
                            tot_amt2 = tot_amt2 + tot_amt1;
                            Find_category +=ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["ad_cat_code"].ToString();
                            billed_no1 = 0; billed_area1 = 0; billed_amt1 = 0; publish_no1 = 0; publish_area1 = 0; publish_amt1 = 0; book_no1 = 0; book_area1 = 0; book_amt1 = 0; tot_no1 = 0; tot_area1 = 0; tot_amt1 = 0;
                            if (ds.Tables[0].Rows[i]["region_nm"].ToString() == ds.Tables[0].Rows[i - 1]["region_nm"].ToString())
                            {
                                TBL.Append("<tr font-family='Arial'>");
                                TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Ad Category:-" + ds.Tables[0].Rows[i]["cat_name"] + "</b></td>");
                                TBL.Append("</tr>");
                            }
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }
                        if (Find_Region.IndexOf(ds.Tables[0].Rows[i]["region_nm"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Region Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no2) + "<b></td>");
                            tot_billed_no = tot_billed_no + billed_no2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area2) + "<b></td>");
                            tot_billed_area = tot_billed_area + billed_area2;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt2) + "<b></td>");
                            tot_billed_amt = tot_billed_amt + billed_amt2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no2) + "<b></td>");
                            tot_publish_no = tot_publish_no + publish_no2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area2) + "<b></td>");
                            tot_publish_area = tot_publish_area + publish_area2;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt2) + "<b></td>");
                            tot_publish_amt = tot_publish_amt + publish_amt2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no2) + "<b></td>");
                            tot_book_no = tot_book_no + book_no2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area2) + "<b></td>");
                            tot_book_area = tot_book_area + book_area2;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt2) + "<b></td>");
                            tot_book_amt = tot_book_amt + book_amt2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no2) + "<b></td>");
                            tot_tot_no = tot_tot_no + tot_no2;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area2) + "<b></td>");
                            tot_tot_area = tot_tot_area + tot_area2;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt2) + "<b></td>");
                            tot_tot_amt = tot_tot_amt + tot_amt2;
                            TBL.Append("</tr>");
                            Find_Region += ds.Tables[0].Rows[i]["region_nm"].ToString();
                            billed_no2 = 0; billed_area2 = 0; billed_amt2 = 0; publish_no2 = 0; publish_area2 = 0; publish_amt2 = 0; book_no2 = 0; book_area2 = 0; book_amt2 = 0; tot_no2 = 0; tot_area2 = 0; tot_amt2 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Region:-" + ds.Tables[0].Rows[i]["region_nm"] + "</b></td>");
                            TBL.Append("</tr>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Ad Category:-" + ds.Tables[0].Rows[i]["cat_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            
                            rowcounter = rowcounter + 1;
                        }
                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["subcat_name"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["subsubcat_name"].ToString() + "</td>");
                    if (ds.Tables[0].Rows[i]["no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["no_ins"].ToString() + "</td>");
                        billed_no = billed_no + Convert.ToDouble(ds.Tables[0].Rows[i]["no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["display_area"].ToString() + "</td>");
                        billed_area = billed_area + Convert.ToDouble(ds.Tables[0].Rows[i]["display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["amount"].ToString() + "</td>");
                        billed_amt = billed_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"].ToString());
                    }

                    /////publish//////
                    if (ds.Tables[0].Rows[i]["publish_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_no_ins"].ToString() + "</td>");
                        publish_no = publish_no + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["publish_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_display_area"].ToString() + "</td>");
                        publish_area = publish_area + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["publish_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["publish_amount"].ToString() + "</td>");
                        publish_amt = publish_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_amount"].ToString());
                    }
                    /////booked////
                    if (ds.Tables[0].Rows[i]["book_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_no_ins"].ToString() + "</td>");
                        book_no = book_no + Convert.ToDouble(ds.Tables[0].Rows[i]["book_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["book_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_display_area"].ToString() + "</td>");
                        book_area = book_area + Convert.ToDouble(ds.Tables[0].Rows[i]["book_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["book_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["book_amount"].ToString() + "</td>");
                        book_amt = book_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["book_amount"].ToString());
                    }
                    /////total////
                    if (ds.Tables[0].Rows[i]["total_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_no_ins"].ToString() + "</td>");
                        tot_no = tot_no + Convert.ToDouble(ds.Tables[0].Rows[i]["total_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["total_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_area"].ToString() + "</td>");
                        tot_area = tot_area + Convert.ToDouble(ds.Tables[0].Rows[i]["total_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["total_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["total_amount"].ToString() + "</td>");
                        tot_amt = tot_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["total_amount"].ToString());
                    }
                    Find_Region += ds.Tables[0].Rows[i]["region_nm"].ToString();
                    Find_category +=ds.Tables[0].Rows[i]["region_nm"].ToString()+ ds.Tables[0].Rows[i]["ad_cat_code"].ToString();
                    find_cat2 += ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["ad_cat_code"].ToString() + ds.Tables[0].Rows[i]["ad_sub_cat_code"].ToString() + ds.Tables[0].Rows[i]["subcat_name"].ToString();
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Sub Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                billed_no1 = billed_no1 + billed_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                billed_area1 = billed_area1 + billed_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                billed_amt1 = billed_amt1 + billed_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                publish_no1 = publish_no1 + publish_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                publish_area1 = publish_area1 + publish_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                publish_amt1 = publish_amt1 + publish_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                book_no1 = book_no1 + book_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                book_area1 = book_area1 + book_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                book_amt1 = book_amt1 + book_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                tot_no1 = tot_no1 + tot_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                tot_area1 = tot_area1 + tot_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                tot_amt1 = tot_amt1 + tot_amt;
                TBL.Append("</tr>");



                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no1) + "<b></td>");
                billed_no2 = billed_no2 + billed_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area1) + "<b></td>");
                billed_area2 = billed_area2 + billed_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt1) + "<b></td>");
                billed_amt2 = billed_amt2 + billed_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no1) + "<b></td>");
                publish_no2 = publish_no2 + publish_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area1) + "<b></td>");
                publish_area2 = publish_area2 + publish_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt1) + "<b></td>");
                publish_amt2 = publish_amt2 + publish_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no1) + "<b></td>");
                book_no2 = book_no2 + book_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area1) + "<b></td>");
                book_area2 = book_area2 + book_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt1) + "<b></td>");
                book_amt2 = book_amt2 + book_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no1) + "<b></td>");
                tot_no2 = tot_no2 + tot_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area1) + "<b></td>");
                tot_area2 = tot_area2 + tot_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt1) + "<b></td>");
                tot_amt2 = tot_amt2 + tot_amt1;


                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Region Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no2) + "<b></td>");
                tot_billed_no = tot_billed_no + billed_no2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area2) + "<b></td>");
                tot_billed_area = tot_billed_area + billed_area2;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt2) + "<b></td>");
                tot_billed_amt = tot_billed_amt + billed_amt2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no2) + "<b></td>");
                tot_publish_no = tot_publish_no + publish_no2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area2) + "<b></td>");
                tot_publish_area = tot_publish_area + publish_area2;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt2) + "<b></td>");
                tot_publish_amt = tot_publish_amt + publish_amt2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no2) + "<b></td>");
                tot_book_no = tot_book_no + book_no2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area2) + "<b></td>");
                tot_book_area = tot_book_area + book_area2;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt2) + "<b></td>");
                tot_book_amt = tot_book_amt + book_amt2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no2) + "<b></td>");
                tot_tot_no = tot_tot_no + tot_no2;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area2) + "<b></td>");
                tot_tot_area = tot_tot_area + tot_area2;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt2) + "<b></td>");
                tot_tot_amt = tot_tot_amt + tot_amt2;
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Grand Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_billed_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_publish_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_book_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_tot_amt) + "<b></td>");

                TBL.Append("</tr>");

                TBL.Append("</table>");
                TBL.Append("</table></p>");
            }

            report.InnerHtml = TBL.ToString();
        }

            else if(reptype=="RP")
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_product_status_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_product_status_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
            
            double[] arr = new double[ds.Tables[0].Columns.Count];
            double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
            double[] arr_tot = new double[ds.Tables[0].Columns.Count];
            double gg = 0;


            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Category Wise Summary</td></tr>");
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
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Sub Cat" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Cat3" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                TBL.Append("</tr>");


                rowcounter = rowcounter + 5;
                Find_category = ds.Tables[0].Rows[0]["prod_cat_name"].ToString();
                Find_Region = ds.Tables[0].Rows[0]["region_nm"].ToString();
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
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Category Wise Summary</td></tr>");
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
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                            TBL.Append("</tr>");



                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Sub Cat" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Cat3" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                            TBL.Append("</tr>");

                            rowcounter = rowcounter + 5;
                        }


                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Region:-" + ds.Tables[0].Rows[i]["region_nm"] + "</b></td>");
                        TBL.Append("</tr>");
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product Category:-" + ds.Tables[0].Rows[i]["prod_cat_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_category.IndexOf(ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["prod_cat_name"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                            billed_no1 = billed_no1 + billed_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                            billed_area1 = billed_area1 + billed_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                            billed_amt1 = billed_amt1 + billed_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                            publish_no1 = publish_no1 + publish_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                            publish_area1 = publish_area1 + publish_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                            publish_amt1 = publish_amt1 + publish_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                            book_no1 = book_no1 + book_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                            book_area1 = book_area1 + book_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                            book_amt1 = book_amt1 + book_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                            tot_no1 = tot_no1 + tot_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                            tot_area1 = tot_area1 + tot_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                            tot_amt1 = tot_amt1 + tot_amt;
                            Find_category += ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["prod_cat_name"].ToString();
                            billed_no = 0; billed_area = 0; billed_amt = 0; publish_no = 0; publish_area = 0; publish_amt = 0; book_no = 0; book_area = 0; book_amt = 0; tot_no = 0; tot_area = 0; tot_amt = 0;
                            if (ds.Tables[0].Rows[i]["region_nm"].ToString() == ds.Tables[0].Rows[i-1]["region_nm"].ToString())
                            {
                                TBL.Append("<tr font-family='Arial'>");
                                TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product Category:-" + ds.Tables[0].Rows[i]["prod_cat_name"] + "</b></td>");
                                TBL.Append("</tr>");
                            }
                            rowcounter = rowcounter + 1;
                        }

                        if (Find_Region.IndexOf(ds.Tables[0].Rows[i]["region_nm"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Region Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no1) + "<b></td>");
                            tot_billed_no = tot_billed_no + billed_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area1) + "<b></td>");
                            tot_billed_area = tot_billed_area + billed_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                            tot_billed_amt = tot_billed_amt + billed_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no1) + "<b></td>");
                            tot_publish_no = tot_publish_no + publish_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area1) + "<b></td>");
                            tot_publish_area = tot_publish_area + publish_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt1) + "<b></td>");
                            tot_publish_amt = tot_publish_amt + publish_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no1) + "<b></td>");
                            tot_book_no = tot_book_no + book_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area1) + "<b></td>");
                            tot_book_area = tot_book_area + book_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt1) + "<b></td>");
                            tot_book_amt = tot_book_amt + book_amt1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no1) + "<b></td>");
                            tot_tot_no = tot_tot_no + tot_no1;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area1) + "<b></td>");
                            tot_tot_area = tot_tot_area + tot_area1;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt1) + "<b></td>");
                            tot_tot_amt = tot_tot_amt + tot_amt1;
                            Find_category += ds.Tables[0].Rows[i]["region_nm"].ToString();
                            billed_no1 = 0; billed_area1 = 0; billed_amt1 = 0; publish_no1 = 0; publish_area1 = 0; publish_amt1 = 0; book_no1 = 0; book_area1 = 0; book_amt1 = 0; tot_no1 = 0; tot_area1 = 0; tot_amt1 = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Region:-" + ds.Tables[0].Rows[i]["region_nm"] + "</b></td>");
                            TBL.Append("</tr>");
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product Category:-" + ds.Tables[0].Rows[i]["prod_cat_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }
                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["prod_subcat_name"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["pro_subsubcat_name"].ToString() + "</td>");
                    if (ds.Tables[0].Rows[i]["no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["no_ins"].ToString() + "</td>");
                        billed_no = billed_no + Convert.ToDouble(ds.Tables[0].Rows[i]["no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["display_area"].ToString() + "</td>");
                        billed_area = billed_area + Convert.ToDouble(ds.Tables[0].Rows[i]["display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["amount"].ToString() + "</td>");
                        billed_amt = billed_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"].ToString());
                    }

                    /////publish//////
                    if (ds.Tables[0].Rows[i]["publish_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_no_ins"].ToString() + "</td>");
                        publish_no = publish_no + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["publish_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_display_area"].ToString() + "</td>");
                        publish_area = publish_area + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["publish_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["publish_amount"].ToString() + "</td>");
                        publish_amt = publish_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_amount"].ToString());
                    }
                    /////booked////
                    if (ds.Tables[0].Rows[i]["book_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_no_ins"].ToString() + "</td>");
                        book_no = book_no + Convert.ToDouble(ds.Tables[0].Rows[i]["book_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["book_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_display_area"].ToString() + "</td>");
                        book_area = book_area + Convert.ToDouble(ds.Tables[0].Rows[i]["book_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["book_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["book_amount"].ToString() + "</td>");
                        book_amt = book_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["book_amount"].ToString());
                    }
                    /////total////
                    if (ds.Tables[0].Rows[i]["total_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_no_ins"].ToString() + "</td>");
                        tot_no = tot_no + Convert.ToDouble(ds.Tables[0].Rows[i]["total_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["total_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_area"].ToString() + "</td>");
                        tot_area = tot_area + Convert.ToDouble(ds.Tables[0].Rows[i]["total_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["total_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["total_amount"].ToString() + "</td>");
                        tot_amt = tot_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["total_amount"].ToString());
                    }
                    Find_Region += ds.Tables[0].Rows[i]["region_nm"].ToString();
                    Find_category += ds.Tables[0].Rows[i]["region_nm"].ToString()+ds.Tables[0].Rows[i]["prod_cat_name"].ToString();
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                billed_no1 = billed_no1 + billed_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                billed_area1 = billed_area1 + billed_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                billed_amt1 = billed_amt1 + billed_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                publish_no1 = publish_no1 + publish_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                publish_area1 = publish_area1 + publish_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                publish_amt1 = publish_amt1 + publish_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                book_no1 = book_no1 + book_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                book_area1 = book_area1 + book_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                book_amt1 = book_amt1 + book_amt;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                tot_no1 = tot_no1 + tot_no;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                tot_area1 = tot_area1 + tot_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                tot_amt1 = tot_amt1 + tot_amt;
                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Region Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no1) + "<b></td>");
                tot_billed_no = tot_billed_no + billed_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area1) + "<b></td>");
                tot_billed_area = tot_billed_area + billed_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                tot_billed_amt = tot_billed_amt + billed_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no1) + "<b></td>");
                tot_publish_no = tot_publish_no + publish_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area1) + "<b></td>");
                tot_publish_area = tot_publish_area + publish_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt1) + "<b></td>");
                tot_publish_amt = tot_publish_amt + publish_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no1) + "<b></td>");
                tot_book_no = tot_book_no + book_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area1) + "<b></td>");
                tot_book_area = tot_book_area + book_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt1) + "<b></td>");
                tot_book_amt = tot_book_amt + book_amt1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no1) + "<b></td>");
                tot_tot_no = tot_tot_no + tot_no1;
                TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area1) + "<b></td>");
                tot_tot_area = tot_tot_area + tot_area1;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt1) + "<b></td>");
                tot_tot_amt = tot_tot_amt + tot_amt1;

                TBL.Append("</tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Grand Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_billed_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_publish_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_book_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_tot_amt) + "<b></td>");

                TBL.Append("</tr>");

                TBL.Append("</table>");
                TBL.Append("</table></p>");
            }

            report.InnerHtml = TBL.ToString();
        }
        else
        {
            if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_product_status_p";
                NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            else
            {

                string[] parameterValueArray = new string[] { compcode, pcent, branch, adtype, adcat, prodcat, prodsubcat, reptype, datebasedon, fromdate, todate, hiddendateformat.Value, hdnuserid.Value, pub, edtn, extra1, extra2, extra3, extra4, extra5 };
                string procedureName = "rpt_product_status_p";
                NewAdbooking.Classes.CommonClass exe = new NewAdbooking.Classes.CommonClass();
                ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);

            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                return;
            }
            
            double[] arr = new double[ds.Tables[0].Columns.Count];
            double[] arr_Grand = new double[ds.Tables[0].Columns.Count];
            double[] arr_tot = new double[ds.Tables[0].Columns.Count];
            double gg = 0;


            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno = 1;
                StringBuilder tbl = new StringBuilder();
                TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' valign='top'>");
                TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                TBL.Append("<tr><td colspan='10' style='text-align:center;font-size:20px;'width='100%'><b>" + centermame + "</b></td></tr>");
                TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Category Wise Summary</td></tr>");
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
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                TBL.Append("</tr>");


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Sub Cat" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Cat3" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                TBL.Append("</tr>");


                rowcounter = rowcounter + 5;
                Find_category = ds.Tables[0].Rows[0]["prod_cat_name"].ToString();
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
                            TBL.Append("<tr><td colspan='10'  align='center'style='font-size:15px; width='10%'>Product Category Wise Summary</td></tr>");
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
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='4%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='24%'><b>&nbsp;</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Billed" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Publish" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Booked" + "</b></td>");
                            TBL.Append("<td colspan='3' style='text-align:center;font-size:11px;border-top:solid 1px black;' width='18%'><b>" + "Total" + "</b></td>");
                            TBL.Append("</tr>");



                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='4%'><b>" + "S.No" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Sub Cat" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='12%'><b>" + "Product Cat3" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "No.Of Ins" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='5%'><b>" + "Display Area" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + "Amount" + "</b></td>");

                            TBL.Append("</tr>");

                            rowcounter = rowcounter + 5;
                        }


                    }

                    if (i == 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product Category:-" + ds.Tables[0].Rows[i]["prod_cat_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }
                    else
                    {
                        if (Find_category.IndexOf(ds.Tables[0].Rows[i]["prod_cat_name"].ToString()) < 0)
                        {
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='3' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                            tot_billed_no = tot_billed_no + billed_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                            tot_billed_area = tot_billed_area + billed_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                            tot_billed_amt = tot_billed_amt + billed_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                            tot_publish_no = tot_publish_no + publish_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                            tot_publish_area = tot_publish_area + publish_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                            tot_publish_amt = tot_publish_amt + publish_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                            tot_book_no = tot_book_no + book_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                            tot_book_area = tot_book_area + book_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                            tot_book_amt = tot_book_amt + book_amt;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                            tot_tot_no = tot_tot_no + tot_no;
                            TBL.Append("<td colspan='0' style='text-align:left;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                            tot_tot_area = tot_tot_area + tot_area;
                            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                            tot_tot_amt = tot_tot_amt + tot_amt;
                            Find_category += ds.Tables[0].Rows[i]["prod_cat_name"].ToString();
                            billed_no = 0; billed_area = 0; billed_amt = 0; publish_no = 0; publish_area = 0; publish_amt = 0; book_no = 0; book_area = 0; book_amt = 0; tot_no = 0; tot_area = 0; tot_amt = 0;
                            TBL.Append("<tr font-family='Arial'>");
                            TBL.Append("<td colspan='10' style='text-align:Left;font-size:11px;' width='100%'><b>" + "Product Category:-" + ds.Tables[0].Rows[i]["prod_cat_name"] + "</b></td>");
                            TBL.Append("</tr>");
                            rowcounter = rowcounter + 1;
                        }
                    }
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='4%'>" + sno + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["prod_subcat_name"].ToString() + "</td>");
                    TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='12%'>" + ds.Tables[0].Rows[i]["pro_subsubcat_name"].ToString() + "</td>");
                    if (ds.Tables[0].Rows[i]["no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["no_ins"].ToString() + "</td>");
                        billed_no = billed_no + Convert.ToDouble(ds.Tables[0].Rows[i]["no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["display_area"].ToString() + "</td>");
                        billed_area = billed_area + Convert.ToDouble(ds.Tables[0].Rows[i]["display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["amount"].ToString() + "</td>");
                        billed_amt = billed_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["amount"].ToString());
                    }

                    /////publish//////
                    if (ds.Tables[0].Rows[i]["publish_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_no_ins"].ToString() + "</td>");
                        publish_no = publish_no + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["publish_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["publish_display_area"].ToString() + "</td>");
                        publish_area = publish_area + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["publish_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["publish_amount"].ToString() + "</td>");
                        publish_amt = publish_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["publish_amount"].ToString());
                    }
                    /////booked////
                    if (ds.Tables[0].Rows[i]["book_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_no_ins"].ToString() + "</td>");
                        book_no = book_no + Convert.ToDouble(ds.Tables[0].Rows[i]["book_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["book_display_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["book_display_area"].ToString() + "</td>");
                        book_area = book_area + Convert.ToDouble(ds.Tables[0].Rows[i]["book_display_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["book_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["book_amount"].ToString() + "</td>");
                        book_amt = book_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["book_amount"].ToString());
                    }
                    /////total////
                    if (ds.Tables[0].Rows[i]["total_no_ins"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_no_ins"].ToString() + "</td>");
                        tot_no = tot_no + Convert.ToDouble(ds.Tables[0].Rows[i]["total_no_ins"].ToString());

                    }
                    if (ds.Tables[0].Rows[i]["total_area"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='5%'>" + ds.Tables[0].Rows[i]["total_area"].ToString() + "</td>");
                        tot_area = tot_area + Convert.ToDouble(ds.Tables[0].Rows[i]["total_area"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["total_amount"].ToString() != "")
                    {
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;padding-right:10px;' width='8%'>" + ds.Tables[0].Rows[i]["total_amount"].ToString() + "</td>");
                        tot_amt = tot_amt + Convert.ToDouble(ds.Tables[0].Rows[i]["total_amount"].ToString());
                    }

                    Find_category += ds.Tables[0].Rows[i]["prod_cat_name"].ToString();
                    sno++;
                    rowcounter = rowcounter + 1;
                }
                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Category Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_no) + "<b></td>");
                tot_billed_no = tot_billed_no + billed_no;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", billed_area) + "<b></td>");
                tot_billed_area = tot_billed_area + billed_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", billed_amt) + "<b></td>");
                tot_billed_amt = tot_billed_amt + billed_amt;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_no) + "<b></td>");
                tot_publish_no = tot_publish_no + publish_no;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", publish_area) + "<b></td>");
                tot_publish_area = tot_publish_area + publish_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", publish_amt) + "<b></td>");
                tot_publish_amt = tot_publish_amt + publish_amt;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_no) + "<b></td>");
                tot_book_no = tot_book_no + book_no;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", book_area) + "<b></td>");
                tot_book_area = tot_book_area + book_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", book_amt) + "<b></td>");
                tot_book_amt = tot_book_amt + book_amt;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_no) + "<b></td>");
                tot_tot_no = tot_tot_no + tot_no;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_area) + "<b></td>");
                tot_tot_area = tot_tot_area + tot_area;
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_amt) + "<b></td>");
                tot_tot_amt = tot_tot_amt + tot_amt;


                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='3' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='28%'><b>" + "Grand Total" + "</b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_billed_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_billed_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_publish_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_publish_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_book_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_book_amt) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_no) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='5%'><b>" + string.Format("{0:0.00}", tot_tot_area) + "<b></td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;padding-right:10px;' width='8%'><b>" + string.Format("{0:0.00}", tot_tot_amt) + "<b></td>");

                TBL.Append("</tr>");

                TBL.Append("</table>");
                TBL.Append("</table></p>");
            }

            report.InnerHtml = TBL.ToString();
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