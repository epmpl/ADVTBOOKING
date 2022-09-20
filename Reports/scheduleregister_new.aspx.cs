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
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

public partial class Reports_scheduleregister_new : System.Web.UI.Page
{
    int notot = 0;
    int cnt1 = 0, cnt2 = 0, cnt4 = 0, cnt5 = 0, rowcounter = 0, maxlimit = 47;
    decimal cnt3 = 0;
    int dd2;
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
    int pgn = 1;
    string day = "";
    string month = "";
    string year = "";
    string date = "";

    string datefrom1 = "", adcatname = "";
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
    int cont1;
    //string fromdt = "";
    //string dateto="";
    int totunaudit = 0, totaudit = 0, temptotunaudit = 0, temptotaudit = 0;
    string branch_code = "", branch_name = "", ro_statuscod = "", ro_statusnam = "";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    string sortfield = "";
    string sorting = "", supplementcode = "", package11name = "", ciod = "";
    double sqcm = 0, colcm = 0, other = 0, totrol = 0, totcd = 0, totcc = 0, areaset = 0;

    double tempsqcm = 0, tempcolcm = 0, tempother = 0, temptotrol = 0, temptotcd = 0, temptotcc = 0, tempareaset = 0;

    string package11 = "", pkgdetail = "";
    DataSet ds;
    string editionname = "";
    string name1 = "", name2 = "", name3 = "", hdnasc = "";
    string chk_excel = "";

    string edipre, edichange;
    string section;

    double totgamt = 0, totsur = 0, totcom = 0, tototh = 0, totnet = 0, totspace = 0, totbox = 0, totdisc = 0;
    double Atotnet = 0, Atotspace = 0, Atotrate = 0;
    double totgamt1 = 0, totsur1 = 0, totcom1 = 0, tototh1 = 0, totnet1 = 0, totspace1 = 0, totrate1 = 0;
    double Gtotgamt = 0, Gtotsur = 0, Gtotbox = 0, Gtototh = 0, Gtotnet = 0, Gtotcom = 0, Gtotrate = 0, Gtotdisc = 0;
    double Gtotnet1 = 0, Gtotspace1 = 0, Gtotrate1 = 0;

    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
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


        string[] prm_Array = new string[44];


        DataSet ds1 = new DataSet();







        destination = Request.QueryString["destination"].ToString();
        fromdt = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        publ = Request.QueryString["publication"].ToString();
        publication = Request.QueryString["publicationname"].ToString();
        edition = Request.QueryString["edition"].Trim().ToString();
        editionname = Request.QueryString["editionname"].Trim().ToString();
        publicationcenter = Request.QueryString["publicationcenter"].Trim().ToString();
        pubcentcode = Request.QueryString["pubcentcode"].Trim().ToString();
        adtype = Request.QueryString["adtype"].Trim().ToString();
        adtypecode = Request.QueryString["adtypecode"].Trim().ToString();
        adcategory = Request.QueryString["adcategory"].Trim().ToString();
        editiondetail = Request.QueryString["editiondetail"].Trim().ToString();
        status = Request.QueryString["status"].Trim().ToString();
        adcatname = Request.QueryString["adcatname"].Trim().ToString();
        supplementcode = Request.QueryString["supplementcode"].Trim().ToString();
        package11 = Request.QueryString["package11"].Trim().ToString();
        pkgdetail = Request.QueryString["pkgdetail"].Trim().ToString();
        package11name = Request.QueryString["package11name"].Trim().ToString();
        chk_excel = Request.QueryString["chk_excel"].Trim().ToString();
        branch_code = Request.QueryString["branch_code"].Trim().ToString();
        branch_name = Request.QueryString["branch_name"].Trim().ToString();
        hdnasc = Request.QueryString["hdnasc"].Trim().ToString();
        ciod = Request.QueryString["ciod"].Trim().ToString();
        ro_statuscod = Request.QueryString["rostatus_code"].Trim().ToString();
        ro_statusnam = Request.QueryString["rostatus"].Trim().ToString();

