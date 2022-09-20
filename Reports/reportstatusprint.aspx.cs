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

public partial class reportstatusprint : System.Web.UI.Page
{
     string tbl;
    string agency = "";
    string client = "";
    int maxlimit = 10;
    int a = 0;
    string dytbl = "";

    string fromdt = "";
    string dateto = "";

    string package = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";

    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string status = "";
    string agname = "";
    string adcatname = "";
    string status1 = "";
    string hold = "";
    string datefrom1 = "";
    string dateto1 = "";

    //////////////////////////


    int sno = 1;
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    double areasum = 0;

    /////////////////////////


    string adtypename = "";
    double amt = 0;
    double Arr = 0;
    double area = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    //int area = 0;
    int ins_no = 0;
    string sortorder = "";
    string sortvalue = "";
    string editionname = "", agtype = "", agtypetext = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {

       // hiddendateformat.Value = "dd/mm/yyyy";
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
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[7].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        ds = (DataSet)Session["statusad"];
        string prm = Session["prm_statusad_print"].ToString();
        string[] prm_Array = new string[37];
        prm_Array = prm.Split('~');

         
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();


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
        status1 = prm_Array[21]; //Request.QueryString["status1"].ToString();
        adcatname = prm_Array[23]; //Request.QueryString["adcatname"].ToString();
        status = prm_Array[24]; //Request.QueryString["status"].ToString();
        adtypename = prm_Array[25]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[27]; //Request.QueryString["editionname"].ToString();
        hold = prm_Array[29]; //Request.QueryString["hold"].ToString();
        agtype = prm_Array[31]; //Request.QueryString["agtype1"].ToString();
        agtypetext = prm_Array[33]; //Request.QueryString["agtypetext"].ToString();


        //hold = "abc";
        hiddendatefrom.Value = fromdt.ToString();
        Session["fromdate"] = fromdt;
        Session["todate"] = dateto;

        //  hiddendateto.Value = dateto.ToString();
        // string dateformat = Request.QueryString["dateformat"].ToString();
        if (agtype == "0")
        {
            lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = agtypetext.ToString();
        }


        if (adtyp == "0")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypename.ToString();
        }

        if ((adcat == "0") || (adcat == ""))
        {
            lbladcatg.Text = "ALL".ToString();
        }
        else
        {
            lbladcatg.Text = adcatname.ToString();
        }



        if (publ == "0")
        {
            lblpub.Text = "ALL".ToString();
        }
        else
        {
            lblpub.Text = pubcname.ToString();
        }
        if (pubcen == "0")
        {
            pcenter.Text = "ALL".ToString();
        }
        else
        {
            pcenter.Text = pub2.ToString();
        }


        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();


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

      

        //datefrom1 = "";
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





            ///////////


            if (hiddendateformat.Value == "dd/mm/yyyy")
            {

                string[] arr = dateto.Split('/');
                string dd = arr[0];
                string mm = arr[1];
                string yy = arr[2];
                dateto1 = dd + "/" + mm + "/" + yy;

            }


        ////////////

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



        //if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        //{

        //    DateTime dt = System.DateTime.Now;


        //    day = dt.Day.ToString();
        //    month = dt.Month.ToString();
        //    year = dt.Year.ToString();
        //    date = day + "/" + month + "/" + year;

        //}
        //else
        //    if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
        //    {

        //        DateTime dt = System.DateTime.Now;


        //        day = dt.Day.ToString();
        //        month = dt.Month.ToString();
        //        year = dt.Year.ToString();
        //        date = month + "/" + day + "/" + year;

        //    }
        //    else
        //        if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
        //        {

        //            DateTime dt = System.DateTime.Now;


        //            day = dt.Day.ToString();
        //            month = dt.Month.ToString();
        //            year = dt.Year.ToString();
        //            date = year + "/" + month + "/" + day;

