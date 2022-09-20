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
using System.Data.OracleClient;
using System.IO;
using System.Text;

public partial class agencycliviewprint : System.Web.UI.Page
{
    int maxlimit = 10;
    int a = 0;
    int maxlimit_new = 50;
    string clientname = "";
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
    string clientname1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    int ins_no = 0;
    double amt = 0;
    string client = "";
    string package = "";
    string drillon = "";
    string sortorder = "";
    string sortvalue = "", agtype = "", agtypetext = "";
    double area1 = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    DataSet ds;
    System.Web.HttpBrowserCapabilities browser;

    double ver;

    protected void Page_Load(object sender, EventArgs e)
    {


        //hiddendateformat.Value = Session["dateformat"].ToString();
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
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[5].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);


        ds = (DataSet)Session["allclient"];
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/agencyclient.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();

        string prm = Session["prm_allclient_print"].ToString();
        string[] prm_Array = new string[35];
        prm_Array = prm.Split('~');


        clientname = prm_Array[1];// Request.QueryString["clientname"].ToString();
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
        clientname1 = prm_Array[23]; //Request.QueryString["client"].ToString();
        adtypename = prm_Array[25]; //Request.QueryString["adtypename"].ToString();
        editionname = prm_Array[27]; //Request.QueryString["editionname"].ToString();
        agtype = prm_Array[29]; //Request.QueryString["agtype1"].ToString();
        agtypetext = prm_Array[31]; //Request.QueryString["agtypetext"].ToString();

        if (agtype == "0")
        {
            lblagtype.Text = "ALL".ToString();
        }
        else
        {
            lblagtype.Text = agtypetext.ToString();
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

        //if (adcat == "0")
        //{
        //    Adcat.Text = " ";
        //}
        //else
        //{
        //    Adcat.Text = (adcatname.Replace("'", " ").ToString());
        //}

        if (clientname == "0" || clientname == "")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname1.ToString();
        }
        //if (adtyp == "0")
        //{
        //    lbladtype.Text = "";
        //}
        //else
        //{
        //    lbladtype.Text = adtypename.ToString();

        //}
        if (edition == "0" || edition == "")
        {
            lbedition.Text = "ALL".ToString();
        }
        else
        {
            lbedition.Text = editionname.ToString();


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
            lbladcat.Text = "ALL".ToString();
        }
        else
        {
            lbladcat.Text = adcatname.ToString();
        }




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


