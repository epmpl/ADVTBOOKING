using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;

using iTextSharp.text.pdf;
using System.Drawing.Printing;
//using System.Diagnostics.Design;
using System.Diagnostics;
using iTextSharp.text.pdf.wmf;
using System.Data.OracleClient;
using System.Web.UI.WebControls;

public partial class categorywiseview : System.Web.UI.Page
{
    int sno = 1;
    double amtnew = 0;
    double amtnew1 = 0;
    double amtnew13 = 0;
    double amtsum = 0;
    double billamtsum = 0;
    double yieldamtsum = 0;

    string page="",fromdate="",dateto="",publication="",pubcent="",region="",destination="", adtype="";
    string executive="",city="",chk="",  pagename="", pubname="", pubcentname="", regionname="", adtypename="";
    string exename = "", cityname = "", agcatname = "", agcat = "";
    string day = "", month = "", year = "", date = "",todate="",fromdt="";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
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
       
        ds = (DataSet)Session["catreport"];
        string prm = Session["prm_catreport"].ToString();
        string[] prm_Array = new string[41];
        prm_Array = prm.Split('~');


        DataSet dsx = new DataSet();
        dsx.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = dsx.Tables[0].Rows[0].ItemArray[87].ToString();

        page = prm_Array[1];// Request.QueryString["page"].ToString();
        fromdate = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        publication = prm_Array[7]; //Request.QueryString["publication"].ToString();
        pubcent = prm_Array[9]; //Request.QueryString["pubcenter"].ToString();
        region = prm_Array[11]; //Request.QueryString["region"].ToString();
        destination = prm_Array[13]; //Request.QueryString["destination"].ToString();
        adtype = prm_Array[15]; //Request.QueryString["adtype"].ToString();
        executive = prm_Array[17]; //Request.QueryString["rep"].ToString();
        city = prm_Array[19]; //Request.QueryString["place"].ToString();
        chk = prm_Array[21]; //Request.QueryString["grp"].ToString();
        pagename = prm_Array[23]; //Request.QueryString["pagetext"].ToString();
        pubname = prm_Array[25]; //Request.QueryString["publicname"].ToString();
        pubcentname = prm_Array[27]; //Request.QueryString["publiccent"].ToString();
        regionname = prm_Array[29]; //Request.QueryString["regiontext"].ToString();
        adtypename = prm_Array[31]; //Request.QueryString["adtypetext"].ToString();
        exename = prm_Array[33]; //Request.QueryString["reptext"].ToString();
        cityname = prm_Array[35]; //Request.QueryString["placetext"].ToString();
        agcatname = prm_Array[37]; //Request.QueryString["agcatname"].ToString();
        agcat = prm_Array[39]; //Request.QueryString["agcat"].ToString();
        chk_excel = prm_Array[41];

        if (page == "0")
        {lblpage.Text = "ALL".ToString();}
        else
        { lblpage.Text = pagename.ToString(); }

        if (pubcent == "0")
        { lblpubcent.Text = "ALL".ToString(); }
        else
        { lblpubcent.Text = pubcentname.ToString(); }

        if (publication == "0")
        { lblpub.Text = "ALL".ToString();}
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
        if (!Page.IsPostBack)
        {
            if (destination == "1" || destination == "0")
            {
                onscreen(fromdate, dateto, region, pubcent, page, Session["compcode"].ToString(), Session["dateformat"].ToString(), publication, adtype, executive, city, agcat);
            }
            else if (destination == "4")
            {
                excel(fromdate, dateto, region, pubcent, page, Session["compcode"].ToString(), Session["dateformat"].ToString(), publication, adtype, executive, city, agcat);

            }
            else if (destination == "3")
            {
                pdf(fromdate, dateto, region, pubcent, page, Session["compcode"].ToString(), Session["dateformat"].ToString(), publication, adtype, executive, city, agcat);
            }
        }
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
        int cont = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' valign='top'>";
       // tbl = tbl + "<tr valign='top'><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='5px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td><td class='middle4' width='4px' valign='top'>&nbsp;</td></tr>";

