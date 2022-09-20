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

public partial class datewise_billing_report_print : System.Web.UI.Page
{
    string Destination = "";
    string Report = "";
    string fromdate = "";
    string todate = "";
    string printing_centercode = "";
    string printingcentername = "";
    string printingcenter_name = "";
    string branch_name = "";
    string publication = "";
    string publicationname = "";
    string branchcode = "";
    string adv_type = "";
    string adtype_name = "";
    string adcat_code = "";
    string adv_category = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string d = "";
    string branch_find = "";
    int pageno = 1;
    string rundate = "";

    int maxlimit = 30;
    int sno = 1;
    string name1 = "", name2 = "", name3 = "";
    int rowcount = 0;
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

        Report = Request.QueryString["report_name"].ToString();

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

        adv_type = Request.QueryString["adtype"].ToString();
        hdnadtype.Value = Request.QueryString["adtype"].ToString();

        adtype_name = Request.QueryString["ad_type"].ToString();
        hdnad_type.Value = Request.QueryString["ad_type"].ToString();

        adcat_code = Request.QueryString["adcat"].ToString();
        hdnadcat.Value = Request.QueryString["adcat"].ToString();

        adv_category = Request.QueryString["ad_category"].ToString();
        hdnad_cat.Value = Request.QueryString["ad_category"].ToString();

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

