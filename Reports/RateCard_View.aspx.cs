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
using System.Text;

public partial class RateCard_View : System.Web.UI.Page
{
    string fdate = "";
    string tdate = "";
    string center1 = "";
    string dpaddtype = "";
    string adcat = "";
    string package1 = "";
    string rundate = "";
    string ratecode = "";
    string dateformat = "";
    string adtype_nam = "";
    string center_nam = "";
    string adcat_nam = "";
    string uomcode = "";
    string ratecode_nam = "";

    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 15;
    int pgn = 0;
    string sno = "";
    string view = "";
    string rdatefinalhdsmain = "";
    string reportname = "";
    string companyname = "";
    string drpbookfrom = "";
    string user = "";
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your Session Has Been Expired');window.close();</script>"); ;
            return;
        }
        hiddencomcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();
        dateformat = Session["dateformat"].ToString();

        fdate = Request.QueryString["fdate"].ToString();
        tdate = Request.QueryString["tdate"].ToString();
        center1 = Request.QueryString["center1"].ToString();
        dpaddtype = Request.QueryString["dpaddtype"].ToString();
        adcat = Request.QueryString["adcat"].ToString();
        ratecode = Request.QueryString["ratecode1"].ToString();
        package1 = Request.QueryString["package1"].ToString();
        view = Request.QueryString["view"].ToString();
        adtype_nam = Request.QueryString["adtype_nam"].ToString();
        center_nam = Request.QueryString["center_nam"].ToString();
        adcat_nam = Request.QueryString["adcat_nam"].ToString();
        ratecode_nam = Request.QueryString["ratecode_nam"].ToString();
        uomcode = Request.QueryString["dpedidetail"].ToString();
        user = Session["Username"].ToString();
        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        string rdate = tim[0];
        string[] rdatehdsmaintds = rdate.Split(' ');
        string hdsmainhjrdate = rdatehdsmaintds[0];
        string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
        string hdsmainhjrdate1 = hdsmainhjrdateS[0];
        string hdsmainhjrdate2 = hdsmainhjrdateS[1];
        string hdsmainhjrdate3 = hdsmainhjrdateS[2];
        rdatefinalhdsmain = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;


        reportname = "Rate Card Register";
        if (!Page.IsPostBack)
        {
            if (view == "0" || view == "1" || view == "")
            {
                gridbind();
            }
            else
            {
                gridbind_excel();
            }
            // btnPrint.Attributes.Add("onclick", "javascript:return printreport();");

        }

    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            //ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch);
            ds = obj.displaycardratereport(fdate, tdate, Session["compcode"].ToString(), center1, ratecode, dpaddtype, adcat, Session["dateformat"].ToString(), package1, Session["userid"].ToString(), uomcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.displaycardratereport(fdate, tdate, Session["compcode"].ToString(), center1, ratecode, dpaddtype, adcat, Session["dateformat"].ToString(), package1, Session["userid"].ToString(), uomcode);
        }
         else
        {
            string[] parameterValueArray = new string[] { fdate, tdate, dpaddtype, adcat, package1, center1, ratecode, Session["compcode"].ToString(), uomcode, Session["dateformat"].ToString(), Session["userid"].ToString(), null, null, null, null, null };
            string procedureName = "rpt_ratecard";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/RateCard.xml"));
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        maxlimit = Convert.ToInt32(dsxml.Tables[1].Rows[0].ItemArray[16].ToString());
       
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            StringBuilder tbl = new StringBuilder();
            double weekdayrat = 0;
            double weekextrarat = 0;
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
           tbl.Append(header());
           tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

           tbl.Append("<tr>");
           tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'  align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td>");
          // tbl.Append("<td  class='middle31new'  " + dsxml.Tables[1].Rows[0].ItemArray[17].ToString() + "</td>");
           tbl.Append("<td  class='middle31new'>" + "Premium" + "</td>");
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>");
           
           tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>");
           tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td>");
           
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td>");

           tbl.Append("</tr>");


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;

                   tbl.Append("</table></td><tr></table></p>");
                    tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                    tbl.Append("<tr><td>");
                   tbl.Append(header());
                   tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                   tbl.Append("<tr>");
                   tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new' align='center' >" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td>");
                   //tbl.Append("<td  class='middle31new'  " + dsxml.Tables[1].Rows[0].ItemArray[17].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + "Premium" + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>");
                   tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td>");
                    
                   tbl.Append("</tr>");
                }

                sno1++;
               tbl.Append("<tr font-size='10' font-family='Arial'>");
               tbl.Append("<td class='rep_data' width='2%'>" + sno1 + "</td>");

               tbl.Append("<td class='rep_data' width='8%'style=padding-left:'1px'>");
               tbl.Append(ds.Tables[0].Rows[p]["Pub_Cent_name"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='5%'>");
               tbl.Append(ds.Tables[0].Rows[p]["RATECODE"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='6%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Adv_Cat_Name"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='6%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Adv_Subcat_Name"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='8%'>");
               tbl.Append(ds.Tables[0].Rows[p]["PACKAGE"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='5%'>");
               tbl.Append(ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='3%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Size_From"].ToString() + "</b></td>");

               tbl.Append("<td class='rep_data' width='3%' align='center'>");
               tbl.Append(ds.Tables[0].Rows[p]["Size_To"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='5%'>");
               tbl.Append(ds.Tables[0].Rows[p]["MaxSize"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='5%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Valid_From"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='5%' style=padding-left:'2px'>");
               tbl.Append(ds.Tables[0].Rows[p]["Valid_To"].ToString() + "</td>");

                //tbl += "<td class='rep_data' width='5%'>");
                //tbl += ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='4%'>");
                string col = ds.Tables[0].Rows[p]["Col_Name"].ToString();
                if (col.Substring(0, 1) == "B")
                    col = "B / W";
               tbl.Append(col + "</td>");
               tbl.Append("<td class='rep_data' width='5%'>");
               tbl.Append(ds.Tables[0].Rows[p]["PREMIUMNAME"].ToString() + "</td>");
               tbl.Append("<td class='rep_data' width='5%'>");
               tbl.Append(ds.Tables[0].Rows[p]["Scheme_Name"].ToString() + "</td>");

               tbl.Append("<td class='rep_data' width='3%' align='right'>");
                if (ds.Tables[0].Rows[p]["Week_Day_Rate"].ToString() != "")
                    weekdayrat = Convert.ToDouble(ds.Tables[0].Rows[p]["Week_Day_Rate"].ToString());
               tbl.Append(weekdayrat.ToString("F2") + "</td>");

               tbl.Append("<td class='rep_data' width='5%' align='right'>");
                if (ds.Tables[0].Rows[p]["Week_Extra_Rate"].ToString() != "")
                    weekextrarat = Convert.ToDouble(ds.Tables[0].Rows[p]["Week_Extra_Rate"].ToString());
               tbl.Append(weekextrarat.ToString("F2") + "</td>");

               tbl.Append("</tr>");

                rowcounter++;

            }
           
           tbl.Append("</table></td><tr></table></p>");

            report.InnerHtml = tbl.ToString();

           
        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }
    private string header()
    {
        string hdrtbl = "";
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + reportname + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='2' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Center :</b>" + center_nam + "</td><td colspan='2' style='text-align:right'><b>Rate Code :</b>" + ratecode_nam + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='5' style='text-align:left'><b>Ad Category :</b>" + adcat_nam + "</td><td colspan='2'  style='text-align:left'><b>User Name:</b>" + user + "</td></tr>";//<td colspan='6' style='text-align:left'><b>Edition :</b>" + "" + "</td><td colspan='6' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    private string header_excel()
    {
        string hdrtbl = "";
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='18' style='font-size:12px;vertical-align:top;font-family:Verdana;text-align:center'><b>" + companyname + "</b></td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='18' style='font-size:12px;vertical-align:top;font-family:Verdana;text-align:center'><b>" + reportname + "</b></td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='6' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='6' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='6' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='6' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='6' style='text-align:left'><b>Center :</b>" + center_nam + "</td><td colspan='6' style='text-align:right'><b>Rate Code :</b>" + ratecode_nam + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='18' style='text-align:left'><b>Ad Category :</b>" + adcat_nam + "</td></tr>";//<td colspan='6' style='text-align:left'><b>Edition :</b>" + "" + "</td><td colspan='6' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    public void gridbind_excel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            // ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch);
            ds = obj.displaycardratereport(fdate, tdate, Session["compcode"].ToString(), center1, ratecode, dpaddtype, adcat, Session["dateformat"].ToString(), package1, Session["userid"].ToString(), uomcode);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.displaycardratereport(fdate, tdate, Session["compcode"].ToString(), center1, ratecode, dpaddtype, adcat, Session["dateformat"].ToString(), package1, Session["userid"].ToString(), uomcode);
        }
           else
        {
            string[] parameterValueArray = new string[] { fdate, tdate, dpaddtype, adcat, package1, center1, ratecode, Session["compcode"].ToString(), uomcode, Session["dateformat"].ToString(), Session["userid"].ToString(), null, null, null, null, null };
            string procedureName = "rpt_ratecard";
            NewAdbooking.classmysql.CommonClass sms = new NewAdbooking.classmysql.CommonClass();
            ds = sms.DynamicBindProcedure(procedureName, parameterValueArray);
            
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/RateCard.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        string tbl = "";

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");



        maxlimit = Convert.ToInt32(dsxml.Tables[1].Rows[0].ItemArray[16].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            //string tbl = "";
            double weekdayrat = 0;
            double weekextrarat = 0;
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            tbl = tbl + "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
            tbl = tbl + "<tr><td>";
            tbl += header();
            tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";

            tbl += "<tr>";
            tbl += "<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td>";
            tbl += "<td  class='middle31new'  align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td>";
           // tbl += "<td  class='middle31new'  " + dsxml.Tables[1].Rows[0].ItemArray[17].ToString() + "</td>";
            tbl += "<td  class='middle31new'>"   + "Premium" + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>";
            tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>";
            tbl += "<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td>";
            tbl += "</tr>";


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                //if (rowcounter == maxlimit)
                //{
                //    rowcounter = 0;

                //    tbl += "</table></td><tr></table></p>";
                //    tbl = tbl + "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
                //    tbl = tbl + "<tr><td>";
                //    tbl += header();
                //    tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
                //    tbl += "<tr>";
                //    tbl += "<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[15].ToString() + "</td>";
                //    tbl += "<td  class='middle31new' align='center' >" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>";
                //    tbl += "<td  class='middle31new' align='right'>" + dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td>";

                //    tbl += "<tr>";
                //}

                sno1++;
                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='2%'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='8%'style=padding-left:'1px'>";
                tbl += ds.Tables[0].Rows[p]["Pub_Cent_name"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='5%'>";
                tbl += ds.Tables[0].Rows[p]["RATECODE"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["Adv_Cat_Name"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='6%'>";
                tbl += ds.Tables[0].Rows[p]["Adv_Subcat_Name"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["PACKAGE"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='5%'>";
                tbl += ds.Tables[0].Rows[p]["UOM"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='3%'>";
                tbl += ds.Tables[0].Rows[p]["Size_From"].ToString() + "</b></td>";

                tbl += "<td class='rep_data' width='3%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["Size_To"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='5%'>";
                tbl += ds.Tables[0].Rows[p]["MaxSize"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='5%'>";
                tbl += ds.Tables[0].Rows[p]["Valid_From"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='5%' style=padding-left:'2px'>";
                tbl += ds.Tables[0].Rows[p]["Valid_To"].ToString() + "</td>";

                //tbl += "<td class='rep_data' width='5%'>";
                //tbl += ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='4%'>";
                string col = ds.Tables[0].Rows[p]["Col_Name"].ToString();
                if (col.Substring(0, 1) == "B")
                    col = "B / W";
                tbl += col + "</td>";
                tbl += "<td class='rep_data' width='8%'>";
                tbl += ds.Tables[0].Rows[p]["PREMIUMNAME"].ToString() + "</td>";
                tbl += "<td class='rep_data' width='5%'>";
                tbl += ds.Tables[0].Rows[p]["Scheme_Name"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='3%' align='right'>";
                if (ds.Tables[0].Rows[p]["Week_Day_Rate"].ToString() != "")
                    weekdayrat = Convert.ToDouble(ds.Tables[0].Rows[p]["Week_Day_Rate"].ToString());
                tbl += weekdayrat.ToString("F2") + "</td>";

                tbl += "<td class='rep_data' width='5%' align='right'>";
                if (ds.Tables[0].Rows[p]["Week_Extra_Rate"].ToString() != "")
                    weekextrarat = Convert.ToDouble(ds.Tables[0].Rows[p]["Week_Extra_Rate"].ToString());
                tbl += weekextrarat.ToString("F2") + "</td>";

                tbl += "</tr>";

                //tbl += "<tr font-size='10' font-family='Arial'>";

                //tbl += "<td class='rep_data' colspan='3' >";
                //tbl += ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>";

                //tbl += "<td style='font-size:11px;vertical-align:top;' colspan='17' ><b>Edition :</b>";
                //tbl += ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>";

                //tbl += "</tr>";

                //tbl += "<tr font-size='10' font-family='Arial' style='height:25px' >";

                //tbl += "<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Agency TD. :</b>";
                //tbl += ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</td>";

                //tbl += "<td style='font-size:11px;vertical-align:top;' colspan='18' ><b>Remark :</b>";
                //tbl += ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>";

                //tbl += "</tr>";



                rowcounter++;

            }
            tbl += "</table></td><tr></table></p>";

            report.InnerHtml = tbl;

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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printrow.Attributes.Add("style", "display:none");
        bdy.Attributes.Add("onload", "window.print()");
    }
}
