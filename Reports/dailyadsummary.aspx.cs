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


public partial class Reports_dailyadsummary : System.Web.UI.Page
{
    string fromdate = "";
    string dateto = "";
    string docket = "";
    string searching = "";
    string companyname = "";
    string pubname = "";
    string pubcent = "";
    string edition = "";
    string state = "";
    string dist = "";
    string city = "";
    string printcenter = "";
    string branch = "";
    string agencytype = "";
    string userid = "";
    string reporttype = "";
    string adtype =  "";
    string uom =  "";
    string listadcat = "";
    string listadsubcat = "";
    string compcode = "";
    string useridmain = "";
    string dateformat = "";
    string rdatefinalhdsmain = "";
    string reportname = "";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 30;
    int pgn = 0;
    string rundate = "";
    string rdate = "";
   string   AgencyName = "";
    string city1 = "";
     string  BookingId = "";
     string   ClientName = "";
     string  bookindate= "";
      string edition1 = "";
      string   RO_No = "";
       string  pub_dt = "";
       string ins = "";
       string agname = "";
       string clientname = "";
       string status = "";
       string hold = "";
       string descid = "";
       string ascdesc = "";
       string chk_access = "";
       string SNo = "";
       double BillAmt = 0;
       string pageno = "";

       string date = "";
       string day = "";
       string month = "";
       string year = "";
       double area = 0;
       double totrol = 0;
       double totcd = 0;
       double totcc = 0;
       int i1 = 1;
       double amt = 0;
       string bookingtype = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        useridmain = hiddenuserid.Value;
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();
      chk_access =  Session["access"].ToString();

        fromdate = Request.QueryString["fromdate"].ToString();
        dateto = Request.QueryString["dateto"].ToString();
        docket = Request.QueryString["docket"].ToString();
        searching = Request.QueryString["searching"].ToString();

        pubname = Request.QueryString["pubname"].ToString();
        pubcent = Request.QueryString["pubcent"].ToString();
        edition = Request.QueryString["edition"].ToString();
        state = Request.QueryString["state"].ToString();
        dist = Request.QueryString["dist"].ToString();
        city = Request.QueryString["city"].ToString();
        printcenter = Request.QueryString["printcenter"].ToString();
        branch = Request.QueryString["branch"].ToString();
        agencytype = Request.QueryString["agencytype"].ToString();
        userid = Request.QueryString["userid"].ToString();
        reporttype = Request.QueryString["reporttype"].ToString();
        adtype = Request.QueryString["adtype"].ToString();
        uom = Request.QueryString["uom"].ToString();
        listadcat = Request.QueryString["listadcat"].ToString();
        listadsubcat = Request.QueryString["subcatcode"].ToString();
        pageno = Request.QueryString["pageno"].ToString();
        bookingtype = Request.QueryString["bookingtype"].ToString();
        rundate = DateTime.Now.ToString();
        if (edition == "--Select Edition Name--")
            edition= "";

