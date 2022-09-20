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

public partial class weekly_monthly_reports_print : System.Web.UI.Page
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
    int rowcount = 0;
    int maxlimit = 30;
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
        int pno = 1;
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
            ScriptManager.RegisterClientScriptBlock(this, typeof(weekly_monthly_reports_print), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }
        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            string reportname1 = "Week wise and Publication wise Revenue";

            tbl1 = tbl1 + "<tr><td>";
            //tbl1 = tbl1 + "<table style='width:100%' >";
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
            tbl1 = tbl1 + "<tr><td  align='right' style='font-family:Arial;font-size:12px;' colspan='4'><b>Page No.:</b>" + pno + "</td></tr>";
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
            //tbl1 = tbl1 + " </table>";

            ////////////////////for column names//////////////////
            tbl1 = tbl1 + "<p style='page-break-after:always'><table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
            string sp_week = "";
            for (int i = 2; i < (ds.Tables[0].Columns.Count); i++)
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
                //tbl1 = tbl1 + "<tr>";
                for (int j = 5; j < ds.Tables[0].Columns.Count; j++)
                {
                    string branch_brk = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    if (rowcount == maxlimit)
                    {
                        pno = pno + 1;
                        rowcount = 0;
                        tbl1 = tbl1 + "</table></p>";
                        tbl1 = tbl1 + "<p style='page-break-before:always'><table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
                        tbl1 = tbl1 + "<tr><td>";
                        //tbl1 = tbl1 + "<table style='width:100%' >";
                        tbl1 = tbl1 + "<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
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

                        tbl1 = tbl1 + "<tr><td  align='right' style='font-family:Arial;font-size:12px;' colspan='4'><b>Page No.:</b>" + pno + "</td></tr>";
                        tbl1 = tbl1 + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";

                        string sp_week1 = "";
                        for (int l = 5; l < (ds.Tables[0].Columns.Count); l++)
                        {
                            if (ds.Tables[0].Columns[l].Caption == "PUBL_NAME")
                            {
                                tbl1 = tbl1 + "<tr><td width='60px' class='middle31new' align='left'><b>Publication</b></td>";
                            }
                            else if (ds.Tables[0].Columns[l].Caption == "TOTOL")
                            {
                                tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>Total</b>";
                                tbl1 = tbl1 + "</br>No. of Insertions";
                                tbl1 = tbl1 + "</td>";
                            }
                            else if (ds.Tables[0].Columns[l].Caption == "NO_OF_INSERT")
                            {
                                tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>" + "" + "</b>";
                                tbl1 = tbl1 + "</br>Amount";
                                tbl1 = tbl1 + "</td>";
                            }
                            else if (l >= 6)
                            {
                                string[] split_week = ds.Tables[0].Columns[l].Caption.Split('#');
                                if (sp_week1.IndexOf(split_week[1]) < 0)
                                {
                                    tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>" + split_week[1] + "</b>";
                                    tbl1 = tbl1 + "</br>No. of Insertions";
                                    tbl1 = tbl1 + "</td>";
                                    tbl1 = tbl1 + "<td width='60px' class='middle31new' align='right'><b>" + "" + "</b>";
                                    tbl1 = tbl1 + "</br>Amount";
                                    tbl1 = tbl1 + "</td>";
                                }
                                sp_week1 += split_week[1] + "~";
                            }
                        }
                        tbl1 = tbl1 + "</tr>";
                    }
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
                        tbl1 = tbl1 + "<td width='60px' class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j - 1]).ToString("F2") + "</td>";
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
                            tbl1 = tbl1 + "<td width='60px' class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                        }
                        else
                        {
                            tbl1 = tbl1 + "<td width='60px' class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "</td>";
                        }
                    }

                }
                rowcount++;
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
                            tbl1 += "<td width='60px' class='middle31new' align='right'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c].ToString() + "</td>";
                        }
                        else if (split_ad_type[0] == "A")
                        {
                            tbl1 += "<td width='60px' class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c]).ToString("F2") + "</td>";
                        }
                    }
                    tbl1 += "</tr>";
                }
            }
            tbl1 = tbl1 + "</table>";
            tblgrid.InnerHtml = tbl1;
                        
        }
    }
}
