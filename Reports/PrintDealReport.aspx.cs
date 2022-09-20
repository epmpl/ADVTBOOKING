using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

public partial class Reports_PrintDealReport : System.Web.UI.Page
{
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
    DataSet ds = new DataSet();
    System.Web.HttpBrowserCapabilities browser;

    string destination = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string fromdt = "";
    string dateto = "";
    string advtype = "All";
    string dealtype = "All";
    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {

        browser = Request.Browser;
        ver = (float)(browser.MajorVersion + browser.MinorVersion);

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_PrintDealReport));
        ds = (DataSet)Session["delrep"];
        string prm = Session["rep_delrep"].ToString();
        string[] prm_Array = new string[15];
        prm_Array = prm.Split('~');
        destination = prm_Array[1];
        fromdt = prm_Array[3];
        dateto = prm_Array[5];
        if (prm_Array[7] != "--Select Ad Type--")
            advtype = prm_Array[7];
        if (prm_Array[9] != "-Select Deal-")
            dealtype = prm_Array[9];

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = day + "/" + month + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = month + "/" + day + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + month + "/" + day;

                }
        if (!IsPostBack)
        {
            printreport();
        }
    }
    private void printreport()
    {
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/DealReport.xml"));
        int maxlimit = 15;
        string cmpnyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
        string dynhead = dsxml.Tables[0].Rows[0].ItemArray[13].ToString();

        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];

        int cont = ds.Tables[0].Rows.Count;
        StringBuilder tblhdr = new StringBuilder();
        //tblhdr.Append("<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>");
        tblhdr.Append("<tr ><td align='center' colspan='25' style='height: 28px;padding-left:20px' class='headingc'>" + cmpnyname + "</td></tr>");
        tblhdr.Append("<tr><td align='center' colspan='25' style='height: 28px' class='headingp'>" + dynhead + "</td></tr>");
        tblhdr.Append("<tr><td style='width: 69px' colspan='25'></td></tr>");

        tblhdr.Append("<tr><td  class='upper2' colspan='2'  align='right'>DATE FROM:</td><td class='middle2' align='left' colspan='2'  >" + fromdt + "</td><td colspan='6' ></td><td  class='upper2' colspan='2' align='right'>RUN DATE:</td><td class='middle2' colspan='2'align='left' >" + date.ToString() + "</td><td colspan='11' ></td></tr>");
        tblhdr.Append("<tr><td class='upper2' colspan='2' align='right' >ADTYPE:</td><td class='middle2' colspan='2' align='left' >" + advtype + "</td><td colspan='17' ></td>");
        tblhdr.Append("<td  class='upper2' colspan='2' align='right'>DEAL TYPE:</td><td class='middle2' colspan='2'align='left' >" + dealtype + "</td><td></td></tr>");


        StringBuilder tbl = new StringBuilder();
        int i1 = 1;

        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;

        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        if (browser.Browser == "Firefox")
        {
            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
        }
        else if (browser.Browser == "IE")
        {
            if ((ver == 7.0) || (ver == 8.0))
            {
                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            }
            else if (ver == 6.0)
            {
                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            }
        }


        for (int p = 0; p < pagecount; p++)
        {

            if (browser.Browser == "Firefox")
            {
                tbl.Append("</table></P>");

                if (p == pagecount - 1)
                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                else
                    tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

            }
            else if (browser.Browser == "IE")
            {
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {

                        if (p != 0)
                        {
                            tbl.Append("</table></P>");
                            if (p == pagecount - 1)
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                    }
                    else if (ver == 6.0)
                    {
                        
                        if (p != 0)
                        {
                            tbl.Append("</table>");
                            if (p == pagecount - 1)
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                        }
                    }
                }
            }

            tbl.Append(tblhdr);
            tbl.Append("<tr><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td><td class='middle31'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td><td class='middle31'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td><td class='middle31'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[16].ToString() + "</td>");
            tbl.Append("<td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[17].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[18].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[19].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[20].ToString() + "</td><td class='middle31'  style='border-top:solid 1px black;'>" + dsxml.Tables[1].Rows[0].ItemArray[21].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[22].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[23].ToString() + "</td><td class='middle31' style='border-top:solid 1px black;' >" + dsxml.Tables[1].Rows[0].ItemArray[24].ToString() + "</td>");
            tbl.Append("</tr>");


            for (int i = ct; i < ds.Tables[0].Rows.Count && i < fr; i++)
            {

                tbl.Append("<tr >");
                tbl.Append("<td class='rep_data' width='3%'>");
                tbl.Append(i1++.ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["DEAL_NO"] + "</td>");


                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append(ds.Tables[0].Rows[i]["DEAL_NAME"] + "</td>");

                tbl.Append("<td class='rep_data' width='5%'>");
                tbl.Append("" + "</td>");//DEAL DATE


                tbl.Append("<td class='rep_data' align='right' width='3%'>");
                tbl.Append(ds.Tables[0].Rows[i]["DEAL_TYPE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right'>");
                tbl.Append(ds.Tables[0].Rows[i]["FROM_DATE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["TILL_DATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["TOTAL_VALUE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["TOTAL_VOLUM"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left'  >");
                tbl.Append(ds.Tables[0].Rows[i]["AGENCY_NAME"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' width='3%' >");
                tbl.Append(ds.Tables[0].Rows[i]["CLIENT_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["PACKAGECODE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["CARD_RATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["PREMIUM_CODE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["CONTRACT_RATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["DISCPER"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["DISCTYPE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["INSERTION"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["MIN_SIZE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["MAX_SIZE"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["VALUEFROM"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["VALUETO"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["RATE_CODE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' align='left' >");
                tbl.Append(ds.Tables[0].Rows[i]["REMARKS"] + "</td>");

                tbl.Append("<td class='rep_data' align='right' >");
                tbl.Append(ds.Tables[0].Rows[i]["APPROVED"].ToString() + "</td>");

                tbl.Append("</tr>");

            }
            ct = ct + maxlimit;
            fr = fr + maxlimit;
            //tbl.Append("</table>");

            
        }
        if (browser.Browser == "Firefox")
        {
            tbl.Append("</table></P>");

        }
        else if (browser.Browser == "IE")
        {
            if ((ver == 8.0) || (ver == 7.0))
            {
                tbl.Append("</table></P>");

            }
            else if (ver == 6.0)
            {
                tbl.Append("</table>");

            }
        }
        //div1.Visible = true;
        div1.InnerHtml = tbl.ToString();
    }
}