        tbl = tbl + ("<tr valign='top'><td class='rep_datatotal_vouchdata' valign='top'>S.No.</td><td class='rep_datatotal_vouchdata' valign='top'  align='left'>Booking</br>Id</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Agency</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Agency</br>Add.</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Client</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Client</br>Add.</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>RoNo</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>RoDate</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Area</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Edition</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Color</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Bill</br>Status</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Pay</br>Type</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Spl</br>Disc.</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Space</br>Disc.</td><td class='rep_datatotal_vouchdata' valign='top' align='left'>Revenue</br>Center</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Rate</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Gross</br>Amt</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Agency</br>TD</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Addl</br>TD</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Bill</br>Amt</td><td class='rep_datatotal_vouchdata' valign='top' align='right'>Yield</td>");

        int i1 = 1;
        double totalgross = 0;
        double totalbill = 0;
        double totalyield = 0;
        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");

            //string cid = "";
            //string rrr1 = ds.Tables[0].Rows[i]["CIOID"].ToString();
            //char[] cid1 = rrr1.ToCharArray();
            //int len111 = cid1.Length;
            //int ch_end = 0;
            //int ch_str = 0;
            //for (int ch = 0; ch < len111; ch++)
            //{
            //    /**/
            //    ch_end = ch_end + 9;
            //    ch_str = ch_end;
            //    if (ch_end > len111)
            //        ch_str = len111 - ch;
            //    else
            //        ch_str = ch_end - ch;

            //    cid = cid + rrr1.Substring(ch, ch_str).Trim();
            //    cid = cid + "</br>";
            //    ch = ch + 9;
            //    if (ch > len111)
            //        ch = len111;
            //}
            string cioid1 = "";
            string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
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
            tbl = tbl + (cioid1 + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");

            //string agency1 = "";
            //string rrr2 = ds.Tables[0].Rows[i]["Agency"].ToString();
            //char[] agency = rrr2.ToCharArray();
            //int len222 = agency.Length;
            //int line22 = 0;
            //int ch_end1 = 0;
            //int ch_str1 = 0;
            //for (int ch1 = 0; ((ch1 < len222) && (line22 < 2)); ch1++)
            //{
            //    /**/
            //    ch_end1 = ch_end1 + 16;
            //    ch_str1 = ch_end1;
            //    if (ch_end1 > len222)
            //        ch_str1 = len222 - ch1;
            //    else
            //        ch_str1 = ch_end1 - ch1;

            //    agency1 = agency1 + rrr2.Substring(ch1, ch_str1).Trim();
            //    agency1 = agency1 + "</br>";
            //    ch1 = ch1 + 16;
            //    if (ch1 > len222)
            //        ch1 = len222;/**/
            //}
            string agency1 = "";
            string rrr1 = ds.Tables[0].Rows[i]["Agency"].ToString();
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
            tbl = tbl + (agency1 + "</td>");



            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");

            //string A_Place1 = "";
            //string rrr111 = ds.Tables[0].Rows[i]["A_Place"].ToString();
            //char[] A_Place = rrr111.ToCharArray();
            //int len11111 = A_Place.Length;
            //int line1111 = 0;
            //int ch_endp = 0;
            //int ch_strp = 0;
            //for (int ch1 = 0; ((ch1 < len11111) && (line1111 < 2)); ch1++)
            //{
            //    /**/
            //    ch_endp = ch_endp + 40;
            //    ch_strp = ch_endp;
            //    if (ch_endp > len11111)
            //        ch_strp = len11111 - ch1;
            //    else
            //        ch_strp = ch_endp - ch1;

            //    A_Place1 = A_Place1 + rrr111.Substring(ch1, ch_strp).Trim();
            //    A_Place1 = A_Place1 + "</br>";
            //    ch1 = ch1 + 40;
            //    if (ch1 > len11111)
            //        ch1 = len11111;/**/
            //}
            string ag_place = "";
            string rrra = ds.Tables[0].Rows[i]["A_Place"].ToString();
            if (rrra.Length >= 40)
            {
                ag_place = rrra.Substring(0, 40);
                if (rrra.Length - 40 < 40)
                    ag_place += "</br>" + rrra.Substring(40, rrra.Length - 40);
                else
                    ag_place += "</br>" + rrra.Substring(40, 40);
            }
            else
                ag_place = rrra;
            tbl = tbl + (ag_place + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");

            //string client1 = "";
            //string rrr11 = ds.Tables[0].Rows[i]["Client"].ToString();
            //char[] client = rrr11.ToCharArray();
            //int len1111 = client.Length;
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

            //    client1 = client1 + rrr11.Substring(ch11, ch_str11).Trim();
            //    client1 = client1 + "</br>";
            //    ch11 = ch11 + 16;
            //    if (ch11 > len1111)
            //        ch11 = len1111;
            //}
            string client1 = "";
            string rrr2 = ds.Tables[0].Rows[i]["Client"].ToString();
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
            tbl = tbl + (client1 + "</td>");


            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");

            //string Package1 = "";
            //string rrr111111 = ds.Tables[0].Rows[i]["C_Place"].ToString();
            //char[] Package = rrr111111.ToCharArray();
            //int len11111111 = Package.Length;
            //int line1111111 = 0;
            //int ch_end111 = 0;
            //int ch_str111 = 0;
            //for (int ch111111 = 0; ((ch111111 < len11111111) && (line1111111 < 2)); ch111111++)
            //{
            //    /**/
            //    ch_end111 = ch_end111 + 15;
            //    ch_str111 = ch_end111;
            //    if (ch_end111 > len11111111)
            //        ch_str111 = len11111111 - ch111111;
            //    else
            //        ch_str111 = ch_end111 - ch111111;

            //    Package1 = Package1 + rrr111111.Substring(ch111111, ch_str111).Trim();
            //    Package1 = Package1 + "</br>";
            //    ch111111 = ch111111 + 15;
            //    if (ch111111 > len11111111)
            //        ch111111 = len11111111;
            //}
            string cli_place = "";
            string rrrc = ds.Tables[0].Rows[i]["C_Place"].ToString();
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
            tbl = tbl + (cli_place + "</td>");


            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoDate"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillableArea"].ToString()) + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");


