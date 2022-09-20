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

public partial class packagewiseprint : System.Web.UI.Page
{
    int maxlimit = 15;
    string destination = "";
    string fromdt = "";
    string dateto = "";
    string frmdt = "";
    string todate = "", datefrom1 = "", dateto1 = "";
    string paymodename = "", paymode = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string clientname = "";
    string agencyname = "";
    string clientname1 = "";
    string agencyname1 = "";
    double BillAmt = 0, area = 0;
    int sno = 1;
    string packagecode = "", packagename = "", adtypecode = "", adtypename = "";
    string pubcode = "", pubname = "", pubcentcode = "", pubcentname = "", editioncode = "", editionname = "";
    double Netamt = 0;
    double Grossamt = 0;
    double ActualBuss = 0, agencyadddisc = 0, agencydisc = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddendateformat.Value = Session["dateformat"].ToString();

        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("XML/disschreg.xml"));

        heading.Text = ds1.Tables[0].Rows[0].ItemArray[92].ToString();
        dateto = Session["dateto"].ToString();
        fromdt = Session["fromdate"].ToString();


        frmdt = Request.QueryString["fromdate"].ToString();
        todate = Request.QueryString["dateto"].ToString();
        destination = Request.QueryString["destination"].ToString();
        agencyname = Request.QueryString["agency"].ToString();
        clientname = Request.QueryString["client"].ToString();
        agencyname1 = Request.QueryString["agencyname"].ToString();
        clientname1 = Request.QueryString["clientname"].ToString();

        packagecode = Request.QueryString["packagecode"].ToString();
        packagename = Request.QueryString["packagename"].ToString();
        adtypecode = Request.QueryString["adtypecode"].ToString();
        adtypename = Request.QueryString["adtypename"].ToString();
        pubcode = Request.QueryString["pubcode"].ToString();
        pubname = Request.QueryString["pubname"].ToString();
        pubcentcode = Request.QueryString["pubcentcode"].ToString();
        pubcentname = Request.QueryString["pubcentname"].ToString();
        editioncode = Request.QueryString["editioncode"].ToString();
        editionname = Request.QueryString["editionname"].ToString();
        hiddendatefrom.Value = fromdt.ToString();

        if (editioncode == "0")
        {
            lbledition.Text = "ALL".ToString();
        }
        else
        {
            lbledition.Text = editionname.ToString();
        }


        if (pubcentcode == "0")
        {
            lblpubcent.Text = "ALL".ToString();
        }
        else
        {
            lblpubcent.Text = pubcentname.ToString();
        }


        if (pubcode == "0")
        {
            lblpublication.Text = "ALL".ToString();
        }
        else
        {
            lblpublication.Text = pubname.ToString();
        }


        if (packagecode == "0")
        {
            lbpackage.Text = "ALL".ToString();
        }
        else
        {
            lbpackage.Text = packagename.ToString();
        }

        if (clientname == "0")
        {
            lbclient.Text = "ALL".ToString();
        }
        else
        {
            lbclient.Text = clientname1.ToString();
        }

        if (agencyname == "0")
        {
            lbagency.Text = "ALL".ToString();
        }
        else
        {
            lbagency.Text = agencyname1.ToString();
        }
        if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
        {
            DateTime dt = System.DateTime.Now;
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = day + "/" + month + "/" + year;
        }
        else if (hiddendateformat.Value == "mm/dd/yyyy".ToString())
        {
            DateTime dt = System.DateTime.Now;
            day = dt.Day.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            date = month + "/" + day + "/" + year;
        }
        else if (hiddendateformat.Value == "yyyy/mm/dd".ToString())
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

            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{

            //    string[] arr = fromdt.Split('/');
            //    string dd = arr[0];
            //    string mm = arr[1];
            //    string yy = arr[2];
            //    datefrom1 = mm + "/" + dd + "/" + yy;

            //}
            //else
            //{
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
            // }
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




        onscreen(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);

    }
    private void onscreen(string frmdt, string todate, string compcode, string clientname, string agencyname, string dateformate, string packagecode, string adtypecode, string pubcode, string pubcentcode, string editioncode)
    {


        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.bill obj = new NewAdbooking.Classes.bill();
            //ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString());
        }
        else
        {
            NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            ds = obj.packagewise(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, Session["dateformat"].ToString(), packagecode, adtypecode, pubcode, pubcentcode, editioncode);

        }
        cmpnyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
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
        int cont = ds.Tables[0].Rows.Count;

        if (ds.Tables[0].Rows.Count > 0)
        {
            tbl = "<table  cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top'>";

            for (int p = 0; p < pagecount; p++)
            {
                int s = p + 1;
                tbl += "</table>";
                tbl += "<table width='100%' cellspacing='0px' cellpadding = '0' border='0' align='center' class='break'>";
                tbl += "<tr>";
                tbl += "<td class='middle111' align='right' colspan='10'>" + "Page  " + s + "  of  " + pagecount;
                tbl += "</td></tr>";

               // tbl += "<tr><td class='middle31new'>S.No.</td><td class='middle31new' align='left'>BookingId</td><td class='middle31new' align='left'>MR.No.</td><td class='middle31new' align='left'>Agency</td><td class='middle31new' align='left'>Client</td><td  class='middle31new' align='right'>CardRate</td><td  class='middle31new' align='right'>AgreedRate</td><td class='middle31new' align='right'>BillableArea</td><td  class='middle31new' align='right'>TradeDisc.(%)</td><td class='middle31new' align='right'>BillAmt</td></tr>";
                tbl = tbl + ("<tr><td class='middle31new'>S.No.</td><td class='middle31new' width='15%'>Package</td><td class='middle31new' width='15%' align='right'>GrossAmt</td><td class='middle31new' width='15%' align='right'>Agency</br>TD(%)</td><td class='middle31new' width='15%' align='right'>Agency</br>TD(Amt)</td><td class='middle31new' width='15%'  align='right'>Agency Addl</br>TD(%)</td><td class='middle31new' width='15%'  align='right'>Agency Addl</br>TD(Amt)</td><td class='middle31new' width='15%' align='right'>NETAMT</td><td class='middle31new' width='15%' align='right'>Retainer</br>Commission(%)</td><td class='middle31new' width='15%' align='right'>Retainer</br>Commission(Amt)</td><td class='middle31new' width='10%' align='right'>ActualBuss</td></tr>");
           
       

                tbl += "</tr>";
                for (int d = ct; d < ds.Tables[0].Rows.Count && d < fr; d++)
                {
                    int a = d;
                    a = a + 1;

                    tbl = tbl + ("<tr >");
                    tbl = tbl + ("<td class='rep_data'>");
                    tbl = tbl + (i1++.ToString() + "</td>");




                    tbl = tbl + ("<td class='rep_data' width='15%' >");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Package"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["GrossAmt"] + "</td>");
                    if (ds.Tables[0].Rows[d]["GrossAmt"].ToString() != "")
                        Grossamt = Grossamt + Convert.ToDouble(ds.Tables[0].Rows[d]["GrossAmt"]);

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Trade_disc"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["Agency_DisVal"] + "</td>");
                    if (ds.Tables[0].Rows[d]["Agency_DisVal"].ToString() != "")
                        agencydisc = agencydisc + Convert.ToDouble(ds.Tables[0].Rows[d]["Agency_DisVal"]);

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTD(%)"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["AgencyAddlTDAmt"] + "</td>");
                    if (ds.Tables[0].Rows[d]["AgencyAddlTDAmt"].ToString() != "")
                        agencyadddisc = agencyadddisc + Convert.ToDouble(ds.Tables[0].Rows[d]["AgencyAddlTDAmt"]);


                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["NETAMT"] + "</td>");
                    if (ds.Tables[0].Rows[d]["NETAMT"].ToString() != "")
                        Netamt = Netamt + Convert.ToDouble(ds.Tables[0].Rows[d]["NETAMT"]);

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["RetComm(%)"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='15%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["RetCommAmt"] + "</td>");

                    tbl = tbl + ("<td class='rep_data' width='10%' align='right'>");
                    tbl = tbl + (ds.Tables[0].Rows[d]["ActualBuss"] + "</td>");
                    if (ds.Tables[0].Rows[d]["ActualBuss"].ToString() != "")
                        ActualBuss = ActualBuss + Convert.ToDouble(ds.Tables[0].Rows[d]["ActualBuss"]);

                    tbl = tbl + "</tr>";
                }
                ct = ct + maxlimit;
                fr = fr + maxlimit;


            }
            tbl = tbl + ("<tr ><td colspan='0'>&nbsp;</td></tr>");
            tbl = tbl + ("<tr><td class='middle1212' align='left' colspan='2'><b>Total:</b></td><td id='tdcio~1' width='15%'  class='middle1212' align='right'>" + Grossamt.ToString() + "</td><td width='15%'   class='middle1212'>&nbsp;</td><td width='15%'   class='middle1212' align='right'>" + agencydisc + "</td><td  width='15%'  class='middle1212'>&nbsp;</td><td  width='15%'  class='middle1212' align='right'>" + agencyadddisc + "</td><td class='middle1212' align='right' width='15%' >" + Netamt.ToString() + "</td><td  class='middle1212' width='15%' >&nbsp;</td><td width='15%'  class='middle1212' align='right'>&nbsp;</td><td class='middle1212' align='right' width='10%' >" + ActualBuss.ToString() + "</td></tr>");
            tbl = tbl + ("<table>");
            // tblgrid.InnerHtml = tbl;
            div1.InnerHtml = tbl;

        }
    }
}
