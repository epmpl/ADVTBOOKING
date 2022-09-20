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
using System.Data.OracleClient;
using System.Data.SqlClient;

public partial class Reports_printrebatereport : System.Web.UI.Page
{
    int maxlimit = 17;
    string dateto = "", fromdt = "", destination = "", region = "", regionname = "";
    string adtype = "", orderby = "", pubcode = "", adtypename = "", publication = "";
    string exename = "", execode = "";
    int a = 0;
    string day = "", month = "", year = "", date = "";
    int dd2;
    double Area = 0;
    double Amt = 0;
    string temp_category = "", temp_agname = "", temp_pubcent = "", temp_edition = "", temp_state = "", temp_district = "", temp_client = "", temp_newcategory = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[45].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        ds = (DataSet)Session["rebaterep"];
        string prm = Session["prm_rebaterep_print"].ToString();
        string[] prm_Array = new string[23];
        prm_Array = prm.Split('~');



        fromdt = prm_Array[1];// Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[3]; //Request.QueryString["dateto"].ToString();
        destination = prm_Array[5];// Request.QueryString["destination"].ToString();
        regionname = prm_Array[7];// Request.QueryString["region"].ToString();
        region = prm_Array[9]; //Request.QueryString["regcode"].ToString();
        orderby = prm_Array[11];// Request.QueryString["orderby"].ToString();
        adtype = prm_Array[13];// Request.QueryString["adtype"].ToString();
        pubcode = prm_Array[15];// Request.QueryString["publication"].ToString();
        publication = prm_Array[17];// Request.QueryString["publname"].ToString();
        adtypename = prm_Array[19];// Request.QueryString["adtypename"].ToString();
        exename = prm_Array[21]; //Request.QueryString["exename"].ToString();
        execode = prm_Array[23];// Request.QueryString["execode"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));

        if (execode == "0" || execode=="")
            {
                lblexecutive.Text = "ALL".ToString();
            }
            else
            {
                lblexecutive.Text = exename.ToString();
            }
            if (pubcode == "0")
            {
                lblpublication.Text = "ALL".ToString();
            }
            else
            {
                lblpublication.Text = publication.ToString();
            }
            if (region == "0")
            {
                lblregion.Text = "ALL".ToString();
            }
            else
            {
                lblregion.Text = regionname.ToString();
            }

            if (adtype == "0")
            {
                lbladtype.Text = "ALL".ToString();
            }
            else
            {
                lbladtype.Text = adtypename.ToString();
            }

