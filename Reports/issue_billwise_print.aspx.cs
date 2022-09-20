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

public partial class Reports_issue_billwise_print : System.Web.UI.Page
{
    int maxlimit = 22;
    string compcode = "", printcent = "", publ_name = "", supl_name = "", district_name = "", edition = "", fromdate = "", todate = "", ratio_type = "", statecode = "", destination = "", extra1 = "", extra2 = "";
    string printingcenter = "";
    string edition_name = "";
    string pub_name = "";
    string suppliment_name = "";
    string dist_name = "";
    double month_collection = 0;
    double rcr = 0;
    double rcp = 0;
    double ca = 0;
    int i = 0;
    string compname = "";
    System.Web.HttpBrowserCapabilities browser;
    double ver;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            chk_access.Value = Session["access"].ToString();

            printcent = Request.QueryString["printcent"];
            edition = Request.QueryString["edition"];
            fromdate = Request.QueryString["fromdate"];
            todate = Request.QueryString["todate"];
            ratio_type = Request.QueryString["ratio_type"];
            publ_name = Request.QueryString["publ_name"];
            //destination = Request.QueryString["destination"];
            district_name = Request.QueryString["district_name"];
            supl_name = Request.QueryString["supl_name"];
            compcode = Request.QueryString["compcode"];
            compname = Session["comp_name"].ToString();

            if (printcent == "0" || printcent=="")
            {
                printingcenter = "All";
            }
            else
            {
                printingcenter = printcent;
            }

            if (edition == "" || edition=="0")
            {
                edition_name = "All";
            }
            else
            {
                edition_name = edition;
            }

            if (publ_name == "0" || publ_name == null)
            {
                pub_name = "All";
            }
            else
            {
                pub_name = publ_name;
            }

            if (district_name == "0" || district_name == null)
            {
                dist_name = "All";
            }
            else
            {
                dist_name = district_name;
            }

            if (supl_name == "0" || supl_name == null || supl_name == "")
            {
                suppliment_name = "All";
            }
            else
            {
                suppliment_name = supl_name;
            }

