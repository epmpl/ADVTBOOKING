
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

public partial class Reports_qbc_alleditions_rpt_view : System.Web.UI.Page
{
    string comp_code    = "";
    string date_basedon = "";
    string year_basedon = "";
    string loc          = "";
    string unit         = "";
    string rp_type      = "";
    string destination  = "";
    string frdt         = "";
    string tbl1         = "";
    string todt         = "";
    string act          = "";
    string trnno        = "";
    string brancode     = "";
    string ReportName   = "";
    string dateformat   = "";
    string unitcode     = "";
   
        
    string extra = "";
    string extra1 = "", extra2 = "", extra3 = "", extra4 = "", extra5 = "", extra6 = "", extra7 = "", extra8 = "", extra9 = "", userid="";
    string flag = "";
    string cust = "";
    string f = "";
    string datetype = "";
    DataSet dsmain = new DataSet();
    StringBuilder TBL = new StringBuilder();
    StringBuilder head = new StringBuilder();
    StringBuilder head1 = new StringBuilder();


    int TotalColSpan = 0;
    int ColSpan1 = 0;
    int ColSpan2 = 0;
    string newfontww1 = "YES";
    double ALL_Total = 0;
    double col_sp = 0;
    int pagec;
    int pagecount;
    int pagewidth = 20;
    double tot_req_dep = 0;
    double tot_col_amt = 0;
    double tot_due_balance = 0;
    double tot_act_balance = 0;
    double tot_due_dep = 0;
    double tot_balance = 0;
    double tot_cur_balance = 0;
    double tot_held_dep = 0;
    int rowcount = 0;
    int maxlimit = 30;
    int m = 0;
    int s1 = 0;
    int p;
    //int m;
    int jj = 1;
    int kk;
    int ll;
    int j;
    static int current;
    static int ab = 0;
    static int b = 4;
    static int k;
    static int l;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your Session has been Expired!'); window.close();</script>)");
            return;
        }
        hdnusername.Value = Session["Username"].ToString();
        userid = Session["userid"].ToString();
        comp_code = Request.QueryString["compcode"].ToString();
        unitcode = Request.QueryString["unitcode"].ToString();
        brancode = Request.QueryString["brancode"].ToString();
        frdt = Request.QueryString["frdt"].ToString();
        todt = Request.QueryString["todt"].ToString();
        date_basedon = Request.QueryString["date_basedon"].ToString();
        year_basedon = Request.QueryString["year_basedon"].ToString();
        dateformat = Request.QueryString["dateformat"].ToString();
        extra1 = Request.QueryString["extra1"].ToString();
        extra2 = Request.QueryString["extra2"].ToString();
        extra3 = Request.QueryString["extra3"].ToString();
        extra4 = Request.QueryString["extra4"].ToString();
        extra5 = Request.QueryString["extra5"].ToString();
        destination = extra5;
        dsmain = new DataSet();
        string[] parameterValueArray = new string[] { comp_code, unitcode, brancode, frdt, todt, date_basedon, year_basedon, userid, dateformat, extra1, extra2, extra3, extra4, extra5 };
        if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string procedureName = "rpt_unitwise_business";
            NewAdbooking.Classes.CommonClass obj = new NewAdbooking.Classes.CommonClass();
            dsmain = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string procedureName = "rpt_unitwise_business";
            NewAdbooking.classesoracle.CommonClass obj = new NewAdbooking.classesoracle.CommonClass();
            dsmain = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (dsmain.Tables.Count == 0 || dsmain.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }
        else
        {
            TotalColSpan = (dsmain.Tables[0].Columns.Count) - 4;
            col_sp = TotalColSpan / 3;

            if (TotalColSpan % 2 == 0)
            {
                ColSpan1 = TotalColSpan / 2;
                ColSpan2 = ColSpan1;
            }
            else
            {
                ColSpan1 = (TotalColSpan - 1) / 2;
                ColSpan2 = ColSpan1 + 1;
            }
        }
        //===========================================for paging============================================================
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
            
                ReportName = "All Editions Business Report";
                showreportnew();
        }
        else
        {
            ReportName = "All Editions Business Report";
           // ReportViewexl();
            showreportnew();
        }

    }

    string ConvertDateAsDateformat(string date)
    {
        if (!string.IsNullOrEmpty(date))
        {
            if (dateformat.ToLower() == "dd/mm/yyyy")
            {
                date = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(date));
            }
            else if (dateformat.ToLower() == "mm/dd/yyyy")
            {
                date = string.Format("{0:MM/dd/yyyy}", DateTime.Parse(date));
            }
            else
            {
                date = string.Format("{0:yyyy/MM/dd}", DateTime.Parse(date));
            }
        }
        return date;
    }
    StringBuilder ReportHeadernew(int i)
    {
        head = new StringBuilder();
        head.Append("<table cellpadding='0' class='header111' width='99%' cellspacing='0' border='0' align='center' style='vertical-align:top;margin-left:auto; margin-right:auto;'>");
        head.Append("<tr class='header111' ><td colspan='" + TotalColSpan + "' style='font-size:20px;font-family:Verdana;text-align:center;color:black;text-decoration: blink;'><b>" + Session["comp_name"].ToString() + "</b></td></tr>");
        head.Append("<tr class='header111'><td colspan='" + TotalColSpan + "' style='font-size:15px;font-family:Verdana;text-align:center;color:black'><b>" + ReportName + "</b></td></tr>");
        head.Append("<tr class='header111'><td colspan='" + ColSpan1 + "' style='font-size:15px;font-family:Verdana;text-align:left;padding-left:10px;'><b>Unit : </b>" + unit + "</td>");
        head.Append("</tr>");
        head.Append("<tr><td colspan='" + 0 + "' style='font-size:15px;font-family:Verdana;text-align:left;padding-left:10px;'><b>From Date: </b>" + frdt + "</td>");
        head.Append("<td colspan='" + 0 + "' style='font-size:15px;font-family:Verdana;text-align:right;padding-right:10px;'><b>To Date: </b>" + todt + "</td>");
        head.Append("</tr>");
        head.Append("</table>");
        head.Append("<table cellpadding='0' cellspacing='0' border='0' style='vertical-align:top;overflow-y:scroll;margin-left:auto; margin-right:auto;'>");
        head.Append("<tr class='imageclass' style='height:25px;'>");
        head.Append("<td class='middle31' style='width:3%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black; border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>SR. NO.</b></td>");
        //head.Append("<td class='middle31' style='width:5%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black; border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>" + "Unit" + "</b><b> </b></td>");
        head.Append("<td class='middle31' style='width:5%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black; border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>" + "Branch" + "</b><b> </b></td>");
       
        for(int i1 =5; i1< dsmain.Tables[0].Columns.Count; i1++)
        {
            head.Append("<td class='middle31' style='width:5%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black; border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>" + dsmain.Tables[0].Columns[i1].ToString() + "</b><b> </b></td>");
        }
        
       
        head.Append("</tr>");
        return head;
    }
    string CheckValue(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            value = "&nbsp;";
        }
        return value;
    }
    public void showreportnew()
    {


        //=========================================================for paging==============================================================================================================
        int rcount = dsmain.Tables[0].Rows.Count;
        pagec = rcount % pagewidth;
        pagecount = rcount / pagewidth;

        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }
        //=================================for next and previous==================================================
        if (ll == 1)
        {
            kk = ll;
            jj = ll + 1;
        }
        else if (ll == pagecount)
        {
            kk = ll - 1;
            jj = ll;
        }
        else
        {
            kk = ll - 1;
            jj = ll + 1;
        }
        int r1 = p + pagewidth;
        //=================================with r1=================================================================
        ab = r1 / pagewidth;
        b = ab + 3;
        if (b > pagecount)
        {
            b = pagecount;
        }
        if (rcount == 0)
        {
            ab = 0;
            b = 0;
        }

        double [] tot = new double[10];
        double[] tot1 = new double[10];
        double final = 0;
        double actual = 0;
        double value = 0;
        double vatamt = 0;
        if (dsmain.Tables[0].Rows.Count > 0)
        {

            int sno = 1;
            TBL.Append(ReportHeadernew(0));
            TBL.Append("<tr >");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 11px; vertical-align :middle ;border-left:0px solid black;border-bottom:1px solid black;'>" + "Unit:" + CheckValue(dsmain.Tables[0].Rows[0]["UNIT_NAME"].ToString()) + "</td>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 12px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
            //TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 12px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
            for (int i3 = 5; i3 < dsmain.Tables[0].Columns.Count; i3++)
            {
                TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");

            }
            TBL.Append("</tr >");
            string pre_unit = CheckValue(dsmain.Tables[0].Rows[0]["UNIT_NAME"].ToString());
            string unit = CheckValue(dsmain.Tables[0].Rows[0]["UNIT_NAME"].ToString());
            for (int i = 0; i < dsmain.Tables[0].Rows.Count; i++)
            {
                if (destination == "1")
                {
                    if (rowcount == maxlimit)
                    {
                        rowcount = 0;
                        TBL.Append("</table><div style='page-break-after: always;'></div>");
                        TBL.Append(ReportHeadernew(0));
                    }
                }
                if (p % 2 == 0)
                {
                    // ======================================== For values =====================================================    
                    TBL.Append("<tr class='newfontww1'>");
                }
                else
                {
                    TBL.Append("<tr class='newfontww2'>");
                }
                p++;
                
                if (pre_unit != CheckValue(dsmain.Tables[0].Rows[i]["UNIT_NAME"].ToString()))
                {
                    TBL.Append("<tr >");
                    pre_unit = CheckValue(dsmain.Tables[0].Rows[i]["UNIT_NAME"].ToString());
                    TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black;border-left:1px solid black;border-top:0px solid black;border-bottom:1px solid black;'>" + "&nbsp;" + "</td>");
                    TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 15px; vertical-align :middle ;border-left:0px solid black; border-top:1px solid black;border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + "Total" + "</td>");
                    //TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 18px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
                    for (int i2 = 5; i2 < dsmain.Tables[0].Columns.Count; i2++)
                    {
                        TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 15px; vertical-align :middle ;border-left:1px solid black;border-top:1px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + tot[i2] + "</td>");

                    }
                    TBL.Append("</tr >");
                    tot = new double[10];
                    TBL.Append("<tr >");
                    TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 11px; vertical-align :middle ;border-left:0px solid black;border-bottom:1px solid black;'>" + "Unit:" + CheckValue(dsmain.Tables[0].Rows[i]["UNIT_NAME"].ToString()) + "</td>");
                    TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 12px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
                    //TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 12px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
                    for (int i3 = 5; i3 < dsmain.Tables[0].Columns.Count; i3++)
                    {
                        TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");

                    }
                    TBL.Append("</tr >");
                }
                // TBL.Append("<tr class='newfontww' style='height:20px;'>");
                TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black;border-bottom:1px solid black;'>" + sno.ToString() + "</td>");
                //TBL.Append("<td style='text-align:left;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + CheckValue(dsmain.Tables[0].Rows[i]["UNIT_NAME"].ToString()) + "</td>");
                TBL.Append("<td style='text-align:left;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black; border-top:1px solid black;border-right:0px solid black;padding-left:2px;'>" + CheckValue(dsmain.Tables[0].Rows[i]["BRANCH_NAME"].ToString()) + "</td>");
                for (int i2 = 5; i2 < dsmain.Tables[0].Columns.Count; i2++)
                {
                    TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black; border-top:1px solid black;border-right:0px solid black;padding-left:2px;'>" + CheckValue(dsmain.Tables[0].Rows[i][i2].ToString()) + "</td>");
                    tot[i2] = tot[i2] + Convert.ToDouble(CheckValue(dsmain.Tables[0].Rows[i][i2].ToString()));
                    tot1[i2] = tot1[i2] + Convert.ToDouble(CheckValue(dsmain.Tables[0].Rows[i][i2].ToString()));
                }
        
               
                TBL.Append("</tr>");
                rowcount++;
                sno++;
            }
            TBL.Append("<tr>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black;border-left:1px solid black;border-top:0px solid black;border-bottom:1px solid black;'>" + "&nbsp;" + "</td>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 15px; vertical-align :middle ;border-left:0px solid black; border-top:1px solid black;border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + "Total" + "</td>");
            //TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 18px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
            for (int i2 = 5; i2 < dsmain.Tables[0].Columns.Count; i2++)
            {
                TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 15px; vertical-align :middle ;border-left:1px solid black; border-top:1px solid black;border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + tot[i2] + "</td>");

            }


            TBL.Append("</tr>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-left:1px solid black;border-left:1px solid black;border-top:0px solid black;border-bottom:1px solid black;'>"+"&nbsp;"+"</td>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 15px; vertical-align :middle ;border-left:0px solid black; border-top:1px solid black;border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + "Grand Total" + "</td>");
            //TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:bold; font-size: 18px; vertical-align :middle ;border-left:0px solid black; border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'></td>");
            for (int i2 = 5; i2 < dsmain.Tables[0].Columns.Count; i2++)
            {
                TBL.Append("<td style='text-align:right;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 15px; vertical-align :middle ;border-left:1px solid black; border-top:1px solid black;border-bottom:1px solid black;border-right:0px solid black;padding-left:2px;'>" + tot1[i2] + "</td>");
                
            }

            
            TBL.Append("</tr>");
            TBL.Append("</table>");

            view.InnerHtml = TBL.ToString();
            f = "p";
            //btnprint.Attributes.Add("onclick", "javascript:window.open('printcomplete_rpt.aspx?comp_code=" + comp_code + "&publ=" + publ + "&edtn=" + edtn + "&loc=" + loc + "&unit=" + unit + "&rp_type=" + rp_type + "&destination=" + destination + "&from_date=" + from_date + "&to_date=" + to_date + "&act=" + act + "&trnno=" + trnno + "&branch=" + branch + "&dateformate=" + dateformate + "&status=" + status + "&gifttype=" + gifttype + "&acttype=" + acttype + "&flag=" + flag + "&cust=" + cust + ")");
           // btnprint.Attributes.Add("onclick", "javascript:window.open('print_qbc_alleditions_rpt.aspx?comp_code=" + comp_code + "&unitcode=" + unitcode + "&brancode=" + brancode + "&frdt=" + frdt + "&todt=" + todt + "&date_basedon=" + date_basedon + "&year_basedon=" + year_basedon + "&userid=" + userid + "&dateformat=" + dateformat + "&extra1=" + extra1 + "&extra2=" + extra2 + "&extra3=" + extra3 + "&extra4=" + extra4 + "&extra5=" + extra5 + "')");
            //window.open("qbc_alleditions_rpt_view.aspx?compcode=" + compcode + "&unitcode=" + unitcode + "&brancode=" + brancode + "&frdt=" + frdt + "&todt=" + todt + "&date_basedon=" + date_basedon + "&year_basedon=" + year_basedon + "&userid=" + userid + "&dateformat=" + dateformat + "&extra1=" + extra1 + "&extra2=" + extra2 + "&extra3=" + extra3 + "&extra4=" + extra4 + "&extra5=" + extra5, '');
            TBL.Append("</table>");
            view.InnerHtml = TBL.ToString();
            if (destination == "2")
            {
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                hw.WriteBreak();
                view.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria does not produce any result');</script>");
            Response.Write("<script>window.close();</script>");
            return;
        }
    }


    


   





}