        string[] tim = rundate.Split(' ');
        rdate = tim[0];
        string[] rdatehdsmaintds = rdate.Split(' ');
        string hdsmainhjrdate = rdatehdsmaintds[0];
        string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
        string hdsmainhjrdate1 = hdsmainhjrdateS[0];
        string hdsmainhjrdate2 = hdsmainhjrdateS[1];
        string hdsmainhjrdate3 = hdsmainhjrdateS[2];
        rdatefinalhdsmain = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;
        reportname = "Daily Ads Of Day";
        SNo = "SNo";
        AgencyName = "Agency Name";
        city1 = "City";
        BookingId = "ID";
         ClientName = "Client Name";
        bookindate= "Booking Date";
        edition1 = "Edition";
        RO_No = "RO No";
        pub_dt = "Ro Date";
        ins = "Ins No.";
        if (!Page.IsPostBack)
        {
            if (reporttype=="4")
            {
                gridbindexcel();
            }
            else if (reporttype == "5")
            {
                gridbindexcelsummary();
            }
            else if (reporttype == "6")
            {
                gridbindexcelsummarybooking();
            }
            else if (reporttype == "7")
            {
                gridbindexcelsummarybookingcls();
            }
            else
            {
                gridbind();
            }
           
        }
        btnPrint.Attributes.Add("onclick", "javascript:return printreport();");


    }
    
    public void gridbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{
            //    from_date = DMYToMDY(txtfrmdate.Text);
            //    to_date = DMYToMDY(txttodate1.Text);
            //}


            //else if (hiddendateformat.Value == "yyyy/mm/dd")
            //{
            //    from_date = YMDToMDY(txtfrmdate.Text);
            //    to_date = YMDToMDY(txttodate1.Text);
            //}
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);

        }
        else
        {
            string[] parameterValueArray = new string[] { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city, pageno };
            string procedureName = "daily_booking_report";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            StringBuilder tbl = new StringBuilder();
             companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
              tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
              tbl.Append("<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>");
              tbl.Append("<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>");
              tbl.Append("<tr class='middle33'><td colspan='2' style='text-align:left'>From Date:" + fromdate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>");
              tbl.Append("<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + dateto + "</td></tr>");

              tbl.Append("</table>");
              tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
              tbl.Append("<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new' align='center'>" + BookingId + "</td><td  class='middle31new'>Booking Date</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + city1 + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ins + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + pub_dt + "</td><td  class='middle31new' align='left'>Username</td><td   class='middle31new' align='center' >Bill Amt</td><td   class='middle31new' align='center' >Remark</td></tr>");

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                      tbl.Append( "</table><p>");
                      tbl.Append( "</br>");
                      tbl.Append( "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                      tbl.Append( "</table><p>");

                      tbl.Append( "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                      tbl.Append("<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new' align='center'>" + BookingId + "</td><td  class='middle31new'>Booking Date</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + city1 + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ins + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + pub_dt + "</td><td  class='middle31new' align='left'>Username</td><td   class='middle31new' align='center' >Bill Amt</td><td   class='middle31new' align='center' >Remark</td></tr>");

                }

                sno1++;
                  tbl.Append( "<tr font-size='10' font-family='Arial'>");
                  tbl.Append( "<td class='rep_data' width='3%'>" + sno1 + "</td>");

                  tbl.Append( "<td class='rep_data' width='8%'style=padding-left:'1px'>");
                  tbl.Append( ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='7%'style=padding-left:'1px' align='left'>");
                string datewise = ds.Tables[0].Rows[p]["BKDATE"].ToString();
                    
                string[] datewise1 = datewise.Split(' ');
                string[] datewise2 = datewise1[0].Split('/');
                string mo = datewise2[0];
                string da = datewise2[1];
                string ye = datewise2[2];
                if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                {
                    datewise = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                {

                    datewise = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                {

                    datewise = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                }
                  tbl.Append( datewise + "</td>");


                  tbl.Append( "<td class='rep_data' width='20%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='8%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["AG_CITY"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='15%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>");


                  tbl.Append( "<td class='rep_data' width='8%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["no_of_insdertion"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='5%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='5%'>");

                string rodate = ds.Tables[0].Rows[p]["RO_DATE"].ToString();
                if (rodate != "")
                {
                    string[] rodate1 = rodate.Split(' ');
                    string[] rodate2 = rodate1[0].Split('/');
                    mo = rodate2[0];
                    da = rodate2[1];
                    ye = rodate2[2];
                }
                if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                {
                    rodate = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                {

                    rodate = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                {

                    rodate = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                }
                  tbl.Append( rodate + "</td>");

                  tbl.Append("<td class='rep_data' width='8%'>");
                  tbl.Append(ds.Tables[0].Rows[p]["booked_by"].ToString() + "</td>");

                  tbl.Append("<td class='rep_data' width='20%'>");
                  tbl.Append(ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>");


                  tbl.Append("<td class='rep_data' width='27%'>");
                  tbl.Append(ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td>");

                  if (ds.Tables[0].Rows[p]["Amt"].ToString() != "")
                      BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());

                  //tbl.Append( ds.Tables[0].Rows[p]["RO_DATE"].ToString() + "</td>");
                  //tbl.Append = tbl.Append + ("<tr><td colspan='3' class='rep_data'></td>" + BillAmt);

                  rowcounter++;
            }



            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
            tbl.Append("<tr font-size='10' font-family='Arial'>");
            tbl.Append("</br><b><td width='100%' border='1' class='middle31new' cellpadding='0px' cellspacing='0px' align='left'>");
            tbl.Append(("Total") + "</td>");
            tbl.Append("</br><b><td width='100%' border='1' class='middle31new' cellpadding='0px' cellspacing='0px' align='right'>");
            tbl.Append((BillAmt.ToString()) + "</td>");
            tbl.Append("</tr></table></p>");

            report.InnerHtml = tbl.ToString();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }
    
    public void gridbindexcel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{
            //    from_date = DMYToMDY(txtfrmdate.Text);
            //    to_date = DMYToMDY(txttodate1.Text);
            //}


            //else if (hiddendateformat.Value == "yyyy/mm/dd")
            //{
            //    from_date = YMDToMDY(txtfrmdate.Text);
            //    to_date = YMDToMDY(txttodate1.Text);
            //}
            //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue);

        }
        else
        {
            if (printcenter == "0") { printcenter = ""; }
            if (pubname == "0") { pubname = ""; }
            if (pubcent == "0") { pubcent = ""; }
            if (agencytype == "0") { agencytype = ""; }

            string procedureName = "daily_booking_report";
            string[] parameterValueArray = { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city ,""};
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            int sno1 = 0;
            StringBuilder tbl = new StringBuilder();
             companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
              tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
              tbl.Append("<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>");
              tbl.Append("<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>");
              tbl.Append("<tr class='middle33'><td colspan='2' style='text-align:left'>From Date:" + fromdate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>");
              tbl.Append("<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + dateto + "</td></tr>");

              tbl.Append("</table>");
              tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
              tbl.Append("<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new' align='center'>" + BookingId + "</td><td  class='middle31new'>Booking Date</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + city1 + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ins + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + pub_dt + "</td><td  class='middle31new'>Username</td><td   class='middle31new' align='center' >Bill Amt</td><td   class='middle31new' align='right' >Remark</td></tr>");

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                
                sno1++;
                  tbl.Append( "<tr font-size='10' font-family='Arial'>");
                  tbl.Append( "<td class='rep_data' width='3%'>" + sno1 + "</td>");

                  tbl.Append( "<td class='rep_data' width='12%'style=padding-left:'1px'>");
                  tbl.Append( ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='10%'style=padding-left:'1px' align='left'>");
                string datewise = ds.Tables[0].Rows[p]["BKDATE"].ToString();
                    
                string[] datewise1 = datewise.Split(' ');
                string[] datewise2 = datewise1[0].Split('/');
                string mo = datewise2[0];
                string da = datewise2[1];
                string ye = datewise2[2];
                if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                {
                    datewise = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                {

                    datewise = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                {

                    datewise = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                }
                  tbl.Append( datewise + "</td>");


                  tbl.Append( "<td class='rep_data' width='20%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='8%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["AG_CITY"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='20%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>");


                  tbl.Append( "<td class='rep_data' width='8%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["no_of_insdertion"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='8%'>");
                  tbl.Append( ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='8%'>");

                string rodate = ds.Tables[0].Rows[p]["RO_DATE"].ToString();
                if (rodate != "")
                {
                    string[] rodate1 = rodate.Split(' ');
                    string[] rodate2 = rodate1[0].Split('/');
                    mo = rodate2[0];
                    da = rodate2[1];
                    ye = rodate2[2];
                }
                if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                {
                    rodate = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                {

                    rodate = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                }
                else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                {

                    rodate = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                }
                  tbl.Append( rodate + "</td>");

                  tbl.Append("<td class='rep_data' width='8%'>");
                  tbl.Append(ds.Tables[0].Rows[p]["booked_by"].ToString() + "</td>");

                  tbl.Append("<td class='rep_data' width='20%'>");
                  tbl.Append(ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>");


                  tbl.Append("<td class='rep_data' width='20%'>");
                  tbl.Append(ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td>");


                  if (ds.Tables[0].Rows[p]["Amt"].ToString() != "")
                      BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());

                  //tbl.Append( ds.Tables[0].Rows[p]["RO_DATE"].ToString() + "</td>");
                  //tbl.Append = tbl.Append + ("<tr><td colspan='3' class='rep_data'></td>" + BillAmt);

                  rowcounter++;
            }



            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
            tbl.Append("<tr font-size='10' font-family='Arial'>");
            tbl.Append("</br><b><td width='100%' border='1' class='middle31new' cellpadding='0px' cellspacing='0px' align='left'>");
            tbl.Append(("Total") + "</td>");
            tbl.Append("</br><b><td width='100%' border='1' class='middle31new' cellpadding='0px' cellspacing='0px' align='right'>");
            tbl.Append((BillAmt.ToString()) + "</td>");
            tbl.Append("</tr></table></p>");

            report.InnerHtml = tbl.ToString();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteBreak();
            report.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }

    private void gridbindexcelsummarybooking()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{
            //    from_date = DMYToMDY(txtfrmdate.Text);
            //    to_date = DMYToMDY(txttodate1.Text);
            //}


            //else if (hiddendateformat.Value == "yyyy/mm/dd")
            //{
            //    from_date = YMDToMDY(txtfrmdate.Text);
            //    to_date = YMDToMDY(txttodate1.Text);
            //}
            //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue);

        }
        else
        {
            //string procedureName = "reportnew1_sum";
            string[] parameterValueArray = { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, "", uom, userid, state, dist, city, "", "6", "", "", "" };
            // NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            NewAdbooking.classmysql.reportstatusall cls_comb = new NewAdbooking.classmysql.reportstatusall();
            ds = cls_comb.alladssummaryrptexl(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, "", uom, userid, state, dist, city, "", "6", "", "", "");


        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            string cmpnyname = ds.Tables[0].Rows[0]["companyname"].ToString();

            int cont = ds.Tables[0].Rows.Count;
            // string tbl = "";
            StringBuilder tbl = new StringBuilder();
            tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='1'>");

            tbl.Append("<tr><td   width='10%' ><b></b></td><td  class='middle31new' width='10%' ><b>From Date</b></td><td class='middle31new'  width='10%' align='left'><b>" + fromdate + "</b></td> <td class='middle31new'  width='10%' align='left'><b>To Date</b></td> <td class='middle31new'  width='10%' align='left'><b>" + dateto + "</b></td></tr>");

            tbl.Append("<tr><td  width='10%' ><b></b></td></tr>");
            tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>No&nbsp;&nbsp;</b></td> <td class='middle31new' width='1%' align='left'><b>Order &nbsp;&nbsp;</br>Type&nbsp;&nbsp;</b></td> <td class='middle31new' width='1%' align='left'><b>Chart&nbsp;&nbsp;</br>Type&nbsp;&nbsp;</b></td> <td class='middle31new' width='4%' align='left'><b>Material&nbsp;&nbsp;</br>Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='3%' align='left'><b>Sub AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;PUB TYPE&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td><td class='middle31new' width='8%' align='center'><b>Variant</b></td><td class='middle31new' width='8%' align='center'><b>Mailing Center</b></td><td class='middle31new' width='8%' align='center'><b>Publication</b></td><td class='middle31new' width='8%' align='center'><b>Publish Date</b></td></b></tr>");
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl.Append("<tr>");
                tbl.Append("<td class='rep_data'>" + i1++.ToString() + "</td>");
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

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + cioid1 + "</td>");
                if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                {
                    DateTime dt = System.DateTime.Now;
                    day = dt.Day.ToString();
                    month = dt.Month.ToString();
                    year = dt.Year.ToString();

                    date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;
                }
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

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + agency1 + "</td>");

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

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + client1 + "</td>");
                //tbl = tbl + (client1 + "</td>");

                string Package1 = "";
                string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
                Package1 = rrr3;

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + Package1 + "</td>");

                if ((ds.Tables[0].Rows[i]["Width"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Width"]).ToString("F2") + "</td>");
                }

                if ((ds.Tables[0].Rows[i]["Depth"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Depth"]).ToString("F2") + "</td>");
                }

                if ((ds.Tables[0].Rows[i]["Area"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2") + "</td>");
                    if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                        area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                        totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                        totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                        totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                }

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["Color_code"] + "</td>");
                if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                }

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["resource_no"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["sectioncode"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["MATERIAL_STATUS"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Page"] + "</td>");

                if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >" + ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                }

                if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                }

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["RoNo."] + "</td>");

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

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + RoStatus1 + "</td>");

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

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + AdCat1 + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["AdsubCat"].ToString() + "</td>");

                if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                }

                if ((ds.Tables[0].Rows[i]["AgreedRate"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                }
                ///////cash disc

                if ((ds.Tables[0].Rows[i]["Cash_Disc"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Cash_Disc"]).ToString("F2") + "</td>");
                }

                ////////cash disc

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["AGREED_AMOUNT"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["SPL_AMOUNT"] + "</td>");

                if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'></td>");
                }
                else
                {
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                }

                if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                    amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Cap"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Key"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["EXEC_NAME"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_STATUS"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_CENTER"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["REVENUE_CENTER"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["PRINT_REMARK"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["brand_name"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["mailing_center"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["publication"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["insert_date"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + "</td>");
                tbl.Append("</tr>");
                tblgrid.InnerHtml = tbl.ToString();
            }


            tbl.Append("<tr >");
            tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
            tbl.Append("<td class='middle13new' colspan='3'>&nbsp;</td>");
            ////////////////////////////////////////
            double cal = System.Math.Round(Convert.ToDouble(area), 2);
            tbl.Append("<td class='middle1212' colspan='4' align='right'><b>Total Area: " + cal.ToString() + "</b>");
            if (totrol > 0)
            {
                double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>" + calf.ToString() + "</td>");
            }
            else
            {
                tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcd > 0)
            {
                double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
                tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>" + calfd + "</td>");
            }
            else
            {
                tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
            }
            if (totcc > 0)
            {
                double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
                tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:" + calft.ToString() + "</b>");
            }
            else
            {
                tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
            }
            tbl.Append("<td  class='middle13new'  colspan='4' align='right' style='font-size: 13px;'><b>BillAmt:" + amt.ToString() + "</b></td>");
            tbl.Append("<td class='middle1212' >&nbsp;</td>");
            tbl.Append("</tr>");
            tbl.Append("</table>");
            tblgrid.InnerHtml = tbl.ToString();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.Write("<p <table width='100%' align=\"center\"><tr><td  colspan=\"23\" align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
            hw.Write("<p <tr><td align=\"center\" colspan=\"23\"><b>" + "ALL ADS OF DAY" + "</b></td></tr></table>");

            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }

    private void gridbindexcelsummarybookingcls()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {


            //if (hiddendateformat.Value == "dd/mm/yyyy")
            //{
            //    from_date = DMYToMDY(txtfrmdate.Text);
            //    to_date = DMYToMDY(txttodate1.Text);
            //}


            //else if (hiddendateformat.Value == "yyyy/mm/dd")
            //{
            //    from_date = YMDToMDY(txtfrmdate.Text);
            //    to_date = YMDToMDY(txttodate1.Text);
            //}
            //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
            //ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue);

        }
        else
        {
            //string procedureName = "reportnew1_sum";
            string[] parameterValueArray = { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, "", uom, userid, state, dist, city, "", "6", "", "", "" };
            // NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            //ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            NewAdbooking.classmysql.reportstatusall cls_comb = new NewAdbooking.classmysql.reportstatusall();
            ds = cls_comb.alladssummaryrptexlcls(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, "", uom, userid, state, dist, city, "", "6", "", "", "");


        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            //string cmpnyname = ds.Tables[0].Rows[0]["companyname"].ToString();

            int cont = ds.Tables[0].Rows.Count;
            // string tbl = "";
            StringBuilder tbl = new StringBuilder();
            tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='1'>");

            tbl.Append("<tr><td   width='10%' ><b></b></td><td  class='middle31new' width='10%' ><b>From Date</b></td><td class='middle31new'  width='10%' align='left'><b>" + fromdate + "</b></td> <td class='middle31new'  width='10%' align='left'><b>To Date</b></td> <td class='middle31new'  width='10%' align='left'><b>" + dateto + "</b></td></tr>");

            tbl.Append("<tr><td  width='10%' ><b></b></td></tr>");
            tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td> <td class='middle31new' width='3%' align='left'><b>Booking Date</b></td> <td class='middle31new' width='3%' align='left'><b>Booking ID</b></td> <td class='middle31new' width='9%' align='left'><b>Agency</b></td> <td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Total Area</b></td> <td class='middle31new' width='7%' align='left'><b>Publish Ad</b></td> <td class='middle31new' width='2%' align='right'><b>Un Publish Ad</b></td> <td class='middle31new' width='2%' align='right'><b>Total Ad</b></td> </td> <td class='middle31new' width='2%' align='right'><b>Paid Ins.</b></td><td class='middle31new' width='2%' align='right'><b>Free Ins.</b></td><td class='middle31new' width='2%' align='right'><b>Type</b></td><td class='middle31new' width='2%' align='right'><b>Remark</b></td></tr>");
            for (int i = 0; i <= cont - 1; i++)
            {
                tbl.Append("<tr>");
                tbl.Append("<td class='rep_data'>" + i1++.ToString() + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["booking_dt"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["booking_id"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["agency_name"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["client_name"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["total_area"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["publish_ad"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["un_publish"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["total_ins"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["paidinsert"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["freeinsert"] + "</td>");
                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["schemeinsert"] + "</td>");

                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["remark"] + "</td>");


                tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + "</td>");
                tbl.Append("</tr>");
                //tblgrid.InnerHtml = tbl.ToString();
            }
            tbl.Append("</table>");
            tblgrid.InnerHtml = tbl.ToString();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //hw.Write("<p <table width='100%' align=\"center\"><tr><td  colspan=\"23\" align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
            //hw.Write("<p <tr><td align=\"center\" colspan=\"23\"><b>" + "ALL ADS OF DAY" + "</b></td></tr></table>");

            hw.WriteBreak();
            tblgrid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }

    private void gridbindexcelsummary()
    {
        DataSet ds = new DataSet();
        DataSet dsdate = new DataSet();
        StringBuilder tbl = new StringBuilder();
        if (fromdate == dateto)
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
                ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
            }

            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {


                //if (hiddendateformat.Value == "dd/mm/yyyy")
                //{
                //    from_date = DMYToMDY(txtfrmdate.Text);
                //    to_date = DMYToMDY(txttodate1.Text);
                //}


                //else if (hiddendateformat.Value == "yyyy/mm/dd")
                //{
                //    from_date = YMDToMDY(txtfrmdate.Text);
                //    to_date = YMDToMDY(txttodate1.Text);
                //}
                //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                //ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue);

            }
            else
            {
                if (uom == "--Select UOM Name--")
                {
                    uom = "";
                }
                //string procedureName = "reportnew1_sum";
                string[] parameterValueArray = { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city, "", "", "", "", "", };
                // NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                //  ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

                NewAdbooking.classmysql.reportstatusall cls_comb = new NewAdbooking.classmysql.reportstatusall();
                ds = cls_comb.alladssummaryrptexl(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, "", uom, userid, state, dist, city, "", "", "", bookingtype, "");

            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Clear();
                Response.ClearContent();
                Response.Charset = "UTF-8";
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

                string cmpnyname = ds.Tables[0].Rows[0]["companyname"].ToString();

                int cont = ds.Tables[0].Rows.Count;
                // string tbl = "";

                tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='1'>");

                tbl.Append("<tr><td   width='10%' ><b></b></td><td  class='middle31new' width='10%' ><b>From Date</b></td><td class='middle31new'  width='10%' align='left'><b>" + fromdate + "</b></td> <td class='middle31new'  width='10%' align='left'><b>To Date</b></td> <td class='middle31new'  width='10%' align='left'><b>" + dateto + "</b></td></tr>");

                tbl.Append("<tr><td  width='10%' ><b></b></td></tr>");

                //tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='3%' align='left'><b>Edition</b></td><td class='middle31new' width='3%' align='left'><b>Publish</br>Date</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td></b></tr>");
                tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>No&nbsp;&nbsp;</b></td> <td class='middle31new' width='1%' align='left'><b>Order &nbsp;&nbsp;</br>Type&nbsp;&nbsp;</b></td> <td class='middle31new' width='1%' align='left'><b>Chart&nbsp;&nbsp;</br>Type&nbsp;&nbsp;</b></td> <td class='middle31new' width='4%' align='left'><b>Material&nbsp;&nbsp;</br>Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='3%' align='left'><b>Sub AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;PUB TYPE&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td><td class='middle31new' width='8%' align='center'><b>Variant</b></td><td class='middle31new' width='8%' align='center'><b>Mailing Center</b></td><td class='middle31new' width='8%' align='center'><b>Publication</b></td><td class='middle31new' width='8%' align='center'><b>Publish Date</b></td><td class='middle31new' width='8%' align='center'><b>Booking Type</b></td></b></tr>");

                for (int i = 0; i <= cont - 1; i++)
                {
                    tbl.Append("<tr>");

                    tbl.Append("<td class='rep_data'>" + i1++.ToString() + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + cioid1 + "</td>");
                    //tbl = tbl + (cioid1 + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["edition"] + "</td>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");

                    if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                    {
                        DateTime dt = System.DateTime.Now;
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();

                        date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;
                    }
                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + agency1 + "</td>");
                    //tbl = tbl + (agency1 + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + client1 + "</td>");
                    //tbl = tbl + (client1 + "</td>");

                    string Package1 = "";
                    string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
                    /* if (rrr3.Length >= 9)
                     {
                         Package1 = rrr3.Substring(0, 9);
                         if (rrr3.Length - 9 < 9)
                             Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                         else
                             Package1 += "</br>" + rrr3.Substring(9, 9);
                     }
                     else
                         Package1 = rrr3;*/

                    Package1 = rrr3;


                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + Package1 + "</td>");
                    //tbl = tbl + (Package1 + "</td>");

                    if ((ds.Tables[0].Rows[i]["Width"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");

                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Width"]).ToString("F2") + "</td>");
                    }

                    if ((ds.Tables[0].Rows[i]["Depth"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Depth"]).ToString("F2") + "</td>");
                    }

                    if ((ds.Tables[0].Rows[i]["Area"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2") + "</td>");

                        if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["Color_code"] + "</td>");

                    if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                    }

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["resource_no"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["sectioncode"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["MATERIAL_STATUS"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Page"] + "</td>");

                    if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >" + ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                    }


                    if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                    }




                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["RoNo."] + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + RoStatus1 + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + AdCat1 + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["AdsubCat"].ToString() + "</td>");

                    if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                    }

                    if ((ds.Tables[0].Rows[i]["AgreedRate"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                    }
                    ///////cash disc

                    if ((ds.Tables[0].Rows[i]["Cash_Disc"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Cash_Disc"]).ToString("F2") + "</td>");
                    }

                    ////////cash disc

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["AGREED_AMOUNT"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["SPL_AMOUNT"] + "</td>");

                    if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'></td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                    }

                    if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Cap"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Key"] + "</td>");
                    //if (ds.Tables[0].Rows[i]["DOCKIT_NO"] != "" || ds.Tables[0].Rows[i]["DOCKIT_NO"] != null)
                    //{
                    //    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["DOCKIT_NO"] + "</td>");
                    //}

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["EXEC_NAME"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_STATUS"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["GS"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_CENTER"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["REVENUE_CENTER"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["PRINT_REMARK"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["brand_name"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["mailing_center"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["publication"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["insert_date"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["booking_type"] + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["ADSTATUS"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["GS"] + "</td>");

                    tbl.Append("</tr>");


                    tblgrid.InnerHtml = tbl.ToString();
                }
            }
        }
        else
        {
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                NewAdbooking.classmysql.reportstatusall cls_comb1 = new NewAdbooking.classmysql.reportstatusall();
                dsdate = cls_comb1.getgromdate_todatedata(fromdate, dateto);
            }

            for (int dsdt = 0; dsdt <= dsdate.Tables[0].Rows.Count - 1; dsdt++)
            {
                string fromdate1 = dsdate.Tables[0].Rows[dsdt]["REC_DATE"].ToString();
                string dateto1 = dsdate.Tables[0].Rows[dsdt]["REC_DATE"].ToString();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
                    ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    //if (hiddendateformat.Value == "dd/mm/yyyy") //{ //    from_date = DMYToMDY(txtfrmdate.Text); //    to_date = DMYToMDY(txttodate1.Text); //}
                    //else if (hiddendateformat.Value == "yyyy/mm/dd")
                    //{
                    //    from_date = YMDToMDY(txtfrmdate.Text);
                    //    to_date = YMDToMDY(txttodate1.Text);
                    //}
                    //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
                    //ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue);

                }
                else
                {
                    if (uom == "--Select UOM Name--")
                    {
                        uom = "";
                    }
                    //string procedureName = "reportnew1_sum";
                    string[] parameterValueArray = { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city, "", "", "", "", "", };
                    // NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    //  ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

                    NewAdbooking.classmysql.reportstatusall cls_comb = new NewAdbooking.classmysql.reportstatusall();
                    ds = cls_comb.alladssummaryrptexl(agname, clientname, adtype, listadcat, listadsubcat, fromdate1, dateto1, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, "", uom, userid, state, dist, city, "", "", "", bookingtype, "");

                }
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                string cmpnyname = ds.Tables[0].Rows[0]["companyname"].ToString();

                int cont = ds.Tables[0].Rows.Count;


                if (dsdt == 0)
                {
                    Response.Clear();
                    Response.ClearContent();
                    Response.Charset = "UTF-8";
                    Response.ContentType = "text/csv";
                    Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
                    tbl.Append("<table width='100%'align='left' cellpadding='2' cellspacing='0' border='1'>");
                    tbl.Append("<tr><td   width='10%' ><b></b></td><td  class='middle31new' width='10%' ><b>From Date</b></td><td class='middle31new'  width='10%' align='left'><b>" + fromdate + "</b></td> <td class='middle31new'  width='10%' align='left'><b>To Date</b></td> <td class='middle31new'  width='10%' align='left'><b>" + dateto + "</b></td></tr>");
                    tbl.Append("<tr><td  width='10%' ><b></b></td></tr>");
                    //tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='3%' align='left'><b>Edition</b></td><td class='middle31new' width='3%' align='left'><b>Publish</br>Date</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Eye&nbsp;&nbsp;</br>Catc&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td></b></tr>");
                    tbl.Append("<tr><td  class='middle31new' width='1%' ><b>S.</br>No</b></td><td class='middle31new' width='3%' align='left'><b>Booking</br>&nbsp;&nbsp;&nbsp;ID</b></td><td class='middle31new' width='9%' align='left'><b>Agency</b></td><td class='middle31new' width='9%' align='left'><b>Client</b></td><td class='middle31new' width='7%' align='left'><b>Package</b></td><td class='middle31new' width='2%' align='right'><b>WD</b></td><td class='middle31new' width='2%' align='right'><b>HT</b></td><td class='middle31new' width='3%' align='right'><b>Area</b></td><td class='middle31new' width='1%' align='left'><b>Color</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>No&nbsp;&nbsp;</b></td> <td class='middle31new' width='1%' align='left'><b>Order &nbsp;&nbsp;</br>Type&nbsp;&nbsp;</b></td> <td class='middle31new' width='1%' align='left'><b>Chart&nbsp;&nbsp;</br>Type&nbsp;&nbsp;</b></td> <td class='middle31new' width='4%' align='left'><b>Material&nbsp;&nbsp;</br>Status&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='left'><b>Page&nbsp;&nbsp;</br>Position&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Page&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='1%' align='left'><b>Post&nbsp;&nbsp;</br>Prem&nbsp;&nbsp;</b></td><td class='middle31new' width='7%' align='left'><b>Ro No.</b></td><td class='middle31new' width='4%' align='left'><b>Ro </br>Status</b></td> <td class='middle31new' width='3%' align='left'><b>AdCat</b></td><td class='middle31new' width='3%' align='left'><b>Sub AdCat</b></td><td class='middle31new' width='4%' align='right'><b>Card</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Agg</br>Rate</b></td><td class='middle31new' width='4%' align='right'><b>Cash&nbsp;&nbsp;</br>Disc&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>AGREED AMOUNT</b></td><td class='middle31new' width='8%' align='center'><b>SPECIAL DISCOUNT</b></td><td class='middle31new' width='4%' align='right'><b>Bill&nbsp;&nbsp;</br>Amt&nbsp;&nbsp;</b></td><td class='middle31new' width='2%' colspan='1' align='left'><b>Caption</b></td><td class='middle31new' width='4%' align='center'><b> Key No.</b></td><td class='middle31new' width='4%' align='right'><b>Executive&nbsp;&nbsp;</br>Name&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='right'><b>&nbsp;&nbsp;PUB TYPE&nbsp;&nbsp;</b></td><td class='middle31new' width='4%' align='center'><b>&nbsp;&nbsp;BOOKED&nbsp;BY&nbsp;&nbsp;</b></td><td class='middle31new' width='8%' align='center'><b>BOOKING CENTER</b></td><td class='middle31new' width='8%' align='center'><b>REVENUE CENTER</b></td><td class='middle31new' width='8%' align='center'><b>PRINT REMARK</b></td><td class='middle31new' width='8%' align='center'><b>Variant</b></td><td class='middle31new' width='8%' align='center'><b>Mailing Center</b></td><td class='middle31new' width='8%' align='center'><b>Publication</b></td><td class='middle31new' width='8%' align='center'><b>Publish Date</b></td><td class='middle31new' width='8%' align='center'><b>Booking Type</b></td></b></tr>");
                }
                for (int i = 0; i <= cont - 1; i++)
                {
                    tbl.Append("<tr>");

                    tbl.Append("<td class='rep_data'>" + i1++.ToString() + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + cioid1 + "</td>");
                    //tbl = tbl + (cioid1 + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["edition"] + "</td>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");

                    if (hiddendateformat.Value == "dd/mm/yyyy".ToString())
                    {
                        DateTime dt = System.DateTime.Now;
                        day = dt.Day.ToString();
                        month = dt.Month.ToString();
                        year = dt.Year.ToString();

                        date = RETURN_LENGTH(day) + "/" + RETURN_LENGTH(month) + "/" + year;
                    }
                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");
                    //tbl = tbl + (ds.Tables[0].Rows[i]["Ins.Date"] + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + agency1 + "</td>");
                    //tbl = tbl + (agency1 + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + client1 + "</td>");
                    //tbl = tbl + (client1 + "</td>");

                    string Package1 = "";
                    string rrr3 = ds.Tables[0].Rows[i]["Package"].ToString();
                    /* if (rrr3.Length >= 9)
                     {
                         Package1 = rrr3.Substring(0, 9);
                         if (rrr3.Length - 9 < 9)
                             Package1 += "</br>" + rrr3.Substring(9, rrr3.Length - 9);
                         else
                             Package1 += "</br>" + rrr3.Substring(9, 9);
                     }
                     else
                         Package1 = rrr3;*/

                    Package1 = rrr3;


                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + Package1 + "</td>");
                    //tbl = tbl + (Package1 + "</td>");

                    if ((ds.Tables[0].Rows[i]["Width"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");

                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Width"]).ToString("F2") + "</td>");
                    }

                    if ((ds.Tables[0].Rows[i]["Depth"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Depth"]).ToString("F2") + "</td>");
                    }

                    if ((ds.Tables[0].Rows[i]["Area"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Area"]).ToString("F2") + "</td>");

                        if (ds.Tables[0].Rows[i]["uom"].ToString() == "CD" || ds.Tables[0].Rows[i]["uom"].ToString() == "ROD")
                            area = area + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROL")
                            totrol = totrol + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROC")
                            totcd = totcd + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                        else if (ds.Tables[0].Rows[i]["uom"].ToString() == "ROW")
                            totcc = totcc + double.Parse(ds.Tables[0].Rows[i]["Area"].ToString());
                    }

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["Color_code"] + "</td>");

                    if (ds.Tables[0].Rows[i]["BulletPremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["BulletPremium"] + "</td>");
                    }

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["resource_no"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["sectioncode"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["MATERIAL_STATUS"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Page"] + "</td>");

                    if (ds.Tables[0].Rows[i]["PagePremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' >" + ds.Tables[0].Rows[i]["PagePremium"] + "</td>");
                    }


                    if (ds.Tables[0].Rows[i]["PositionPremium"].ToString() == "0")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' width='1%'>" + ds.Tables[0].Rows[i]["PositionPremium"] + "</td>");
                    }




                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["RoNo."] + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + RoStatus1 + "</td>");

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

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + AdCat1 + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["AdsubCat"].ToString() + "</td>");

                    if ((ds.Tables[0].Rows[i]["CardRate"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["CardRate"]).ToString("F2") + "</td>");
                    }

                    if ((ds.Tables[0].Rows[i]["AgreedRate"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["AgreedRate"]).ToString("F2") + "</td>");
                    }
                    ///////cash disc

                    if ((ds.Tables[0].Rows[i]["Cash_Disc"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>&nbsp;</td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Cash_Disc"]).ToString("F2") + "</td>");
                    }

                    ////////cash disc

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["AGREED_AMOUNT"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["SPL_AMOUNT"] + "</td>");

                    if ((ds.Tables[0].Rows[i]["Amt"]).ToString() == "")
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'></td>");
                    }
                    else
                    {
                        tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='right'>" + Convert.ToDouble(ds.Tables[0].Rows[i]["Amt"]).ToString("F2") + "</td>");
                    }

                    if (ds.Tables[0].Rows[i]["Amt"].ToString() != "")
                        amt = amt + double.Parse(ds.Tables[0].Rows[i]["Amt"].ToString());

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Cap"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left'>" + ds.Tables[0].Rows[i]["Key"] + "</td>");
                    //if (ds.Tables[0].Rows[i]["DOCKIT_NO"] != "" || ds.Tables[0].Rows[i]["DOCKIT_NO"] != null)
                    //{
                    //    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["DOCKIT_NO"] + "</td>");
                    //}

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["EXEC_NAME"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_STATUS"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

                    //tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["GS"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKING_CENTER"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["REVENUE_CENTER"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["PRINT_REMARK"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["brand_name"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["mailing_center"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["publication"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["insert_date"] + "</td>");

                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["booking_type"] + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["ADSTATUS"] + "</td>");
                    tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["BOOKED_BY"] + "</td>");

                    // tbl.Append("<td style=\"padding-left:4px\" class='rep_data' align='left' >" + ds.Tables[0].Rows[i]["GS"] + "</td>");

                    tbl.Append("</tr>");


                    //tblgrid.InnerHtml = tbl.ToString();
                    tblgrid.InnerHtml = tblgrid.InnerHtml + tbl.ToString();
                    tbl = new StringBuilder();

                }
            }
        }


        tbl.Append("<tr >");

        tbl.Append("<td class='middle13new' colspan='3' style='font-size: 13px;'><b>Total:</b>" + (i1 - 1).ToString() + "</td>");
        tbl.Append("<td class='middle13new' colspan='3'>&nbsp;</td>");

        ////////////////////////////////////////


        double cal = System.Math.Round(Convert.ToDouble(area), 2);
        tbl.Append("<td class='middle1212' colspan='4' align='right'><b>Total Area: " + cal.ToString() + "</b>");
        if (totrol > 0)
        {

            double calf = System.Math.Round(Convert.ToDouble(totrol), 2);
            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Lines:</b>" + calf.ToString() + "</td>");

        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcd > 0)
        {
            double calfd = System.Math.Round(Convert.ToDouble(totcd), 2);
            tbl.Append("<td class='middle1212' colspan='3' align='right'><b>Total Chars:</b>" + calfd + "</td>");

        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='3'>&nbsp;</td>");
        }
        if (totcc > 0)
        {
            double calft = System.Math.Round(Convert.ToDouble(totcc), 2);
            tbl.Append("<td class='middle1212' colspan='2' align='right'><b>Total Words:" + calft.ToString() + "</b>");

        }
        else
        {
            tbl.Append("<td class='middle1212' colspan='2'>&nbsp;</td>");
        }


        ///////////////////////////////////

        tbl.Append("<td  class='middle13new'  colspan='4' align='right' style='font-size: 13px;'><b>BillAmt:" + amt.ToString() + "</b></td>");

        // tbl = tbl + (amt.ToString() + "</td>");
        tbl.Append("<td class='middle1212' >&nbsp;</td>");

        tbl.Append("</tr>");

        tbl.Append("</table>");
        if (fromdate == dateto)
        {
            tblgrid.InnerHtml = tbl.ToString();
        }
        else
        {
            tblgrid.InnerHtml = tblgrid.InnerHtml + tbl.ToString();
        }
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.Write("<p <table width='100%' align=\"center\"><tr><td  colspan=\"23\" align=\"center\"><b>" + ds.Tables[0].Rows[0]["companyname"].ToString() + "</b></td></tr>");
        hw.Write("<p <tr><td align=\"center\" colspan=\"23\"><b>" + "ALL ADS OF DAY" + "</b></td></tr></table>");
        //hw.Write("<p <table> <tr><td colspan=\"4\"><b>PUBLICATION:" + "" + "</b></td> <td colspan=\"4\"><b> PUBLICATION CENTER:" + pcenter.Text + "</b></td><td colspan=\"4\"><b>  EDITION:" + lbedition.Text + " </b></td> <td colspan=\"4\"><b> AGENCY TYPE:" + lblagtype.Text + "</b></td></tr>");
        // hw.Write("<p <tr><td colspan=\"4\"><b>DATE FROM:" + "" + "</b></td> <td colspan=\"4\"><b> DATE TO:" + lblto.Text + "</b></td><td colspan=\"4\"><b> RUN DATE:" + lbldate.Text + "</b></td></tr>");
        //hw.Write("<p <tr><td  colspan=\"4\" ><b>AD TYPE:" + lbladtype.Text + "</b></td><td colspan=\"4\"><b>AD CATEGORY:" + lbladcatg.Text + "</b></td><td colspan=\"4\"><b>AD SUBCAT:" + lbladsubcat.Text + " </b></td></tr></table>");

        hw.WriteBreak();
        tblgrid.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
        //}
        //else
        //{
        //    Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        //}

    }

    /*
   public void gridbindexcelsummay()
   {
       DataSet ds = new DataSet();
       if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
       {
           NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
           ds = obj.spfun1(agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city);
       }

       else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
       {


           //if (hiddendateformat.Value == "dd/mm/yyyy")
           //{
           //    from_date = DMYToMDY(txtfrmdate.Text);
           //    to_date = DMYToMDY(txttodate1.Text);
           //}


           //else if (hiddendateformat.Value == "yyyy/mm/dd")
           //{
           //    from_date = YMDToMDY(txtfrmdate.Text);
           //    to_date = YMDToMDY(txttodate1.Text);
           //}
           //NewAdbooking.Report.Classes.report obj = new NewAdbooking.Report.Classes.report();
           //ds = obj.spfun1(dpdadtype.SelectedValue, str, new1str, from_date, to_date, dppub1.SelectedValue, dppubcent.SelectedValue, Session["compcode"].ToString(), hiddenedition.Value, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim(), "", "", "", "", dpagtype.SelectedItem.Text, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch.SelectedValue, dpd_printcent.SelectedValue, DropDowndocket.SelectedValue, DropDownsearching.SelectedValue, hiddenuom.Value, drpuserid.SelectedValue, drpstate.SelectedValue, drpdistrict.SelectedValue, drpcity.SelectedValue);

       }
       else
       {
           string procedureName = "reportnew1_sum";
           string[] parameterValueArray = { agname, clientname, adtype, listadcat, listadsubcat, fromdate, dateto, compcode, pubname, pubcent, status, edition, dateformat, hold, descid, ascdesc, agencytype, useridmain, chk_access, branch, printcenter, docket, searching, uom, userid, state, dist, city, "","","","","", };
           NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
           ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
       }
       if (ds.Tables[0].Rows.Count > 0)
       {
           Response.Clear();
           Response.ClearContent();
           Response.Charset = "UTF-8";
           Response.ContentType = "text/csv";
           Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

           int sno1 = 0;
           StringBuilder tbl = new StringBuilder();
           companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
           tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
           tbl.Append("<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>");
           tbl.Append("<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>");
           tbl.Append("<tr class='middle33'><td colspan='2' style='text-align:left'>From Date:" + fromdate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>");
           tbl.Append("<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + dateto + "</td></tr>");

           tbl.Append("</table>");
           tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
           tbl.Append("<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new' align='center'>" + BookingId + "</td><td  class='middle31new'>Booking Date</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + city1 + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ins + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + pub_dt + "</td><td  class='middle31new'>Username</td><td   class='middle31new' align='center' >Bill Amt</td><td   class='middle31new' align='right' >Remark</td></tr>");

           for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
           {


               sno1++;
               tbl.Append("<tr font-size='10' font-family='Arial'>");
               tbl.Append("<td class='rep_data' width='3%'>" + sno1 + "</td>");

               tbl.Append("<td class='rep_data' width='12%'style=padding-left:'1px'>");
               tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='10%'style=padding-left:'1px' align='left'>");
               string datewise = ds.Tables[0].Rows[p]["BKDATE"].ToString();

               //string[] datewise1 = datewise.Split(' ');
               //string[] datewise2 = datewise1[0].Split('/');
               //string mo = datewise2[0];
               //string da = datewise2[1];
               //string ye = datewise2[2];
               //if (Session["dateformat"].ToString() == "dd/mm/yyyy")
               //{
               //    datewise = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
               //}
               //else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
               //{

               //    datewise = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
               //}
               //else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
               //{

               //    datewise = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
               //}
               // tbl.Append(datewise + "</td>");
               tbl.Append("" + "</td>");


               tbl.Append("<td class='rep_data' width='20%'>");
               tbl.Append(ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='8%'>");
               tbl.Append(ds.Tables[0].Rows[p]["AG_CITY"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='20%'>");
               tbl.Append(ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>");


               tbl.Append("<td class='rep_data' width='8%'>");
               tbl.Append(ds.Tables[0].Rows[p]["no_of_insdertion"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='8%'>");
               tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='8%'>");

               string rodate = ds.Tables[0].Rows[p]["RO_DATE"].ToString();
               string mo = "";
               string da = "";
               string ye = "";
               if (rodate != "")
               {
                   string[] rodate1 = rodate.Split(' ');
                   string[] rodate2 = rodate1[0].Split('/');
                   mo = rodate2[0];
                   da = rodate2[1];
                   ye = rodate2[2];
               }
               if (Session["dateformat"].ToString() == "dd/mm/yyyy")
               {
                   rodate = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
               }
               else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
               {

                   rodate = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
               }
               else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
               {

                   rodate = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
               }
               tbl.Append(rodate + "</td>");

               tbl.Append("<td class='rep_data' width='8%'>");
               tbl.Append(ds.Tables[0].Rows[p]["booked_by"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='20%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Amt"].ToString() + "</td>");


               tbl.Append("<td class='rep_data' width='20%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Print_remark"].ToString() + "</td>");


               if (ds.Tables[0].Rows[p]["Amt"].ToString() != "")
                   BillAmt = BillAmt + Convert.ToDouble(ds.Tables[0].Rows[p]["Amt"].ToString());

               //tbl.Append( ds.Tables[0].Rows[p]["RO_DATE"].ToString() + "</td>");
               //tbl.Append = tbl.Append + ("<tr><td colspan='3' class='rep_data'></td>" + BillAmt);

               rowcounter++;
           }



           tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
           tbl.Append("<tr font-size='10' font-family='Arial'>");
           tbl.Append("</br><b><td width='100%' border='1' class='middle31new' cellpadding='0px' cellspacing='0px' align='left'>");
           tbl.Append(("Total") + "</td>");
           tbl.Append("</br><b><td width='100%' border='1' class='middle31new' cellpadding='0px' cellspacing='0px' align='right'>");
           tbl.Append((BillAmt.ToString()) + "</td>");
           tbl.Append("</tr></table></p>");

           report.InnerHtml = tbl.ToString();
           System.IO.StringWriter sw = new System.IO.StringWriter();
           HtmlTextWriter hw = new HtmlTextWriter(sw);
           hw.WriteBreak();
           report.RenderControl(hw);
           Response.Write(sw.ToString());
           Response.Flush();
           Response.End();

       }
       else
       {
           Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
       }

   }
   */

    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }
   


}
