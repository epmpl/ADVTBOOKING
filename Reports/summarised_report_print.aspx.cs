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

public partial class summarised_report_print : System.Web.UI.Page
{
    int sno = 1;
    double amtsum = 0;
    string adtyp = "";
    string adtypname = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string adtypename = "";
    string editionname = "";
    string pdfName1 = "";
    double amtnew = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string package = "";
    //int area = 0;
    decimal area = 0;
    double ARR = 0;
    int i1 = 1;
    double amt = 0;
    string client = "";
    string agency = "";

    string sortorder = "";
    string sortvalue = "";
    int maxlimit=10;
    string page = "", region = "", rep = "", place = "", grp = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
  

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
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[25].ToString());

        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        heading.Text = "Status Wise Daily Summarized Report";

        ds = (DataSet)Session["summarize"];
        string prm = Session["prm_summarize_print"].ToString();
        string[] prm_Array = new string[39];
        prm_Array = prm.Split('~');

        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        adtyp = prm_Array[5]; //Request.QueryString["adtype"].ToString();
        destination = prm_Array[7]; //Request.QueryString["destination"].ToString();
        publ = prm_Array[9]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[11]; //Request.QueryString["pubcenter"].ToString();
        edition = prm_Array[13]; //Request.QueryString["edition"].ToString();
        pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();
        editionname = prm_Array[19]; //Request.QueryString["editionname"].ToString();
        adtypname = prm_Array[21]; //Request.QueryString["adtypname"].ToString();


        if (publ == "0")
        {
            lblpublication.Text = "ALL".ToString();
        }
        else
        {
            lblpublication.Text = pubcname.ToString();
        }

        if (adtyp == "0")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypname.ToString();
        }


        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();
        }

        if (pubcen == "0")
        {
            lbcent.Text = "ALL".ToString();
        }
        else
        {
            lbcent.Text = pub2.ToString();
        }


        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {

            DateTime dt = System.DateTime.Now;


            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();

            if (day.Length < 2)
                day = "0" + day;
            if (month.Length < 2)
                month = "0" + month;

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
        lblrundate.Text = date.ToString();
        lblfrom.Text = fromdt;
        lblto.Text = dateto;

        //if (fromdt != "")
        //{
        //    DateTime dt = Convert.ToDateTime(fromdt.ToString());
        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {
        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        datefrom1 = day + "/" + month + "/" + year;


        //    }
        //    else if (hiddendateformat.Value == "mm/dd/yyyy")
        //    {
        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        datefrom1 = month + "/" + day + "/" + year;

        //    }
        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {

        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        datefrom1 = year + "/" + month + "/" + day;
        //    }
        //}
        //lblfrom.Text = datefrom1;
        

        //dateto1 = "";
        //if (dateto != "")
        //{
        //    DateTime dt = Convert.ToDateTime(dateto.ToString());
        //    if (hiddendateformat.Value == "dd/mm/yyyy")
        //    {
        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        dateto1 = day + "/" + month + "/" + year;

        //    }
        //    else if (hiddendateformat.Value == "mm/dd/yyyy")
        //    {

        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        dateto1 = month + "/" + day + "/" + year;

        //    }
        //    else if (hiddendateformat.Value == "yyyy/mm/dd")
        //    {

        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        dateto1 = year + "/" + month + "/" + day;
        //    }
        //}
        //lblto.Text = dateto1;
        onscreen(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), edition);




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



    private void onscreen(string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string dateformat, string edition)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    //ds = obj.spfun(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Categorreport obj = new NewAdbooking.Report.classesoracle.Categorreport();
        //    ds = obj.Dailyrep(fromdt, dateto, adtyp, publ, pubcen, Session["compcode"].ToString(), Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), editionname);
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
           // tbl = "<table  cellspacing='0px' cellpadding = '3px' border='0' align='center' style='vertical-align:top'>";

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

               // tbl += "</table>";
               // tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                tbl += "<tr>";
                tbl += "<td class='middle111' align='right' colspan='11'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<td class='middle31new' width='16%'  >" + "S.No." + "</td>";
                tbl += "<td class='middle31new' width='16%'  align='left'>" + "Status" + "</td>";
                tbl += "<td class='middle31new' width='16%'  align='left'>" + "Booking"+"</br>"+"Type" + "</td>";
                tbl += "<td class='middle31new' width='16%' align='right'>" + "GrossAmt" + "</td>";
                tbl += "<td class='middle31new' width='16%' align='right'>" + "Area" + "</td>";
                tbl += "<td class='middle31new' width='20%'  align='right'>" + "TotalAds" + "</td>";
               
                tbl += "</tr>";

                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {
                    int a = d;
                    a = a + 1;

                    tbl = tbl + ("<tr >");


                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (i1++.ToString() + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Status"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Type"] + "</td>");
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["GrossAmt"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["GrossAmt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[d]["GrossAmt"].ToString());
                    //=====================
                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["Area"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                        area = area + decimal.Parse(ds.Tables[0].Rows[d]["Area"].ToString());

                    tbl = tbl + ("<td class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["count(*)"] + "</td>");
                  
                    tbl = tbl + "</tr>";
                    tblgrid.InnerHtml += tbl;
                    tbl = "";
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;

               
            }
            tbl = tbl + ("<tr >");
            tbl = tbl + ("<td class='middle13new' style='font-size:12px'><b>Total:-</b></td>");
            tbl = tbl + ("<td class='middle13new' style='font-size:12px'>");
            tbl = tbl + ("&nbsp;</td>");
            tbl = tbl + ("<td class='middle13new' style='font-size:12px'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle13new' style='font-size:12px' align='right'>");
            tbl = tbl + (chk_null(amt.ToString()) + "</td>");
            tbl = tbl + ("<td class='middle13new' align='right' style='font-size:12px'>");
            tbl = tbl + (chk_null(area.ToString()) + "</td>");
            tbl = tbl + ("<td class='middle13new'>&nbsp;</td>");

            tbl = tbl + "</tr>";
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

         //   tbl = tbl + ("</table>");
            tblgrid.InnerHtml += tbl;
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
}
