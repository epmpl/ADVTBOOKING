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

public partial class printpageprem : System.Web.UI.Page
{
    int maxlimit = 17;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    string dateto = "", fromdt = "", destination = "";
   
    string adtype = "", client = "", adtypename = "", clientname1 = "",agency="",agencyname="",hold="";
   
    int a = 0;
    string day = "", month = "", year = "", date = "",agtype="",agtypetext="";
   
    double area = 0;
    double amt = 0;
    string publ = "", pubcen = "", pub2 = "", pubcname = "", edition = "", page = "", position = "", editionname = "", positioncode = "";
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet brk = new DataSet();
        brk.ReadXml(Server.MapPath("XML/pagebreak.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[11].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        if (Session["dateformat"] != null)
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Your session has been expired');window.close();</script>");
            return;
        }


        ds = (DataSet)Session["pageprem"];
        string prm = Session["prm_pageprem_print"].ToString();
        string[] prm_Array = new string[40];
        prm_Array = prm.Split('~');

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();


        dateto = prm_Array[1];// Request.QueryString["dateto"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        destination = prm_Array[5]; //Request.QueryString["destination"].ToString();
        publ = prm_Array[7]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[9]; //Request.QueryString["pubcenter"].ToString();
        pub2 = prm_Array[11]; //Request.QueryString["publiccent"].ToString();
        pubcname = prm_Array[13]; //Request.QueryString["publicname"].ToString();
        edition = prm_Array[15]; //Request.QueryString["edition"].ToString();
        page = prm_Array[17]; //Request.QueryString["page"].ToString();
        position = prm_Array[19]; //Request.QueryString["position"].ToString();
        editionname = prm_Array[21]; //Request.QueryString["editionname"].ToString();
        positioncode = prm_Array[23]; //Request.QueryString["positioncode"].ToString();
        adtype = prm_Array[25]; //Request.QueryString["adtype"].ToString();
        adtypename = prm_Array[27]; //Request.QueryString["adtypename"].ToString();
        client = prm_Array[29]; //Request.QueryString["client"].ToString();
        clientname1 = prm_Array[31]; //Request.QueryString["clientname"].ToString();
        agency = prm_Array[33]; //Request.QueryString["agency"].ToString();
        agencyname = prm_Array[35]; //Request.QueryString["agencyname"].ToString();
        agtype = prm_Array[37]; //Request.QueryString["agtype1"].ToString();
        agtypetext = prm_Array[39]; //Request.QueryString["agtypetext"].ToString();


       
        hold = "abc";
        if (agtype == "0")
        {
            lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = agtypetext.ToString();
        }

        if (adtype == "0")
        {
            lbladtype.Text = "ALL".ToString();
        }
        else
        {
            lbladtype.Text = adtypename.ToString();
        }

        if (page == "0")
        {
            lblpagepr.Text = "ALL".ToString();
        }
        else
        {
            lblpagepr.Text = page.ToString();
        }
        if (position == "0")
        {
            lblposition.Text = "ALL".ToString();
        }
        else
        {
            lblposition.Text = positioncode.ToString();
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
        if (edition == "0" || edition=="")
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
        lbldate.Text = date.ToString();
        lblfrom.Text = fromdt;
        lblto.Text = dateto;
        onscreen(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, adtype, agency, client);
        

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
    private void onscreen(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold, string adtype, string agency, string client)
    {

        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
       // DataSet ds = new DataSet();
       
       //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
       // {
       //     NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
       //     ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), agency, adtype, temp3, temp4, client, agtypetext);
       // }
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        string TBL = "";
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
          //  TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
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
            //       TBL = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
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
              //  TBL += "</table>";
             //   TBL += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                TBL += "<tr valign='top'>";
                TBL += "<td class='middle111' align='right' colspan='20'>" + "Page  " + s + "  of  " + pagecount;
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
                TBL += "<td class='middle31new' valign='top'>" + "S.No." + "</td>";

                TBL += "<td class='middle31new' align='left' valign='top'>" + "Booking" + "</br>" + "Id" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Edition" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Publish" + "</br>" + "date" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Agency" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Client" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Package" + "</td>";
                TBL += "<td class='middle31new' align='right' valign='top'>" + "Area&nbsp;&nbsp;" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Color" + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Page" + "</br>" + "Position" + "</td>";
                //premium
                TBL += "<td class='middle31new' width='1%'>Page</br>Prem</td><td class='middle31new' width='1%'>Post</br>Prem</td><td class='middle31new' width='2%'>Eye</br>Catc</td>";
               ////////
                TBL += "<td class='middle31new' valign='top' align='left'>" + "RoNo." + "</td>";
                TBL += "<td class='middle31new' align='left' valign='top'>" + "Ro." + "</br>" + "Status" + "</td>";
                TBL += "<td class='middle31new' valign='top' align='left'>" + "Adcat" + "</td>";
                TBL += "<td class='middle31new'  valign='top' align='left'>" + "Rate" + "</br>" + "Code" + "</td>";
                TBL += "<td class='middle31new' valign='top' align='right'>" + "Rate" + "</td>";
                TBL += "<td class='middle31new' align='right' valign='top'>" + "Amt" + "&nbsp;&nbsp;</td>";
                //caption
                TBL +="<td class='middle31new' width='2%' colspan='2' valign='top' align='left'>Caption</br>Key No</td>";
                ////////
                TBL += "</tr>";

                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {

                    a = d;
                    a = a + 1;
                   TBL += "<tr>";
                    TBL = TBL + ("<td class='rep_data' valign='top' >");
                    TBL = TBL + (a.ToString() + "</td>");
                   

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");

                    
                    //string cioid1 = "";
                    //string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                    //char[] cioid = rrr.ToCharArray();
                    //int len11 = cioid.Length;

                    //int ch_end = 0;
                    //int ch_str = 0;
                    //for (int ch = 0; ch < len11; ch++)
                    //{
                    //    /**/
                    //    ch_end = ch_end + 9;
                    //    ch_str = ch_end;
                    //    if (ch_end > len11)
                    //        ch_str = len11 - ch;
                    //    else
                    //        ch_str = ch_end - ch;

                    //    cioid1 = cioid1 + rrr.Substring(ch, ch_str).Trim();
                    //    cioid1 = cioid1 + "</br>";
                    //    ch = ch + 9;
                    //    if (ch > len11)
                    //        ch = len11;
                    //}

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

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["edition"] + "</td>");


                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                        TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
                       
                       
                        //string agency1 = "";
                        //string chkr = ds.Tables[0].Rows[d]["Agency"].ToString();
                        //char[] agencyj = chkr.ToCharArray();
                        //int len111 = agencyj.Length;
                        //int line11 = 0;
                        //int ch_end1 = 0;
                        //int ch_str1 = 0;
                        //for (int ch1 = 0; ((ch1 < len111) && (line11 < 2)); ch1++)
                        //{
                        //    /**/
                        //    ch_end1 = ch_end1 + 16;
                        //    ch_str1 = ch_end1;
                        //    if (ch_end1 > len111)
                        //        ch_str1 = len111 - ch1;
                        //    else
                        //        ch_str1 = ch_end1 - ch1;

                        //    agency1 = agency1 + chkr.Substring(ch1, ch_str1).Trim();
                        //    agency1 = agency1 + "</br>";
                        //    ch1 = ch1 + 16;
                        //    if (ch1 > len111)
                        //        ch1 = len111;/**/
                        //}
                        string agency1 = "";
                        string rrr1 = ds.Tables[0].Rows[d]["Agency"].ToString();
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
                        TBL = TBL + (agency1 + "</td>");
                    



                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
                   
                    //string client1 = "";
                    //string der = ds.Tables[0].Rows[d]["Client"].ToString();
                    //char[] clientd = der.ToCharArray();
                    //int len1111 = clientd.Length;
                    //int line = 0;
                    //int ch_end11 = 0;
                    //int ch_str11 = 0;
                    //for (int ch11 = 0; ((ch11 < len1111) && (line < 2)); ch11++)
                    //{
                    //    /* */
                    //    ch_end11 = ch_end11 + 16;
                    //    ch_str11 = ch_end11;
                    //    if (ch_end11 > len1111)
                    //        ch_str11 = len1111 - ch11;
                    //    else
                    //        ch_str11 = ch_end11 - ch11;

                    //    client1 = client1 + der.Substring(ch11, ch_str11).Trim();
                    //    client1 = client1 + "</br>";
                    //    ch11 = ch11 + 16;
                    //    if (ch11 > len1111)
                    //        ch11 = len1111;
                    //}
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

                  
                    //string Package1 = "";
                    //string rrr111111 = ds.Tables[0].Rows[d]["Package"].ToString();
                    //char[] Package = rrr111111.ToCharArray();
                    //int len11111111 = Package.Length;
                    //int line1111111 = 0;
                    //int ch_end111 = 0;
                    //int ch_str111 = 0;
                    //for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
                    //{
                    //    /**/
                    //    ch_end111 = ch_end111 + 8;
                    //    ch_str111 = ch_end111;
                    //    if (ch_end111 > len11111111)
                    //        ch_str111 = len11111111 - ch111111;
                    //    else
                    //        ch_str111 = ch_end111 - ch111111;

                    //    Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
                    //    Package1 = Package1 + "</br>";
                    //    ch111111 = ch111111 + 8;
                    //    if (ch111111 > len11111111)
                    //        ch111111 = len11111111;
                    //}
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
                    //----------------------------------------------------------------///
                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    TBL = TBL + (Package1 + "</td>");


                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='right'  valign='top'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Area"].ToString()) + "</td>");
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
                        
                    //string Pkg11 = "";
                    //string re1 = ds.Tables[0].Rows[d]["Hue"].ToString();
                    //char[] rt1 = re1.ToCharArray();
                    //int ledw = rt1.Length;
                    //int lkiu = 0;
                    //int ch_endp = 0;
                    //int ch_strp = 0;
                    //for (int ch1 = 0; ((ch1 < ledw) && (lkiu < 2)); ch1++)
                    //{
                    //    /**/
                    //    ch_endp = ch_endp + 9;
                    //    ch_strp = ch_endp;
                    //    if (ch_endp > ledw)
                    //        ch_strp = ledw - ch1;
                    //    else
                    //        ch_strp = ch_endp - ch1;

                    //    Pkg11 = Pkg11 + re1.Substring(ch1, ch_strp).Trim();
                    //    Pkg11 = Pkg11 + "</br>";
                    //    ch1 = ch1 + 9;
                    //    if (ch1 > ledw)
                    //        ch1 = ledw;/**/
                    //}
                    string hue_col = "";
                    string rrrt = ds.Tables[0].Rows[d]["Hue"].ToString();
                    if (rrrt.Length >= 9)
                    {
                        hue_col = rrrt.Substring(0, 9);
                        if (rrrt.Length - 9 < 9)
                            hue_col += "</br>" + rrrt.Substring(9, rrrt.Length - 9);
                        else
                            hue_col += "</br>" + rrrt.Substring(9, 9);
                    }
                    else
                        hue_col = rrrt;
                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'>");
                    TBL = TBL + (hue_col + "</td>");

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'  valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Page"] + "</td>");

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data'  width='1%'>");
                    if (ds.Tables[0].Rows[d]["priname"].ToString() == "0")
                    {
                        TBL = TBL + "" + "</td>";
                    }
                    else
                    {
                        TBL = TBL + (ds.Tables[0].Rows[d]["priname"] + "</td>");
                    }
                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'  width='1%'>");
                    if (ds.Tables[0].Rows[d]["PositionPremium"].ToString() == "0")
                    {
                        TBL = TBL + "" + "</td>";
                    }
                    else
                    {
                        TBL = TBL + (ds.Tables[0].Rows[d]["PositionPremium"] + "</td>");
                    }

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'  width='1%'>");
                    if (ds.Tables[0].Rows[d]["BulletPremium"].ToString() == "0")
                    {
                        TBL = TBL + "" + "</td>";
                    }
                    else
                    {
                        TBL = TBL + (ds.Tables[0].Rows[d]["BulletPremium"] + "</td>");
                    }

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["RoNo."] + "</td>");

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

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' valign='top' align='left'>");
                    TBL = TBL + (RoStatus1 + "</td>");

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' valign='top' align='left'>");
                    
                   
                    //string AdCat1 = "";
                    //string rrrnew1 = ds.Tables[0].Rows[d]["AdCat"].ToString();
                    //char[] AdCat = rrrnew1.ToCharArray();
                    //int lennew1 = AdCat.Length;
                    //int linenew1 = 0;
                    //int ch_end1111 = 0;
                    //int ch_str1111 = 0;
                    //for (int chnew1 = 0; ((chnew1 < lennew1) && (linenew1 < 2)); chnew1++)
                    //{

                       
                    //    ch_end1111 = ch_end1111 + 9;
                    //    ch_str1111 = ch_end1111;
                    //    if (ch_end1111 > lennew1)
                    //        ch_str1111 = lennew1 - chnew1;
                    //    else
                    //        ch_str1111 = ch_end1111 - chnew1;

                    //    AdCat1 = AdCat1 + rrrnew1.Substring(chnew1, ch_str1111).Trim();
                    //    AdCat1 = AdCat1 + "</br>";
                    //    chnew1 = chnew1 + 9;
                    //    if (chnew1 > lennew1)
                    //        chnew1 = lennew1;
                    //}
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
                    TBL = TBL + (AdCat1 + "</td>");

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
                    //string ratecode1 = "";
                    //string w2 = ds.Tables[0].Rows[d]["RateCode"].ToString();
                    //char[] ratecode = w2.ToCharArray();
                    //int les1 = ratecode.Length;
                    //int ls1 = 0;
                   
                    //int ch_endls1 = 0;
                    //int ch_strls1 = 0;
                    //for (int chnew1 = 0; ((chnew1 < les1) && (ls1 < 2)); chnew1++)
                    //{

                    //    /**/
                    //    ch_endls1 = ch_endls1 + 9;
                    //    ch_strls1 = ch_endls1;
                    //    if (ch_endls1 > les1)
                    //        ch_strls1 = les1 - chnew1;
                    //    else
                    //        ch_strls1 = ch_endls1 - chnew1;

                    //    ratecode1 = ratecode1 + w2.Substring(chnew1, ch_strls1).Trim();
                    //    ratecode1 = ratecode1 + "</br>";
                    //    chnew1 = chnew1 + 9;
                    //    if (chnew1 > lennew1)
                    //        chnew1 = lennew1;
                    //}

                    string ratecode1 = "";
                    string rrrq = ds.Tables[0].Rows[d]["RateCode"].ToString();
                    if (rrrq.Length >= 9)
                    {
                        ratecode1 = rrrq.Substring(0, 9);
                        if (rrrq.Length - 9 < 9)
                            ratecode1 += "</br>" + rrrq.Substring(9, rrrq.Length - 9);
                        else
                            ratecode1 += "</br>" + rrrq.Substring(9, 9);
                    }
                    else
                        ratecode1 = rrrq;
                    TBL = TBL + (ratecode1 + "</td>");

                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='right' valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");

                  
                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' align='right' valign='top'>");
                    TBL = TBL + (chk_null(ds.Tables[0].Rows[d]["Amt"].ToString()) + "</td>");
                    if (ds.Tables[0].Rows[d]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());


                    TBL = TBL + ("<td  style=\"padding-left:4px\"  class='rep_data' colspan='2' align='left'  valign='top'>");
                    TBL = TBL + (ds.Tables[0].Rows[d]["Cap"] +"<br>");

                   
                    TBL = TBL + (ds.Tables[0].Rows[d]["Key"] + "</td>");
                   
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


            TBL = TBL + ("<tr>");
            TBL = TBL + ("<td class='middle1212' colspan='3' align='left'><b>Total Ads.</b> ");
            TBL = TBL + (a.ToString() + "</td>");
            TBL = TBL + ("<td colspan='2' class='middle1212'>&nbsp;</td>");
           // TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
          
            //TBL = TBL + ("<td class='middle1212'><b>Total:</b></td>");

            TBL = TBL + ("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            TBL = TBL + (chk_null(cal.ToString()) + "</td>");

            if (totrol > 0)
            {
                TBL = TBL + ("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                TBL = TBL + (calf.ToString() + "</td>");
            }
            else
            {
                TBL = TBL + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                TBL = TBL + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>");
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                TBL = TBL + (calfd.ToString() + "</td>");
            }
            else
            {
                TBL = TBL + ("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                TBL = TBL + ("<td class='middle1212' colspan='2' align='right'><b>Total Words:</b>");
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                TBL = TBL + (calft.ToString() + "</td>");
            }
            else
            {
                TBL = TBL + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
            }
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");

            //TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
            TBL = TBL + ("<td class='middle1212' colspan='2' align='right'><b>Total amt:</b></td>");
           
			


            
           
            TBL = TBL + ("<td class='middle1212' align='right'  >");
            double cal1 = System.Math.Round(Convert.ToDouble(amt), 2);
            TBL = TBL + (chk_null(cal1.ToString()) + "</td>");
			TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");
			TBL = TBL + ("<td class='middle1212'>&nbsp;</td>");

            TBL = TBL + "</tr>";
           // TBL += "</table>";
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
            div1.Visible = true;
           // div1.InnerHtml = TBL;
            div1.InnerHtml += TBL;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        }

        

    }
}