            //string RoStatus1 = "";
            //string rrrnew11 = ds.Tables[0].Rows[i]["Edition"].ToString();
            //char[] RoStatus = rrrnew11.ToCharArray();
            //int lennew11 = RoStatus.Length;
            //int linenew11 = 0;
            //int ch_end11111 = 0;
            //int ch_str11111 = 0;
            //for (int chnew11 = 0; ((chnew11 < lennew11) && (linenew11 < 2)); chnew11++)
            //{

            //    /**/
            //    ch_end11111 = ch_end11111 + 9;
            //    ch_str11111 = ch_end11111;
            //    if (ch_end11111 > lennew11)
            //        ch_str11111 = lennew11 - chnew11;
            //    else
            //        ch_str11111 = ch_end11111 - chnew11;
            //    RoStatus1 = RoStatus1 + rrrnew11.Substring(chnew11, ch_str11111).Trim();
            //    RoStatus1 = RoStatus1 + "</br>";
            //    chnew11 = chnew11 + 9;
            //    if (chnew11 > lennew11)
            //        chnew11 = lennew11;/**/

            //}
            string Package1 = "";
            string rrr3 = ds.Tables[0].Rows[i]["Edition"].ToString();
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
            tbl = tbl + (Package1 + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Hue"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["BillStatus"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
            //string paytype1 = "";
            //string chk3 = ds.Tables[0].Rows[i]["PaymentType"].ToString();
            //char[] paytype = chk3.ToCharArray();
            //int lenchk2 = paytype.Length;
            //int linechk2 = 0;
            //int ch_end4 = 0;
            //int ch_str4 = 0;
            //for (int chnew11 = 0; ((chnew11 < lenchk2) && (linechk2 < 2)); chnew11++)
            //{

            //    /**/
            //    ch_end4 = ch_end4 + 9;
            //    ch_str4 = ch_end4;
            //    if (ch_end4 > lenchk2)
            //        ch_str4 = lenchk2 - chnew11;
            //    else
            //        ch_str4 = ch_end4 - chnew11;
            //    paytype1 = paytype1 + chk3.Substring(chnew11, ch_str4).Trim();
            //    paytype1 = paytype1 + "</br>";
            //    chnew11 = chnew11 + 9;
            //    if (chnew11 > lenchk2)
            //        chnew11 = lenchk2;/**/

            //}
            string pay_type = "";
            string rrre = ds.Tables[0].Rows[i]["PaymentType"].ToString();
            if (rrre.Length >= 9)
            {
                pay_type = rrre.Substring(0, 9);
                if (rrre.Length - 9 < 9)
                    pay_type += "</br>" + rrre.Substring(9, rrre.Length - 9);
                else
                    pay_type += "</br>" + rrre.Substring(9, 9);
            }
            else
                pay_type = rrre;
          //  tbl = tbl + (pay_type + "</td>");
            tbl = tbl + (ds.Tables[0].Rows[i]["PaymentType"].ToString() + "</td>");
             
            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["SpecialDisc"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["SpaceDisc"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='left'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RevenueCenter"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["AgreedRate"].ToString()) + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            if (ds.Tables[0].Rows[i]["GrossAmt"].ToString() == "")
            {
                tbl = tbl + ("" + "</td>");
            }
            else
            {
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["GrossAmt"].ToString()) + "</td>");

                totalgross = totalgross + Convert.ToDouble(ds.Tables[0].Rows[i]["GrossAmt"]);
            }

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Disc"] + "</td>");
            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Addlagcomm"] + "</td>");

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            if (ds.Tables[0].Rows[i]["BillAmt"].ToString() == "")
            {
                tbl = tbl + ("" + "</td>");
            }
            else
            {
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["BillAmt"].ToString()) + "</td>");
                totalbill = totalbill + Convert.ToDouble(ds.Tables[0].Rows[i]["BillAmt"]);
            }

            tbl = tbl + ("<td style=\"padding-left:4px\"   class='rep_data' align='right'>");
            if (ds.Tables[0].Rows[i]["Yield"].ToString() == "")
            {
                tbl = tbl + ("" + "</td>");
            }
            else
            {
                tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["Yield"].ToString()) + "</td>");
                totalyield = totalyield + Convert.ToDouble(ds.Tables[0].Rows[i]["Yield"]);
            }
            tbl += "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";

            if (i == (cont - 1))
            {
                tbl = tbl + ("<tr>");
             
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>Total:</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>" + (totalgross.ToString()) + "</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td  align='right'class='rep_datatotal_vouchdata'><b>&nbsp;</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (totalbill.ToString("F2")) + "</b></td>");
                tbl = tbl + ("<td  colspan='0'align='right'class='rep_datatotal_vouchdata'><b>" + (totalyield.ToString("F2")) + "</b></td>");
                
                tbl = tbl + ("</tr>");
            }


        }

      
        tbl = tbl + "</tr>";
        tbl = tbl + ("</table>");
        //tblgrid.InnerHtml = tbl;
        tblgrid.InnerHtml += tbl;
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_catreport_print"]="dateto~" + dateto + "~fromdate~" + fromdate + "~destination~" + destination + "~region~" + region + "~regiontext~" + regionname + "~grp~" + chk + "~page~" + page + "~publication~" + publication + "~pubcenter~" + pubcent + "~adtype~" + adtype + "~rep~" + executive + "~place~" + city + "~agcat~" + agcat + "~pagetext~" + pagename + "~publicname~" + pubname + "~publiccent~" + pubcentname + "~adtypetext~" + adtypename + "~reptext~" + exename + "~placetext~" + cityname + "~agcatname~" + agcatname ;
        Response.Redirect("printcategoryreport.aspx");
