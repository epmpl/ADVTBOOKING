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
using System.Text;

public partial class PrintmulticlientScheReg : System.Web.UI.Page
{
    int nontot = 0;
    int checkvar = 1;
    int temprowcnt = 0;
    int cnt = 0;
    int cntP;
    int cnt1 = 0, cnt2 = 0, cnt4 = 0, cnt5 = 0;
    decimal cnt3 = 0;
    int dfr = 0;
    int dd2;
    int cont1;
    int maxlimit = 15;
    string client = "";
    string pdfName1 = "";

    int totunaudit = 0, totaudit = 0, temptotunaudit = 0, temptotaudit = 0;

    string agency = "";
    int count1 = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count31 = 0;
    string destination = "";
    string fromdt = "";
    string dateto = "", adcatname = "", editionname = "";

    string day = "";
    string month = "";
    string year = "";
    string date = "";

    string datefrom1 = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    decimal area1 = 0;
    decimal paidins = 0;
    string package = "";
    string package11 = "";
    string dateformate = "";
    string fmg = "";
    string sortorder = "";
    string sortvalue = "";
    string publicationcenter = "";
    string adtype = "";
    string adtypecode = "";
    string adcategory = "";
    string edition = "";
    string supplement = "";
    string pubcentcode = "";
    string dytbl = "";
    string editiondetail = "";
    string status = "", dynedition = "";
    //string fromdt = "";
    //string dateto="";

    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    string sortfield = "";
    string sorting = "", supplementcode = "";
    string dynhead = "", dynpub = "", dynfrmdt = "", dyntodt = "", dynpubcent = "", dynadcat = "", dynadtype = "", dyncompname = "";
    double sqcm = 0, colcm = 0, other = 0, totrol = 0, totcd = 0, totcc = 0, areaset = 0;
    string pkgdetail = "", package11name = "", pubnamelb = "";
    double tempsqcm = 0, tempcolcm = 0, tempother = 0, temptotrol = 0, temptotcd = 0, temptotcc = 0, tempareaset = 0;
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;
    double ver;

