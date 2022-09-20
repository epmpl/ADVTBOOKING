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
using System.IO;

public partial class reportnewprint2 : System.Web.UI.Page
{
    int maxlimit = 10;
    int a = 0;
    string agency = "";
    string client = "";
    string package = "";

    string agname = "";
    string adtyp = "";
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
    string day = "";
    string month = "";
    string year = "";
    string adcatname = "";
    string agencyname = "";
    string agencysubcode1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    double area = 0;
    int i1 = 0;
    double amt = 0;
    string sortorder = "";
    string sortvalue = "", agtype = "", agtypetext = "";
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    string edtn = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;
    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = (DataSet)Session["allagency"];

        if (Session["dateformat"] == null)
            Response.Redirect("../login.aspx");
        else
            hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[3].ToString());
     
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        string prm = Session["prm_allagency_print"].ToString();
        string[] prm_Array = new string[35];
        prm_Array = prm.Split('~');

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        Ajax.Utility.RegisterTypeForAjax(typeof(reportnewprint2));


            agname = prm_Array[1];// Request.QueryString["agname"].ToString();
            adtyp = prm_Array[3]; //Request.QueryString["adtype"].ToString();
            adcat = prm_Array[5]; //Request.QueryString["adcategory"].ToString();
            fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
            dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
            publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
            pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
            pubcname = prm_Array[15]; //Request.QueryString["publicname"].ToString();
            pub2 = prm_Array[17]; //Request.QueryString["publiccent"].ToString();

            edition = prm_Array[19]; //Request.QueryString["edition"].ToString();
            adcatname = prm_Array[21]; //Request.QueryString["adcatname"].ToString();
            agencyname = prm_Array[23]; //Request.QueryString["agencyname"].ToString();
            adtypename = prm_Array[25]; //Request.QueryString["adtypename"].ToString();
            editionname = prm_Array[27]; //Request.QueryString["editionname"].ToString();
            agencysubcode1 = prm_Array[29]; //Request.QueryString["agencysubcode"].ToString();
            agtype = prm_Array[31]; //Request.QueryString["agtype1"].ToString();
            agtypetext = prm_Array[33];// Request.QueryString["agtypetext"].ToString();

               if (agtype == "0")
                lblagtype.Text = "ALL".ToString();
            else
                lblagtype.Text = agtypetext.ToString();
            if (publ == "0")
                lblpub.Text = "ALL".ToString();
            else
                lblpub.Text = pubcname.ToString();
            if (pubcen == "0")
                pcenter.Text = "ALL".ToString();
            else
                pcenter.Text = pub2.ToString();

            if (adtyp == "0")
                lbladtype.Text = "ALL".ToString();
            else
                lbladtype.Text = adtypename.ToString();

            if ((adcat == "0") || (adcat == ""))
                lbladcat.Text = "ALL".ToString();
            else
                lbladcat.Text = adcatname.ToString();

            if (edition == "0" || edition == "")
                lbedition.Text = "ALL".ToString();
            else
                lbedition.Text = editionname.ToString();

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

            if (agencysubcode1 == "true")
            {
                lblAgencyCode.Visible = true;
                lblAgencyCode.Text = "All".ToString();
                aaa.Visible = true;

            }
            else
            {
                lblAgencyCode.Visible = false;
                aaa.Visible = false;

            }

                onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
           
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

    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spAgency(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
        //}
        
            cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
       
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        string tbl = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
           //     tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
          

        if (agencysubcode1 == "true")
        {
         
            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table>";
                    if (p == pagecount ||p==0)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1||p==0)
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else if (p == 0)
                        {
                            tbl += "<P style='page-break-before:inherit;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                        }
                        else
                        {
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        }
                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1)
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<P style='page-break-before:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  

              //  tbl += "</table>";
               // tbl += "<table width='93%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                 tbl += "<tr valign='top'>";
                tbl += "<td class='middle111' align='right' colspan='21'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>";


                tbl = tbl + ("<tr><td class='middle31new' width='1%' >S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='10%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Sub Agency</td><td class='middle31new' width='10%'align='left'>&nbsp;&nbsp;Client</td><td  class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='left'>&nbsp;&nbsp;Color&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='right' >Area&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='right' >HT&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='right' >WD&nbsp;&nbsp;</td><td class='middle31new' width='3%' align='left'>Page&nbsp;&nbsp;</br>Post&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left' >Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='7%'  align='left' >Ro No.&nbsp;&nbsp;</td><td class='middle31new' width='4%' align='left'>RoStatus</td> <td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt.&nbsp;&nbsp;</td><td class='middle31new' width='2%' colspan='2' align='left'>Caption</br>Key No</td><td class='middle31new' width='2%' colspan='2' align='left'>Status</td></tr>");



                  for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (a.ToString() + "</td>");

                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                    if (rrr.Length >= 10)
                    {
                        cioid1 = rrr.Substring(0, 10);
                        if (rrr.Length - 10 < 10)
                            cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                        else
                            cioid1 += "</br>" + rrr.Substring(10, 10);
                    }
                    else
                        cioid1 = rrr;


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (cioid1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                edition = ds.Tables[0].Rows[d]["edition"].ToString();
                if (edition.Length > 8)
                {
                    tbl = tbl + (edition.ToString().Substring(0, 8) + "</td>");

                }
                else
                {
                    tbl = tbl + (edition.ToString() + "</td>");

                }
               // tbl = tbl + (ds.Tables[0].Rows[d]["edition"] + "</td>");



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Ins_date"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                string agency1 = "";
                string rrr1 = ds.Tables[0].Rows[d]["Agency_Name"].ToString();
                if (rrr1.Length > 16)
                {
                    tbl = tbl + (rrr1.ToString().Substring(0, 16) + "</td>");
                }
                else
                {
                    tbl = tbl + (rrr1.ToString() + "</td>");

                }
                //if (rrr1.Length >= 12)
                //{
                //    agency1 = rrr1.Substring(0, 12);
                //    if (rrr1.Length - 12 < 12)
                //        agency1 += "</br>" + rrr1.Substring(12, rrr1.Length - 12);
                //    else
                //        agency1 += "</br>" + rrr1.Substring(12, 12);
                //}
                //else
                //    agency1 = rrr1;

                //tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                //tbl = tbl + (agency1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                tbl = tbl + (ds.Tables[0].Rows[d]["SubAg"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
            
                string rrr10 = ds.Tables[0].Rows[d]["Client_Name"].ToString();
                //if (rrr2.Length >= 16)
                //{
                //    client1 = rrr2.Substring(0, 16);
                //    if (rrr2.Length - 16 < 16)
                //        client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                //    else
                //        client1 += "</br>" + rrr2.Substring(16, 16);
                //}
                //else
                //    client1 = rrr2;
                if (rrr10.Length > 16)
                {
                    tbl = tbl + (rrr10.ToString().Substring(0, 16) + "</td>");

                }
                else
                {
                    tbl = tbl + (rrr10.ToString() + "</td>");
                }

           




                string Package1 = "";
                string rrr3 = ds.Tables[0].Rows[d]["Package"].ToString();
                if (rrr3.Length >= 9)
                {
                    Package1 = rrr3.Substring(0, 9);
                    if (rrr3.Length - 9 < 9)
                        Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                    else
                        Package1 += "</br>" + rrr3.Substring(9, 9);
                }
                else
                    Package1 = rrr3;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (Package1 + "</td>");



                //----------------------------------------------------------------///
                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                tbl = tbl + (ds.Tables[0].Rows[d]["Color_code"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");

                if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                {
                    
                    if (ds.Tables[0].Rows[d]["uom"].ToString() == "CD" || ds.Tables[0].Rows[d]["uom"].ToString() == "ROD")
                        area = area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());

                }



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Depth"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Width"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Page"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                string pagep = ds.Tables[0].Rows[d]["PagePremium"].ToString();
                if (pagep.Length >12)
                {
                    tbl = tbl + (pagep.ToString().Substring(0,12)+ "</td>");
                }
                else
                {
                    tbl = tbl + (pagep.ToString() + "</td>");
                   
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");
                string pos = ds.Tables[0].Rows[d]["PositionPremium"].ToString();
                if (ds.Tables[0].Rows[d]["PositionPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[d]["PositionPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>");
                if (ds.Tables[0].Rows[d]["BulletPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[d]["BulletPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                tbl = tbl + (ds.Tables[0].Rows[d]["RoNo."] + "</td>");


                string RoStatus1 = "";
                string rrr4 = ds.Tables[0].Rows[d]["RoStatus"].ToString();
                if (rrr4.Length >= 9)
                {
                    RoStatus1 = rrr4.Substring(0, 9);
                    if (rrr4.Length - 9 < 9)
                        RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                    else
                        RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                }
                else
                    RoStatus1 = rrr4;


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (RoStatus1 + "</td>");

                string AdCat1 = "";
                string rrr5 = ds.Tables[0].Rows[d]["AdCat"].ToString();
                if (rrr5.Length >= 9)
                {
                    AdCat1 = rrr5.Substring(0, 9);
                    if (rrr5.Length - 9 < 9)
                        AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                    else
                        AdCat1 += "</br>" + rrr5.Substring(9, 9);
                }
                else
                    AdCat1 = rrr5;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (AdCat1 + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["RateCode"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[d]["CardRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["CardRate"]).ToString("F2") + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[d]["AgreedRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["AgreedRate"]).ToString("F2") + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");


                if (ds.Tables[0].Rows[d].ItemArray[19].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {

                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["Amt"]).ToString("F2") + "</td>");
                    if (ds.Tables[0].Rows[d].ItemArray[19].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
                string caption1 = ds.Tables[0].Rows[d]["Cap"].ToString();
                if (caption1.Length > 8)
                {
                    tbl = tbl + caption1.ToString().Substring(0, 8);
                }
                else
                {
                    tbl = tbl + caption1.ToString();

                }
               // tbl = tbl + ds.Tables[0].Rows[d]["Cap"] ;
                 tbl = tbl + "</br>";
                tbl = tbl + (ds.Tables[0].Rows[d]["Key"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
               // string caption1 = ds.Tables[0].Rows[d]["Status"].ToString();
                //if (caption1.Length > 8)
                //{
                //    tbl = tbl + caption1.ToString().Substring(0, 8);
                //}
                //else
                //{
                //    tbl = tbl + caption1.ToString();

                //}
                //tbl = tbl + ds.Tables[0].Rows[d]["Cap"];
                //tbl = tbl + "</br>";
                tbl = tbl + (ds.Tables[0].Rows[d]["Status"] + "</td>");

                tbl = tbl + "</tr>";


                tbl += "<tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>";
                

                tblgrid.InnerHtml += tbl;
                tbl = "";

            }
            ct = ct + maxlimit;
            fr = fr + maxlimit;

            }



            tbl = tbl + ("<tr >");

            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + a.ToString() + "</td>");
            tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 12px;'>&nbsp;</td>");


            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");
            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }


            tbl = tbl + ("<td class='middle13new' colspan='3' align='right' style='font-size: 12px;'><b>BillAmt:</b></td>");
            tbl = tbl + ("<td class='middle1212' colspan='6' style='font-size: 12px;'>");
            tbl = tbl + (amt.ToString() + "</td>");

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
            tblgrid.InnerHtml += tbl;

         //   tblgrid.InnerHtml += tbl;


        }

        else
        {

             for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    tbl = tbl + "</table></P>";
                    if (p == pagecount ||p==0)
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
                            tbl += "<P ><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            //tbl += "<P style='page-break-before:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        //   else if (p == 0)
                        //   {
                        //       tbl += "<P style='page-break-before:inherit;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        //  }
                        else
                        {
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            //   tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            //tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        }
                    }
                    else if (ver == 6.0)
                    {
                        tbl = tbl + "</table>";
                        if (p == pagecount - 1)
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  
              //  tbl += "</table>";
              //  tbl += "<table width='93%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                 tbl += "<tr valign='top'>";
                tbl += "<td class='middle111' align='right' colspan='23'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl += "<tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>";


                tbl = tbl + ("<tr><td class='middle31new' width='1%' >S.</br>No.</td><td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='5%'align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%'align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='7%'align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='7%' align='left'>&nbsp;&nbsp;Client</td><td  class='middle31new' width='6%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' align='right' align='right'>&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='right'>&nbsp;&nbsp;HT</td><td class='middle31new' width='1%' align='right'>&nbsp;&nbsp;WD&nbsp;&nbsp;</td><td class='middle31new' width='3%'  align='left'>Page&nbsp;&nbsp;</br>Post&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left' >Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%'  align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='5%' align='left' >Ro No.</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' >&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt.&nbsp;&nbsp;</td><td class='middle31new' width='3%' colspan='2' align='left'>Caption</br>Key No</td><td class='middle31new' width='3%' colspan='2' align='left'>Status</td></tr>");
          

                  for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (a.ToString() + "</td>");


                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                    if (rrr.Length >= 10)
                    {
                        cioid1 = rrr.Substring(0, 10);
                        if (rrr.Length - 10 < 10)
                            cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                        else
                            cioid1 += "</br>" + rrr.Substring(10, 10);
                    }
                    else
                        cioid1 = rrr;


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (cioid1 + "</td>");


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    edition = ds.Tables[0].Rows[d]["edition"].ToString();
                    if (edition.Length > 8)
                    {
                        tbl = tbl + (edition.ToString().Substring(0, 8) + "</td>");

                    }
                    else
                    {
                        tbl = tbl + (edition.ToString() + "</td>");

                    }
                //tbl = tbl + (ds.Tables[0].Rows[d]["edition"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Ins_date"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");

                string agency1 = "";
                string rrr1 = ds.Tables[0].Rows[d]["Agency_Name"].ToString();

                if (rrr1.Length > 12)
                {
                    tbl = tbl + (rrr1.ToString().Substring(0, 12) + "</td>");
                }
                else
                {
                    tbl = tbl + (rrr1.ToString() + "</td>");

                }
                //if (rrr1.Length >= 16)
                //{
                //    agency1 = rrr1.Substring(0, 16);
                //    if (rrr1.Length - 16 < 16)
                //        agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                //    else
                //        agency1 += "</br>" + rrr1.Substring(16, 16);
                //}
                //else
                //    agency1 = rrr1;

                //tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                //tbl = tbl + (agency1 + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                
                string rrr2 = ds.Tables[0].Rows[d]["Client_Name"].ToString();
                //if (rrr2.Length >= 16)
                //{
                //    client1 = rrr2.Substring(0, 16);
                //    if (rrr2.Length - 16 < 16)
                //        client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                //    else
                //        client1 += "</br>" + rrr2.Substring(16, 16);
                //}
                //else
                //    client1 = rrr2;
                if (rrr2.Length > 12)
                {
                    tbl = tbl + (rrr2.ToString().Substring(0, 12) + "</td>");

                }
                else
                {
                    tbl = tbl + (rrr2.ToString() + "</td>");
                }

               



                string Package1 = "";
                string rrr3 = ds.Tables[0].Rows[d]["Package"].ToString();
                if (rrr3.Length >= 9)
                {
                    Package1 = rrr3.Substring(0, 9);
                    if (rrr3.Length - 9 < 9)
                        Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                    else
                        Package1 += "</br>" + rrr3.Substring(9, 9);
                }
                else
                    Package1 = rrr3;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (Package1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Color_code"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");

                if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                {
                   

                    if (ds.Tables[0].Rows[d]["uom"].ToString() == "CD" || ds.Tables[0].Rows[d]["uom"].ToString() == "ROD")
                        area = area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());

                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Depth"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Width"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                string page1 = ds.Tables[0].Rows[d]["Page"].ToString();
                if (page1.Length > 12)
                {
                    tbl = tbl + (page1.ToString().Substring(0, 12) + "</td>");
                }
                else
                {
                    tbl = tbl + (page1.ToString() + "</td>");

                }
               


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                string pagep1 = ds.Tables[0].Rows[d]["PagePremium"].ToString();
                if (pagep1.Length > 12)
                {
                    tbl = tbl + (pagep1.ToString().Substring(0, 12) + "</td>");
                }
                else
                {
                    tbl = tbl + (pagep1.ToString() + "</td>");

                }




                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                if (ds.Tables[0].Rows[d]["PositionPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[d]["PositionPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
                if (ds.Tables[0].Rows[d]["BulletPremium"].ToString() == "0")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (ds.Tables[0].Rows[d]["BulletPremium"] + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["RoNo."] + "</td>");



                string RoStatus1 = "";
                string rrr4 = ds.Tables[0].Rows[d]["RoStatus"].ToString();
                if (rrr4.Length >= 9)
                {
                    RoStatus1 = rrr4.Substring(0, 9);
                    if (rrr4.Length - 9 < 9)
                        RoStatus1 += "</br>" + rrr4.Substring(9, rrr4.Length - 9);
                    else
                        RoStatus1 += "</br>" + rrr4.Substring(9, 9);
                }
                else
                    RoStatus1 = rrr4;


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (RoStatus1 + "</td>");


                string AdCat1 = "";
                string rrr5 = ds.Tables[0].Rows[d]["AdCat"].ToString();
                if (rrr5.Length >= 9)
                {
                    AdCat1 = rrr5.Substring(0, 9);
                    if (rrr5.Length - 9 < 9)
                        AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                    else
                        AdCat1 += "</br>" + rrr5.Substring(9, 9);
                }
                else
                    AdCat1 = rrr5;

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (AdCat1 + "</td>");


                tbl = tbl + ("<td class='rep_data' align='left'>&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[0].Rows[d]["RateCode"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[d]["CardRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["CardRate"]).ToString("F2") + "</td>");
                }


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                if (ds.Tables[0].Rows[d]["AgreedRate"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {
                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["AgreedRate"]).ToString("F2") + "</td>");
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                if (ds.Tables[0].Rows[d]["Amt"].ToString() == "")
                {
                    tbl = tbl + "" + "</td>";
                }
                else
                {

                    tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["Amt"]).ToString("F2") + "</td>");
                    if (ds.Tables[0].Rows[d].ItemArray[19].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());
                }

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                string caption = ds.Tables[0].Rows[d]["Cap"].ToString();
                if (caption.Length > 8)
                {
                    tbl = tbl + caption.ToString().Substring(0, 8);
                }
                else
                {
                    tbl = tbl + caption.ToString();

                }
                //tbl = tbl + ds.Tables[0].Rows[d]["Cap"];
                tbl = tbl + "</br>";
             
                tbl = tbl + (ds.Tables[0].Rows[d]["Key"] + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[d]["Status"] + "</td>");
                tbl = tbl + "</tr>";



                tbl += "<tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>";
            


                tblgrid.InnerHtml += tbl;
                tbl = "";
            }
            ct = ct + maxlimit;
            fr = fr + maxlimit;
        }

          

            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + a.ToString() + "</td>");
            tbl = tbl + ("<td class='middle13new' colspan='4' style='font-size: 12px;'>&nbsp;</td>");


            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");
            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            //tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle13new' colspan='3' align='right' style='font-size: 12px;'><b>BillAmt:</b></td>");
            tbl = tbl + ("<td class='middle1212' colspan='6' style='font-size: 12px;'>");
            tbl = tbl + (amt.ToString(("F2")) + "</td>");
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
                    tbl = tbl + "</table></P>";

                }
            }
            tblgrid.InnerHtml += tbl;

           

        }
        
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }


    }

}
