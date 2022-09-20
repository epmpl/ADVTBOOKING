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



public partial class Reports_BillRegisterchklstsummry : System.Web.UI.Page
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
    string type = "summary";
    int page_count = 0;
    int rowcounter = 0;
    int maxlimit = 30;
    int pgn = 1;
    string orderby = "";
    string sno = "";
    string view = "";
    string rdatefinalhdsmain = "";
    string rdatefinalhdsmain1 = "";
    string reportname = "";
    string companyname = "";
    string Basedon = "";
    string flag = "";
    string extra1 = "";
    string extra2 = ""; 
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
        flag = Request.QueryString["flag"].ToString();
        adtype_nam = Request.QueryString["adtype_nam"].ToString();
        publication_nam = Request.QueryString["publication_nam"].ToString();
        edition_nam = Request.QueryString["edition_nam"].ToString();
        pubcent_nam = Request.QueryString["pubcent_nam"].ToString();

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

        //DataSet ds = new DataSet();
        //ds.ReadXml(Server.MapPath("XML/BillRegister_Chklst.xml"));
        //reportname = ds.Tables[0].Rows[0].ItemArray[13].ToString();
         if (!Page.IsPostBack)
        {
            if (flag == "1")
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
            else if (flag == "2")
            {
                if (view == "0" || view == "1" || view == "")
                {
                    gridbinddetail();
                }
                else
                {
                    gridbind_excel_detail();
                }

            }
            else
            {
                if (view == "0" || view == "1" || view == "")
                {
                  dailyreportdata();
                }
                else
                {
                    dailyreportdataexcel();
                }

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
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {

            int sno1 = 0;
            string tbl = "";
            double billamt = 0;
            double rate = 0;
            double total = 0;
            companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
            tbl = tbl + "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
            tbl = tbl + "<tr><td>";
            tbl += header();
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";

            tbl += "<tr>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
            tbl += "<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
            //tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";

            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
            tbl += "<tr>";


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;

                    tbl += "</table></td><tr></table></p>";
                    tbl = tbl + "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
                    tbl = tbl + "<tr><td>";
                    tbl += header();
                    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr>";
                    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                    tbl += "<td  class='middle31new'align='right'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                    //tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";

                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>";
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>";
                    //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>";
                    tbl += "<tr>";
                }
                // string.Format("{0:0.00}",any object);
                sno1++;

                //rundate = DateTime.Parse(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()).ToShortDateString();
                rundate = ds.Tables[0].Rows[p]["BILL_DATE"].ToString();
                //rundate= changeformat(rundate);
                string[] tim = rundate.Split(' ');
                string rdate = tim[0];
                string[] rdatehdsmaintds = rdate.Split(' ');
                string hdsmainhjrdate = rdatehdsmaintds[0];
                string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
                string hdsmainhjrdate1 = hdsmainhjrdateS[0];
                string hdsmainhjrdate2 = hdsmainhjrdateS[1];
                string hdsmainhjrdate3 = hdsmainhjrdateS[2];

                rdatefinalhdsmain1 = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;



                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='2%'align='center'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='8%' align='center'>";
                tbl += rdatefinalhdsmain1 + "</td>";

                tbl += "<td class='rep_data' width='5%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["FROM_BILLNO"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["TO_BILLNO"].ToString() + "</td>";


                tbl += "<td class='rep_data' width='5%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["NO_OF_BILLS"].ToString() + "</td>";




                tbl += "<td class='rep_data' width='5%'align='right' >";
                if (ds.Tables[0].Rows[p]["TOT_BILLAMT"].ToString() != "")
                    billamt = Convert.ToDouble(string.Format("{0:0.00}", ds.Tables[0].Rows[p]["TOT_BILLAMT"].ToString()));
                total = billamt + total;
                tbl += billamt.ToString("F2") + "</td>";



                tbl += "<td class='rep_data' width='5%' align='right'>";
                tbl += string.Format("{0:0.00}", total) + "</td>";


                //tbl += "<td class='rep_data' width='5%' align='center'>";
                //tbl += "" + "</td>";




                tbl += "</tr>";



                rowcounter++;

            }

            tbl += "<tr width='50%'>";
            tbl += "<td class='middle31new'  colspan='5'  align='right'>";
            tbl += dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";

            tbl += "<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>";
            tbl += "<td  class='middle31new' colspan='2'>" + "" + "</td>";
            tbl += "</tr>";

            // tbl += "<tr font-size='10' font-family='Arial'>";
            //totalad = ds.Tables[0].Rows.Count;
            //  alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
            //  nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

            //  tbl += "<tr><td   class='middle31new' colspan='5' align='center' ><b>To be Billed :</b>";
            //  tbl += (totalad - nottobill - alreadybil).ToString() + "</td>";

            //  tbl += "<td   class='middle31new' colspan='5' align='center' ><b>Booked by Others :</b>";
            //  tbl += nottobill.ToString() + "</td>";

            //  tbl += "<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>";
            //  tbl += alreadybil.ToString() + "</td>";

            //  tbl += "<td   class='middle31new' colspan='5' align='center' ><b>Total Ads :</b>";
            //  tbl += totalad.ToString() + "</td>";


            //  tbl += "</tr>";
            tbl += "</table></td><tr></table></p>";

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
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
            int sno1 = 0;
            string tbl = "";
            double billamt = 0;
            double rate = 0;
            double total = 0;
            // companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
            tbl = tbl + "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='1' align='center' style='vertical-align:top;padding-left:15px;'>";
            tbl = tbl + "<tr><td>";
            tbl += header();
            tbl += "<table width='100%' border='1' cellpadding='0px' cellspacing='0px'>";

            tbl += "<tr>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
            tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
            //tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";

            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
            //tbl += "<td  class='middle31new'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
            // tbl += "<tr>";


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                //if (rowcounter == maxlimit)
                //{
                //    rowcounter = 0;

                //    tbl += "</table></td><tr></table></p>";
                //    tbl = tbl + "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
                //    tbl = tbl + "<tr><td>";
                //    tbl += header();
                //    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                //    tbl += "<tr>";
                //    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[13].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[5].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[6].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[7].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[8].ToString() + "</td>";
                //    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[9].ToString() + "</td>";
                //    tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[10].ToString() + "</td>";
                //    //tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[0].Rows[0].ItemArray[12].ToString() + "</td>";

                //    //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>";
                //    //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>";
                //    //tbl += "<td  class='middle31new'>" + dsxml.Tables[1].Rows[0].ItemArray[9].ToString() + "</td>";
                //    tbl += "<tr>";
                //}
                // string.Format("{0:0.00}",any object);
                sno1++;

                //rundate = DateTime.Parse(ds.Tables[0].Rows[p]["BILL_DATE"].ToString()).ToShortDateString();
                rundate = ds.Tables[0].Rows[p]["BILL_DATE"].ToString();
                //rundate= changeformat(rundate);
                string[] tim = rundate.Split(' ');
                string rdate = tim[0];
                string[] rdatehdsmaintds = rdate.Split(' ');
                string hdsmainhjrdate = rdatehdsmaintds[0];
                string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
                string hdsmainhjrdate1 = hdsmainhjrdateS[0];
                string hdsmainhjrdate2 = hdsmainhjrdateS[1];
                string hdsmainhjrdate3 = hdsmainhjrdateS[2];

                rdatefinalhdsmain1 = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;



                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='2%'align='center'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='8%' align='center'>";
                tbl += rdatefinalhdsmain1 + "</td>";

                tbl += "<td class='rep_data' width='5%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["FROM_BILLNO"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='8%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["TO_BILLNO"].ToString() + "</td>";


                tbl += "<td class='rep_data' width='5%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["NO_OF_BILLS"].ToString() + "</td>";




                tbl += "<td class='rep_data' width='5%'align='right' >";
                if (ds.Tables[0].Rows[p]["TOT_BILLAMT"].ToString() != "")
                    billamt = Convert.ToDouble(string.Format("{0:0.00}", ds.Tables[0].Rows[p]["TOT_BILLAMT"].ToString()));
                total = billamt + total;
                tbl += billamt.ToString("F2") + "</td>";



                tbl += "<td class='rep_data' width='5%' align='right'>";
                tbl += string.Format("{0:0.00}", total) + "</td>";


                //tbl += "<td class='rep_data' width='5%' align='center'>";
                //tbl += "" + "</td>";




                tbl += "</tr>";



                rowcounter++;

            }

            tbl += "<tr width='50%'>";
            tbl += "<td class='middle31new'  colspan='5'  align='right'>";
            tbl += dsxml.Tables[0].Rows[0].ItemArray[11].ToString() + "</td>";

            tbl += "<td  class='middle31new' align='right'>" + string.Format("{0:0.00}", total) + "</td>";
            tbl += "<td  class='middle31new'>" + "" + "</td>";
            tbl += "</tr>";

            // tbl += "<tr font-size='10' font-family='Arial'>";
            //totalad = ds.Tables[0].Rows.Count;
            //  alreadybil = Convert.ToInt32(ds.Tables[4].Rows[0]["ALREADY_BILLED"].ToString());
            //  nottobill = Convert.ToInt32(ds.Tables[4].Rows[0]["BOOKED_BY_OTHERS"].ToString());

            //  tbl += "<tr><td   class='middle31new' colspan='5' align='center' ><b>To be Billed :</b>";
            //  tbl += (totalad - nottobill - alreadybil).ToString() + "</td>";

            //  tbl += "<td   class='middle31new' colspan='5' align='center' ><b>Booked by Others :</b>";
            //  tbl += nottobill.ToString() + "</td>";

            //  tbl += "<td   class='middle31new' colspan='5' align='center' ><b>Already Billed :</b>";
            //  tbl += alreadybil.ToString() + "</td>";

            //  tbl += "<td   class='middle31new' colspan='5' align='center' ><b>Total Ads :</b>";
            //  tbl += totalad.ToString() + "</td>";


            //  tbl += "</tr>";
            tbl += "</table></td></tr></table></p>";

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

    private string header()
    {
        string hdrtbl = "";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;' valign = 'top'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + dsxml.Tables[0].Rows[0].ItemArray[14].ToString() + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td  colspan='2' style='text-align:left'>" + dsxml.Tables[0].Rows[0].ItemArray[4].ToString() + rdatefinalhdsmain + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='3' style='text-align:left'>" + dsxml.Tables[0].Rows[0].ItemArray[0].ToString() + fdate + dsxml.Tables[0].Rows[0].ItemArray[1].ToString() + tdate + "</td></tr>";


        //hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + companyname + "</td></tr>";
        //hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + reportname + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='2' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='2' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
        
        
        
        
        
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'>" + adtype_nam + "</td><td colspan='2' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='2' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>Edition :</b>" + edition_nam + "</td><td colspan='2' style='text-align:left'>" + "" + "</td><td colspan='2' style='text-align:right'>" + "" + "</td></tr>";
        // hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>ToDate :</b>" + tdate + "</td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printrow.Attributes.Add("style", "display:none");
        bdy.Attributes.Add("onload", "window.print()");
    }

    public string changeformat(string userdate)
    {
        string[] arr = userdate.Split('/');
        string change = arr[1] + "/" + arr[0] + "/" + arr[2];
        return change;
    }

    public void gridbinddetail()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
  NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
