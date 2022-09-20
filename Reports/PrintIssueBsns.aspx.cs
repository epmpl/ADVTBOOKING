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

public partial class Reports_PrintIssueBsns : System.Web.UI.Page
{
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string datefrom1 = "";
    string dateto1 = "";
    string pubcode = "";
    string publication = "";
    string edition = "";
    string editioncode = "";
    string destination = "";
    string fromdt = "";
    string dateto = "";
    double Netamt = 0;
    double Totalads = 0;
    int maxlimit = 15;
    string adtypecode = "", adtypename = "", pubcentcode = "", pubcentname = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
           
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[13].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[82].ToString();

        ds = (DataSet)Session["issuebus"];
        string prm = Session["prm_issuebus_print"].ToString();
        string[] prm_Array = new string[21];
        prm_Array = prm.Split('~');



        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcode = prm_Array[7]; //Request.QueryString["publication"].ToString();
        publication = prm_Array[9]; //Request.QueryString["publicationname"].ToString();
        editioncode = prm_Array[11]; //Request.QueryString["edition"].Trim().ToString();
        edition = prm_Array[13]; //Request.QueryString["editionname"].Trim().ToString();
        adtypecode = prm_Array[15]; //Request.QueryString["adtypecode"].Trim().ToString();
        adtypename = prm_Array[17]; //Request.QueryString["adtypename"].Trim().ToString();
        pubcentcode = prm_Array[19]; //Request.QueryString["pubcentcode"].Trim().ToString();
        pubcentname = prm_Array[21]; //Request.QueryString["pubcentname"].Trim().ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_PrintIssueBsns));

        if (pubcode == "0")
        {
            lblpublication.Text = "";
        }
        else
        {
            lblpublication.Text = publication.ToString();

        }

        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;

        }
        else
            if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
            {

                DateTime dt = System.DateTime.Now;


                day = dt.Day.ToString();
                month = dt.Month.ToString();
                year = dt.Year.ToString();
                date = RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day) + "/" + year;

            }
            else
                if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                {

                    DateTime dt = System.DateTime.Now;


                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    date = year + "/" + RETURN_LENGTH(month) + "/" + RETURN_LENGTH(day);

                }
        lbldate.Text = date.ToString();
       


        if (fromdt != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = fromdt.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                datefrom1 = dd + "/" + mm + "/" + yy;

            }
            else
            {
                DateTime dt = Convert.ToDateTime(fromdt.ToString());
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = day + "/" + month + "/" + year;


                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    datefrom1 = year + "/" + month + "/" + day;
                }
            }
        }
        lblfrom.Text = datefrom1;
        //dateto1 = "";
        if (dateto != "")
        {

            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto1 = dd + "/" + mm + "/" + yy;

            }


            else
            {

                DateTime dt = Convert.ToDateTime(dateto.ToString());

                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = day + "/" + month + "/" + year;

                }
                else if (hiddendateformat.Value == "mm/dd/yyyy")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = month + "/" + day + "/" + year;

                }
                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {

                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();
                    dateto1 = year + "/" + month + "/" + day;
                }
            }
        }
        lblto.Text = dateto1;

        hiddendatefrom.Value = fromdt.ToString();

         onscreen(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(),adtypecode,pubcentcode); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
       
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

    public string chk_null(string str_decimal)
    {
        string final_decimal = "";
        if (str_decimal == "0.00" || str_decimal == "0.0" || str_decimal == "0")
        {
            final_decimal = "0.00";
        }
        else if (str_decimal.IndexOf(".") > -1)
        {

            double dd = System.Math.Round(Convert.ToDouble(str_decimal), 2);
            string[] oo = dd.ToString().Split('.');
            if (oo.Length == 1)
                final_decimal = dd.ToString() + ".00";
            else if (oo[1].Length == 1)
                final_decimal = dd.ToString() + "0";
            else
                final_decimal = dd.ToString();
        }
        else
        {
            if (str_decimal != "")
            {
                final_decimal = Convert.ToDouble(str_decimal).ToString("F2");
            }
            else
                final_decimal = "0.00";
        }
        return final_decimal;
    }

    private void onscreen(string fromdt, string dateto, string pubcode, string editioncode, string dateformat , string adtypecode, string pubcentcode)  //, string supplement)
    {

        //DataSet ds = new DataSet();

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    // ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter, adtype, edition, supplement, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.IssueBusnonscreen(fromdt, dateto, pubcode, editioncode, dateformat, adtypecode, pubcentcode, Session["compcode"].ToString());//

        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        int i1 = 1;
        string tbl = "";
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
        {//width='50%'
           // tbl = "<table  cellspacing='0px' cellpadding = '0px' border='0' width='60%' align='left' style='vertical-align:top'>";
            if (browser.Browser == "Firefox")
            {
                tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
            
            for (int p = 0; p < pagecount; p++)
            {
               
                int s = p + 1;

                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table></P>";
                    if (p == pagecount - 1)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl = tbl + "</table></P>";
                        if (p == pagecount - 1)
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1)
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  
                //tbl += "</table>";
                // tbl += "</br>";
                tbl += "<tr valign='top'>";
              //  tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='CENTER' class='break'>";
              //  tbl += "<tr>";
                tbl += "<td class='middle111' align='right' colspan='3'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<td class='middle31new'  align='left' width='20%'>" + "ISSUE" + "</td>";
                tbl += "<td class='middle31new'  align='right' width='20%'>" + "Net Amt" + "</td>";
                tbl += "<td class='middle31new' align='right'  width='10%'>" + "TOTAL  ADS"  + "</td>";
                
                tbl += "</tr>";
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {
                    int a = d;
                    a = a + 1;

                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data' align='left' width='20%'>");
                    tbl = tbl + ( ds.Tables[0].Rows[d]["Edition"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' align='right' width='20%'>");
                    tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["NETAMT"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["NETAMT"].ToString() != "")
                        Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[d]["NETAMT"]);


                    tbl = tbl + ("<td class='rep_data' align='right' width='10%'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["TotalAds"] + "</td>");
                    if (ds.Tables[0].Rows[d]["TotalAds"].ToString() != "")
                        Totalads = Totalads + Convert.ToInt32(ds.Tables[0].Rows[d]["TotalAds"]);
                 
                   
                    //}
                    tbl = tbl + "</tr>";

                    div1.InnerHtml += tbl;
                    tbl = "";
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }

            tbl = tbl + ("<tr><td class='middle1212' align='left' width='20%'><b>Total:</b></td><td  class='middle1212' align='right' width='20%'>" + (chk_null(Netamt.ToString())) + "</td><td class='middle1212' align='right' width='10%'>" + Totalads.ToString() + "</td></tr>"); 
           // tbl += "</table>";
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
            //div1.InnerHtml = tbl;
            div1.InnerHtml += tbl;

        }
    }
}
