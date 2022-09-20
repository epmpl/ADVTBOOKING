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

public partial class PrintScheduleRegister : System.Web.UI.Page
{
    int cont1;
    int maxlimit =17;
    string client = "";
    string pdfName1 = "";
    string agency = "";
    int count1 = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;
    int count31 = 0;
    string destination = "";
    string fromdt = "";
    string dateto = "";

    string day = "";
    string month = "";
    string year = "";
    string date = "";

    string datefrom1 = "";
    string dateto1 = "";
    string publ = "";
    string publication = "";
    decimal area = 0;
    decimal paidins = 0;
    string package = "";
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
    string status = "";
    //string fromdt = "";
    //string dateto="";


    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;


    protected void Page_Load(object sender, EventArgs e)
    {

        hiddendateformat.Value = Session["dateformat"].ToString();
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/report1.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
        publication = Request.QueryString["publicationname"].ToString();
         fromdt = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        destination = Request.QueryString["destination"].ToString();
        publ = Request.QueryString["publication"].ToString();
        publicationcenter = Request.QueryString["publicationcenter"].Trim().ToString();
        pubcentcode = Request.QueryString["pubcentcode"].Trim().ToString();
        adtype = Request.QueryString["adtype"].Trim().ToString();
        adtypecode = Request.QueryString["adtypecode"].Trim().ToString();
        adcategory = Request.QueryString["adcategory"].Trim().ToString();
        edition = Request.QueryString["edition"].Trim().ToString();
        editiondetail = Request.QueryString["editiondetail"].Trim().ToString();
        status = Request.QueryString["status"].Trim().ToString();
        
        if (publ == "0")
        {
            lblpublication.Text = "";
        }
        else
        {
            lblpublication.Text = publication.ToString();

        }

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
                datefrom1 = mm + "/" + dd + "/" + yy;

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
        lblpublicationcenter.Text = publicationcenter;
        lbadtype.Text = adtype;
        if (adcategory != "")
        {
            lbadcategory.Text = adcategory;
        }
        else
        {
            lbadcategory.Text = "ALL";
        }
        if (pubcentcode != "0")
        {
            lblpublicationcenter.Text = publicationcenter;
        }
        else
        {
            lblpublicationcenter.Text = "ALL";
        }
        hiddendatefrom.Value = fromdt.ToString();


        onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, status,edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString()); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

    }

    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string status,string edition, string pubcentcode, string adtypecode, string adcategory, string dateformat)  //, string supplement)
    {

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //ds = obj.onscreenreport(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());


        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            // ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter, adtype, edition, supplement, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
            NewAdbooking.classesoracle.Class1 obj = new NewAdbooking.classesoracle.Class1();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status,edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

        }
        if (editiondetail == "0" || editiondetail == "2")
        {
            int i1 = 1;
            string tbl = "";
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
            {//width='50%'
                tbl = "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    tbl += "</table>";
                    // tbl += "</br>";
                    tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                    //tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0'>";
                    if (p == 0)
                    {
                        // tbl += "<tr><td class='p_head' colspan='15' >Display Schedule Register</td></tr>";
                    }
                   

                    tbl += "<tr>";
                    tbl += "<td class='middle111' align='right' colspan='16'>" + "Page  " + s + "  of  " + pagecount;
                    tbl += "</td></tr>";

                    tbl += "<td class='middleSNo' width='5%'  align='right'>" + "S.No." + "</td>";
                    tbl += "<td class='middleSNo' width='8%'  align='left'>" + "CIOID" + "</td>";
                    tbl += "<td class='middle123' width='6%'  align='left'>" + "Ins.Date" + "</td>";
                    tbl += "<td class='middle123' width='12%' align='left'>" + "Agency" + "</td>";
                    tbl += "<td class='middle123' width='12%' align='left'>" + "Client" + "</td>";
                    tbl += "<td class='middle123' width='9%' align='left'>" + "Package" + "</td>";
                    tbl += "<td class='middleSNo' width='3%'  align='right'>" + "WH" + "</td>";
                    tbl += "<td class='middleSNo' width='3%'  align='right'>" + "HT" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='right'>" + "Area" + "</td>";
                    tbl += "<td class='middleSNo' width='3%'  align='left' >" + "Hue" + "</td>";
                    tbl += "<td class='middle123' width='9%'  align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>";
                   // tbl += "<td class='middle123' width='5%'  align='right'>" + "Card" + "</br>" + "Rate" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='right'>" + "Agg" + "</br>" + "Rate" + "</td>";
                    tbl += "<td class='middle123' width='10%' align='left'>" + "Status" + "</br>" + "Instruction" + "</td>";
                    tbl += "<td class='middle123' width='5%'  align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>";
                    tbl += "</tr>";
                    for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                    {
                        int a = d;
                        a = a + 1;

                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_dataSN'  width='5%' align='right'>");
                        tbl = tbl + (i1++.ToString() + "</td>");

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
                            else if (ch % 9 != 0)
                            {
                                cioid1 = cioid1 + cioid[ch];
                            }
                            else
                            {
                                cioid1 = cioid1 + "</br>" + cioid[ch];
                            }
                        }
                        //----------------------------------------------------------------///

                        tbl = tbl + ("<td class='rep_dataSN'  width='8%' align='left'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</td>");

                        tbl = tbl + (cioid1 + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN' width='6%' align='left'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Ins.date"] + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN'  align='left' width='12%'>");
                        //-------------------------------------------//
                        string Agency1 = "";
                        string Agency11 = "";
                        string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                        char[] Agency = AA.ToCharArray();
                        int len12 = Agency.Length;
                        int line1 = 0;

                        for (int ch = 0; ch < len12; ch++)
                        {
                            if (Agency[ch] != ' ')
                            {
                                Agency1 = Agency1 + Agency[ch];
                            }
                        }
                        char[] AA1 = Agency1.ToCharArray();

                        for (int ch = 0; ((ch < AA1.Length) && (line1 < 2)); ch++)
                        {

                            if (ch == 0)
                            {
                                Agency11 = Agency11 + AA1[ch];
                            }
                            else if (ch % 16 != 0)
                            {
                                Agency11 = Agency11 + AA1[ch];
                            }
                            else
                            {

                                line1 = line1 + 1;
                                if (line1 != 2)
                                {
                                    Agency11 = Agency11 + "</br>" + AA1[ch];
                                }
                                // Agency1 = Agency1 + "</br>" + Agency[ch];
                            }
                        }
                        //---------------------------------------------//
                        tbl = tbl + (Agency11 +/*"</br>" + ds.Tables[0].Rows[d]["Spl Instruction"]+*/"</td>");
                        tbl = tbl + ("<td class='rep_dataSN'  align='left' width='12%'>");

                        string Client1 = "";
                        string Client11 = "";
                        string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                        char[] Client = BB.ToCharArray();
                        int len13 = Client.Length;
                        int line2 = 0;

                        for (int ch = 0; ch < len13; ch++)
                        {
                            if (Client[ch] != ' ')
                            {
                                Client1 = Client1 + Client[ch];
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
                                // Agency1 = Agency1 + "</br>" + Agency[ch];
                            }
                        }
                        //---------------------------------------------//
                        // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                        tbl = tbl + (Client11 + /*"</br>"+ ds.Tables[0].Rows[d]["Caption"]+*/ "</td>");
                        tbl = tbl + ("<td class='rep_data' align='left' width='9%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Package"] + /*"</br>" + ds.Tables[0].Rows[d]["Key_no"] +*/ "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='3%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[12].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Width"] + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='3%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Depth"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='5%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");

                        if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                            area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);

                        tbl = tbl + ("<td class='rep_dataSN' align='left' width='3%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Hue"] + "</td>");


                        tbl = tbl + ("<td class='rep_data' width='9%' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN'  width='5%' align='left'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[7].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["PagePremium"] + "" + ds.Tables[0].Rows[d]["PosPremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='5%'>");
                        // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</td>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["PosPremium"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</td>");
                        //tbl = tbl + (ds.Tables[0].Rows[d]["CardRate"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data' align='right' width='5%'>");
                        // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</td>");
                       // Double agrate=Convert.ToDouble(ds.Tables[0].Rows[d]["AgreedRate"]);
                        tbl = tbl + (ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN' align='left' width='10%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[10].ToString() + "</td>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["InsertStatus"] + "</br>" + ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");
                        
                        //tbl = tbl + ("<td class='rep_data'>");
                        //tbl = tbl + (ds.Tables[0].Rows[i]["Key_no"] + "</td>");
                        //tbl = tbl + ("<td class='rep_data' align='right'>");
                        //tbl = tbl + (ds.Tables[0].Rows[d]["Pageno"] + "</td>");
                        tbl = tbl + ("<td class='rep_dataSN' align='left'  width='6%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Adcat"] + "</br>" + ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");

                        if (ds.Tables[0].Rows[d]["Paidins"].ToString() != "")
                            paidins = paidins + Convert.ToInt32(ds.Tables[0].Rows[d]["Paidins"]);

                        if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                            count1++;
                        if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                            count2++;
                        // count2 = count2++;
                        if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                        {
                            if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                count3++;
                            else
                                count31++;
                        }

                        tbl = tbl + "</tr>";
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;


                }
                //tbl = tbl + ("<tr ><td colspan='16'>&nbsp;</td></tr>");
                tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                tbl = tbl + ("<tr><td class='middle31' colspan='2'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='middle3' colspan='2'>TotalArea:" + area.ToString() + "</td><td class='middle31'>Line/Word:" + count3.ToString() + "</td><td id='tdag~3' class='middle3'>Size:" + count31.ToString() + "</td><td id='tdcli~4' class='middle3' colspan='3'>Paid :" + paidins.ToString() + "</td><td id='tdpac~5' class='middle3'>Fmg:" + count1.ToString() + "</td><td id='tdro~29' class='middle3' colspan='3'>HouseAd:" + count2.ToString() + "</td><td id='tdro~26' class='middle3' colspan='2'>Date:" + date.ToString() + "</td></tr>"); //<td id='tdro~25' class='middle3'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td>
                tbl += "</table>";
                div1.Visible = true;
                div1.InnerHtml = tbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }
        }
        else
        {
            int i1 = 1;
            string tbl = "";
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

            if (ds.Tables[0].Rows.Count > 0)
            {
                tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

                for (int p = 0; p < pagecount; p++)
                {
                    int s = p + 1;
                    tbl += "</table>";
                    // tbl += "</br>";
                    tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                    //if (p == 0)
                    //{
                    //    tbl += "<tr><td class='p_head' colspan='15' >Display Schedule Register</td></tr>";
                    //}
                    tbl += "<tr>";
                    tbl += "<td class='middle111' align='right' colspan='16'>" + "Page  " + s + "  of  " + pagecount;
                    tbl += "</td></tr>";

                    tbl += "<td class='middleSNo' width='5%'  align='right'>" + "S.No." + "</td>";
                    tbl += "<td class='middleSNo' width='8%'  align='left'>" + "CIOID" + "</td>";
                    tbl += "<td class='middle123' width='6%'  align='left'>" + "Ins.Date" + "</td>";
                    tbl += "<td class='middle123' width='12%' align='left'>" + "Agency" + "</td>";
                    tbl += "<td class='middle123' width='12%' align='left'>" + "Client" + "</td>";
                    tbl += "<td class='middle123' width='9%' align='left'>" + "Package" + "</td>";
                    tbl += "<td class='middleSNo' width='3%'  align='right'>" + "WH" + "</td>";
                    tbl += "<td class='middleSNo' width='3%'  align='right'>" + "HT" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='right'>" + "Area" + "</td>";
                    tbl += "<td class='middleSNo' width='3%'  align='left' >" + "Hue" + "</td>";
                    tbl += "<td class='middleSNo' width='9%'  align='left'>" + "Caption" + "</br>" + "Keyno" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='left'>" + "Premium" + "</br>" + "Pageno" + "</td>";
                    // tbl += "<td class='middle123' width='5%'  align='right'>" + "Card" + "</br>" + "Rate" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='right'>" + "Agg" + "</br>" + "Rate" + "</td>";
                    tbl += "<td class='middleSNo' width='10%' align='left'>" + "Status" + "</br>" + "Instruction" + "</td>";
                    tbl += "<td class='middleSNo' width='5%'  align='left'>" + "AdCat" + "</br>" + "Subcat" + "</td>";
                    int edi;
                    for (edi = 0; edi < cont1; edi++)
                    {
                        tbl = tbl + ("<td class='edidetail'>");
                        tbl = tbl + (ds.Tables[1].Rows[edi]["Editions"] + "</td>");
                    }
                    //tbl = tbl + ("</tr>");
                    tbl += "</tr>";


                    for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                    {
                        int a = d;
                        a = a + 1;
                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='rep_dataSN'  width='5%' align='right'>");
                        tbl = tbl + (i1++.ToString() + "</td>");

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
                            else if (ch % 9 != 0)
                            {
                                cioid1 = cioid1 + cioid[ch];
                            }
                            else
                            {
                                cioid1 = cioid1 + "</br>" + cioid[ch];
                            }
                        }
                        //----------------------------------------------------------------///

                        tbl = tbl + ("<td class='rep_dataSN'  width='5%'>");
                        tbl = tbl + (cioid1 + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' width='5%' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Ins.date"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN'  align='left' width='12%'>");
                        //-------------------------------------------//
                        string Agency1 = "";
                        string Agency11 = "";
                        string AA = ds.Tables[0].Rows[d].ItemArray[1].ToString();
                        char[] Agency = AA.ToCharArray();
                        int len12 = Agency.Length;
                        int line1 = 0;

                        for (int ch = 0; ch < len12; ch++)
                        {
                            if (Agency[ch] != ' ')
                            {
                                Agency1 = Agency1 + Agency[ch];
                            }
                        }
                        char[] AA1 = Agency1.ToCharArray();

                        for (int ch = 0; ((ch < AA1.Length) && (line1 < 2)); ch++)
                        {

                            if (ch == 0)
                            {
                                Agency11 = Agency11 + AA1[ch];
                            }
                            else if (ch % 16 != 0)
                            {
                                Agency11 = Agency11 + AA1[ch];
                            }
                            else
                            {

                                line1 = line1 + 1;
                                if (line1 != 2)
                                {
                                    Agency11 = Agency11 + "</br>" + AA1[ch];
                                }
                                // Agency1 = Agency1 + "</br>" + Agency[ch];
                            }
                        }
                        //---------------------------------------------//
                        tbl = tbl + (Agency11 + "</td>");
                        
                        tbl = tbl + ("<td class='rep_dataSN'  align='left' width='12%'>");
                        string Client1 = "";
                        string Client11 = "";
                        string BB = ds.Tables[0].Rows[d].ItemArray[2].ToString();
                        char[] Client = BB.ToCharArray();
                        int len13 = Client.Length;
                        int line2 = 0;

                        for (int ch = 0; ch < len13; ch++)
                        {
                            if (Client[ch] != ' ')
                            {
                                Client1 = Client1 + Client[ch];
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
                                // Agency1 = Agency1 + "</br>" + Agency[ch];
                            }
                        }
                        //---------------------------------------------//
                        // tbl = tbl + (ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</td>");
                        tbl = tbl + (Client11 +  "</td>");
                        
                        tbl = tbl + ("<td class='rep_data' align='left' width='11%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Package"] +  "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='5%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Width"] + "</td>");
                       
                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='5%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Depth"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='5%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Area"] + "</td>");

                        if (ds.Tables[0].Rows[d]["Area"].ToString() != "")
                          area = area + Convert.ToInt32(ds.Tables[0].Rows[d]["Area"]);

                        tbl = tbl + ("<td class='rep_dataSN' align='left' width='5%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Hue"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' width='9%' align='left'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Caption"] + "</br>" + ds.Tables[0].Rows[d]["Key_no"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' align='left'  width='5%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["PagePremium"] + "" + ds.Tables[0].Rows[d]["PosPremium"] + "</br>" + ds.Tables[0].Rows[d]["Pageno"] + "</td>");
                        
                        //tbl = tbl + ("<td class='rep_data' align='right' width='5%'>");
                        //tbl = tbl + (ds.Tables[0].Rows[d]["CardRate"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN' align='right' width='5%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["AgreedRate"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN'  valign='top'  width='10%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["InsertStatus"] +"</br>"+ ds.Tables[0].Rows[d]["Spl Instruction"] + "</td>");

                        tbl = tbl + ("<td class='rep_dataSN'  width='6%'>");
                        tbl = tbl + (ds.Tables[0].Rows[d]["Adcat"] +"</br>"+ ds.Tables[0].Rows[d]["AdSubcat"] + "</td>");

                        for (int edi1 = 0; edi1 < cont1; edi1++)
                        {
                            if (ds.Tables[0].Rows[d]["edition"].ToString() == ds.Tables[1].Rows[edi1]["Editions"].ToString())
                            {
                                tbl = tbl + ("<td class='rep_dataSN'>");
                                string insdate = ds.Tables[0].Rows[d]["Ins.date"].ToString();
                                tbl = tbl + (insdate.Substring(3,2) + "</td>");
                            }
                            else
                            {
                                tbl = tbl + ("<td class='rep_data'>");
                            }
                        }

                        if (ds.Tables[0].Rows[d]["Paidins"].ToString() != "")
                            paidins = paidins + Convert.ToInt32(ds.Tables[0].Rows[d]["Paidins"]);

                        if (ConfigurationSettings.AppSettings["FMG"].ToString() == ds.Tables[0].Rows[d]["ratecd"])
                            count1++;
                        if (ConfigurationSettings.AppSettings["HouseAd"].ToString() == ds.Tables[0].Rows[d]["Adcat"].ToString())
                            count2++;
                        // count2 = count2++;
                        if (ds.Tables[0].Rows[d]["Uom"].ToString() != "")
                        {
                            if (ConfigurationSettings.AppSettings["UOM"].ToString() == ds.Tables[0].Rows[d]["Uom"].ToString())
                                count3++;
                            else
                                count31++;
                        }

                        tbl = tbl + "</tr>";
                    }
                    ct = ct + maxlimit;
                    fr = fr + maxlimit;


                }
                tbl = tbl + ("<tr ><td colspan='16'>&nbsp;</td></tr>");
                //tbl = tbl + "<tr><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
                tbl = tbl + ("<tr><td class='total' colspan='2'>TotalAds:" + (i1 - 1).ToString() + "</td><td id='tdcio~1' class='total' colspan='2'>TotalArea:" + area.ToString() + "</td><td class='total'>Line/Word:" + count3.ToString() + "</td><td id='tdag~3' class='total' colspan='2'>Size:" + count31.ToString() + "</td><td id='tdcli~4' class='total' colspan='4'>Paid :" + paidins.ToString() + "</td><td id='tdpac~5' class='total' colspan='3'>Fmg:" + count1.ToString() + "</td><td id='tdro~29' class='total' colspan='3'>HouseAd:" + count2.ToString() + "</td><td id='tdro~26' class='total' colspan='8'>Date:" + date.ToString() + "</td></tr>"); //<td id='tdro~25' class='total' colspan='2'>Page:" + 1 + "-" + (i1 - 1).ToString() + "</td>
                tbl += "</table>";
                div1.Visible = true;
                div1.InnerHtml = tbl;
            }
            else
            {
                Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            }
        }

       
    }

}