        onscreen(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

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


    private void onscreen(string clientname, string adtyp, string adcat, string fromdt, string dateto, string publ, string pubcen, string compcode, string edition, string dateformat)
    {
        //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.Class1 misrep = new NewAdbooking.Report.classesoracle.Class1();
        //    ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Report.Classes.report misrep = new NewAdbooking.Report.Classes.report();
        //    ds = misrep.spclient(clientname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", agtypetext);

        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int cont = ds.Tables[0].Rows.Count;
        int contc = ds.Tables[0].Columns.Count;
        int ct = 0;
        int rowcounter = 0;
        int fr = maxlimit;
        int fr_new = maxlimit_new;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        // string tbl = "";
        StringBuilder tbl = new StringBuilder();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (browser.Browser == "Firefox")
            {
            //    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
                else if (ver == 6.0)
                {
                    tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>");
                }
            }

            int db = 0;
                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    if (browser.Browser == "Firefox")
                    {
                        tbl.Append("</table>");
                        if (p == pagecount ||p==0)
                            tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                        else
                            tbl.Append("<P style='page-break-before:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                    }
                    else if (browser.Browser == "IE")
                    {
                        if ((ver == 8.0) || (ver == 7.0))
                        {
                            tbl.Append("</table></p>");
                            if (p == pagecount - 1)
                                tbl.Append("<P style='page-break-before:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else if (p == 0)
                            {
                                tbl.Append("<P style='page-break-after:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");

                            }
                            else
                            {
                                tbl.Append("<P style='page-break-after:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            }
                        }
                        else if (ver == 6.0)
                        {
                            tbl.Append("</table>");
                            if (p == pagecount - 1)
                                tbl.Append("<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>");
                            else
                                tbl.Append("<P style='page-break-before:always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                        }
                    }  




                    // tbl.Append("</table>");
                    // tbl.Append("<table width='98%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>");
                    tbl.Append("<tr valign='top'>");
                    tbl.Append("<td class='middle111' align='right' colspan='23'>" + "Page  " + s + "  of  " + pagecount);
             

                    tbl.Append("<tr><td class='middle31new' width='1%'>S.</br>No.</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Booking</br>&nbsp;&nbsp;ID</td><td class='middle31new' width='3%'  align='left'>&nbsp;&nbsp;Edition</td><td class='middle31new' width='3%'  align='left'>&nbsp;&nbsp;Publish</br>&nbsp;&nbsp;Date</td><td class='middle31new'  width='9%'  align='left'>&nbsp;&nbsp;Client</td><td class='middle31new' width='6%'  align='left'>&nbsp;&nbsp;Package</td><td class='middle31new' width='2%'  align='right'>&nbsp;&nbsp;HT</td><td class='middle31new' width='2%'  align='right'>&nbsp;&nbsp;WD</td><td class='middle31new' width='3%'  align='right'>&nbsp;&nbsp;Area</td><td class='middle31new' width='3%'  align='left'>&nbsp;&nbsp;Color</td><td class='middle31new' width='1%' valign='top' align='left'>&nbsp;&nbsp;Page&nbsp;&nbsp;</br>&nbsp;&nbsp;Position&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left' >Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left' >Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</td><td class='middle31new' width='1%' align='left'>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</td><td class='middle31new' width='6%' align='left'>RoNo.</td><td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;RoStatus</td> <td class='middle31new' width='5%' align='left'>&nbsp;&nbsp;AdCat</td><td class='middle31new' width='3%' align='left'>&nbsp;&nbsp;Rate</br>&nbsp;&nbsp;Code</td><td class='middle31new' width='3%'  align='right'>&nbsp;&nbsp;Card</br>&nbsp;&nbsp;Rate</td><td class='middle31new' width='4%' align='right'>&nbsp;&nbsp;AggRate</td><td class='middle31new' width='4%' align='right'>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</td><td class='middle31new' width='3%' colspan='2' align='left'>Caption</br>Key&nbsp;No.</td></tr>");



                    for (int d = a; d < cont && rowcounter <= fr; d++)
                    {

                        a = d;
                        a = a + 1;

                        tbl.Append("<tr >");
                        tbl.Append("<td class='rep_data'>");
                        tbl.Append(a.ToString() + "</td>");


                        string cioid1 = "";
                        string rrr = ds.Tables[0].Rows[d]["CIOID"].ToString();
                        if (rrr.Length >= 10)
                        {
                            cioid1 = rrr.Substring(0, 10);
                            if (rrr.Length - 10 < 10)
                            {
                                cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                                
                            }
                            else
                            {
                                cioid1 += "</br>" + rrr.Substring(10, 10);
                              
                            }
                        }
                        else
                            cioid1 = rrr;


                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        tbl.Append(cioid1 + "</td>");
                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        tbl.Append(ds.Tables[0].Rows[d]["edition"] + "</td>");


                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        tbl.Append(ds.Tables[0].Rows[d]["Ins_date"] + "</td>");

                        //string client = "";
                        //string client1 = "";
                        //string client2 = "";
                        //string client3 = "";
                        //string client4 = "";
                        //string rrr2 = ds.Tables[0].Rows[d]["Client_Name"].ToString();
                        //if (rrr2.Length >= 16)
                        //{
                        //    client = rrr2.Substring(0, 16);


                        //    if (rrr2.Length <= 32)
                        //    {
                        //        int aa = rrr2.Length;
                        //        client1 = rrr2.Substring(17, rrr2.Length - 17);
                        //        client += "</br>" + client1;
                        //        rowcounter = rowcounter + 2;
                        //    }
                        //    else if (rrr2.Length <= 48)
                        //    {
                        //        client1 = rrr2.Substring(17, 32 - 17);
                        //        client2 = rrr2.Substring(33, rrr2.Length - 33);

                        //        client += "</br>" + client1 + "</br>" + client2;
                        //        rowcounter = rowcounter + 3;
                        //    }
                        //    else if (rrr2.Length <= 64)
                        //    {
                        //        client1 = rrr2.Substring(17, 32 - 17);
                        //        client2 = rrr2.Substring(33, 48 - 33);
                        //        client3 = rrr2.Substring(49, rrr2.Length - 49);

                        //        client += "</br>" + client1 + "</br>" + client2 + "</br>" + client3;
                        //        rowcounter = rowcounter + 4;
                        //    }
                        //    else if (rrr2.Length <= 80)
                        //    {
                        //        client1 = rrr2.Substring(17, 32 - 17);
                        //        client2 = rrr2.Substring(33, 48 - 33);
                        //        client3 = rrr2.Substring(49, 64 - 49);
                        //        client4 = rrr2.Substring(65, rrr2.Length - 65);
                        //        client += "</br>" + client1 + "</br>" + client2 + "</br>" + client3 + "</br>" + client4;
                        //        rowcounter = rowcounter + 5;
                        //    }
                        //}
                        //else if (rrr2 == " ")
                        //{
                        //    rowcounter = rowcounter + 1;
                        //}
                        //else
                        //{
                        //    client = rrr2;
                        //    rowcounter = rowcounter + 1;
                        //}
                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");

                        string rrr2 = ds.Tables[0].Rows[d]["Client_Name"].ToString();
                        if (rrr2.Length > 26)
                        {
                            tbl.Append(rrr2.ToString().Substring(0, 26) + "</td>");
                        }
                        else
                        {
                            tbl.Append(rrr2.ToString() + "</td>");
                        }

                        tbl.Append(client + "</td>");

                        string Package1 = "";
                        string rrr3 = ds.Tables[0].Rows[d]["Package"].ToString();
                        if (rrr3.Length >= 9)
                        {
                            Package1 = rrr3.Substring(0, 9);
                            if (rrr3.Length - 9 < 9)
                            {
                                Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                               
                            }
                            else
                            {
                                Package1 += "</br>" + rrr3.Substring(9, 9);
                              
                            }
                        }
                        else
                            Package1 = rrr3;

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        tbl.Append(Package1 + "</td>");

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
                        tbl.Append(ds.Tables[0].Rows[d]["Depth"] + "</td>");

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
                        tbl.Append(ds.Tables[0].Rows[d]["Width"] + "</td>");

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
                        tbl.Append(ds.Tables[0].Rows[d]["Area"] + "</td>");
                        if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                        {

                            if (ds.Tables[0].Rows[d]["uom"].ToString() == "CD" || ds.Tables[0].Rows[d]["uom"].ToString() == "ROD")
                                area1 = area1 + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                            else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROL")
                                totrol = totrol + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                            else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROC")
                                totcd = totcd + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());
                            else if (ds.Tables[0].Rows[d]["uom"].ToString() == "ROW")
                                totcc = totcc + double.Parse(ds.Tables[0].Rows[d]["Area"].ToString());


                        }
                        //----------------------------------------------------------------///
                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
                        tbl.Append(ds.Tables[0].Rows[d]["Color_code"] + "</td>");

                        string page = ds.Tables[0].Rows[d]["Page"].ToString();
                        if (page.Length >= 12)
                        {
                            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Page"].ToString().Substring(0, 12) + "</td>");

                        }
                        else
                        {
                            tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                            tbl.Append(ds.Tables[0].Rows[d]["Page"] + "</td>");
                        }
                        //tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        //tbl.Append(ds.Tables[0].Rows[d]["Page"] + "</td>");


                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='1%'>");

                        if (ds.Tables[0].Rows[d]["PagePremium"].ToString() == "0")
                        {
                            tbl.Append("" + "</td>");
                        }
                        else
                        {


                            tbl.Append(ds.Tables[0].Rows[d]["PagePremium"] + "</td>");
                        }




                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='1%'>");
                        if (ds.Tables[0].Rows[d]["PositionPremium"].ToString() == "0")
                        {
                            tbl.Append("" + "</td>");
                        }
                        else
                        {
                            tbl.Append(ds.Tables[0].Rows[d]["PositionPremium"] + "</td>");
                        }

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' width='1%'>");
                        if (ds.Tables[0].Rows[d]["BulletPremium"].ToString() == "0")
                        {
                            tbl.Append("" + "</td>");
                        }
                        else
                        {
                            tbl.Append(ds.Tables[0].Rows[d]["BulletPremium"] + "</td>");
                        }

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        tbl.Append(ds.Tables[0].Rows[d]["RoNo."] + "</td>");

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left'>");
                        tbl.Append(ds.Tables[0].Rows[d]["RoStatus"] + "</td>");


                        string AdCat1 = "";
                        string rrr5 = ds.Tables[0].Rows[d]["AdCat"].ToString();
                        if (rrr5.Length >= 9)
                        {
                            AdCat1 = rrr5.Substring(0, 9);
                            if (rrr5.Length - 9 < 9)
                            {
                                AdCat1 += "</br>" + rrr5.Substring(9, rrr5.Length - 9);
                               
                            }
                            else
                            {
                                AdCat1 += "</br>" + rrr5.Substring(9, 9);
                              
                            }
                        }
                        else
                            AdCat1 = rrr5;


                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
                        tbl.Append(AdCat1 + "</td>");


                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='left' >");
                        tbl.Append(ds.Tables[0].Rows[d]["RateCode"] + "</td>");

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");

                        if ((ds.Tables[0].Rows[d]["CardRate"]).ToString() == "")
                        {
                            tbl.Append("" + "</td>");
                        }
                        else
                        {

                            tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[d]["CardRate"]).ToString("F2") + "</td>");
                        }

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");
                        if ((ds.Tables[0].Rows[d]["AgreedRate"]).ToString() == "")
                        {
                            tbl.Append("" + "</td>");
                        }
                        else
                        {

                            tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[d]["AgreedRate"]).ToString("F2") + "</td>");
                        }

                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' align='right'>");

                        if ((ds.Tables[0].Rows[d]["Amt"]).ToString() == "")
                        {
                            tbl.Append("" + "</td>");
                        }
                        else
                        {

                            tbl.Append(Convert.ToDouble(ds.Tables[0].Rows[d]["Amt"]).ToString("F2") + "</td>");
                        }

                        if (ds.Tables[0].Rows[d]["Amt"].ToString() != "")
                            amt = amt + double.Parse(ds.Tables[0].Rows[d]["Amt"].ToString());
                       
                        tbl.Append("<td style=\"padding-left:4px\"  class='rep_data' colspan='2' align='left'>");
                        tbl.Append(ds.Tables[0].Rows[d]["Cap"]);
                        tbl.Append("</br>");
                        tbl.Append(ds.Tables[0].Rows[d]["Key"] + "</td>");


                        tbl.Append("</tr>");




                       
                        rowcounter++;
                    }
                    //if (p == 0)
                    //{
                    //    ct = ct + rowcounter;
                    //    fr = fr + rowcounter;
                    //}
                    //else
                    //{
                    //    ct = ct + rowcounter;
                    //    fr = fr + rowcounter;
                    //}
                    //if (p == 0)
                    //{
                    //    rowcounter = rowcounter + 5;
                    //}
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;
                   // rowcounter = 0;
                  
                   
                }

                tbl.Append("<tr >");

                tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + a.ToString() + "</td>");
                tbl.Append("<td class='middle13new' colspan='3'>&nbsp;</td>");

                ////////////////////////////////////////

                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Area:</b>");
                double cal = System.Math.Round(Convert.ToDouble(area1), 2);
                tbl.Append(cal.ToString() + "</td>");

                if (totrol > 0)
                {
                    tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>");
                    double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                    tbl.Append(calf.ToString() + "</td>");
                }
                else
                {
                    tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
                }
                if (totcd > 0)
                {
                    tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Cds:</b>");
                    double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                    tbl.Append(calfd.ToString() + "</td>");
                }
                else
                {
                    tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
                }
                if (totcc > 0)
                {
                    tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total CCs:</b>");
                    double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                    tbl.Append(calft.ToString() + "</td>");
                }
                else
                {
                    tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
                }


                ///////////////////////////////////

                tbl.Append("<td  class='middle13new' colspan='5'  align='right' style='font-size: 13px;'><b>BillAmt:</b>");
                tbl.Append(amt.ToString() + "</td>");
                tbl.Append("<td class='middle13new'  style='font-size: 13px;'></tr>");



                if (browser.Browser == "Firefox")
                {
                    tbl.Append("</table></P>");

                }
                else if (browser.Browser == "IE")
                {
                    if ((ver == 8.0) || (ver == 7.0))
                    {
                        tbl.Append("</table></p>");

                    }
                    else if (ver == 6.0)
                    {
                        tbl.Append("</table></P>");

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

