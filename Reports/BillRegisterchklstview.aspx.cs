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


public partial class BillRegisterchklstview : System.Web.UI.Page
{
    string fdate = "";
    string tdate = "";
    string dppub1 = "";
    string branch = "";
    string dpedition = "";
    string dppubcent = "";
    string dpaddtype = "";
    string Agencytype = "";
    string ratecod = "";
    string uom = "";
    string rundate = "";
    string dpedidetail = "";
    string dateformat = "";
    string dpd_branch = "";
    string adtype_nam = "";
    string publication_nam = "";
    string edition_nam = "";
    string pubcent_nam = "";
    string type = "run";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 30;
    int pgn = 0;
    string orderby = "";
    string sno = "";
    string view = "";
    string rdatefinalhdsmain = "";
    string reportname = "";
    string companyname = "";
    string Basedon = "";
    string printcentername = "";
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
        dppub1 = Request.QueryString["dppub1"].ToString();
        branch = Request.QueryString["branch"].ToString();
        dpedition = Request.QueryString["dpedition1"].ToString();
        dppubcent = Request.QueryString["dppubcent"].ToString();
        dpaddtype = Request.QueryString["dpaddtype"].ToString();
        Agencytype = Request.QueryString["Agencytype"].ToString();
        ratecod = Request.QueryString["ratecod"].ToString();
        uom = Request.QueryString["uom"].ToString();
        view = Request.QueryString["view"].ToString();
        Basedon = Request.QueryString["Basedon"].ToString();
       // dpd_branch = Request.QueryString["dpd_branch"].ToString();
        adtype_nam = Request.QueryString["adtype_nam"].ToString();
        publication_nam = Request.QueryString["publication_nam"].ToString();
        edition_nam = Request.QueryString["edition_nam"].ToString();
        pubcent_nam = Request.QueryString["pubcent_nam"].ToString();
        printcentername = Request.QueryString["printcentername"].ToString();
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

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/BillRegister_Chklst.xml"));
        reportname = ds.Tables[0].Rows[0].ItemArray[13].ToString();
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
            ds = obj.getbillregisterrec_chklst(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        else
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.getbillregisterrec_chklst(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/BillRegister_Chklst.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        double total = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            //string tbl = "";
            double billamt = 0;
            double rate = 0;
            double arera = 0;
            StringBuilder tbl = new StringBuilder();
       
            
            companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
           tbl.Append( "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append( "<tr><td>");
             tbl.Append( header());
             tbl.Append( "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

             tbl.Append( "<tr>");
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[18].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");
      
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[21].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[20].ToString() + "</td>");
             
            tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
             tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[19].ToString() + "</td>");
          
             tbl.Append( "<tr>");


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;
                   
                     tbl.Append( "</table></td><tr>");
                  tbl.Append( "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
                   tbl.Append( "</table><p>");
                     tbl.Append( header());
                     tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

                     tbl.Append("<tr>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[18].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");

                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[21].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[20].ToString() + "</td>");

                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
                     tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[19].ToString() + "</td>");

                     tbl.Append("</tr>");

                }
               // string.Format("{0:0.00}",any object);
                sno1++;
                 tbl.Append( "<tr font-size='10' font-family='Arial'>");
                 tbl.Append( "<td class='rep_data' width='2%'>" + sno1 + "</td>");

