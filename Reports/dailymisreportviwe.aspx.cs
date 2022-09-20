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

public partial class Reports_dailymisreportviwe : System.Web.UI.Page
{
    int pageno = 1;
    string agency = "";
    string client = "";
    string package = "";
    int maxlimit = 20;
    string agname = "";
    string adtyp = "";
    string destination = "";
    string adcat = "";
    string fromdt = "";
    string dateto = "";
    string publ = "";
    string pubcen = "";
    string pub2 = "";
    string pubcname = "";
    string edition = "";
    string date = "";
    string day = "";
    string month = "";
    string year = "";
    string adcatname = "";
    string agencyname = "";
    string agencyname1 = "";
    string agencysubcode1 = "";
    string adtypename = "";
    string editionname = "";
    string datefrom1 = "";
    string dateto1 = "";
    string area = "";
    string uom = "";
    int i1 = 0;
    double amt = 0;
    string sortorder = "";
    string sortvalue = "", agtype = "", agtypetext = "";
    string companyname = "";
    int p = 0;
    string rdatefinalhdsmain1 = "";
    string rundate = "";

    string rdatefinalhdsmain = "";
    double comm1 = 0;
    double comm2 = 0;
    double areanew = 0;
    int sno = 1;
    int sumsno;
    double rowcounter = 0;
    double totrol = 0;
    double totcd = 0;
    double totcc = 0;
    DataSet ds;

    string name1 = "", name2 = "", name3 = "";
    string chk_excel = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = (DataSet)Session["dailymis"];

        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {

        }
        string prm = Session["prm_dailymis"].ToString();
        string[] prm_Array = new string[3];
        prm_Array = prm.Split('~');
        fromdt = prm_Array[2]; //Request.QueryString["fromdate"].ToString();
        dateto = prm_Array[4]; //Request.QueryString["dateto"].ToString();
        pubcen = prm_Array[12];
        adtyp = prm_Array[8];
        area = prm_Array[14];
        uom = prm_Array[10];
        chk_excel = prm_Array[6];
        if (pubcen == "--Select Publication Center--" || pubcen == "")
        {
            pubcen = "All";
        }