        if (!Page.IsPostBack)
        {
            if (Report == "C")
            {
                ShowReport();
            }
            else
            {
                ShowReport1();
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
        int t = 0;
        string code_data = "";
        string tbl1 = "";
        int pno = 1;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billing_report rpt = new NewAdbooking.Report.Classes.datewise_billing_report();
            ds = rpt.category_billing(hdncompcode.Value, printing_centercode, branchcode, publication, adv_type, adcat_code, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billing_report rpt = new NewAdbooking.Report.classesoracle.datewise_billing_report();
            ds = rpt.category_billing(hdncompcode.Value, printing_centercode, branchcode, publication, adv_type, adcat_code, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "rpt_category_billing_summ";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hdncompcode.Value, printing_centercode, branchcode, publication, adv_type, adcat_code, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(datewise_billing_report_print), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }

        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            string reportname1 = "Date Wise/Category wise Billing Report";

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
            string pub_name = "";
            if (publicationname == "" || publicationname == null)
            {
                pub_name = "All";

            }
            else
            {
                pub_name = publicationname;
            }
            tbl1 = tbl1 + "<tr><td  align='left'style='font-family:Arial;font-size:12px; width:40%;'><b>Publication:</b>" + pub_name + "</td>";

            string printingname = "";
            if (printingcentername == "" || printingcentername == null)
            {
                printingname = "All";

            }
            else
            {
                printingname = printingcentername;
            }

            tbl1 = tbl1 + "<td  align='left' style='font-family:Arial;font-size:12px;'><b>Printing Center:</b>" + printingname + "</td>";
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


            string adt = "";
            if (adtype_name == "" || adtype_name == null)
            {
                adt = "All";

            }
            else
            {
                adt = adtype_name;
            }
            tbl1 = tbl1 + "<tr><td  align='left'style='font-family:Arial;font-size:12px; width:40%;'><b>Ad Type:</b>" + adt + "</td>";

            string adcatname = "";
            if (adv_category == "" || adv_category == null)
            {
                adcatname = "All";

            }
            else
            {
                adcatname = adv_category;
            }
            tbl1 = tbl1 + "<td  align='left'style='font-family:Arial;font-size:12px;'><b>Ad Category:</b>" + adcatname + "</td>";

            tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Run Date:</b>" + rundate + "</td></tr>";
            //string pno = 1;
            //tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Taluka Name:</b>" + pno + "</td></tr>";

            //tbl1 = tbl1 + " </table>";
            /*************************  Header Starts here ******************************/
            tbl1 = tbl1 + "<p style='page-break-after:always'><table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
            string sp_adtype = "";
            for (int i = 2; i < (ds.Tables[0].Columns.Count - 1); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "BILL_DATE")
                {
                    tbl1 = tbl1 + "<tr><td class='middle31new' align='left'><b>Bill Date</b></td>";
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1 = tbl1 + "<td ColSpan='2' class='middle31new' align='right'><b>Total</b>";
                    tbl1 = tbl1 + "</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO";
                    tbl1 = tbl1 + "</td>";
                }
                //else if (ds.Tables[0].Columns[i].Caption == "NO_OF_INSERT")
                //{
                //    tbl1 = tbl1 + "<td class='middle31new' align='right'>" + "";
                //    tbl1 = tbl1 + "</br>RO";
                //    tbl1 = tbl1 + "</td>";
                //}
                else if (i >= 5)
                {
                    string[] split_adtype = ds.Tables[0].Columns[i].Caption.Split('#');
                    if (sp_adtype.IndexOf(split_adtype[1]) < 0)
                    {
                        tbl1 = tbl1 + "<td ColSpan='2' class='middle31new' align='right'><b>" + get_adtype(hdncompcode.Value, split_adtype[1], "cat") + "</b>";
                        tbl1 = tbl1 + "</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO";
                        tbl1 = tbl1 + "</td>";
                    }
                    sp_adtype += split_adtype[1] + "~";
                }

            }
            tbl1 = tbl1 + "</tr>";
            //==================================================for values=========================================================================================================================
            //string tbl = tbl1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //tbl1 = tbl1 + "<tr>";
                for (int j = 2; j < ds.Tables[0].Columns.Count; j++)
                {
                    string pub_brk = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    if (rowcount == maxlimit)
                    {
                        pno = pno + 1;
                        rowcount = 0;
                        tbl1 = tbl1 + "</table></p>";
                        tbl1 = tbl1 + "<p style='page-break-before:always'><table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
                        tbl1 = tbl1 + "<tr><td>";
                        //tbl1 = tbl1 + "<tr><td>";
                        tbl1 = tbl1 + "<table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
                        tbl1 = tbl1 + "<tr><td></td><td align='center' style='height: 20px;padding-right:130px' colspan='2' class='headingc'> ";
                        tbl1 = tbl1 + compname1;
                        tbl1 = tbl1 + "</td></tr>";

                        tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style='height: 20px;'></td>";
                        tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-size:16px' colspan='2' class ='headingp1'><b>";
                        tbl1 = tbl1 + reportname1;
                        tbl1 = tbl1 + "</b></td></tr>";

                        tbl1 = tbl1 + "<tr style=width:100%'><td align='left' style= 'height: 20px;'  ></td>";
                        tbl1 = tbl1 + "<td align='center' style='height: 20px;padding-right:130px; font-family:Arial;font-size:12px' colspan='2'><b>From Date  </b>" + fromdate + "<b>    To   </b>" + todate + "</td>";
                        tbl1 = tbl1 + "</tr>";

                        tbl1 = tbl1 + "<tr><td style='width:69px'></td></tr></table>";

                        tbl1 = tbl1 + "<tr><td  align='right' style='font-family:Arial;font-size:12px;' colspan='4'><b>Page No.:</b>" + pno + "</td></tr>";
                        tbl1 = tbl1 + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";

                        string sp_adtype1 = "";
                        for (int l = 2; l < (ds.Tables[0].Columns.Count - 1); l++)
                        {
                            if (ds.Tables[0].Columns[l].Caption == "BILL_DATE")
                            {
                                tbl1 = tbl1 + "<tr><td class='middle31new' align='left'><b>Bill Date</b></td>";
                            }
                            else if (ds.Tables[0].Columns[l].Caption == "TOTOL")
                            {
                                tbl1 = tbl1 + "<td ColSpan='2' class='middle31new' align='right'><b>Total</b>";
                                tbl1 = tbl1 + "</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO";
                                tbl1 = tbl1 + "</td>";
                            }
                            else if (l >= 5)
                            {
                                string[] split_adtype = ds.Tables[0].Columns[l].Caption.Split('#');
                                if (sp_adtype1.IndexOf(split_adtype[1]) < 0)
                                {
                                    tbl1 = tbl1 + "<td ColSpan='2' class='middle31new' align='right'><b>" + get_adtype(hdncompcode.Value, split_adtype[1], "cat") + "</b>";
                                    tbl1 = tbl1 + "</br>Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RO";
                                    tbl1 = tbl1 + "</td>";
                                                                    }
                                sp_adtype1 += split_adtype[1] + "~";
                            }
                            
                        }
                        tbl1 = tbl1 + "</tr>";
                        
                    }
                    if (code_data.IndexOf(pub_brk) < 0)
                    {
                        if (i > 0)
                        {
                            tbl1 += "<tr><td class='middle31new'>" + ds.Tables[1].Rows[t - 1].ItemArray[3].ToString() + " Total</td>";
                            for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                            {
                                string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                                if (split_ad_type[0] == "A")
                                {
                                    tbl1 += "<td class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[t - 1].ItemArray[c]).ToString("F2") + "</td>";
                                }
                                else
                                {
                                    tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[t - 1].ItemArray[c].ToString() + "</td>";
                                }
                            }
                            tbl1 += "</tr>";
                        }
                        code_data += ds.Tables[1].Rows[t].ItemArray[3].ToString() + "~";
                        t++;
                    }
                    if (j == 2)
                    {
                        tbl1 = tbl1 + "<td class='rep_data' align='left'>" + changeformat1(ds.Tables[0].Rows[i].ItemArray[j].ToString()) + "</td>";
                    }
                    else if (j >= 5)
                    {
                        string[] split_adtype = ds.Tables[0].Columns[j].Caption.Split('#');
                        if (split_adtype[0] == "A")
                        {
                            tbl1 = tbl1 + "<td class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "</td>";
                        }
                        else
                        {
                            tbl1 = tbl1 + "<td class='rep_data' align='right'>" + ds.Tables[0].Rows[i].ItemArray[j].ToString() + "</td>";
                        }
                    }

                }
                rowcount++;

                tbl1 = tbl1 + "</tr>";
                if (i == ds.Tables[0].Rows.Count - 1)
                {
                    tbl1 += "<tr><td class='middle31new'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[3].ToString() + " Total</td>";
                    for (int c = 4; c < ds.Tables[1].Columns.Count; c++)
                    {
                        string[] split_ad_type = ds.Tables[1].Columns[c].Caption.Split('#');
                        if (split_ad_type[0] == "A")
                        {
                            tbl1 += "<td class='middle31new' align='right'>" + Convert.ToDouble(ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c]).ToString("F2") + "</td>";
                        }
                        else
                        {
                            tbl1 += "<td class='middle31new' align='right'>" + ds.Tables[1].Rows[ds.Tables[1].Rows.Count - 1].ItemArray[c].ToString() + "</td>";
                        }
                    }
                    tbl1 += "</tr>";
                }

            }
            tbl1 = tbl1 + "</table>";

