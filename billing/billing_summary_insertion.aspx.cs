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
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using System.Data.OracleClient;
using iTextSharp.text.pdf;
using System.Drawing.Printing;
using System.Diagnostics.Design;
using System.Diagnostics;
//using iTextSharp.text.pdf.codec.wmf;


public partial class billing_summary_insertion : System.Web.UI.Page
{
    string client = "";
    string dtformat = "";
    string todate = "";
    string fromdt = "";
    string pub = "";
    string bkcen = "";
    string rev = "";
    string agtype = "";
    string pckg = "";
    string adtyp = "";
    string ag = "";

    string billstate = "";
    string rtaudit = "";
    string blmod = "";
    string blcycle = "";
    decimal area = 0;
    int i1 = 1;
    double amt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        dtformat = Request.QueryString["dtformat"].ToString();
        todate = Request.QueryString["todate"].ToString();
        fromdt = Request.QueryString["fromdt"].ToString();
        pub = Request.QueryString["pub"].ToString();
        bkcen = Request.QueryString["bkcen"].ToString();
        rev = Request.QueryString["rev"].ToString();
        agtype = Request.QueryString["agtype"].ToString();
        pckg = Request.QueryString["pckg"].ToString();
        adtyp = Request.QueryString["adtyp"].ToString();
        ag = Request.QueryString["ag"].ToString();
        client = Request.QueryString["client"].ToString();
        billstate = Request.QueryString["billstate"].ToString();
        rtaudit = Request.QueryString["rtaudit"].ToString();
        blmod = Request.QueryString["blmod"].ToString();
        blcycle = Request.QueryString["blcycle"].ToString();

        //onscreen(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString());

        onscreen(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());


    }
    private void onscreen(string dtformat, string todate, string fromdt, string pub, string bkcen, string rev, string agtype, string pckg, string adtyp, string ag, string client, string billstate, string rtaudit, string blmod, string blcycle, string comp_code, string userid)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {

            NewAdbooking.BillingClass.Classes.billing_save abc = new NewAdbooking.BillingClass.Classes.billing_save();
            ds = abc.summary_insertion(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = abc.summary_insertion(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle);

        }
        else
        {
        }
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='0' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";






        tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>BOOKING_ID</td><td class='middle31'>Ins.No</td><td class='middle31'>Ro.No</td><td class='middle31'>H</td><td class='middle31'>W</td><td class='middle31'>Size</td><td class='middle31'>Edition</td><td class='middle31'>Client</td><td class='middle31'>Agency</td><td class='middle31'>City</td><td class='middle31'>Commission</td><td class='middle31'>SpDis%</td><td class='middle31'>premium</td><td class='middle31'>Spl.Dis</td><td class='middle31'>BoxCh.</td><td class='middle31'>BillStatus</td><td class='middle31'>GrossRate</td><td class='middle31'>BillAmt</td><td class='middle31'>Ag.Rt.</td><td class='middle31'>CardRt.</td><td class='middle31'>RoDt.</td></tr>");












        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'  >");
            tbl = tbl + (i1++.ToString() + "</td>");
            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Cio_Booking_Id"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["no_of_insertion"] + "</td>");


            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RO_No"] + "</td>");



            tbl = tbl + ("<td class='rep_data'  align='right' >");
            tbl = tbl + (ds.Tables[0].Rows[i]["Height"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Width"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Size_Book"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["edition"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["client"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");

            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency_City"] + "</td>");





            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Commission"] + "</td>");


            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Special_disc_per"] + "</td>");
      
      
      
            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Premium1"] + "</td>");


            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Special_discount"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Box_charges"] + "</td>");








            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["status"] + "</td>");


            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Gross_Rate"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Bill_Amt"] + "</td>");



            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agreed_Rate"] + "</td>");


             tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Card_Rate"] + "</td>");

            tbl = tbl + ("<td class='rep_data'  align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["RO_Date"] + "</td>");



         


       







     





            tbl = tbl + "</tr>";

        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='rep_data'>Total:-</td>");
        tbl = tbl + ("<td class='rep_data''>");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");

        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;

    }
}
