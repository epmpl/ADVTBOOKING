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

public partial class printcategoryreport : System.Web.UI.Page
{
    int maxlimit = 10;
    string page = "", fromdate = "", dateto = "", publication = "", pubcent = "", region = "", destination = "", adtype = "";
    string executive = "", city = "", chk = "", pagename = "", pubname = "", pubcentname = "", regionname = "", adtypename = "";
    string exename = "", cityname = "", agcatname = "", agcat = "";
    string day = "", month = "", year = "", date = "", todate = "", fromdt = "";
    string tbl;
   
    int a = 0;
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
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[23].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        DataSet dsx = new DataSet();
        dsx.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = dsx.Tables[0].Rows[0].ItemArray[87].ToString();


        ds = (DataSet)Session["catreport"];
        string prm = Session["prm_catreport_print"].ToString();
        string[] prm_Array = new string[39];
        prm_Array = prm.Split('~');


        dateto = prm_Array[1];// Request.QueryString["dateto"].ToString();
        fromdate = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        destination = prm_Array[5]; //Request.QueryString["destination"].ToString();
        region = prm_Array[7]; //Request.QueryString["region"].ToString();
        regionname = prm_Array[9]; //Request.QueryString["regiontext"].ToString();
        chk = prm_Array[11]; //Request.QueryString["grp"].ToString();
        page = prm_Array[13]; //Request.QueryString["page"].ToString();
        publication = prm_Array[15]; //Request.QueryString["publication"].ToString();
        pubcent = prm_Array[17]; //Request.QueryString["pubcenter"].ToString();
        adtype = prm_Array[19]; //Request.QueryString["adtype"].ToString();
        executive = prm_Array[21]; //Request.QueryString["rep"].ToString();
        city = prm_Array[23]; //Request.QueryString["place"].ToString();
        agcat = prm_Array[25]; //Request.QueryString["agcat"].ToString();
        pagename = prm_Array[27]; //Request.QueryString["pagetext"].ToString();
        pubname = prm_Array[29]; //Request.QueryString["publicname"].ToString();
        pubcentname = prm_Array[31]; //Request.QueryString["publiccent"].ToString();
        adtypename = prm_Array[33]; //Request.QueryString["adtypetext"].ToString();
        exename = prm_Array[35]; //Request.QueryString["reptext"].ToString();
        cityname = prm_Array[37]; //Request.QueryString["placetext"].ToString();
        agcatname = prm_Array[39]; //Request.QueryString["agcatname"].ToString();

        if (page == "0")
        { lblpage.Text = "ALL".ToString(); }
        else
        { lblpage.Text = pagename.ToString(); }

        if (pubcent == "0")
        { lblpubcent.Text = "ALL".ToString(); }
        else
        { lblpubcent.Text = pubcentname.ToString(); }

        if (publication == "0")
        { lblpub.Text = "ALL".ToString(); }
        else
        { lblpub.Text = pubname.ToString(); }

        if (region == "0")
        { lblregion.Text = "ALL".ToString(); }
        else
        { lblregion.Text = regionname.ToString(); }

        if (adtype == "0")
        { lbladtype.Text = "ALL".ToString(); }
        else
        { lbladtype.Text = adtypename.ToString(); }

        if (executive == "0" || executive=="")
        { lblexecutive.Text = "ALL".ToString(); }
        else
        { lblexecutive.Text = exename.ToString(); }

        if (city == "0")
        { lblcity.Text = "ALL".ToString(); }
        else
        { lblcity.Text = cityname.ToString(); }

        if (agcat == "0")
        { lblagcat.Text = "ALL".ToString(); }
        else
        { lblagcat.Text = agcatname.ToString(); }


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

        lblfrom.Text = fromdate;
        lblto.Text = dateto;
        onscreen(fromdate, dateto, region, pubcent, page, Session["compcode"].ToString(), Session["dateformat"].ToString(), publication, adtype, executive, city, agcat);
       

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

