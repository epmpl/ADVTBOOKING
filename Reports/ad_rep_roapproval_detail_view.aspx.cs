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


public partial class ad_rep_roapproval_detail_view : System.Web.UI.Page
{
    string pextra1 = "";
    string pextra2 = "";
    string pextra3 = "";
    string pextra4 = "";
    string pextra5 = "";
    string compcode = "";
    string branch = "";
    string fromdate = "";
    string todate = "";
    string branch_name = "";
    string type = "";
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
    string agencycode = "";
    string client = "";
    string excutive = "";
    string center = "";
    string center_name = "";
    string status = "";
    string pdate_flag = "";
    string sno = "";
    string ciod = "";
    string clientname = "";
    string agencyname = "";
    string sqcm = "";
    string pubdate = "";
    string apporal = "";
    string printremark = "";
    string per = "";
    string userid = "";
    string view = "";
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
        userid = hiddenuserid.Value;
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();
        fromdate = Request.QueryString["fromdate"].ToString();
        todate = Request.QueryString["todate"].ToString();
        center = Request.QueryString["center"].ToString();
        center_name = Request.QueryString["center_name"].ToString();
        branch = Request.QueryString["branch"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();
        status = Request.QueryString["status"].ToString();
        pdate_flag = Request.QueryString["pdate_flag"].ToString();
        status = Request.QueryString["status"].ToString();
        pdate_flag = Request.QueryString["pdate_flag"].ToString();
        view = Request.QueryString["view"].ToString();
        client = Request.QueryString["client"].ToString();
        agencycode = Request.QueryString["agencycode"].ToString();
        excutive = Request.QueryString["excutive"].ToString();
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
        sno = "S.No";
        ciod = "Booking Id";
        clientname = "Client Name";
        sqcm = "SQCM/Words";
        agencyname = "Agency Name";
        pubdate = "Pub Date";
        apporal = "Approved By";
        printremark = "Remarks";
        per = "Discount Percent";
       
        reportname = "Ro Approval Detail";
        if (!Page.IsPostBack)
        {
            if (view == "ons")
            {
                gridbind();
            }
            else
            {
               gridbind_excel();
            }
       btnPrint.Attributes.Add("onclick", "javascript:return printreport();");

        }
       
    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.ad_rep_roapproval_detail(compcode, center, branch, agencycode, client, excutive, pdate_flag, fromdate, todate, dateformat,userid,status, pextra1, pextra2, pextra3, pextra4, pextra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = unregistclient.ad_rep_roapproval_detail(compcode, center, branch, agencycode, client, excutive, pdate_flag, fromdate, todate, dateformat, userid, status, pextra1, pextra2, pextra3, pextra4, pextra5);
    
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ad_rep_roapproval_detail";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, center, branch, agencycode, client, excutive, pdate_flag, fromdate, todate, dateformat, userid, status, pextra1, pextra2, pextra3, pextra4, pextra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            companyname = ds.Tables[0].Rows[0]["Comp_Name"].ToString();
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + companyname + "</td></tr>";
            tbl += "<tr class='headingc'><td colspan='4' style='text-align:center'>" + reportname + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>From Date:" + fromdate + "</td><td style='text-align:right'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>ToDate:" + todate + "</td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new'>" + sno + "</td><td  class='middle31new'>" + ciod + "</td><td  class='middle31new'>" + clientname + "</td><td  class='middle31new'>" + agencyname + "</td><td  class='middle31new'>" + sqcm + "</td><td  class='middle31new'>" + pubdate + "</td><td  class='middle31new'>" + apporal + "</td><td  class='middle31new'>" + printremark + "</td><td  class='middle31new'>" + per + "</td></tr>";
               
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
                    tbl += "<tr><td  class='middle31new'>" + sno + "</td><td  class='middle31new'>" + ciod + "</td><td  class='middle31new'>" + clientname + "</td><td  class='middle31new'>" + agencyname + "</td><td  class='middle31new'>" + sqcm + "</td><td  class='middle31new'>" + pubdate + "</td><td  class='middle31new'>" + apporal + "</td><td  class='middle31new'>" + printremark + "</td><td  class='middle31new'>" + per + "</td></tr>";
                    //tbl += "</table></p>";
                    //tbl += "<p><table width='100%' cellspacing='0' cellpadding='0' border='0' >";
                }

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='8%'style=padding-left:'1px'>";
                tbl += ds.Tables[0].Rows[p]["CIO_BOOKING_ID"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["AGENCY"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["SIZE_BOOK"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["BOOKDATE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["APPROVED_BY"].ToString() + "</td>";
               
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["APPROVED_REMARK"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["DEVIATION"].ToString() + "</td>";

              

                rowcounter++;

            }

            tbl += "</table></p>";

            report.InnerHtml = tbl;
      
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }

    public void gridbind_excel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.unregisteredclient unregistclient = new NewAdbooking.Report.classesoracle.unregisteredclient();
            ds = unregistclient.ad_rep_roapproval_detail(compcode, center, branch, agencycode, client, excutive, pdate_flag, fromdate, todate, dateformat, userid, status, pextra1, pextra2, pextra3, pextra4, pextra5);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.unregisteredclient unregistclient = new NewAdbooking.Report.Classes.unregisteredclient();
            ds = unregistclient.ad_rep_roapproval_detail(compcode, center, branch, agencycode, client, excutive, pdate_flag, fromdate, todate, dateformat, userid, status, pextra1, pextra2, pextra3, pextra4, pextra5);
    
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "mysql")
        {
            string procedureName = "ad_rep_roapproval_detail";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = { compcode, center, branch, agencycode, client, excutive, pdate_flag, fromdate, todate, dateformat, userid, status, pextra1, pextra2, pextra3, pextra4, pextra5 };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
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
            tbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr class='headingc'><td colspan='12'  align='center'>" + companyname + "</td></tr>";
            tbl += "<tr class='headingc'><td colspan='12'  align='center'>" + reportname + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='6'  align='left'>From Date:" + fromdate + "</td><td colspan='6'  align='right'>Run Date:" + rdatefinalhdsmain + "</td></tr>";
            tbl += "<tr class='middle33'><td colspan='6' align='left'>ToDate:" + todate + "</td></tr>";

            tbl += "</table>";
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
            tbl += "<tr><td  class='middle31new'>" + sno + "</td><td  class='middle31new' colspan='2' >" + ciod + "</td><td  class='middle31new' colspan='2' >" + clientname + "</td><td  class='middle31new' colspan='2' >" + agencyname + "</td><td  class='middle31new'>" + sqcm + "</td><td  class='middle31new'>" + pubdate + "</td><td  class='middle31new'>" + apporal + "</td><td  class='middle31new'>" + printremark + "</td><td  class='middle31new'>" + per + "</td></tr>";
                
            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

              
                sno1++;
                tbl += "<tr font-size='10' font-family='Arial' align='center'>";
                tbl += "<td class='rep_data' width='3%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' colspan='2'  width='8%'style=padding-left:'1px'>";
                tbl += ds.Tables[0].Rows[p]["CIO_BOOKING_ID"].ToString() + "</td>";
                tbl += "<td class='rep_data' colspan='2'  width='8%'>";
                tbl += ds.Tables[0].Rows[p]["CLIENT"].ToString() + "</td>";
                tbl += "<td class='rep_data' colspan='2'  width='8%'>";
                tbl += ds.Tables[0].Rows[p]["AGENCY"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["SIZE_BOOK"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["BOOKDATE"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["APPROVED_BY"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["APPROVED_REMARK"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["DEVIATION"].ToString() + "</td>";



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
         //   Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
           // alert("1");

           
        }

    }
}
