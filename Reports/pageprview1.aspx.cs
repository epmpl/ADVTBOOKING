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
using System.Web.UI.WebControls;


public partial class pageprview1 : System.Web.UI.Page
{
    int sno = 1;
    double amt = 0;
    double amt1 = 0;
    double area1 = 0;
    double areanew = 0;
    double areasum = 0;
    double amtsum = 0;
    double amtnew = 0;
    double billablearea = 0;
    double billarea2 = 0;
    double totrol=0;
    double totcd = 0;
    double totcc = 0;

    string clientname = "";
    string adtyp = "";
    string destination = "";
    //string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
   // string adcatname = "";
    string day = "";
    string month = "";
    string year = "";
    string positioncode = "";
    string agname = "";
   //string status = "";
    string status1 = "";
    string hold = "";
    //string adtypename="";
    string  editionname="";
   // string agencyname = "";
    string page = "";
    string position = "";
    string datefrom1 = "";
    string dateto1 = "";
    int ins_no = 0;
    double area = 0;
    double BillAmt = 0;
    float billarea = 0;
    string package = "";
    string sortorder = "", agtype = "", agtypetext = "";
    string sortvalue = "",adtype="",adtypename="",client="",clientname1="",agency="",agencyname="";
    DataSet ds;
    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
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
       
       
        fromdt = Session["fromdate"].ToString();
        dateto = Session["todate"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();

        ds = (DataSet)Session["pageprem"];
        string prm = Session["prm_pageprem"].ToString();
        string[] prm_Array = new string[42];
        prm_Array = prm.Split('~');

        page = prm_Array[1];//Request.QueryString["page"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        publ = prm_Array[7]; //Request.QueryString["publication"].ToString();
        pubcen = prm_Array[9]; //Request.QueryString["pubcenter"].ToString();
        pubcname = prm_Array[11]; //Request.QueryString["publicname"].ToString();
        pub2 = prm_Array[13]; //Request.QueryString["publiccent"].ToString();
        edition = prm_Array[15]; //Request.QueryString["edition"].ToString();
        destination = prm_Array[17]; //Request.QueryString["destination"].ToString();
        editionname = prm_Array[19]; //Request.QueryString["editionname"].ToString();
        position = prm_Array[21]; //Request.QueryString["position"].ToString();
        positioncode = prm_Array[23]; //Request.QueryString["positioncode"].ToString();
        adtypename = prm_Array[25]; //Request.QueryString["adtypename"].ToString();
        adtype = prm_Array[27]; //Request.QueryString["adtype"].ToString();
        client = prm_Array[29]; //Request.QueryString["client"].ToString();
        agency = prm_Array[31]; //Request.QueryString["agency"].ToString();
        clientname1 = prm_Array[33]; //Request.QueryString["clientname"].ToString();
        agencyname = prm_Array[35]; //Request.QueryString["agencyname"].ToString();
        agtype = prm_Array[37]; //Request.QueryString["agtype"].ToString();
        agtypetext = prm_Array[39]; //Request.QueryString["agtypetext"].ToString();
        chk_excel = prm_Array[41];
           

            hiddendatefrom.Value = fromdt.ToString();
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

            if (!Page.IsPostBack)
            {
                if (destination == "1" || destination == "0")
                {
                    onscreen(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, adtype, agency, client);
                }
                else if (destination == "4")
                {
                    excel(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, adtype, agency, client);
                }
                else
                    if (destination == "3")
                    {
                        pdf(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, adtype, agency, client);

                    }
            }
        
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
    private void onscreen(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold,string adtype, string agency,string client)    
    {
        string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
          //DataSet ds = new DataSet();
          //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
          //{
          //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
          //    SqlDataAdapter da = new SqlDataAdapter();
          //    ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
          //}
          ////ds = obj.spPagepremium(clientname, agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), status, edition, Session["dateformat"].ToString(), hold);
          //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
          //{
          //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
          //    ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), agency, adtype, temp3, temp4, client, agtypetext);
          //}
          cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
    int contc = ds.Tables[0].Columns.Count;
    string tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";

    tbl = tbl + "<tr><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";

        if (hiddenascdesc.Value == "")
        {
            //tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>CIOID</td><td class='middle31'>Ins.Date</td><td id='tdag~3' class='middle3'   onclick=sorting('Agency',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~4' class='middle3'   onclick=sorting('Client',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~5' class='middle3'   onclick=sorting('City',this.id)>City<img id='imgcidown' src='Images\\down.gif' style='display:block;'><img id='imgciup' src='Images\\up.gif' style='display:none;'></td><td id='tdcl~6' class='middle3'   onclick=sorting('Package',this.id)>Package<img id='imgpadown' src='Images\\down.gif' style='display:block;'><img id='imgpaup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>Depth</td><td class='middle31'>Width</td><td class='middle31'>Hue</td><td class='middle31'>Ins.No</td><td class='middle31'>BookDate</td><td class='middle31'>RoNo.</td><td class='middle31'>RoStatus</td><td id='tdat~14' class='middle3'   onclick=sorting('AdType',this.id)>AdType<img id='imgatdown' src='Images\\down.gif' style='display:block;'><img id='imgatup' src='Images\\up.gif' style='display:none;'></td><td class='middle31'>RateCode</td><td class='middle31'>Status</td><td class='middle31'>PagePremium</td><td class='middle31'>PosPremium</td></tr>");
            tbl = tbl + ("<tr><td class='middle3'>S.No.</td><td class='middle3' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;Id</td><td class='middle3' align='left'>&nbsp;&nbsp;Edition</td><td class='middle3' align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle3' align='left'>&nbsp;&nbsp;Agency</td><td  class='middle3' align='left'>&nbsp;&nbsp;Client</td><td  class='middle3' align='left'>&nbsp;&nbsp;Package</td><td class='middle3' align='right'>&nbsp;&nbsp;Area</td><td class='middle3' align='left'>&nbsp;&nbsp;Color</td><td class='middle3' align='left'>&nbsp;&nbsp;Page</br>&nbsp;&nbsp;Position</td><td class='middle3' width='1%' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Prem&nbsp;&nbsp;</td><td class='middle3' width='1%' align='left'>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle3' width='2%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle3' align='left'>RoNo.&nbsp;&nbsp;</td><td class='middle3'>Ro</br>Status</td><td class='middle3' align='left'>&nbsp;&nbsp;Adcat</td><td class='middle3' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle3' align='right'>&nbsp;&nbsp;Rate</td><td class='middle3' width='4%' align='right'>&nbsp;&nbsp;Amt.</td><td class='middle3' width='2%' colspan='2' align='left'>&nbsp;&nbsp;Caption</br>&nbsp;&nbsp;Key No</td></tr>");

        }
        

        int i1 = 1;

        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");


            //string cioid1 = "";
            //string rrr = ds.Tables[0].Rows[i]["CIOID"].ToString();
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

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");


            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Ins.date"] + "</td>");

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");


            //string agency1 = "";
            //string chkr = ds.Tables[0].Rows[i]["Agency"].ToString();
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




            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");

            //string client1 = "";
            //string der = ds.Tables[0].Rows[i]["Client"].ToString();
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


            //string Package1 = "";
            //string rrr111111 = ds.Tables[0].Rows[i]["Package"].ToString();
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
            string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
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
            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'>");
            tbl = tbl + (Package1 + "</td>");


            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='right'  valign='top'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["Area"].ToString()) + "</td>");
            if (ds.Tables[0].Rows[i]["Area"].ToString() != "")
            {


                if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                    area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                    totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                    totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                    totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());



            }

            //string Pkg11 = "";
            //string re1 = ds.Tables[0].Rows[i]["Hue"].ToString();
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
            string rrrt = ds.Tables[0].Rows[i]["Hue"].ToString();
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
            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='center'>");
            tbl = tbl + (hue_col + "</td>");

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'  valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Page"] + "</td>");

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data'  width='1%'>");

            if (ds.Tables[0].Rows[i]["priname"].ToString() == "0")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {
                tbl = tbl + (ds.Tables[0].Rows[i]["priname"] + "</td>");
            }
            //if (ds.Tables[0].Rows[i]["PagePremiumcd"].ToString() == "0")
            //{
            //    tbl = tbl + "" + "</td>";
            //}
            //else
            //{
            //    tbl = tbl + (ds.Tables[0].Rows[i]["PagePremiumcd"] + "</td>");
            //}
            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'  width='1%'>");
            if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {
                tbl = tbl + (ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
            }

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left'  width='1%'>");
            if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
            {
                tbl = tbl + "" + "</td>";
            }
            else
            {
                tbl = tbl + (ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
            }

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RoNo."] + "</td>");

            string RoStatus1 = "";
            string rrr4 = ds.Tables[0].Rows[i]["RoStatus"].ToString();
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

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' valign='top' align='left'>");
            tbl = tbl + (RoStatus1 + "</td>");

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' valign='top' align='left'>");


            //string AdCat1 = "";
            //string rrrnew1 = ds.Tables[0].Rows[i]["AdCat"].ToString();
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
            string rrr5 = ds.Tables[0].Rows[i]["AdCat"].ToString();
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
            tbl = tbl + (AdCat1 + "</td>");

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='left' valign='top'>");
            //string ratecode1 = "";
            //string w2 = ds.Tables[0].Rows[i]["RateCode"].ToString();
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
            string rrrq = ds.Tables[0].Rows[i]["RateCode"].ToString();
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
            tbl = tbl + (ratecode1 + "</td>");

            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='right' valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["AgreedRate"] + "</td>");


            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' align='right' valign='top'>");
            tbl = tbl + (chk_null(ds.Tables[0].Rows[i]["Amt"].ToString()) + "</td>");
            if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());


            tbl = tbl + ("<td  style=\"padding-left:4px\"  class='rep_data' colspan='2' align='left'  valign='top'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Cap"] + "<br>");


            tbl = tbl + (ds.Tables[0].Rows[i]["Key"] + "</td>");

            tbl += "</tr>";
            tblgrid.InnerHtml += tbl;
            tbl = "";
        }

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle1212'>");
        tbl = tbl + ("<tr><td class='middle1212' colspan='2'align='left'><b>Total Ads:</b>");//</td>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");

         tbl = tbl + ("<td class='middle1212' colspan='4'>&nbsp;</td>");
         //tbl = tbl + ("<td class='middle1212' >Total</td>");
         tbl = tbl +("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl = tbl +(chk_null(cal.ToString()) + "</td>");
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
            tbl = tbl + ("<td class='middle1212' colspan='3' align='right'><b>Total Chars:<b/>");
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            tbl = tbl + (calfd.ToString() + "</td>");
        }
        else
        {
        }
        if (totcc > 0)
        {
            tbl = tbl + ("<td class='middle1212' colspan='3' align='left'><b>Total Words:</b>");
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            tbl = tbl + (calft.ToString() + "</td>");
        }
        else
        {
            tbl = tbl + ("<td class='middle1212' colspan='1'>&nbsp;</td>");
        }
        tbl = tbl + ("<td class='middle1212' colspan='2'>&nbsp;</td>");
        tbl = tbl + ("<td class='middle1212'colspan='4' align='right'><b>Total Amt:</b>");
        double cal1 = System.Math.Round(Convert.ToDouble(amt), 2);
        tbl = tbl + (chk_null(cal1.ToString()) + "</td>");
        tbl = tbl + ("<td class='middle1212' >&nbsp;</td>");
        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        //tblgrid.InnerHtml = tbl;
        tblgrid.InnerHtml += tbl;
    
}

    private void excel(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold, string adtype, string agency, string client)
    {
       

            string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
            //DataSet ds = new DataSet();
            // if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
            //    ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), agency, adtype, temp3, temp4, client, agtypetext);
            //}
            int cont = ds.Tables[0].Rows.Count;

            for (int u = 0; u < cont; u++)
            {

                if (ds.Tables[0].Rows[u]["Area"].ToString() != "")
                {
                    //if (ds.Tables[0].Rows[u]["uom"].ToString() == "SQ0")
                    //    area1 = area1 + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[u]["uom"].ToString() == "LI0")
                    //    totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[u]["uom"].ToString() == "SQ1")
                    //    totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[u]["uom"].ToString() == "CC0")
                    //    totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    if (ds.Tables[0].Rows[u]["uom"].ToString() == "CD" || ds.Tables[0].Rows[u]["uom"].ToString() == "ROD")
                        area1 = area1 + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());
                    else if (ds.Tables[0].Rows[u]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[u]["Area"].ToString());


                }
            }

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
            nameColumn1.HeaderText = "Edition";
            nameColumn1.DataField = "edition";

            name1 = name1 + "," + "Edition";
            name2 = name2 + "," + "edition";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn1);

            BoundColumn nameColumn2 = new BoundColumn();
            nameColumn2.HeaderText = "Publish Date";
            nameColumn2.DataField = "Ins.Date";

            name1 = name1 + "," + "Publish Date";
            name2 = name2 + "," + "Ins.Date";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn2);

            BoundColumn nameColumn4 = new BoundColumn();
            nameColumn4.HeaderText = "Agency";
            nameColumn4.DataField = "Agency";

            name1 = name1 + "," + "Agency";
            name2 = name2 + "," + "Agency";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn4);



            BoundColumn nameColumn6 = new BoundColumn();
            nameColumn6.HeaderText = "Client";
            nameColumn6.DataField = "Client";

            name1 = name1 + "," + "Client";
            name2 = name2 + "," + "Client";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn6);

            BoundColumn nameColumn7 = new BoundColumn();
            nameColumn7.HeaderText = "Package";
            nameColumn7.DataField = "Package";

            name1 = name1 + "," + "Package";
            name2 = name2 + "," + "Package";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn7);



            BoundColumn nameColumn11 = new BoundColumn();
            nameColumn11.HeaderText = "Area";
            nameColumn11.DataField = "Area";

            name1 = name1 + "," + "Area";
            name2 = name2 + "," + "Area";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn11);

            BoundColumn nameColumn12 = new BoundColumn();
            nameColumn12.HeaderText = "Color";
            nameColumn12.DataField = "Hue";

            name1 = name1 + "," + "Color";
            name2 = name2 + "," + "Hue";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn12);


            BoundColumn nameColumn13 = new BoundColumn();
            nameColumn13.HeaderText = "Page Position";
            nameColumn13.DataField = "Page";

            name1 = name1 + "," + "Page Position";
            name2 = name2 + "," + "Page";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn13);


            BoundColumn nameColumn14 = new BoundColumn();
            nameColumn14.HeaderText = "Page Premium";
            nameColumn14.DataField = "PagePremiumcd";

            name1 = name1 + "," + "Page Premium";
            name2 = name2 + "," + "PagePremiumcd";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn14);

            BoundColumn nameColumn15 = new BoundColumn();
            nameColumn15.HeaderText = "Position Premium";
            nameColumn15.DataField = "PositionPremium";

            name1 = name1 + "," + "Position Premium";
            name2 = name2 + "," + "PositionPremium";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn15);


            BoundColumn nameColumn16 = new BoundColumn();
            nameColumn16.HeaderText = "Eye Catcher";
            nameColumn16.DataField = "BulletPremium";

            name1 = name1 + "," + "Eye Catcher";
            name2 = name2 + "," + "BulletPremium";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn16);

            BoundColumn nameColumn17 = new BoundColumn();
            nameColumn17.HeaderText = "RoNo.";
            nameColumn17.DataField = "RoNo.";

            name1 = name1 + "," + "RoNo.";
            name2 = name2 + "," + "RoNo.";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn17);

            BoundColumn nameColumn18 = new BoundColumn();
            nameColumn18.HeaderText = "RoStatus";
            nameColumn18.DataField = "RoStatus";

            name1 = name1 + "," + "RoStatus";
            name2 = name2 + "," + "RoStatus";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn18);

            BoundColumn nameColumn19 = new BoundColumn();
            nameColumn19.HeaderText = "AdCat";
            nameColumn19.DataField = "AdCat";

            name1 = name1 + "," + "AdCat";
            name2 = name2 + "," + "AdCat";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn19);

            BoundColumn nameColumn20 = new BoundColumn();
            nameColumn20.HeaderText = "RateCode";
            nameColumn20.DataField = "RateCode";

            name1 = name1 + "," + "RateCode";
            name2 = name2 + "," + "RateCode";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn20);

            BoundColumn nameColumn21 = new BoundColumn();
            nameColumn21.HeaderText = "Rate";
            nameColumn21.DataField = "AgreedRate";

            name1 = name1 + "," + "Rate";
            name2 = name2 + "," + "AgreedRate";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn21);

            BoundColumn nameColumn22 = new BoundColumn();
            nameColumn22.HeaderText = "Amt";
            nameColumn22.DataField = "Amt";

            name1 = name1 + "," + "Amt";
            name2 = name2 + "," + "Amt";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn22);


            BoundColumn nameColumn23 = new BoundColumn();
            nameColumn23.HeaderText = "Caption";
            nameColumn23.DataField = "Cap";

            name1 = name1 + "," + "Caption";
            name2 = name2 + "," + "Cap";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(nameColumn23);

            BoundColumn name24Column23 = new BoundColumn();
            name24Column23.HeaderText = "Key No.";
            name24Column23.DataField = "Key";

            name1 = name1 + "," + "Key No.";
            name2 = name2 + "," + "Key";
            name3 = name3 + "," + "G";
            DataGrid1.Columns.Add(name24Column23);



            DataGrid1.DataSource = ds;
            if (chk_excel == "1")
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                DataGrid1.ShowHeader = true;
                DataGrid1.ShowFooter = true;
                DataGrid1.DataBind();
                hw.Write("<p <table border =\"1\"> <tr> <td align=\"center\" colspan=\"20\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
                hw.Write("<p <table border =\"1\"> <tr> <td align=\"center\" colspan=\"20\"><b>Page Premium Report</b></td></tr><table>");
                hw.Write("<p <table border =\"1\"> <tr> <td align=\"left\"><b>Page Premium:</b>" + lblpagepr.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Position:</b>" + lblposition.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Publication:</b>" + lblpub.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Pub Center:</b>" + pcenter.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Edition:</b>" + lbedition.Text);
                hw.Write("<p <table border =\"1\"> <tr> <td align=\"left\"><b>Date From:</b>" + lblfrom.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Date To:</b>" + lblto.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Run Date:</b>" + lbldate.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>AdType:</b>" + lbladtype.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Agency Type:</b>" + lblagtype.Text);
              

                hw.WriteBreak();

                DataGrid1.RenderControl(hw);

                int sno11 = sno - 1;

                Response.Write(sw.ToString().Replace("</table>", "<tr><td colspan='6'>TotalAds:  " + cont + "</td><td >Total Area:</td>,<td align='left'>" + area1 + "</td><td >Total Lines:</td><td  align='left'>" + totrol + "</td><td >Total Chars:</td><td  align='left'>" + totcd + "</td><td >Total Words:</td><td colspan='6' align='left'>" + totcc + "</td><td >" + amtnew + "</td></tr></table>"));
            }
            else
            {
                
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
    private void pdf(string page, string position, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat, string hold, string adtype, string agency, string client)    
        {
            DataSet pdfxml = new DataSet();
            pdfxml.ReadXml(Server.MapPath("XML/pdf.xml"));
        string pdfName = "";
        pdfName = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + ".pdf";
        string name = Server.MapPath("") + "//" + pdfName;
        Document document = new Document(PageSize.A4.rotate(), 30, 30, 30, 30);
        PdfWriter.getInstance(document, new FileStream(name, FileMode.Create));
        int i2 = 0;
        //=======================================WATERMARK=========================================

      

        //--------------------for page numbering---------------------------------------------

        //HeaderFooter footer = new HeaderFooter(new Phrase(i2=i2+1 ), true);
        HeaderFooter footer = new HeaderFooter(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[28].ToString() + i2++), true);
        footer.Border = Rectangle.NO_BORDER;
        footer.Alignment = Element.ALIGN_CENTER;
        document.Footer = footer;

        document.Open();     
        int NumColumns = 21;        
        //---------------------------------
        Font font9 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 14, Font.BOLD);
        Font font10 = FontFactory.getFont(FontFactory.TIMES_ROMAN, 7, Font.BOLD);
        Font font11 = FontFactory.getFont(FontFactory.COURIER, 7);
        //----------------------------------------
        try
        {
            string temp1 = "", temp2 = "", temp3 = "", temp4 = "", temp5 = "";
            //DataSet ds = new DataSet();
            //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            //{
            //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //}
            //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            //{
            //    NewAdbooking.Report.classesoracle.classnew obj = new NewAdbooking.Report.classesoracle.classnew();
            //    ds = obj.spPagepremium(page, position, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hold, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), agency, adtype, temp3, temp4, client, agtypetext);
            //}
            PdfPTable tbl = new PdfPTable(1);
            float[] xy = { 100 };
            tbl.DefaultCell.BorderWidth = 0;
            tbl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.setWidths(xy);

            tbl.addCell(new Phrase(ds.Tables[0].Rows[0]["companyname"].ToString(), font9));

            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/report1.xml"));
            //heading.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            //oSheet.Cells[1, 7] = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
           
           // tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[4].ToString(), font9));
            tbl.addCell(new Phrase(ds1.Tables[0].Rows[0].ItemArray[4].ToString(), font9));

            //tbl.addCell("List of ADS -Hold/Cancelled");
            float[] headerwidths1 = { 50 };
            tbl.setWidths(headerwidths1);
            tbl.WidthPercentage = 100;
            //tbl.DefaultCell.Padding = -5;
            document.Add(tbl);
            //-----------------------------------------------
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

            PdfPTable tbl2 = new PdfPTable(6);
            tbl2.DefaultCell.BorderWidth = 0;
            tbl2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[29].ToString(), font10));
            tbl2.addCell(new Phrase(fromdt.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[30].ToString(), font10));
            tbl2.addCell(new Phrase(dateto.ToString(), font11));
            tbl2.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[31].ToString(), font10));
            tbl2.addCell(new Phrase(date.ToString(), font11));
            tbl2.WidthPercentage = 100;
            document.Add(tbl2);

            //--------------------------------------------===
            float[] headerwidths55 = { 14, 14, 14, 23, 21, 18, 14, 16, 15, 15, 16, 14, 20, 20, 16, 20, 16, 18, 24, 16, 18 };
            PdfPTable datatable = new PdfPTable(headerwidths55);
            datatable.DefaultCell.Padding = 3;
           
            //float[] headerwidths = { 14, 14, 14, 21, 18, 18, 7, 7, 15, 15, 16, 14, 20, 20, 14, 16, 16, 18, 15, 16, 18, 14, 12, 14, 18, 9, 9 };
            //float[] headerwidths = { 12,12, 12, 14, 21, 18, 7, 7,18, 16, 20, 20, 15, 16, 18, 17,  18, 20, 18 }; // percentage
            //datatable.setWidths(headerwidths);
            datatable.WidthPercentage = 100; // percentage
            datatable.DefaultCell.BorderWidth = 0;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.DefaultCell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[0].ToString(), font10));
            datatable.addCell(new Phrase("Booking Id", font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[75].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[85].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[2].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[3].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[6].ToString(), font10));
            //datatable.addCell(new Phrase("Pub", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[19].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[64].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[87].ToString(), font10));            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[35].ToString(), font10));
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[11].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[36].ToString(), font10));
          
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[79].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[15].ToString(), font10));
            //datatable.addCell(new Phrase("Area", font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[16].ToString(), font10));            
            //datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[17].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[18].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[20].ToString(), font10));            
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[61].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[33].ToString(), font10));

            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[26].ToString(), font10));
            datatable.addCell(new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[27].ToString(), font10));

            Phrase p2 = new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[37].ToString());


            document.Add(p2);
            datatable.HeaderRows = 1;
            
            int i1 = 1;
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                //for (int a = 0; a <= 10; ++a)
                //{
                datatable.addCell(new Phrase(i1++.ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["CIOID"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["edition"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Ins.date"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Agency"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Client"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["City"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][4].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Package"].ToString(), font11));
                datatable.addCell(new Phrase (chk_null(ds.Tables[0].Rows[row]["Area"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["Area"].ToString() != "")
                {
                    //if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ0")
                    //    area1 = area1 + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "LI0")
                    //    totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "SQ1")
                    //    totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    //else if (ds.Tables[0].Rows[row]["uom"].ToString() == "CC0")
                    //    totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());


                    if (ds.Tables[0].Rows[row]["uom"].ToString() == "CD" || ds.Tables[0].Rows[row]["uom"].ToString() == "ROD")
                        area1 = area1 + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());
                    else if (ds.Tables[0].Rows[row]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[row]["Area"].ToString());

               
                } 
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Width"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Hue"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Page"].ToString(), font11));
                //ins_no = ins_no + Convert.ToInt32(ds.Tables[0].Rows[row]["Ins.No."].ToString());


                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PagePremiumcd"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["PositionPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["BulletPremium"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoNo."].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RoStatus"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AdCat"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["RateCode"].ToString(), font11));
                //datatable.addCell(new Phrase(ds.Tables[0].Rows[row][19].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["AgreedRate"].ToString(), font11));
                datatable.addCell(new Phrase(chk_null(ds.Tables[0].Rows[row]["Amt"].ToString()), font11));
                if (ds.Tables[0].Rows[row]["Amt"].ToString() != "")
                    amt1 = amt1 + double.Parse(ds.Tables[0].Rows[row]["Amt"].ToString());

                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Cap"].ToString(), font11));
                datatable.addCell(new Phrase(ds.Tables[0].Rows[row]["Key"].ToString(), font11));
                //}               
                //}
            }

            document.Add(datatable);           

            Phrase p3 = (new Phrase(pdfxml.Tables[0].Rows[0].ItemArray[55].ToString(), font10));


            document.Add(p3);

            PdfPTable tbltotal = new PdfPTable(13);
            float[] headerwidths = { 11, 30, 23, 14, 10, 8, 12, 10, 10, 10, 10, 18, 33 }; // percentage
            tbltotal.setWidths(headerwidths);
            tbltotal.DefaultCell.BorderWidth = 0;
          tbltotal.WidthPercentage = 100;
            tbltotal.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            tbltotal.addCell(new Phrase(pdfxml.Tables[1].Rows[0].ItemArray[15].ToString(), font10));
            tbltotal.addCell(new Phrase((i1 -1).ToString(), font11));
           
            tbltotal.addCell(new Phrase("Area:", font11));
            tbltotal.addCell(new Phrase (chk_null(area1.ToString()), font11));

            if (totrol > 0)
            {
                tbltotal.addCell(new Phrase("Lines:", font11));
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbltotal.addCell(new Phrase(calf.ToString(), font11));

                
            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcd > 0)
            {
                tbltotal.addCell(new Phrase("Cds:", font11));
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbltotal.addCell(new Phrase(calfd.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }
            if (totcc > 0)
            {

                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbltotal.addCell(new Phrase("CCs:", font11));
                tbltotal.addCell(new Phrase(calft.ToString(), font11));

            }
            else
            {
                tbltotal.addCell(new Phrase(" ", font11));
                tbltotal.addCell(new Phrase(" ", font11));
            }

           
            

           
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            //tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase(" ", font11));
            tbltotal.addCell(new Phrase("Amt:", font11));
           
            tbltotal.addCell(new Phrase(amt1.ToString(), font11));
            tbltotal.addCell(new Phrase(" ", font11));
            
            
            document.Add(tbltotal);

            document.Close();

            Response.Redirect(pdfName);

        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.StackTrace);
        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_pageprem_print"] = "dateto~" + dateto + "~fromdate~" + fromdt + "~destination~" + destination + "~publication~" + publ + "~pubcenter~" + pubcen + "~publiccent~" + pub2 + "~publicname~" + pubcname + "~edition~" + edition + "~page~" + page + "~position~" + position + "~editionname~" + editionname + "~positioncode~" + positioncode + "~adtype~" + adtype + "~adtypename~" + adtypename + "~client~" + client + "~clientname~" + clientname1 + "~agency~" + agency + "~agencyname~" + agencyname + "~agtype1~" + agtype + "~agtypetext~" + agtypetext;
      Response.Redirect("printpageprem.aspx");

       // Response.Redirect("printpageprem.aspx?dateto=" + dateto + "&fromdate=" + fromdt + "&destination=" + destination + "&publication=" + publ + "&pubcenter=" + pubcen + "&publiccent=" + pub2 + "&publicname=" + pubcname + "&edition=" + edition + "&page=" + page + "&position=" + position + "&editionname=" + editionname + "&positioncode=" + positioncode + "&adtype=" + adtype + "&adtypename=" + adtypename + "&client=" + client + "&clientname=" + clientname1 + "&agency=" + agency + "&agencyname=" + agencyname + "&agtype1=" + agtype + "&agtypetext=" + agtypetext + "");

    }
   
    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        string sno1 = e.Item.Cells[0].Text;
        string cioidchk = e.Item.Cells[1].Text;

        if ((sno1 != "S.No") && (cioidchk != "") && (sno1 != "&nbsp;"))
        {
            e.Item.Cells[0].Text = Convert.ToString(sno++);
        }

        string check = e.Item.Cells[18].Text;
        string amt = e.Item.Cells[18].Text;

        if (check != "Amt")
        {
            if (check != "&nbsp;")
            {


                string totalarea = e.Item.Cells[18].Text;
                amtsum = Convert.ToDouble(totalarea);
                amtnew = amtnew + amtsum;


            }
        }

        string check2 = e.Item.Cells[7].Text;
        string billarea = e.Item.Cells[7].Text;

        if (check2 != "Area")
        {
            if (check2 != "&nbsp;")
            {


                string billarea1 = e.Item.Cells[7].Text;
                billarea2 = Convert.ToDouble(billarea1);
                billablearea = billablearea + billarea2;


            }
        }
    }
}