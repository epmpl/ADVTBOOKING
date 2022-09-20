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

public partial class Reports_printrepresentative_ledger : System.Web.UI.Page
{

    double grouptotal_Govt = 0;
    double grouptotal_local = 0;
    double grouptotal_national = 0;
    int netsum = 0;
    double areanew = 0;
    double areasum = 0;
    string client = "";
    string pdfName1 = "";
    string agency = "";
    int sno = 1;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    double amtnew = 0;
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    double amtsum = 0;
    string datefrom1 = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    double amt1 = 0;
    string package = "";
    string dateformate = "";
    string pubcent = "";
    string sortorder = "";
    string sortvalue = "";
    string value = "";
    string adtyp = "";
    string bill = "";
    string execut = "";
    string team = "";
    string cl = "";
    string ag = "";
    decimal payment = 0;
    double amtnet = 0;
    int maxlimit = 22;
    int chkfirst = 0;
    string sortfield = "";
    string district = "";
    string branch = "";
    string districtname = "";
    string branchname = "";
    string sorting = "", retainercode = "", retainername = "", rep = "", adtypename = "", pubcentname = "";
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
      //  maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[31].ToString());
        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);



        ds = (DataSet)Session["repledger"];
        string prm = Session["prm_repledger_print"].ToString();
        string[] prm_Array = new string[37];
        prm_Array = prm.Split('~');


        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        pubcent = prm_Array[7]; //Request.QueryString["pubcent"].ToString();
        publ = prm_Array[9]; //Request.QueryString["publication"].ToString();
        publication = prm_Array[11]; //Request.QueryString["publicationname"].ToString();
        adtyp = prm_Array[13]; //Request.QueryString["adtyp"].ToString();
        execut = prm_Array[15]; //Request.QueryString["execut"].Trim().ToString();
        team = prm_Array[17]; //Request.QueryString["team"].Trim().ToString();
        bill = prm_Array[19]; //Request.QueryString["bill"].Trim().ToString();
        cl = prm_Array[21]; //Request.QueryString["cl"].Trim().ToString();
        ag = prm_Array[23]; //Request.QueryString["ag"].Trim().ToString();
        sortfield = prm_Array[25]; //Request.QueryString["sortfield"].Trim().ToString();
        sorting = prm_Array[27]; //Request.QueryString["sorting"].Trim().ToString();
        retainercode = prm_Array[29]; //Request.QueryString["retainercode"].Trim().ToString();
        retainername = prm_Array[31]; //Request.QueryString["retainername"].Trim().ToString();
        rep = prm_Array[33]; //Request.QueryString["rep"].Trim().ToString();
        adtypename = prm_Array[35]; //Request.QueryString["adtypename"].Trim().ToString();
        district = prm_Array[45];
        branch = prm_Array[41];
        districtname = prm_Array[39];
        branchname = prm_Array[43];
        pubcentname = prm_Array[37]; //Request.QueryString["pubcentname"].Trim().ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        if(rep=="1")
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
        else
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();

        if (publication == "--Select Revenue Center--")
        {
            lblpublication.Text = "All";
        }
        else
        {
            lblpublication.Text = publication.ToString();

        }
        if (adtyp == "0")
        {
            lbladtype.Text = "All";
        }
        else
        {
            lbladtype.Text = adtypename.ToString();

        }
        if (pubcent == "0")
        {
            lblpubcent.Text = "All";
        }
        else
        {
            lblpubcent.Text = pubcentname.ToString();

        }

        if (branch == "0" || branch == "")
        {
            lblbranch.Text = "All";
        }
        else
        {
            lblbranch.Text = branchname.ToString();

        }



        if (district == "0" || district == "")
        {
            lbldistrict.Text = "All";
        }
        else
        {
            lbldistrict.Text = districtname.ToString();

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
        //  lbldate.Text = Convert.ToDateTime(date).ToString("dd-MMM-yyyy");
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
        // lblfrom.Text = Convert.ToDateTime(datefrom1).ToString("dd-MMM-yyyy");
        lblfrom.Text = datefrom1;
        //dateto1 = "";
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
        //  lblto.Text = Convert.ToDateTime(dateto1).ToString("dd-MMM-yyyy");
        lblto.Text = dateto1;

        hiddendatefrom.Value = fromdt.ToString();

        onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString());

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


    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string dateformat)
    {
        string agn = "";
        string agnnew = "";
        int agamt = 0;
        int agamtnew = 0;
        string agsamt = "";
        string agsamtnew = "";
        string agnj = "";
        string agnnewj = "";
        int agamtj = 0;
        int agamtnewj = 0;
        int agamtnew1 = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    //NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    //ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.representative(pubcent, adtyp, fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), sortfield, sorting, value, execut, team, bill, cl, ag,retainercode,rep);
        //}
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
        int i1 = 1;
        string tbl = "";
        int ct = 0;
        int fr = maxlimit;
       // int brk = ds.Tables[1].Rows.Count;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        int j = 0;
        int sn = 1;
        double amtnet1 = 0;
        int cont = ds.Tables[0].Rows.Count;
        double group_govt = 0;
        double group_local = 0;
        double group_national = 0;
        double newamt = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {//width='50%'
           //tbl = "<table width='100%'  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";
            if (browser.Browser == "Firefox")
            {
             //   tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 7.0) || (ver == 8.0))
                {
                    tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
                else if (ver == 6.0)
                {
                    tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
                }
            }    


            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                if (browser.Browser == "Firefox")
                {
                    if (p != 0)
                    {
                        tbl = tbl + "</table></P>";
                        if (p == pagecount )
                            tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                        else
                            tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    }
                }
                else if (browser.Browser == "IE")
                {
                    
                        if ((ver == 8.0) || (ver == 7.0))
                        {
                            tbl = tbl + "</table></P>";
                            if (p == pagecount-1)
                                tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            else
                                tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                        }
                        else if (ver == 6.0)
                        {
                            tbl = tbl + "</table>";
                            if (p == pagecount)
                                tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                            else
                                tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                        }
                    
                }
               // tbl += "</table>";
                // tbl += "</br>";
             
                // tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";

                tbl += "<tr valign='top'>";
                
                tbl += "<td class='middle111' align='right' colspan='11'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

                tbl = tbl + ("<tr><td class='middle123'>S.No.</td><td class='middle123' align='left'>Agency</td><td class='middle123' align='left'>Edition</td><td class='middle123' align='left'>Publish</br>Date</td><td  class='middle123' align='left'>Package</td><td class='middle123' align='left'>Client</td><td class='middle123' align='left'>Ro.No.</td><td class='middle123' align='left'>Ro.Date</td><td class='middle123' align='left'>Key</td><td class='middle123' align='right'>NetAmt&nbsp;&nbsp;</td><td  class='middle123' align='left'>Adcategory</td></tr>"); //<td class='middle31'>Remarks1</td><td class='middle31'>Remarks2</td>

                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                    {
                        int a = d;
                        a = a + 1;



                        if (rep == "1")
                        {
                            if (d == 0)
                            {

                                tbl = tbl + ("<tr >");
                                tbl = tbl + ("<td class='rep_data2' align='left'>Executive");
                                tbl = tbl + ("</td>");
                                tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[d]["Executive"]);
                                tbl = tbl + ("</td>");
                                tbl = tbl + ("</tr >");
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[d]["Executive"].ToString() != ds.Tables[0].Rows[d - 1]["Executive"].ToString())
                                {
                                    sn = 1;
                                    tbl = tbl + ("<tr >");
                                    tbl = tbl + ("<td class='rep_data2' colspan='9' align='right'>Total");
                                    tbl = tbl + ("</td>");
                                    tbl = tbl + ("<td class='rep_data2'  align='right'>" + chk_null(amtnet1.ToString()));
                                    tbl = tbl + ("&nbsp;&nbsp;</td>");
                                    tbl = tbl + ("</tr >");
                                    amtnet1 = 0;

                                    tbl = tbl + ("<tr >");
                                    tbl = tbl + ("<td class='rep_data2' align='left'>Executive");
                                    tbl = tbl + ("</td>");
                                    tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[d]["Executive"]);
                                    tbl = tbl + ("</td>");
                                    tbl = tbl + ("</tr >");
                                }
                            }
                        }
                        else if (rep == "2")
                        {


                            if (d == 0)
                            {
                                tbl = tbl + ("<tr >");
                                tbl = tbl + ("<td class='rep_data2' align='left'>Retainer");
                                tbl = tbl + ("</td>");
                                tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[d]["Retainer"]);
                                tbl = tbl + ("</td>");
                                tbl = tbl + ("</tr >");
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[d]["Retainer"].ToString() != ds.Tables[0].Rows[d - 1]["Retainer"].ToString())
                                {
                                    sn = 1;
                                    tbl = tbl + ("<tr >");
                                    tbl = tbl + ("<td class='rep_data2' align='left'>Total");
                                    tbl = tbl + ("</td>");
                                    tbl = tbl + ("<td class='rep_data2' colspan='9' align='right'>" + amtnet1);
                                    tbl = tbl + ("&nbsp;&nbsp;</td>");
                                    tbl = tbl + ("</tr >");
                                    amtnet1 = 0;


                                    tbl = tbl + ("<tr >");
                                    tbl = tbl + ("<td class='rep_data2' align='left'>Retainer");
                                    tbl = tbl + ("</td>");
                                    tbl = tbl + ("<td class='rep_data2' colspan='3' align='left'>" + ds.Tables[0].Rows[d]["Retainer"]);
                                    tbl = tbl + ("</td>");
                                    tbl = tbl + ("</tr >");
                                }
                            }
                        }




                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_data'>");
                        tbl = tbl + (sn++.ToString() + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Agency"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");

                        tbl = tbl + (ds.Tables[0].Rows[d]["edition"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Ins.Date"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Package"] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Client"] + "</td>");


                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Ro.No."] + "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Ro.Date"] + "</td>");


                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        if (ds.Tables[0].Rows[d]["Key"].ToString() == "-Select Heading-")
                        {
                            tbl = tbl + ("" + "</td>");
                        }
                        else
                        {
                            tbl = tbl + (ds.Tables[0].Rows[d]["Key"] + "</td>");
                        }


                        tbl = tbl + ("<td class='rep_data' align='right'>");

                        if (ds.Tables[0].Rows[d]["NetAmt"].ToString() != "")
                        {
                            amtnet = Convert.ToDouble(ds.Tables[0].Rows[d]["NetAmt"].ToString());
                            amtnet1 = amtnet1 + Convert.ToDouble(ds.Tables[0].Rows[d]["NetAmt"].ToString());


                            newamt = newamt + Convert.ToDouble(ds.Tables[0].Rows[d]["NetAmt"].ToString());

                        }



                        tbl = tbl + (chk_null(ds.Tables[0].Rows[d]["NetAmt"].ToString()) + "&nbsp;&nbsp;</td>");

                        tbl = tbl + ("<td class='rep_data' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Adcat"] + "</td>");


                        if (ds.Tables[0].Rows[d]["FinalGRP"].ToString() == "GOVT.")
                        {

                            if (ds.Tables[0].Rows[d]["NetAmt"].ToString() != "")
                                group_govt = Convert.ToDouble(ds.Tables[0].Rows[d]["NetAmt"].ToString());
                            grouptotal_Govt = grouptotal_Govt + group_govt;
                        }
                        if (ds.Tables[0].Rows[d]["FinalGRP"].ToString() == "NATIONAL")
                        {

                            if (ds.Tables[0].Rows[d]["NetAmt"].ToString() != "")
                                group_national = Convert.ToDouble(ds.Tables[0].Rows[d]["NetAmt"].ToString());
                            grouptotal_national = grouptotal_national + group_national;
                        }
                        if (ds.Tables[0].Rows[d]["FinalGRP"].ToString() == "LOCAL")
                        {

                            if (ds.Tables[0].Rows[d]["NetAmt"].ToString() != "")
                                group_local = Convert.ToDouble(ds.Tables[0].Rows[d]["NetAmt"].ToString());
                            grouptotal_local = grouptotal_local + group_local;

                        }
                        tbl = tbl + "</tr>";

                        if (d == cont - 1)
                        {
                            tbl = tbl + ("<tr >");
                            tbl = tbl + ("<td class='rep_data2' colspan='9' align='right'>Total");
                            tbl = tbl + ("</td>");
                            tbl = tbl + ("<td class='rep_data2'  align='right'>" + chk_null(amtnet1.ToString()));
                            tbl = tbl + ("</td>");
                            tbl = tbl + ("</tr >");
                        }

                        div1.InnerHtml += tbl;
                        tbl = "";
                    }
                
                

                ct = ct + maxlimit;
                fr = fr + maxlimit;
                if (ct >= ds.Tables[0].Rows.Count)
                    break;

            }
           // tbl = tbl + ("<tr >");
       //     tbl = tbl + "<tr><td class='middle4' colspan='11' width='4px'>&nbsp;</td></tr>";

           // tbl = tbl + ("<tr >");
           // tbl = tbl + ("<td class='middle13'>");
            tbl = tbl + ("<tr><td class='middle123' colspan='3' align='left'>TotalAds.=");
            tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            tbl = tbl + (cont.ToString() + "</td>");
            tbl = tbl + ("<td class='middle123'>");
            tbl = tbl + ("&nbsp;</td><td class='middle123'>&nbsp;</td>");
            tbl = tbl + ("<td class='middle123'>&nbsp;");
            //tbl = tbl + (area.ToString());
            tbl = tbl + ("</td><td class='middle123'>&nbsp;</td><td class='middle123'>&nbsp;</td><td class='middle123'>TotalAmt</td>");
            tbl = tbl + ("<td class='middle123' align='right'>");
            tbl = tbl + (chk_null(newamt.ToString()) + "</td><td class='middle123'>&nbsp;</td>");
            tbl = tbl + "</tr>";

           // //tbl = tbl + ("<tr >");
           //// tbl = tbl + ("<td class='middle13'>");
           // tbl = tbl + ("<tr><td class='rep_data2' colspan='3' align='left'>Govt.Total=");
           // tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
           // tbl = tbl + (grouptotal_Govt.ToString() + "</td>");
           // tbl = tbl + ("</tr>");
           //// tbl = tbl + ("</td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td>");

           //// tbl = tbl + ("<td class='middle13'>");
           // tbl = tbl + ("<tr><td class='rep_data2' colspan='3' align='left'>Nat.Total=");
           // tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
           // tbl = tbl + (grouptotal_national.ToString() + "</td>");
           //// tbl = tbl + ("</td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td>");
           // tbl = tbl + ("</tr>");

           // //tbl = tbl + ("<td class='middle13'>");
           // tbl = tbl + ("<tr><td class='rep_data2' colspan='3' align='left'>LocalTotal=");
           // tbl = tbl + ("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
           // tbl = tbl + (grouptotal_local.ToString() + "</td>");
           // //tbl = tbl + ("</td><td class='middle13'></td><td class='middle13'></td><td class='middle13'></td>");
           // tbl = tbl + "</tr>";
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
           //tbl = tbl + ("</table>");
            div1.Visible = true;
            div1.InnerHtml += tbl;
        }
    }
}
