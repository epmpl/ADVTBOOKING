using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;

public partial class weekly_monthly_reports_view : System.Web.UI.Page
{
    string rundate = "";
    string Destination = "";
    string fromdate = "";
    string todate = "";
    string basedon = "";
    string printing_centercode = "";
    string printingcentername = "";
    string printingcenter_name = "";
    string branch_name = "";
    string publication = "";
    string publicationname = "";
    string branchcode = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string extra6 = "";
    string extra7 = "";
    string extra8 = "";
    string extra9 = "";
    string extra10 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();
        hdncompcode.Value = Session["compcode"].ToString();
        hdnuserid.Value = Session["userid"].ToString();
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script> window.parent.location=\" login.aspx\";</script>)");
            return;
        }
        rundate = DateTime.Today.ToString().Split(' ')[0];
        string date11117 = rundate;
        string dd7 = date11117.Split('/')[1];
        string mm7 = date11117.Split('/')[0];
        string yyyy7 = date11117.Split('/')[2];
        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {
            rundate = RETURN_LENGTH(dd7) + "/" + RETURN_LENGTH(mm7) + "/" + yyyy7;
        }
        else
            if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
            {
                rundate = yyyy7 + "/" + RETURN_LENGTH(mm7) + "/" + RETURN_LENGTH(dd7);
            }
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/datewise_billing_report.xml"));

        Destination = Request.QueryString["Destination"].ToString();

        fromdate = Request.QueryString["fromdate"].ToString();
        hdnfromdate11.Value = Request.QueryString["fromdate"].ToString();

        todate = Request.QueryString["todate"].ToString();
        hdntodate11.Value = Request.QueryString["todate"].ToString();
                
        printing_centercode = Request.QueryString["printingcenter"].ToString();
        hdnprinting_centercode11.Value = Request.QueryString["printingcenter"].ToString();

        printingcentername = Request.QueryString["printingcenter_name"].ToString();
        hdnprinting_centername11.Value = Request.QueryString["printingcenter_name"].ToString();

        branchcode = Request.QueryString["branch"].ToString();
        hdnbranchcode11.Value = Request.QueryString["branch"].ToString();

        branch_name = Request.QueryString["branch_name"].ToString();
        hdnbranchname11.Value = Request.QueryString["branch_name"].ToString();

        publication = Request.QueryString["publication_code"].ToString();
        hdnpublication.Value = Request.QueryString["publication_code"].ToString();

        publicationname = Request.QueryString["pub_name"].ToString();
        hdnpubname.Value = Request.QueryString["pub_name"].ToString();

        basedon = Request.QueryString["based_on"].ToString();
        hdnbasedon.Value = Request.QueryString["based_on"].ToString();

        extra1 = Request.QueryString["ext1"].ToString();
        hdnextra111.Value = Request.QueryString["ext1"].ToString();

        extra2 = Request.QueryString["ext2"].ToString();
        hdnextra211.Value = Request.QueryString["ext2"].ToString();

        extra3 = Request.QueryString["ext3"].ToString();
        hdnextra311.Value = Request.QueryString["ext3"].ToString();

        extra4 = Request.QueryString["ext4"].ToString();
        hdnextra411.Value = Request.QueryString["ext4"].ToString();

        extra5 = Request.QueryString["ext5"].ToString();
        hdnextra511.Value = Request.QueryString["ext5"].ToString();

        extra6 = Request.QueryString["ext6"].ToString();
        hdnextra611.Value = Request.QueryString["ext6"].ToString();

        extra7 = Request.QueryString["ext7"].ToString();
        hdnextra711.Value = Request.QueryString["ext7"].ToString();

        extra8 = Request.QueryString["ext8"].ToString();
        hdnextra811.Value = Request.QueryString["ext8"].ToString();

        extra9 = Request.QueryString["ext9"].ToString();
        hdnextra911.Value = Request.QueryString["ext9"].ToString();

        extra10 = Request.QueryString["ext10"].ToString();
        hdnextra10.Value = Request.QueryString["ext10"].ToString();

        if (!Page.IsPostBack)
        {
            if (Destination == "1" || Destination == "0")
            {
                ShowReport();
            }
            else if (Destination == "4")
            {
                showreportexcel();
            }
            else if (Destination == "3")
            {
                pdf();
            }
            
        }
    }


    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }
    private void ShowReport()
    {
        string tbl1 = "";
        string code_data = "";
        int t = 0;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.weekly_monthly_reports rpt = new NewAdbooking.Report.Classes.weekly_monthly_reports();
            ds = rpt.weekwise_billing(hdncompcode.Value, printing_centercode, branchcode, publication, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), basedon, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.weekly_monthly_reports rpt = new NewAdbooking.Report.classesoracle.weekly_monthly_reports();
            ds = rpt.weekwise_billing(hdncompcode.Value, printing_centercode, branchcode, publication, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), basedon, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(weekly_monthly_reports_view), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }
        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            string reportname1 = "Week wise and Publication wise Revenue";

            tbl1 = tbl1 + "<tr><td>";
            tbl1 = tbl1 + "<table style='width:100%' >";
            tbl1 = tbl1 + "<tr><td></td><td align='center' style='height: 20px;padding-right:130px' colspan='2' class='headingc' > ";
            tbl1 = tbl1 + compname1;
            tbl1 = tbl1 + "</td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' colspan='2' class ='headingp1'><b>";
            tbl1 = tbl1 + reportname1;
            tbl1 = tbl1 + "</b></td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-family:Arial;font-size:12px' colspan='2'><b>From Date  </b>" + fromdate + "<b>    To   </b>" + todate + "</td>";
            tbl1 = tbl1 + "</tr>";

            tbl1 = tbl1 + "<tr><td style='width: 69px'> </td></tr></table>";

            tbl1 = tbl1 + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
            tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;' colspan='4'><b>Run Date:</b>" + rundate + "</td></tr>";
            string printingname = "";
            if (printingcentername == "" || printingcentername == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = printingcentername;
            }
            tbl1 = tbl1 + "<tr><td  align='left'style='font-family:Arial;font-size:12px; width:40%;'><b>Printing Center:</b>" + printingname + "</td>";

            string brname = "";
            if (branch_name == "" || branch_name == null)
            {
                brname = "All";

            }
            else
            {
                brname = branch_name;
            }
            tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Branch Name:</b>" + brname + "</td></tr>";

            //string pub_name = "";
            //if (publicationname == "" || publicationname == null)
            //{
            //    pub_name = "All";

            //}
            //else
            //{
            //    pub_name = publicationname;
            //}

            //tbl1 = tbl1 + "<tr><td  align='left' style='font-family:Arial;font-size:12px;'><b>Publication:</b>" + pub_name + "</td>";
            
            //tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
            tbl1 = tbl1 + " </table>";

            ////////////////////for column names
            tbl1 = tbl1 + "<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
            string sp_week = "";
            for (int i = 5; i < (ds.Tables[0].Columns.Count); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "PUBL_NAME")
                {
                    tbl1 = tbl1 + "<tr><td width='60px' class='middle31new' align='left'><b>Publication</b></td>";
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>Total</b>";
                    tbl1 = tbl1 + "</br>No. of Insertions";
                    tbl1 = tbl1 + "</td>";
                }
                else if (ds.Tables[0].Columns[i].Caption == "NO_OF_INSERT")
                {
                    tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>" + "" + "</b>";
                    tbl1 = tbl1 + "</br>Amount";
                    tbl1 = tbl1 + "</td>";
                }
                else if (i >= 6)
                {
                    string[] split_week = ds.Tables[0].Columns[i].Caption.Split('#');
                    if (sp_week.IndexOf(split_week[1]) < 0)
                    {
                        tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>" + split_week[1] + "</b>";
                        tbl1 = tbl1 + "</br>No. of Insertions";
                        tbl1 = tbl1 + "</td>";
                        tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>" + "" + "</b>";
                        tbl1 = tbl1 + "</br>Amount";
                        tbl1 = tbl1 + "</td>";
                    }
                    sp_week += split_week[1] + "~";
                }
            }
            tbl1 = tbl1 + "</tr>";
            //==================================================for values=========================================================================================================================
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tbl1 = tbl1 + "<tr>";
                for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
                {
                    string branch_brk = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    if (code_data.IndexOf(branch_brk) < 0)
                    {
                        if (i > 0)
                        {
                            tbl1 += "<tr><td width='60px' class='middle31new'>" + ds.Tables[1].Rows[t - 1].ItemArray[3].ToString() + " Total</td>";
                            for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                            {
                                string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                                if (c == ds.Tables[1].Columns.Count - 1)
                                {
                                    tbl1 += "<td width='60px' class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c - 1]).ToString("F2") + "</td>";
                                }
                                else if (c == ds.Tables[1].Columns.Count - 2)
                                {
                                    tbl1 += "<td width='60px' class='middle31new' align='right'>" + ds.Tables[1].Rows[t - 1].ItemArray[c + 1].ToString() + "</td>";
                                }
                                else if (split_ad_type[0] == "R")
                                {
                                    tbl1 += "<td width='60px' class='middle31new' align='right'>" + ds.Tables[1].Rows[t - 1].ItemArray[c].ToString() + "</td>";
                                }
                                else if (split_ad_type[0] == "A")
                                {
                                    tbl1 += "<td width='60px' class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c]).ToString("F2") + "</td>";
                                }
                            }
                            tbl1 += "</tr>";
                        }
                        code_data += ds.Tables[1].Rows[t].ItemArray[3].ToString() + "~";
                        t++;
                    }
                    if (j == 5)
                    {
                        tbl1 = tbl1 + "<td width='60px' class='rep_data' align='left'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                    }
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        tbl1 = tbl1 + "<td width='60px' class='rep_data' align='right' >" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j - 1]).ToString("F2") + "</td>";
                    }
                    else if (j == ds.Tables[0].Columns.Count - 2)
                    {
                        tbl1 = tbl1 + "<td width='60px' class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j + 1].ToString() + "</td>"; 
                    }
                    else if (j >= 6)
                    {
                        string[] split_adtype = ds.Tables[0].Columns[j].Caption.Split('#');
                        if (split_adtype[0] == "R")
                        {
                            tbl1 = tbl1 + "<td class='rep_data' align='right' width='60px'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                        }
                        else
                        {
                            tbl1 = tbl1 + "<td class='rep_data' align='right' width='60px'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "</td>";
                        }
                    }
                    
                }
                tbl1 = tbl1 + "</tr>";
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    tbl1 += "<tr><td width='60px' class='middle31new'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[3].ToString() + " Total</td>";
                    for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                    {
                        string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                        if (c == ds.Tables[1].Columns.Count - 1)
                        {
                            tbl1 += "<td width='60px' class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c - 1]).ToString("F2") + "</td>";
                        }
                        else if (c == ds.Tables[1].Columns.Count - 2)
                        {
                            tbl1 += "<td width='60px' class='middle31new' align='right'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c + 1].ToString() + "</td>";
                        }
                        else if (split_ad_type[0] == "R")
                        {
                            tbl1 += "<td width='60px' class='middle31new' align='right' width='50px'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c].ToString() + "</td>";
                        }
                        else if (split_ad_type[0] == "A")
                        {
                            tbl1 += "<td width='60px' class='middle31new' align='right' width='50px'>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c]).ToString("F2") + "</td>";
                        }
                    }
                    tbl1 += "</tr>";
                }
            }
            tbl1 = tbl1 + "</table>";
            tblgrid.InnerHtml = tbl1;

            btnprint.Attributes.Add("onclick", "javascript:return window.open('weekly_monthly_reports_print.aspx?Destination=" + Destination + "&fromdate=" + fromdate + "&todate=" + todate + "&printingcenter_name=" + printingcentername + "&printingcenter=" + printing_centercode + "&branch=" + branchcode + "&branch_name=" + branch_name + "&publication_code=" + publication + "&pub_name=" + publicationname + "&based_on=" + basedon + "&ext1=" + extra1 + "&ext2=" + extra2 + "&ext3=" + extra3 + "&ext4=" + extra4 + "&ext5=" + extra5 + "&ext6=" + extra6 + "&ext7=" + extra7 + "&ext8=" + extra8 + "&ext9=" + extra9 + "&ext10=" + extra10 + "')");
        }
    }

    private void showreportexcel()
    {
        string tbl1 = "";
        string code_data = "";
        int t = 0;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.weekly_monthly_reports rpt = new NewAdbooking.Report.Classes.weekly_monthly_reports();
            ds = rpt.weekwise_billing(hdncompcode.Value, printing_centercode, branchcode, publication, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), basedon, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.weekly_monthly_reports rpt = new NewAdbooking.Report.classesoracle.weekly_monthly_reports();
            ds = rpt.weekwise_billing(hdncompcode.Value, printing_centercode, branchcode, publication, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), basedon, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(weekly_monthly_reports_view), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top'>";

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            string reportname1 = "Week wise and Publication wise Revenue";
            int col1 = (ds.Tables[0].Columns.Count - 4) / 2;
            tbl1 = tbl1 + "<tr><td>";
            tbl1 = tbl1 + "<table style='width:100%' >";
            tbl1 = tbl1 + "<tr><td></td><td align='center' style='height: 20px; width:100%;' class='headingc' ColSpan=" + col1 + "> ";
            tbl1 = tbl1 + compname1;
            tbl1 = tbl1 + "</td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' class ='headingp1' ColSpan=" + col1 + "><b>";
            tbl1 = tbl1 + reportname1;
            tbl1 = tbl1 + "</b></td></tr>";

            tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
            tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-family:Arial;font-size:12px' ColSpan=" + col1 + "><b>From Date  </b>" + fromdate + "<b>    To   </b>" + todate + "</td>";
            tbl1 = tbl1 + "</tr>";
            int col = ds.Tables[0].Columns.Count-6;

            tbl1 = tbl1 + "<tr><td style='width: 69px'> </td></tr></table>";
            
            tbl1 = tbl1 + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='1' width='100%' >";
            tbl1 = tbl1 + "<tr><td  align='left' style='font-family:Arial;font-size:12px;width:60%;'>" + "" + "</td>";
            tbl1 = tbl1 + "<td align='right'style='font-family:Arial;font-size:12px;'ColSpan="+col+"><b>Run Date:</b>" + rundate + "</td></tr>";
            string printingname = "";
            if (printingcentername == "" || printingcentername == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = printingcentername;
            }
            tbl1 = tbl1 + "<tr><td  align='left'style='font-family:Arial;font-size:12px; width:60%;'><b>Printing Center:</b>" + printingname + "</td>";

            string brname = "";
            if (branch_name == "" || branch_name == null)
            {
                brname = "All";

            }
            else
            {
                brname = branch_name;
            }
            tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;' ColSpan=" + col + "><b>Branch Name:</b>" + brname + "</td></tr>";

            //string pub_name = "";
            //if (publicationname == "" || publicationname == null)
            //{
            //    pub_name = "All";

            //}
            //else
            //{
            //    pub_name = publicationname;
            //}

            //tbl1 = tbl1 + "<tr><td  align='left' style='font-family:Arial;font-size:12px;'><b>Publication:</b>" + pub_name + "</td>";

            //tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
            tbl1 = tbl1 + " </table>";
            ////////////////////for column names
            tbl1 = tbl1 + "<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='1'>";
            string sp_adcat = "";
            string sp_week = "";
            tbl1 = tbl1 + "<tr>";
            for (int i = 2; i < (ds.Tables[0].Columns.Count - 1); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "PUBL_NAME")
                {
                    tbl1 = tbl1 + "<td class='middle31new' align='left'><b>Publication</b></td>";
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1 = tbl1 + "<td ColSpan='2' class='middle31new' align='right'><b>Total</b>";
                    //tbl1 = tbl1 + "</br>No. of Insertion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount";
                    tbl1 = tbl1 + "</td>";
                }
                else if (i >= 6)
                {
                    string[] split_week = ds.Tables[0].Columns[i].Caption.Split('#');
                    if (sp_week.IndexOf(split_week[1]) < 0)
                    {
                        tbl1 = tbl1 + "<td ColSpan='2' class='middle31new' align='right'><b>" + split_week[1] + "</b>";
                        //tbl1 = tbl1 + "</br>No. of Insertion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount&nbsp;&nbsp;";
                        tbl1 = tbl1 + "</td>";
                    }
                    sp_week += split_week[1] + "~";
                }
            }
            tbl1 = tbl1 + "</tr>";
            tbl1 += "<tr>";
            for (int i = 5; i < (ds.Tables[0].Columns.Count-1); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "PUBL_NAME")
                {
                    tbl1 = tbl1 + "<td class='middle31new' align='left'><b>" + "&nbsp;" + "</b></td>";
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1 = tbl1 + "<td ColSpan='1' class='middle31new' align='right'><b>No. of insertions</b>";
                    tbl1 = tbl1 + "<td ColSpan='1' class='middle31new' align='right'><b>Amount</b>";
                    //tbl1 = tbl1 + "</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO";
                    tbl1 = tbl1 + "</td>";
                }
                else if (i >= 6 && i < ds.Tables[0].Columns.Count)
                {
                    
                    string[] split_week = ds.Tables[0].Columns[i].Caption.Split('#');
                    if (sp_adcat.IndexOf(split_week[1]) < 0)
                    {
                        tbl1 = tbl1 + "<td class='middle31new' align='right'><b>No. of insertions</b>";
                        tbl1 = tbl1 + "<td class='middle31new' align='right'><b>Amount</b>";
                        //tbl1 = tbl1 + "</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO";
                        tbl1 = tbl1 + "</td>";
                        sp_adcat += split_week[1] + "~";
                    }
                    //sp_adtype += split_adtype[0] + "~";
                }

            }
            //==================================================for values=========================================================================================================================
            tbl1 = tbl1 + "<tr>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //tbl1 = tbl1 + "<tr>";
                for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
                {
                    string branch_brk = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    if (code_data.IndexOf(branch_brk) < 0)
                    {
                        if (i > 0)
                        {
                            tbl1 += "<tr><td class='middle31new'><b>" + ds.Tables[1].Rows[t - 1].ItemArray[3].ToString() + " Total</b></td>";
                            for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                            {
                                string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                                if (c == ds.Tables[1].Columns.Count - 1)
                                {
                                    tbl1 += "<td class='middle31new' align='right'><b>" + Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c - 1]).ToString("F2") + "</b></td>";
                                }
                                else if (c == ds.Tables[1].Columns.Count - 2)
                                {
                                    tbl1 += "<td class='middle31new' align='right'><b>" + ds.Tables[1].Rows[t - 1].ItemArray[c + 1].ToString() + "</b></td>";
                                }
                                else if (split_ad_type[0] == "R")
                                {
                                    tbl1 += "<td class='middle31new' align='right'><b>" + Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c]).ToString("F2") + "</b></td>";
                                }
                                else if (split_ad_type[0] == "A")
                                {
                                    tbl1 += "<td class='middle31new' align='right'><b>" + ds.Tables[1].Rows[t - 1].ItemArray[c].ToString() + "</b></td>";
                                }
                            }
                            tbl1 += "</tr>";
                        }
                        code_data += ds.Tables[1].Rows[t].ItemArray[3].ToString() + "~";
                        t++;
                    }
                    if (j == 5)
                    {
                        tbl1 = tbl1 + "<td class='rep_data' align='left'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                    }
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        tbl1 = tbl1 + "<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j - 1]).ToString("F2") + "</td>";
                    }
                    else if (j == ds.Tables[0].Columns.Count - 2)
                    {
                        tbl1 = tbl1 + "<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j + 1].ToString() + "</td>";
                    }
                    else if (j >= 6)
                    {
                        string[] split_adtype = ds.Tables[0].Columns[j].Caption.Split('#');
                        if (split_adtype[0] == "R")
                        {
                            tbl1 = tbl1 + "<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                        }
                        else
                        {
                            tbl1 = tbl1 + "<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "&nbsp;&nbsp;</td>";
                        }
                    }

                }
                tbl1 = tbl1 + "</tr>";
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    tbl1 += "<tr><td class='middle31new'><b>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[3].ToString() + " Total</b></td>";
                    for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                    {
                        string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                        if (c == ds.Tables[1].Columns.Count - 1)
                        {
                            tbl1 += "<td class='middle31new' align='right'><b>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c - 1]).ToString("F2") + "</b></td>";
                        }
                        else if (c == ds.Tables[1].Columns.Count - 2)
                        {
                            tbl1 += "<td class='middle31new' align='right'><b>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c + 1].ToString() + "</b></td>";
                        }
                        else if (split_ad_type[0] == "R")
                        {
                            tbl1 += "<td class='middle31new' align='right'><b>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c].ToString() + "</b></td>";
                        }
                        else if (split_ad_type[0] == "A")
                        {
                            tbl1 += "<td class='middle31new' align='right'><b>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c]).ToString("F2") + "</b></td>";
                        }
                    }
                    tbl1 += "</tr>";
                }
            }
            tbl1 += "</tr>";
            tbl1 = tbl1 + "</table>";
            tblgrid.InnerHtml = tbl1;
        }
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        tblgrid.Visible = true;
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    private void pdf()
    {
        int t = 0;
        string code_data = "";
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        name = Server.MapPath("") + "//" + pdfName;

        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        iTextSharp.text.HeaderFooter footer = new iTextSharp.text.HeaderFooter(new iTextSharp.text.Phrase(i2++.ToString()), true);
        footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
        document.Footer = footer;
        footer.Border = 0;
        document.Open();

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.weekly_monthly_reports rpt = new NewAdbooking.Report.Classes.weekly_monthly_reports();
            ds = rpt.weekwise_billing(hdncompcode.Value, printing_centercode, branchcode, publication, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), basedon, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.weekly_monthly_reports rpt = new NewAdbooking.Report.classesoracle.weekly_monthly_reports();
            ds = rpt.weekwise_billing(hdncompcode.Value, printing_centercode, branchcode, publication, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), basedon, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10);
        }

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            iTextSharp.text.Font font9 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font10 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font11 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 10);
            iTextSharp.text.Font font8 = iTextSharp.text.FontFactory.getFont(iTextSharp.text.FontFactory.TIMES_ROMAN, 8);

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            PdfPTable tbl = new PdfPTable(1);
            tbl.DefaultCell.BorderWidth = 0;
            tbl.WidthPercentage = 100;
            tbl.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            tbl.addCell(new iTextSharp.text.Phrase(compname1, font9));
            tbl.addCell(new iTextSharp.text.Phrase("Date Wise/Category wise Billing Report", font9));
            tbl.addCell(new iTextSharp.text.Phrase("From Date:" + fromdate + "To:" + todate, font10));
            document.Add(tbl);

            ///////////////////for header
            PdfPTable tbl7 = new PdfPTable(2);
            tbl7.DefaultCell.BorderWidth = 0;
            tbl7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl7.WidthPercentage = 100;
            tbl7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            tbl7.addCell(new iTextSharp.text.Phrase("", font10));
            tbl7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            tbl7.addCell(new iTextSharp.text.Phrase("Run Date: " + rundate, font10));
            tbl7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
            if (printingcentername == "" || printingcentername == null)
            {
                tbl7.addCell(new iTextSharp.text.Phrase("Printing Center: " + "All", font10));
            }
            else
            {
                tbl7.addCell(new iTextSharp.text.Phrase("Printing Center: " + printingcentername, font10));
            }
            tbl7.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            if (branch_name == "" || branch_name == null)
            {
                tbl7.addCell(new iTextSharp.text.Phrase("Branch: " + "All", font10));
            }
            else
            {
                tbl7.addCell(new iTextSharp.text.Phrase("Branch: " + branch_name, font10));
            }
            document.Add(tbl7);

            //PdfPTable tbl8 = new PdfPTable(1);
            //tbl8.DefaultCell.BorderWidth = 0;
            //tbl8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            //tbl8.WidthPercentage = 100;
            //tbl8.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            //tbl8.addCell(new iTextSharp.text.Phrase("Run Date: " + rundate, font10));
            //document.Add(tbl8);
                        
            ///////////////////for Column Name//////////////////
            int cont = ds.Tables[0].Columns.Count;
            cont = cont - 5;

            PdfPTable tbl2 = new PdfPTable(cont);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.WidthPercentage = 100;
            string sp_week = "";
            iTextSharp.text.Phrase p3 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p3);
            for (int i = 2; i < (ds.Tables[0].Columns.Count - 1); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "PUBL_NAME")
                {
                    tbl2.addCell(new iTextSharp.text.Phrase("Publication", font10));
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    tbl2.addCell(new iTextSharp.text.Phrase("Total" + "\n" + "No. of Insertions", font10));
                    tbl2.addCell(new iTextSharp.text.Phrase("\n" + "Amount", font10));
                }
                else if (i >= 6)
                {
                    string[] split_week = ds.Tables[0].Columns[i].Caption.Split('#');
                    if (sp_week.IndexOf(split_week[1]) < 0)
                    {
                        tbl2.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl2.addCell(new iTextSharp.text.Phrase(split_week[1] + "\n" + "No. of Insertions", font10));
                        tbl2.addCell(new iTextSharp.text.Phrase("\n" + "Amount", font10));
                    }
                    sp_week += split_week[1] + "~";
                }
            }
            document.Add(tbl2);
            iTextSharp.text.Phrase p4 = new iTextSharp.text.Phrase("____________________________________________________________________________________________________________________");
            document.Add(p4);
            /////////////////////////////////for values
            PdfPTable tbl3 = new PdfPTable(cont);
            tbl3.DefaultCell.BorderWidth = 0;
            tbl3.WidthPercentage = 100;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
                {
                    string branch_brk = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    if (code_data.IndexOf(branch_brk) < 0)
                    {
                        if (i > 0)
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                            tbl3.DefaultCell.Colspan = cont;
                            tbl3.addCell(new iTextSharp.text.Phrase("_____________________________________________________________________________________________________________________________________________", font10));
                            tbl3.DefaultCell.Colspan = 1;
                            tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t - 1].ItemArray[3].ToString() + " Total", font10));
                            for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                            {
                                string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                                if (c == ds.Tables[1].Columns.Count - 1)
                                {
                                    tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl3.addCell(new iTextSharp.text.Phrase(Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c-1]).ToString("F2"), font10));
                                    //tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[t - 1].ItemArray[c - 1].ToString() + "</td>";
                                }
                                else if (c == ds.Tables[1].Columns.Count - 2)
                                {
                                    tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t - 1].ItemArray[c+1].ToString(), font10));
                                    //tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[t - 1].ItemArray[c + 1].ToString() + "</td>";
                                }
                                else if (split_ad_type[0] == "R")
                                {
                                    tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl3.addCell(new iTextSharp.text.Phrase(Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c]).ToString("F2"), font10));
                                    //tbl1 += "<td class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c]).ToString("F2") + "</td>";
                                }
                                else if (split_ad_type[0] == "A")
                                {
                                    tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                                    tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[t - 1].ItemArray[c].ToString(), font10));
                                    //tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[t - 1].ItemArray[c].ToString() + "</td>";
                                }
                            }
                            tbl3.DefaultCell.Colspan = cont;
                            tbl3.addCell(new iTextSharp.text.Phrase("_____________________________________________________________________________________________________________________________________________", font10));
                            tbl3.DefaultCell.Colspan = 1;
                        }
                        code_data += ds.Tables[1].Rows[t].ItemArray[3].ToString() + "~";
                        t++;
                    }
                    if (j == 5)
                    {
                        tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                        tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[i].ItemArray[j].ToString(), font11));
                        //tbl1 = tbl1 + "<td class='rep_data' align='left'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                    }
                    else if (j == ds.Tables[0].Columns.Count - 1)
                    {
                        tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl3.addCell(new iTextSharp.text.Phrase(Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j-1]).ToString("F2"), font11));
                        //tbl1 = tbl1 + "<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j - 1]).ToString("F2") + "</td>";
                    }
                    else if (j == ds.Tables[0].Columns.Count - 2)
                    {
                        tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[i].ItemArray[j+1].ToString(), font11));
                        //tbl1 = tbl1 + "<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j + 1].ToString() + "</td>";
                    }
                    else if (j >= 6)
                    {
                        string[] split_adtype = ds.Tables[0].Columns[j].Caption.Split('#');
                        if (split_adtype[0] == "R")
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[0].Rows[i].ItemArray[j].ToString(), font11));
                            //tbl1 = tbl1 + "<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                        }
                        else
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl3.addCell(new iTextSharp.text.Phrase(Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2"), font11));
                            //tbl1 = tbl1 + "<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "&nbsp;&nbsp;</td>";
                        }
                    }
                }
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    tbl3.DefaultCell.Colspan = cont;
                    tbl3.addCell(new iTextSharp.text.Phrase("_____________________________________________________________________________________________________________________________________________", font10));
                    tbl3.DefaultCell.Colspan = 1;
                    tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[3].ToString() + " Total", font10));
                    //tbl1 += "<tr><td class='middle31new'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[3].ToString() + " Total</td>";
                    for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                    {
                        string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                        if (c == ds.Tables[1].Columns.Count - 1)
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl3.addCell(new iTextSharp.text.Phrase(Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c-1]).ToString("F2"), font10));
                            //tbl1 += "<td class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c - 1]).ToString("F2") + "</td>";
                        }
                        else if (c == ds.Tables[1].Columns.Count - 2)
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c+1].ToString(), font10));
                            //tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c + 1].ToString() + "</td>";
                        }
                        else if (split_ad_type[0] == "R")
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl3.addCell(new iTextSharp.text.Phrase(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c].ToString(), font10));
                            //tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c].ToString() + "</td>";
                        }
                        else if (split_ad_type[0] == "A")
                        {
                            tbl3.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                            tbl3.addCell(new iTextSharp.text.Phrase(Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c]).ToString("F2"), font10));
                            //tbl1 += "<td class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c]).ToString("F2") + "</td>";
                        }
                    }
                    tbl3.DefaultCell.Colspan = cont;
                    tbl3.addCell(new iTextSharp.text.Phrase("_____________________________________________________________________________________________________________________________________________", font10));
                    tbl3.DefaultCell.Colspan = 1;
                }
            }
            document.Add(tbl3);

            document.Close();
            Response.Redirect(pdfName, false);
        }
    }
}