            DataSet xml = new DataSet();
            xml.ReadXml(Server.MapPath("XML/issuebillreport.xml"));
            reportname.Value = xml.Tables[0].Rows[0].ItemArray[11].ToString();
            from_date.Value = xml.Tables[0].Rows[0].ItemArray[12].ToString();
            to_date.Value = xml.Tables[0].Rows[0].ItemArray[13].ToString();
            pubcent.Value = xml.Tables[0].Rows[0].ItemArray[14].ToString();
            publication.Value = xml.Tables[0].Rows[0].ItemArray[16].ToString();
            district.Value = xml.Tables[0].Rows[0].ItemArray[19].ToString();
            suppliment.Value = xml.Tables[0].Rows[0].ItemArray[18].ToString();
            branch.Value = xml.Tables[0].Rows[0].ItemArray[15].ToString();
            mainedition.Value = xml.Tables[0].Rows[0].ItemArray[17].ToString();

        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        // maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[27].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);
        //lbldate.Text = date.ToString();
        lblfromdate.Text = fromdate;
        lbltodate.Text = todate;
        lblprintcent.Text = printingcenter;
       // lblbranch.Text = "";
        lblpublication.Text = pub_name;
        lbledition.Text = edition_name;
        lblsuppliment.Text = suppliment_name;
        lbldistrict.Text = dist_name;
        heading.Text = reportname.Value;
        cmpnyname.Text = compname.ToString();
        onscreen();
    }

    public void onscreen()
    {
            string tbl = "";
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.issuebillreport rpt = new NewAdbooking.Report.classesoracle.issuebillreport();
                ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }
            else
            {
                //NewAdbooking.Report.Classes.issuebillreport rpt = new NewAdbooking.Report.Classes.issuebillreport();
                //ds = rpt.getissuebillrep(hiddencompcode.Value, printcent, edition, fromdate, todate, hiddendateformat.Value, hiddenuserid.Value, chk_access.Value, ratio_type, extra1, extra2);
            }

            int cont = ds.Tables[0].Rows.Count;
            int contc = ds.Tables[0].Columns.Count;
            double[] arr1 = new double[contc];
            int ct = 0;
            int fr = maxlimit;
            int rcount = ds.Tables[0].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;
            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                //tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
                //tbl = tbl + "<tr><td colspan='12' style='text-align:center;' class='headingc'>" + reportname.Value + "</td></tr>";
                //tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + from_date.Value + "</td><td colspan='1' style='text-align:left;'>" + fromdate + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + to_date.Value + "</td><td colspan='1' style='text-align:right;'>" + todate + "</td></tr>";
                //tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + pubcent.Value + "</td><td colspan='1' style='text-align:left;'>" + pub_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + branch.Value + "</td><td colspan='1' style='text-align:right;'>" + todate + "</td></tr>";
                //tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + publication.Value + "</td><td colspan='1' style='text-align:left;'>" + pub_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + mainedition.Value + "</td><td colspan='1' style='text-align:left;'>" + edition_name + "</td></tr>";
                //tbl = tbl + "<tr><td colspan='1' style='text-align:left;' class='upper2'>" + suppliment.Value + "</td><td colspan='1' style='text-align:left;'>" + supl_name + "</td><td colspan='8'></td><td colspan='1' style='text-align:right;' class='upper2'>" + district.Value + "</td><td colspan='1' style='text-align:left;'>" + dist_name + "</td></tr>";
                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;

                    if (browser.Browser == "Firefox")
                    {
                        if (p != 0)
                        {
                            tbl = tbl + "</table></P>";
                            if (p == pagecount || p == 0)

                                tbl = tbl + "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            else
                                tbl = tbl + "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        }
                    }
                    else if (browser.Browser == "IE")
                    {
                        if ((ver == 8.0) || (ver == 7.0))
                        {

                            tbl = tbl + "</table></P>";
                            if (p == pagecount - 1)
                                tbl = tbl + "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            else
                                tbl = tbl + "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";


                        }
                        else if (ver == 6.0)
                        {
                            tbl = tbl + "</table>";
                            if (p == pagecount - 1)
                                tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            else
                                tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                        }
                    }
                    tbl = tbl + "<tr valign='top'><td class='middle111' align='right' colspan='12'>" + "Page  " + s + "  of  " + pagecount + "</td></tr>";

                    tbl = tbl + "<tr><td class='middle31' align='left'>Publication</td><td class='middle31' align='left'>Main Edition</td><td  class='middle31' align='left'>Sub Edition</td><td class='middle31' align='left'>Suppliment</td><td class='middle31' align='left'>Qty</td><td class='middle31' align='right'>CC(Sq cm)</br>(with linage)</td><td class='middle31' align='right'>Business</br>(Billed)</td><td class='middle31' align='right'>Debit</br>Note</td><td class='middle31' align='right'>Busienss</br>AgainstCollection</td><td class='middle31' align='right'>Credit</br>Note</td><td class='middle31' align='right'>Balance</td><td class='middle31' align='right'>This month</br>collection</td></tr>";

                    for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                    {
                        tbl = tbl + ("<tr style='height:30px'>");

                        tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                        if (d == 0)
                        {
                            tbl = tbl + ds.Tables[0].Rows[d]["PUBLICATION_CODE"] + "</td>";
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["PUBLICATION_CODE"].ToString() != ds.Tables[0].Rows[d - 1]["PUBLICATION_CODE"].ToString())
                            {
                                tbl = tbl + ds.Tables[0].Rows[d]["PUBLICATION_CODE"] + "</td>";
                            }
                            else
                            {
                                tbl = tbl + ("</td>");
                            }
                        }
                        tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["EDITION_NAME"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["SUB_EDITION_CODE"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:left;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["DSIZE"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["BUSINESS_BILL"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["DEBIT_NOTE"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["RCR"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["CREDIT_NOTE"] + "</td>";

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + ds.Tables[0].Rows[d]["BALANCE"] + "</td>";

                        if (ds.Tables[0].Rows[d]["RCR"].ToString() != "")
                        {
                            rcr = double.Parse(ds.Tables[0].Rows[d]["RCR"].ToString());
                        }
                        else
                        {
                            rcr = 0;
                        }

                        if (ds.Tables[0].Rows[d]["RCP"].ToString() != "")
                        {
                            rcp = double.Parse(ds.Tables[0].Rows[d]["RCP"].ToString());
                        }
                        else
                        {
                            rcp = 0;
                        }

                        if (ds.Tables[0].Rows[d]["CA"].ToString() != "")
                        {
                            rcp = double.Parse(ds.Tables[0].Rows[d]["CA"].ToString());
                        }
                        else
                        {
                            rcp = 0;
                        }

                        //if (ds.Tables[0].Rows[i]["RCR"].ToString() != "" || ds.Tables[0].Rows[i]["RCP"].ToString() != "" || ds.Tables[0].Rows[i]["CA"].ToString()!="")
                        //{
                        month_collection = rcr + rcp + ca;
                        //}

                        tbl = tbl + "<td colspan='1' style='text-align:right;' class='rep_data' align='left' valign='top' colspan='1'>";
                        tbl = tbl + month_collection + "</td>";

                        tbl = tbl + "</tr>";
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;
                }
                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table></P>";

                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl = tbl + "</table></P>";

                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";

                    }
                }
                div1.Visible = true;
                div1.InnerHtml += tbl;
            }     
    }
}
