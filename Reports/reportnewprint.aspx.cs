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
using System.Text;

public partial class reportnewprint : System.Web.UI.Page
{
    int maxlimit = 10;
    int a = 0;
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
    string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string adtypename = "";
    string editionname = "";
    string pdfName1 = "";
    string datefrom1 = "";
    string dateto1 = "";
    string package = "";
    int i1 = 1;
    double amt = 0;
    string client = "";
    string agency = "";
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;

    string sortorder = "";
    string sortvalue = "";
    string adsubcat = "";
    string adsubcatname = "", agtype = "", agtypetext = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["dateformat"] == null)
            Response.Redirect("../login.aspx");
        else
            hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[1].ToString());
        //maxlimit = 2;


        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();

        ds = (DataSet)Session["allads"];

        string prm = Session["parameter_print"].ToString();
        string[] prm_Array = new string[35];
        prm_Array = prm.Split('~');
  
        adtyp = prm_Array[1];//Request.QueryString["adtype"].ToString();
        adcat = prm_Array[3]; //Request.QueryString["adcategory"].ToString();
        adsubcat = prm_Array[5]; //Request.QueryString["adsubcat"].ToString();
        fromdt = prm_Array[7]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[9]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[11]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[13]; //Request.QueryString["pubcenter"].ToString();
        edition = prm_Array[15]; //Request.QueryString["edition"].ToString();
        pubcname = prm_Array[17]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[19]; //Request.QueryString["publiccent"].ToString();
        adcatname = prm_Array[21]; //Request.QueryString["adcatname"].ToString();
        adtypename = prm_Array[23]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[25]; //Request.QueryString["editionname"].ToString();
        adsubcatname = prm_Array[27]; //Request.QueryString["adsubcatname"].ToString();
        agtype = prm_Array[29]; //Request.QueryString["agtype1"].ToString();
        agtypetext = prm_Array[31]; //Request.QueryString["agtypetext"].ToString();


        Ajax.Utility.RegisterTypeForAjax(typeof(reportnewprint));
        hiddendatefrom.Value = fromdt.ToString();

        if (agtype == "0")
            lblagtype.Text = "ALL".ToString();
        else
            lblagtype.Text = agtypetext.ToString();

        if (adtyp == "0")
            lbladtype.Text = "ALL".ToString();
        else
            lbladtype.Text = adtypename.ToString();

        if ((adcat == "0") || (adcat == ""))
            lbladcatg.Text = "ALL".ToString();
        else
            lbladcatg.Text = adcatname.ToString();

        if ((adsubcatname == "0") || (adsubcatname == ""))
            lbladsubcat.Text = "ALL".ToString();
        else
            lbladsubcat.Text = adsubcatname.ToString();


        if (publ == "0")
            lblpub.Text = "ALL".ToString();
        else
            lblpub.Text = pubcname.ToString();
        if (pubcen == "0")
            pcenter.Text = "ALL".ToString();
        else
            pcenter.Text = pub2.ToString();


        if (edition == "0" || edition == "")
            lbedition.Text = "ALL".ToString();
        else
            lbedition.Text = editionname.ToString();


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
        onscreen(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());


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




    private void onscreen(string adtyp, string adcat, string adsubcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
        //    ds = obj.spfun1(adtyp, adcat, adsubcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", agtypetext, Session["userid"].ToString());

        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;

        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
            pagecount = pagecount + 1;

        //string tbl = "";
        StringBuilder tbl = new StringBuilder();
        if (ds.Tables[0].Rows.Count > 0)
        {

            if (browser.Browser == "Firefox")
            {
              //  tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) ||(ver == 8.0))
                {
                   tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if ( ver == 6.0)
                {
                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
            }    



            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;


                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");
                    if (p == pagecount ||p==0)
                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    else
                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0)||(ver == 7.0))
                    {
                        tbl.Append("</table></P>");
                        if(p==pagecount)
                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        if (p == 1)
                            maxlimit = maxlimit + 4;
                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table>");
                        if (p == pagecount - 1)
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                        tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                    }
                }  


               // tbl += "</table>";
               // tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                 tbl.Append("<tr valign='top'>");
           //     tbl += "<td class='middle111' align='right' colspan='22'>" + "Page  " + s + "  of  " + pagecount;
                 tbl.Append("<td class='middle111' align='right' colspan='22'>" + "Page  " + s );
                tbl.Append("</td></tr>");

                tbl.Append("<tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr><tr></tr>");


                tbl.Append("<tr><td  class='middle31new' width='1%' >S.</br>No</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='9%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='11%' align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='6%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp;HT</td><td class='middle31new' width='2%' align='right'>&nbsp;&nbsp;WD</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle31new' width='1%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='6%' align='left'>Ro No.</br>Status</td><td class='middle31new' width='4%' align='left'>Executive </td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Ro </br>&nbsp;&nbsp;Status</td> <td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;Agg</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right' style=\"padding-left:4px\">Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</td><td class='middle31new' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No.</td></tr>");



                 for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr ; d++)
                {

                    a = d;
                    a = a + 1;
                   tbl.Append("<tr >");
                   tbl.Append("<td class='rep_data'>" + a.ToString() + "</td>");
                    //tbl = tbl + (a.ToString() + "</td>");

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



                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + cioid1 + "</td>");


                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[d]["edition"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[d]["Ins.Date"] + "</td>");
                   


                    string agency1 = "";
                    string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
                    if (rrr1.Length >= 12)
                    {
                        agency1 = rrr1.Substring(0, 12);
                        if (rrr1.Length - 12 < 12)
                            agency1 += "</br>" + rrr1.Substring(12, rrr1.Length - 12);
                        else
                            agency1 += "</br>" + rrr1.Substring(12, 12);
                    }
                    else
                        agency1 = rrr1;
                    if (ds.Tables[0].Rows[d]["Agency"].ToString().Length>15)
                    agency1 = ds.Tables[0].Rows[d]["Agency"].ToString().Substring(0, 15);


                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + agency1 + "</td>");
                    

                    string client1 = "";
                    string rrr2 = ds.Tables[0].Rows[d]["Client"].ToString();
                    //if (rrr2.Length >= 16)
                    //{
                    //    client1 = rrr2.Substring(0, 16);
                    //    if (rrr2.Length - 16 < 16)
                    //        client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                    //    else
                    //        client1 += "</br>" + rrr2.Substring(16, 16);
                    //}
                    if (rrr2.Length >= 16)
                    {
                        client1 = ds.Tables[0].Rows[d]["Client"].ToString().Substring(0, 16);
                    }
                    else
                    {
                        client1 = rrr2;
                    }




                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + client1 + "</td>");
                    
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




                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + Package1 + "</td>");
                    


                    
                    if ((ds.Tables[0].Rows[d]["Depth"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>&nbsp;</td>");
                    }
                    else
                    {                        
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[d]["Depth"]).ToString() + "</td>");

                    }
                    

                    if ((ds.Tables[0].Rows[d]["Width"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                       
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[d]["Width"]).ToString() + "</td>");
                        

                    }
                    

                    if ((ds.Tables[0].Rows[d]["Area"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                        
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[d]["Area"]).ToString("F2") + "</td>");
                        
                        if (ds.Tables[0].Rows[d]["uom"].ToString() == "CD" || ds.Tables[0].Rows[d]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                        else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());


                      
                    }

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[d]["Color_code"] + "</td>");
                   

                    string page = "";
                    string pg1 = ds.Tables[0].Rows[d]["Page"].ToString();

                    if (pg1.Length >= 12)
                    {
                        page = ds.Tables[0].Rows[d]["Page"].ToString().Substring(0, 12);
                    }
                    else
                    {
                        page = pg1;
                    }


                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + page + "</td>");
                                  
                   


                    if (ds.Tables[0].Rows[d]["PagePremium"].ToString() == "0")
                    {
                        
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >&nbsp;</td>");
                    }
                    else
                    {                       
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >" + ds.Tables[0].Rows[d]["PagePremium"] + "</td>");
                    }




                    
                    if (ds.Tables[0].Rows[d]["PositionPremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                        
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[d]["PositionPremium"] + "</td>");
                        
                    }

                   
                    if (ds.Tables[0].Rows[d]["BulletPremium"].ToString() == "0")
                    {
                        
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[d]["BulletPremium"] + "</td>");
                        
                    }


                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[d]["RoNo."] + "</br>" + ds.Tables[0].Rows[d]["ADSTATUS"] + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[d]["RoNo."] + "</td>");



                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[d]["DOCKIT_NO"] + "</td>");
                    

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



                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + RoStatus1 + "</td>");
                    
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



                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + AdCat1 + "</td>");
                    



                    

                    if ((ds.Tables[0].Rows[d]["CardRate"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                      
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[d]["CardRate"]).ToString("F2") + "</td>");
                        
                    }
                   
                    if ((ds.Tables[0].Rows[d]["AgreedRate"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                       
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>"+Convert.ToDouble(ds.Tables[0].Rows[d]["AgreedRate"]).ToString("F2")+"</td>");
                       

                    }

                     ////cash disc

                   

                    if ((ds.Tables[0].Rows[d]["Cash_Disc"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                       
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[d]["Cash_Disc"]).ToString("F2") + "</td>");
                        
                    }
                     /////cash disc
                    

                    if ((ds.Tables[0].Rows[d]["Amt"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                        
                    }
                    else
                    {
                       tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[d]["Amt"]).ToString("F2") + "</td>");
                        
                    }

                    if (ds.Tables[0].Rows[d]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[d]["Cap"] + "</br>" + ds.Tables[0].Rows[d]["Key"] + "</td>");

                    //tbl = tbl + ds.Tables[0].Rows[d]["Cap"];
                    //tbl = tbl + "</br>";

                    //tbl = tbl + (ds.Tables[0].Rows[d]["Key"] + "</td>");


                    tbl.Append("</tr>");

                    tbl.Append("<tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr><tr ></tr>");
                 

                    tblgrid.InnerHtml = tbl.ToString();
                    

                }
                ct = ct + maxlimit;
                if (p == 0)
                {
                    //*****change by rikkee
                    //fr = fr + maxlimit + 4;
                    //pagec = (rcount - 20) % (maxlimit + 4);
                    //pagecount = (rcount - 20) / (maxlimit + 4);
                    fr = fr + maxlimit;
                    pagec = (rcount - 18) % (maxlimit);
                    pagecount = (rcount - 18) / (maxlimit);
                    if (pagec > 0)
                        pagecount = pagecount + 2;

                    if(pagec == 0)
                        pagecount = pagecount + 1;
                }
                else
                    fr = fr + maxlimit;


            }

            tbl.Append("<tr>");
            tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + a.ToString() + "</td>");
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
           
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
          
            tbl.Append("<td class='middle1212' colspan='4' align='right'><b>Total Area: "+chk_null(cal.ToString())+"</b></td>");
            if (totrol > 0)
            {
               
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
               
                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b> " + calf.ToString() + "</td>");
            }
            else
                tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");

            if (totcd > 0)
            {
              
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>" + calfd.ToString() + " </td>");
            }
            else
                tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");

            if (totcc > 0)
            {
                
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                
                tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>" + calft.ToString() + " ");
            }
            else
                tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");

            tbl.Append("<td class='middle13new' align='right' colspan='5' style='font-size: 13px;'><b>BillAmt:</b>"+chk_null(amt.ToString()) +" </td>");
           
            tbl.Append("<td class='middle13new'>&nbsp;</td></tr>");

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
            tblgrid.InnerHtml = tbl.ToString();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
}