//        Response.Redirect("printcategoryreport.aspx?dateto=" + dateto + "&fromdate=" + fromdate + "&destination=" + destination +"&region=" + region + "&regiontext=" + regionname + "&grp=" + chk + "&page=" + page + "&publication=" + publication + "&pubcenter=" + pubcent +"&adtype=" + adtype + "&rep=" + executive + "&place=" + city + "&agcat=" + agcat + "&pagetext=" + pagename + "&publicname=" + pubname + "&publiccent=" + pubcentname + "&adtypetext=" + adtypename + "&reptext=" + exename +"&placetext=" + cityname +"&agcatname=" + agcatname + "");


    }
    private void pdf(string datefrom, string dateto, string region, string pubcent, string page, string compcode, string dateformate, string publname, string adtyp, string execode, string city, string agencycat)
    {
      
        DataSet pdfxml = new DataSet();
        double totalgross = 0;
        double totalbill = 0;
        double totalyield = 0;
        pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter writer = PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
         HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();
        int NumColumns = 22;
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 17, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 11, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 8);

        try
        {
            string temp1 = "", temp2 = "";
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
            //    ds = obj.categoryreport(datefrom, dateto, adtyp, publname, pubcent, execode, region, city, chk, page, compcode, dateformate, temp1, temp2, agencycat);
            //}
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);
            tbl.DefaultCell.Border = Rectangle.LEFT | Rectangle.RIGHT;
            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[87].ToString(), font9));
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            document.Add(tbl);
            PdfPTable tbl1 = new PdfPTable(1);
            tbl1.DefaultCell.BorderWidth = 0;
            tbl1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl1.addCell("");
            tbl1.WidthPercentage = 100;
            int i;
            for (i = 0; i < 2; i++)
            {
                document.Add(tbl1);
            }

            PdfPTable tbl2 = new PdfPTable(8);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(fromdate.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.addCell(new Phrase("Executive", font10));
            tbl2.addCell(new Phrase(lblexecutive.Text, font11));
            
            tbl2.addCell(new Phrase("Publication", font10));
            tbl2.addCell(new Phrase(lblpub.Text, font11));
            tbl2.addCell(new Phrase("Pub Center", font10));
            tbl2.addCell(new Phrase(lblpubcent.Text, font11));
            tbl2.addCell(new Phrase("Ad type", font10));
            tbl2.addCell(new Phrase(lbladtype.Text, font11));
            tbl2.addCell(new Phrase("Page", font10));
            tbl2.addCell(new Phrase(lblpage.Text, font11));

            tbl2.addCell(new Phrase("Region", font10));
            tbl2.addCell(new Phrase(lblregion.Text, font11));
            tbl2.addCell(new Phrase("City ", font10));
            tbl2.addCell(new Phrase(lblcity.Text, font11));
            
            tbl2.addCell(new Phrase("Agency Category", font10));
            tbl2.addCell(new Phrase(lblagcat.Text, font11));
            tbl2.addCell(new Phrase("", font10));
            tbl2.addCell(new Phrase("", font11));


            tbl2.WidthPercentage = 100;
            document.Add(tbl2);


            //-------------------------------table for header-------------------------------------------------------
            PdfPTable datatable = new PdfPTable(NumColumns);
            datatable.DefaultCell.Padding = 3;
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.Colspan = 22;
            datatable.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[86].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[88].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
           datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[89].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[39].ToString() , font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[0].ToString() , font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[9].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[10].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[2].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[83].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[90].ToString(), font10));
            datatable.addCell(new Phrase("Addl.TD", font10));
            
            datatable.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[4].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[84].ToString(), font10));
            
            //datatable.HeaderRows = 1;

            //Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());
            //document.Add(p2);
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            datatable.DefaultCell.Colspan = 22;
            datatable.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font10));
            datatable.DefaultCell.Colspan = 1;
            int row = 0;
            int i1 = 1;
            while (row < ds.Tables[0].Rows.Count)
            {
               datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["A_Place"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["C_Place"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoDate"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillableArea"].ToString()), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Edition"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BillStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PaymentType"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SpecialDisc"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["SpaceDisc"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RevenueCenter"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["AgreedRate"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["GrossAmt"].ToString() == "")
                {
                    datatable.addCell(new Phrase("", font11));
                }
                else
                {
                    datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["GrossAmt"].ToString()), font11));
                    totalgross = totalgross + Convert.ToDouble(ds.Tables[0].Rows[row]["GrossAmt"]);
                }
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Disc"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Addlagcomm"].ToString(), font11));
                if (ds.Tables[0].Rows[row]["BillAmt"].ToString() == "")
                {
                    datatable.addCell(new Phrase("", font11));
                }
                else
                {
                    datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["BillAmt"].ToString()), font11));
                    totalbill = totalbill + Convert.ToDouble(ds.Tables[0].Rows[row]["BillAmt"]);
                }
                if (ds.Tables[0].Rows[row]["Yield"].ToString() == "")
                {
                    datatable.addCell(new Phrase("", font11));
                }
                else
                {
                    datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["Yield"].ToString()), font11));
                    totalyield = totalyield + Convert.ToDouble(ds.Tables[0].Rows[row]["Yield"]);
                }
                
                row++;

            }

            document.Add(datatable);

           // Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[54].ToString(), font10));
           // document.Add(p3);

            //PdfPTable tbltotal = new PdfPTable(13);
            //float[] headerwidths = { 11, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16 }; // percentage
            //tbltotal.setWidths(headerwidths);
            //tbltotal.DefaultCell.BorderWidth = 0;
            //tbltotal.WidthPercentage = 100;
            //tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            //tbltotal.addCell(new Phrase((i1 - 1).ToString(), font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[68].ToString() + count1.ToString(), font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[69].ToString() + count2.ToString(), font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[16].ToString(), font10));

            //tbltotal.addCell(new Phrase(BillAmt.ToString(), font11));
            //tbltotal.addCell(new Phrase(agencomm.ToString(), font11));
            // document.Add(tbltotal);



            PdfPTable tbltotal = new PdfPTable(22);
            float[] bbbb = { 15, 13, 14, 14, 10, 8, 12, 10, 1, 10, 10, 10, 16, 11, 11, 11, 15, 25, 6, 3, 25, 20 }; // percentage
            tbltotal.setWidths(bbbb);
            tbltotal.DefaultCell.BorderWidth = 0;
            tbltotal.WidthPercentage = 100;
            //tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbltotal.DefaultCell.Colspan = 22;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font10));
            tbltotal.DefaultCell.Colspan = 1;
            //tbltotal.DefaultCell.VerticalAlignment = Element.ALIGN_LEFT;
            tbltotal.addCell(new Phrase("TOTAL", font10));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            tbltotal.addCell(new Phrase(totalgross.ToString(), font10));
            tbltotal.addCell(new Phrase(" ", font10));
            tbltotal.addCell(new Phrase(" ", font10));
            tbltotal.addCell(new Phrase(totalbill.ToString("F2"), font10));
            tbltotal.addCell(new Phrase(totalyield.ToString("F2"), font10));
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            tbltotal.DefaultCell.Colspan = 22;
            tbltotal.addCell(new Phrase("_____________________________________________________________________________________________________________________________________________", font10));
            document.Add(tbltotal);


            document.Close();
            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }


    }
    private void excel(string datefrom, string dateto, string region, string pubcent, string page, string compcode, string dateformate, string publname, string adtyp, string execode, string city, string agencycat)
    {
              string temp1 = "", temp2 = "";

                //DataSet ds = new DataSet();
                //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                //{
                //    NewAdbooking.Report.classesoracle.billregister obj = new NewAdbooking.Report.classesoracle.billregister();
                //    ds = obj.categoryreport(datefrom, dateto, adtyp, publname, pubcent, execode, region, city, chk, page, compcode, dateformate, temp1, temp2, agencycat);
                //}
                
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";

                Response.ContentType = "text/csv";
                if (chk_excel == "1")
                {
                    Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
                }
                else
                {
                    Response.AppendHeader("content-disposition", "attachment; filename=Ex.csv");
                }

                BoundColumn nameColumn0 = new BoundColumn();
                nameColumn0.HeaderText = "S.No";
                DataGrid1.Columns.Add(nameColumn0);



                BoundColumn nameColumn = new BoundColumn();
                nameColumn.HeaderText = "Booking Id";
                nameColumn.DataField = "CIOID";

                name1 = name1 + "," + "Booking Id";
                name2 = name2 + "," + "CIOID";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn);

                BoundColumn nameColumn1 = new BoundColumn();
                nameColumn1.HeaderText = "Agency";
                nameColumn1.DataField = "Agency";

                name1 = name1 + "," + "Agency";
                name2 = name2 + "," + "Agency";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn1);

                BoundColumn nameColumn2 = new BoundColumn();
                nameColumn2.HeaderText = "Agency Address";
                nameColumn2.DataField = "A_Place";

                name1 = name1 + "," + "Agency Address";
                name2 = name2 + "," + "A_Place";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn2);

                BoundColumn nameColumn4 = new BoundColumn();
                nameColumn4.HeaderText = "Client";
                nameColumn4.DataField = "Client";

                name1 = name1 + "," + "Client";
                name2 = name2 + "," + "Client";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn4);


                BoundColumn nameColumn5 = new BoundColumn();
                nameColumn5.HeaderText = "Client Address";
                nameColumn5.DataField = "C_Place";

                name1 = name1 + "," + "Client Address";
                name2 = name2 + "," + "C_Place";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn5);

                BoundColumn nameColumn6 = new BoundColumn();
                nameColumn6.HeaderText = "RoNo";
                nameColumn6.DataField = "RoNo";

                name1 = name1 + "," + "RoNo";
                name2 = name2 + "," + "RoNo";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn6);

                BoundColumn nameColumn7 = new BoundColumn();
                nameColumn7.HeaderText = "RoDate";
                nameColumn7.DataField = "RoDate";

                name1 = name1 + "," + "RoDate";
                name2 = name2 + "," + "RoDate";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn7);

                BoundColumn nameColumn8 = new BoundColumn();
                nameColumn8.HeaderText = "Area";
                nameColumn8.DataField = "BillableArea";

                name1 = name1 + "," + "Area";
                name2 = name2 + "," + "BillableArea";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn8);

                BoundColumn nameColumn9 = new BoundColumn();
                nameColumn9.HeaderText = "Edition";
                nameColumn9.DataField = "Edition";

                name1 = name1 + "," + "Edition";
                name2 = name2 + "," + "Edition";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn9);

                BoundColumn nameColumn10 = new BoundColumn();
                nameColumn10.HeaderText = "Color";
                nameColumn10.DataField = "Hue";

                name1 = name1 + "," + "Color";
                name2 = name2 + "," + "Hue";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn10);

                BoundColumn nameColumn11 = new BoundColumn();
                nameColumn11.HeaderText = "BillStatus";
                nameColumn11.DataField = "BillStatus";

                name1 = name1 + "," + "BillStatus";
                name2 = name2 + "," + "BillStatus";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn11);


                BoundColumn nameColumn12 = new BoundColumn();
                nameColumn12.HeaderText = "PaymentType";
                nameColumn12.DataField = "PaymentType";

                name1 = name1 + "," + "PaymentType";
                name2 = name2 + "," + "PaymentType";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn12);

                BoundColumn nameColumn13 = new BoundColumn();
                nameColumn13.HeaderText = "SpecialDisc";
                nameColumn13.DataField = "SpecialDisc";

                name1 = name1 + "," + "SpecialDisc";
                name2 = name2 + "," + "SpecialDisc";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn13);

                BoundColumn nameColumn14 = new BoundColumn();
                nameColumn14.HeaderText = "SpaceDisc";
                nameColumn14.DataField = "SpaceDisc";

                name1 = name1 + "," + "SpaceDisc";
                name2 = name2 + "," + "SpaceDisc";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn14);

                BoundColumn nameColumn15 = new BoundColumn();
                nameColumn15.HeaderText = "RevenueCenter";
                nameColumn15.DataField = "RevenueCenter";

                name1 = name1 + "," + "RevenueCenter";
                name2 = name2 + "," + "RevenueCenter";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn15);

                BoundColumn nameColumn16 = new BoundColumn();
                nameColumn16.HeaderText = "Rate";
                nameColumn16.DataField = "AgreedRate";

                name1 = name1 + "," + "Rate";
                name2 = name2 + "," + "AgreedRate";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn16);

                BoundColumn nameColumn17 = new BoundColumn();
                nameColumn17.HeaderText = "GrossAmt";
                nameColumn17.DataField = "GrossAmt";

                name1 = name1 + "," + "GrossAmt";
                name2 = name2 + "," + "GrossAmt";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn17);

                BoundColumn nameColumn18 = new BoundColumn();
                nameColumn18.HeaderText = "Agency TD";
                nameColumn18.DataField = "Disc";

                name1 = name1 + "," + "Agency TD";
                name2 = name2 + "," + "Disc";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn18);

                BoundColumn nameColumn19 = new BoundColumn();
                nameColumn19.HeaderText = "Additional TD";
                nameColumn19.DataField = "Addlagcomm";

                name1 = name1 + "," + "Additional TD";
                name2 = name2 + "," + "Addlagcomm";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn19);

                BoundColumn nameColumn20 = new BoundColumn();
                nameColumn20.HeaderText = "BillAmt";
                nameColumn20.DataField = "BillAmt";

                name1 = name1 + "," + "BillAmt";
                name2 = name2 + "," + "BillAmt";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn20);

                BoundColumn nameColumn21 = new BoundColumn();
                nameColumn21.HeaderText = "Yield";
                nameColumn21.DataField = "Yield";

                name1 = name1 + "," + "Yield";
                name2 = name2 + "," + "Yield";
                name3 = name3 + "," + "G";
                DataGrid1.Columns.Add(nameColumn21);




                DataGrid1.DataSource = ds;
                if (chk_excel == "1")
                {
                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    DataGrid1.ShowHeader = true;
                    DataGrid1.ShowFooter = true;
                    DataGrid1.DataBind();
                    hw.Write("<p <table border=\"1\"><tr><td colspan=\"22\"align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"22\"align=\"center\"><b>" +"category wise Report" +"</b></td></tr>");
                    hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "Publication Center:"+"</b>" + lblpubcent.Text + "</td>");
                    hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Publication:" + "</b>" + lblpub.Text + "</td>");
                    hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Region:" + "</b>" + lblregion.Text + "</td></tr>");
                    hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "Ad Type:" + "</b>" + lbladtype.Text + "</td>");
                    hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "Executive:" + "</b>" + lblexecutive.Text + "</td>");
                    hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "City:" + "</b>" + lblcity.Text + "</td>");
                    hw.Write("<p <td colspan=\"11\"align=\"left\"><b>" + "Agency Category:" + "</b>" + lblagcat.Text + "</td></tr>");
                    hw.Write("<p <tr><td colspan=\"3\"align=\"left\"><b>" + "From Date:" + "</b>" + lblfrom.Text + "</td>");
                    hw.Write("<p <td colspan=\"4\"align=\"left\"><b>" + "To Date:" + "</b>" + lblto.Text + "</td>");
                    hw.Write("<p <td colspan=\"15\"align=\"left\"><b>" + "Run Date:" + "</b>" + lbldate.Text + "</td><tr>");
                    //hw.Write("<p align=\"right\"><b>Run Date:</b>" + ds.Tables[0].Rows[0]["Rundate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<b>Category Wise Report<b>");
                    hw.WriteBreak();
                    DataGrid1.RenderControl(hw);
                    int sno11 = sno - 1;
                    Response.Write(sw.ToString().Replace("</table>", "<tr><td>TotalAds:  " + sno11 + "</td><td align=\"center\" colspan=\"16\">TOTAL</td><td align=\"right\"colspan=\"1\">" + amtnew + "</td><td colspan=\"1\">&nbsp;</td ><td colspan\"1\">&nbsp;</td ><td align=\"right\"colspan=\"1\">" + amtnew1 + "</td><td align=\"right\"colspan=\"1\">" + amtnew13 + "</td></tr></table>"));
                }
                else
                {
                    DataGrid1.DataSource = ds;

                    string[] names = name2.Substring(1, name2.Length - 1).Split(',');
                    string[] captions = name1.Substring(1, name1.Length - 1).Split(',');
                    string[] formats = name3.Substring(1, name3.Length - 1).Split(',');
                    string[][] colProperties ={ names, captions, formats };

                    QueryToCSV(ds, colProperties);
                }
                Response.Flush();
                Response.End();
         
}