        if (uom == "-Select UOM Name-" || uom == "")
        {
            uom = "All";
        }
        if (!Page.IsPostBack)
        {
            if (chk_excel == "1" || chk_excel == "0")
            {
                onscreen();
            }
            else 
            {
                Excel();
           
            }
            //else
            //    if (destination == "3")
            //    {
            //        pdf(agname, adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());
            //    }
        }
    }

    private void onscreen()
    {
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/dailymis.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            int sno1 = 0;
            // string tbl = "";
            StringBuilder tbl = new StringBuilder();
            double billamt = 0;
            double rate = 0;
            double total = 0;
            rundate = ds.Tables[1].Rows[0]["CUR_DATE"].ToString();
            rundate = changeformat(rundate);
            string[] tim = rundate.Split(' ');
            string rdate = tim[0];
            string[] rdatehdsmaintds = rdate.Split(' ');
            string hdsmainhjrdate = rdatehdsmaintds[0];
            string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
            string hdsmainhjrdate1 = hdsmainhjrdateS[0];
            string hdsmainhjrdate2 = hdsmainhjrdateS[1];
            string hdsmainhjrdate3 = hdsmainhjrdateS[2];
            rdatefinalhdsmain1 = hdsmainhjrdate1 + '/' + hdsmainhjrdate2 + '/' + hdsmainhjrdate3;
            // companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
          //  tbl.Append("<tr class='middle31new'></tr>");
            tbl.Append(header());
            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

            tbl.Append("<tr>");
            //tbl.Append("<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[44].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center' width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='9%'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='5%'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>");
            
            tbl.Append("<td  class='middle31new'align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='5%'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'width='25%'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>");
            

            // 


            for (p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                if (rowcounter == maxlimit)
                {
                    maxlimit = 25;
                    rowcounter = 0;
                    tbl.Append( "</table><p>");
                    tbl.Append( "</br>");
                    tbl.Append( "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0' cellpadding='0' border='0'>");

                    tbl.Append( "</table><p>");
                    tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px>");
                    pageno++;
                    tbl.Append("<tr class='middle31new'><td colspan='11' align='right' valign = 'top'><b>Page No.:"+"</b>" + pageno + "</td></tr>");
                    tbl.Append("</table>");
                    tbl.Append( "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");
                    tbl.Append("<tr>");
                    //tbl.Append("<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[44].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'align='center' width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'align='center'width='9%'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'align='center'width='5%'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>");

                    tbl.Append("<td  class='middle31new'align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='center'width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new'align='center'width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='center'width='5%'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>");
                    tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");

                    tbl.Append("<td  class='middle31new' align='center'width='25%'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>");
                }

                sno1++;

                //rundate = DateTime.Parse(ds.Tables[0].Rows[p]["CUR_DATE"].ToString()).ToShortDateString();






                tbl.Append("<tr font-size='10' font-family='Arial'>");
                tbl.Append("<td class='rep_data' width='2%'align='center'>" + sno1 + "</td>");
                tbl.Append("<td class='rep_data' width='9%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");

               

                tbl.Append("<td class='rep_data' width='5%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["INSERT_DATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["REGION_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='2%' align='right'>");
                tbl.Append(ds.Tables[0].Rows[p]["HEIGHT"].ToString() + "</td>");




                tbl.Append("<td class='rep_data' width='2%'align='right' >");
                tbl.Append(ds.Tables[0].Rows[p]["WIDTH"].ToString() + "</td>");



                tbl.Append("<td class='rep_data' width='5%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["SIZE_BOOK"].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='10%' align='left'>");
                tbl.Append(ds.Tables[0].Rows[p]["POS_TYPE_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='left'>");
                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREMIUM_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='left'>");
                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");



                tbl.Append("<td class='rep_data' width='25%' align='left'>");
                tbl.Append(ds.Tables[0].Rows[p]["PRINT_REMARK"].ToString() + "</td>");

                


                //tbl.Append( "<td class='rep_data' width='5%' align='center'>";
                //tbl.Append( "" + "</td>");




                tbl.Append("</tr>");



                rowcounter++;

            }

            // tbl.Append("<tr width='50%'>");
            // tbl.Append("<td class='middle31new'  colspan='5'  align='right'>");
            // tbl.Append(dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td>");

            //tbl.Append("<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>");
            //tbl.Append("<td  class='middle31new'>" + "" + "</td>");
            //tbl.Append("</tr>");

            // tbl.Append( "<tr font-size='10' font-family='Arial'>";
            //totalad = ds.Tables[0].Rows.Count;
            //  alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
            //  nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

            //  tbl.Append( "<tr><td   class='middle31new' colspan='5' align='center' ><b>To be Billed :</b>";
            //  tbl.Append( (totalad - nottobill - alreadybil).ToString() + "</td>");

            //  tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Booked by Others :</b>";
            //  tbl.Append( nottobill.ToString() + "</td>");

            //  tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>";
            //  tbl.Append( alreadybil.ToString() + "</td>");

            //  tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Total Ads :</b>";
            //  tbl.Append( totalad.ToString() + "</td>");


            //  tbl.Append( "</tr>";
            tbl.Append("</table></td></tr></table></p>");

            report.InnerHtml = tbl.ToString();


        }
    }

    private string header()
    {   
        string hdrtbl = "";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/dailymis.xml"));
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='13' style='text-align:center;' valign = 'top'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='13' style='text-align:center;' valign = 'top'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td></tr>";
       // hdrtbl += "<tr class='middle33'><td  style='text-align:right'colspan='11' >" + "Rundate:" + rdatefinalhdsmain1 + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='3' style='text-align:left'><b>" + "From Date:" + "</b>" + fromdt + "</td><td colspan='4' style='text-align:left'><b>" + "AD Type:" + "</b>" + adtyp + "</td><td colspan='4' style='text-align:left'><b>" + "Publication Center:" + "</b>" + pubcen + "</td><td colspan='2' style='text-align:right;' valign = 'top'><b>Page No.:" +"</b>"+ pageno + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='3' style='text-align:left'><b>" + "To Date:" + "</b>" + dateto + "</td><td colspan='4' style='text-align:left'><b>" + "UOM:" + "</b>" + uom + "</td><td colspan='4' style='text-align:left'><b>" + "Area:" + "</b>" + area + "</td><td  style='text-align:right'colspan='2' ><b>" + "Rundate:" + "</b>" + rdatefinalhdsmain1 + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='2' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Edition :</b>" + edition_nam + "</td><td colspan='2' style='text-align:left'>" + "" + "</td><td colspan='2' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }

    private string headerex()
    {
        string hdrtbl = "";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/dailymis.xml"));
        hdrtbl = "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;' valign = 'top'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;' valign = 'top'>" + dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td  style='text-align:left'>" + "Rundate:" + rdatefinalhdsmain1 + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='3' style='text-align:left'>" + "From Date:" + fromdt + "To Dade:" + dateto + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='2' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Edition :</b>" + edition_nam + "</td><td colspan='2' style='text-align:left'>" + "" + "</td><td colspan='2' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }

    public string changeformat(string userdate)
    {
        string[] arr = userdate.Split('/');
        string change = arr[1] + "/" + arr[0] + "/" + arr[2];
        return change;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printrow.Attributes.Add("style", "display:none");
        bdy.Attributes.Add("onload", "window.print()");
    }


    private void Excel()
    {

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/dailymis.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {


            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            int sno1 = 0;
            // string tbl = "";
            StringBuilder tbl = new StringBuilder();
            double billamt = 0;
            double rate = 0;
            double total = 0;
            rundate = ds.Tables[1].Rows[0]["CUR_DATE"].ToString();
            rundate = changeformat(rundate);
            string[] tim = rundate.Split(' ');
            string rdate = tim[0];
            string[] rdatehdsmaintds = rdate.Split(' ');
            string hdsmainhjrdate = rdatehdsmaintds[0];
            string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
            string hdsmainhjrdate1 = hdsmainhjrdateS[0];
            string hdsmainhjrdate2 = hdsmainhjrdateS[1];
            string hdsmainhjrdate3 = hdsmainhjrdateS[2];
            rdatefinalhdsmain1 = hdsmainhjrdate1 + '/' + hdsmainhjrdate2 + '/' + hdsmainhjrdate3;
            // companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
            tbl.Append(headerex());
            tbl.Append("<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>");

            tbl.Append("<tr>");
            //tbl.Append("<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[44].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center' width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='9%'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='5%'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>");

            tbl.Append("<td  class='middle31new'align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>");
            tbl.Append("<td  class='middle31new'align='center'width='2%'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='5%'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[12].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[13].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'width='10%'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'width='25%'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>");
            


            // 


            for (p = 0; p < ds.Tables[0].Rows.Count; p++)
            {
                
                sno1++;

                //rundate = DateTime.Parse(ds.Tables[0].Rows[p]["CUR_DATE"].ToString()).ToShortDateString();






                tbl.Append("<tr font-size='10' font-family='Arial'>");
                tbl.Append("<td class='rep_data' width='2%'align='center'>" + sno1 + "</td>");
                tbl.Append("<td class='rep_data' width='9%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["CIOID"].ToString() + "</td>");



                tbl.Append("<td class='rep_data' width='5%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["INSERT_DATE"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["AGENCY_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["REGION_NAME"].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='10%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["CLIENT_NAME"].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='2%' align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["HEIGHT"].ToString() + "</td>");




                tbl.Append("<td class='rep_data' width='2%'align='right' >");
                tbl.Append(ds.Tables[0].Rows[p]["WIDTH"].ToString() + "</td>");



                tbl.Append("<td class='rep_data' width='5%' align='right'>");
                tbl.Append(ds.Tables[0].Rows[p]["SIZE_BOOK"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='left'>");
                tbl.Append(ds.Tables[0].Rows[p]["POS_TYPE_NAME"].ToString() + "</td>");

                tbl.Append("<td class='rep_data' width='10%' align='left'>");
                tbl.Append(ds.Tables[0].Rows[p]["PAGE_PREMIUM_NAME"].ToString() + "</td>");


                tbl.Append("<td class='rep_data' width='10%' align='right'>");
                tbl.Append(ds.Tables[0].Rows[p]["PACKAGE_NAME"].ToString() + "</td>");

             

                tbl.Append("<td class='rep_data' width='25%' align='right'>");
                tbl.Append(ds.Tables[0].Rows[p]["PRINT_REMARK"].ToString() + "</td>");




                //tbl.Append( "<td class='rep_data' width='5%' align='center'>";
                //tbl.Append( "" + "</td>");




                tbl.Append("</tr>");



                rowcounter++;

            }

            // tbl.Append("<tr width='50%'>");
            // tbl.Append("<td class='middle31new'  colspan='5'  align='right'>");
            // tbl.Append(dsxml.Tables[1].Rows[0].ItemArray[11].ToString() + "</td>");

            //tbl.Append("<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>");
            //tbl.Append("<td  class='middle31new'>" + "" + "</td>");
            //tbl.Append("</tr>");

            // tbl.Append( "<tr font-size='10' font-family='Arial'>";
            //totalad = ds.Tables[0].Rows.Count;
            //  alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
            //  nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

            //  tbl.Append( "<tr><td   class='middle31new' colspan='5' align='center' ><b>To be Billed :</b>";
            //  tbl.Append( (totalad - nottobill - alreadybil).ToString() + "</td>");

            //  tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Booked by Others :</b>";
            //  tbl.Append( nottobill.ToString() + "</td>");

            //  tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>";
            //  tbl.Append( alreadybil.ToString() + "</td>");

            //  tbl.Append( "<td   class='middle31new' colspan='5' align='center' ><b>Total Ads :</b>";
            //  tbl.Append( totalad.ToString() + "</td>");


            //  tbl.Append( "</tr>";
            tbl.Append("</table></td></tr></table></p>");

            report.InnerHtml = tbl.ToString();

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
