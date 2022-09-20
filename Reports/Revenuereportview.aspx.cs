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

public partial class Revenuereportview : System.Web.UI.Page
{
    string day = "";
    string month = "";
    string year = "";
    string date = "";
    string datefrom1 = "";
    string dateto1 = "";
    string pubcode = "";
    string publication = "";
    string edition = "";
    string editioncode = "";
    string destination = "";
    string fromdt = "";
    string dateto = "";
    double Netamt = 0;
    double Totalads = 0;
    double Grossamt = 0;
    double ActualBuss = 0.00, agencyadddisc = 0.00, agencydisc = 0.00, gstamount = 0.00, billamount = 0.00;
    string adtypecode = "", adtypename = "", pubcentcode = "", pubcentname = "" , reporttype="";
    double grandGrossamt = 0.00, grandagencydisc = 0.00, grandgstamount = 0.00, grandbillamount = 0.00;
 
    DataSet ds;
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
       

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));
        heading.Text = ds1.Tables[0].Rows[0].ItemArray[83].ToString();

        
        ds = (DataSet)Session["revsum"];
        string prm = Session["prm_revsum"].ToString();
        string[] prm_Array = new string[22];
        prm_Array = prm.Split('~');



        destination = prm_Array[1];// Request.QueryString["destination"].ToString();
        fromdt = prm_Array[3]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[5]; //Request.QueryString["dateto"].ToString();
        editioncode = prm_Array[7]; //Request.QueryString["edition"].Trim().ToString();
        edition = prm_Array[9]; //Request.QueryString["editionname"].Trim().ToString();
        pubcode = prm_Array[11]; //Request.QueryString["publication"].ToString();
        publication = prm_Array[13]; //Request.QueryString["publicationname"].ToString();
        adtypecode = prm_Array[15]; //Request.QueryString["adtypecode"].Trim().ToString();
        adtypename = prm_Array[17]; //Request.QueryString["adtypename"].Trim().ToString();
        pubcentcode = prm_Array[19]; //Request.QueryString["pubcentcode"].Trim().ToString();
        pubcentname = prm_Array[21]; //Request.QueryString["pubcentname"].Trim().ToString();
        reporttype  = prm_Array[23];

        Ajax.Utility.RegisterTypeForAjax(typeof(Revenuereportview));

        if (pubcode == "0")
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
     
        hiddendatefrom.Value = fromdt.ToString();
        if (!IsPostBack)
        {
            //if (destination == "1" || destination == "0")
            //{
                if (reporttype == "D")
                {
                    onscreen(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode); //, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
                }
                else if (reporttype == "P")
                {
                    onscreenpublication(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode);
                }
                else if (reporttype == "S")
                {
                    onscreenstate(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode);
                }
                else if (reporttype == "R")
                {
                    onscreenrevenue(fromdt, dateto, pubcode, editioncode, Session["dateformat"].ToString(), adtypecode, pubcentcode);
                }
           // }
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
    private void onscreen(string fromdt, string dateto, string pubcode, string editioncode, string dateformat, string adtypecode, string pubcentcode)  //, string supplement)
    {

       // SqlDataAdapter da = new SqlDataAdapter();
        //DataSet ds = new DataSet();
       
        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        //{
        //    NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
        //    // ds = obj.displayonscreenreport(fromdt, dateto, Session["compcode"].ToString(), publ, Session["dateformat"].ToString(), publicationcenter, adtype, edition, supplement, hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        //}
        //else
        //{
        //    NewAdbooking.Report.classesoracle.SummaryReport obj = new NewAdbooking.Report.classesoracle.SummaryReport();
        //    ds = obj.IssueBusnonscreen(fromdt, dateto, pubcode, editioncode, dateformat, adtypecode, pubcentcode, Session["compcode"].ToString());//

        //}
        cmpnyname.Text = "TEST";//ds.Tables[0].Rows[0]["companyname"].ToString();

            string tbl = "";
            //tbl = "<table width='100%'align='left' cellpadding='5' cellspacing='0' border='0'>";
            //tbl = tbl + "<tr><td class='middle4' width='2px'>&nbsp;</td><td class='middle4' width='2px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='5px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td><td class='middle4' width='4px'>&nbsp;</td></tr>";
            //tbl = tbl + ("<tr><td class='middle31' width='15%'>ISSUE</td><td class='middle31' width='15%' align='right'>GrossAmt</td><td class='middle31' width='15%' colspan='2' align='right'>Agency TD Amt</br>%Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Value</td><td class='middle31' width='15%' colspan='2' align='right'>Agency Addl TD Amt</br>%Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Value</td><td class='middle31' width='15%' align='right'>NETAMT</td><td class='middle31' width='10%' align='right'>Retainer/Executive</br>Commission(%)</td><td class='middle31' width='10%' align='right'>Retainer/Executive</br>Commission(Amt)</td><td class='middle31' width='10%' align='right'>ActualBuss</td></tr>");


            tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>";
            tbl += "<td class='middle31new'  align='left'>" + "ISSUE" + "</td>";
            tbl += "<td class='middle31new' align='right'>" + "&nbsp;&nbsp;GrossAmt" + "</td>";
            tbl += "<td class='middle31new'  align='right'  colspan='2'>" + "&nbsp;&nbsp;Agency TD Amt" + "</br>" + "&nbsp;&nbsp;%Age" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Value" + "</td>";
            tbl += "<td class='middle31new'  align='right'  colspan='2'>" + "&nbsp;&nbsp;Agency Addl TD Amt" + "</br>" + "&nbsp;&nbsp;%Age" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "Value" + "</td>";
            tbl += "<td class='middle31new'   align='right'>" + "&nbsp;&nbsp;NETAMT" + "</td>";
            tbl += "<td class='middle31new'  align='right'>" + "&nbsp;&nbsp;Retainer/Executive</br>&nbsp;&nbsp;Commission(%)" + "</td>";
            tbl += "<td class='middle31new' width='10%' align='right'>&nbsp;&nbsp;Retainer/Executive</br>&nbsp;&nbsp;Commission(Amt)</td>";
            tbl += "<td class='middle31new'  align='right'>" + "&nbsp;&nbsp;ActaulBuss" + "</td>";
            tbl += "</tr>";

            int i1 = 1;
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                int cont = ds.Tables[1].Rows.Count;
                for (int i = 0; i <= cont - 1; i++)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data' align='left' >");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Edition"] + "</td>");

                    tbl = tbl + ("<td class='rep_data'  align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["GrossAmt"] + "</td>");
                    if (ds.Tables[1].Rows[i]["GrossAmt"].ToString() != "")
                        Grossamt = Grossamt + Convert.ToDouble(ds.Tables[1].Rows[i]["GrossAmt"]);

                    tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Trade_disc"] + "</td>");

                    tbl = tbl + ("<td class='rep_data'  align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Agency_DisVal"] + "</td>");
                    if (ds.Tables[1].Rows[i]["Agency_DisVal"].ToString() != "")
                        agencydisc = agencydisc + Convert.ToDouble(ds.Tables[1].Rows[i]["Agency_DisVal"]);

                    tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                    tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTD(%)"] + "</td>");

                    tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;");
                    tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"] + "</td>");
                    if (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                        agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[1].Rows[i]["AgencyAddlTDAmt"]);


                    tbl = tbl + ("<td class='rep_data'  align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["NETAMT"] + "</td>");
                    if (ds.Tables[1].Rows[i]["NETAMT"].ToString() != "")
                        Netamt = Netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["NETAMT"]);

                    tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["RetComm(%)"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["RetCommAmt"] + "</td>");

                    tbl = tbl + ("<td class='rep_data'  align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["ActualBuss"] + "</td>");
                    if (ds.Tables[1].Rows[i]["ActualBuss"].ToString() != "")
                        ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[1].Rows[i]["ActualBuss"]);
                    tbl = tbl + ("</tr >");
                    tblgrid.InnerHtml += tbl;
                    tbl = "";

                }
            }
            else
            {
                int cont = ds.Tables[1].Rows.Count;
                for (int i = 0; i <= cont - 1; i++)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data' width='15%'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Edition"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["GrossAmt"] + "</td>");
                    if (ds.Tables[1].Rows[i]["GrossAmt"].ToString() != "")
                        Grossamt = Grossamt + Convert.ToDouble(ds.Tables[1].Rows[i]["GrossAmt"]);

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Trade_disc"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["Agency_DisVal"] + "</td>");
                    if (ds.Tables[1].Rows[i]["Agency_DisVal"].ToString() != "")
                        agencydisc = agencydisc + Convert.ToDouble(ds.Tables[1].Rows[i]["Agency_DisVal"]);

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTD(%)"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"] + "</td>");
                    if (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                        agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[1].Rows[i]["AgencyAddlTDAmt"]);


                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["NETAMT"] + "</td>");
                    if (ds.Tables[1].Rows[i]["NETAMT"].ToString() != "")
                        Netamt = Netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["NETAMT"]);

                    tbl = tbl + ("<td class='rep_data' width='10%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["RetComm(%)"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='10%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["RetCommAmt"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='10%' align='right'>");
                    tbl = tbl + (ds.Tables[1].Rows[i]["ActualBuss"] + "</td>");
                    if (ds.Tables[1].Rows[i]["ActualBuss"].ToString() != "")
                        ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[1].Rows[i]["ActualBuss"]);
                    tbl = tbl + ("</tr >");
                    tblgrid.InnerHtml += tbl;
                    tbl = "";

                }
            }
      
        tbl = tbl + ("<tr ><td colspan='0'>&nbsp;</td></tr>");
        tbl = tbl + ("<tr><td class='middle1212' align='left'><b>Total:</b></td><td id='tdcio~1' class='middle1212' align='right'>" + Grossamt.ToString() + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencydisc + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencyadddisc + "</td><td class='middle1212' align='right' >" + Netamt.ToString() + "</td><td  class='middle1212' colspan='2'>&nbsp;</td><td class='middle1212' align='right'>" + ActualBuss.ToString() + "</td></tr>");
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;
       
    }

    private void onscreenpublication(string fromdt, string dateto, string pubcode, string editioncode, string dateformat, string adtypecode, string pubcentcode)  //, string supplement)
    {
        cmpnyname.Text = "THE NEW INDIAN EXPRESS";//ds.Tables[0].Rows[0]["companyname"].ToString();
        string tbl = "";
        //tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Booking Id" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Publish Date" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Publication Name" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "State Name" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Revenue Center" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Agency Name" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "Gross Amount" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "Agency Comm" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "GST AMOUNT" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "NETAMT" + "</td>"; tbl += "</tr>";


        if (destination == "4")
        {
            tbl = tbl + ("<table width='100%' cellspacing='0px' cellpadding = '0' border='1' align='center' >");
            tbl = tbl + ("<tr>");
                tbl = tbl + ("<td style='font-size:22px;' align='center'  colspan='20'>" + cmpnyname.Text + "</td>");
            tbl = tbl + ("</tr>");

                tbl = tbl + ("<tr>");
                tbl = tbl + ("<td style='font-size:15px;'  align='center'  colspan='10'>" + "From Date" + "&nbsp;&nbsp;&nbsp;&nbsp;" + fromdt + "</td>");
                tbl = tbl + ("<td style='font-size:15px;'  align='center'  colspan='10'>" + "To Date" + "&nbsp;&nbsp;&nbsp;&nbsp;" + dateto + "</td>");
                tbl = tbl + ("</tr>");

            tbl = tbl + ("<tr><td class='middle31new' align='center'  colspan='20'>" + "&nbsp;&nbsp;&nbsp;&nbsp;" + "</td></tr>");
            tbl = tbl + ("<tr>");
        }
        else
        {
            tbl = tbl + ("<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>");

        }

        //tbl += "<td class='middle31new' align='left'  colspan='2'>" + "ISSUE" + "</td>";
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Booking Id" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Publish Date" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Publication Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "State Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Revenue Center" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Agency Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "Gross Amount" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "Agency Comm" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "GST AMOUNT" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "NETAMT" + "</td>");
        tbl = tbl + ("</tr>");
       


        int i1 = 1;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            int cont = ds.Tables[1].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data' align='left' >");
                tbl = tbl + (ds.Tables[1].Rows[i]["Edition"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["GrossAmt"] + "</td>");
                if (ds.Tables[1].Rows[i]["GrossAmt"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[1].Rows[i]["GrossAmt"]);

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["Trade_disc"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["Agency_DisVal"] + "</td>");
                if (ds.Tables[1].Rows[i]["Agency_DisVal"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[1].Rows[i]["Agency_DisVal"]);

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTD(%)"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"] + "</td>");
                if (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                    agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[1].Rows[i]["AgencyAddlTDAmt"]);


                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["NETAMT"] + "</td>");
                if (ds.Tables[1].Rows[i]["NETAMT"].ToString() != "")
                    Netamt = Netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["NETAMT"]);

                tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["RetComm(%)"] + "</td>");

                tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["RetCommAmt"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["ActualBuss"] + "</td>");
                if (ds.Tables[1].Rows[i]["ActualBuss"].ToString() != "")
                    ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[1].Rows[i]["ActualBuss"]);
                tbl = tbl + ("</tr >");
                tblgrid.InnerHtml += tbl;
                tbl = "";

            }
        }
        else
        {
            int cont = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["publication_code"].ToString() != ds.Tables[0].Rows[i - 1]["publication_code"].ToString())
                    {

                        //tbl = tbl + ("<tr >");
                        //tbl = tbl + ("<td class='middle1212'  colspan='12'  align='left'>");
                        //tbl = tbl + ("" + "</td>");
                        //tbl = tbl + ("</tr >");

                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
                        tbl = tbl + ("Total" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i - 1]["publication_name"] + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (Grossamt + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (agencydisc + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (gstamount + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (string.Format("{0:0.00}", billamount) + "</td>");
                        tbl = tbl + ("</tr >");

                        //tbl = tbl + ("<tr >");
                        //tbl = tbl + ("<td class='middle1212'  colspan='12'  align='right'>");
                        //tbl = tbl + ("" + "</td>");
                        //tbl = tbl + ("</tr >");
                        Grossamt = 0.00;
                        agencydisc = 0.00;
                        gstamount = 0.00;
                        billamount = 0.00;
                    }
                }
                tbl = tbl + ("<tr >");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["cio_booking_id"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["insert_date"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["publication_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["state_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["rev_center"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["agency_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["gross_rate"] + "</td>");
                if (ds.Tables[0].Rows[i]["gross_rate"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["gross_rate"]);

                if (ds.Tables[0].Rows[i]["gross_rate"].ToString() != "")
                    grandGrossamt = grandGrossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["gross_rate"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["agncyamnt"] + "</td>");
                if (ds.Tables[0].Rows[i]["agncyamnt"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["agncyamnt"]);
                if (ds.Tables[0].Rows[i]["agncyamnt"].ToString() != "")
                    grandagencydisc = grandagencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["agncyamnt"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["gst_amt"] + "</td>");
                }
                else
                {
                    tbl = tbl + ("0.00" + "</td>");
                }
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                    gstamount = gstamount + Convert.ToDouble(ds.Tables[0].Rows[i]["gst_amt"]);
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                    grandgstamount = grandgstamount + Convert.ToDouble(ds.Tables[0].Rows[i]["gst_amt"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["bill_amt"] + "</td>");
                if (ds.Tables[0].Rows[i]["bill_amt"].ToString() != "")
                    billamount = billamount + Convert.ToDouble(ds.Tables[0].Rows[i]["bill_amt"]);
                if (ds.Tables[0].Rows[i]["bill_amt"].ToString() != "")
                    grandbillamount = grandbillamount + Convert.ToDouble(ds.Tables[0].Rows[i]["bill_amt"]);

                tbl = tbl + ("</tr >");
                //if (destination == "4")
                //{
                //    tblgrid.InnerHtml += tbl;
                //}
                //else
                //{
                //    tblgrid.InnerHtml += tbl;
                //}
                //tbl = "";

                if (i == cont - 1)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
                    tbl = tbl + ("Total" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i - 1]["publication_name"] + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (Grossamt + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (agencydisc + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (gstamount + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (billamount + "</td>");
                    tbl = tbl + ("</tr >");
                }
            }
        }

        tbl = tbl + ("<tr ><td colspan='0'>&nbsp;</td></tr>");
        //tbl = tbl + ("<tr><td class='middle1212' align='left'><b>Total:</b></td><td id='tdcio~1' class='middle1212' align='right'>" + Grossamt.ToString() + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencydisc + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencyadddisc + "</td><td class='middle1212' align='right' >" + Netamt.ToString() + "</td><td  class='middle1212' colspan='2'>&nbsp;</td><td class='middle1212' align='right'>" + ActualBuss.ToString() + "</td></tr>");
        //tbl = tbl + ("<tr><td class='middle1212' align='left' colspan='2'><b>Total:</b></td><td id='tdcio~1' class='middle1212' colspan='2' align='right'>" + Grossamt.ToString() + "</td> <td  class='middle1212' align='right' colspan='2'>" + agencydisc + "</td><td class='middle1212' align='right' colspan='2'>" + Netamt.ToString() + "</td></tr>");

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
        tbl = tbl + ("Grand Total"  + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + ( string.Format("{0:0.00}", grandGrossamt)+ "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + ( string.Format("{0:0.00}", grandagencydisc)+ "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + ( string.Format("{0:0.00}", grandgstamount) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + ( string.Format("{0:0.00}", grandbillamount) + "</td>");
        tbl = tbl + ("</tr >");

        tbl = tbl + ("</table>");
        //tblgrid.InnerHtml += tbl;

        if (destination == "4")
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            //tblgrid.InnerHtml = tbl.ToString();
            tblgrid.InnerHtml += tbl;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        else
        {
            tblgrid.InnerHtml += tbl;
        }

    }

    private void onscreenstate(string fromdt, string dateto, string pubcode, string editioncode, string dateformat, string adtypecode, string pubcentcode)  //, string supplement)
    {
        cmpnyname.Text = "THE NEW INDIAN EXPRESS";//ds.Tables[0].Rows[0]["companyname"].ToString();
        string tbl = "";
        //tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Booking Id" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Publish Date" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Publication Name" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "State Name" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Revenue Center" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Agency Name" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "Gross Amount" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "Agency Comm" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "GST AMOUNT" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "NETAMT" + "</td>"; tbl += "</tr>";


        if (destination == "4")
        {
            tbl = tbl + ("<table width='100%' cellspacing='0px' cellpadding = '0' border='1' align='center' >");
            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td style='font-size:22px;' align='center'  colspan='20'>" + cmpnyname.Text + "</td>");
            tbl = tbl + ("</tr>");

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td style='font-size:15px;'  align='center'  colspan='10'>" + "From Date" + "&nbsp;&nbsp;&nbsp;&nbsp;" + fromdt + "</td>");
            tbl = tbl + ("<td style='font-size:15px;'  align='center'  colspan='10'>" + "To Date" + "&nbsp;&nbsp;&nbsp;&nbsp;" + dateto + "</td>");
            tbl = tbl + ("</tr>");

            tbl = tbl + ("<tr><td class='middle31new' align='center'  colspan='20'>" + "&nbsp;&nbsp;&nbsp;&nbsp;" + "</td></tr>");
            tbl = tbl + ("<tr>");
        }
        else
        {
            tbl = tbl + ("<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>");

        }

        //tbl += "<td class='middle31new' align='left'  colspan='2'>" + "ISSUE" + "</td>";
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Booking Id" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Publish Date" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Publication Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "State Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Revenue Center" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Agency Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "Gross Amount" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "Agency Comm" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "GST AMOUNT" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "NETAMT" + "</td>");
        tbl = tbl + ("</tr>");



        int i1 = 1;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            int cont = ds.Tables[1].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data' align='left' >");
                tbl = tbl + (ds.Tables[1].Rows[i]["Edition"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["GrossAmt"] + "</td>");
                if (ds.Tables[1].Rows[i]["GrossAmt"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[1].Rows[i]["GrossAmt"]);

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["Trade_disc"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["Agency_DisVal"] + "</td>");
                if (ds.Tables[1].Rows[i]["Agency_DisVal"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[1].Rows[i]["Agency_DisVal"]);

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTD(%)"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"] + "</td>");
                if (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                    agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[1].Rows[i]["AgencyAddlTDAmt"]);


                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["NETAMT"] + "</td>");
                if (ds.Tables[1].Rows[i]["NETAMT"].ToString() != "")
                    Netamt = Netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["NETAMT"]);

                tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["RetComm(%)"] + "</td>");

                tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["RetCommAmt"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["ActualBuss"] + "</td>");
                if (ds.Tables[1].Rows[i]["ActualBuss"].ToString() != "")
                    ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[1].Rows[i]["ActualBuss"]);
                tbl = tbl + ("</tr >");
                tblgrid.InnerHtml += tbl;
                tbl = "";

            }
        }
        else
        {
            int cont = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["state_name"].ToString() != ds.Tables[0].Rows[i - 1]["state_name"].ToString())
                    {

                        //tbl = tbl + ("<tr >");
                        //tbl = tbl + ("<td class='middle1212'  colspan='12'  align='left'>");
                        //tbl = tbl + ("" + "</td>");
                        //tbl = tbl + ("</tr >");

                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
                        tbl = tbl + ("Total" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i - 1]["state_name"] + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (Grossamt + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (agencydisc + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (gstamount + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (string.Format("{0:0.00}", billamount) + "</td>");
                        tbl = tbl + ("</tr >");

                        //tbl = tbl + ("<tr >");
                        //tbl = tbl + ("<td class='middle1212'  colspan='12'  align='right'>");
                        //tbl = tbl + ("" + "</td>");
                        //tbl = tbl + ("</tr >");
                        Grossamt = 0.00;
                        agencydisc = 0.00;
                        gstamount = 0.00;
                        billamount = 0.00;
                    }
                }
                tbl = tbl + ("<tr >");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["cio_booking_id"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["insert_date"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["publication_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["state_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["rev_center"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["agency_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["gross_rate"] + "</td>");
                if (ds.Tables[0].Rows[i]["gross_rate"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["gross_rate"]);

                if (ds.Tables[0].Rows[i]["gross_rate"].ToString() != "")
                    grandGrossamt = grandGrossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["gross_rate"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["agncyamnt"] + "</td>");
                if (ds.Tables[0].Rows[i]["agncyamnt"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["agncyamnt"]);
                if (ds.Tables[0].Rows[i]["agncyamnt"].ToString() != "")
                    grandagencydisc = grandagencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["agncyamnt"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["gst_amt"] + "</td>");
                }
                else
                {
                    tbl = tbl + ("0.00" + "</td>");
                }
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                    gstamount = gstamount + Convert.ToDouble(ds.Tables[0].Rows[i]["gst_amt"]);
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                    grandgstamount = grandgstamount + Convert.ToDouble(ds.Tables[0].Rows[i]["gst_amt"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["bill_amt"] + "</td>");
                if (ds.Tables[0].Rows[i]["bill_amt"].ToString() != "")
                    billamount = billamount + Convert.ToDouble(ds.Tables[0].Rows[i]["bill_amt"]);
                if (ds.Tables[0].Rows[i]["bill_amt"].ToString() != "")
                    grandbillamount = grandbillamount + Convert.ToDouble(ds.Tables[0].Rows[i]["bill_amt"]);

                tbl = tbl + ("</tr >");
                //if (destination == "4")
                //{
                //    tblgrid.InnerHtml += tbl;
                //}
                //else
                //{
                //    tblgrid.InnerHtml += tbl;
                //}
                //tbl = "";

                if (i == cont - 1)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
                    tbl = tbl + ("Total" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i - 1]["state_name"] + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (Grossamt + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (agencydisc + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (gstamount + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (billamount + "</td>");
                    tbl = tbl + ("</tr >");
                }
            }
        }

        tbl = tbl + ("<tr ><td colspan='0'>&nbsp;</td></tr>");
        //tbl = tbl + ("<tr><td class='middle1212' align='left'><b>Total:</b></td><td id='tdcio~1' class='middle1212' align='right'>" + Grossamt.ToString() + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencydisc + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencyadddisc + "</td><td class='middle1212' align='right' >" + Netamt.ToString() + "</td><td  class='middle1212' colspan='2'>&nbsp;</td><td class='middle1212' align='right'>" + ActualBuss.ToString() + "</td></tr>");
        //tbl = tbl + ("<tr><td class='middle1212' align='left' colspan='2'><b>Total:</b></td><td id='tdcio~1' class='middle1212' colspan='2' align='right'>" + Grossamt.ToString() + "</td> <td  class='middle1212' align='right' colspan='2'>" + agencydisc + "</td><td class='middle1212' align='right' colspan='2'>" + Netamt.ToString() + "</td></tr>");

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
        tbl = tbl + ("Grand Total" + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandGrossamt) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandagencydisc) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandgstamount) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandbillamount) + "</td>");
        tbl = tbl + ("</tr >");

        tbl = tbl + ("</table>");
        //tblgrid.InnerHtml += tbl;

        if (destination == "4")
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            //tblgrid.InnerHtml = tbl.ToString();
            tblgrid.InnerHtml += tbl;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        else
        {
            tblgrid.InnerHtml += tbl;
        }

    }

    private void onscreenrevenue(string fromdt, string dateto, string pubcode, string editioncode, string dateformat, string adtypecode, string pubcentcode)  //, string supplement)
    {
        cmpnyname.Text = "THE NEW INDIAN EXPRESS";//ds.Tables[0].Rows[0]["companyname"].ToString();
        string tbl = "";
        //tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Booking Id" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Publish Date" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Publication Name" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "State Name" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Revenue Center" + "</td>"; tbl += "<td class='middle31new' align='left'  colspan='2'>" + "Agency Name" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "Gross Amount" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "Agency Comm" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "GST AMOUNT" + "</td>"; tbl += "<td class='middle31new' align='right' colspan='2'>" + "NETAMT" + "</td>"; tbl += "</tr>";


        if (destination == "4")
        {
            tbl = tbl + ("<table width='100%' cellspacing='0px' cellpadding = '0' border='1' align='center' >");
            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td style='font-size:22px;' align='center'  colspan='20'>" + cmpnyname.Text + "</td>");
            tbl = tbl + ("</tr>");

            tbl = tbl + ("<tr>");
            tbl = tbl + ("<td style='font-size:15px;'  align='center'  colspan='10'>" + "From Date" + "&nbsp;&nbsp;&nbsp;&nbsp;" + fromdt + "</td>");
            tbl = tbl + ("<td style='font-size:15px;'  align='center'  colspan='10'>" + "To Date" + "&nbsp;&nbsp;&nbsp;&nbsp;" + dateto + "</td>");
            tbl = tbl + ("</tr>");

            tbl = tbl + ("<tr><td class='middle31new' align='center'  colspan='20'>" + "&nbsp;&nbsp;&nbsp;&nbsp;" + "</td></tr>");
            tbl = tbl + ("<tr>");
        }
        else
        {
            tbl = tbl + ("<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' ><tr>");

        }

        //tbl += "<td class='middle31new' align='left'  colspan='2'>" + "ISSUE" + "</td>";
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Booking Id" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Publish Date" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Publication Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "State Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Revenue Center" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='left'  colspan='2'>" + "Agency Name" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "Gross Amount" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "Agency Comm" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "GST AMOUNT" + "</td>");
        tbl = tbl + ("<td class='middle31new' align='right' colspan='2'>" + "NETAMT" + "</td>");
        tbl = tbl + ("</tr>");



        int i1 = 1;
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            int cont = ds.Tables[1].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl = tbl + ("<tr >");
                tbl = tbl + ("<td class='rep_data' align='left' >");
                tbl = tbl + (ds.Tables[1].Rows[i]["Edition"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["GrossAmt"] + "</td>");
                if (ds.Tables[1].Rows[i]["GrossAmt"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[1].Rows[i]["GrossAmt"]);

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["Trade_disc"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["Agency_DisVal"] + "</td>");
                if (ds.Tables[1].Rows[i]["Agency_DisVal"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[1].Rows[i]["Agency_DisVal"]);

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTD(%)"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>&nbsp;&nbsp;&nbsp;&nbsp;");
                tbl = tbl + (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"] + "</td>");
                if (ds.Tables[1].Rows[i]["AgencyAddlTDAmt"].ToString() != "")
                    agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[1].Rows[i]["AgencyAddlTDAmt"]);


                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["NETAMT"] + "</td>");
                if (ds.Tables[1].Rows[i]["NETAMT"].ToString() != "")
                    Netamt = Netamt + Convert.ToDouble(ds.Tables[1].Rows[i]["NETAMT"]);

                tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["RetComm(%)"] + "</td>");

                tbl = tbl + ("<td class='rep_data' width='10%'   align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["RetCommAmt"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  align='right'>");
                tbl = tbl + (ds.Tables[1].Rows[i]["ActualBuss"] + "</td>");
                if (ds.Tables[1].Rows[i]["ActualBuss"].ToString() != "")
                    ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[1].Rows[i]["ActualBuss"]);
                tbl = tbl + ("</tr >");
                tblgrid.InnerHtml += tbl;
                tbl = "";

            }
        }
        else
        {
            int cont = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= cont - 1; i++)
            {
                if (i > 0)
                {
                    if (ds.Tables[0].Rows[i]["rev_center"].ToString() != ds.Tables[0].Rows[i - 1]["rev_center"].ToString())
                    {

                        //tbl = tbl + ("<tr >");
                        //tbl = tbl + ("<td class='middle1212'  colspan='12'  align='left'>");
                        //tbl = tbl + ("" + "</td>");
                        //tbl = tbl + ("</tr >");

                        tbl = tbl + ("<tr >");
                        tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
                        tbl = tbl + ("Total" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i - 1]["rev_center"] + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (Grossamt + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (agencydisc + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (gstamount + "</td>");
                        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                        tbl = tbl + (string.Format("{0:0.00}", billamount) + "</td>");
                        tbl = tbl + ("</tr >");

                        //tbl = tbl + ("<tr >");
                        //tbl = tbl + ("<td class='middle1212'  colspan='12'  align='right'>");
                        //tbl = tbl + ("" + "</td>");
                        //tbl = tbl + ("</tr >");
                        Grossamt = 0.00;
                        agencydisc = 0.00;
                        gstamount = 0.00;
                        billamount = 0.00;
                    }
                }
                tbl = tbl + ("<tr >");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["cio_booking_id"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["insert_date"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["publication_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["state_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["rev_center"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["agency_name"] + "</td>");

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["gross_rate"] + "</td>");
                if (ds.Tables[0].Rows[i]["gross_rate"].ToString() != "")
                    Grossamt = Grossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["gross_rate"]);

                if (ds.Tables[0].Rows[i]["gross_rate"].ToString() != "")
                    grandGrossamt = grandGrossamt + Convert.ToDouble(ds.Tables[0].Rows[i]["gross_rate"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["agncyamnt"] + "</td>");
                if (ds.Tables[0].Rows[i]["agncyamnt"].ToString() != "")
                    agencydisc = agencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["agncyamnt"]);
                if (ds.Tables[0].Rows[i]["agncyamnt"].ToString() != "")
                    grandagencydisc = grandagencydisc + Convert.ToDouble(ds.Tables[0].Rows[i]["agncyamnt"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                {
                    tbl = tbl + (ds.Tables[0].Rows[i]["gst_amt"] + "</td>");
                }
                else
                {
                    tbl = tbl + ("0.00" + "</td>");
                }
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                    gstamount = gstamount + Convert.ToDouble(ds.Tables[0].Rows[i]["gst_amt"]);
                if (ds.Tables[0].Rows[i]["gst_amt"].ToString() != "")
                    grandgstamount = grandgstamount + Convert.ToDouble(ds.Tables[0].Rows[i]["gst_amt"]);

                tbl = tbl + ("<td class='rep_data'  colspan='2'  align='right'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["bill_amt"] + "</td>");
                if (ds.Tables[0].Rows[i]["bill_amt"].ToString() != "")
                    billamount = billamount + Convert.ToDouble(ds.Tables[0].Rows[i]["bill_amt"]);
                if (ds.Tables[0].Rows[i]["bill_amt"].ToString() != "")
                    grandbillamount = grandbillamount + Convert.ToDouble(ds.Tables[0].Rows[i]["bill_amt"]);

                tbl = tbl + ("</tr >");
                //if (destination == "4")
                //{
                //    tblgrid.InnerHtml += tbl;
                //}
                //else
                //{
                //    tblgrid.InnerHtml += tbl;
                //}
                //tbl = "";

                if (i == cont - 1)
                {
                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
                    tbl = tbl + ("Total" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i - 1]["rev_center"] + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (Grossamt + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (agencydisc + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (gstamount + "</td>");
                    tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
                    tbl = tbl + (billamount + "</td>");
                    tbl = tbl + ("</tr >");
                }
            }
        }

        tbl = tbl + ("<tr ><td colspan='0'>&nbsp;</td></tr>");
        //tbl = tbl + ("<tr><td class='middle1212' align='left'><b>Total:</b></td><td id='tdcio~1' class='middle1212' align='right'>" + Grossamt.ToString() + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencydisc + "</td><td  class='middle1212'>&nbsp;</td><td  class='middle1212' align='right'>" + agencyadddisc + "</td><td class='middle1212' align='right' >" + Netamt.ToString() + "</td><td  class='middle1212' colspan='2'>&nbsp;</td><td class='middle1212' align='right'>" + ActualBuss.ToString() + "</td></tr>");
        //tbl = tbl + ("<tr><td class='middle1212' align='left' colspan='2'><b>Total:</b></td><td id='tdcio~1' class='middle1212' colspan='2' align='right'>" + Grossamt.ToString() + "</td> <td  class='middle1212' align='right' colspan='2'>" + agencydisc + "</td><td class='middle1212' align='right' colspan='2'>" + Netamt.ToString() + "</td></tr>");

        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='middle1212' colspan='12' align='center' >");
        tbl = tbl + ("Grand Total" + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandGrossamt) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandagencydisc) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandgstamount) + "</td>");
        tbl = tbl + ("<td class='middle1212' colspan='2' align='right'>");
        tbl = tbl + (string.Format("{0:0.00}", grandbillamount) + "</td>");
        tbl = tbl + ("</tr >");

        tbl = tbl + ("</table>");
        //tblgrid.InnerHtml += tbl;

        if (destination == "4")
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            //tblgrid.InnerHtml = tbl.ToString();
            tblgrid.InnerHtml += tbl;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        else
        {
            tblgrid.InnerHtml += tbl;
        }

    }


    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["prm_revsum_print"]="destination~" + destination + "~fromdate~" + fromdt + "~dateto~" + dateto + "~publication~" + pubcode + "~publicationname~" + publication + "~edition~" + editioncode + "~editionname~" + edition + "~adtypecode~" + adtypecode + "~adtypename~" + adtypename + "~pubcentcode~" + pubcentcode + "~pubcentname~" + pubcentname;
        Response.Redirect("PrintRevSummary.aspx");
//        Response.Redirect("PrintRevSummary.aspx?destination=" + destination + "&fromdate=" + fromdt + "&dateto=" + dateto + "&publication=" + pubcode + "&publicationname=" + publication + "&edition=" + editioncode + "&editionname=" + edition + "&adtypecode=" + adtypecode + "&adtypename=" + adtypename + "&pubcentcode=" + pubcentcode + "&pubcentname=" + pubcentname);

    }
}