    private void onscreen(string datefrom, string dateto, string region, string pubcent, string page, string compcode, string dateformate, string publname, string adtyp, string execode, string city, string agencycat)
    {
        string temp1 = "", temp2 = "";

        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
        //    ds = obj.categoryreport(datefrom, dateto, adtyp, publname, pubcent, execode, region, city, chk, page, compcode, dateformate, temp1, temp2, agencycat);
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
      string TBL = "";
      double totalgross = 0;
      double totalbill = 0;
      double totalyield = 0;
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
            
           // TBL = "<table width='80%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            //if (browser.Browser == "Firefox")
            //{
            //    TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            //}
            //else if (browser.Browser == "IE")
            //{
            //    if ((ver == 7.0) || (ver == 8.0))
            //    {
            //        TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                
            //    }

            //    else if (ver == 6.0)
            //    {
            //        TBL = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            //    }
            //}    
            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {


                    TBL = TBL + "</table></P>";
                    if (p == pagecount || p == 0)
                        TBL += "<P><table  cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        TBL += "<P style='page-break-after:always;'><table  cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                }

                else if (browser.Browser == "IE")
                {


                    TBL = TBL + "</table></P>";
                    if (p == pagecount - 1)
                        TBL += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        TBL += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";


                }


               
                TBL += "<tr valign='top'>";
                TBL += "<td class='middle111' align='right' colspan='21'>" + "Page  " + s + "  of  " + pagecount;
                TBL += "</td></tr>";

               
                TBL = TBL + ("<tr valign='top'><td class='rep_datatotal_vouchdata' valign='top'>S.No.</td><td class='rep_datatotal_vouchdata' valign='top'  align='left'>Booking</br>Id</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Agency</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Agency</br>Add.</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Client</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Client</br>Add.</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>RoNo</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>RoDate</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Area</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Edition</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Color</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Bill</br>Status</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Pay</br>Type</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Spl</br>Disc.</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Space</br>Disc.</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Revenue</br>Center</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Rate</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Gross</br>Amt</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Agency</br>TD</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Addl</br>TD</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Bill</br>Amt</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Yield</td></tr>");
               
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;

                    TBL += "<tr>";
                    TBL = TBL + ("<td class='rep_data'>");
                    TBL = TBL + (a.ToString() + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                   
                    
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
                    TBL = TBL + (cioid1 + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                    
                    
                   

                    TBL = TBL + (ds.Tables[0].Rows[d]["Agency"].ToString() + "</td>");



                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                   
                   
                    TBL = TBL + (ds.Tables[0].Rows[d]["A_Place"].ToString() + "</td>");

                    TBL = TBL + ("<td class='rep_data' align='left'>");
                   
                    string client1 = "";
                    string rrr2 = ds.Tables[0].Rows[d]["Client"].ToString();
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
                    TBL = TBL + (client1 + "</td>");


                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                   
                   
                    string cli_place = "";
                    string rrrc = ds.Tables[0].Rows[d]["C_Place"].ToString();
                    if (rrrc.Length >= 15)
                    {
                        cli_place = rrrc.Substring(0, 15);
                        if (rrrc.Length - 15 < 15)
                            cli_place += "</br>" + rrrc.Substring(15, rrrc.Length - 15);
                        else
                            cli_place += "</br>" + rrrc.Substring(15, 15);
                    }
                    else
                        cli_place = rrrc;
                    TBL = TBL + (cli_place + "</td>");


                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                    string tem_ro = "";
                    string rrrc_ro = ds.Tables[0].Rows[d]["RoNo"].ToString();
                    if (rrrc_ro.Length >= 9)
                    {
                        tem_ro = rrrc_ro.Substring(0, 9);
                        if (rrrc_ro.Length - 9 < 9)
                            tem_ro += "</br>" + rrrc_ro.Substring(9, rrrc_ro.Length - 9);
                        else
                            tem_ro += "</br>" + rrrc_ro.Substring(9, 9);
                    }
                    else
                        tem_ro = rrrc_ro;
                    TBL = TBL + (tem_ro + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["RoDate"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["BillableArea"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                  
                  
                    string Package1 = "";
                    string rrr3 = ds.Tables[0].Rows[d]["Edition"].ToString();
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
                    TBL = TBL + (Package1 + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Hue"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["BillStatus"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                    
                   
                    
                    TBL = TBL + (ds.Tables[0].Rows[d]["PaymentType"].ToString() + "</td>");


                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["SpecialDisc"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["SpaceDisc"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
                  
                    TBL = TBL + (ds.Tables[0].Rows[d]["RevenueCenter"].ToString() + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    if (ds.Tables[0].Rows[d]["GrossAmt"].ToString() == "")
                    {
                        TBL = TBL + ("" + "</td>");
                    }
                    else
                    {
                        TBL = TBL + (ds.Tables[0].Rows[d]["GrossAmt"] + "</td>");
                        totalgross = totalgross + Convert.ToDouble(ds.Tables[0].Rows[d]["GrossAmt"]);
                    }

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Disc"] + "</td>");
                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Addlagcomm"] + "</td>");

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    if (ds.Tables[0].Rows[d]["BillAmt"].ToString() == "")
                    {
                        TBL = TBL + ("" + "</td>");
                    }
                    else
                    {
                        TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["BillAmt"].ToString()) + "</td>");
                        totalbill = totalbill + Convert.ToDouble(ds.Tables[0].Rows[d]["BillAmt"]);
                    }

                    TBL = TBL + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
                    if (ds.Tables[0].Rows[d]["Yield"].ToString() == "")
                    {
                        TBL = TBL + ("" + "</td>");
                    }
                    else
                    {
                        TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Yield"].ToString()) + "</td>");
                        totalyield = totalyield + Convert.ToDouble(ds.Tables[0].Rows[d]["Yield"]);
                    }
                    TBL += "</tr>";

                  
                    div1.InnerHtml += TBL;
                    TBL = "";

                    if (d == (ds.Tables[0].Rows.Count - 1))
                    {
                        TBL = TBL + ("<tr>");

                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (totalgross.ToString()) + "</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                        TBL = TBL + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (totalbill.ToString("F2")) + "</b></td>");
                        TBL = TBL + ("<td align='right'class='rep_datatotal_vouchdata'><b>" + (totalyield.ToString("F2")) + "</b></td>");

                        TBL = TBL + ("</tr>");
                    }


                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;
               

            }
            //if (browser.Browser == "Firefox")
            //{
            //    TBL = TBL + "</table></P>";

            //}
            //else if (browser.Browser == "IE")
            //{
            //    if ((ver == 8.0) || (ver == 7.0))
            //    {
            //        TBL = TBL + "</table></P>";

            //    }
            //    else if (ver == 6.0)
            //    {
            //        TBL = TBL + "</table>";

            //    }
            //}
           
            //TBL = TBL + "</tr>";
            //TBL += "</table>";

            div1.Visible = true;
            div1.InnerHtml += TBL;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }
    }
}