            tblgrid.InnerHtml = tbl1;
            
        }
    }
    private void ShowReport1()
    {
        int t = 0;
        string code_data = "";
        string tbl1 = "";
        int pno = 1;
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.datewise_billing_report rpt = new NewAdbooking.Report.Classes.datewise_billing_report();
            ds = rpt.publication_billing(hdncompcode.Value, printing_centercode, branchcode, publication, adv_type, adcat_code, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billing_report rpt = new NewAdbooking.Report.classesoracle.datewise_billing_report();
            ds = rpt.publication_billing(hdncompcode.Value, printing_centercode, branchcode, publication, adv_type, adcat_code, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "rpt_publwise_billing_summ";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { hdncompcode.Value, printing_centercode, branchcode, publication, adv_type, adcat_code, fromdate, todate, hdnuserid.Value, Session["dateformat"].ToString(), extra1, extra2, extra3, extra4, extra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(datewise_billing_report_print), "sa", "alert(\"searching criteria is not valid\"); window.close();", true);
            return;
        }

        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl1 = tbl1 + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            string compname1 = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            string reportname1 = "Publication Wise/Edition wise Billing Report";

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
            tbl1 = tbl1 + "<tr><td  align='right'style='font-family:Arial;font-size:12px;' colspan='4'><b>Run Date:</b>" + rundate + "</td></tr>";
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
            string adt = "";
            if (adtype_name == "" || adtype_name == null)
            {
                adt = "All";

            }
            else
            {
                adt = adtype_name;
            }
            tbl1 = tbl1 + "<tr><td  align='left'style='font-family:Arial;font-size:12px; width:40%;'><b>Ad Type:</b>" + adt + "</td>";
            string adcatname = "";
            if (adv_category == "" || adv_category == null)
            {
                adcatname = "All";

            }
            else
            {
                adcatname = adv_category;
            }
            tbl1 = tbl1 + "<td  align='right'style='font-family:Arial;font-size:12px;'><b>Ad Category:</b>" + adcatname + "</td>";
            ////////////////////for column names//////////////////////////
            tbl1 = tbl1 + "<p style='page-break-after:always'><table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
            string sp_pub = "";
            for (int i = 2; i < (ds.Tables[0].Columns.Count); i++)
            {
                if (ds.Tables[0].Columns[i].Caption == "BILL_DATE")
                {
                    tbl1 = tbl1 + "<tr><td width='5%' class='middle31new' align='left'><b>Bill Date</b></td>";
                }
                else if (ds.Tables[0].Columns[i].Caption == "TOTOL")
                {
                    tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>Total</b>";
                    tbl1 = tbl1 + "</td>";
                }
                else if (i >= 3)
                {
                    string[] split_pub = ds.Tables[0].Columns[i].Caption.Split('#');
                    if (sp_pub.IndexOf(split_pub[0]) < 0)
                    {
                        tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>" + get_pub(hdncompcode.Value, split_pub[0]) + "</b>";//get_pub(hdncompcode.Value,
                        tbl1 = tbl1 + "</br>" + split_pub[1];
                        tbl1 = tbl1 + "</td>";
                    }
                    else
                    {
                        tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>" + "" + "</b>";//get_pub(hdncompcode.Value,
                        tbl1 = tbl1 + "</br>" + split_pub[1];
                        tbl1 = tbl1 + "</td>";
                    }
                    sp_pub += split_pub[0] + "~";
                }
            }
            tbl1 = tbl1 + "</tr>";
            //==================================================for values=========================================================================================================================
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //tbl1 = tbl1 + "<tr>";
                for (int j = 2; j < ds.Tables[0].Columns.Count; j++)
                {
                    if (rowcount == maxlimit)
                    {
                        pno = pno + 1;
                        rowcount = 0;
                        tbl1 = tbl1 + "</table></p>";
                        tbl1 = tbl1 + "<p style='page-break-before:always'><table style='vertical-align:top' width='100%' cellpadding='0px' cellspacing ='0px' border ='0'>";
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
                        tbl1 = tbl1 + "<tr><td  align='right' style='font-family:Arial;font-size:12px;' colspan='4'><b>Page No.:</b>" + pno + "</td></tr>";
                        tbl1 = tbl1 + "<tr><td style='width: 69px'> </td></tr></table>";

                        
                        tbl1 = tbl1 + "<table id='table1' cellpadding='0' cellspacing='0' align='center' border='0' width='100%' >";
                        string sp_pub1 = "";
                        for (int s = 2; s < (ds.Tables[0].Columns.Count); s++)
                        {
                            if (ds.Tables[0].Columns[s].Caption == "BILL_DATE")
                            {
                                tbl1 = tbl1 + "<tr><td width='5%' class='middle31new' align='left'><b>Bill Date</b></td>";
                            }
                            else if (ds.Tables[0].Columns[s].Caption == "TOTOL")
                            {
                                tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>Total</b>";
                                tbl1 = tbl1 + "</td>";
                            }
                            else if (s >= 3)
                            {
                                string[] split_pub1 = ds.Tables[0].Columns[s].Caption.Split('#');
                                if (sp_pub1.IndexOf(split_pub1[0]) < 0)
                                {
                                    tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>" + get_pub(hdncompcode.Value, split_pub1[0]) + "</b>";//get_pub(hdncompcode.Value,
                                    tbl1 = tbl1 + "</br>" + split_pub1[1];
                                    tbl1 = tbl1 + "</td>";
                                }
                                else
                                {
                                    tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>" + "" + "</b>";//get_pub(hdncompcode.Value,
                                    tbl1 = tbl1 + "</br>" + split_pub1[1];
                                    tbl1 = tbl1 + "</td>";
                                }
                                sp_pub1 += split_pub1[0] + "~";
                            }
                        }
                        tbl1 = tbl1 + "</tr>";

                    }
                    if (j == 2)
                    {
                        tbl1 = tbl1 + "<td width='5%' class='rep_data' align='left'>" + changeformat1(ds.Tables[0].Rows[i].ItemArray[j].ToString()) + "</td>";
                    }

                    else if (j >= 3)
                    {
                        tbl1 = tbl1 + "<td width='5%' class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i].ItemArray[j]).ToString("F2") + "</td>";

                    }
                }
                rowcount++;
                tbl1 = tbl1 + "</tr>";
            }
            
            for (int l = 0; l < ds.Tables[1].Rows.Count; l++)
            {
                tbl1 += "<tr><td width='5%' class='middle31new'><b>Total</b></td>";
                for (int m = 2; m < ds.Tables[1].Columns.Count; m++)
                {
                    tbl1 = tbl1 + "<td width='5%' class='middle31new' align='right'><b>" + Convert.ToDouble(ds.Tables[1].Rows[l].ItemArray[m]).ToString("F2") + "</b></td>";
                }
            }
            tbl1 = tbl1 + "</tr>";

            tbl1 = tbl1 + "</table>";
            tblgrid.InnerHtml = tbl1;
        }
    }

    public string changeformat1(string Supplydate)
    {
        string[] arr = Supplydate.Split('/');
        //string len_dt = arr[1];
        //string len_mnth = arr[0];
        if (arr[1].ToString().Length < 2)
        {
            arr[1] = "0" + arr[1];
        }
        else
        {
            arr[1] = arr[1];
        }
        if (arr[0].ToString().Length < 2)
        {
            arr[0] = "0" + arr[0];
        }
        else
        {
            arr[0] = arr[0];
        }
        string change = arr[1] + "/" + arr[0] + "/" + arr[2].Substring(0, 4);
        return change;
    }

    public string get_adtype(string compcode, string catcode, string value)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billing_report supost = new NewAdbooking.Report.classesoracle.datewise_billing_report();
            ds = supost.bind_function(compcode, catcode, value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "AD_GET_catnameE";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            string[] parameterValueArray = { compcode, catcode, value };
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);
            
        }
        else
        {
            NewAdbooking.Report.Classes.datewise_billing_report supost = new NewAdbooking.Report.Classes.datewise_billing_report();
            ds = supost.bind_function(compcode, catcode, value);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            return fetchvalue;
        }
        return fetchvalue;
    }

    public string get_pub(string compcode, string pubcode)
    {
        string fetchvalue = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.datewise_billing_report supost1 = new NewAdbooking.Report.classesoracle.datewise_billing_report();
            ds = supost1.bind_publication(compcode, pubcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ad_get_fieldname1";
            NewAdbooking.classmysql.Master obj = new NewAdbooking.classmysql.Master();
            string[] parameterValueArray = { compcode, pubcode,"" , "","","","",""};
            ds = obj.BindCommanFunction(procedureName, parameterValueArray);

        }

        else
        {
            NewAdbooking.Report.Classes.datewise_billing_report supost1 = new NewAdbooking.Report.Classes.datewise_billing_report();
            ds = supost1.bind_publication(compcode, pubcode, "publication");
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            fetchvalue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            return fetchvalue;
        }
        return fetchvalue;
    }
}