            if (orderby == "Publication")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[34].ToString();
            }
            else if (orderby == "Region")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[33].ToString();
            }
            else if (orderby == "Agency Region")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[75].ToString();

            }
            else if (orderby == "Extra Rebate")
            {
               
                heading.Text = ds1.Tables[0].Rows[0].ItemArray[35].ToString();
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
                else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
                    {

                        DateTime dt = System.DateTime.Now;


                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();
                        date = month + "/" + day + "/" + year;

                    }
                    else if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
                        {

                            DateTime dt = System.DateTime.Now;


                            day = dt.Day.ToString();
                            month = dt.Month.ToString();
                            year = dt.Year.ToString();
                            date = year + "/" + month + "/" + day;

                        }
            lbldate.Text = date.ToString();
            lblfrom.Text = fromdt;
            lblto.Text = dateto;

         onscreen(fromdt, dateto, Session["compcode"].ToString(), region, Session["dateformat"].ToString());
           
       
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



    private void onscreen(string fromdt, string dateto, string compcode, string reg, string dateformat)
    {
       
        //DataSet ds = new DataSet();
       
        // if (ConfigurationSettings.AppSettings["Connectiontype"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //    ds = obj.rebatebilling(fromdt, dateto, region, pubcode, temp_category, compcode, dateformat, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), temp_agname, adtype, temp_pubcent, temp_edition, execode, temp_state, temp_district, temp_client, temp_newcategory, orderby);
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int dealcount = 0;
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        string TBL = "";
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if ( pagec > 0)
        {pagecount = pagecount + 1;}

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
               // TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    
            //TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    TBL = TBL + "</table></P>";
                    if (p == pagecount ||p==0)
                        TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        TBL = TBL + "</table></P>";
                        if (p == pagecount - 1)
                            TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                    }
                    else if (ver == 6.0)
                    {
                        TBL = TBL + "</table>";
                        if (p == pagecount - 1)
                            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                    }
                }  
                for (int i = 0; i <= cont - 1; i++)
                {
                    if (ds.Tables[0].Rows[i]["Dealname"].ToString() == "" || ds.Tables[0].Rows[i]["Dealname"].ToString() == "0")
                    {}
                    else
                    {dealcount++;}
                }
               

                //TBL += "</table>";
              //  TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                TBL += "<tr valign='top'>";
                TBL += "<td class='middle111' align='right' colspan='15'>" + "Page  " + s + "  of  " + pagecount;
                TBL += "</td></tr>";

                TBL += "<tr></tr>";
                TBL += "<tr></tr>";
                TBL += "<tr></tr>";
                TBL += "<tr></tr>";
                TBL += "<tr></tr>";
                TBL += "<tr></tr>";
                TBL += "<tr></tr>";
                TBL += "<tr></tr>";

                TBL += "<tr>";
                TBL += "<td class='middle123' valign='top'>" + "S.No." + "</td>";
                if (orderby == "Publication")
                {
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Publication" + "</td>";
                }
                else if (orderby == "Region")
                {
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Region" + "</td>";
              
                }
                else if (orderby == "Agency Region")
                {
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Region" + "</td>";
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Agency" + "</td>";
              
                }
               
             
                TBL += "<td class='middle123' align='left' valign='top'>" + "Booking"+"</br>"+"Id" + "</td>";
                if (orderby != "Agency Region")
                {
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Agency" + "</td>";
                }
               
                TBL += "<td class='middle123' align='left' valign='top'>" + "Client" + "</td>";
                if (orderby == "Extra Rebate")
                {
                    TBL += "<td class='middle123' align='left' valign='top'>" + "Publication" + "</td>";
                }
                TBL += "<td class='middle123' align='right' valign='top'>" + "Area" + "</td>";
                TBL += "<td class='middle123' align='right' valign='top'>" + "Bill" + "</br>" + "Amt" + "</td>";

                TBL += "<td class='middle123' align='right' valign='top'>" + "Special" + "</br>" + "Disc" + "</td>";
                TBL += "<td class='middle123' align='right' valign='top'>" + "Space" + "</br>" + "Disc" + "</td>";
                TBL += "<td class='middle123' align='right' valign='top'>" + "Special" + "</br>" + "Disc%" + "</td>";
                TBL += "<td class='middle123' align='right' valign='top'>" + "Space" + "</br>" + "Disc%" + "</td>";
                TBL += "<td class='middle123' align='right' valign='top'>" + "Card" + "</br>" + "Rate" + "</td>";
                TBL += "<td class='middle123' align='right' valign='top'>" + "Agg" + "</br>" + "Rate" + "</td>";

                TBL += "<td class='middle123' valign='top' align='right'>" + "Disc" + "&nbsp;&nbsp;</td>";

                TBL += "<td class='middle123' valign='top' align='left'>" + "Revenue" + "</br>" + "Center" + "</td>";
                if (dealcount > 0)
                {
                    lbldeal.Text = "YES";
                    TBL += "<td class='middle123' valign='top' align='left'>" + "Deal Name" + "</td>";
                    TBL += "</tr>";
                }
                else
                {
                    lbldeal.Text = "NO";
                    TBL += "</tr>";
                }

               

                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                    if (d > 0 && orderby != "Extra Rebate")//for adcat total
                    {
                        if (orderby != "Agency Region")
                        {

                            if ((ds.Tables[0].Rows[d][orderby].ToString() != ds.Tables[0].Rows[d - 1][orderby].ToString()))//|| (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString()) || (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))
                            {
                                TBL = TBL + ("<tr style='height:40px'>");
                                TBL = TBL + ("<td class='rep_data' style='height:50px'>");
                                TBL = TBL + ("<b>" + "Total" + "</b>" + "</td>");

                                for (int abc = 0; abc <= 3; abc++)
                                {
                                    TBL = TBL + ("<td class='rep_data' style='height:50px'>");
                                    TBL = TBL + ("</td>");
                                }


                                int i11 = 3;
                                arr1[0] = 0;
                                arr1[1] = 0;
                                for (int j11 = dd2; j11 < a - 1; j11++)
                                {
                                    if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                    {
                                        arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                    }
                                    else
                                    {
                                        arr1[0] = arr1[0] + 0;
                                    }

                                    if (ds.Tables[0].Rows[j11]["BillAmt"].ToString() != "")
                                    {
                                        arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["BillAmt"].ToString());
                                    }
                                    else
                                    {
                                        arr1[1] = arr1[1] + 0;
                                    }
                                }
                                dd2 = Convert.ToInt32(a - 1);
                                for (int k11 = 0; k11 <= 1; k11++)
                                {
                                    TBL = TBL + "<td  align='right' class='rep_data'>";
                                    TBL = TBL + chk_null(arr1[k11].ToString());
                                    TBL = TBL + "</td>";
                                }
                                TBL = TBL + "</tr>";
                            }
                        }
                        else
                        {
                            if ((ds.Tables[0].Rows[d]["Region"].ToString() != ds.Tables[0].Rows[d - 1]["Region"].ToString()))//|| (ds.Tables[0].Rows[i]["Product"].ToString() != ds.Tables[0].Rows[i - 1]["Product"].ToString()) || (ds.Tables[0].Rows[i]["Region"].ToString() != ds.Tables[0].Rows[i - 1]["Region"].ToString()))
                            {
                                TBL = TBL + ("<tr style='height:40px'>");
                                TBL = TBL + ("<td class='rep_data' style='height:50px'>");
                                TBL = TBL + ("<b>" + "Total" + "</b>" + "</td>");

                                for (int abc = 0; abc <= 3; abc++)
                                {
                                    TBL = TBL + ("<td class='rep_data' style='height:50px'>");
                                    TBL = TBL + ("</td>");
                                }


                                int i11 = 3;
                                arr1[0] = 0;
                                arr1[1] = 0;
                                for (int j11 = dd2; j11 < a - 1; j11++)
                                {
                                    if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                    {
                                        arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                    }
                                    else
                                    {
                                        arr1[0] = arr1[0] + 0;
                                    }

                                    if (ds.Tables[0].Rows[j11]["BillAmt"].ToString() != "")
                                    {
                                        arr1[1] = arr1[1] + Convert.ToDouble(ds.Tables[0].Rows[j11]["BillAmt"].ToString());
                                    }
                                    else
                                    {
                                        arr1[1] = arr1[1] + 0;
                                    }
                                }
                                dd2 = Convert.ToInt32(a - 1);
                                for (int k11 = 0; k11 <= 1; k11++)
                                {
                                    TBL = TBL + "<td  align='right' class='rep_data'>";
                                    TBL = TBL + chk_null(arr1[k11].ToString());
                                    TBL = TBL + "</td>";
                                }
                                TBL = TBL + "</tr>";
                            }
                        }
                    }//for adcat total

                    TBL += "<tr>";
                    TBL = TBL + ("<td class='rep_data' valign='top' >");
                    TBL = TBL + (a.ToString() + "</td>");
                    if (orderby == "Publication")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Publication"].ToString() != ds.Tables[0].Rows[d - 1]["Publication"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }


                    }
                    if (orderby == "Region")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        // TBL = TBL + (ds.Tables[0].Rows[i]["Region"] + "</td>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Region"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Region"].ToString() != ds.Tables[0].Rows[d - 1]["Region"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Region"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }
                    }

                    if (orderby == "Agency Region")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        //TBL = TBL + (ds.Tables[0].Rows[i]["Publication"] + "</td>");
                        if (d == 0)
                        {
                            TBL = TBL + (ds.Tables[0].Rows[d]["Region"] + "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[d]["Region"].ToString() != ds.Tables[0].Rows[d - 1]["Region"].ToString())
                            {
                                TBL = TBL + (ds.Tables[0].Rows[d]["Region"] + "</td>");
                            }
                            else
                            {
                                TBL = TBL + ("</td>");
                            }
                        }

                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
                        char[] agency = rrr1.ToCharArray();
                        int len111 = agency.Length;
                        int line11 = 0;
                        int ch_end1 = 0;
                        int ch_str1 = 0;
                        for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                        {
                            /**/
                            ch_end1 = ch_end1 + 16;
                            ch_str1 = ch_end1;
                            if (ch_end1 > len111)
                                ch_str1 = len111 - ch1;
                            else
                                ch_str1 = ch_end1 - ch1;

                            agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                            agency1 = agency1 + "</br>";
                            ch1 = ch1 + 16;
                            if (ch1 > len111)
                                ch1 = len111;/**/
                        }
                        TBL = TBL + (agency1 + "</td>");
                    }

                    TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");

                    string cioid1 = "";
                    string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                    char[] cioid = rrr.ToCharArray();
                    int len11 = cioid.Length;

                    int ch_end = 0;
                    int ch_str = 0;
                    for (int ch = 0; ch < len11; ch++)
                    {
                        /**/
                        ch_end = ch_end + 9;
                        ch_str = ch_end;
                        if (ch_end > len11)
                            ch_str = len11 - ch;
                        else
                            ch_str = ch_end - ch;

                        cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                        cioid1 = cioid1 + "</br>";
                        ch = ch + 9;
                        if (ch > len11)
                            ch = len11;
                    }
                    TBL = TBL + (cioid1 + "</td>");


                    if (orderby != "Agency Region")
                    {
                        TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
                        char[] agency = rrr1.ToCharArray();
                        int len111 = agency.Length;
                        int line11 = 0;
                        int ch_end1 = 0;
                        int ch_str1 = 0;
                        for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                        {
                            /**/
                            ch_end1 = ch_end1 + 16;
                            ch_str1 = ch_end1;
                            if (ch_end1 > len111)
                                ch_str1 = len111 - ch1;
                            else
                                ch_str1 = ch_end1 - ch1;

                            agency1 = agency1 + rrr1.Substring(ch1, ch_str1).Trim();
                            agency1 = agency1 + "</br>";
                            ch1 = ch1 + 16;
                            if (ch1 > len111)
                                ch1 = len111;/**/
                        }
                        TBL = TBL + (agency1 + "</td>");
                    }
                    /////////////////////////////////////////////////////////////////////end
                   

                    TBL = TBL + ("<td class='rep_data' align='left' valign='top'>");
                    //TBL = TBL + (ds.Tables[0].Rows[d]["Client"] + "</td>");
                    string client1 = "";
                    string rrr11 = ds.Tables[0].Rows[d]["Client"].ToString();
                    char[] client = rrr11.ToCharArray();
                    int len1111 = client.Length;
                    int line = 0;
                    int ch_end11 = 0;
                    int ch_str11 = 0;
                    for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                    {
                        /* */
                        ch_end11 = ch_end11 + 16;
                        ch_str11 = ch_end11;
                        if (ch_end11 > len1111)
                            ch_str11 = len1111 - ch11;
                        else
                            ch_str11 = ch_end11 - ch11;

                        client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
                        client1 = client1 + "</br>";
                        ch11 = ch11 + 16;
                        if (ch11 > len1111)
                            ch11 = len1111;
                    }
                    if (rrr11.Length>16)
                    client1 = rrr11.Substring(0, 16).Trim();
                    else
                        client1 = rrr11;
                    TBL = TBL + (client1 + "</td>");
                    if (orderby == "Extra Rebate")
                    {
                        TBL = TBL + ("<td class='rep_data' valign='top' align='left'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Publication"] + "</td>");
                    }
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Area"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                        Area = Area + float.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["BillAmt"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["BillAmt"].ToString() != "")
                        Amt = Amt + double.Parse(ds.Tables[0].Rows[d]["BillAmt"].ToString());


                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["SpecialDisc"].ToString()) + "</td>");
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["SpaceDisc"].ToString()) + "</td>");
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["SpecialDisc%"] + "</td>");
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["SpaceDisc%"] + "</td>");

                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["CardRate"].ToString()) + "</td>");
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["AgreedRate"].ToString()) + "</td>");
                    TBL = TBL + ("<td class='rep_data' valign='top' align='right'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Disc"].ToString()) + "&nbsp;&nbsp;</td>");
                    TBL = TBL + ("<td class='rep_data' valign='top' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["RevenueCenter"] + "</td>");
                    if (ds.Tables[0].Rows[d]["Dealname"].ToString() == "" || ds.Tables[0].Rows[d]["Dealname"].ToString() == "0")
                    {
                    }
                    else
                    {
                        TBL = TBL + ("<td class='rep_data' valign='top' align='left'>");
                        TBL = TBL + (ds.Tables[0].Rows[d]["Dealname"] + "</td>");

                    }
                    TBL += "</tr>";

                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";
                    TBL += "<tr></tr>";

                    div1.InnerHtml += TBL;
                    TBL = "";
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }


            TBL = TBL + ("<tr><td class='middle1212' align='left' ><b>Total Ads.</b></td>");
            TBL = TBL + ("<td class='middle1212' align='left'>");
            TBL = TBL + (a.ToString() + "</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");

            TBL = TBL + ("<td class='middle1212'><b>Total:</b></td>");
            TBL = TBL + ("<td class='middle1212' align='right'>");
            double cal = System.Math.Round(Convert.ToDouble(Area), 2);
            TBL = TBL + (chk_null(cal.ToString()) + "</td>");
            TBL = TBL + ("<td class='middle1212' align='right'  >");
            double cal1 = System.Math.Round(Convert.ToDouble(Amt), 2);
            TBL = TBL + (chk_null(cal1.ToString()) + "</td>");
            TBL = TBL + ("<td class='middle1212' colspan='8'>&nbsp;</td>");
            if (dealcount > 0)
            {
                TBL = TBL + ("<td class='middle1212' >&nbsp;</td></tr>");
            }
            else
            {
                TBL = TBL + ("</tr>");
            }
            //TBL = TBL + "</tr>";
            if (browser.Browser == "Firefox")
            {
                TBL = TBL + "</table></P>";

            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    TBL = TBL + "</table></P>";

                }
                else if (ver == 6.0)
                {
                    TBL = TBL + "</table>";

                }
            }  
          //  TBL += "</table>";

            div1.Visible = true;
            div1.InnerHtml += TBL;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }

    }
}
