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

public partial class AttendenceRegister_view : System.Web.UI.Page
{
    string fdate = "";
    string tdate = "";
    string dppub1 = "";
    string drpstatus = "";
    string dpedition = "";
    string dppubcent = "";
    string dpaddtype = "";
    string adcat = "";
    string supplement = "";
    string package1 = "";
    string rundate = "";
    string dpedidetail = "";
    string dateformat = "";
    string dpd_branch = "";
    string adtype_nam = "";
    string publication_nam = "";
    string edition_nam = "";
    string pubcent_nam = "";
    string adcat_nam = "";
    string uomcode = "";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 8;
    int maxlimtbill = 30;
    int pgn = 0;
    int allbill = 0;
    string orderby = "";
    string sno = "";
    string view = "";
    string rdatefinalhdsmain = "";
    string reportname = "";
    string companyname = "";
    string drpbookfrom = "";
    string rdatefinalhdsmain1 = "";
    int combin = 0;
    int single = 0;
    string branch_name = "";
    string subcat = "";
    string subcatcode = "";
    string billflag = "";
    string bookdummy1 = "";
    string type = "";
    string bilcycle = "";
    string branchtype = "";
    string allreadybilled = "";
    string branchbased = "";
    string username = "";
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
        branchtype = Session["revenue"].ToString();

        fdate = Request.QueryString["fdate"].ToString();
        tdate = Request.QueryString["tdate"].ToString();
        dppub1 = Request.QueryString["dppub1"].ToString();
        drpstatus = Request.QueryString["drpstatus"].ToString();
        dpedition = Request.QueryString["dpedition1"].ToString();
        dppubcent = Request.QueryString["dppubcent"].ToString();
        dpaddtype = Request.QueryString["dpaddtype"].ToString();
        adcat = Request.QueryString["adcat"].ToString();
        supplement = Request.QueryString["supplement"].ToString();
        package1 = Request.QueryString["package1"].ToString();
        view = Request.QueryString["view"].ToString();
        drpbookfrom = Request.QueryString["drpbookfrom"].ToString();
        dpd_branch = Request.QueryString["dpd_branch"].ToString();
        adtype_nam = Request.QueryString["adtype_nam"].ToString();
        publication_nam = Request.QueryString["publication_nam"].ToString();
        edition_nam = Request.QueryString["edition_nam"].ToString();
        pubcent_nam = Request.QueryString["pubcent_nam"].ToString();
        adcat_nam = Request.QueryString["adcat_nam"].ToString();
        uomcode = Request.QueryString["dpedidetail"].ToString();
        branch_name = Request.QueryString["branch_name"].ToString();
        subcat = Request.QueryString["subcat"].ToString();
        subcatcode = Request.QueryString["subcatcode"].ToString();
        billflag = Request.QueryString["billflag"].ToString();
        bookdummy1 = Request.QueryString["dummyreport"].ToString();
        allreadybilled = Request.QueryString["allreaybilled"].ToString();
        branchbased = Request.QueryString["branchbaseddate"].ToString();
        username = Session["Username"].ToString();
          
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


