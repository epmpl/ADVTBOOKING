using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Reports_rptunregisteredclientprint : System.Web.UI.Page
{
    string compcode = "";
    string branch = "";
    string fromdate = "";
    string todate = "";
    string branch_name = "";
    string view = "";
    string rundate = "";
    string rdate = "";
    string dateformat = "";
    string rdatefinalhdsmain = "";
    string reportname = "";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 40;
    int pgn = 0;
    string companyname = "";
    string SNo = "";
    string BookingId = "";
    string ClientName = "";
    string ClientAddress = "";
    string AgencyName = "";
    string AdType = "";
    string Adcategory = "";
    string Package = "";
    string Area = "";
    string CardRate = "";
    string GrossAmount = "";
    string BillAmount = "";
    string Rate_code = "";
    string uom = "";
    string padtype = "";
    string padtype_name = "";
    string puomcode = "";
    string puomcode_name = "";
    string pdate_flag = "";
    string pdateflag_name = "";
    string pextra1 = "";
    string pextra2 = "";
    string pextra3 = "";
    string pextra4 = "";
    string pextra5 = "";
    string registype;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script> window.parent.location=\" login.aspx\";</script>)");
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();
        fromdate = Request.QueryString["fromdate"].ToString();
        todate = Request.QueryString["todate"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();
        branch = Request.QueryString["branch"].ToString();
       view = Request.QueryString["view"].ToString();
       padtype = Request.QueryString["padtype"].ToString();
       padtype_name = Request.QueryString["padtype_name"].ToString();
       puomcode = Request.QueryString["puomcode"].ToString();
       puomcode_name = Request.QueryString["puomcode_name"].ToString();
       pdate_flag = Request.QueryString["pdate_flag"].ToString();
       pdateflag_name = Request.QueryString["pdateflag_name"].ToString();
       registype = Request.QueryString["registertype"].ToString();
        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        rdate = tim[0];
        string[] rdatehdsmaintds = rdate.Split(' ');
        string hdsmainhjrdate = rdatehdsmaintds[0];
        string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
        string hdsmainhjrdate1 = hdsmainhjrdateS[0];
        string hdsmainhjrdate2 = hdsmainhjrdateS[1];
        string hdsmainhjrdate3 = hdsmainhjrdateS[2];
        rdatefinalhdsmain = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;
        SNo = "S.No";
        BookingId = "Booking Id";
        ClientName = "Client Name";
        ClientAddress = "Client Address";
        AgencyName = "Agency Name";
        Adcategory = "Ad category";
        Package = "Package";
        Area = "Area";
        CardRate = "Card Rate";
        GrossAmount = "Gross Amount";
        BillAmount = "Bill Amount";
        AdType = "Ad Type";
        Rate_code = "Rate_code";
        uom = "UOM";
        //hiddencompname.Value = Session["companyname"].ToString();
        //companyname = hiddencompname.Value;
        reportname = "Unregistered Client Report";
        if (!Page.IsPostBack)
        {
            if (view == "ons")
            {
                gridbind();
            }
            //else
            //{
            //    gridbind_excel();
            //}

        }
      

    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.clint(compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, registype, pextra3, pextra4, pextra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = unregistclient.clint(compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, pextra2, pextra3, pextra4, pextra5);

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "rpt_unregistered_client";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, branch, fromdate, todate, dateformat, padtype, puomcode, pdate_flag, pextra1, pextra2, pextra3, pextra4, pextra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
            int pgn = 1;
        page_count = ds.Tables[0].Rows.Count / maxlimit;
        int rem = ds.Tables[0].Rows.Count % maxlimit;
        if (rem > 0)
        {
            page_count = page_count + 2;
        }
        else
        {
            page_count = page_count + 1;
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (pgn > page_count)
            {
                page_count = page_count + (pgn - page_count);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int sno1 = 0;
                string tbl = "";

                tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                tbl += "<tr width='100%' ><td colspan='4' style='verticle-align:top;' align='right' class = 'middle33'>Page No." + pgn + "</td></tr>";
                tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>";
                tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>";
                tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>From Date:" + fromdate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
                tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + todate + "</td></tr>";

                tbl += "</table>";
                tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new'>" + BookingId + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ClientAddress + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + Package + "</td><td  class='middle31new'>" + AdType + "</td><td  class='middle31new'>" + Adcategory + "</td><td  class='middle31new'>" + Area + "</td><td  class='middle31new'>" + uom + "</td><td  class='middle31new'>" + Rate_code + "</td><td class='middle31new'>" + CardRate + "</td><td  class='middle31new'>" + GrossAmount + "</td><td  class='middle31new'>" + BillAmount + "</td></tr>";

                for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
                {

                    if (rowcounter == maxlimit)
                    {
                        pgn = pgn + 1;
                        rowcounter = 0;
                        tbl += "</table><p>";
                        tbl += "</br>";
                        tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                        tbl += "</table><p>";
                        tbl += "<tr width='100%' ><td  style='verticle-align:top;' align='right' class = 'middle33'>Page No." + pgn + "</td></tr>";

                        tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                        tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new'>" + BookingId + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ClientAddress + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + Package + "</td><td  class='middle31new'>" + AdType + "</td><td  class='middle31new'>" + Adcategory + "</td><td  class='middle31new'>" + Area + "</td><td  class='middle31new'>" + uom + "</td><td  class='middle31new'>" + Rate_code + "</td><td class='middle31new'>" + CardRate + "</td><td  class='middle31new'>" + GrossAmount + "</td><td  class='middle31new'>" + BillAmount + "</td></tr>";
                        tbl += "</table></p>";
                        tbl += "<p><table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                    }

                    sno1++;
                    tbl += "<tr font-size='10' font-family='Arial'>";
                    tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                    tbl += "<td class='rep_data' width='8%'style=padding-left:'1px'>";
                    tbl += ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["ClIENTNAME"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["CLIENT_ADDRESS"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Agency_Name"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Package_Name"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Adv_Type_Name"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Adv_Cat_Name"].ToString() + "</td>";

                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Total_area"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Uom_Name"].ToString() + "</td>";

                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Rate_code"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Card_rate"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Bill_amount"].ToString() + "</td>";
                    tbl += "<td class='rep_data' width='8%'>";
                    tbl += ds.Tables[0].Rows[p]["Gross_amount"].ToString() + "</td>";


                    rowcounter++;
                    
                }
                
                tbl += "</table></p>";

                report.InnerHtml = tbl;

            }
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }
    }