ds = obj.getbillregisterrec_chklst_detail(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        else
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.getbillregisterrec_chklst_detail(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            int sno1 = 0;
            string tbl = "";
            double fmgadd = 0;
            double directcash = 0;
            double normaladds = 0;
             double secemads = 0;
            double inhouseadd = 0;
            double fmgaddtot = 0;
            double directcashtot = 0;
            double normaladdstot = 0;
            double secemadstot = 0;
            double inhouseaddtot = 0;
            double totaltot = 0;
            double dummyads= 0;
            double dummyatot = 0;
        
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            tbl = tbl + "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
            tbl = tbl + "<tr><td>";
            tbl += headerdetail();
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";

            tbl += "<tr>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
            tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>";       
               
            tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
            tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>";
       
            tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>";
       
            tbl += "<tr>";


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                if (rowcounter == maxlimit)
                {
                    rowcounter = 0;

                    tbl += "</table></td><tr></table></p>";
                    tbl = tbl + "<p style='PAGE-BREAK-BEFORE: always'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
                    tbl = tbl + "<tr><td>";
                    pgn = pgn + 1;
                        
                    tbl += headerdetail();
                    tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
                    tbl += "<tr>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[7].ToString() + "</td>";       
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[10].ToString() + "</td>";
       
                    tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[8].ToString() + "</td>";
       
                      tbl += "<tr>";
                }
                 sno1++;

                rundate = DateTime.Parse(ds.Tables[0].Rows[p]["BILLDATE"].ToString()).ToShortDateString();
                string[] tim = rundate.Split(' ');
                string rdate = tim[0];
                string[] rdatehdsmaintds = rdate.Split(' ');
                string hdsmainhjrdate = rdatehdsmaintds[0];
                string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
                string hdsmainhjrdate1 = hdsmainhjrdateS[0];
                string hdsmainhjrdate2 = hdsmainhjrdateS[1];
                string hdsmainhjrdate3 = hdsmainhjrdateS[2];
                rdatefinalhdsmain1 = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;


                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='5%'align='center'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += rdatefinalhdsmain1 + "</td>";

                tbl += "<td class='rep_data' width='15%'  align='center' >";
                tbl += ds.Tables[0].Rows[p]["FMG_ADS"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["FMG_ADS"].ToString()!="")
                {
                    fmgadd = Convert.ToDouble(ds.Tables[0].Rows[p]["FMG_ADS"].ToString());
                    fmgaddtot = fmgaddtot + Convert.ToDouble(ds.Tables[0].Rows[p]["FMG_ADS"].ToString());
                }

                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["NORMAL_ADS"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["NORMAL_ADS"].ToString() != "")
                {
                    normaladds = Convert.ToDouble(ds.Tables[0].Rows[p]["NORMAL_ADS"].ToString());
                    normaladdstot = normaladdstot + Convert.ToDouble(ds.Tables[0].Rows[p]["NORMAL_ADS"].ToString());

                }
                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["SCHEME_ADS"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["SCHEME_ADS"].ToString() != "")
                {
                    secemads = Convert.ToDouble(ds.Tables[0].Rows[p]["SCHEME_ADS"].ToString());
                    secemadstot = secemadstot + Convert.ToDouble(ds.Tables[0].Rows[p]["SCHEME_ADS"].ToString());

                }
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["DIRECT_CASH"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["DIRECT_CASH"].ToString() != "")
                {
                    directcash = Convert.ToDouble(ds.Tables[0].Rows[p]["DIRECT_CASH"].ToString());
                    directcashtot = directcashtot + Convert.ToDouble(ds.Tables[0].Rows[p]["DIRECT_CASH"].ToString());
                }
                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["INHOUSE_ADS"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["INHOUSE_ADS"].ToString() != "")
                {
                    inhouseadd = Convert.ToDouble(ds.Tables[0].Rows[p]["INHOUSE_ADS"].ToString());
                    inhouseaddtot = inhouseaddtot + Convert.ToDouble(ds.Tables[0].Rows[p]["INHOUSE_ADS"].ToString());
                }

                tbl += "<td class='rep_data' width='10%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["BOOK_FOR_DUMMY"].ToString() + "</td>";
                if (ds.Tables[0].Rows[p]["BOOK_FOR_DUMMY"].ToString() != "")
                {
                    dummyads = Convert.ToDouble(ds.Tables[0].Rows[p]["BOOK_FOR_DUMMY"].ToString());
                    dummyatot = dummyatot + Convert.ToDouble(ds.Tables[0].Rows[p]["BOOK_FOR_DUMMY"].ToString());
                }
                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += (fmgadd + normaladds + secemads + directcash + inhouseadd + dummyads).ToString() + "</td>";
            
                tbl += "</tr>";



                rowcounter++;

            }

            tbl += "<tr font-size='10' font-family='Arial'align='right'>";
            tbl += "<td class='middle31new'  colspan='2'>&nbsp;</td>";
            tbl += "<td class='middle31new' align='left' colspan='1'>Fmg Ads Tot:-" + fmgaddtot + "</td>";
            tbl += "<td class='middle31new' align='left'  colspan='1'>Normal Ads Tot:-" + normaladdstot + "</td>";
            tbl += "<td class='middle31new' align='left'  colspan='1'>Scheme Ads Tot:-" + secemadstot + "</td>";
            tbl += "<td class='middle31new' align='left'  colspan='1'>Cash Ads Tot:-" + directcashtot + "</td>";
            tbl += "<td class='middle31new' align='left' colspan='1'>In house Ads Tot:-" + inhouseaddtot + "</td>";
            tbl += "<td class='middle31new' align='left' colspan='1'>Dummy Ads Tot:-" + dummyatot + "</td>";
         
            tbl += "<td class='middle31new' align='left'  colspan='1'>Total Ads:-";
            tbl += (fmgaddtot + normaladdstot + secemadstot + directcashtot + inhouseaddtot + dummyatot).ToString() + "</td>";

            tbl += "</tr>";



                 tbl += "</table></td><tr></table></p>";

            report.InnerHtml = tbl;

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
        }

    }
    private string headerdetail()
    {
        string hdrtbl = "";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;' valign = 'top'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='2' style='text-align:left'></td><td colspan='2' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>To Date :</b>" + tdate + "</td><td colspan='2' style='text-align:left'></td><td colspan='2' style='text-align:right'><b>Page No.:</b>" + pgn + "</td></tr>";
      
        hdrtbl += "</table>";
        return hdrtbl;
    }
    private string headerdetailexcel()
    {
        string hdrtbl = "";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center;' valign = 'top'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='6' style='text-align:center'>" + dsxml.Tables[1].Rows[0].ItemArray[6].ToString() + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='2' style='text-align:left'></td><td colspan='2' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='2' style='text-align:left'><b>To Date :</b>" + tdate + "</td><td colspan='2' style='text-align:left'></td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }
    public void gridbind_excel_detail()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
            // ds = obj.getbillregisterrec_chklst_detail(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        else
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.getbillregisterrec_chklst_detail(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            int sno1 = 0;
            string tbl = "";
            double billamt = 0;
            double rate = 0;
            double total = 0;
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            tbl = tbl + "<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>";
            tbl = tbl + "<tr><td>";
            tbl += headerdetailexcel();
            tbl += "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";

            tbl += "<tr>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[0].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[5].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[1].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[2].ToString() + "</td>";
            tbl += "<td  class='middle31new'align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[3].ToString() + "</td>";
            tbl += "<td  class='middle31new' align='center'>" + dsxml.Tables[1].Rows[0].ItemArray[4].ToString() + "</td>";
            tbl += "<tr>";


            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                sno1++;

                rundate = DateTime.Parse(ds.Tables[0].Rows[p]["BILLDATE"].ToString()).ToShortDateString();
                string[] tim = rundate.Split(' ');
                string rdate = tim[0];
                string[] rdatehdsmaintds = rdate.Split(' ');
                string hdsmainhjrdate = rdatehdsmaintds[0];
                string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
                string hdsmainhjrdate1 = hdsmainhjrdateS[0];
                string hdsmainhjrdate2 = hdsmainhjrdateS[1];
                string hdsmainhjrdate3 = hdsmainhjrdateS[2];
                rdatefinalhdsmain1 = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;


                tbl += "<tr font-size='10' font-family='Arial'>";
                tbl += "<td class='rep_data' width='5%'align='center'>" + sno1 + "</td>";

                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += rdatefinalhdsmain1 + "</td>";

                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["FMG_ADS"].ToString() + "</td>";

                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["NORMAL_ADS"].ToString() + "</td>";


                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["SCHEME_ADS"].ToString() + "</td>";




                tbl += "<td class='rep_data' width='15%' align='center'>";
                tbl += ds.Tables[0].Rows[p]["INHOUSE_ADS"].ToString() + "</td>";



                tbl += "</tr>";



                rowcounter++;

            }



            tbl += "</table></td><tr></table></p>";

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


    public void dailyreportdataexcel()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
             NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
             //ds = obj.dailyreportdata(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
          //   ds = obj.dailyreportdata(dpaddtype, fdate, tdate, Session["compcode"].ToString(), dppubcent, branch, Session["dateformat"].ToString(), Agencytype, ratecod, uom, Session["userid"].ToString(), Session["access"].ToString(), Basedon, extra2);
        }
        else
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.dailyreportdata(dpaddtype, fdate, tdate, Session["compcode"].ToString(), dppubcent, branch, Session["dateformat"].ToString(), Agencytype, ratecod, uom, Session["userid"].ToString(), Session["access"].ToString(), Basedon, extra2);
    
        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        double amountbill = 0;
        double areatotal = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.Charset = "UTF-8";
            Response.ContentType = "text/csv";
            Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");

            int sno1 = 0;
            //string tbl = "";
            StringBuilder tbl = new StringBuilder();
      
            double billamt = 0;
            double rate = 0;
            double total = 0;
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
            tbl.Append(headerdetailexceldaily());
            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[0].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[10].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[11].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[12].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[13].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[14].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[2].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[43].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[15].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[16].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[17].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[21].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[22].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[49].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[50].ToString() + "</td>");
        
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[25].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[24].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[26].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[46].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[28].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[29].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[30].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[31].ToString() + "</td>");
           
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[32].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[27].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[33].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[5].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[6].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[7].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[8].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[34].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[36].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[37].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[44].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[38].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[45].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[39].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[40].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[41].ToString() + "</td>");


            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[4].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[23].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[47].ToString() + "</td>");

               // tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[35].ToString() + "</td>");

            // tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[42].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[48].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[51].ToString() + "</td>");

            tbl.Append("<tr>");



            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                sno1++;



                tbl.Append("<tr font-size='10' font-family='Arial'>");
                tbl.Append("<td class='rep_data' align='center'>" + sno1 + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["cioid"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                string insdate = ds.Tables[0].Rows[p]["insdate"].ToString();
                if (insdate.IndexOf(' ') > -1)
                {
                    string[] insdate1 = insdate.Split(' ');
                    string[] insdate2 = insdate1[0].Split('/');
                    string mo = insdate2[0];
                    string da = insdate2[1];
                    string ye = insdate2[2];
                    if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                    {
                        insdate = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                    }
                    else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                    {

                        insdate = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                    }
                    else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                    {

                        insdate = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                    }

                }
                tbl.Append((insdate + "</td>"));

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["bill_no"].ToString() + "</td>");
                tbl.Append("<td class='rep_data'  align='center'>");
                string datewise = ds.Tables[0].Rows[p]["bill_date"].ToString();
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
                tbl.Append((datewise + "</td>"));

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["ro_no"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                string rodate = ds.Tables[0].Rows[p]["ro_date"].ToString();
                if (rodate.IndexOf(' ') > -1)
                {
                    string[] rodate1 = rodate.Split(' ');
                    string[] rodate2 = rodate1[0].Split('/');
                    string mo = rodate2[0];
                    string da = rodate2[1];
                    string ye = rodate2[2];
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

                }
                tbl.Append((rodate + "</td>"));


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["agency_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["trade_disc"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["client_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["uom_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["height"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["width"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["size_book"].ToString() + "</td>");
                if (ds.Tables[0].Rows[p]["width"].ToString() != "")
                {
                    areatotal = areatotal + Convert.ToDouble(ds.Tables[0].Rows[p]["size_book"].ToString());
                }

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["word"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["card_rate"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["special_disc_per"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["insert_discount"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["page_prem"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["page_position"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["translation_charges"].ToString() + "</td>");
                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["gross_amt"].ToString() + "</td>");



                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["agreed_rate"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["offer_page_premium"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["offer_posi_premium"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["translation_disc"].ToString() + "</td>");
               


          

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["agreed_amt"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["bill_amt"].ToString() + "</td>");
                if (ds.Tables[0].Rows[p]["bill_amt"].ToString() != "")
                {
                    amountbill = amountbill + Convert.ToDouble(ds.Tables[0].Rows[p]["bill_amt"].ToString());
                }
                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["package_code"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["industry_name"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["brand_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["product_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["varient_name"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["regionname"].ToString() + "</td>");

                //  tbl.Append("<td class='rep_data'  align='center'>");
                // tbl.Append(ds.Tables[0].Rows[p]["city_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["ag_city"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["executive_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["exec_city_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["retainer_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["retain_city_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["team_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["color_code"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["page_no"].ToString() + "</td>");



                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["cat_name"].ToString() + "</td>");








                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["rate_code"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["eye_catcher"].ToString() + "</td>");

                    //tbl.Append("<td class='rep_data'  align='center'>");
                // tbl.Append(ds.Tables[0].Rows[p]["page_position_code"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["ledger_agency"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["print_remark"].ToString() + "</td>");



                tbl.Append("</tr>");



                rowcounter++;
            }
            tbl.Append("<tr >");

            tbl.Append("<td  class='middle31new' colspan='13'>" + "" + "Total</td>");

            tbl.Append("<td class='middle31new'  colspan='1'  align='center'>");
            tbl.Append(areatotal.ToString() + "</td>");
            tbl.Append("<td  class='middle31new' colspan='13'>" + "" + "</td>");
            tbl.Append("<td class='middle31new'  colspan='1'  align='center'>");
            tbl.Append(amountbill.ToString() + "</td>");
            tbl.Append("<td  class='middle31new' colspan='20'>" + "" + "</td>");

            tbl.Append("</tr>");



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

    }
    public void dailyreportdata()
    {

        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
             NewAdbooking.Report.Classes.AttendenceRegister obj = new NewAdbooking.Report.Classes.AttendenceRegister();
             //ds = obj.getbillregisterrec_chklst_detail(fdate, tdate, Session["compcode"].ToString(), dppub1, branch, dpedition, dppubcent, dpaddtype, Session["dateformat"].ToString(), Session["userid"].ToString(), Session["access"].ToString(), Agencytype, ratecod, uom, Basedon, type);
             ds = obj.dailyreportdata(dpaddtype, fdate, tdate, Session["compcode"].ToString(), dppubcent, branch, Session["dateformat"].ToString(), Agencytype, ratecod, uom, Session["userid"].ToString(), Session["access"].ToString(), Basedon, extra2);
        }
        else
        {
            NewAdbooking.Report.classesoracle.AttendenceRegister obj = new NewAdbooking.Report.classesoracle.AttendenceRegister();
            ds = obj.dailyreportdata(dpaddtype, fdate, tdate, Session["compcode"].ToString(), dppubcent, branch, Session["dateformat"].ToString(), Agencytype, ratecod, uom, Session["userid"].ToString(), Session["access"].ToString(), Basedon, extra2);

        }
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        string showothercentdata = "N";
        int totalad = 0;
        int tobebilled = 0;
        int nottobill = 0;
        int alreadybil = 0;
        double amountbill = 0;
        double areatotal = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
           
            int sno1 = 0;
            //string tbl = "";
            StringBuilder tbl = new StringBuilder();

            double billamt = 0;
            double rate = 0;
            double total = 0;
            companyname = ds.Tables[0].Rows[0]["COMP_NAME"].ToString();
            tbl.Append("<p><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='center' style='vertical-align:top;padding-left:15px;'>");
            tbl.Append("<tr><td>");
            tbl.Append(headerdetailexceldaily());
            tbl.Append("<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>");

            tbl.Append("<tr>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[0].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[9].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[10].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[11].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[12].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[13].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[14].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[1].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[2].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[3].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[43].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[15].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[16].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[17].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[21].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[22].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[49].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[50].ToString() + "</td>");
         
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[25].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[24].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[26].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[46].ToString() + "</td>");
 
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[28].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[29].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[30].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[31].ToString() + "</td>");
          
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[32].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[27].ToString() + "</td>");
       
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[33].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[5].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[6].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[7].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[8].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[34].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[36].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[37].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[44].ToString() + "</td>");

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[38].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[45].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[39].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[40].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[41].ToString() + "</td>");
       

            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[4].ToString() + "</td>");
                  tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[23].ToString() + "</td>");
                  
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[47].ToString() + "</td>");

          
               // tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[35].ToString() + "</td>");
             
                // tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[42].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[48].ToString() + "</td>");
            tbl.Append("<td  class='middle31new' align='center'>" + dsxml.Tables[2].Rows[0].ItemArray[51].ToString() + "</td>");
         
            tbl.Append("<tr>");



            for (int p = 0; p < ds.Tables[0].Rows.Count; p++)
            {

                sno1++;



                tbl.Append("<tr font-size='10' font-family='Arial'>");
                tbl.Append("<td class='rep_data' align='center'>" + sno1 + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["cioid"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                string insdate = ds.Tables[0].Rows[p]["insdate"].ToString();
                if (insdate.IndexOf(' ') > -1)
                {
                    string[] insdate1 = insdate.Split(' ');
                    string[] insdate2 = insdate1[0].Split('/');
                    string mo = insdate2[0];
                    string da = insdate2[1];
                    string ye = insdate2[2];
                    if (Session["dateformat"].ToString() == "dd/mm/yyyy")
                    {
                        insdate = RETURN_LENGTH(da) + "/" + RETURN_LENGTH(mo) + "/" + ye;
                    }
                    else if (Session["dateformat"].ToString() == "mm/dd/yyyy")
                    {

                        insdate = RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da) + "/" + ye;
                    }
                    else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
                    {

                        insdate = ye + "/" + RETURN_LENGTH(mo) + "/" + RETURN_LENGTH(da);
                    }

                }
                tbl.Append((insdate + "</td>"));

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["bill_no"].ToString() + "</td>");
                tbl.Append("<td class='rep_data'  align='center'>");
                string datewise = ds.Tables[0].Rows[p]["bill_date"].ToString();
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
                tbl.Append((datewise + "</td>"));

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["ro_no"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                string rodate = ds.Tables[0].Rows[p]["ro_date"].ToString();
                if (rodate.IndexOf(' ') > -1)
                {
                    string[] rodate1 = rodate.Split(' ');
                    string[] rodate2 = rodate1[0].Split('/');
                    string mo = rodate2[0];
                    string da = rodate2[1];
                    string ye = rodate2[2];
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

                }
                tbl.Append((rodate + "</td>"));


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["agency_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["trade_disc"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["client_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["uom_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["height"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["width"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["size_book"].ToString() + "</td>");
                if (ds.Tables[0].Rows[p]["width"].ToString()!="")
                {
                areatotal = areatotal + Convert.ToDouble(ds.Tables[0].Rows[p]["size_book"].ToString());
                }

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["word"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["card_rate"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["special_disc_per"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["insert_discount"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["page_prem"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["page_position"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["translation_charges"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["gross_amt"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["agreed_rate"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["offer_page_premium"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["offer_posi_premium"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["translation_disc"].ToString() + "</td>");

              
                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["agreed_amt"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["bill_amt"].ToString() + "</td>");
                if (ds.Tables[0].Rows[p]["bill_amt"].ToString()!="")
                {
                amountbill = amountbill + Convert.ToDouble(ds.Tables[0].Rows[p]["bill_amt"].ToString());
                }

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["package_code"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["industry_name"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["brand_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["product_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["varient_name"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["regionname"].ToString() + "</td>");

                //  tbl.Append("<td class='rep_data'  align='center'>");
                // tbl.Append(ds.Tables[0].Rows[p]["city_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["ag_city"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["executive_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["exec_city_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["retainer_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["retain_city_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["team_name"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["color_code"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["page_no"].ToString() + "</td>");



                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["cat_name"].ToString() + "</td>");






              
               
                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["rate_code"].ToString() + "</td>");

              
                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["eye_catcher"].ToString() + "</td>");

               
              
               
                //tbl.Append("<td class='rep_data'  align='center'>");
                // tbl.Append(ds.Tables[0].Rows[p]["page_position_code"].ToString() + "</td>");


                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["ledger_agency"].ToString() + "</td>");

                tbl.Append("<td class='rep_data'  align='center'>");
                tbl.Append(ds.Tables[0].Rows[p]["print_remark"].ToString() + "</td>");


                tbl.Append("</tr>");



                rowcounter++;

            }
            tbl.Append("<tr >");

             tbl.Append("<td  class='middle31new' colspan='12'>" + "" + "Total</td>");

            tbl.Append("<td class='middle31new'  colspan='2'  align='center'>");
            tbl.Append(areatotal.ToString() + "</td>");
            tbl.Append("<td  class='middle31new' colspan='13'>" + "" + "</td>");
            tbl.Append("<td class='middle31new'  colspan='2'  align='center'>");
            tbl.Append(amountbill.ToString() + "</td>");
            tbl.Append("<td  class='middle31new' colspan='20'>" + "" + "</td>");

            tbl.Append("</tr>");

            tbl.Append("</table></td><tr></table></p>");

            report.InnerHtml = tbl.ToString();
          

        }
        else
        {
            Response.Write("<script>alert('Searching Criteria is not valid.');window.close();</script>");
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
    private string headerdetailexceldaily()
    {
        string hdrtbl = "";
        DataSet dsxml = new DataSet();
        dsxml.ReadXml(Server.MapPath("XML/biilingregitersummary.xml"));
        hdrtbl = "<table width='100%' border='0' cellpadding='0px' cellspacing='0px'>";
        hdrtbl += "<tr class='headingc'><td colspan='47' style='text-align:center;' valign = 'top'>" + companyname + "</td></tr>";
        hdrtbl += "<tr class='headingc'><td colspan='47' style='text-align:center'>" + dsxml.Tables[0].Rows[0].ItemArray[15].ToString() + "</td></tr>";

        hdrtbl += "<tr class='middle33'><td colspan='20' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='20' style='text-align:left'><b>ToDate :</b>" + tdate + "</td><td colspan='7' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        hdrtbl += "<tr class='middle33'><td colspan='20' style='text-align:left'><b>AdType :</b>" + adtype_nam + "</td><td colspan='20' style='text-align:left'><b>Publication :</b>" + publication_nam + "</td><td colspan='7' style='text-align:right'><b>Publication Center :</b>" + pubcent_nam + "</td></tr>";
 
        
        
        
        //hdrtbl += "<tr class='middle33'><td colspan='20' style='text-align:left'><b>From Date :</b>" + fdate + "</td><td colspan='20' style='text-align:left'></td><td colspan='7' style='text-align:right'><b>Run Date :</b>" + rdatefinalhdsmain + "</td></tr>";
        //hdrtbl += "<tr class='middle33'><td colspan='20' style='text-align:left'><b>To Date :</b>" + tdate + "</td><td colspan='20' style='text-align:left'></td></tr>";

        hdrtbl += "</table>";
        return hdrtbl;
    }

}