        reportname = "Attendence Register";
        if (!Page.IsPostBack)
        {
            if (allreadybilled == "0")
            {
                if (view == "0" || view == "1" || view == "")
                {
                    gridbind();
                }
                else
                {
                    gridbind_excel();
                }
            }
            else
            {
                if (view == "0" || view == "1" || view == "")
                {
                    gridbindbilled();
                }
                else
                {
                    gridbind_excelbilled();
                }
            }
        
        }

    }
    public void gridbind()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
           //ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode);
         }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode);
        }
        else
        {
            string procedureName = "schedulereport_checklist";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/AttendenceRegister.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int totadd2 = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        int   schad=0;
        int directcash = 0;
        int totadd3 = 0;
        int bookdummy = 0;
        string bookintype = "";
        //====****************** Case for Book from other Center *****************//
        if (drpbookfrom == "Y" && dppubcent != "0" && dppubcent != "" && (ds.Tables[2].Rows.Count > 0))
        {
            showothercentdata = "Y";
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            //string tbl = "";
            double billamt = 0;
            companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
              StringBuilder tbl = new StringBuilder();
       
            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
            pgn = pgn + 1;
                 
            tbl.Append(header());
            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
            
           tbl.Append( "<tr>");
            tbl.Append( "<td  class='middle31new'>"+dsxml.Tables[0].Rows[0].ItemArray[0].ToString()+"</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
           // tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");
          
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");
         
            tbl.Append("<tr>");


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                    pgn = pgn + 1;
                    tbl.Append("</table></td><tr></table></p>");
                    tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                    tbl.Append("<tr><td>");
                    tbl.Append(header());

                    tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");

                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");
         
                    tbl.Append("<tr>");
                }
                if (branchbased == "NB")
                {
                if (bookdummy1 == "YDU")
                {
                    if (billflag == "bill")
                    {
                        sno1++;
                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                        tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                        string type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                        if (type == "7")
                        {
                            bookdummy++;
                        }
                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data_new' width='8%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                        //tbl += "<td class='rep_data_new' width='5%'>";
                        //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                        //tbl += "<td class='rep_data_new' width='5%'>";
                        //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                        if (col.Substring(0, 1) == "B")
                            col = "B / W";
                        tbl.Append(col + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='8%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                        //tbl += "<td class='rep_data_new' width='2%'>";
                        //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                        string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {
                        if (rateag == "0")
                        {
                            string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                            if (spdis != "0")
                            {
                                if (tran != "0")
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                }
                                else
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                }

                            }
                            else
                            {
                                if (tran != "0")
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                }
                                else
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                }

                            }
                        }
                        else
                        {
                            if (tran != "0")
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                            }
                            else
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                            }
                        }
                        }
                        tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                        if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                            billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {
                            tbl.Append(billamt.ToString("F2") + "</td>");
                        }


                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {
                            tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                        } 
                        if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                        {
                            allbill++;
                        }

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {

                            tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                        } 
                        string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                        if (bilcycle == "1")
                        {
                            bilcycle = "D";
                            single++;

                        }
                        else if (bilcycle == "2")
                        {
                            bilcycle = "W";

                        }
                        else if (bilcycle == "3")
                        {
                            bilcycle = "F";

                        }
                        else if (bilcycle == "4")
                        {
                            bilcycle = "M";

                        }

                        else if (bilcycle == "6")
                        {
                            bilcycle = "C";
                            combin++;

                        }


                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");


                        tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                        tbl.Append("</tr>");

                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                        tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                        string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                        if (datewise.IndexOf(' ') > -1)
                        {
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

                        }
                        tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));
                        tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                        if (type == "3")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                        }
                        else if (type == "1")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                        }

                        else if (type == "2")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                        }
                        else if (type == "4")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                        }
                        else if (type == "5")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                        }
                        else if (type == "6")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                        }
                        else if (type == "7")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                        }
                        tbl.Append((bookintype + "</td>"));

                        tbl.Append("<td class='rep_data_new' colspan='10' >");
                        tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                      
                        tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                        tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                        tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                        tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                        tbl.Append("</tr>");
                        tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                        tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='24' ><b>Edition :</b>");
                        tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                        tbl.Append("</tr>");
                     
                        tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                        tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                        tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                        tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                        tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                        tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                        tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                        tbl.Append("</tr>");



                        rowcounter++;

                    }


                    else
                    {
                        string type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                        if (type == "7")
                        {
                            bookdummy++;
                        }
                        if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                        {
                            allbill++;
                        }
                        string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                        if (bilcycle == "1")
                        {
                            bilcycle = "D";
                            single++;

                        }
                        else if (bilcycle == "2")
                        {
                            bilcycle = "W";

                        }
                        else if (bilcycle == "3")
                        {
                            bilcycle = "F";

                        }
                        else if (bilcycle == "4")
                        {
                            bilcycle = "M";

                        }

                        else if (bilcycle == "6")
                        {
                            bilcycle = "C";
                            combin++;

                        }


                        if (ds.Tables[0].Rows[p]["bill_no"].ToString() == "")
                        {
                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='2%'>";
                            //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            }
                            //if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            //{
                            //    allbill++;
                            //}

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            }
                            //string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            //if (bilcycle == "1")
                            //{
                            //    bilcycle = "D";
                            //    single++;

                            //}
                            //else if (bilcycle == "2")
                            //{
                            //    bilcycle = "W";

                            //}
                            //else if (bilcycle == "3")
                            //{
                            //    bilcycle = "F";

                            //}
                            //else if (bilcycle == "4")
                            //{
                            //    bilcycle = "M";

                            //}

                            //else if (bilcycle == "6")
                            //{
                            //    bilcycle = "C";
                            //    combin++;

                            //}


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking Date:-</b>");
                            string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));

                            tbl.Append("<td class='rep_data_new' colspan='10' >");
                            tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                           // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                           // tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                            tbl.Append("</tr>");
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                            tbl.Append("</tr>");
                    
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                            tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                            tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                            tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                            tbl.Append("</tr>");



                            rowcounter++;

                        }

                    }
                }
                else
                {
                    type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                  
                       // type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                      
                  
                    if (type != "7")
                    {
                        if (billflag == "bill")
                        {
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }
                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }

                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='2%'>";
                            //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            }
                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            }

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                            string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));

                            tbl.Append("<td class='rep_data_new' colspan='10' >");
                            tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                           // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                           // tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                            tbl.Append("</tr>");
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                            tbl.Append("</tr>");
                    
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                            tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                            tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                            tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                            tbl.Append("</tr>");



                            rowcounter++;

                        }


                        else
                        {
                            type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }
                            bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }


                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() == "")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='2%'>";
                                //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }
                                //if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }   //string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;

                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));
                        
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new' colspan='9' >");
                                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                                tbl.Append("</tr>");
                    
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                                tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;

                            }

                        }
                    }
                }
            }
               else
                {
                    if (dpd_branch == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                      {
                    if (bookdummy1 == "YDU")
                    {
                        if (billflag == "bill")
                        {
                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                            string type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='2%'>";
                            //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            }
                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            }
                            string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");


                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                            string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));

                            tbl.Append("<td class='rep_data_new' colspan='10' >");
                            tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");


                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                            tbl.Append("</tr>");
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='24' ><b>Edition :</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                            tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                            tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                            tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                            tbl.Append("</tr>");



                            rowcounter++;

                        }


                        else
                        {
                            string type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }
                            string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }


                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() == "")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='2%'>";
                                //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }
                                //if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }
                                //string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;

                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new' colspan='10' >");
                                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                // tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                                tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;

                            }

                        }
                    }
                    else
                    {
                        type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();

                        // type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();


                        if (type != "7")
                        {
                            if (billflag == "bill")
                            {
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }

                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='2%'>";
                                //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new' colspan='10' >");
                                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                // tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                                tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;

                            }


                            else
                            {
                                type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }


                                if (ds.Tables[0].Rows[p]["bill_no"].ToString() == "")
                                {
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='2%'>";
                                    //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                                    if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }


                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    }
                                    //if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                                    //{
                                    //    allbill++;
                                    //}

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }   //string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                    //if (bilcycle == "1")
                                    //{
                                    //    bilcycle = "D";
                                    //    single++;

                                    //}
                                    //else if (bilcycle == "2")
                                    //{
                                    //    bilcycle = "W";

                                    //}
                                    //else if (bilcycle == "3")
                                    //{
                                    //    bilcycle = "F";

                                    //}
                                    //else if (bilcycle == "4")
                                    //{
                                    //    bilcycle = "M";

                                    //}

                                    //else if (bilcycle == "6")
                                    //{
                                    //    bilcycle = "C";
                                    //    combin++;

                                    //}


                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");


                                    tbl.Append("</tr>");

                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking Date:-</b>");
                                    string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>"));

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                    if (type == "3")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                    }
                                    else if (type == "1")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                    }

                                    else if (type == "2")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                    }
                                    else if (type == "4")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (type == "5")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (type == "6")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (type == "7")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                    }
                                    tbl.Append((bookintype + "</td>"));

                                    tbl.Append("<td class='rep_data_new' colspan='9' >");
                                    tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                    //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                    //tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");


                                    tbl.Append("</tr>");
                                    tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");
                                    tbl.Append("</tr>");

                                    tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");



                                    tbl.Append("<td class='attreptline' colspan='2' ><b>Agency TD. :");
                                    tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                    tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td   class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                    tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                    tbl.Append("</tr>");



                                    rowcounter++;

                                }

                            }
                        }
                    }
                }
            }


            }


                // tbl.Append("<tr font-size='10' font-family='Arial'>";
                if (showothercentdata != "Y")
                {
                    if (ds.Tables[3].Rows.Count == 0)
                    {
                        totalad = ds.Tables[0].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());

                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='left' ><b>To be Billed :</b>");
                        tbl.Append((totalad - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>DIRECT CASH :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>SCHEME AdS:</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>COMBIN Ads :</b>");
                        tbl.Append(combin.ToString() + "</td>");
                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Dummy Ads :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>SINGLE Ads :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append(totalad.ToString() + "</td>");




                        tbl.Append("</tr>");
                    }
                }
            
            tbl.Append("</table></td><tr></table></p>");
           tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");

           report.InnerHtml = tbl.ToString();

//====****************** Case for Book from other Center *****************//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           
                if (showothercentdata == "Y")
                {
                   
                    sno1 = 0;
                    tbl.Length = 0;
                    rowcounter = 0;

                    reportname = "Attendence Register(Booked For Others)";
                    companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                    tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                  tbl.Append( "<tr><td>");
                    pgn = pgn + 1;
                 
                    tbl.Append(header());
                    tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
                    ////tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");
          
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");
         
                  tbl.Append("<tr>");


                    for (int p = 0; p < ds.Tables[2].Rows.Count; p++)
                    {

                        if (rowcounter == maxlimit)
                        {
                            rowcounter = 0;

                            tbl.Append("</table></td><tr></table></p>");
                           tbl.Append( "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                            tbl.Append("<tr><td>");
                            pgn = pgn + 1;
                          
                            tbl.Append(header());
                             tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                            tbl.Append("<tr>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");
          
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");
         
                            tbl.Append("<tr>");
                        }
                       if (branchbased == "NB")
                     {
                          if (bookdummy1 == "YDU")
                         {
                        if (billflag == "bill")
                        {
                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                            string type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                            // tbl.Append("<td class='rep_data_new' width='2%'>";
                            // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            } 
                            if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }
                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            } 
                            string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;
                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }



                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial'>");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                            string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));
                 

                            tbl.Append("<td class='rep_data_new' colspan='10' >");
                            tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                            //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                            //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                            tbl.Append("</tr>");
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");
                            tbl.Append("</tr>");
                    
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                            tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                            tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                            tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                            tbl.Append("</tr>");



                            rowcounter++;
                        }
                        else
                        {

                            if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }
                            string type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }


                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }
                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }
                            if (ds.Tables[2].Rows[p]["bill_no"].ToString() == "")
                            {

                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }  
                                //if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}
                                //tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }   //string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;
                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}



                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));
                 
                                tbl.Append("<td class='rep_data_new' colspan='10' >");
                                tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");
                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;

                            }
                        }
                          }
                        else
                          {
                              type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                
                              if(type != "7")
                              {
                                   if (billflag == "bill")
                              {

                                  if (type == "7")
                                  {
                                      bookdummy++;
                                  }
                                  bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                  if (bilcycle == "1")
                                  {
                                      bilcycle = "D";
                                      single++;
                                  }
                                  else if (bilcycle == "2")
                                  {
                                      bilcycle = "W";

                                  }
                                  else if (bilcycle == "3")
                                  {
                                      bilcycle = "F";

                                  }
                                  else if (bilcycle == "4")
                                  {
                                      bilcycle = "M";

                                  }

                                  else if (bilcycle == "6")
                                  {
                                      bilcycle = "C";
                                      combin++;

                                  }
                                  if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                  {
                                      allbill++;
                                  }
                  
                                       sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                          
                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                            tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                            // tbl.Append("<td class='rep_data_new' width='2%'>";
                            // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();

                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }
                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            }
                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial'>");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                            string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));
                 

                            tbl.Append("<td class='rep_data_new' colspan='10' >");
                            tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                           // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                            //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                            tbl.Append("</tr>");
                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");
                            tbl.Append("</tr>");

                            tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                            tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                            tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                            tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                            tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                            tbl.Append("</tr>");



                            rowcounter++;
                        }
                        else
                        {
                            if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }
                            type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                             bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }


                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }
                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }

                            if (ds.Tables[2].Rows[p]["bill_no"].ToString() == "")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }
                                //if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}
                                //tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                //string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;
                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}



                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));
                 
                                tbl.Append("<td class='rep_data_new' colspan='3' >");
                                tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:35px' >");


                                tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;

                            }
                        }
                              }
                             
                          }
                    }
                       else
                       {
                           if (dpd_branch == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                        {
                           if (bookdummy1 == "YDU")
                           {
                               if (billflag == "bill")
                               {
                                   sno1++;
                                   tbl.Append("<tr font-size='10' font-family='Arial'>");
                                   tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                   string type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                   if (type == "7")
                                   {
                                       bookdummy++;
                                   }
                                   tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                   tbl.Append("<td class='rep_data_new' width='8%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                   tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                   //tbl += "<td class='rep_data_new' width='5%'>";
                                   //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                   tbl.Append("<td class='rep_data_new' width='5%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                   tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                   tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                   //tbl += "<td class='rep_data_new' width='5%'>";
                                   //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                   tbl.Append("<td class='rep_data_new' width='5%'>");
                                   string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                   if (col.Substring(0, 1) == "B")
                                       col = "B / W";
                                   tbl.Append(col + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='5%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='5%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='8%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='5%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='5%'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                   // tbl.Append("<td class='rep_data_new' width='2%'>";
                                   // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                   tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                   string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                   string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                   if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                   {
                                       if (rateag == "0")
                                       {
                                           string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                           if (spdis != "0")
                                           {
                                               if (tran != "0")
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                               }
                                               else
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                               }

                                           }
                                           else
                                           {
                                               if (tran != "0")
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                               }
                                               else
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                               }

                                           }
                                       }
                                       else
                                       {
                                           if (tran != "0")
                                           {
                                               tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                           }
                                           else
                                           {
                                               tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                           }
                                       }
                                   }
                                   tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                   if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                       billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                   if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                   {

                                       tbl.Append(billamt.ToString("F2") + "</td>");
                                   }

                                   tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                   if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                   {
                                       tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                   }
                                   if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                   {
                                       allbill++;
                                   }
                                   tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                   if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                   {

                                       tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                   }
                                   string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                   if (bilcycle == "1")
                                   {
                                       bilcycle = "D";
                                       single++;
                                   }
                                   else if (bilcycle == "2")
                                   {
                                       bilcycle = "W";

                                   }
                                   else if (bilcycle == "3")
                                   {
                                       bilcycle = "F";

                                   }
                                   else if (bilcycle == "4")
                                   {
                                       bilcycle = "M";

                                   }

                                   else if (bilcycle == "6")
                                   {
                                       bilcycle = "C";
                                       combin++;

                                   }



                                   tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                   tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                   tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                                   tbl.Append("</tr>");

                                   tbl.Append("<tr font-size='10' font-family='Arial'>");

                                   tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                   string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                   if (datewise.IndexOf(' ') > -1)
                                   {
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

                                   }
                                   tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                                   tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                   if (type == "3")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                   }
                                   else if (type == "1")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                   }

                                   else if (type == "2")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                   }
                                   else if (type == "4")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                   }
                                   else if (type == "5")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                   }
                                   else if (type == "6")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                   }
                                   else if (type == "7")
                                   {
                                       bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                   }
                                   tbl.Append((bookintype + "</td>"));


                                   tbl.Append("<td class='rep_data_new' colspan='10' >");
                                   tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                   //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                   //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                   tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                   tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                   tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                                   tbl.Append("</tr>");
                                   tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                   tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");
                                   tbl.Append("</tr>");

                                   tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                   tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                                   tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                   tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                   tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                   tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                   tbl.Append("</tr>");



                                   rowcounter++;
                               }
                               else
                               {

                                   if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                   {
                                       allbill++;
                                   }
                                   string type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                   if (type == "7")
                                   {
                                       bookdummy++;
                                   }
                                   string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                   if (bilcycle == "1")
                                   {
                                       bilcycle = "D";
                                       single++;

                                   }


                                   else if (bilcycle == "2")
                                   {
                                       bilcycle = "W";

                                   }
                                   else if (bilcycle == "3")
                                   {
                                       bilcycle = "F";

                                   }
                                   else if (bilcycle == "4")
                                   {
                                       bilcycle = "M";

                                   }
                                   else if (bilcycle == "6")
                                   {
                                       bilcycle = "C";
                                       combin++;

                                   }
                                   if (ds.Tables[2].Rows[p]["bill_no"].ToString() == "")
                                   {

                                       sno1++;
                                       tbl.Append("<tr font-size='10' font-family='Arial'>");
                                       tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                       tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                       tbl.Append("<td class='rep_data_new' width='8%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                       //tbl += "<td class='rep_data_new' width='5%'>";
                                       //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                       tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                       tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                       //tbl += "<td class='rep_data_new' width='5%'>";
                                       //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                       if (col.Substring(0, 1) == "B")
                                           col = "B / W";
                                       tbl.Append(col + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='8%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                       // tbl.Append("<td class='rep_data_new' width='2%'>";
                                       // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                       string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {
                                           if (rateag == "0")
                                           {
                                               string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                               if (spdis != "0")
                                               {
                                                   if (tran != "0")
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                   }
                                                   else
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                   }

                                               }
                                               else
                                               {
                                                   if (tran != "0")
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                   }
                                                   else
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                   }

                                               }
                                           }
                                           else
                                           {
                                               if (tran != "0")
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                               }
                                               else
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                               }
                                           }
                                       }
                                       tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                       if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                           billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {

                                           tbl.Append(billamt.ToString("F2") + "</td>");
                                       }
                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {
                                           tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                       }
                                       //if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                       //{
                                       //    allbill++;
                                       //}
                                       //tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {

                                           tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                       }   //string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                       //if (bilcycle == "1")
                                       //{
                                       //    bilcycle = "D";
                                       //    single++;
                                       //}
                                       //else if (bilcycle == "2")
                                       //{
                                       //    bilcycle = "W";

                                       //}
                                       //else if (bilcycle == "3")
                                       //{
                                       //    bilcycle = "F";

                                       //}
                                       //else if (bilcycle == "4")
                                       //{
                                       //    bilcycle = "M";

                                       //}

                                       //else if (bilcycle == "6")
                                       //{
                                       //    bilcycle = "C";
                                       //    combin++;

                                       //}



                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                                       tbl.Append("</tr>");

                                       tbl.Append("<tr font-size='10' font-family='Arial'>");

                                       tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                       string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                       if (datewise.IndexOf(' ') > -1)
                                       {
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

                                       }
                                       tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                                       tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                       if (type == "3")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                       }
                                       else if (type == "1")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                       }

                                       else if (type == "2")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                       }
                                       else if (type == "4")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                       }
                                       else if (type == "5")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                       }
                                       else if (type == "6")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                       }
                                       else if (type == "7")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                       }
                                       tbl.Append((bookintype + "</td>"));

                                       tbl.Append("<td class='rep_data_new' colspan='10' >");
                                       tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                       //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                       //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                                       tbl.Append("</tr>");
                                       tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                       tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");
                                       tbl.Append("</tr>");
                                       tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                       tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                                       tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                       tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                       tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                       tbl.Append("</tr>");



                                       rowcounter++;

                                   }
                               }
                           }
                           else
                           {
                               type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();

                               if (type != "7")
                               {
                                   if (billflag == "bill")
                                   {

                                       if (type == "7")
                                       {
                                           bookdummy++;
                                       }
                                       bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                       if (bilcycle == "1")
                                       {
                                           bilcycle = "D";
                                           single++;
                                       }
                                       else if (bilcycle == "2")
                                       {
                                           bilcycle = "W";

                                       }
                                       else if (bilcycle == "3")
                                       {
                                           bilcycle = "F";

                                       }
                                       else if (bilcycle == "4")
                                       {
                                           bilcycle = "M";

                                       }

                                       else if (bilcycle == "6")
                                       {
                                           bilcycle = "C";
                                           combin++;

                                       }
                                       if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                       {
                                           allbill++;
                                       }

                                       sno1++;
                                       tbl.Append("<tr font-size='10' font-family='Arial'>");
                                       tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                       tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                       tbl.Append("<td class='rep_data_new' width='8%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                       //tbl += "<td class='rep_data_new' width='5%'>";
                                       //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                       tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                       tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                       //tbl += "<td class='rep_data_new' width='5%'>";
                                       //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                       if (col.Substring(0, 1) == "B")
                                           col = "B / W";
                                       tbl.Append(col + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='8%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                       // tbl.Append("<td class='rep_data_new' width='2%'>";
                                       // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                       string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();

                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {
                                           if (rateag == "0")
                                           {
                                               string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                               if (spdis != "0")
                                               {
                                                   if (tran != "0")
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                   }
                                                   else
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                   }

                                               }
                                               else
                                               {
                                                   if (tran != "0")
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                   }
                                                   else
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                   }

                                               }
                                           }
                                           else
                                           {
                                               if (tran != "0")
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                               }
                                               else
                                               {
                                                   tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                               }
                                           }
                                       }
                                       tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                       if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                           billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {

                                           tbl.Append(billamt.ToString("F2") + "</td>");
                                       }
                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {
                                           tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                       }
                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                       {

                                           tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                       }


                                       tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                       tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                       tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                                       tbl.Append("</tr>");

                                       tbl.Append("<tr font-size='10' font-family='Arial'>");

                                       tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                       string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                       if (datewise.IndexOf(' ') > -1)
                                       {
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

                                       }
                                       tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                                       tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                       if (type == "3")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                       }
                                       else if (type == "1")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                       }

                                       else if (type == "2")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                       }
                                       else if (type == "4")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                       }
                                       else if (type == "5")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                       }
                                       else if (type == "6")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                       }
                                       else if (type == "7")
                                       {
                                           bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                       }
                                       tbl.Append((bookintype + "</td>"));


                                       tbl.Append("<td class='rep_data_new' colspan='10' >");
                                       tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                       // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                       //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                       tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                                       tbl.Append("</tr>");
                                       tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                       tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");
                                       tbl.Append("</tr>");

                                       tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                       tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                                       tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                       tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                       tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                       tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                       tbl.Append("</tr>");



                                       rowcounter++;
                                   }
                                   else
                                   {
                                       if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                       {
                                           allbill++;
                                       }
                                       type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                       if (type == "7")
                                       {
                                           bookdummy++;
                                       }
                                       bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                       if (bilcycle == "1")
                                       {
                                           bilcycle = "D";
                                           single++;

                                       }


                                       else if (bilcycle == "2")
                                       {
                                           bilcycle = "W";

                                       }
                                       else if (bilcycle == "3")
                                       {
                                           bilcycle = "F";

                                       }
                                       else if (bilcycle == "4")
                                       {
                                           bilcycle = "M";

                                       }
                                       else if (bilcycle == "6")
                                       {
                                           bilcycle = "C";
                                           combin++;

                                       }

                                       if (ds.Tables[2].Rows[p]["bill_no"].ToString() == "")
                                       {
                                           sno1++;
                                           tbl.Append("<tr font-size='10' font-family='Arial'>");
                                           tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                           tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                           tbl.Append("<td class='rep_data_new' width='8%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                           tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                           //tbl += "<td class='rep_data_new' width='5%'>";
                                           //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                           tbl.Append("<td class='rep_data_new' width='5%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                           tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                           tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                           //tbl += "<td class='rep_data_new' width='5%'>";
                                           //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                           tbl.Append("<td class='rep_data_new' width='5%'>");
                                           string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                           if (col.Substring(0, 1) == "B")
                                               col = "B / W";
                                           tbl.Append(col + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='5%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='5%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='8%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='5%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='5%'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                           // tbl.Append("<td class='rep_data_new' width='2%'>";
                                           // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                           tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                           string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                           string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                           if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                           {
                                               if (rateag == "0")
                                               {
                                                   string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                                   if (spdis != "0")
                                                   {
                                                       if (tran != "0")
                                                       {
                                                           tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                       }
                                                       else
                                                       {
                                                           tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                       }

                                                   }
                                                   else
                                                   {
                                                       if (tran != "0")
                                                       {
                                                           tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                       }
                                                       else
                                                       {
                                                           tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                       }

                                                   }
                                               }
                                               else
                                               {
                                                   if (tran != "0")
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                   }
                                                   else
                                                   {
                                                       tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                                   }
                                               }
                                           }
                                           tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                           if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                               billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                           if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                           {

                                               tbl.Append(billamt.ToString("F2") + "</td>");
                                           }
                                           tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                           if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                           {
                                               tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                           }
                                           //if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                           //{
                                           //    allbill++;
                                           //}
                                           //tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                           //string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                           //if (bilcycle == "1")
                                           //{
                                           //    bilcycle = "D";
                                           //    single++;
                                           //}
                                           //else if (bilcycle == "2")
                                           //{
                                           //    bilcycle = "W";

                                           //}
                                           //else if (bilcycle == "3")
                                           //{
                                           //    bilcycle = "F";

                                           //}
                                           //else if (bilcycle == "4")
                                           //{
                                           //    bilcycle = "M";

                                           //}

                                           //else if (bilcycle == "6")
                                           //{
                                           //    bilcycle = "C";
                                           //    combin++;

                                           //}



                                           tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                           tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                           tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");


                                           tbl.Append("</tr>");

                                           tbl.Append("<tr font-size='10' font-family='Arial'>");

                                           tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                           string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                           if (datewise.IndexOf(' ') > -1)
                                           {
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

                                           }
                                           tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>"));
                                           tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='2' ><b>Booking type:-</b>");
                                           if (type == "3")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                           }
                                           else if (type == "1")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                           }

                                           else if (type == "2")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                           }
                                           else if (type == "4")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                           }
                                           else if (type == "5")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                           }
                                           else if (type == "6")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                           }
                                           else if (type == "7")
                                           {
                                               bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                           }
                                           tbl.Append((bookintype + "</td>"));

                                           tbl.Append("<td class='rep_data_new' colspan='3' >");
                                           tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                           tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                           tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                           tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>BILL NO:</b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                           tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>BILL DATE:</b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");

                                           tbl.Append("</tr>");

                                           tbl.Append("<tr font-size='10' font-family='Arial' style='height:35px' >");


                                           tbl.Append("<td  class='attreptline' colspan='2' ><b>Agency TD. :");
                                           tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                           tbl.Append("<td  class='attreptline' colspan='12' ><b>Remark :</b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                           tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                           tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                           tbl.Append("</tr>");



                                           rowcounter++;

                                       }
                                   }
                               }

                           }
                       }
                    }

                    }
                    if (ds.Tables[3].Rows.Count == 0)
                    {
                        totalad = ds.Tables[0].Rows.Count;
                        totadd2 = ds.Tables[2].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());


                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='center' ><b>To be Billed :</b>");
                        tbl.Append((totalad + totadd2 - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='4' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>DIRECT CASH :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>SCHEME AdS:</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>COMBIN Ads :</b>");
                        tbl.Append(combin.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Dummy Ads :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>DAILY Ads :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append((totalad + totadd2).ToString() + "</td>");


                       // tbl.Append("</table></td><tr></table></p>";
                    }
                    tbl.Append("</table></td><tr></table></p>");
                    tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");

                    report.InnerHtml = report.InnerHtml + tbl.ToString();

                }
              //====****************** Case for Book from editon Center *****************/////////////////////
///**************************************************************************************////////////////////////
///*************************************************************************************//////////////////////////


                if (ds.Tables[3].Rows.Count > 0)
                {


                    sno1 = 0;
                    tbl.Length = 0;
                    rowcounter = 0;
                    reportname = "Attendence Register(Edition Wise)";
                    companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                    tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                    tbl.Append("<tr><td>");
                    pgn = pgn + 1;

                    tbl.Append(header());
                    tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
                    ////tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";

                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");

                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");

                    tbl.Append("<tr>");


                    for (int p = 0; p < ds.Tables[3].Rows.Count; p++)
                    {

                        if (rowcounter == maxlimit)
                        {
                            rowcounter = 0;

                            tbl.Append("</table></td><tr></table></p>");
                            tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                            tbl.Append("<tr><td>");
                            pgn = pgn + 1;
                            tbl.Append(header());

                            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                            tbl.Append("<tr>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'  align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>");
                            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</td>";
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");

                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");

                            tbl.Append("<tr>");
                        }
                         if (branchbased == "NB")
                      {

                        if (bookdummy1 == "YDU")
                        {
                            if (billflag == "bill")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                string type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                } 
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }
                                string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;
                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }



                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");


                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));
                          
                                tbl.Append("<td class='rep_data_new' colspan='10' >");
                                tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                               // tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");
                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;
                            }
                            else
                            {
                                string type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }


                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() == "")
                                {
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                    // tbl.Append("<td class='rep_data_new' width='2%'>";
                                    // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    } 
                                    //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                    //{
                                    //    allbill++;
                                    //}
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }  //string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                    //if (bilcycle == "1")
                                    //{
                                    //    bilcycle = "D";
                                    //    single++;
                                    //}
                                    //else if (bilcycle == "2")
                                    //{
                                    //    bilcycle = "W";

                                    //}
                                    //else if (bilcycle == "3")
                                    //{
                                    //    bilcycle = "F";

                                    //}
                                    //else if (bilcycle == "4")
                                    //{
                                    //    bilcycle = "M";

                                    //}

                                    //else if (bilcycle == "6")
                                    //{
                                    //    bilcycle = "C";
                                    //    combin++;

                                    //}



                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");


                                    tbl.Append("</tr>");

                                    tbl.Append("<tr font-size='10' font-family='Arial'>");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                    string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append((datewise + "&nbsp;&nbsp;" + "<b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));
                          
                                    tbl.Append("<td class='rep_data_new' colspan='10' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                   // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                    //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                    tbl.Append("</tr>");
                                    tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");
                                    tbl.Append("</tr>");

                                    tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                    tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                    tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                    tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                    tbl.Append("</tr>");



                                    rowcounter++;
                                }
                            }
                        }
                        else
                        {
                            type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                          

                              if(type != "7")
                             {
                            
                      
                            if (billflag == "bill")
                            {
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;
                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }


                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                
                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                } 
                                //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }  //string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;
                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}



                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");


                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");

                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial'>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));
                          
                                tbl.Append("<td class='rep_data_new' colspan='10' >");
                                tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                               // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                tbl.Append("</tr>");
                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");
                                tbl.Append("</tr>");

                                tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;
                            }
                            else
                            {
                                 type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                 bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }


                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() == "")
                                {
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                    // tbl.Append("<td class='rep_data_new' width='2%'>";
                                    // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    } 
                                    //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                    //{
                                    //    allbill++;
                                    //}
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }//string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                    //if (bilcycle == "1")
                                    //{
                                    //    bilcycle = "D";
                                    //    single++;
                                    //}
                                    //else if (bilcycle == "2")
                                    //{
                                    //    bilcycle = "W";

                                    //}
                                    //else if (bilcycle == "3")
                                    //{
                                    //    bilcycle = "F";

                                    //}
                                    //else if (bilcycle == "4")
                                    //{
                                    //    bilcycle = "M";

                                    //}

                                    //else if (bilcycle == "6")
                                    //{
                                    //    bilcycle = "C";
                                    //    combin++;

                                    //}



                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");


                                    tbl.Append("</tr>");

                                    tbl.Append("<tr font-size='10' font-family='Arial'>");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                    string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));
                          
                                    tbl.Append("<td class='rep_data_new' colspan='10' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                    //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                   // tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                    tbl.Append("</tr>");

                                    tbl.Append("<tr font-size='10' font-family='Arial' style='height:35px' >");


                                    tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                    tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                    tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                    tbl.Append("</tr>");



                                    rowcounter++;
                                }
                            }
                        }
                        }
                    }
                         else
                         {
                             if (dpd_branch == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                        {
                             if (bookdummy1 == "YDU")
                             {
                                 if (billflag == "bill")
                                 {
                                     sno1++;
                                     tbl.Append("<tr font-size='10' font-family='Arial'>");
                                     tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                     string type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                     if (type == "7")
                                     {
                                         bookdummy++;
                                     }
                                     tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                     tbl.Append("<td class='rep_data_new' width='8%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                     tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                     //tbl += "<td class='rep_data_new' width='5%'>";
                                     //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                     tbl.Append("<td class='rep_data_new' width='5%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                     tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                     tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                     //tbl += "<td class='rep_data_new' width='5%'>";
                                     //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                     tbl.Append("<td class='rep_data_new' width='5%'>");
                                     string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                     if (col.Substring(0, 1) == "B")
                                         col = "B / W";
                                     tbl.Append(col + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='5%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='5%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='8%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='5%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='5%'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                     // tbl.Append("<td class='rep_data_new' width='2%'>";
                                     // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                     tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                     string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                     string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                     if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                     {
                                         if (rateag == "0")
                                         {
                                             string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                             if (spdis != "0")
                                             {
                                                 if (tran != "0")
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                 }
                                                 else
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                 }

                                             }
                                             else
                                             {
                                                 if (tran != "0")
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                 }
                                                 else
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                 }

                                             }
                                         }
                                         else
                                         {
                                             if (tran != "0")
                                             {
                                                 tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                             }
                                             else
                                             {
                                                 tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                             }
                                         }
                                     }
                                     tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                     if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                         billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                     if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                     {

                                         tbl.Append(billamt.ToString("F2") + "</td>");
                                     }
                                     tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                     if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                     {
                                         tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                     }
                                     if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                     {
                                         allbill++;
                                     }
                                     tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                     if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                     {

                                         tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                     }
                                     string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                     if (bilcycle == "1")
                                     {
                                         bilcycle = "D";
                                         single++;
                                     }
                                     else if (bilcycle == "2")
                                     {
                                         bilcycle = "W";

                                     }
                                     else if (bilcycle == "3")
                                     {
                                         bilcycle = "F";

                                     }
                                     else if (bilcycle == "4")
                                     {
                                         bilcycle = "M";

                                     }

                                     else if (bilcycle == "6")
                                     {
                                         bilcycle = "C";
                                         combin++;

                                     }



                                     tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                     tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                     tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");


                                     tbl.Append("</tr>");

                                     tbl.Append("<tr font-size='10' font-family='Arial'>");

                                     tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                     string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                     if (datewise.IndexOf(' ') > -1)
                                     {
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

                                     }
                                     tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));

                                     tbl.Append("<td class='rep_data_new' colspan='10' >");
                                     tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                     //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                     // tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                     tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                     tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                     tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                     tbl.Append("</tr>");
                                     tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                     tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");
                                     tbl.Append("</tr>");

                                     tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                     tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                     tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                     tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                     tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                     tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                     tbl.Append("</tr>");



                                     rowcounter++;
                                 }
                                 else
                                 {
                                     string type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                     if (type == "7")
                                     {
                                         bookdummy++;
                                     }
                                     if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                     {
                                         allbill++;
                                     }
                                     string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                     if (bilcycle == "1")
                                     {
                                         bilcycle = "D";
                                         single++;

                                     }


                                     else if (bilcycle == "2")
                                     {
                                         bilcycle = "W";

                                     }
                                     else if (bilcycle == "3")
                                     {
                                         bilcycle = "F";

                                     }
                                     else if (bilcycle == "4")
                                     {
                                         bilcycle = "M";

                                     }

                                     else if (bilcycle == "6")
                                     {
                                         bilcycle = "C";
                                         combin++;

                                     }
                                     if (ds.Tables[3].Rows[p]["bill_no"].ToString() == "")
                                     {
                                         sno1++;
                                         tbl.Append("<tr font-size='10' font-family='Arial'>");
                                         tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                         tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                         tbl.Append("<td class='rep_data_new' width='8%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                         //tbl += "<td class='rep_data_new' width='5%'>";
                                         //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                         tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                         tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                         //tbl += "<td class='rep_data_new' width='5%'>";
                                         //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                         if (col.Substring(0, 1) == "B")
                                             col = "B / W";
                                         tbl.Append(col + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='8%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                         // tbl.Append("<td class='rep_data_new' width='2%'>";
                                         // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                         string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {
                                             if (rateag == "0")
                                             {
                                                 string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                                 if (spdis != "0")
                                                 {
                                                     if (tran != "0")
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                     }
                                                     else
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                     }

                                                 }
                                                 else
                                                 {
                                                     if (tran != "0")
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                     }
                                                     else
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                     }

                                                 }
                                             }
                                             else
                                             {
                                                 if (tran != "0")
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                 }
                                                 else
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                                 }
                                             }
                                         }
                                         tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                         if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                             billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {

                                             tbl.Append(billamt.ToString("F2") + "</td>");
                                         }
                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {
                                             tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                         }
                                         //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                         //{
                                         //    allbill++;
                                         //}
                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {

                                             tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                         }  //string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                         //if (bilcycle == "1")
                                         //{
                                         //    bilcycle = "D";
                                         //    single++;
                                         //}
                                         //else if (bilcycle == "2")
                                         //{
                                         //    bilcycle = "W";

                                         //}
                                         //else if (bilcycle == "3")
                                         //{
                                         //    bilcycle = "F";

                                         //}
                                         //else if (bilcycle == "4")
                                         //{
                                         //    bilcycle = "M";

                                         //}

                                         //else if (bilcycle == "6")
                                         //{
                                         //    bilcycle = "C";
                                         //    combin++;

                                         //}



                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");


                                         tbl.Append("</tr>");

                                         tbl.Append("<tr font-size='10' font-family='Arial'>");

                                         tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                         string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                         if (datewise.IndexOf(' ') > -1)
                                         {
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

                                         }
                                         tbl.Append((datewise + "&nbsp;&nbsp;" + "<b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));

                                         tbl.Append("<td class='rep_data_new' colspan='10' >");
                                         tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                         // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                         //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                         tbl.Append("</tr>");
                                         tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                         tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");
                                         tbl.Append("</tr>");

                                         tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                         tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                         tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                         tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                         tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                         tbl.Append("</tr>");



                                         rowcounter++;
                                     }
                                 }
                             }
                             else
                             {
                                 type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();


                                 if (type != "7")
                                 {


                                     if (billflag == "bill")
                                     {
                                         if (type == "7")
                                         {
                                             bookdummy++;
                                         }
                                         bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                         if (bilcycle == "1")
                                         {
                                             bilcycle = "D";
                                             single++;
                                         }
                                         else if (bilcycle == "2")
                                         {
                                             bilcycle = "W";

                                         }
                                         else if (bilcycle == "3")
                                         {
                                             bilcycle = "F";

                                         }
                                         else if (bilcycle == "4")
                                         {
                                             bilcycle = "M";

                                         }

                                         else if (bilcycle == "6")
                                         {
                                             bilcycle = "C";
                                             combin++;

                                         }
                                         if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                         {
                                             allbill++;
                                         }


                                         sno1++;
                                         tbl.Append("<tr font-size='10' font-family='Arial'>");
                                         tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                         tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                         tbl.Append("<td class='rep_data_new' width='8%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                         //tbl += "<td class='rep_data_new' width='5%'>";
                                         //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                         tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                         tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                         //tbl += "<td class='rep_data_new' width='5%'>";
                                         //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                         if (col.Substring(0, 1) == "B")
                                             col = "B / W";
                                         tbl.Append(col + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='8%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                         // tbl.Append("<td class='rep_data_new' width='2%'>";
                                         // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                         string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {
                                             if (rateag == "0")
                                             {
                                                 string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                                 if (spdis != "0")
                                                 {
                                                     if (tran != "0")
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                     }
                                                     else
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                     }

                                                 }
                                                 else
                                                 {
                                                     if (tran != "0")
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                     }
                                                     else
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                     }

                                                 }
                                             }
                                             else
                                             {
                                                 if (tran != "0")
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                 }
                                                 else
                                                 {
                                                     tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                                 }
                                             }
                                         }
                                         tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                         if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                             billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {

                                             tbl.Append(billamt.ToString("F2") + "</td>");
                                         }
                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {
                                             tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                         }
                                         //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                         //{
                                         //    allbill++;
                                         //}
                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                         {

                                             tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                         }  //string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                         //if (bilcycle == "1")
                                         //{
                                         //    bilcycle = "D";
                                         //    single++;
                                         //}
                                         //else if (bilcycle == "2")
                                         //{
                                         //    bilcycle = "W";

                                         //}
                                         //else if (bilcycle == "3")
                                         //{
                                         //    bilcycle = "F";

                                         //}
                                         //else if (bilcycle == "4")
                                         //{
                                         //    bilcycle = "M";

                                         //}

                                         //else if (bilcycle == "6")
                                         //{
                                         //    bilcycle = "C";
                                         //    combin++;

                                         //}



                                         tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");


                                         tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                         tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");

                                         tbl.Append("</tr>");

                                         tbl.Append("<tr font-size='10' font-family='Arial'>");

                                         tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                         string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                         if (datewise.IndexOf(' ') > -1)
                                         {
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

                                         }
                                         tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));

                                         tbl.Append("<td class='rep_data_new' colspan='10' >");
                                         tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                         // tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                         //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                         tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                         tbl.Append("</tr>");
                                         tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");

                                         tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='23' ><b>Edition :</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");
                                         tbl.Append("</tr>");

                                         tbl.Append("<tr font-size='10' font-family='Arial' style='height:15px' >");


                                         tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                         tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                         tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                         tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                         tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                         tbl.Append("</tr>");



                                         rowcounter++;
                                     }
                                     else
                                     {
                                         type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                         if (type == "7")
                                         {
                                             bookdummy++;
                                         }
                                         if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                         {
                                             allbill++;
                                         }
                                         bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                         if (bilcycle == "1")
                                         {
                                             bilcycle = "D";
                                             single++;

                                         }


                                         else if (bilcycle == "2")
                                         {
                                             bilcycle = "W";

                                         }
                                         else if (bilcycle == "3")
                                         {
                                             bilcycle = "F";

                                         }
                                         else if (bilcycle == "4")
                                         {
                                             bilcycle = "M";

                                         }

                                         else if (bilcycle == "6")
                                         {
                                             bilcycle = "C";
                                             combin++;

                                         }
                                         if (ds.Tables[3].Rows[p]["bill_no"].ToString() == "")
                                         {
                                             sno1++;
                                             tbl.Append("<tr font-size='10' font-family='Arial'>");
                                             tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                             tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                             tbl.Append("<td class='rep_data_new' width='8%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                             tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                             //tbl += "<td class='rep_data_new' width='5%'>";
                                             //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                             tbl.Append("<td class='rep_data_new' width='5%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                             tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                             tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                             //tbl += "<td class='rep_data_new' width='5%'>";
                                             //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                             tbl.Append("<td class='rep_data_new' width='5%'>");
                                             string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                             if (col.Substring(0, 1) == "B")
                                                 col = "B / W";
                                             tbl.Append(col + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='5%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='5%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='8%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='5%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='5%'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                             // tbl.Append("<td class='rep_data_new' width='2%'>";
                                             // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                             tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                             string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                             string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                             if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                             {
                                                 if (rateag == "0")
                                                 {
                                                     string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                                     if (spdis != "0")
                                                     {
                                                         if (tran != "0")
                                                         {
                                                             tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                         }
                                                         else
                                                         {
                                                             tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                         }

                                                     }
                                                     else
                                                     {
                                                         if (tran != "0")
                                                         {
                                                             tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                         }
                                                         else
                                                         {
                                                             tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                         }

                                                     }
                                                 }
                                                 else
                                                 {
                                                     if (tran != "0")
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                     }
                                                     else
                                                     {
                                                         tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                                     }
                                                 }
                                             }
                                             tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                             if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                                 billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                             if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                             {

                                                 tbl.Append(billamt.ToString("F2") + "</td>");
                                             }
                                             tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                             if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                             {
                                                 tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                             }
                                             //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                             //{
                                             //    allbill++;
                                             //}
                                             tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                             if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                             {

                                                 tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                             }//string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                             //if (bilcycle == "1")
                                             //{
                                             //    bilcycle = "D";
                                             //    single++;
                                             //}
                                             //else if (bilcycle == "2")
                                             //{
                                             //    bilcycle = "W";

                                             //}
                                             //else if (bilcycle == "3")
                                             //{
                                             //    bilcycle = "F";

                                             //}
                                             //else if (bilcycle == "4")
                                             //{
                                             //    bilcycle = "M";

                                             //}

                                             //else if (bilcycle == "6")
                                             //{
                                             //    bilcycle = "C";
                                             //    combin++;

                                             //}



                                             tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");

                                             tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                             tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");


                                             tbl.Append("</tr>");

                                             tbl.Append("<tr font-size='10' font-family='Arial'>");

                                             tbl.Append("<td style='font-size:11px;vertical-align:top;' colspan='3' ><b>Booking Date:-</b>");
                                             string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                             if (datewise.IndexOf(' ') > -1)
                                             {
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

                                             }
                                             tbl.Append((datewise + "&nbsp;&nbsp;" + " <b>Publish date:-</b>" + ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>"));

                                             tbl.Append("<td class='rep_data_new' colspan='10' >");
                                             tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                             //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='9' ><b>Edition :</b>");
                                             // tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                             tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='2' ><b>RO NO:</b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                             tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL NO:</b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                             tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='3' ><b>BILL DATE:</b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");

                                             tbl.Append("</tr>");

                                             tbl.Append("<tr font-size='10' font-family='Arial' style='height:35px' >");


                                             tbl.Append("<td class='attreptline'  colspan='2' ><b>Agency TD. :");
                                             tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</b></td>");

                                             tbl.Append("<td class='attreptline' colspan='12' ><b>Remark :</b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                             tbl.Append("<td class='attreptline' colspan='7' ><b>Executive/Retainer:</b>");
                                             tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "/" + ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");

                                             tbl.Append("</tr>");



                                             rowcounter++;
                                         }
                                     }
                                 }
                             }
                         }
                         }

                    }
                    if (showothercentdata == "Y")
                    {
                        totalad = ds.Tables[0].Rows.Count;
                        totadd2 = ds.Tables[2].Rows.Count;
                        totadd3 = ds.Tables[3].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());


                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='center' ><b>To be Billed :</b>");
                        tbl.Append((totalad + totadd2 + totadd3 - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='4' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Direct Cash :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>Scheme :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Combin :</b>");
                        tbl.Append(combin.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Book for Dummy :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Single :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append((totalad + totadd2 + totadd3).ToString() + "</td>");


                        tbl.Append("</table></td><tr></table></p>");
                    }
                    else
                    {
                        totalad = ds.Tables[0].Rows.Count;

                        totadd3 = ds.Tables[3].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());


                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='center' ><b>To be Billed :</b>");
                        tbl.Append((totalad + totadd3 - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='4' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Direct Cash :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>Scheme :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Combin :</b>");
                        tbl.Append(combin.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Book for Dummy :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Single :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append((totalad + totadd3).ToString() + "</td>");


                        tbl.Append("</table></td><tr></table></p>");


                    }

                    report.InnerHtml = report.InnerHtml + tbl.ToString();



                }
        }

        else
        {
            btnPrint.Visible = false;

                hdnname.Value = reportname + "," + companyname + "," + fdate + "," + tdate + "," + rundate + "," + adtype_nam + "," + publication_nam + "," + pubcent_nam + "," + adcat_nam + "," + edition_nam;
            hdnxml.Value = dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "," + dsxml.Tables[0].Rows[0].ItemArray[25].ToString();
            string script = @"  if(confirm('Click OK or Cancel to Continue')) { 
var names=document.getElementById('hdnname').value.split(',');
var head=document.getElementById('hdnxml').value.split(',');
 var hdrtbl = '';
      hdrtbl = '<table width=100% border=0 cellpadding=0px cellspacing=0px>';
        hdrtbl += '<tr class=headingc><td colspan=6 style=text-align:center>'+names[1]+'</td></tr>';
        hdrtbl += '<tr class=headingc><td colspan=6 style=text-align:center>'+names[0]+'</td></tr>';
        hdrtbl += '<tr class=middle33><td colspan=2 style=text-align:left><b>From Date :</b>' + names[2] + '</td><td colspan=2 style=text-align:left><b>ToDate :</b>' + names[3] + '</td><td colspan=2 style=text-align:right><b>Run Date :</b>' + names[4] + '</td></tr>';
        hdrtbl += '<tr class=middle33><td colspan=2 style=text-align:left><b>AdType :</b>' + names[5] + '</td><td colspan=2 style=text-align:left><b>Publication :</b>' + names[6] + '</td><td colspan=2 style=text-align:right><b>Publication Center :</b>' + names[7] + '</td></tr>';
        hdrtbl += '<tr class=middle33><td colspan=2 style=text-align:left><b>Ad Category :</b>' + names[8] + '</td><td colspan=2 style=text-align:left><b>Edition :</b>' + names[9] + '</td><td colspan=2 style=text-align:right>' + '' + '</td></tr>';
        hdrtbl += '</table><table width=100% border=0 cellpadding=0px cellspacing=0px>';
         hdrtbl += '<tr>';
            hdrtbl += '<td  class=middle31new>'+head[0]+'</td>';
            hdrtbl += '<td  class=middle31new>' + head[1] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[2] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[3] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[4] + '</td>';
           
            hdrtbl += '<td  class=middle31new>' + head[6] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[8] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[9] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[10] + '</td>';
            
            hdrtbl += '<td  class=middle31new>' + head[12] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[13] + '</td>';
           
            hdrtbl += '<td  class=middle31new>' + head[15] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[13] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[15] + '</td>';
            hdrtbl += '<td  class=middle31new>' + head[16] + '</td>';
           

            hdrtbl += '<td  class=middle31new align=right>' + head[17] + '</td>';
            hdrtbl += '<td  class=middle31new align=right>' + head[7] +'</td>';
            hdrtbl += '<td  class=middle31new align=right>' + head[19] + '</td>';
            hdrtbl += '<td  class=middle31new align=right>' + head[20] + '</td>';
            hdrtbl += '<td  class=middle31new align=right>' + head[21] + '</td>';
          
            hdrtbl += '<td  class=middle31new align=right>' + head[22] + '</td>';
            hdrtbl += '<td  class=middle31new align=right>' + head[25] + '</td>';
            
            hdrtbl += '<td  class=middle31new align=right>' + head[23] + '</td>';
            hdrtbl += '<td  class=middle31new align=right>' + head[24] + '</td>';
         
            hdrtbl += '<tr>';

            
        hdrtbl += '</table>';
       
              document.getElementById('report').innerHTML = hdrtbl;
                                  
                                } 
                                else { 
                                    window.close();

                                }";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "confirm_entry", script, true);







            //ScriptManager.RegisterClientScriptBlock(this, typeof(representative_ledger), "sa", "conformation2('" + companyname + "','" + reportname + "','" + fdate + "','" + tdate + "','" + rundate + "','" + adtype_nam + "','" + pubcent_nam + "','" + adcat_nam + "','" + edition_nam + "')", true);
            //Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }
    }

  
    private string header()
    {
        string hdrtbl = "";
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
      //  hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>User Name  :" + username + "</b></td><td colspan='2' style='text-align:left'></td><td colspan='2' style='text-align:right'></td></tr>"; 
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + reportname + "</td></tr>";
        hdrtbl += "<tr ><td colspan='3' style='text-align:left' class='middle33'><b>User Name  :" + username + "</b></td><td colspan='2' class='headingc' style='text-align:left'>&nbsp;</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='2' style='text-align:right'><b>Run Date :</b>" + rundate + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='2' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Ad Category :</b>" + adcat_nam + "</td><td colspan='2' style='text-align:left'><b>Branch Name :</b>" + branch_name + "</td><td colspan='2' style='text-align:right'><b>Page No." + pgn + "</b></td></tr>"; 
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
        hdrtbl += "<tr class='middle33'><td colspan='6' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='6' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='6' style='text-align:right'><b>Run Date :</b>" + rundate + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='6' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='6' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='6' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='6' style='text-align:left'><b>Ad Category :</b>" + adcat_nam + "</td><td colspan='6' style='text-align:left'><b>Branch Name :</b>" + branch_name + "</td><td colspan='6' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    public void gridbind_excel()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            // ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode);
        }

        else
        {
            string procedureName = "schedulereport_checklist";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/AttendenceRegister.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int totadd2 = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        int schad = 0;
        int directcash = 0;
        int totadd3 = 0;
            int bookdummy = 0;
        string bookintype = "";
      
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        
        //====****************** Case for Book from other Center *****************//
        if (drpbookfrom == "Y" && dppubcent != "0" && dppubcent != "" && (ds.Tables[2].Rows.Count > 0))
        {
            showothercentdata = "Y";
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
           // string tbl = "";
            double billamt = 0;
            companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                   StringBuilder tbl = new StringBuilder();
      
           tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append( "<tr><td>");
            tbl.Append(header_excel());
            tbl.Append("<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>");
            
            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</b></td>");
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></td>");
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</b></td>");
            //tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");
          
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");

            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[26].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[27].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[28].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[30].ToString() + "</b></td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[33].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[34].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[36].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[37].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");

            tbl.Append("<tr>");
             

            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

               
                if (bookdummy1 == "YDU")
                {
                    if (billflag == "bill")
                    {
                        sno1++;
                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                        tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                        string type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                        if (type == "7")
                        {
                            bookdummy++;
                        }
                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data_new' width='8%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                        //tbl += "<td class='rep_data_new' width='5%'>";
                        //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                        //tbl += "<td class='rep_data_new' width='5%'>";
                        //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                        if (col.Substring(0, 1) == "B")
                            col = "B / W";
                        tbl.Append(col + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='8%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'>");
                        tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                        //tbl += "<td class='rep_data_new' width='2%'>";
                        //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                        string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {
                            if (rateag == "0")
                            {
                                string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                if (spdis != "0")
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                    }

                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                    }

                                }
                            }
                            else
                            {
                                if (tran != "0")
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                }
                                else
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                }
                            }
                        }
                        tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                        if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                            billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {
                            tbl.Append(billamt.ToString("F2") + "</td>");
                        }


                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {
                            tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                        }
                        if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                        {
                            allbill++;
                        }

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                        {

                            tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                        }
                        string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                        if (bilcycle == "1")
                        {
                            bilcycle = "D";
                            single++;

                        }
                        else if (bilcycle == "2")
                        {
                            bilcycle = "W";

                        }
                        else if (bilcycle == "3")
                        {
                            bilcycle = "F";

                        }
                        else if (bilcycle == "4")
                        {
                            bilcycle = "M";

                        }

                        else if (bilcycle == "6")
                        {
                            bilcycle = "C";
                            combin++;

                        }


                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");




                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                        if (datewise.IndexOf(' ') > -1)
                        {
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

                        }
                        tbl.Append(datewise + "</td>");

                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                        if (type == "3")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                        }
                        else if (type == "1")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                        }

                        else if (type == "2")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                        }
                        else if (type == "4")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                        }
                        else if (type == "5")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                        }
                        else if (type == "6")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                        }
                        else if (type == "7")
                        {
                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                        }
                        tbl.Append((bookintype + "</td>"));

                        tbl.Append("<td class='rep_data_new'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                        //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                        //tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                        tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                        tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                        tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                        tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");



                        tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                        tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");



                        tbl.Append("<td class='rep_data_new' >");
                        tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                        tbl.Append("<td class='rep_data_new'>");
                        tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                        tbl.Append("<td   class='rep_data_new' >");
                        tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                        tbl.Append("<td class='rep_data_new'>");
                        tbl.Append(ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                        tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                        tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");

                        tbl.Append("</tr>");





                        rowcounter++;

                    }


                    else
                    {
                        string type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                        if (type == "7")
                        {
                            bookdummy++;
                        }
                        if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                        {
                            allbill++;
                        }
                        string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                        if (bilcycle == "1")
                        {
                            bilcycle = "D";
                            single++;

                        }
                        else if (bilcycle == "2")
                        {
                            bilcycle = "W";

                        }
                        else if (bilcycle == "3")
                        {
                            bilcycle = "F";

                        }
                        else if (bilcycle == "4")
                        {
                            bilcycle = "M";

                        }

                        else if (bilcycle == "6")
                        {
                            bilcycle = "C";
                            combin++;

                        }


                        if (ds.Tables[0].Rows[p]["bill_no"].ToString() == "")
                        {
                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='2%'>";
                            //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            }
                            //if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            //{
                            //    allbill++;
                            //}

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            }
                            //string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            //if (bilcycle == "1")
                            //{
                            //    bilcycle = "D";
                            //    single++;

                            //}
                            //else if (bilcycle == "2")
                            //{
                            //    bilcycle = "W";

                            //}
                            //else if (bilcycle == "3")
                            //{
                            //    bilcycle = "F";

                            //}
                            //else if (bilcycle == "4")
                            //{
                            //    bilcycle = "M";

                            //}

                            //else if (bilcycle == "6")
                            //{
                            //    bilcycle = "C";
                            //    combin++;

                            //}


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");



                            tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                            string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append(datewise + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));

                            tbl.Append("<td class='rep_data_new'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                            //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                            //tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");



                            tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");



                            tbl.Append("<td class='rep_data_new' >");
                            tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                            tbl.Append("<td class='rep_data_new'>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td   class='rep_data_new' >");
                            tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                            tbl.Append("<td class='rep_data_new'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");

                            tbl.Append("</tr>");




                            rowcounter++;

                        }

                    }
                }
                else
                {
                    type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();

                    // type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                   
                    if (type != "7")
                    {
                        if (billflag == "bill")
                        {
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }
                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }


                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                            tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='5%'>";
                            //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                            if (col.Substring(0, 1) == "B")
                                col = "B / W";
                            tbl.Append(col + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='8%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'>");
                            tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                            //tbl += "<td class='rep_data_new' width='2%'>";
                            //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                            string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                if (rateag == "0")
                                {
                                    string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                    if (spdis != "0")
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                        }

                                    }
                                }
                                else
                                {
                                    if (tran != "0")
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                    }
                                    else
                                    {
                                        tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                    }
                                }
                            }
                            tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                            if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(billamt.ToString("F2") + "</td>");
                            }


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {
                                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                            }
                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                            {

                                tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                            }

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");



                            tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                            string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                            if (datewise.IndexOf(' ') > -1)
                            {
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

                            }
                            tbl.Append(datewise + "</td>");

                            tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                            if (type == "3")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                            }
                            else if (type == "1")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                            }

                            else if (type == "2")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                            }
                            else if (type == "4")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                            }
                            else if (type == "5")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                            }
                            else if (type == "6")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                            }
                            else if (type == "7")
                            {
                                bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                            }
                            tbl.Append((bookintype + "</td>"));

                            tbl.Append("<td class='rep_data_new'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                            //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                            //tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");



                            tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                            tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");



                            tbl.Append("<td class='rep_data_new' >");
                            tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                            tbl.Append("<td class='rep_data_new'>");
                            tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                            tbl.Append("<td   class='rep_data_new' >");
                            tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                            tbl.Append("<td class='rep_data_new'>");
                            tbl.Append(ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                            tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                            tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");

                            tbl.Append("</tr>");




                            rowcounter++;

                        }


                        else
                        {
                            type = ds.Tables[0].Rows[p]["BOOKING_TYPE"].ToString();
                            if (type == "7")
                            {
                                bookdummy++;
                            }
                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                            {
                                allbill++;
                            }
                            bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                            if (bilcycle == "1")
                            {
                                bilcycle = "D";
                                single++;

                            }
                            else if (bilcycle == "2")
                            {
                                bilcycle = "W";

                            }
                            else if (bilcycle == "3")
                            {
                                bilcycle = "F";

                            }
                            else if (bilcycle == "4")
                            {
                                bilcycle = "M";

                            }

                            else if (bilcycle == "6")
                            {
                                bilcycle = "C";
                                combin++;

                            }


                            if (ds.Tables[0].Rows[p]["bill_no"].ToString() == "")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='4%'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%'style='font-family:Verdana;'   align='right'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[0].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[0].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[0].Rows[p]["Key_no"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='2%'>";
                                //tbl += ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[0].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[0].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[0].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[0].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[0].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[0].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }
                                //if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["RATE_CODE"].ToString() + "</td>");


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[0].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[0].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }   //string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;

                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}


                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[0].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");





                                tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                string datewise = ds.Tables[0].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append(datewise + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PUBDT"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                                tbl.Append(ds.Tables[0].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");



                                tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                                tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</td>");



                                tbl.Append("<td class='rep_data_new' >");
                                tbl.Append(ds.Tables[0].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                tbl.Append("<td class='rep_data_new'>");
                                tbl.Append(ds.Tables[0].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='rep_data_new' >");
                                tbl.Append(ds.Tables[0].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='rep_data_new'>");
                                tbl.Append(ds.Tables[0].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[0].Rows[p]["PAGENO"].ToString() + "</td>");

                                tbl.Append("</tr>");


                                rowcounter++;

                            }

                        }
                    }
                }


            }


            // tbl.Append("<tr font-size='10' font-family='Arial'>";
            if (showothercentdata != "Y")
            {
                if (ds.Tables[3].Rows.Count == 0)
                {
                    totalad = ds.Tables[0].Rows.Count;
                    alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                    nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                    schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                    directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());

                    tbl.Append("<tr><td   class='middle31new' colspan='2' align='left' ><b>To be Billed :</b>");
                    tbl.Append((totalad - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                    tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>Booked by Others :</b>");
                    tbl.Append(nottobill.ToString() + "</td>");

                    tbl.Append("<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>");
                    tbl.Append(allbill.ToString() + "</td>");


                    tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>DIRECT CASH :</b>");
                    tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                    tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>SCHEME AdS:</b>");
                    tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                    tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>COMBIN Ads :</b>");
                    tbl.Append(combin.ToString() + "</td>");
                    tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Dummy Ads :</b>");
                    tbl.Append(bookdummy.ToString() + "</td>");

                    tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>SINGLE Ads :</b>");
                    tbl.Append(single.ToString() + "</td>");

                    tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                    tbl.Append(totalad.ToString() + "</td>");




                    tbl.Append("</tr>");
                }
            }

            tbl.Append("</table></td><tr></table></p>");
          
   
            report.InnerHtml = tbl.ToString();

//====****************** Case for Book from other Center *****************//
              if (showothercentdata == "Y")
                {
                    sno1 = 0;
                    tbl.Length = 0;
                    rowcounter = 0;
                    reportname = "Attendence Register(Booked For Others)";
                    companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                      tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>");
                    tbl.Append( "<tr><td>");
                    tbl.Append(header_excel());
                    tbl.Append("<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>");

                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'  colspan='1'><b>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</b></td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></td>");
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</b></td>");
                   // tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");
          
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");

                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[26].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[27].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[28].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[30].ToString() + "</b></td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");

                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[33].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[34].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[36].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[37].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");

               
                  tbl.Append("</tr>");


                    for (int p = 0; p < ds.Tables[2].Rows.Count; p++)
                    {

                        if (bookdummy1 == "YDU")
                        {
                            if (billflag == "bill")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                string type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                }
                                if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }
                                string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;
                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }



                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");



                                tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append(datewise + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                                tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");



                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");



                                tbl.Append("<td class='rep_data_new' >");
                                tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                tbl.Append("<td class='rep_data_new'>");
                                tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='rep_data_new' >");
                                tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='rep_data_new'>");
                                tbl.Append(ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");

                                tbl.Append("</tr>");






                                rowcounter++;
                            }
                            else
                            {
                                if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                string type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }


                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                if (ds.Tables[2].Rows[p]["bill_no"].ToString() == "")
                                {
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                    // tbl.Append("<td class='rep_data_new' width='2%'>";
                                    // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    }
                                    //if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                    //{
                                    //    allbill++;
                                    //}
                                    //tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }   //string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                    //if (bilcycle == "1")
                                    //{
                                    //    bilcycle = "D";
                                    //    single++;
                                    //}
                                    //else if (bilcycle == "2")
                                    //{
                                    //    bilcycle = "W";

                                    //}
                                    //else if (bilcycle == "3")
                                    //{
                                    //    bilcycle = "F";

                                    //}
                                    //else if (bilcycle == "4")
                                    //{
                                    //    bilcycle = "M";

                                    //}

                                    //else if (bilcycle == "6")
                                    //{
                                    //    bilcycle = "C";
                                    //    combin++;

                                    //}



                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");




                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                    string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append(datewise + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    if (type == "3")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                    }
                                    else if (type == "1")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                    }

                                    else if (type == "2")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                    }
                                    else if (type == "4")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (type == "5")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (type == "6")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (type == "7")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                    }
                                    tbl.Append((bookintype + "</td>"));

                                    tbl.Append("<td class='rep_data_new'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                    //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                    //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                    tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");



                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");



                                    tbl.Append("<td class='rep_data_new' >");
                                    tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                    tbl.Append("<td class='rep_data_new'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td   class='rep_data_new' >");
                                    tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='rep_data_new'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");

                                    tbl.Append("</tr>");



                                    rowcounter++;

                                }
                            }
                        }
                        else
                        {
                            type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                          

                            if (type != "7")
                            {
                                if (billflag == "bill")
                                {
                                    if (type == "7")
                                    {
                                        bookdummy++;
                                    }
                                    bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                    if (bilcycle == "1")
                                    {
                                        bilcycle = "D";
                                        single++;
                                    }
                                    else if (bilcycle == "2")
                                    {
                                        bilcycle = "W";

                                    }
                                    else if (bilcycle == "3")
                                    {
                                        bilcycle = "F";

                                    }
                                    else if (bilcycle == "4")
                                    {
                                        bilcycle = "M";

                                    }

                                    else if (bilcycle == "6")
                                    {
                                        bilcycle = "C";
                                        combin++;

                                    }
                                    if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                    {
                                        allbill++;
                                    }
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                    // tbl.Append("<td class='rep_data_new' width='2%'>";
                                    // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();

                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }


                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");


                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                    string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append(datewise + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    if (type == "3")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                    }
                                    else if (type == "1")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                    }

                                    else if (type == "2")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                    }
                                    else if (type == "4")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (type == "5")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (type == "6")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (type == "7")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                    }
                                    tbl.Append((bookintype + "</td>"));

                                    tbl.Append("<td class='rep_data_new'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                    //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                    //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                    tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                                    tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");



                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");



                                    tbl.Append("<td class='rep_data_new' >");
                                    tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                    tbl.Append("<td class='rep_data_new'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td   class='rep_data_new' >");
                                    tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='rep_data_new'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");

                                    tbl.Append("</tr>");



                                    rowcounter++;
                                }
                                else
                                {
                                    if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                    {
                                        allbill++;
                                    }
                                    type = ds.Tables[2].Rows[p]["BOOKING_TYPE"].ToString();
                                    if (type == "7")
                                    {
                                        bookdummy++;
                                    }
                                    bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                    if (bilcycle == "1")
                                    {
                                        bilcycle = "D";
                                        single++;

                                    }


                                    else if (bilcycle == "2")
                                    {
                                        bilcycle = "W";

                                    }
                                    else if (bilcycle == "3")
                                    {
                                        bilcycle = "F";

                                    }
                                    else if (bilcycle == "4")
                                    {
                                        bilcycle = "M";

                                    }
                                    else if (bilcycle == "6")
                                    {
                                        bilcycle = "C";
                                        combin++;

                                    }

                                    if (ds.Tables[2].Rows[p]["bill_no"].ToString() == "")
                                    {
                                        sno1++;
                                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                                        tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                        tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");

                                        tbl.Append("<td class='rep_data_new' width='8%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                        tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                                        //tbl += "<td class='rep_data_new' width='5%'>";
                                        //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                        tbl.Append("<td class='rep_data_new' width='5%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["INS_DATE"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</b></td>");

                                        tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</b></td>");

                                        tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Area"].ToString() + "</td>");

                                        //tbl += "<td class='rep_data_new' width='5%'>";
                                        //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                        tbl.Append("<td class='rep_data_new' width='5%'>");
                                        string col = ds.Tables[2].Rows[p]["Hue"].ToString();
                                        if (col.Substring(0, 1) == "B")
                                            col = "B / W";
                                        tbl.Append(col + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["PagePremium"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["PosPremium"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='8%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[2].Rows[p]["AdSubcat"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Caption"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["Key_no"].ToString() + "</td>");

                                        // tbl.Append("<td class='rep_data_new' width='2%'>";
                                        // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["cardrate"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        string rateag = ds.Tables[2].Rows[p]["agreedrate"].ToString();
                                        string tran = ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString();
                                        if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                        {
                                            if (rateag == "0")
                                            {
                                                string spdis = ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                                if (spdis != "0")
                                                {
                                                    if (tran != "0")
                                                    {
                                                        tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                    }
                                                    else
                                                    {
                                                        tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                    }

                                                }
                                                else
                                                {
                                                    if (tran != "0")
                                                    {
                                                        tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                    }
                                                    else
                                                    {
                                                        tbl.Append(ds.Tables[2].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                    }

                                                }
                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[2].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[2].Rows[p]["agreedrate"].ToString() + "</td>");

                                                }
                                            }
                                        }
                                        tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                        if (ds.Tables[2].Rows[p]["BILL_AMT"].ToString() != "")
                                            billamt = Convert.ToDouble(ds.Tables[2].Rows[p]["BILL_AMT"].ToString());
                                        if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                        {

                                            tbl.Append(billamt.ToString("F2") + "</td>");
                                        }
                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        if (branchtype == ds.Tables[2].Rows[p]["BRANCH"].ToString())
                                        {
                                            tbl.Append(ds.Tables[2].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                        }
                                        //if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                                        //{
                                        //    allbill++;
                                        //}
                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                        //string bilcycle = ds.Tables[2].Rows[p]["Bill_cycle"].ToString();
                                        //if (bilcycle == "1")
                                        //{
                                        //    bilcycle = "D";
                                        //    single++;
                                        //}
                                        //else if (bilcycle == "2")
                                        //{
                                        //    bilcycle = "W";

                                        //}
                                        //else if (bilcycle == "3")
                                        //{
                                        //    bilcycle = "F";

                                        //}
                                        //else if (bilcycle == "4")
                                        //{
                                        //    bilcycle = "M";

                                        //}

                                        //else if (bilcycle == "6")
                                        //{
                                        //    bilcycle = "C";
                                        //    combin++;

                                        //}



                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");




                                        tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                        string datewise = ds.Tables[2].Rows[p]["BkDATE"].ToString();
                                        if (datewise.IndexOf(' ') > -1)
                                        {
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

                                        }
                                        tbl.Append(datewise + "</td>");

                                        tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["PUBDT"].ToString() + "</td>");

                                        tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                        if (type == "3")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                        }
                                        else if (type == "1")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                        }

                                        else if (type == "2")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                        }
                                        else if (type == "4")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                        }
                                        else if (type == "5")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                        }
                                        else if (type == "6")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                        }
                                        else if (type == "7")
                                        {
                                            bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                        }
                                        tbl.Append((bookintype + "</td>"));

                                        tbl.Append("<td class='rep_data_new'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                        //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                        //tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");

                                        tbl.Append("<td style='font-size:13px;vertical-align:top;'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["RO_NO"].ToString() + "</td>");

                                        tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                        tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                                        tbl.Append("<td style='font-size:13px;vertical-align:top;'><b>");
                                        tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");



                                        tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</td>");



                                        tbl.Append("<td class='rep_data_new' >");
                                        tbl.Append(ds.Tables[2].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                        tbl.Append("<td class='rep_data_new'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                        tbl.Append("<td   class='rep_data_new' >");
                                        tbl.Append(ds.Tables[2].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                        tbl.Append("<td class='rep_data_new'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                        tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                        tbl.Append(ds.Tables[2].Rows[p]["PAGENO"].ToString() + "</td>");

                                        tbl.Append("</tr>");



                                        rowcounter++;

                                    }
                                }
                            }

                        }

                    }
                    if (ds.Tables[3].Rows.Count == 0)
                    {
                        totalad = ds.Tables[0].Rows.Count;
                        totadd2 = ds.Tables[2].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());


                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='center' ><b>To be Billed :</b>");
                        tbl.Append((totalad + totadd2 - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='4' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>DIRECT CASH :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>SCHEME AdS:</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>COMBIN Ads :</b>");
                        tbl.Append(combin.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Dummy Ads :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>DAILY Ads :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append((totalad + totadd2).ToString() + "</td>");


                      }
                   
               
                }
              tbl.Append("</table></td><tr></table></p>");
                 
              report.InnerHtml = report.InnerHtml + tbl.ToString();

             
            //////////////////////////////editon wise////////////
              if (ds.Tables[3].Rows.Count > 0)
              {
                  sno1 = 0;
                  tbl.Length = 0;
                  rowcounter = 0;
                  reportname = "Attendence Register(Edition Wise)";
                  companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                 tbl.Append("<table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>");
                 tbl.Append("<tr><td>");
                  tbl.Append(header_excel());
                  tbl.Append("<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>");

                  tbl.Append("<tr>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</b></td>");
                  //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>";
                  //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</b></td>");
                  //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</b></td>");
                  //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td>";
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[16].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[17].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</b></td>");
                  //tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[18].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[19].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[20].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[21].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[22].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[25].ToString() + "</td>");

                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[23].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[24].ToString() + "</td>");

                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[26].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new'><b>" + dsxml.Tables[0].Rows[0].ItemArray[27].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[28].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'><b>" + dsxml.Tables[0].Rows[0].ItemArray[30].ToString() + "</b></td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");

                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[33].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[34].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[35].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[36].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[37].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[38].ToString() + "</td>");

                  tbl.Append("<tr>");


                  for (int p = 0; p < ds.Tables[3].Rows.Count; p++)
                  {

                    

                      if (bookdummy1 == "YDU")
                        {
                            if (billflag == "bill")
                            {
                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                string type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                } 
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }
                                string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;
                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }



                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");




                                tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append(datewise + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new' >");
                                tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' >");
                                tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");



                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");



                                tbl.Append("<td class='attreptline' >");
                                tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                tbl.Append("<td class='attreptline'>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='attreptline' >");
                                tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='attreptline'>");
                                tbl.Append(ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");

                                tbl.Append("</tr>");


                                rowcounter++;
                            }
                            else
                            {
                                string type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                string bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }


                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() == "")
                                {
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                    // tbl.Append("<td class='rep_data_new' width='2%'>";
                                    // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    } 
                                    //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                    //{
                                    //    allbill++;
                                    //}
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }  //string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                    //if (bilcycle == "1")
                                    //{
                                    //    bilcycle = "D";
                                    //    single++;
                                    //}
                                    //else if (bilcycle == "2")
                                    //{
                                    //    bilcycle = "W";

                                    //}
                                    //else if (bilcycle == "3")
                                    //{
                                    //    bilcycle = "F";

                                    //}
                                    //else if (bilcycle == "4")
                                    //{
                                    //    bilcycle = "M";

                                    //}

                                    //else if (bilcycle == "6")
                                    //{
                                    //    bilcycle = "C";
                                    //    combin++;

                                    //}



                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");



                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                    string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append(datewise + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    if (type == "3")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                    }
                                    else if (type == "1")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                    }

                                    else if (type == "2")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                    }
                                    else if (type == "4")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (type == "5")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (type == "6")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (type == "7")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                    }
                                    tbl.Append((bookintype + "</td>"));

                                    tbl.Append("<td class='rep_data_new' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                    //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                    //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");



                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");



                                    tbl.Append("<td class='attreptline' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                    tbl.Append("<td class='attreptline'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td   class='attreptline' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='attreptline'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");

                                    tbl.Append("</tr>");

                                    rowcounter++;
                                }
                            }
                        }
                        else
                        {
                            type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                           
                              if(type != "7")
                             {
                            
                      
                            if (billflag == "bill")
                            {
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;
                                }
                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }


                                sno1++;
                                tbl.Append("<tr font-size='10' font-family='Arial'>");
                                tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");
                                
                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                //tbl += "<td class='rep_data_new' width='5%'>";
                                //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                if (col.Substring(0, 1) == "B")
                                    col = "B / W";
                                tbl.Append(col + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='8%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'>");
                                tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                // tbl.Append("<td class='rep_data_new' width='2%'>";
                                // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    if (rateag == "0")
                                    {
                                        string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                        if (spdis != "0")
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (tran != "0")
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                        }
                                        else
                                        {
                                            tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                        }
                                    }
                                }
                                tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                    billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(billamt.ToString("F2") + "</td>");
                                }
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                } 
                                //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                //{
                                //    allbill++;
                                //}
                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                {

                                    tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                }  //string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                //if (bilcycle == "1")
                                //{
                                //    bilcycle = "D";
                                //    single++;
                                //}
                                //else if (bilcycle == "2")
                                //{
                                //    bilcycle = "W";

                                //}
                                //else if (bilcycle == "3")
                                //{
                                //    bilcycle = "F";

                                //}
                                //else if (bilcycle == "4")
                                //{
                                //    bilcycle = "M";

                                //}

                                //else if (bilcycle == "6")
                                //{
                                //    bilcycle = "C";
                                //    combin++;

                                //}




                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");



                                tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                if (datewise.IndexOf(' ') > -1)
                                {
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

                                }
                                tbl.Append(datewise + "</td>");

                                tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                if (type == "3")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                }
                                else if (type == "1")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                }

                                else if (type == "2")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                }
                                else if (type == "4")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                }
                                else if (type == "5")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                }
                                else if (type == "6")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                }
                                else if (type == "7")
                                {
                                    bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                }
                                tbl.Append((bookintype + "</td>"));

                                tbl.Append("<td class='rep_data_new' >");
                                tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;' >");
                                tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");



                                tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");



                                tbl.Append("<td class='attreptline' >");
                                tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                tbl.Append("<td class='attreptline'>");
                                tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                tbl.Append("<td   class='attreptline' >");
                                tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='attreptline'>");
                                tbl.Append(ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");

                                tbl.Append("</tr>");



                                rowcounter++;
                            }
                            else
                            {
                                 type = ds.Tables[3].Rows[p]["BOOKING_TYPE"].ToString();
                                if (type == "7")
                                {
                                    bookdummy++;
                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                {
                                    allbill++;
                                }
                                 bilcycle = ds.Tables[0].Rows[p]["Bill_cycle"].ToString();
                                if (bilcycle == "1")
                                {
                                    bilcycle = "D";
                                    single++;

                                }


                                else if (bilcycle == "2")
                                {
                                    bilcycle = "W";

                                }
                                else if (bilcycle == "3")
                                {
                                    bilcycle = "F";

                                }
                                else if (bilcycle == "4")
                                {
                                    bilcycle = "M";

                                }

                                else if (bilcycle == "6")
                                {
                                    bilcycle = "C";
                                    combin++;

                                }
                                if (ds.Tables[3].Rows[p]["bill_no"].ToString() == "")
                                {
                                    sno1++;
                                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                                    tbl.Append("<td class='rep_data_new' width='2%'>" + sno1 + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'style=padding-left:'1px'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:12px;vertical-align:top;font-family:Verdana;padding-right:1px' width='8%'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["RO_No"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["INS_DATE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='left'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='2%' style='font-family:Verdana;'  align='right'><b>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</b></td>");

                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Area"].ToString() + "</td>");

                                    //tbl += "<td class='rep_data_new' width='5%'>";
                                    //tbl += ds.Tables[2].Rows[p]["Uom"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    string col = ds.Tables[3].Rows[p]["Hue"].ToString();
                                    if (col.Substring(0, 1) == "B")
                                        col = "B / W";
                                    tbl.Append(col + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PagePremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PosPremium"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='8%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Adcat"].ToString() + "/" + ds.Tables[3].Rows[p]["AdSubcat"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Caption"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["Key_no"].ToString() + "</td>");

                                    // tbl.Append("<td class='rep_data_new' width='2%'>";
                                    // tbl.Append(ds.Tables[2].Rows[p]["NO_INSERT"].ToString() + "</td>";

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["cardrate"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    string rateag = ds.Tables[3].Rows[p]["agreedrate"].ToString();
                                    string tran = ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString();
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        if (rateag == "0")
                                        {
                                            string spdis = ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString();
                                            if (spdis != "0")
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "%" + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                            else
                                            {
                                                if (tran != "0")
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                                }
                                                else
                                                {
                                                    tbl.Append(ds.Tables[3].Rows[p]["SPECIAL_DISC_PER"].ToString() + "</td>");

                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (tran != "0")
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "/" + ds.Tables[3].Rows[p]["TRANSLATION_DISC"].ToString() + "</td>");
                                            }
                                            else
                                            {
                                                tbl.Append(ds.Tables[3].Rows[p]["agreedrate"].ToString() + "</td>");

                                            }
                                        }
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%' align='right'>");
                                    if (ds.Tables[3].Rows[p]["BILL_AMT"].ToString() != "")
                                        billamt = Convert.ToDouble(ds.Tables[3].Rows[p]["BILL_AMT"].ToString());
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(billamt.ToString("F2") + "</td>");
                                    }
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {
                                        tbl.Append(ds.Tables[3].Rows[p]["PAGE_PREM_PER"].ToString() + "</td>");
                                    } 
                                    //if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                                    //{
                                    //    allbill++;
                                    //}
                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RATE_CODE"].ToString() + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    if (branchtype == ds.Tables[3].Rows[p]["BRANCH"].ToString())
                                    {

                                        tbl.Append(ds.Tables[3].Rows[p]["POSPREM_DISC"].ToString() + "</td>");
                                    }//string bilcycle = ds.Tables[3].Rows[p]["Bill_cycle"].ToString();
                                    //if (bilcycle == "1")
                                    //{
                                    //    bilcycle = "D";
                                    //    single++;
                                    //}
                                    //else if (bilcycle == "2")
                                    //{
                                    //    bilcycle = "W";

                                    //}
                                    //else if (bilcycle == "3")
                                    //{
                                    //    bilcycle = "F";

                                    //}
                                    //else if (bilcycle == "4")
                                    //{
                                    //    bilcycle = "M";

                                    //}

                                    //else if (bilcycle == "6")
                                    //{
                                    //    bilcycle = "C";
                                    //    combin++;

                                    //}



                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["NO_OF_INSERTION"].ToString() + "/" + ds.Tables[3].Rows[p]["NO_INSERT"].ToString() + "-" + bilcycle + "</td>");


                                    tbl.Append("<td style='font-size:11px;vertical-align:top;' >");
                                    string datewise = ds.Tables[3].Rows[p]["BkDATE"].ToString();
                                    if (datewise.IndexOf(' ') > -1)
                                    {
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

                                    }
                                    tbl.Append(datewise + "</td>");

                                    tbl.Append("<td class='rep_data_new' width='5%'  align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PUBDT"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    if (type == "3")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[0].ToString();
                                    }
                                    else if (type == "1")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[1].ToString();
                                    }

                                    else if (type == "2")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[2].ToString();
                                    }
                                    else if (type == "4")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (type == "5")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (type == "6")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (type == "7")
                                    {
                                        bookintype = dsxml.Tables[3].Rows[0].ItemArray[6].ToString();
                                    }
                                    tbl.Append((bookintype + "</td>"));

                                    tbl.Append("<td class='rep_data_new' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

                                    //tbl.Append("<td style='font-size:13px;vertical-align:top;' colspan='8' ><b>Edition :</b>");
                                    //tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["RO_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                                    tbl.Append("<td style='font-size:13px;vertical-align:top;'  >");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");



                                    tbl.Append("<td style='font-size:11px;vertical-align:top;'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</td>");



                                    tbl.Append("<td class='attreptline' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["TRADE_DISC"].ToString() + "%</td>");

                                    tbl.Append("<td class='attreptline'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["BILL_REMARKS"].ToString() + "</td>");

                                    tbl.Append("<td   class='attreptline' >");
                                    tbl.Append(ds.Tables[3].Rows[p]["EXECUTIVE_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='attreptline'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["RETAINER_NAME"].ToString() + "</td>");
                                    tbl.Append("<td class='rep_data_new' width='3%' align='center'>");
                                    tbl.Append(ds.Tables[3].Rows[p]["PAGENO"].ToString() + "</td>");

                                    tbl.Append("</tr>");

                                    rowcounter++;
                                }
                            }
                        }
                        }

                    }
                    if (showothercentdata == "Y")
                    {
                        totalad = ds.Tables[0].Rows.Count;
                        totadd2 = ds.Tables[2].Rows.Count;
                        totadd3 = ds.Tables[3].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());


                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='center' ><b>To be Billed :</b>");
                        tbl.Append((totalad + totadd2 + totadd3 - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='4' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Direct Cash :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>Scheme :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Combin :</b>");
                        tbl.Append(combin.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Book for Dummy :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Single :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append((totalad + totadd2 + totadd3).ToString() + "</td>");


                        tbl.Append("</table></td><tr></table></p>");
                    }
                    else
                    {
                        totalad = ds.Tables[0].Rows.Count;

                        totadd3 = ds.Tables[3].Rows.Count;
                        alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
                        nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

                        schad = Convert.ToInt32(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString());
                        directcash = Convert.ToInt32(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString());


                        tbl.Append("<tr><td   class='middle31new' colspan='2' align='center' ><b>To be Billed :</b>");
                        tbl.Append((totalad + totadd3 - nottobill - allbill - schad - directcash - bookdummy).ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Booked by Others :</b>");
                        tbl.Append(nottobill.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='4' align='center' ><b>Already Billed :</b>");
                        tbl.Append(allbill.ToString() + "</td>");


                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Direct Cash :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["DIRECT_CASH"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='3' align='center' ><b>Scheme :</b>");
                        tbl.Append(ds.Tables[4].Rows[0]["SCHEME_ADS"].ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Combin :</b>");
                        tbl.Append(combin.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Book for Dummy :</b>");
                        tbl.Append(bookdummy.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Single :</b>");
                        tbl.Append(single.ToString() + "</td>");

                        tbl.Append("<td   class='middle31new' colspan='2' align='center' ><b>Total Ads :</b>");
                        tbl.Append((totalad + totadd3).ToString() + "</td>");


                        tbl.Append("</table></td><tr></table></p>");


                    }


                  // report.InnerHtml = report.InnerHtml + tbl;
      


                }
              report.InnerHtml = report.InnerHtml + tbl.ToString();
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
    public string RETURN_LENGTH(string str_decimal)
    {
        string x = "";
        if (str_decimal.Length == 1)
            x = "0" + str_decimal;
        else
            x = str_decimal;
        return x;
    }
    public void gridbindbilled()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            // ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode);
        }
        else
        {
            string procedureName = "schedulereport_checklist";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/AttendenceRegister.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int totadd2 = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        int schad = 0;
        int directcash = 0;
        int totadd3 = 0;
        int bookdummy = 0;
        string bookintype = "";
        //====****************** Case for Book from other Center *****************//
        if (drpbookfrom == "Y" && dppubcent != "0" && dppubcent != "" && (ds.Tables[2].Rows.Count > 0))
        {
            showothercentdata = "Y";
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            //string tbl = "";
            double billamt = 0;
            companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
            StringBuilder tbl = new StringBuilder();

            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
            pgn = pgn + 1;

            tbl.Append(header());
            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
          // tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
           tbl.Append("<tr>");


        for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
        {
            if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
            {
                if (rowcounter == maxlimtbill)
                {
                    rowcounter = 0;
                    pgn = pgn + 1;
                    tbl.Append("</table></td><tr></table></p>");
                    tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                    tbl.Append("<tr><td>");
                    tbl.Append(header());
                    tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                    // tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                    tbl.Append("<tr>");

                }
                sno1++;
                tbl.Append("<tr font-size='10' font-family='Arial'>");
                tbl.Append("<td class='rep_data_new' width='3%'>" + sno1 + "</td>");

                tbl.Append( "<td class='rep_data' width='10%'>");
                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");
                tbl.Append("<td class='rep_data' width='25%'>");
                tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                  tbl.Append( "<td class='rep_data' width='20%'>");
                tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

              tbl.Append("<td class='rep_data' width='10%'>");
                tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

              
               tbl.Append("<td class='rep_data' width='3%'>");
                tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</td>");

                tbl.Append( "<td class='rep_data' width='4%'>");
                tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</td>");
                tbl.Append("<td class='rep_data' width='10%'>");
                tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='6%'>");
                tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");
                tbl.Append("</tr>");
                tbl.Append("<tr>");
                tbl.Append("<td  class='rep_data' font-family='Arial' colspan='9' style='height:15px' ><b>Package:");
                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</b></td>");
           
                tbl.Append("</tr>");
                tbl.Append("<tr>");
                tbl.Append("<td  class='rep_data' font-family='Arial' colspan='9' style='height:15px' ><b>Edition:");
                tbl.Append(ds.Tables[0].Rows[p]["EDITION"].ToString() + "</b></td>");

                tbl.Append("</tr>");
         

                rowcounter++;
            }
        }

        tbl.Append("</table></td><tr></table></p>");
        tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
        report.InnerHtml = tbl.ToString();
  ///////////////////////////////////////////////////////////////
        if (ds.Tables[2].Rows.Count > 0)
        {
          
            if (showothercentdata == "Y")
            {
                sno1 = 0;
                tbl.Length = 0;
                rowcounter = 0;

                reportname = "Attendence Register(Booked For Others)";
                companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                tbl.Append("<tr><td>");
                pgn = pgn + 1;

                tbl.Append(header());
                tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                tbl.Append("<tr>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                // tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                tbl.Append("<tr>");

                for (int p = 0; p < ds.Tables[2].Rows.Count; p++)
                {
                    if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                    {
                        if (rowcounter == maxlimtbill)
                        {
                            rowcounter = 0;
                            pgn = pgn + 1;
                            tbl.Append("</table></td><tr></table></p>");
                            tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                            tbl.Append("<tr><td>");
                            tbl.Append(header());
                            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                            tbl.Append("<tr>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                            // tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                            tbl.Append("<tr>");

                        }
                        sno1++;
                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                        tbl.Append("<td class='rep_data_new' width='3%'>" + sno1 + "</td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");
                        tbl.Append("<td class='rep_data' width='25%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='20%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");


                        tbl.Append("<td class='rep_data' width='3%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='4%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</td>");
                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='6%'>");
                        tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");
                        tbl.Append("</tr>");
                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data' font-family='Arial' colspan='9' style='height:15px' ><b>Package:");
                        tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</b></td>");

                        tbl.Append("</tr>");

                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data' font-family='Arial' colspan='9' style='height:15px' ><b>Edition:");
                        tbl.Append(ds.Tables[2].Rows[p]["EDITION"].ToString() + "</b></td>");

                        tbl.Append("</tr>");

                        rowcounter++;
                    }
                }
                tbl.Append("</table></td><tr></table></p>");
                tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");

                report.InnerHtml = report.InnerHtml + tbl.ToString();

            }
        }
///////////////////////////////////////////////////edtionwise///////////////////////////////

        if (ds.Tables[3].Rows.Count > 0)
        {
            
                sno1 = 0;
                tbl.Length = 0;
                rowcounter = 0;

                reportname = "Attendence Register(Edition Wise)";
                companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                tbl.Append("<tr><td>");
                pgn = pgn + 1;

                tbl.Append(header());
                tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                tbl.Append("<tr>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                // tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                tbl.Append("<tr>");

                for (int p = 0; p < ds.Tables[3].Rows.Count; p++)
                {
                    if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                    {
                        if (rowcounter == maxlimtbill)
                        {
                            rowcounter = 0;
                            pgn = pgn + 1;
                            tbl.Append("</table></td><tr></table></p>");
                            tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                            tbl.Append("<tr><td>");
                            tbl.Append(header());
                            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                            tbl.Append("<tr>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                            // tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                            tbl.Append("<tr>");

                        }
                        sno1++;
                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                        tbl.Append("<td class='rep_data_new' width='3%'>" + sno1 + "</td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");
                        tbl.Append("<td class='rep_data' width='25%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='20%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");


                        tbl.Append("<td class='rep_data' width='3%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='4%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</td>");
                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='6%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");
                        tbl.Append("</tr>");
                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data' font-family='Arial' colspan='9' style='height:15px' ><b>Package:");
                        tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</b></td>");

                        tbl.Append("</tr>");
                        tbl.Append("<tr>");
                        tbl.Append("<td  class='rep_data' font-family='Arial' colspan='9' style='height:15px' ><b>Edition:");
                        tbl.Append(ds.Tables[3].Rows[p]["EDITION"].ToString() + "</b></td>");

                        tbl.Append("</tr>");


                        rowcounter++;
                    }
                }
                tbl.Append("</table></td><tr></table></p>");
                tbl.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");

                report.InnerHtml = report.InnerHtml + tbl.ToString();
            
            }
        
        }
    }
    public void gridbind_excelbilled()
    {
        DataSet ds = new DataSet();
        string[] parameterValueArray = new string[] { fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode };
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            // ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch);
        }
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.displayonscreenreport(fdate, tdate, Session["compcode"].ToString(), dppub1, drpstatus, dpedition, dppubcent, dpaddtype, adcat, Session["dateformat"].ToString(), orderby, "ASC", supplement, package1, dpedidetail, Session["userid"].ToString(), Session["access"].ToString(), dpd_branch, drpbookfrom, uomcode, subcatcode);
        }
        else
        {
            string procedureName = "schedulereport_checklist";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/AttendenceRegister.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int totadd2 = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        int schad = 0;
        int directcash = 0;
        int totadd3 = 0;
        int bookdummy = 0;
        string bookintype = "";
        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

        //====****************** Case for Book from other Center *****************//
        if (drpbookfrom == "Y" && dppubcent != "0" && dppubcent != "" && (ds.Tables[2].Rows.Count > 0))
        {
            showothercentdata = "Y";
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            //string tbl = "";
            double billamt = 0;
            companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
            StringBuilder tbl = new StringBuilder();

            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
            pgn = pgn + 1;

            tbl.Append(header());
            tbl.Append("<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>");
            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
            tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
            tbl.Append("<tr>");


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                if (ds.Tables[0].Rows[p]["bill_no"].ToString() != "")
                {
                    sno1++;
                    tbl.Append("<tr font-size='10' font-family='Arial'>");
                    tbl.Append("<td class='rep_data_new' width='3%'>" + sno1 + "</td>");

                    tbl.Append("<td class='rep_data' width='10%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</b></td>");
                    tbl.Append("<td class='rep_data' width='25%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["Agency"].ToString() + "," + ds.Tables[0].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                    tbl.Append("<td class='rep_data' width='20%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["Client"].ToString() + "</b></td>");

                    tbl.Append("<td class='rep_data' width='10%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");
                    tbl.Append("<td class='rep_data' width='10%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</b></td>");


                    tbl.Append("<td class='rep_data' width='3%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["Depth"].ToString() + "</td>");

                    tbl.Append("<td class='rep_data' width='4%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["Width"].ToString() + "</td>");
                    tbl.Append("<td class='rep_data' width='10%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["BILL_NO"].ToString() + "</td>");

                    tbl.Append("<td class='rep_data' width='6%'>");
                    tbl.Append(ds.Tables[0].Rows[p]["BILLDATE"].ToString() + "</td>");
                 
                    tbl.Append("</tr>");


                    rowcounter++;
                }
            }

            tbl.Append("</table></td><tr></table></p>");
              report.InnerHtml = tbl.ToString();
            ///////////////////////////////////////////////////////////////
            if (ds.Tables[2].Rows.Count > 0)
            {

                if (showothercentdata == "Y")
                {
                    sno1 = 0;
                    tbl.Length = 0;
                    rowcounter = 0;

                    reportname = "Attendence Register(Booked For Others)";
                    companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                    tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>");
                    tbl.Append("<tr><td>");
                    pgn = pgn + 1;

                    tbl.Append(header());
                    tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                    tbl.Append("<tr>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                    tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                    tbl.Append("<tr>");

                    for (int p = 0; p < ds.Tables[2].Rows.Count; p++)
                    {
                        if (ds.Tables[2].Rows[p]["bill_no"].ToString() != "")
                        {
                            sno1++;
                            tbl.Append("<tr font-size='10' font-family='Arial'>");
                            tbl.Append("<td class='rep_data_new' width='3%'>" + sno1 + "</td>");

                            tbl.Append("<td class='rep_data' width='10%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["CIOID"].ToString() + "</b></td>");
                            tbl.Append("<td class='rep_data' width='25%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Agency"].ToString() + "," + ds.Tables[2].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data' width='20%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Client"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data' width='10%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data' width='10%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["PACKAGE_NAME"].ToString() + "</b></td>");

                            tbl.Append("<td class='rep_data' width='3%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Depth"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data' width='4%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["Width"].ToString() + "</td>");
                            tbl.Append("<td class='rep_data' width='10%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILL_NO"].ToString() + "</td>");

                            tbl.Append("<td class='rep_data' width='6%'>");
                            tbl.Append(ds.Tables[2].Rows[p]["BILLDATE"].ToString() + "</td>");
                               tbl.Append("</tr>");


                            rowcounter++;
                        }
                    }
                    tbl.Append("</table></td><tr></table></p>");
              
                    report.InnerHtml = report.InnerHtml + tbl.ToString();

                }
            }
            ///////////////////////////////////////////////////edtionwise///////////////////////////////

            if (ds.Tables[3].Rows.Count > 0)
            {

                sno1 = 0;
                tbl.Length = 0;
                rowcounter = 0;

                reportname = "Attendence Register(Edtion wise)";
                companyname = ds.Tables[4].Rows[0]["COMP_NAME"].ToString();
                tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>");
                tbl.Append("<tr><td>");
                pgn = pgn + 1;

                tbl.Append(header());
                tbl.Append("<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>");
                tbl.Append("<tr>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[2].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[3].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + "</td>");
                tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[29].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[31].ToString() + "</td>");
                tbl.Append("<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[32].ToString() + "</td>");
                tbl.Append("<tr>");

                for (int p = 0; p < ds.Tables[3].Rows.Count; p++)
                {
                    if (ds.Tables[3].Rows[p]["bill_no"].ToString() != "")
                    {
                        sno1++;
                        tbl.Append("<tr font-size='10' font-family='Arial'>");
                        tbl.Append("<td class='rep_data_new' width='3%'>" + sno1 + "</td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["CIOID"].ToString() + "</b></td>");
                        tbl.Append("<td class='rep_data' width='25%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Agency"].ToString() + "," + ds.Tables[3].Rows[p]["AGENCY_CITY"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='20%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Client"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["EDITION_NAME"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["PACKAGE_NAME"].ToString() + "</b></td>");

                        tbl.Append("<td class='rep_data' width='3%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Depth"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='4%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["Width"].ToString() + "</td>");
                        tbl.Append("<td class='rep_data' width='10%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["BILL_NO"].ToString() + "</td>");

                        tbl.Append("<td class='rep_data' width='6%'>");
                        tbl.Append(ds.Tables[3].Rows[p]["BILLDATE"].ToString() + "</td>");
                       
                        tbl.Append("</tr>");


                        rowcounter++;
                    }
                }
                tbl.Append("</table></td><tr></table></p>");

                report.InnerHtml = report.InnerHtml + tbl.ToString();
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                hw.WriteBreak();
                report.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
    }
}