        //        }
        //lbldate.Text = date.ToString();
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
        ////dateto1 = "";
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
        if (status1 == "--Select Status--")
        {

            lbstatus.Text = "ALL".ToString();
        }
        else
        {
            lbstatus.Text = status1.ToString();
        }

      
            onscreen(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
       
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
    private void onscreen(string agname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string status, string edition, string dateformat, string hold)
    {
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
         if (ds.Tables[0].Rows.Count > 0)
        {

        for (int p = 0; p < pagecount; p++)
        {
             int s = p + 1;
            if (browser.Browser == "Firefox")
            {


                tbl = tbl + "</table></P>";
                if (p == pagecount || p == 0)
                    tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                else
                    tbl += "<P style='page-break-after:always;'><table cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

            }

            else if (browser.Browser == "IE")
            {


                tbl = tbl + "</table></P>";
                if (p == pagecount || p == 0)
                    tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                else
                    tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";


            }
                
                tbl += "<tr valign='top'>";
                tbl += "<td class='middle111' align='right' colspan='16'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "<td class='middle111' align='right' colspan='16'>";
                tbl += "</td></tr>";



                tbl = tbl + ("<tr  ><td class='middle31new' width='1%'>S.</br>No</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new' width='8%' align='left'>&nbsp;&nbsp;Agency</td><td class='middle31new' width='8%' align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='6%' align='right'>&nbsp;&nbsp; HT</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp; WD</td><td  class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Area</td><td class='middle31new'  width='2%' align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='4%' align='left'>&nbsp;&nbsp;AdCat</td><td  class='middle31new' width='4%' align='right'>&nbsp;&nbsp;CardRate</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt.&nbsp;&nbsp;</td><td class='middle31new' width='3%' align='right'>&nbsp;&nbsp;Disc</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Status</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Material</br>&nbsp;&nbsp;Status</td><td class='middle31new'  width='4%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No.</td></tr>");


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
                    tbl = tbl + (ds.Tables[0].Rows[d]["edition"] + "</td>");


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Ins_Date"] + "</td>");


                   
                    string agency1 = "";
                    string rrr1 = ds.Tables[0].Rows[d]["Agency_Name"].ToString();
                    if (rrr1.Length >= 16)
                    {
                        agency1 = rrr1.Substring(0, 16);
                        if (rrr1.Length - 16 < 16)
                            agency1 += "</br>" + rrr1.Substring(16, rrr1.Length - 16);
                        else
                            agency1 += "</br>" + rrr1.Substring(16, 16);
                    }
                    else
                        agency1 = rrr1;

                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (agency1 + "</td>");



                    
                    string client1 = "";
                    string rrr2 = ds.Tables[0].Rows[d]["Client_Name"].ToString();
                    if (rrr2.Length >= 16)
                    {
                        client1 = rrr2.Substring(0, 16);
                        if (rrr2.Length - 16 < 16)
                            client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                        else
                            client1 += "</br>" + rrr2.Substring(16, 16);
                    }
                    else
                        client1 = rrr2;


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (client1 + "</td>");




                    
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
                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (Package1 + "</td>");




                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Depth"] + "</td>");

                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Width"] + "</td>");

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


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>&nbsp&nbsp");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Color_code"] + "</td>");


                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["AdCat"] + "</td>");

                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'> ");


                    if ((ds.Tables[0].Rows[d]["CardRate"]).ToString() == "")
                    {
                        tbl = tbl + "" + "</td>";
                    }
                    else
                    {

                        tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["CardRate"]).ToString("F2") + "</td>");
                    }




                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");

                    if ((ds.Tables[0].Rows[d]["Amt"]).ToString() == "")
                    {
                        tbl = tbl + "" + "</td>";
                    }
                    else
                    {

                        tbl = tbl + (Convert.ToDouble(ds.Tables[0].Rows[d]["Amt"]).ToString("F2") + "</td>");
                        amt = amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());
                    }

                    
                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Disc"] + "</td>");
                    
                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Status"] + "</td>");
                    
                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["MatStatus"] + "</td>");
                    
                    tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' colspan='2' align='left'>");
                    tbl = tbl + ds.Tables[0].Rows[d]["Cap"];
                    tbl = tbl + "</br>";
                   
                    tbl = tbl + (ds.Tables[0].Rows[d]["Key"] + "</td>");
                   

                    tbl = tbl + "</tr>";



                    tblgrid.InnerHtml += tbl;
                    tbl = "";

                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
        }
       


           


            tbl = tbl + ("<tr>");

            tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'><b>Total Ads:</b>" + a.ToString() + "</td>");
            //tbl = tbl + ("<td class='middle13new' colspan='2' style='font-size: 12px;'>&nbsp;</td>");


            if (totcc > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl = tbl + (calft.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
            }

            tbl = tbl + ("<td class='middle1212' colspan='6' align='right'><b>Total Area:</b>");
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl = tbl + (cal.ToString() + "</td>");

            if (totrol > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl = tbl + (calf.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
            }
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle13new' colspan='2' align='right' style='font-size: 12px;'><b>BillAmt:</b>");
            //tbl = tbl + ("<td class='middle13new' colspan='3' style='font-size: 12px;'>");
            tbl = tbl + (amt.ToString() + "</td>");
            if (totcd > 0)
            {
                tbl = tbl + ("<td class='middle1212' colspan='2' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl = tbl + (calfd.ToString() + "</td>");
            }
            else
            {
                tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
            }
           
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");

            tbl = tbl + "</tr>";
       
            //if (browser.Browser == "Firefox")
            //{
            //    tbl = tbl + "</table></P>";

            //}
            //else if (browser.Browser == "IE")
            //{
            //    if ((ver == 8.0) || (ver == 7.0))
            //    {
            //        tbl = tbl + "</table></P>";

            //    }
            //    else if (ver == 6.0)
            //    {
            //        tbl = tbl + "</table>";

            //    }
           // }  
            tblgrid.InnerHtml += tbl;




    }
         else
         {
             Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
         }
        }
       
    }