                 tbl.Append( "<td class='rep_data' width='8%'style=padding-left:'1px'>");
                 tbl.Append( ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='10%' align='left'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Client"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='8%' align='center'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Size"].ToString() + "&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>");
                 arera = arera +  Convert.ToDouble(ds.Tables[0].Rows[p]["Size"].ToString());
                 tbl.Append( "<td class='rep_data' width='5%' align='right'>");
                if (ds.Tables[0].Rows[p]["InsrtAgreedRate"].ToString() != "")
                {
                    rate = Convert.ToDouble(string.Format("{0:0.00}", ds.Tables[0].Rows[p]["InsrtAgreedRate"].ToString()));
                }
                else
                {
                   // rate = 
                }
                 tbl.Append( rate.ToString("F2") + "</td>");

                 tbl.Append( "<td class='rep_data' width='5%' align='center'>");
                 tbl.Append( ds.Tables[0].Rows[p]["AgencyComm"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='5%'align='right'>");
                if (ds.Tables[0].Rows[p]["InsrtBillAmt"].ToString() != "")
                    billamt = Convert.ToDouble(string.Format("{0:0.00}", ds.Tables[0].Rows[p]["InsrtBillAmt"].ToString()));
                total = billamt + total;
                 tbl.Append( billamt.ToString("F2") + "</td>");



                 tbl.Append( "<td class='rep_data' width='5%' align='center'>");
                 tbl.Append( ds.Tables[0].Rows[p]["No_Insert"].ToString() + "/" + ds.Tables[0].Rows[p]["TotalInsert"].ToString() + "</td>");



                 tbl.Append( "<td class='rep_data' width='10%'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Bill_No"].ToString() + "</td>");


                 tbl.Append("<td class='rep_data' width='5%'>");
                 if (ds.Tables[0].Rows[p]["Color"].ToString() == "B")
                 {
                     tbl.Append("Black & White" + "</td>");
                 }
                 else
                 {
                     tbl.Append("Color" + "</td>");
                 }
                 //tbl.Append(ds.Tables[0].Rows[p]["Color"].ToString() + "</td>");



                 tbl.Append("<td class='rep_data' width='10%'>");
                 string datewise = ds.Tables[0].Rows[p]["FIRST_PUB_DATE"].ToString();
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
          
                 tbl.Append( "<td class='rep_data' width='10%'>");
                 tbl.Append(ds.Tables[0].Rows[p]["BILLING_STATUS"].ToString() + "</td>");
                 tbl.Append( "<td class='rep_data' width='10%'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Insert_Status"].ToString() + "</td>");

                 tbl.Append( "</tr>");



                rowcounter++;

            }

             tbl.Append( "<tr >");
          
             tbl.Append( "<td class='middle31new'  colspan='2'  align='right'>");
             tbl.Append( dsxml.Tables[1].Rows[0].ItemArray[14].ToString() +"</td>");
             tbl.Append("<td  class='middle31new' colspan='1'>" + "" + "</td>");
          
            tbl.Append("<td class='middle31new'  colspan='1'  align='center'>");
             tbl.Append(arera.ToString()+ "</td>");
             tbl.Append("<td  class='middle31new' colspan='2'>" + "" + "</td>");
          
             tbl.Append( "<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>");
             tbl.Append( "<td  class='middle31new' colspan='6'>" + "" + "</td>");
             tbl.Append( "</tr>");

            //  tbl.Append( "<tr font-size='10' font-family='Arial'>";
              //totalad = ds.Tables[0].Rows.Count;
              //  alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
              //  nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

              //   tbl.Append( "<tr><td   class='middle31new' colspan='5' align='center' ><b>To be Billed :</b>";
              //   tbl.Append( (totalad - nottobill - alreadybil).ToString() + "</td>");

              //   tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Booked by Others :</b>";
              //   tbl.Append( nottobill.ToString() + "</td>");

              //   tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>";
              //   tbl.Append( alreadybil.ToString() + "</td>");

              //   tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Total Ads :</b>";
              //   tbl.Append( totalad.ToString() + "</td>");


              //   tbl.Append( "</tr>";
             tbl.Append( "</table></td><tr></table></p>");

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
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='2' style='text-align:right'><b>Publication Center :</b>" + printcentername + "</td></tr>";
         // hdr tbl.Append( "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }


    private string headerexcelreport()
    {
        string hdrtbl = "";
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='middle33'><td colspan='13' style='text-align:center'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='13' style='text-align:center'>" + reportname + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='5' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='5' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='3' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='5' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='5' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='3' style='text-align:right'><b>Publication Center :</b>" + printcentername + "</td></tr>";
        // hdr tbl.Append( "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

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
        hdrtbl += "<tr class='middle33'><td colspan='6' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='6' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='6' style='text-align:right'><b>Publication Center :</b>" + printcentername + "</td></tr>";
         // hdr tbl.Append( "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    public void gridbind_excel()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            ds = obj.getbillregisterrec_chklst(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        else
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.getbillregisterrec_chklst(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/BillRegister_Chklst.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        double total = 0;

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            //string tbl = "";
            double billamt = 0;
            double rate = 0;
            double arera = 0;
            StringBuilder tbl = new StringBuilder();
       
       
            companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
          tbl.Append( "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append( "<tr><td>");
            tbl.Append(headerexcelreport());
             tbl.Append( "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

             tbl.Append( "<tr>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[18].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
             tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
             tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");

             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[21].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[20].ToString() + "</td>");

             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
             tbl.Append("<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[19].ToString() + "</td>");
            // tbl.Append( "<tr>";


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                //if (rowcounter == maxlimit)
                //{
                //    rowcounter = 0;

                //     tbl.Append( "</table></td><tr></table></p>";
                //    tbl = tbl + "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
                //    tbl = tbl + "<tr><td>";
                //     tbl.Append( header();
                //     tbl.Append( "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                //     tbl.Append( "<tr>";
                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[18].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");

                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");
                //     tbl.Append( "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
                //     tbl.Append( "<tr>";
                //}
                // string.Format("{0:0.00}",any object);
               sno1++;
                 tbl.Append( "<tr font-size='10' font-family='Arial'>");
                 tbl.Append( "<td class='rep_data' width='2%'>" + sno1 + "</td>");

                 tbl.Append( "<td class='rep_data' width='8%'style=padding-left:'1px'>");
                 tbl.Append( ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='5%' align='left'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Client"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='8%' align='center'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Size"].ToString() + "&nbsp;&nbsp;" + ds.Tables[0].Rows[p]["Uom"].ToString() + "</td>");

                 arera = arera + Convert.ToDouble(ds.Tables[0].Rows[p]["Size"].ToString());
               


                 tbl.Append( "<td class='rep_data' width='5%' align='right'>");
                if (ds.Tables[0].Rows[p]["InsrtAgreedRate"].ToString() != "")
                {
                    rate = Convert.ToDouble(string.Format("{0:0.00}", ds.Tables[0].Rows[p]["InsrtAgreedRate"].ToString()));
                }
                else
                {
                   // rate = 
                }
                 tbl.Append( rate.ToString("F2") + "</td>");

                 tbl.Append( "<td class='rep_data' width='5%' align='center'>");
                 tbl.Append( ds.Tables[0].Rows[p]["AgencyComm"].ToString() + "</td>");

                 tbl.Append( "<td class='rep_data' width='5%'align='right'>");
                if (ds.Tables[0].Rows[p]["InsrtBillAmt"].ToString() != "")
                    billamt = Convert.ToDouble(string.Format("{0:0.00}", ds.Tables[0].Rows[p]["InsrtBillAmt"].ToString()));
                total = billamt + total;
                 tbl.Append( billamt.ToString("F2") + "</td>");



                 tbl.Append( "<td class='rep_data' width='5%' align='center'>");
                 tbl.Append( ds.Tables[0].Rows[p]["No_Insert"].ToString() + "-" + ds.Tables[0].Rows[p]["TotalInsert"].ToString() + "</td>");



                 tbl.Append( "<td class='rep_data' width='5%'>");
                 tbl.Append( ds.Tables[0].Rows[p]["Bill_No"].ToString() + "</td>");



                 tbl.Append("<td class='rep_data' width='5%'>");
                 if (ds.Tables[0].Rows[p]["Color"].ToString() == "B")
                 {
                     tbl.Append("Black & White" + "</td>");
                 }
                 else
                 {
                     tbl.Append("Color" + "</td>");
                 }
                 //tbl.Append(ds.Tables[0].Rows[p]["Color"].ToString() + "</td>");



            
                 tbl.Append("<td class='rep_data' width='10%'>");
                 string datewise = ds.Tables[0].Rows[p]["FIRST_PUB_DATE"].ToString();
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
            

                 tbl.Append( "<td class='rep_data' width='10%'>");
                 tbl.Append(ds.Tables[0].Rows[p]["BILLING_STATUS"].ToString() + "</td>");
                 tbl.Append( "<td class='rep_data' width='10%'>");
                 tbl.Append(ds.Tables[0].Rows[p]["Insert_Status"].ToString() + "</td>");

                 tbl.Append( "</tr>");



                rowcounter++;

            }

             //tbl.Append( "<tr >");
          
             //tbl.Append( "<td class='middle31new'  colspan='6'  align='right'>");
             //tbl.Append( dsxml.Tables[1].Rows[0].ItemArray[14].ToString() +"</td>");
             //tbl.Append( "<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>");
             //tbl.Append( "<td  class='middle31new' colspan='3'>" + "" + "</td>");
             //tbl.Append( "</tr>");





             tbl.Append("<tr >");

             tbl.Append("<td class='middle31new'  colspan='2'  align='right'>");
             tbl.Append(dsxml.Tables[1].Rows[0].ItemArray[14].ToString() + "</td>");
             tbl.Append("<td  class='middle31new' colspan='1'>" + "" + "</td>");

             tbl.Append("<td class='middle31new'  colspan='1'  align='center'>");
             tbl.Append(arera.ToString() + "</td>");
             tbl.Append("<td  class='middle31new' colspan='2'>" + "" + "</td>");

             tbl.Append("<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>");
             tbl.Append("<td  class='middle31new' colspan='6'>" + "" + "</td>");
             tbl.Append("</tr>");











            //  tbl.Append( "<tr font-size='10' font-family='Arial'>";
              //totalad = ds.Tables[0].Rows.Count;
              //  alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
              //  nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

              //   tbl.Append( "<tr><td   class='middle31new' colspan='5' align='center' ><b>To be Billed :</b>";
              //   tbl.Append( (totalad - nottobill - alreadybil).ToString() + "</td>");

              //   tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Booked by Others :</b>";
              //   tbl.Append( nottobill.ToString() + "</td>");

              //   tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>";
              //   tbl.Append( alreadybil.ToString() + "</td>");

              //   tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Total Ads :</b>";
              //   tbl.Append( totalad.ToString() + "</td>");


              //   tbl.Append( "</tr>";
             tbl.Append( "</table></td><tr></table></p>");

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


            //report.InnerHtml = tbl;
         


        //}
        //else
        //{
        //    Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        //}

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
}