private void QueryToCSV(DataSet dr, string[][] colProperties)
{
    if (colProperties.Length > 0)
    {
        int counter;
        Response.Write("\"" + String.Join("\",\"", colProperties[1]) + "\"\n");
        for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
        {
            counter = 0;
            Response.Write("\"");
            foreach (String column in colProperties[0])
            {
                //dr.Tables[0].Rows[i].
                Response.Write(String.Format("{0:" + colProperties[2][counter] + "}", dr.Tables[0].Rows[i].ItemArray[getcolindex(dr, column)]));
                if (counter < colProperties[0].Length - 1)
                {
                    Response.Write("\",\"");
                }
                counter += 1;
            }
            Response.Write("\"\n");
        }
        //dr.Close();
        //tw.Close();
    }
}
private int getcolindex(DataSet ds, string col)
{
    int i;
    for (i = 0; i < ds.Tables[0].Columns.Count - 1; i++)
    {
        if (ds.Tables[0].Columns[i].ColumnName.ToLower().Trim() == col.ToLower().Trim())
        {
            goto td5;

        }
    }
td5:
    return i;
}



    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }
        string check1 = e.Item.Cells[17].Text;
        string amt = e.Item.Cells[17].Text;

        if (check1 != "GrossAmt")
        {
            if (check1 != "&nbsp;")
            {


                string totalarea = e.Item.Cells[17].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }


        string bill = e.Item.Cells[20].Text;
        string billamt = e.Item.Cells[20].Text;
        if (bill != "BillAmt")
        {
            if (bill != "&nbsp;")
            {


                string totalbill= e.Item.Cells[20].Text;
                billamtsum = Convert.ToDouble(totalbill);
                amtnew1 = amtnew1 + billamtsum;


            }
        }
        string yield = e.Item.Cells[21].Text;
        string yieldamt = e.Item.Cells[21].Text;
        if (yield != "Yield")
        {
            if (yield != "&nbsp;")
            {


                string totalyield = e.Item.Cells[21].Text;
                yieldamtsum = Convert.ToDouble(totalyield);
               amtnew13 = amtnew13 + yieldamtsum;


            }
        }

    }
}