        section = Request.QueryString["designer"].Trim().ToString();
        string[] parameterValueArray = new string[] { fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), ciod, hdnasc, supplementcode, package11, pkgdetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod, section };
        // DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            if (hiddendateformat.Value == "dd/mm/yyyy")
            {
                fromdt = DMYToMDY(fromdt);
                dateto = DMYToMDY(dateto);
            }


            else if (hiddendateformat.Value == "yyyy/mm/dd")
            {
                fromdt = YMDToMDY(fromdt);
                dateto = YMDToMDY(dateto);
            }
            NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), ciod, hdnasc, supplementcode, package11, pkgdetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod, section);

        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), ciod, hdnasc, supplementcode, package11, pkgdetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod);

        }

        else
        {
            string procedureName = "Schedulereport1";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
       // return ds;

        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_scheduleregister_new));

        if (ds.Tables[0].Rows.Count == 0)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_scheduleregister_new), "sa", "alert(\"searching criteria is not valid\");window.close();", true);

            return;
        }
        if (edition == "")
            edition = "0";


        if (pkgdetail == "0")
        {
            pubnamelb.Text = "PUBLICATION:";
            if (publ == "0")
            {
                lblpublication.Text = "";
            }
            else
            {
                lblpublication.Text = publication.ToString();

            }
        }
        else
        {
            pubnamelb.Text = "PACKAGE:";
            if (package11name == "--Select Package--")
            {
                lblpublication.Text = "All";
            }
            else
            {
                lblpublication.Text = package11name.ToString();
            }
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

        lblfrom.Text = fromdt;
        datefrom1 = fromdt;
        lblto.Text = dateto;
        dateto1 = dateto;




        lbadtype.Text = adtype;
        if (adcategory != "")
        {
            lbadcategory.Text = adcatname;
        }
        else
        {
            lbadcategory.Text = "ALL";
        }
        if (edition != "" && edition != "0")
            lbedition.Text = editionname;
        else
            lbedition.Text = "ALL";

        lblrostatus.Text = ro_statusnam;

        if (pubcentcode != "0")
        {
            lblpublicationcenter.Text = publicationcenter;
        }
        else
        {
            lblpublicationcenter.Text = "ALL";
        }
        hiddendatefrom.Value = fromdt.ToString();
        btnprint.Attributes.Add("onclick", "javascript:return forclick();");
        if (!IsPostBack)
        {
            if (destination == "1" || destination == "0" || destination == "4")
            {


                onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            }
            //else if (destination == "4")
            //{

            //    //excel(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());

            //}
            //else
            //    if (destination == "3")
            //    {

            //        //pdf(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
            //    }
        }

        else if (hiddenascdesc.Value != "")
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                string from_date1 = "";
                string to_date1 = "";
                if (hiddendateformat.Value == "dd/mm/yyyy")
                {
                    from_date1 = DMYToMDY(fromdt);
                    to_date1 = DMYToMDY(dateto);
                }


                else if (hiddendateformat.Value == "yyyy/mm/dd")
                {
                    from_date1 = YMDToMDY(fromdt);
                    to_date1 = YMDToMDY(dateto);
                }
                NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();

                ds = obj.displayonscreenreport(from_date1, to_date1, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package11, editiondetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod, section);

            }
            else
            {
                NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();

                ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), supplementcode, package11, editiondetail, Session["userid"].ToString(), Session["access"].ToString(), branch_code, ro_statuscod);

            }

            Session["schedulerep"] = ds;
            onscreen(fromdt, dateto, Session["compcode"].ToString(), publ, status, edition, pubcentcode, adtypecode, adcategory, Session["dateformat"].ToString(), package11); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
    }
    private void onscreen(string fromdt, string dateto, string compcode, string pub1, string status, string edition, string pubcentcode, string adtypecode, string adcategory, string dateformat, string package111)  //, string supplement)
    {

        sortfield = hiddencioid.Value.Trim();
        sorting = hiddenascdesc.Value.Trim();
        SqlDataAdapter da = new SqlDataAdapter();
        cmpnyname.Text = ds.Tables[4].Rows[0].ItemArray[1].ToString();
        string tab4date = ds.Tables[4].Rows[0].ItemArray[0].ToString();

        int contc = ds.Tables[0].Columns.Count;
        double[] arr1 = new double[contc];
        StringBuilder TBL = new StringBuilder();

        string Find_edtn = "";
        //string find_agcode = "";

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
            return;
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno = 1;

            TBL.Append("<tr>");
            TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:13px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
            TBL.Append("</tr>");
            pgn++;
            TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='2%'><b>" + "Sr.No" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "RO.Control No" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='14%'><b>" + "Agency Name" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='14%'><b>" + "Client Name" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "AdType" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Page No" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Ad Size" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "SurCh.Amt" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Box Ch Amt" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sp Disc Amt" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
            TBL.Append("</tr>");


            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='2%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Booking Date" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'><b>" + "Address" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'><b>" + "RO No" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Caption" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Program RO" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Aggreed Rate" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "SurCh %" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Box Ch %" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Comm%" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Sp Disc" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("</tr>");

            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='2%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Agency ID" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='14%'><b>" + "Location" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='14%'><b>" + "RO Date" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Key" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Pre Reciept" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "SP Amount" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("<td colspan='2' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='14%'><b>" + "Ad First Sch" + "</b></td>");
            //TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
            TBL.Append("</tr>");

            rowcounter = rowcounter + 8;

            Find_edtn = ds.Tables[0].Rows[0]["edition_name"].ToString();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (rowcounter >= maxlimit)
                {
                    rowcounter = 0;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        TBL.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");

                        TBL.Append("<tr>");
                        TBL.Append("<td class='mis_hdr1' colspan='10'  align='right' style='font-size:13px; '><b>" + " Page no :" + " " + pgn + "</b></td>");
                        TBL.Append("</tr>");
                        pgn++;
                        TBL.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'>");
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='2%'><b>" + "Sr.No" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "RO.Control No" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='14%'><b>" + "Agency Name" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='14%'><b>" + "Client Name" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "AdType" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Page No" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Ad Size" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "SurCh.Amt" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Box Ch Amt" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Comm Amt" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Sp Disc Amt" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;' width='7%'><b>" + "Net Amt" + "</b></td>");
                        TBL.Append("</tr>");


                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='2%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Booking Date" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'><b>" + "Address" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'><b>" + "RO No" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Caption" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'><b>" + "Program RO" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Aggreed Rate" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "SurCh %" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Box Ch %" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Comm%" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>" + "Sp Disc" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("</tr>");

                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='2%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Agency ID" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='14%'><b>" + "Location" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='14%'><b>" + "RO Date" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Key" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "Pre Reciept" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>" + "SP Amount" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("<td colspan='2' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='14%'><b>" + "Ad First Sch" + "</b></td>");
                        //TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'><b>&nbsp;</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 4;
                    }

                }

                if (i == 0)
                {
                    TBL.Append("<tr font-family='Arial'>");
                    TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;' width='14%'><b>" + "Edition:-" + ds.Tables[0].Rows[i]["edition_name"] + "</b></td>");
                    TBL.Append("</tr>");
                }
                else
                {
                    if (Find_edtn.IndexOf(ds.Tables[0].Rows[i]["edition_name"].ToString()) < 0)
                    {
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='6' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='51%'><b>" + "Edition Total" + "</b></td>");
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totgamt) + "<b></td>");
                        Gtotgamt = Gtotgamt + totgamt;
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totsur) + "<b></td>");
                        Gtotsur = Gtotsur + totsur;
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totbox) + "<b></td>");
                        Gtotbox = Gtotbox + totbox;
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totcom) + "<b></td>");
                        Gtotcom = Gtotcom + totcom;
                        TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totdisc) + "<b></td>");
                        Gtotdisc = Gtotdisc + totdisc;
                        TBL.Append("<td colspan='2' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='14%'><b>" + string.Format("{0:0.00}", totnet) + "<b></td>");
                        Gtotnet = Gtotnet + totnet;
                        TBL.Append("</tr>");
                        Find_edtn += ds.Tables[0].Rows[i]["edition_name"].ToString();
                        totgamt = 0; totsur = 0; totbox = 0; totdisc = 0; totnet = 0; totcom = 0; //totrate1 = 0;
                        TBL.Append("<tr font-family='Arial'>");
                        TBL.Append("<td colspan='2' style='text-align:Left;font-size:11px;' width='14%'><b>" + "Edition:-" + ds.Tables[0].Rows[i]["edition_name"] + "</b></td>");
                        TBL.Append("</tr>");
                        rowcounter = rowcounter + 1;
                    }


                }

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='2%'>" + sno + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["CIOID"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'>" + ds.Tables[0].Rows[i]["Agency"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'>" + ds.Tables[0].Rows[i]["Client"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["Adcat"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["PagePremium"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["Depth"].ToString() + "<b>x</b>" + ds.Tables[0].Rows[i]["Width"].ToString() + "<b>/</b>" + ds.Tables[0].Rows[i]["Area"].ToString() + "</td>");

                if (ds.Tables[0].Rows[i]["Special_charges"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Special_charges"].ToString()).ToString("f2") + "</td>");//sruch amt
                    totsur = totsur + Convert.ToDouble(ds.Tables[0].Rows[i]["Special_charges"].ToString());
                }

                if (ds.Tables[0].Rows[i]["boxchrg"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["boxchrg"].ToString()).ToString("f2") + "</td>");//boxch amt
                    totbox = totbox + Convert.ToDouble(ds.Tables[0].Rows[i]["boxchrg"].ToString());
                }
                if (ds.Tables[0].Rows[i]["comm_amt"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString()).ToString("f2") + "</td>");//comm amt
                    totcom = totcom + Convert.ToDouble(ds.Tables[0].Rows[i]["comm_amt"].ToString());
                }

                if (ds.Tables[0].Rows[i]["DISCOUNT"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["DISCOUNT"].ToString()).ToString("f2") + "</td>");//Sp disc amt
                    totdisc = totdisc + Convert.ToDouble(ds.Tables[0].Rows[i]["DISCOUNT"].ToString());
                }
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                //netamt
                if (ds.Tables[0].Rows[i]["net_amt"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["net_amt"].ToString()).ToString("f2") + "</td>");//net amt
                    totnet = totnet + Convert.ToDouble(ds.Tables[0].Rows[i]["net_amt"].ToString());
                }
                TBL.Append("<tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='2%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["booking_date"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'>" + ds.Tables[0].Rows[i]["ag_add"].ToString() + "</td>");//address
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='14%'>" + ds.Tables[0].Rows[i]["RO_No"].ToString() + "</td>");//rono
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["Caption"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["NO_INSERT"].ToString() + "</td>");//programro
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"].ToString()).ToString("f2") + "</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");//sruch %
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");//Other ch
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["AgencyComm"].ToString() + "</td>");//comm %
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>" + ds.Tables[0].Rows[i]["DISCOUNT_PER"].ToString() + "</td>");//Sp disc %
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;' width='7%'>&nbsp;</td>");
                TBL.Append("<tr>");

                TBL.Append("<tr font-family='Arial'>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='2%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'>" + ds.Tables[0].Rows[i]["agcode"].ToString() + "</td>");//agcd
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='14%'>" + ds.Tables[0].Rows[i]["CITY_NAME"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='14%'>" + ds.Tables[0].Rows[i]["RO_DATE"].ToString() + "</td>");//rodate
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'>" + ds.Tables[0].Rows[i]["Key_no"].ToString() + "</td>");
                TBL.Append("<td colspan='0' style='text-align:Left;font-size:11px;border-bottom:solid 1px black;' width='7%'>" + ds.Tables[0].Rows[i]["pre_receipt"].ToString() + "</td>");//prerecpt
                //agreedamt
                if (ds.Tables[0].Rows[i]["Agreed_amt"].ToString() == "")
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                }
                else
                {
                    TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_amt"].ToString()).ToString("f2") + "</td>");//net amt
                    totgamt = totgamt + Convert.ToDouble(ds.Tables[0].Rows[i]["Agreed_amt"].ToString());
                }
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                TBL.Append("<td colspan='2' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='14%'>" + ds.Tables[0].Rows[i]["Ins.date"].ToString() + "</td>");
                //TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-bottom:solid 1px black;' width='7%'>&nbsp;</td>");
                TBL.Append("<tr>");
                Find_edtn += ds.Tables[0].Rows[0]["edition"].ToString();
                sno++;
                rowcounter = rowcounter + 3;
            }
            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='6' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='51%'><b>" + "Edition Total" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totgamt) + "<b></td>");
            Gtotgamt = Gtotgamt + totgamt;
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totsur) + "<b></td>");
            Gtotsur = Gtotsur + totsur;
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totbox) + "<b></td>");
            Gtotbox = Gtotbox + totbox;
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totcom) + "<b></td>");
            Gtotcom = Gtotcom + totcom;
            TBL.Append("<td colspan='0' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", totdisc) + "<b></td>");
            Gtotdisc = Gtotdisc + totdisc;
            TBL.Append("<td colspan='2' style='text-align:right;font-size:11px;border-top:solid 1px black;border-bottom:solid 1px black;' width='14%'><b>" + string.Format("{0:0.00}", totnet) + "<b></td>");
            Gtotnet = Gtotnet + totnet;
            TBL.Append("</tr>");

            TBL.Append("<tr font-family='Arial'>");
            TBL.Append("<td colspan='6' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='51%'><b>" + "Grand Total" + "</b></td>");
            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Gtotgamt) + "<b></td>");

            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Gtotsur) + "<b></td>");

            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Gtotbox) + "<b></td>");

            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Gtotcom) + "<b></td>");

            TBL.Append("<td colspan='0' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='7%'><b>" + string.Format("{0:0.00}", Gtotdisc) + "<b></td>");

            TBL.Append("<td colspan='2' style='text-align:right;font-size:12px;border-top:solid 1px black;border-bottom:solid 1px black;' width='14%'><b>" + string.Format("{0:0.00}", Gtotnet) + "<b></td>");

            TBL.Append("</tr>");
            rowcounter = rowcounter + 2;
        }
        TBL.Append("</table>");
        TBL.Append("</table></p>");
        tblgrid.InnerHtml = TBL.ToString();
        if (destination == "4")
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=schedule_register.xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            tblgrid.InnerHtml = TBL.ToString();
            tblgrid.Visible = true;
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }
}