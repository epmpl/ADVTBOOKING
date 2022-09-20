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


public partial class followupreport : System.Web.UI.Page
{
    string compcode = "";
    string agency = "";
    string fdate = "";
    string tdate = "";
    string client = "";
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
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string companyname = "";
    string SNo = "";
    string BookingId = "";
    string ClientName = "";
    string ClientMail = "";
    string AgencyName = "";
    string Agencymail = "";
    string edition = "";
    string Package = "";
    string INSERTION = "";
    string RO_No = "";
    string RO_date = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        hiddencomcode.Value = Session["compcode"].ToString();
        compcode = hiddencomcode.Value;
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();
        fdate = Request.QueryString["fdate"].ToString();
        tdate = Request.QueryString["tdate"].ToString();
        agency = Request.QueryString["agency"].ToString();
        client = Request.QueryString["client"].ToString();
        view = Request.QueryString["view"].ToString();
        reportname = "Follow Report";
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
        BookingId = "Booking ID";
        Package = "Package";
        edition = "Edition";
        INSERTION = "Ins.No";
        AgencyName = "Agency";
        Agencymail = "AgencyMail";
        ClientName = "Client";
        ClientMail = "Client Mail";
        RO_No = "RO.NO";
       
        RO_date = "RO Date";
      
        if (!Page.IsPostBack)
        {
           // btnExit.Attributes.Add("OnClick", "javascript:return formexit();");
         
            if (view == "ons")
            {
                gridbind();
            }
            else
            {
                gridbind_excel();
            }

        }

    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.followup frec = new NewAdbooking.Classes.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.followup frec = new NewAdbooking.classesoracle.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);

        }


        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>From Date:" + fdate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + tdate + "</td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new'>" + BookingId + "</td><td  class='middle31new'>" + Package + "</td><td  class='middle31new'>" + edition + "</td><td  class='middle31new'>" + INSERTION + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + Agencymail + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ClientMail + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + RO_date + "</td></tr>";

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    tbl += "</table><p>";
                    tbl += "</br>";
                    tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                    tbl += "</table><p>";

                    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new'>" + BookingId + "</td><td  class='middle31new'>" + Package + "</td><td  class='middle31new'>" + edition + "</td><td  class='middle31new'>" + INSERTION + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + Agencymail + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ClientMail + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + RO_date + "</td></tr>";
                    tbl += "</table></p>";
                    tbl += "<p><table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                }

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='8%'style=padding-left:'1px'>";
                tbl += ds.Tables[0].Rows[p]["ID"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["PACKAGENAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["EDITIONNAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["INSERTION"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["AGENCYNAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["MAIL"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["ClientName"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["RONO"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["RODATE"].ToString() + "</td>";
               

                rowcounter++;

            }

            tbl += "</table></p>";

            report.InnerHtml = tbl;
           
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }
        btnPrint.Attributes.Add("onclick", "javascript:window.open('printfollowupreport.aspx?fdate=" + fdate + "&tdate=" + tdate + "&agency=" + agency + "&client=" + client + "&view=" + view + "')");


    }
    public void gridbind_excel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.followup frec = new NewAdbooking.Classes.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.followup frec = new NewAdbooking.classesoracle.followup();
            ds = frec.findrecord(compcode, agency, client, fdate, tdate, hiddendateformat.Value, extra1, extra2, extra3);

        }
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
       


        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
            tbl = "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='middle4'><td colspan='14' align='center'>" + companyname + "</td></tr>";
            tbl += "<tr class='middle4'><td colspan='14' align='center' >" + reportname + "</td></tr>";
            tbl += "<tr class='middle4'><td colspan='2' style='text-align:left'>From Date:" + fdate + "</td><td align='right' colspan='12'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + tdate + "</td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new' align='center'>" + SNo + "</td><td class='middle31new' align='center'>" + BookingId + "</td><td  class='middle31new' align='center'>" + Package + "</td><td  class='middle31new' align='center'>" + edition + "</td><td  class='middle31new' align='center'>" + INSERTION + "</td><td  class='middle31new' align='center'  colspan='2'>" + AgencyName + "</td><td  class='middle31new' align='center'  colspan='2'>" + Agencymail + "</td><td  class='middle31new' align='center'  colspan='2'>" + ClientName + "</td><td  class='middle31new' align='center'>" + ClientMail + "</td><td  class='middle31new' align='center'>" + RO_No + "</td><td  class='middle31new' align='center'>" + RO_date + "</td></tr>";

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                //if (rowcounter == maxlimit)
                //{
                //    rowcounter = 0;
                //    tbl += "</table><p>";
                //    tbl += "</br>";
                //    tbl += "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>";

                //    tbl += "</table><p>";

                //    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                //    tbl += "<tr><td  class='middle31new'>" + SNo + "</td><td class='middle31new'>" + BookingId + "</td><td  class='middle31new'>" + Package + "</td><td  class='middle31new'>" + edition + "</td><td  class='middle31new'>" + INSERTION + "</td><td  class='middle31new'>" + AgencyName + "</td><td  class='middle31new'>" + Agencymail + "</td><td  class='middle31new'>" + ClientName + "</td><td  class='middle31new'>" + ClientMail + "</td><td  class='middle31new'>" + RO_No + "</td><td  class='middle31new'>" + RO_date + "</td></tr>";
                //    tbl += "</table></p>";
                //    tbl += "<p><table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                //}

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' align='center'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' align='center'>";
                tbl += ds.Tables[0].Rows[p]["ID"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center'>";
                tbl += ds.Tables[0].Rows[p]["PACKAGENAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center'>";
                tbl += ds.Tables[0].Rows[p]["EDITIONNAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center' >";
                tbl += ds.Tables[0].Rows[p]["INSERTION"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center' colspan='2'>";
                tbl += ds.Tables[0].Rows[p]["AGENCYNAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center'  colspan='2'>";
                tbl += ds.Tables[0].Rows[p]["MAIL"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center' colspan='2'>";
                tbl += ds.Tables[0].Rows[p]["ClientName"].ToString() + "</td>";

                tbl += "<td class='rep_data' align='center'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>";
                tbl += "<td class='rep_data' align='center'>";
                tbl += ds.Tables[0].Rows[p]["RONO"].ToString() + "</td>";

                tbl += "<td class='rep_data' align='center'>";
                tbl += ds.Tables[0].Rows[p]["RODATE"].ToString() + "</td>";


                rowcounter++;

            }

            tbl += "</table></p>";

            report.InnerHtml = tbl;
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
}