    int editot = 0, fmtot = 0, autot = 0, untot = 0;
    int edichtot = 0, fmchtot = 0, auchtot = 0, unchtot = 0;
    double totar = 0, lntot = 0, chtot = 0, wrdtot = 0;
    double totchar = 0, lnchtot = 0, chchtot = 0, wrdchtot = 0;
    decimal patot = 0, pachtot = 0;
     
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
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[35].ToString());
        // maxlimit = 2;

        browser = Request.Browser;
        ver = (float)(browser.MajorVersion + browser.MinorVersion);




        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        dynhead = "Multi Client Schedule Register Report";


        ds = (DataSet)Session["schedulerep"];
        string prm = Session["rep_schedulerep_print"].ToString();
        string[] prm_Array = new string[41];
        prm_Array = prm.Split('~');


        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3];//Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5];//Request.QueryString["dateto"].ToString();
        publ = prm_Array[7];//Request.QueryString["publication"].ToString();
        publication = prm_Array[9];//Request.QueryString["publicationname"].ToString();
        publicationcenter = prm_Array[11];//Request.QueryString["publicationcenter"].Trim().ToString();
        edition = prm_Array[13];//Request.QueryString["edition"].Trim().ToString();
        pubcentcode = prm_Array[15];//Request.QueryString["pubcentcode"].Trim().ToString();
        adtype = prm_Array[17];//Request.QueryString["adtype"].Trim().ToString();
        adtypecode = prm_Array[19];//Request.QueryString["adtypecode"].Trim().ToString();
        adcategory = prm_Array[21];//Request.QueryString["adcategory"].Trim().ToString();
        editiondetail = prm_Array[23];//Request.QueryString["editiondetail"].Trim().ToString();
        status = prm_Array[25];//Request.QueryString["status"].Trim().ToString();
        sortfield = prm_Array[27];//Request.QueryString["sortfield"].Trim().ToString();
        sorting = prm_Array[29];//Request.QueryString["sorting"].Trim().ToString();
        adcatname = prm_Array[31];//Request.QueryString["adcatname"].Trim().ToString();
        supplementcode = prm_Array[33];//Request.QueryString["supplementcode"].Trim().ToString();
        package11 = prm_Array[35];//Request.QueryString["package1"].Trim().ToString();
        pkgdetail = prm_Array[37];//Request.QueryString["pkgdetail"].Trim().ToString();
        package11name = prm_Array[39];//Request.QueryString["package11name"].Trim().ToString();
        editionname = prm_Array[41];
        if (edition == "")
            edition = "0";

        if (pkgdetail == "0")
        {
            pubnamelb = "PUBLICATION:";
            if (publ == "0")
            {
                dynpub = "All";
            }
            else
            {
                dynpub = publication.ToString();

            }
        }
        else
        {
            pubnamelb = "PACKAGE:";
            if (package11name == "--Select Package--")
            {
                dynpub = "All";
            }
            else
            {
                dynpub = package11name.ToString();
            }
        }

        if (edition != "" && edition != "0")
            dynedition = editionname;
        else
            dynedition = "ALL";

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

        datefrom1 = fromdt;
        dynfrmdt = fromdt;

        dateto1 = dateto;
        dyntodt = dateto;


        dynadtype = adtype;
        if (adcategory != "")
        {

            dynadcat = adcatname;
        }
        else
        {

            dynadcat = "ALL";
        }
        if (pubcentcode != "0")
        {

            dynpubcent = publicationcenter;
        }
        else
        {

            dynpubcent = "ALL";
        }
        hiddendatefrom.Value = fromdt.ToString();


        onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

    }
    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string status, string edition, string pubcentcode, string adtypecode, string adcategory, string dateformat, string package111)  //, string supplement)
    {

        //string tblhdr = "";
        StringBuilder tblhdr = new StringBuilder();


        SqlDataAdapter da = new SqlDataAdapter();

        int cont = ds.Tables[0].Rows.Count;


        dyncompname = ds.Tables[4].Rows[0].ItemArray[1].ToString();
        string tab4date = ds.Tables[4].Rows[0].ItemArray[0].ToString();
        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];


        if (edition != "0")
        {
            tblhdr.Append("<tr ><td align='center' colspan='15' style='height: 28px;padding-left:20px' class='headingc'>" + dyncompname + "</td></tr>");
            tblhdr.Append("<tr><td align='center' colspan='15' style='height: 28px' class='headingp'>" + dynhead + "</td></tr>");
            tblhdr.Append("<tr><td style='width: 69px' colspan='15'></td></tr>");

            //tblhdr.Append( "<tr><td  class='upper2' colspan='3'></td><td  class='upper2' colspan='2' align='left' style='padding-left:60px'>DATE FROM:</td><td class='middle2' colspan='2' >" + dynfrmdt + "</td>");
            tblhdr.Append("<tr><td  class='upper2' colspan='2' align='left'>DATE FROM:</td><td class='middle2' align='left' >" + dynfrmdt + "</td><td  class='upper2' colspan='2' align='left'>RUN DATE:</td><td class='middle2' colspan='2' >" + date.ToString() + "</td></tr>");
            //    tblhdr.Append( "<tr><td style='width: 69px' colspan='15'></td></tr>");

            tblhdr.Append("<tr><td class='upper2' colspan='2' style='padding-left:70px' >" + pubnamelb + "</td><td class='middle2' colspan='2' align='left' >" + dynpub + "</td>");
            tblhdr.Append("<td  class='upper2' colspan='3' style='width:170px'  style='padding-left:15px'>PUBLICATION CENTER:</td><td class='middle2' colspan='2' >" + dynpubcent + "</td><td></td>");
            tblhdr.Append("<td  class='upper2'   >ADTYPE:</td><td class='middle2' colspan='2' >" + dynadtype + "</td>");
            tblhdr.Append(" <td  class='upper2' colspan='2' style='padding-left:30px' >ADCATEGORY:</td><td class='middle2' >" + dynadcat + "</td>");
            tblhdr.Append(" <td  class='upper2'  style='padding-left:30px' >EDITION:</td><td class='middle2' colspan='2'>" + dynedition + "</td></tr>");


        }
        else
        {
            tblhdr.Append("<tr ><td align='center' colspan='15' style='height: 28px;padding-left:20px' class='headingc'>" + dyncompname + "</td></tr>");
            tblhdr.Append("<tr><td align='center' colspan='15' style='height: 28px' class='headingp'>" + dynhead + "</td></tr>");
            tblhdr.Append("<tr><td style='width: 69px' colspan='15'></td></tr>");

            //  tblhdr.Append( "<tr><td  class='upper2' colspan='3'></td><td  class='upper2' colspan='2' align='left' style='padding-left:90px'>DATE FROM:</td><td class='middle2' colspan='2' >" + dynfrmdt + "</td>");
            tblhdr.Append("<tr><td  class='upper2' colspan='2'align='left' style='font-size:13px'>DATE FROM:</td><td class='middle2' colspan='2' style='font-size:15px' >" + dynfrmdt + "</td>");
            tblhdr.Append("<td  class='upper2' colspan='3'style='font-size:13px'  >DATE &nbsp;TO:</td><td class='middle2' colspan='3' style='font-size:15px' >" + dyntodt + "</td>");
            tblhdr.Append("<td  class='upper2' colspan='3' style='font-size:13px'   >RUN DATE:</td><td class='middle2' colspan='2' style='font-size:15px' >" + date + "</td>");
            //  tblhdr.Append( "<tr><td style='width: 69px' colspan='15'></td></tr>");

            tblhdr.Append("<tr><td class='upper2' colspan='2' align='left' style='font-size:13px' >" + pubnamelb + "</td><td class='middle2' colspan='2' align='right' style='font-size:15px' >" + dynpub + "</td>");
            tblhdr.Append("<td  class='upper2' colspan='6'  ></td><td  class='upper2' colspan='3' align='left' style='font-size:12px' >PUBLICATION CENTER:</td><td class='middle2' colspan='2' style='font-size:15px' >" + dynpubcent + "</td></tr>");
            tblhdr.Append("<tr><td  class='upper2' colspan='2' style='font-size:13px' >ADTYPE:</td><td class='middle2' colspan='2' style='font-size:15px' >" + dynadtype + "</td>");
            tblhdr.Append(" <td  class='upper2' colspan='3' style='font-size:13px' >ADCATEGORY:</td><td class='middle2'colspan='3' style='font-size:15px' >" + dynadcat + "</td>");
            tblhdr.Append(" <td  class='upper2' colspan='3'style='font-size:13px' >EDITION:</td><td class='middle2' colspan='2' style='font-size:15px'>" + dynedition + "</td></tr>");

        }
        /////////////////////dynamic header



        if (editiondetail == "0" || editiondetail == "2")
        {
            int i1 = 1;
            //string tbl.Append( "";
            StringBuilder tbl = new StringBuilder();

            int ct = 0;
            int fr = maxlimit;
            int rcount = ds.Tables[0].Rows.Count;
            int tab2count = ds.Tables[1].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;

            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }


            if (edition != "0")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (browser.Browser == "Firefox")
                    {
                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                        if ((ver == 7.0) || (ver == 8.0))
                        {
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                        }
                        else if (ver == 6.0)
                        {
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                        }
                    }
                    // tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

                    for (int p = 0; p < pagecount; p++)
                    {
                        int s = p + 1;
                        if (browser.Browser == "Firefox")
                        {
                            tbl.Append("</table></P>");

                            if (p == pagecount - 1)
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                        }
                        else if (browser.Browser == "IE")
                        {
                            {
                                if ((ver == 8.0) || (ver == 7.0))
                                {

                                    if (p != 0)
                                    {
                                        tbl.Append("</table></P>");
                                        if (p == pagecount - 1)
                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                    }
                                }
                                else if (ver == 6.0)
                                {
                                    tbl.Append("</table>");
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)
                                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                    }
                                }
                            }
                        }



                        //tbl.Append( "</table>";

                        // tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                        if (p == 0)
                            tbl.Append(tblhdr.ToString());
                        tbl.Append("<tr valign='top'>");
                        tbl.Append("<tr>");
                        tbl.Append("<td class='middle111' align='right' colspan='19'>" + "Page  " + s + "  of  " + pagecount);
                        tbl.Append("</td></tr>");
                        tbl.Append("<td class='middle31new'   align='center'>" + "S.No." + "</td>");
                        tbl.Append("<td class='middle31new'  align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                        tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                        tbl.Append("<td class='middle31new'  align='left'>" + "Client" + "</td>");

                        if (edition != "0")
                        {
                            tbl.Append("<td class='middle31new' width='9%' align='left'>" + "Package" + "</td>");

                        }
                        tbl.Append("<td class='middle31new' align='left' >" + "Edition" + "</td>");
                        tbl.Append("<td class='middle31new'   align='left'>" + "RONo." + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Publish" + "</br>" + "Date" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "WD" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left' >" + "Color" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                        if (edition != "0")
                        {
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                        }

                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");



                        tbl.Append("</tr>");
                        for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                        {
                            int a = d;
                            a = a + 1;
                            if (d > 0)//for adcat total
                            {
                                if ((ds.Tables[0].Rows[d]["edition"].ToString() != ds.Tables[0].Rows[d - 1]["edition"].ToString()))
                                {

                                    arr1[0] = 0;
                                    for (int j11 = dd2; j11 < i1 - 1; j11++)
                                    {
                                        if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                                        {
                                            arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                                        }

                                        else
                                        {
                                            arr1[0] = arr1[0] + 0;
                                        }

                                    }
                                    int cnt = Convert.ToInt32(i1 - 1) - dd2;
                                    dd2 = Convert.ToInt32(i1 - 1);

                                    cnt3 = cnt - cnt3;//paid

                                    //   tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                                    tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td></tr>");

                                    cnt1 = 0;//line
                                    cnt2 = 0;//size
                                    cnt3 = 0;//paid
                                    cnt4 = 0;//fmg
                                    cnt5 = 0; //house ads  
                                    tempsqcm = 0;
                                    tempcolcm = 0;
                                    tempother = 0;
                                    temptotcc = 0;
                                    temptotcd = 0;
                                    temptotrol = 0;
                                    tempareaset = 0;
                                    temptotaudit = 0;
                                    temptotunaudit = 0;
                                    /////////////////NEW ADDED

                                }

                            }//for adcat total
                            tbl.Append("<tr >");
                            tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                            tbl.Append(i1++.ToString() + "</td>");

                            //-------------------------------------------//
                            string cioid1 = "";
                            string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                            char[] cioid = rrr.ToCharArray();
                            int len11 = cioid.Length;

                            for (int ch = 0; ch < len11; ch++)
                            {

                                if (ch == 0)
                                {
                                    cioid1 = cioid1 + cioid[ch];
                                }
                                else if (ch % 10 != 0)
                                {
                                    cioid1 = cioid1 + cioid[ch];
                                }
                                else
                                {
                                    cioid1 = cioid1 + "</br>" + cioid[ch];
                                }
                            }

                            //----------------------------------------------------------------///

                            tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                            tbl.Append(cioid1 + "</td>");


                            tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                            //-------------------------------------------//






                            string Agency1 = "";
                            string Agency11 = "";
                            string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                            char[] Agency = AA.ToCharArray();
                            int len12 = Agency.Length;
                            int line1 = 0;

                            for (int ch = 0; ch < len12; ch++)
                            {
                                if (Agency[ch] == ' ')
                                {
                                    Agency1 = AA.Replace(" ", "_");
                                }
                                else
                                {
                                    Agency1 = AA;
                                }
                            }
                            char[] AA1 = Agency1.ToCharArray();

                            for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                            {

                                if (ch == 0)
                                {
                                    Agency11 = Agency11 + Agency[ch];
                                }
                                else if (ch % 11 != 0)
                                {
                                    Agency11 = Agency11 + Agency[ch];
                                }
                                else
                                {

                                    line1 = line1 + 1;
                                    if (line1 != 2)
                                    {
                                        Agency11 = Agency11 + "</br>" + Agency[ch];
                                    }

                                }
                            }
                            //---------------------------------------------//
                            tbl.Append(Agency11 + "</td>");

                            tbl.Append("<td class='rep_data'  align='left' width='14%'>");
                            string Client1 = "";
                            string Client11 = "";
                            string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                            char[] Client = BB.ToCharArray();
                            int len13 = Client.Length;
                            int line2 = 0;

                            for (int ch = 0; ch < len13; ch++)
                            {
                                if (Client[ch] == ' ')
                                {
                                    Client1 = BB.Replace(" ", "_");
                                }
                                else
                                {
                                    Client1 = BB;
                                }
                            }
                            char[] BB1 = Client1.ToCharArray();

                            for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                            {

                                if (ch == 0)
                                {
                                    Client11 = Client11 + BB1[ch];
                                }
                                else if (ch % 14 != 0)
                                {
                                    Client11 = Client11 + BB1[ch];
                                }
                                else
                                {

                                    line2 = line2 + 1;
                                    if (line2 != 2)
                                    {
                                        Client11 = Client11 + "</br>" + BB1[ch];
                                    }
                                    // Agency1 = Agency1 + "</br>" + Agency[ch];
                                }
                            }
                            //---------------------------------------------//
                            // tbl.Append( (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                            tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                            if (edition != "0")
                            {
                                tbl.Append("<td class='rep_data' align='left' width='10%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                            }

                            tbl.Append("<td class='rep_data' align='left' width='12%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["edition"] + "</td>");


                            tbl.Append("<td  class='rep_data' align='left' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");

                            if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                            {
                                area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                {

                                    areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                                else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                {
                                    totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                                else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                {
                                    totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                                else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                {
                                    totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                            }

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                            if (edition != "0")
                            {
                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                            }


                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                            if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                            {
                                tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                totaudit = totaudit + 1;
                                temptotaudit = temptotaudit + 1;
                            }
                            else
                            {
                                tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                totunaudit = totunaudit + 1;
                                temptotunaudit = temptotunaudit + 1;
                            }

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");

                            //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                            //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");

                            //if (ds.Tables[0].Rows[d]["Paidins"].ToString() != "")
                            //    paidins = paidins + Convert.ToInt32(ds.Tables[0].Rows[d]["Paidins"]);


                            // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                            if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                            {

                                count1++;

                                cnt4++;

                            }
                            // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                            if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                            {
                                count2++;

                                cnt5++;

                            }
                            // count2 = count2++;
                            if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                            {
                                if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                {
                                    count3++;

                                    cnt1++;

                                }
                                else
                                {
                                    count31++;

                                    cnt2++;

                                }
                            }
                            paidins = ((i1 - 1) - (count1 + count2));

                            cnt3 = cnt4 + cnt5;

                            tbl.Append("</tr>");
                        }
                        ct = ct + maxlimit;
                        fr = fr + maxlimit;


                    }
                    //  tbl.Append( "<tr><td class='middle31new'colspan='20'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                    tbl.Append("<tr><td class='middle31new'colspan='20'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td></tr>");

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

                    //   tbl.Append( "</table>";

                    div1.Visible = true;
                    div1.InnerHtml = tbl.ToString();
                }
            }
            /////////////new changes 26 nov
            else
            {
                if (pubcentcode != "0")
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";
                        if (browser.Browser == "Firefox")
                        {
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                        }
                        else if (browser.Browser == "IE")
                        {
                            if ((ver == 7.0) || (ver == 8.0))
                            {
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                            else if (ver == 6.0)
                            {
                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                        }
                        //  for (int p = 0; p < tab3; p++)
                        for (int p = 0; p < pagecount; p++)
                        {


                            int s = p + 1;
                            if (browser.Browser == "Firefox")
                            {
                                tbl.Append("</table></P>");

                                if (p == pagecount - 1)
                                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                else
                                    tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                            }
                            else if (browser.Browser == "IE")
                            {
                                if ((ver == 8.0) || (ver == 7.0))
                                {
                                    tbl.Append("</table></P>");

                                    if (p == pagecount - 1)
                                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    else
                                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");


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




                            //tbl.Append( "</table>";
                            //  tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break' >";
                            if (p == 0)
                                tbl.Append(tblhdr.ToString());


                            tbl.Append("<tr valign='top'>");
                            tbl.Append("<tr>");
                            tbl.Append("<td class='middle111' align='right' colspan='19'>" + "Page  " + s + "  of  " + pagecount);
                            tbl.Append("</td></tr>");


                            tbl.Append("<td class='middle31new'   align='center'>" + "S.No." + "</td>");
                            tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                            tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                            tbl.Append("<td class='middle31new'  align='left'>" + "Client" + "</td>");

                            if (edition != "0")
                            {
                                tbl.Append("<td class='middle31new'  align='left'>" + "Package" + "</td>");

                            }
                            tbl.Append("<td class='middle31new'  align='left'  >" + "Edition" + "</td>");
                            tbl.Append("<td class='middle31new'  align='left' >" + "RONo." + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Publish" + "</br>" + "Date" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "WD" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left' >" + "Color" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                            if (edition != "0")
                            {
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                            }

                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");



                            tbl.Append("</tr>");




                            for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                            {

                                int a = d;
                                a = a + 1;
                                if (d > 0)//for adcat total
                                {
                                    if ((ds.Tables[0].Rows[d]["edition"].ToString() != ds.Tables[0].Rows[d - 1]["edition"].ToString()) || (d == cont - 1))
                                    {
                                        if (d == cont - 1)
                                        {
                                            //  tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                            tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");


                                            tbl.Append("</tr>");
                                            cnt1 = 0;//line
                                            cnt2 = 0;//size
                                            cnt3 = 0;//paid
                                            cnt4 = 0;//fmg
                                            cnt5 = 0; //house ads  
                                            tempsqcm = 0;
                                            tempcolcm = 0;
                                            tempother = 0;
                                            temptotcc = 0;
                                            temptotcd = 0;
                                            temptotrol = 0;
                                            tempareaset = 0;
                                            temprowcnt = 0;
                                            temptotaudit = 0;
                                            temptotunaudit = 0;
                                        }
                                        else
                                        {
                                            nontot = 1;
                                            //  tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                            //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                            tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");

                                            tbl.Append("</tr>");

                                            cnt1 = 0;//line
                                            cnt2 = 0;//size
                                            cnt3 = 0;//paid
                                            cnt4 = 0;//fmg
                                            cnt5 = 0; //house ads  
                                            tempsqcm = 0;
                                            tempcolcm = 0;
                                            tempother = 0;
                                            temptotcc = 0;
                                            temptotcd = 0;
                                            temptotrol = 0;
                                            tempareaset = 0;
                                            temprowcnt = 0;
                                            temptotaudit = 0;
                                            temptotunaudit = 0;
                                            /////////////////NEW ADDED
                                        }
                                    }

                                }//for adcat total
                                temprowcnt++;
                                tbl.Append("<tr >");
                                tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                                tbl.Append(i1++.ToString() + "</td>");

                                //-------------------------------------------//
                                string cioid1 = "";
                                string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                                char[] cioid = rrr.ToCharArray();
                                int len11 = cioid.Length;

                                for (int ch = 0; ch < len11; ch++)
                                {

                                    if (ch == 0)
                                    {
                                        cioid1 = cioid1 + cioid[ch];
                                    }
                                    else if (ch % 10 != 0)
                                    {
                                        cioid1 = cioid1 + cioid[ch];
                                    }
                                    else
                                    {
                                        cioid1 = cioid1 + "</br>" + cioid[ch];
                                    }
                                }
                                //----------------------------------------------------------------///

                                tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                                //tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                                tbl.Append(cioid1 + "</td>");


                                tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                                //-------------------------------------------//
                                string Agency1 = "";
                                string Agency11 = "";
                                string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                                char[] Agency = AA.ToCharArray();
                                int len12 = Agency.Length;
                                int line1 = 0;

                                for (int ch = 0; ch < len12; ch++)
                                {
                                    if (Agency[ch] == ' ')
                                    {
                                        Agency1 = AA.Replace(" ", "_");
                                    }
                                    else
                                    {
                                        Agency1 = AA;
                                    }
                                }
                                char[] AA1 = Agency1.ToCharArray();

                                for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                                {

                                    if (ch == 0)
                                    {
                                        Agency11 = Agency11 + Agency[ch];
                                    }
                                    else if (ch % 11 != 0)
                                    {
                                        Agency11 = Agency11 + Agency[ch];
                                    }
                                    else
                                    {

                                        line1 = line1 + 1;
                                        if (line1 != 2)
                                        {
                                            Agency11 = Agency11 + "</br>" + Agency[ch];
                                        }

                                    }
                                }
                                //---------------------------------------------//
                                tbl.Append(Agency11 +/*"</br>" + ds.Tables[0].Rows[d]["Spl Instruction"]+*/"</td>");

                                tbl.Append("<td class='rep_data'  align='left' width='14%'>");
                                string Client1 = "";
                                string Client11 = "";
                                string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                                char[] Client = BB.ToCharArray();
                                int len13 = Client.Length;
                                int line2 = 0;

                                for (int ch = 0; ch < len13; ch++)
                                {
                                    if (Client[ch] == ' ')
                                    {
                                        Client1 = BB.Replace(" ", "_");
                                    }
                                    else
                                    {
                                        Client1 = BB;
                                    }
                                }
                                char[] BB1 = Client1.ToCharArray();

                                for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                                {

                                    if (ch == 0)
                                    {
                                        Client11 = Client11 + BB1[ch];
                                    }
                                    else if (ch % 14 != 0)
                                    {
                                        Client11 = Client11 + BB1[ch];
                                    }
                                    else
                                    {

                                        line2 = line2 + 1;
                                        if (line2 != 2)
                                        {
                                            Client11 = Client11 + "</br>" + BB1[ch];
                                        }

                                    }
                                }
                                //---------------------------------------------//
                                tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td class='rep_data' align='left' width='9%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                                }

                                tbl.Append("<td class='rep_data' align='left' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["edition"] + "</td>");


                                tbl.Append("<td class='rep_data' align='left' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");

                                tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");
                                if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                {
                                    area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                    area1 = area1 + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                    if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                    {

                                        areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                    {
                                        totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                    {
                                        totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                    {
                                        totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                                if (edition != "0")
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                                }


                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");


                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%' align='left'>");
                                if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                                {
                                    tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                    totaudit = totaudit + 1;
                                    temptotaudit = temptotaudit + 1;
                                }
                                else
                                {
                                    tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                    totunaudit = totunaudit + 1;
                                    temptotunaudit = temptotunaudit + 1;
                                }
                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");

                                //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");

                                // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                                if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                                {

                                    count1++;
                                    cnt4++;

                                }
                                // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                                if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                                {
                                    count2++;
                                    cnt5++;

                                }
                                if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                                {
                                    if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                    {
                                        count3++;
                                        cnt1++;

                                    }
                                    else
                                    {
                                        count31++;
                                        cnt2++;

                                    }
                                }
                                paidins = ((i1 - 1) - (count1 + count2));

                                cnt3 = temprowcnt - (cnt4 + cnt5);


                                if (d == cont - 1 && cont > 1 && nontot == 1)
                                {
                                    //tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                    //  tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                    tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");


                                    tbl.Append("</tr>");
                                }


                                tbl.Append("</tr>");

                            }

                            ct = ct + maxlimit;
                            fr = fr + maxlimit;

                        }
                        //  tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + count2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                        // tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td>");
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
                        // tbl.Append( "</table>";
                        div1.Visible = true;
                        div1.InnerHtml = tbl.ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                    }
                }

    ///////to change
                else
                {
                    if (pkgdetail == "0")
                    {
                        int count_pg = 0;
                        int tab3 = ds.Tables[3].Rows.Count;
                        int ct1 = 0;
                        //int cont = ds.Tables[0].Rows.Count;
                        int sq2 = 0;

                        int sq = 0;
                        int counter = 0;
                        int get = 0;

                        int sq1 = 0;

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

                            if (browser.Browser == "Firefox")
                            {
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                            else if (browser.Browser == "IE")
                            {
                                if ((ver == 7.0) || (ver == 8.0))
                                {
                                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                                else if (ver == 6.0)
                                {
                                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                            }
                            for (int p = 0; p < tab3; p++)
                            {

                                //comes here
                                sq = Convert.ToInt32(ds.Tables[3].Rows[p].ItemArray[1].ToString());

                                sq1 = sq + ct1;

                                ///////////////////////new
                                int s = p + 1;
                                if (p == 0)
                                {
                                    if (browser.Browser == "Firefox")
                                    {
                                        tbl.Append("</table></P>");

                                        if (p == pagecount - 1)
                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                    }
                                    else if (browser.Browser == "IE")
                                    {
                                        if ((ver == 8.0) || (ver == 7.0))
                                        {


                                            //if (p == pagecount - 1 ||p==0)

                                            tbl.Append("</table></P>");
                                            //   tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                            //else

                                            //    tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");


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
                                }

                                //  tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                                tbl.Append("<tr valign='top'>");
                                if (p > 0)
                                {
                                    if (p == tab3)
                                    {

                                        if (ds.Tables[3].Rows[p].ItemArray[0].ToString() == ds.Tables[3].Rows[p - 1].ItemArray[0].ToString())
                                        {
                                            counter++;
                                            get = counter + 1;
                                            // nontot = 1;

                                        }
                                        else
                                        {
                                            counter = 0;
                                        }

                                        sq2 = Convert.ToInt32(ds.Tables[3].Rows[p - 1].ItemArray[1].ToString());
                                        cnt3 = sq2 - cnt3;//paid


                                        //tbl.Append( ("<tr><td class='middle31new'colspan='2'>TotalAds:" + sq2.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + area1.ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2' >Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2' >Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='3'>Date:" + tab4date.ToString() + "</td></tr>");

                                        //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");

                                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp" + DateTime.Now.ToString() + "</td></tr>");
                                        editot = editot + sq2;
                                        totar = totar + tempareaset;
                                        patot = patot + cnt3;
                                        fmtot = fmtot + cnt4;
                                        lntot = lntot + temptotrol;
                                        chtot = chtot + temptotcd;
                                        wrdtot = wrdtot + temptotcc;
                                        autot = autot + temptotaudit;
                                        untot = untot + temptotunaudit;


                                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + editot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + totar.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + patot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + fmtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + lntot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + chtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + wrdtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + autot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + untot.ToString() + "&nbsp;&nbsp;&nbsp" + DateTime.Now.ToString() + "</td></tr>");
                                        if (counter > 0)
                                        {
                                            tbl.Append("<tr><td colspan='18' align='right'><b>continue to page" + get + "... </b></td></tr>");
                                            count_pg = 1;
                                        }

                                        cnt1 = 0;//line
                                        cnt2 = 0;//size
                                        cnt3 = 0;//paid
                                        cnt4 = 0;//fmg
                                        cnt5 = 0; //house ads 
                                        area1 = 0;
                                        tempsqcm = 0;
                                        tempcolcm = 0;
                                        tempother = 0;
                                        temptotcc = 0;
                                        temptotcd = 0;
                                        temptotrol = 0;
                                        tempareaset = 0;
                                        temptotunaudit = 0;
                                        temptotaudit = 0;

                                    }
                                    else
                                    {
                                        nontot = 1;
                                        if (ds.Tables[3].Rows[p].ItemArray[0].ToString() == ds.Tables[3].Rows[p - 1].ItemArray[0].ToString())
                                        {
                                            counter++;
                                            get = counter + 1;

                                        }
                                        else
                                        {
                                            counter = 0;
                                        }


                                        sq2 = Convert.ToInt32(ds.Tables[3].Rows[p - 1].ItemArray[1].ToString());
                                        cnt3 = sq2 - cnt3;//paid
                                        /////////////////NEW ADDED
                                        //tbl.Append( ("<tr><td class='middle31new'colspan='2'>TotalAds:" + sq2.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + area1.ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2' >Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2' >Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='3'>Date:" + tab4date.ToString() + "</td></tr>");
                                        //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp" + DateTime.Now.ToString() + "</td></tr>");
                                        editot = editot + sq2;
                                        totar = totar + tempareaset;
                                        patot = patot + cnt3;
                                        fmtot = fmtot + cnt4;
                                        lntot = lntot + temptotrol;
                                        chtot = chtot + temptotcd;
                                        wrdtot = wrdtot + temptotcc;
                                        autot = autot + temptotaudit;
                                        untot = untot + temptotunaudit;


                                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + editot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td></tr>");

                                        if (counter > 0)
                                        {
                                            tbl.Append("<tr><td colspan='18' align='right'><b>continue to page" + get + "... </b></td></tr>");
                                            count_pg = 1;
                                        }

                                        cnt1 = 0;//line
                                        cnt2 = 0;//size
                                        cnt3 = 0;//paid
                                        cnt4 = 0;//fmg
                                        cnt5 = 0; //house ads 
                                        area1 = 0;
                                        tempsqcm = 0;
                                        tempcolcm = 0;
                                        tempother = 0;
                                        temptotcc = 0;
                                        temptotcd = 0;
                                        temptotrol = 0;
                                        tempareaset = 0;
                                        temptotaudit = 0;
                                        temptotunaudit = 0;

                                    }


                                }
                                //////change here
                                if (browser.Browser == "Firefox")
                                {

                                    tbl.Append("</table></P>");
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)

                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center'    valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    }
                                }
                                else if (browser.Browser == "IE")
                                {
                                    if ((ver == 8.0) || (ver == 7.0))
                                    {




                                        tbl.Append("</table></P>");
                                        if (p == pagecount)
                                        {
                                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center'   valign='top'>");
                                        }
                                        else
                                        {
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            //count_pg = 0;
                                        }


                                    }
                                    else if (ver == 6.0)
                                    {
                                        tbl.Append("</table>");
                                        if (p != 0)
                                        {
                                            if (p == pagecount - 1)
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center'   valign='top'>");
                                            else
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                        }
                                    }
                                }

                                //tbl.Append( "</table>";

                                //tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                                tbl.Append(tblhdr.ToString());

                                tbl.Append("<tr>");
                                tbl.Append("<td class='middle111' align='right' colspan='18'>" + "Page  " + s + "  of  " + tab3);
                                tbl.Append("</td></tr>");
                                tbl.Append("<td class='middle31new'   align='center'>" + "S.No." + "</td>");
                                tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left'>" + "Client" + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td class='middle31new'  align='left'>" + "Package" + "</td>");

                                }
                                tbl.Append("<td class='middle31new'  align='left'  >" + "Edition" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left' >" + "RONo." + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Publish" + "</br>" + "Date" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "WD" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left' >" + "Color" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");



                                tbl.Append("</tr>");



                                for (int d = ct1; d < ds.Tables[0].Rows.Count && d < sq1; d++)
                                {

                                    int a = d;
                                    a = a + 1;

                                    tbl.Append("<tr >");
                                    tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                                    tbl.Append(i1++.ToString() + "</td>");

                                    //-------------------------------------------//
                                    string cioid1 = "";
                                    string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                                    char[] cioid = rrr.ToCharArray();
                                    int len11 = cioid.Length;

                                    for (int ch = 0; ch < len11; ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else if (ch % 10 != 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else
                                        {
                                            cioid1 = cioid1 + "</br>" + cioid[ch];
                                        }
                                    }
                                    //----------------------------------------------------------------///

                                    tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                                    tbl.Append(cioid1 + "</td>");


                                    tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                                    //-------------------------------------------//
                                    string Agency1 = "";
                                    string Agency11 = "";
                                    string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                                    char[] Agency = AA.ToCharArray();
                                    int len12 = Agency.Length;
                                    int line1 = 0;

                                    for (int ch = 0; ch < len12; ch++)
                                    {
                                        if (Agency[ch] == ' ')
                                        {
                                            Agency1 = AA.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Agency1 = AA;
                                        }
                                    }
                                    char[] AA1 = Agency1.ToCharArray();

                                    for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else if (ch % 11 != 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else
                                        {

                                            line1 = line1 + 1;
                                            if (line1 != 2)
                                            {
                                                Agency11 = Agency11 + "</br>" + Agency[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Agency11 +/*"</br>" + ds.Tables[0].Rows[d]["Spl Instruction"]+*/"</td>");

                                    tbl.Append("<td class='rep_data'  align='left' width='14%'>");
                                    string Client1 = "";
                                    string Client11 = "";
                                    string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                                    char[] Client = BB.ToCharArray();
                                    int len13 = Client.Length;
                                    int line2 = 0;

                                    for (int ch = 0; ch < len13; ch++)
                                    {
                                        if (Client[ch] == ' ')
                                        {
                                            Client1 = BB.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Client1 = BB;
                                        }
                                    }
                                    char[] BB1 = Client1.ToCharArray();

                                    for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else if (ch % 14 != 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else
                                        {

                                            line2 = line2 + 1;
                                            if (line2 != 2)
                                            {
                                                Client11 = Client11 + "</br>" + BB1[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                                    if (edition != "0")
                                    {
                                        tbl.Append("<td class='rep_data' align='left' width='9%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                                    }

                                    tbl.Append("<td class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["edition"] + "</td>");


                                    tbl.Append("<td class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");

                                    tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");
                                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                    {
                                        area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                        area1 = area1 + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                        if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                        {

                                            areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                        {
                                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                        {
                                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                        {
                                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                                    if (edition != "0")
                                    {
                                        tbl.Append("<td  style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                                    }


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                                    if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                                    {
                                        tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totaudit = totaudit + 1;
                                        temptotaudit = temptotaudit + 1;
                                    }
                                    else
                                    {
                                        tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totunaudit = totunaudit + 1;
                                        temptotunaudit = temptotunaudit + 1;
                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");
                                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");
                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");

                                    // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                                    {

                                        count1++;
                                        cnt4++;

                                    }
                                    //  if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                                    {
                                        count2++;
                                        cnt5++;

                                    }
                                    if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                                    {
                                        if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                        {
                                            count3++;
                                            cnt1++;

                                        }
                                        else
                                        {
                                            count31++;
                                            cnt2++;

                                        }
                                    }
                                    paidins = ((i1 - 1) - (count1 + count2));

                                    cnt3 = cnt4 + cnt5;

                                    if (d == cont - 1 && cont > 1 && nontot == 1)
                                    {
                                        sq2 = Convert.ToInt32(ds.Tables[3].Rows[p].ItemArray[1].ToString());
                                        cnt3 = sq2 - cnt3;//paid
                                        //  tbl.Append( ("<tr><td class='middle31new'colspan='2'>TotalAds:" + sq2.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + area1.ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2' >Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2' >Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='4'>Date:" + tab4date.ToString() + "</td></tr>");
                                        //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp" + DateTime.Now.ToString() + "</td></tr>");
                                        edichtot = edichtot + sq2;
                                        totchar = totchar + tempareaset;
                                        pachtot = pachtot + cnt3;
                                        fmchtot = fmchtot + cnt4;
                                        lnchtot = lnchtot + temptotrol;
                                        chchtot = chchtot + temptotcd;
                                        wrdchtot = wrdchtot + temptotcc;
                                        auchtot = auchtot + temptotaudit;
                                        unchtot = unchtot + temptotunaudit;

                                        //  tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + edichtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + totchar.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + pachtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + fmchtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + lnchtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + chchtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + wrdchtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + auchtot.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + unchtot.ToString() + "&nbsp;&nbsp;&nbsp" + DateTime.Now.ToString() + "</td></tr>");


                                    }


                                    tbl.Append("</tr>");

                                }

                                ct1 = ct1 + sq;//old

                            }
                            // tbl.Append( "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                            // tbl.Append( ("<tr><td class='middle31' colspan='2'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle3' colspan='2'>TotalArea:" + area.ToString() + "</td><td class='middle31'>Line/Word:" + count3.ToString() + "</td><td id='tdag~3' class='middle3'>&nbsp;</td><td id='tdcli~4' class='middle3' colspan='3'>Paid :" + paidins.ToString() + "</td><td id='tdpac~5' class='middle3'>Fmg:" + count1.ToString() + "</td><td id='tdro~29' class='middle3' colspan='3'>HouseAd:" + count2.ToString() + "</td><td id='tdro~26' class='middle3' colspan='4'>Date:" + tab4date.ToString() + "</td></tr>"); //<td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td>
                            //  tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                            tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp" + DateTime.Now.ToString() + "</td></tr>");

                            //change here         

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

                            // tbl.Append( "</table>";

                            div1.Visible = true;
                            div1.InnerHtml = tbl.ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                        }
                    }
                    else
                    {


                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //change here  
                            if (browser.Browser == "Firefox")
                            {
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                            else if (browser.Browser == "IE")
                            {
                                if ((ver == 7.0) || (ver == 8.0))
                                {
                                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                                else if (ver == 6.0)
                                {
                                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                            }
                            // tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";


                            for (int p = 0; p < pagecount; p++)
                            {
                                int s = p + 1;
                                if (browser.Browser == "Firefox")
                                {
                                    tbl.Append("</table></P>");
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)
                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    }
                                }
                                else if (browser.Browser == "IE")
                                {
                                    if ((ver == 8.0) || (ver == 7.0))
                                    {

                                        if (p != 0)
                                        {
                                            tbl.Append("</table></P>");
                                            if (p == pagecount - 1)
                                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            else
                                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                        }
                                    }
                                    else if (ver == 6.0)
                                    {
                                        tbl.Append("</table>");
                                        if (p != 0)
                                        {
                                            if (p == pagecount - 1)
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            else
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                        }
                                    }
                                }


                                // tbl.Append( "</table>";

                                //tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";

                                //tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                                if (p == 0)
                                    tbl.Append(tblhdr.ToString());
                                tbl.Append("<tr valign='top'>");

                                tbl.Append("<tr>");
                                tbl.Append("<td class='middle111' align='right' colspan='18'>" + "Page  " + s + "  of  " + pagecount);
                                tbl.Append("</td></tr>");
                                tbl.Append("<td class='middle31new'  align='center'>" + "S.No." + "</td>");
                                tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left'>" + "Client" + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td class='middle31new'  align='left'>" + "Package" + "</td>");

                                }

                                tbl.Append("<td class='middle31new'  align='left' >" + "RONo." + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Publish" + "</br>" + "Date" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "WD" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left' >" + "Color" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");

                                tbl.Append("</tr>");



                                //for (int d = ct1; d < ds.Tables[0].Rows.Count && d < sq1; d++)
                                //{
                                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                                {
                                    int a = d;
                                    a = a + 1;

                                    tbl.Append("<tr >");
                                    tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                                    tbl.Append(i1++.ToString() + "</td>");

                                    //-------------------------------------------//
                                    string cioid1 = "";
                                    string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                                    char[] cioid = rrr.ToCharArray();
                                    int len11 = cioid.Length;

                                    for (int ch = 0; ch < len11; ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else if (ch % 10 != 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else
                                        {
                                            cioid1 = cioid1 + "</br>" + cioid[ch];
                                        }
                                    }
                                    //----------------------------------------------------------------///

                                    tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                                    tbl.Append(cioid1 + "</td>");


                                    tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                                    //-------------------------------------------//
                                    string Agency1 = "";
                                    string Agency11 = "";
                                    string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                                    char[] Agency = AA.ToCharArray();
                                    int len12 = Agency.Length;
                                    int line1 = 0;

                                    for (int ch = 0; ch < len12; ch++)
                                    {
                                        if (Agency[ch] == ' ')
                                        {
                                            Agency1 = AA.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Agency1 = AA;
                                        }
                                    }
                                    char[] AA1 = Agency1.ToCharArray();

                                    for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else if (ch % 11 != 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else
                                        {

                                            line1 = line1 + 1;
                                            if (line1 != 2)
                                            {
                                                Agency11 = Agency11 + "</br>" + Agency[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Agency11 + "</td>");

                                    tbl.Append("<td class='rep_data'  align='left' width='8%'>");
                                    string Client1 = "";
                                    string Client11 = "";
                                    string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                                    char[] Client = BB.ToCharArray();
                                    int len13 = Client.Length;
                                    int line2 = 0;

                                    for (int ch = 0; ch < len13; ch++)
                                    {
                                        if (Client[ch] == ' ')
                                        {
                                            Client1 = BB.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Client1 = BB;
                                        }
                                    }
                                    char[] BB1 = Client1.ToCharArray();

                                    for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else if (ch % 14 != 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else
                                        {

                                            line2 = line2 + 1;
                                            if (line2 != 2)
                                            {
                                                Client11 = Client11 + "</br>" + BB1[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                                    if (edition != "0")
                                    {
                                        tbl.Append("<td class='rep_data' align='left' width='9%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                                    }

                                    //tbl.Append( ("<td class='rep_data' align='left' width='8%'>");
                                    //tbl.Append( (ds.Tables[0].Rows[d]["edition"] + "</td>");


                                    tbl.Append("<td class='rep_data' align='left' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");

                                    tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");
                                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                    {
                                        area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                        area1 = area1 + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                        if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                        {

                                            areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                        {
                                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                        {
                                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                        {
                                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                                    tbl.Append("<td  style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                                    if (edition != "0")
                                    {
                                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                                    }


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                                    if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                                    {
                                        tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totaudit = totaudit + 1;
                                        temptotaudit = temptotaudit + 1;
                                    }
                                    else
                                    {
                                        tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totunaudit = totunaudit + 1;
                                        temptotunaudit = temptotunaudit + 1;
                                    }

                                    tbl.Append("<td  style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");

                                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");
                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");
                                    //if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                                    {

                                        count1++;
                                        cnt4++;

                                    }
                                    // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                                    {
                                        count2++;
                                        cnt5++;

                                    }
                                    if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                                    {
                                        if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                        {
                                            count3++;
                                            cnt1++;

                                        }
                                        else
                                        {
                                            count31++;
                                            cnt2++;

                                        }
                                    }
                                    paidins = ((i1 - 1) - (count1 + count2));

                                    cnt3 = cnt4 + cnt5;

                                    tbl.Append("</tr>");

                                }


                                ct = ct + maxlimit;
                                fr = fr + maxlimit;


                            }
                            // tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                            tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td></tr>");

                            // tbl.Append( "</table>";
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

                            div1.Visible = true;
                            div1.InnerHtml = tbl.ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                        }
                    }
                }

            }

            //////////////////////////////////////////new changes 26 nov

        }
        else
        {
            int i1 = 1;
            //string tbl.Append( "";
            StringBuilder tbl = new StringBuilder();
            int ct = 0;
            int fr = maxlimit;
            int rcount = ds.Tables[0].Rows.Count;
            cont1 = ds.Tables[1].Rows.Count;
            int pagec = rcount % maxlimit;
            int pagecount = rcount / maxlimit;
            if (pagec > 0)
            {
                pagecount = pagecount + 1;
            }
            if (edition != "0")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";
                    if (browser.Browser == "Firefox")
                    {
                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                        if ((ver == 7.0) || (ver == 8.0))
                        {
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                        }
                        else if (ver == 6.0)
                        {
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                        }
                    }
                    for (int p = 0; p < pagecount; p++)
                    {
                        int s = p + 1;

                        // tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";

                        //  tbl.Append( "</table>";
                        if (browser.Browser == "Firefox")
                        {
                            tbl.Append("</table></P>");
                            if (p != 0)
                            {
                                if (p == pagecount - 1)

                                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                else
                                    tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            }
                        }
                        else if (browser.Browser == "IE")
                        {
                            if ((ver == 8.0) || (ver == 7.0))
                            {
                                tbl.Append("</table></P>");
                                if (p != 0)
                                {
                                    if (p == pagecount - 1)
                                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    else
                                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                }
                            }
                            else if (ver == 6.0)
                            {
                                tbl.Append("</table>");
                                if (p != 0)
                                {
                                    if (p == pagecount - 1)
                                        tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    else
                                        tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                }
                            }
                        }


                        //  tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                        if (p == 0)
                            tbl.Append(tblhdr.ToString());
                        tbl.Append("<tr valign='top'>");
                        tbl.Append("<tr>");

                        tbl.Append("<td class='middle111' align='right' colspan='12'>");
                        for (int dsd = 0; dsd < cont1; dsd++)
                        {
                            tbl.Append("<td >&nbsp;</td>");
                        }
                        tbl.Append("<td class='middle111' align='right' colspan='6'>" + "Page  " + s + "  of  " + pagecount);
                        tbl.Append("</td >");
                        tbl.Append("</td></tr>");

                        tbl.Append("<td class='middle31new'    align='center'>" + "S.No." + "</td>");
                        tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                        tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                        tbl.Append("<td class='middle31new'  align='left'>" + "Client" + "</td>");
                        if (edition != "0")
                        {
                            tbl.Append("<td class='middle31new' align='left'>" + "Package" + "</td>");

                        }

                        tbl.Append("<td class='middle31new'  align='left'>" + "RONo." + "</td>");

                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "WD" + "</td>");
                        tbl.Append("<td  style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left' >" + "Color" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                        if (edition != "0")
                        {
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                        }

                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");

                        int edi;
                        for (edi = 0; edi < cont1; edi++)
                        {
                            tbl.Append("<td style=\"padding-left:4px\" class='edidetail'>");
                            tbl.Append(ds.Tables[1].Rows[edi]["Editions"] + "</td>");
                        }

                        tbl.Append("</tr>");


                        for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                        {
                            int a = d;
                            a = a + 1;
                            //if (d > 0)//for adcat total
                            //{
                            //    if ((ds.Tables[0].Rows[d]["edition"].ToString() != ds.Tables[0].Rows[d - 1]["edition"].ToString()) || (d==cont-1))
                            //    {
                            //        if (d == cont - 1)
                            //        {
                            //            arr1[0] = 0;
                            //            for (int j11 = dd2; j11 <= cont - 1; j11++)
                            //            {
                            //                if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                            //                {
                            //                    arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                            //                }

                            //                else
                            //                {
                            //                    arr1[0] = arr1[0] + 0;
                            //                }

                            //            }
                            //            cnt = Convert.ToInt32(cont) - dd2;

                            //            cnt3 = cnt - cnt3;//paid
                            //        }
                            //        else
                            //        {
                            //            arr1[0] = 0;
                            //            for (int j11 = dd2; j11 < i1 - 1; j11++)
                            //            {
                            //                if (ds.Tables[0].Rows[j11]["Area"].ToString() != "")
                            //                {
                            //                    arr1[0] = arr1[0] + Convert.ToDouble(ds.Tables[0].Rows[j11]["Area"].ToString());
                            //                }

                            //                else
                            //                {
                            //                    arr1[0] = arr1[0] + 0;
                            //                }

                            //            }
                            //            int cnt = Convert.ToInt32(i1 - 1) - dd2;
                            //            dd2 = Convert.ToInt32(i1 - 1);

                            //            cnt3 = cnt - cnt3;//paid
                            //            /////////////////NEW ADDED

                            //            tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");

                            //            for (int dsd = 0; dsd < cont1; dsd++)
                            //            {
                            //                tbl.Append( ("<td class='middle31new'colspan='2'>&nbsp;</td>");
                            //            }
                            //            tbl.Append( ("</tr>");

                            //            cnt1 = 0;//line
                            //            cnt2 = 0;//size
                            //            cnt3 = 0;//paid
                            //            cnt4 = 0;//fmg
                            //            cnt5 = 0; //house ads  
                            //            tempsqcm = 0;
                            //            tempcolcm = 0;
                            //            tempother = 0;
                            //            temptotcc = 0;
                            //            temptotcd = 0;
                            //            temptotrol = 0;
                            //            tempareaset = 0;
                            //            /////////////////NEW ADDED
                            //        }
                            //    }

                            //}//for adcat total
                            tbl.Append("<tr >");
                            tbl.Append("<td class='rep_data'  width='5%' align='center'>");
                            tbl.Append(i1++.ToString() + "</td>");

                            //-------------------------------------------//
                            string cioid1 = "";
                            string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                            char[] cioid = rrr.ToCharArray();
                            int len11 = cioid.Length;

                            for (int ch = 0; ch < len11; ch++)
                            {

                                if (ch == 0)
                                {
                                    cioid1 = cioid1 + cioid[ch];
                                }
                                else if (ch % 10 != 0)
                                {
                                    cioid1 = cioid1 + cioid[ch];
                                }
                                else
                                {
                                    cioid1 = cioid1 + "</br>" + cioid[ch];
                                }
                            }
                            //----------------------------------------------------------------///

                            tbl.Append("<td class='rep_data'  width='5%'>");
                            tbl.Append(cioid1 + "</td>");


                            tbl.Append("<td class='rep_data'  align='left' width='12%'>");
                            //-------------------------------------------//
                            string Agency1 = "";
                            string Agency11 = "";
                            string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                            char[] Agency = AA.ToCharArray();
                            int len12 = Agency.Length;
                            int line1 = 0;

                            for (int ch = 0; ch < len12; ch++)
                            {
                                if (Agency[ch] == ' ')
                                {
                                    Agency1 = AA.Replace(" ", "_");
                                }
                                else
                                {
                                    Agency1 = AA;
                                }
                            }
                            char[] AA1 = Agency1.ToCharArray();

                            for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                            {

                                if (ch == 0)
                                {
                                    Agency11 = Agency11 + Agency[ch];
                                }
                                else if (ch % 16 != 0)
                                {
                                    Agency11 = Agency11 + Agency[ch];
                                }
                                else
                                {

                                    line1 = line1 + 1;
                                    if (line1 != 2)
                                    {
                                        Agency11 = Agency11 + "</br>" + Agency[ch];
                                    }

                                }
                            }
                            //---------------------------------------------//
                            tbl.Append(Agency11 + "</td>");

                            tbl.Append("<td class='rep_data'  align='left' width='12%'>");
                            string Client1 = "";
                            string Client11 = "";
                            string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                            char[] Client = BB.ToCharArray();
                            int len13 = Client.Length;
                            int line2 = 0;

                            for (int ch = 0; ch < len13; ch++)
                            {
                                if (Client[ch] == ' ')
                                {
                                    Client1 = BB.Replace(" ", "_");
                                }
                                else
                                {
                                    Client1 = BB;
                                }
                            }
                            char[] BB1 = Client1.ToCharArray();

                            for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                            {

                                if (ch == 0)
                                {
                                    Client11 = Client11 + BB1[ch];
                                }
                                else if (ch % 16 != 0)
                                {
                                    Client11 = Client11 + BB1[ch];
                                }
                                else
                                {

                                    line2 = line2 + 1;
                                    if (line2 != 2)
                                    {
                                        Client11 = Client11 + "</br>" + BB1[ch];
                                    }

                                }
                            }
                            //---------------------------------------------//

                            tbl.Append(Client11 + "</td>");

                            if (edition != "0")
                            {
                                tbl.Append("<td class='rep_data' align='left' width='11%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Package"] + "</td>");
                            }


                            tbl.Append("<td class='rep_data' align='left' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");


                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");


                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");

                            if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                            {
                                area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);

                                if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                {

                                    areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                                else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                {
                                    totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                                else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                {
                                    totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                                else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                {
                                    totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                }
                            }

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");


                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                            if (edition != "0")
                            {
                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                            }


                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='6%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='9%' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  valign='top'  width='10%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%'>");
                            if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                            {
                                tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                totaudit = totaudit + 1;
                                temptotaudit = temptotaudit + 1;
                            }
                            else
                            {
                                tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                totunaudit = totunaudit + 1;
                                temptotunaudit = temptotunaudit + 1;
                            }

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");

                            //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                            //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");
                            for (int edi1 = 0; edi1 < cont1; edi1++)
                            {
                                if (ds.Tables[0].Rows[d]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Ins.date"].ToString() + "</td>");
                                }
                                else
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'></td>");
                                }
                            }



                            // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                            if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                            {

                                count1++;

                                cnt4++;

                            }
                            //if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                            if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                            {
                                count2++;

                                cnt5++;

                            }

                            if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                            {
                                if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                {
                                    count3++;

                                    cnt1++;

                                }
                                else
                                {
                                    count31++;

                                    cnt2++;

                                }
                            }
                            paidins = ((i1 - 1) - (count1 + count2));
                            if (d != cont - 1)
                            {
                                cnt3 = cnt4 + cnt5;
                            }
                            //if (edition == "0")
                            //{

                            //    if (d == cont - 1 && cont>1)
                            //    {
                            //        tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + cnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");

                            //        for (int dsd = 0; dsd < cont1; dsd++)
                            //        {
                            //            tbl.Append( ("<td class='middle31new'>&nbsp;</td>");
                            //        }
                            //        tbl.Append( ("</tr>");
                            //    }
                            //}

                            tbl.Append("</tr>");
                        }
                        ct = ct + maxlimit;
                        fr = fr + maxlimit;


                    }
                    //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                    tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td>");

                    for (int dsd = 0; dsd < cont1; dsd++)
                    {
                        tbl.Append("<td class='middle31new'colspan='2'>&nbsp;</td>");
                    }
                    tbl.Append("</tr>");
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

                    //  tbl.Append( "</table>";
                    div1.Visible = true;
                    div1.InnerHtml = tbl.ToString();
                }
                else
                {
                    Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                }
            }
            else
            {
                if (pubcentcode != "0")
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        // tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";
                        if (browser.Browser == "Firefox")
                        {
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                        }
                        else if (browser.Browser == "IE")
                        {
                            if ((ver == 7.0) || (ver == 8.0))
                            {
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                            else if (ver == 6.0)
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
                                if (p != 0)
                                {
                                    if (p == pagecount - 1)
                                        tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    else
                                        tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                }
                            }
                            else if (browser.Browser == "IE")
                            {
                                if ((ver == 8.0) || (ver == 7.0))
                                {
                                    tbl.Append("</table></P>");
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)
                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                    }
                                }
                                else if (ver == 6.0)
                                {
                                    tbl.Append("</table>");
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)
                                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                    }
                                }
                            }


                            // tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>");

                            //  tbl.Append( "</table>");
                            tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break' >");
                            if (p == 0)
                                tbl.Append(tblhdr.ToString());
                            tbl.Append("<tr valign='top'>");

                            tbl.Append("<tr>");

                            tbl.Append("<td class='middle111' align='right' colspan='12'>");
                            for (int dsd = 0; dsd < cont1; dsd++)
                            {
                                tbl.Append("<td >&nbsp;</td>");
                            }
                            tbl.Append("<td class='middle111' align='right' colspan='6'>" + "Page  " + s + "  of  " + pagecount);
                            tbl.Append("</td >");
                            tbl.Append("</td></tr>");


                            tbl.Append("<td class='middle31new'   align='center'>" + "S.No." + "</td>");
                            tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                            tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                            tbl.Append("<td class='middle31new'  align='left' >" + "Client" + "</td>");

                            if (edition != "0")
                            {
                                tbl.Append("<td class='middle31new'  align='left'>" + "Package" + "</td>");

                            }

                            tbl.Append("<td class='middle31new'  align='left' >" + "RONo." + "</td>");

                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "WD" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                            tbl.Append("<td  style=\"padding-left:4px\" class='middle31new'  align='left' >" + "Color" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                            if (edition != "0")
                            {
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                            }

                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                            tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");

                            int edi;
                            for (edi = 0; edi < cont1; edi++)
                            {
                                tbl.Append("<td style=\"padding-left:4px\" class='edidetail'>");
                                tbl.Append(ds.Tables[1].Rows[edi]["Editions"] + "</td>");
                            }

                            tbl.Append("</tr>");



                            for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                            {

                                int a = d;
                                a = a + 1;
                                //if (d > 0)//for adcat total
                                //{
                                //    if ((ds.Tables[0].Rows[d]["edition"].ToString() != ds.Tables[0].Rows[d - 1]["edition"].ToString()) || (d == cont - 1))
                                //    {
                                //        if (d == cont - 1)
                                //        {

                                //        }
                                //        else
                                //        {
                                //            nontot = 1;
                                //            tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");

                                //            for (int dsd = 0; dsd < cont1; dsd++)
                                //            {
                                //                tbl.Append( ("<td class='middle31new'>&nbsp;</td>");
                                //            }
                                //            tbl.Append( ("</tr>");

                                //            cnt1 = 0;//line
                                //            cnt2 = 0;//size
                                //            cnt3 = 0;//paid
                                //            cnt4 = 0;//fmg
                                //            cnt5 = 0; //house ads  
                                //            tempsqcm = 0;
                                //            tempcolcm = 0;
                                //            tempother = 0;
                                //            temptotcc = 0;
                                //            temptotcd = 0;
                                //            temptotrol = 0;
                                //            tempareaset = 0;
                                //            temprowcnt = 0;
                                //            /////////////////NEW ADDED
                                //        }
                                //    }

                                //}//for adcat total
                                temprowcnt++;
                                tbl.Append("<tr >");
                                tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                                tbl.Append(i1++.ToString() + "</td>");

                                //-------------------------------------------//
                                string cioid1 = "";
                                string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                                char[] cioid = rrr.ToCharArray();
                                int len11 = cioid.Length;

                                for (int ch = 0; ch < len11; ch++)
                                {

                                    if (ch == 0)
                                    {
                                        cioid1 = cioid1 + cioid[ch];
                                    }
                                    else if (ch % 10 != 0)
                                    {
                                        cioid1 = cioid1 + cioid[ch];
                                    }
                                    else
                                    {
                                        cioid1 = cioid1 + "</br>" + cioid[ch];
                                    }
                                }
                                //----------------------------------------------------------------///

                                tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                                //tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                                tbl.Append(cioid1 + "</td>");


                                tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                                //-------------------------------------------//
                                string Agency1 = "";
                                string Agency11 = "";
                                string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                                char[] Agency = AA.ToCharArray();
                                int len12 = Agency.Length;
                                int line1 = 0;

                                for (int ch = 0; ch < len12; ch++)
                                {
                                    if (Agency[ch] == ' ')
                                    {
                                        Agency1 = AA.Replace(" ", "_");
                                    }
                                    else
                                    {
                                        Agency1 = AA;
                                    }
                                }
                                char[] AA1 = Agency1.ToCharArray();

                                for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                                {

                                    if (ch == 0)
                                    {
                                        Agency11 = Agency11 + Agency[ch];
                                    }
                                    else if (ch % 11 != 0)
                                    {
                                        Agency11 = Agency11 + Agency[ch];
                                    }
                                    else
                                    {

                                        line1 = line1 + 1;
                                        if (line1 != 2)
                                        {
                                            Agency11 = Agency11 + "</br>" + Agency[ch];
                                        }

                                    }
                                }
                                //---------------------------------------------//
                                tbl.Append(Agency11 +/*"</br>" + ds.Tables[0].Rows[d]["Spl Instruction"]+*/"</td>");

                                tbl.Append("<td class='rep_data'  align='left' width='14%'>");
                                string Client1 = "";
                                string Client11 = "";
                                string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                                char[] Client = BB.ToCharArray();
                                int len13 = Client.Length;
                                int line2 = 0;

                                for (int ch = 0; ch < len13; ch++)
                                {
                                    if (Client[ch] == ' ')
                                    {
                                        Client1 = BB.Replace(" ", "_");
                                    }
                                    else
                                    {
                                        Client1 = BB;
                                    }
                                }
                                char[] BB1 = Client1.ToCharArray();

                                for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                                {

                                    if (ch == 0)
                                    {
                                        Client11 = Client11 + BB1[ch];
                                    }
                                    else if (ch % 14 != 0)
                                    {
                                        Client11 = Client11 + BB1[ch];
                                    }
                                    else
                                    {

                                        line2 = line2 + 1;
                                        if (line2 != 2)
                                        {
                                            Client11 = Client11 + "</br>" + BB1[ch];
                                        }

                                    }
                                }
                                //---------------------------------------------//
                                tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td class='rep_data' align='left' width='9%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                                }

                                //  tbl.Append( ("<td class='rep_data' align='left' width='8%'>");
                                //  tbl.Append( (ds.Tables[0].Rows[d]["edition"] + "</td>");


                                tbl.Append("<td class='rep_data' align='left' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                                // tbl.Append( ("<td class='rep_data' width='5%' align='left'>");
                                // tbl.Append( (ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");

                                if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                {
                                    area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                    area1 = area1 + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);

                                    if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                    {

                                        areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                    {
                                        totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                    {
                                        totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                    {
                                        totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                    }
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                                tbl.Append("<td  style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                                if (edition != "0")
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                                }


                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%'>");
                                if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                                {
                                    tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                    totaudit = totaudit + 1;
                                    temptotaudit = temptotaudit + 1;
                                }
                                else
                                {
                                    tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                    totunaudit = totunaudit + 1;
                                    temptotunaudit = temptotunaudit + 1;
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                tbl.Append(ds.Tables[0].Rows[d]["last_puplish_date"] + "</td>");

                                for (int edi1 = 0; edi1 < cont1; edi1++)
                                {
                                    if (ds.Tables[0].Rows[d]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                                    {
                                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["Ins.date"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data'></td>");
                                    }
                                }
                                // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                                if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                                {

                                    count1++;
                                    cnt4++;

                                }
                                // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                                if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                                {
                                    count2++;
                                    cnt5++;

                                }
                                if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                                {
                                    if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                    {
                                        count3++;
                                        cnt1++;

                                    }
                                    else
                                    {
                                        count31++;
                                        cnt2++;

                                    }
                                }
                                paidins = ((i1 - 1) - (count1 + count2));

                                cnt3 = temprowcnt - (cnt4 + cnt5);



                                //if (d == cont - 1 && cont > 1 && nontot == 1)
                                //{
                                //     tbl.Append( ("<tr><td class='middle31new'colspan='16'>TotalAds:" + temprowcnt.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;HouseAd:" + cnt5.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");

                                //    for (int dsd = 0; dsd < cont1; dsd++)
                                //    {
                                //        tbl.Append( ("<td class='middle31new'>&nbsp;</td>");
                                //    }
                                //    tbl.Append( ("</tr>");
                                //}


                                tbl.Append("</tr>");

                            }

                            ct = ct + maxlimit;
                            fr = fr + maxlimit;

                        }
                        //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                        tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td>");

                        for (int dsd = 0; dsd < cont1; dsd++)
                        {
                            tbl.Append("<td  class='middle31new'>&nbsp;</td>");
                        }
                        tbl.Append("</tr>");
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

                        //  tbl.Append( "</table>";
                        div1.Visible = true;
                        div1.InnerHtml = tbl.ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                    }
                }
                else
                {
                    if (pkgdetail == "0")
                    {
                        int count_pg = 0;
                        int tab3 = ds.Tables[3].Rows.Count;
                        int ct1 = 0;

                        int sq2 = 0;

                        int sq = 0;
                        int counter = 0;
                        int get = 0;

                        int sq1 = 0;

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";
                            if (browser.Browser == "Firefox")
                            {
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                            else if (browser.Browser == "IE")
                            {
                                if ((ver == 7.0) || (ver == 8.0))
                                {
                                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                                else if (ver == 6.0)
                                {
                                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                            }
                            for (int p = 0; p < tab3; p++)
                            {


                                sq = Convert.ToInt32(ds.Tables[3].Rows[p].ItemArray[1].ToString());

                                sq1 = sq + ct1;

                                ///////////////////////new
                                int s = p + 1;
                                if (p == 0)
                                {
                                    if (browser.Browser == "Firefox")
                                    {
                                        tbl.Append("</table></P>");
                                        if (p != 0)
                                        {
                                            if (p == pagecount - 1)

                                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            else
                                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        }
                                    }
                                    else if (browser.Browser == "IE")
                                    {
                                        if ((ver == 8.0) || (ver == 7.0))
                                        {

                                            // if (p != 0)
                                            //{
                                            tbl.Append("</table></P>");
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            // if (p == pagecount - 1)
                                            // tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            //else
                                            // tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                            // }
                                        }
                                        else if (ver == 6.0)
                                        {
                                            tbl.Append("</table>");
                                            if (p != 0)
                                            {
                                                if (p == pagecount - 1)
                                                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                                else
                                                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                            }
                                        }
                                    }
                                }
                                // tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";

                                if (p > 0)
                                {
                                    if (p == tab3 - 1)
                                    {

                                        if (ds.Tables[3].Rows[p].ItemArray[0].ToString() == ds.Tables[3].Rows[p - 1].ItemArray[0].ToString())
                                        {
                                            counter++;
                                            get = counter + 1;
                                            // nontot = 1;

                                        }
                                        else
                                        {
                                            counter = 0;
                                        }

                                        sq2 = Convert.ToInt32(ds.Tables[3].Rows[p - 1].ItemArray[1].ToString());
                                        cnt3 = sq2 - cnt3;//paid


                                        // tbl.Append("<tr><td class='middle31new'colspan='2'>TotalAds:" + sq2.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + area1.ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2' >Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2' >Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='3'>Date:" + tab4date.ToString() + "</td>");
                                        // tbl.Append( "<tr><td class='middle31new'colspan='17'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                        tbl.Append("<tr><td class='middle31new'colspan='18'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");

                                        //  tbl.Append("<tr><td class='middle31new'colspan='2'>TotalAds:" + sq2.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + area1.ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2' >Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2' >Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='3'>Date:" + tab4date.ToString() + "</td>");
                                        // tbl.Append("<tr><td class='middle31new'colspan='17'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");


                                        for (int dsd = 0; dsd < cont1; dsd++)
                                        {
                                            tbl.Append("<td class='middle31new'>&nbsp;</td>");
                                        }
                                        tbl.Append("</tr>");
                                        if (counter > 0)
                                        {
                                            tbl.Append("<tr>");
                                            for (int dsd = 0; dsd < cont1; dsd++)
                                            {
                                                tbl.Append("<td></td>");
                                            }

                                            tbl.Append("<td colspan='16' align='right'><b>continue to page" + get + "... </b></td>");

                                            tbl.Append("</tr>");
                                            count_pg = 1;
                                        }

                                        cnt1 = 0;//line
                                        cnt2 = 0;//size
                                        cnt3 = 0;//paid
                                        cnt4 = 0;//fmg
                                        cnt5 = 0; //house ads 
                                        area1 = 0;
                                        tempsqcm = 0;
                                        tempcolcm = 0;
                                        tempother = 0;
                                        temptotcc = 0;
                                        temptotcd = 0;
                                        temptotrol = 0;
                                        tempareaset = 0;
                                        temptotunaudit = 0;
                                        temptotaudit = 0;

                                    }
                                    else
                                    {
                                        nontot = 1;
                                        if (ds.Tables[3].Rows[p].ItemArray[0].ToString() == ds.Tables[3].Rows[p - 1].ItemArray[0].ToString())
                                        {
                                            counter++;
                                            get = counter + 1;

                                        }
                                        else
                                        {
                                            counter = 0;
                                        }


                                        sq2 = Convert.ToInt32(ds.Tables[3].Rows[p - 1].ItemArray[1].ToString());
                                        cnt3 = sq2 - cnt3;//paid
                                        /////////////////NEW ADDED
                                        // tbl.Append( ("<tr><td class='middle31new'colspan='2'>TotalAds:" + sq2.ToString() + "</td><td  class='middle31new' colspan='2'>TotalArea:" + area1.ToString() + "</td><td class='middle31new' colspan='2'>Line/Word:" + cnt1.ToString() + "</td><td class='middle31new' colspan='2' >Paid :" + cnt3.ToString() + "</td><td  class='middle31new' colspan='2' >Fmg:" + cnt4.ToString() + "</td><td  class='middle31new' colspan='2'>HouseAd:" + cnt5.ToString() + "</td><td  class='middle31new' colspan='3'>Date:" + tab4date.ToString() + "</td>");
                                        //tbl.Append( "<tr><td class='middle31new'colspan='16'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                        tbl.Append("<tr><td class='middle31new'colspan='16'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");

                                        for (int dsd = 0; dsd < cont1; dsd++)
                                        {
                                            tbl.Append("<td class='middle31new'>&nbsp;</td>");
                                        }
                                        tbl.Append("</tr>");
                                        if (counter > 0)
                                        {
                                            tbl.Append("<tr>");
                                            for (int dsd = 0; dsd < cont1; dsd++)
                                            {
                                                tbl.Append("<td></td>");
                                            }

                                            tbl.Append("<td colspan='15' align='right'><b>continue to page" + get + "... </b></td>");
                                            // count_pg = 1;
                                            tbl.Append("</tr>");
                                            count_pg = 1;
                                        }

                                        cnt1 = 0;//line
                                        cnt2 = 0;//size
                                        cnt3 = 0;//paid
                                        cnt4 = 0;//fmg
                                        cnt5 = 0; //house ads 
                                        area1 = 0;
                                        tempsqcm = 0;
                                        tempcolcm = 0;
                                        tempother = 0;
                                        temptotcc = 0;
                                        temptotcd = 0;
                                        temptotrol = 0;
                                        tempareaset = 0;
                                        temptotaudit = 0;
                                        temptotunaudit = 0;
                                    }


                                }
                                // }

                                if (browser.Browser == "Firefox")
                                {

                                    tbl.Append("</table></P>");
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)
                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center'    valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    }
                                }
                                else if (browser.Browser == "IE")
                                {
                                    if ((ver == 8.0) || (ver == 7.0))
                                    {

                                        if (p != 0)
                                        {
                                            tbl.Append("</table></P>");
                                            if (p == pagecount - 2)
                                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center'   valign='top'>");
                                            else
                                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                        }
                                    }
                                    else if (ver == 6.0)
                                    {
                                        tbl.Append("</table>");
                                        if (p != 0)
                                        {
                                            if (p == pagecount - 1)
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center'   valign='top'>");
                                            else
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                        }
                                    }
                                }


                                //   tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                                tbl.Append(tblhdr.ToString());

                                tbl.Append("<tr>");

                                tbl.Append("<td class='middle111' align='right' colspan='12'>");
                                for (int dsd = 0; dsd < cont1; dsd++)
                                {
                                    tbl.Append("<td >&nbsp;</td>");
                                }
                                tbl.Append("<td class='middle111' align='right' colspan='6'>" + "Page  " + s + "  of  " + tab3);
                                tbl.Append("</td >");
                                tbl.Append("</td></tr>");
                                tbl.Append("<td class='middle31new'   align='center'>" + "S.No." + "</td>");
                                tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left' >" + "Client" + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td class='middle31new'  align='left'>" + "Package" + "</td>");

                                }

                                tbl.Append("<td class='middle31new'  align='left' >" + "RONo." + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "WD" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left' >" + "Color" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\"  class='middle31new' align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\"  class='middle31new' align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");

                                int edi;
                                for (edi = 0; edi < cont1; edi++)
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='edidetail'>");
                                    tbl.Append(ds.Tables[1].Rows[edi]["Editions"] + "</td>");
                                }

                                tbl.Append("</tr>");



                                for (int d = ct1; d < ds.Tables[0].Rows.Count && d < sq1; d++)
                                {

                                    int a = d;
                                    a = a + 1;

                                    tbl.Append("<tr >");
                                    tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                                    tbl.Append(i1++.ToString() + "</td>");

                                    //-------------------------------------------//
                                    string cioid1 = "";
                                    string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                                    char[] cioid = rrr.ToCharArray();
                                    int len11 = cioid.Length;

                                    for (int ch = 0; ch < len11; ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else if (ch % 10 != 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else
                                        {
                                            cioid1 = cioid1 + "</br>" + cioid[ch];
                                        }
                                    }
                                    //----------------------------------------------------------------///

                                    tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                                    tbl.Append(cioid1 + "</td>");


                                    tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                                    //-------------------------------------------//
                                    string Agency1 = "";
                                    string Agency11 = "";
                                    string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                                    char[] Agency = AA.ToCharArray();
                                    int len12 = Agency.Length;
                                    int line1 = 0;

                                    for (int ch = 0; ch < len12; ch++)
                                    {
                                        if (Agency[ch] == ' ')
                                        {
                                            Agency1 = AA.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Agency1 = AA;
                                        }
                                    }
                                    char[] AA1 = Agency1.ToCharArray();

                                    for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else if (ch % 11 != 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else
                                        {

                                            line1 = line1 + 1;
                                            if (line1 != 2)
                                            {
                                                Agency11 = Agency11 + "</br>" + Agency[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Agency11 +/*"</br>" + ds.Tables[0].Rows[d]["Spl Instruction"]+*/"</td>");

                                    tbl.Append("<td class='rep_data'  align='left' width='14%'>");
                                    string Client1 = "";
                                    string Client11 = "";
                                    string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                                    char[] Client = BB.ToCharArray();
                                    int len13 = Client.Length;
                                    int line2 = 0;

                                    for (int ch = 0; ch < len13; ch++)
                                    {
                                        if (Client[ch] == ' ')
                                        {
                                            Client1 = BB.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Client1 = BB;
                                        }
                                    }
                                    char[] BB1 = Client1.ToCharArray();

                                    for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else if (ch % 14 != 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else
                                        {

                                            line2 = line2 + 1;
                                            if (line2 != 2)
                                            {
                                                Client11 = Client11 + "</br>" + BB1[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                                    if (edition != "0")
                                    {
                                        tbl.Append("<td class='rep_data' align='left' width='9%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                                    }

                                    //  tbl.Append( ("<td class='rep_data' align='left' width='8%'>");
                                    //  tbl.Append( (ds.Tables[0].Rows[d]["edition"] + "</td>");


                                    tbl.Append("<td class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                                    // tbl.Append( ("<td class='rep_data' width='5%' align='left'>");
                                    // tbl.Append( (ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");

                                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                    {
                                        area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                        area1 = area1 + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);

                                        if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                        {

                                            areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                        {
                                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                        {
                                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                        {
                                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                                    if (edition != "0")
                                    {
                                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                                    }


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%'>");
                                    if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                                    {
                                        tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totaudit = totaudit + 1;
                                        temptotaudit = temptotaudit + 1;
                                    }
                                    else
                                    {
                                        tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totunaudit = totunaudit + 1;
                                        temptotunaudit = temptotunaudit + 1;
                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");

                                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");

                                    for (int edi1 = 0; edi1 < cont1; edi1++)
                                    {
                                        if (ds.Tables[0].Rows[d]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                                        {
                                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'>");

                                            tbl.Append(ds.Tables[0].Rows[d]["Ins.date"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'></td>");
                                        }
                                    }

                                    // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                                    {

                                        count1++;
                                        cnt4++;

                                    }
                                    // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                                    {
                                        count2++;
                                        cnt5++;

                                    }
                                    if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                                    {
                                        if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                        {
                                            count3++;
                                            cnt1++;

                                        }
                                        else
                                        {
                                            count31++;
                                            cnt2++;

                                        }
                                    }
                                    paidins = ((i1 - 1) - (count1 + count2));

                                    cnt3 = cnt4 + cnt5;

                                    if (d == cont - 1 && cont > 1 && nontot == 1)
                                    {
                                        sq2 = Convert.ToInt32(ds.Tables[3].Rows[p].ItemArray[1].ToString());
                                        cnt3 = sq2 - cnt3;//paid
                                        //tbl.Append( "<tr><td class='middle31new'colspan='17'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                                        tbl.Append("<tr><td class='middle31new'colspan='18'>TotalAds:" + sq2.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + tempareaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + cnt3.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + cnt4.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + temptotrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + temptotcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + temptotcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + temptotaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + temptotunaudit.ToString() + "</td>");

                                        for (int dsd = 0; dsd < cont1; dsd++)
                                        {
                                            tbl.Append("<td class='middle31new'>&nbsp;</td>");
                                        }
                                        tbl.Append("</tr>");
                                    }


                                    tbl.Append("</tr>");

                                }

                                ct1 = ct1 + sq;//old

                            }
                            //tbl.Append( "<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td></tr>");
                            tbl.Append("<tr><td class='middle31new'colspan='19'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td></tr>");

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
                            // tbl.Append( "</table>";
                            div1.Visible = true;
                            div1.InnerHtml = tbl.ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                        }

                    }
                    else
                    {


                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // tbl.Append( "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";
                            if (browser.Browser == "Firefox")
                            {
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                            }
                            else if (browser.Browser == "IE")
                            {
                                if ((ver == 7.0) || (ver == 8.0))
                                {
                                    tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                                }
                                else if (ver == 6.0)
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
                                    if (p != 0)
                                    {
                                        if (p == pagecount - 1)
                                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                        else
                                            tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                    }
                                }
                                else if (browser.Browser == "IE")
                                {
                                    if ((ver == 8.0) || (ver == 7.0))
                                    {
                                        tbl.Append("</table></P>");
                                        if (p != 0)
                                        {
                                            if (p == pagecount - 1)
                                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            else
                                                tbl.Append("<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                                        }
                                    }
                                    else if (ver == 6.0)
                                    {
                                        tbl.Append("</table>");
                                        if (p != 0)
                                        {
                                            if (p == pagecount - 1)
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                                            else
                                                tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                                        }
                                    }
                                }



                                //  tbl.Append( "</table>";

                                // tbl.Append( "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                                if (p == 0)
                                    tbl.Append(tblhdr.ToString());
                                tbl.Append("<tr>");

                                tbl.Append("<td class='middle111' align='right' colspan='12'>");
                                for (int dsd = 0; dsd < cont1; dsd++)
                                {
                                    tbl.Append("<td >&nbsp;</td>");
                                }
                                tbl.Append("<td class='middle111' align='right' colspan='6'>" + "Page  " + s + "  of  " + pagecount);
                                tbl.Append("</td >");
                                tbl.Append("</td></tr>");
                                tbl.Append("<td class='middle31new'  align='center'>" + "S.No." + "</td>");
                                tbl.Append("<td class='middle31new'   align='left'>" + "Booking" + "</br>" + "Id" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left'>" + "Agency" + "</td>");
                                tbl.Append("<td class='middle31new'  align='left' >" + "Client" + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td class='middle31new'  align='left'>" + "Package" + "</td>");

                                }

                                tbl.Append("<td class='middle31new'  align='left' >" + "RONo." + "</td>");

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "WD" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "HT" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='right'>" + "Area" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Uom" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left' >" + "Color" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'  align='left'>" + "Post" + "</br>" + "Prem." + "</td>");

                                if (edition != "0")
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='right'>" + "Agg" + "</br>" + "Rate" + "</td>");
                                }

                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new'   align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "MaterialStatus" + "</br>" + "FileName" + "</br>" + "Instruction" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Audit" + "</br>" + "Authorization" + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Insertion" + "</br>" + "N0." + "</td>");
                                tbl.Append("<td style=\"padding-left:4px\" class='middle31new' align='left'>" + "Last Publish" + "</br>" + "Date" + "</td>");

                                int edi;
                                for (edi = 0; edi < cont1; edi++)
                                {
                                    tbl.Append("<td style=\"padding-left:4px\" class='edidetail'>");
                                    tbl.Append(ds.Tables[1].Rows[edi]["Editions"] + "</td>");
                                }

                                tbl.Append("</tr>");



                                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                                {

                                    int a = d;
                                    a = a + 1;

                                    tbl.Append("<tr >");
                                    tbl.Append("<td class='rep_data'  width='3%' align='center'>");
                                    tbl.Append(i1++.ToString() + "</td>");

                                    //-------------------------------------------//
                                    string cioid1 = "";
                                    string rrr = ds.Tables[0].Rows[d].ItemArray[0].ToString();
                                    char[] cioid = rrr.ToCharArray();
                                    int len11 = cioid.Length;

                                    for (int ch = 0; ch < len11; ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else if (ch % 10 != 0)
                                        {
                                            cioid1 = cioid1 + cioid[ch];
                                        }
                                        else
                                        {
                                            cioid1 = cioid1 + "</br>" + cioid[ch];
                                        }
                                    }
                                    //----------------------------------------------------------------///

                                    tbl.Append("<td class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append( (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");
                                    tbl.Append(cioid1 + "</td>");


                                    tbl.Append("<td class='rep_data'  align='left' width='10%'>");
                                    //-------------------------------------------//
                                    string Agency1 = "";
                                    string Agency11 = "";
                                    string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                                    char[] Agency = AA.ToCharArray();
                                    int len12 = Agency.Length;
                                    int line1 = 0;

                                    for (int ch = 0; ch < len12; ch++)
                                    {
                                        if (Agency[ch] == ' ')
                                        {
                                            Agency1 = AA.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Agency1 = AA;
                                        }
                                    }
                                    char[] AA1 = Agency1.ToCharArray();

                                    for (int ch = 0; ((ch < len12) && (line1 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else if (ch % 11 != 0)
                                        {
                                            Agency11 = Agency11 + Agency[ch];
                                        }
                                        else
                                        {

                                            line1 = line1 + 1;
                                            if (line1 != 2)
                                            {
                                                Agency11 = Agency11 + "</br>" + Agency[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Agency11 +/*"</br>" + ds.Tables[0].Rows[d]["Spl Instruction"]+*/"</td>");

                                    tbl.Append("<td class='rep_data'  align='left' width='8%'>");
                                    string Client1 = "";
                                    string Client11 = "";
                                    string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                                    char[] Client = BB.ToCharArray();
                                    int len13 = Client.Length;
                                    int line2 = 0;

                                    for (int ch = 0; ch < len13; ch++)
                                    {
                                        if (Client[ch] == ' ')
                                        {
                                            Client1 = BB.Replace(" ", "_");
                                        }
                                        else
                                        {
                                            Client1 = BB;
                                        }
                                    }
                                    char[] BB1 = Client1.ToCharArray();

                                    for (int ch = 0; ((ch < BB1.Length) && (line2 < 2)); ch++)
                                    {

                                        if (ch == 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else if (ch % 14 != 0)
                                        {
                                            Client11 = Client11 + BB1[ch];
                                        }
                                        else
                                        {

                                            line2 = line2 + 1;
                                            if (line2 != 2)
                                            {
                                                Client11 = Client11 + "</br>" + BB1[ch];
                                            }

                                        }
                                    }
                                    //---------------------------------------------//
                                    tbl.Append(Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");

                                    if (edition != "0")
                                    {
                                        tbl.Append("<td class='rep_data' align='left' width='9%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");
                                    }


                                    tbl.Append("<td class='rep_data' align='left' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["RO_No"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");

                                    tbl.Append("<td  style=\"padding-left:4px\" class='rep_data' align='left' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Uom"] + "</td>");

                                    if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                                    {
                                        area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);
                                        area1 = area1 + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);

                                        if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "CD" || ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROD")
                                        {

                                            areaset = areaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            tempareaset = tempareaset + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROL")
                                        {
                                            totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotrol = temptotrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROC")
                                        {
                                            totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcd = temptotcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                        else if (ds.Tables[0].Rows[d]["uomdesc"].ToString() == "ROW")
                                        {
                                            totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                            temptotcc = temptotcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                                        }
                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='3%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Hue"] + "</td>");



                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["PosPremium"] + "</td>");


                                    if (edition != "0")
                                    {
                                        tbl.Append("<td  style=\"padding-left:4px\" class='rep_data' align='right' width='5%'>");
                                        tbl.Append(ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                                    }


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'  width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");


                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='8%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["FILE_NAME"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' width='5%'>");
                                    if (ds.Tables[0].Rows[d]["audit"].ToString() != "")
                                    {
                                        tbl.Append("Y" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totaudit = totaudit + 1;
                                        temptotaudit = temptotaudit + 1;
                                    }
                                    else
                                    {
                                        tbl.Append("N" + "</br>" + ds.Tables[0].Rows[d]["APP_STATUS"] + "</td>");
                                        totunaudit = totunaudit + 1;
                                        temptotunaudit = temptotunaudit + 1;

                                    }

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    tbl.Append(ds.Tables[0].Rows[d]["NO_INSERT"] + "</td>");


                                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'>");
                                    //tbl.Append(ds.Tables[0].Rows[d]["last_publish_date"] + "</td>");

                                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data'  width='5%' align='left'></td>");

                                    for (int edi1 = 0; edi1 < cont1; edi1++)
                                    {
                                        if (ds.Tables[0].Rows[d]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                                        {
                                            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data'>");
                                            tbl.Append(ds.Tables[0].Rows[d]["Ins.date"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append("<td style=\"padding-left:4px\" class='rep_data'></td>");
                                        }
                                    }

                                    // if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "2")
                                    {

                                        count1++;
                                        cnt4++;

                                    }
                                    // if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                                    if (ds.Tables[0].Rows[d]["booktype"].ToString() == "4")
                                    {
                                        count2++;
                                        cnt5++;

                                    }
                                    if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                                    {
                                        if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                        {
                                            count3++;
                                            cnt1++;

                                        }
                                        else
                                        {
                                            count31++;
                                            cnt2++;

                                        }
                                    }
                                    paidins = ((i1 - 1) - (count1 + count2));

                                    cnt3 = cnt4 + cnt5;




                                    tbl.Append("</tr>");

                                }

                                ct = ct + maxlimit;
                                fr = fr + maxlimit;

                            }
                            //tbl.Append( "<tr><td class='middle31new'colspan='17'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Date:" + tab4date.ToString() + "</td>");
                            tbl.Append("<tr><td class='middle31new'colspan='18'>TotalAds:" + (i1 - 1).ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;TotalArea:" + areaset.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Paid :" + paidins.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Fmg:" + count1.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Lines:" + totrol.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Chars:" + totcd.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Words:" + totcc.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Audit:" + totaudit.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;Unaudit:" + totunaudit.ToString() + "</td>");

                            for (int dsd = 0; dsd < cont1; dsd++)
                            {
                                tbl.Append("<td class='middle31new'>&nbsp;</td>");
                            }
                            tbl.Append("</tr>");
                            // tbl.Append( "</table>";
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


                            div1.Visible = true;
                            div1.InnerHtml = tbl.ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
                        }
                    }
                }
            }

        }


    }
}
