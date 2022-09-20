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

public partial class billing_summary_monthly : System.Web.UI.Page
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
    int i;
    int i1 = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Ajax.Utility.RegisterTypeForAjax(typeof(billing_summary_monthly));
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
        DataSet ds1 = new DataSet();

        onscreen(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, blcycle, Session["compcode"].ToString(), Session["userid"].ToString());

    }
    private void onscreen(string dtformat, string todate, string fromdt, string pub, string bkcen, string rev, string agtype, string pckg, string adtyp, string ag, string client, string billstate, string rtaudit, string blmod, string blcycle, string comp_code, string userid)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            // NewAdbooking.Classes.Class1 obj = new NewAdbooking.Classes.Class1();
            //ds = obj.spfun(adtyp, adcat, fromdt, dateto, publ, pubcen, Session["compcode"].ToString(), edition, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.billing_save abc = new NewAdbooking.BillingClass.classesoracle.billing_save();
            ds = abc.MONTHREPORT(dtformat, todate, fromdt, pub, bkcen, rev, agtype, pckg, adtyp, ag, client, billstate, rtaudit, blmod, Session["compcode"].ToString());
        }
        else
        {
        }
        int cont = ds.Tables[0].Rows.Count;
        //dscount.Value = ds.Tables[0].Rows.Count;
        string tbl = "";
        tbl = "<table width='100%'align='left' cellpadding='0' cellspacing='0'>";
        tbl = tbl + "<tr><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td><td class='middle4' width='4px'>-</td></tr>";






        tbl = tbl + ("<tr><td class='middle31'>S.No.</td><td class='middle31'>Agency</td><td class='middle31'>BillStatus</td><td class='middle31'>GrossRate</td><td class='middle31'>Commission</td></tr>");












        for (int i = 0; i <= cont - 1; i++)
        {
            tbl = tbl + ("<tr >");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (i1++.ToString() + "</td>");









            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Agency"] + "</td>");


            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["client"] + "</td>");

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Agency_City"] + "</td>");



          
            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Premium1"] + "</td>");


            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Special_discount"] + "</td>");

            //tbl = tbl + ("<td class='rep_data'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Box_charges"] + "</td>");


            tbl = tbl + ("<td class='rep_data'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["Status"] + "</td>");


            tbl = tbl + ("<td class='rep_data' align='right'>");
            tbl = tbl + (ds.Tables[0].Rows[i]["TotalAmount"] + "</td>");


            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Bill_amount"] + "</td>");

            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Commission"] + "</td>");



            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Agreed_amount"] + "</td>");

            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Card_rate"] + "</td>");










        


            //tbl = tbl + ("<td class='rep_data' align='right'>");
            //tbl = tbl + (ds.Tables[0].Rows[i]["Special_disc_per"] + "</td>");





















            tbl = tbl + "</tr>";

        }
        tbl = tbl + ("<tr >");
        tbl = tbl + "<tr><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle14' width='3px'>-</td><td class='middle4' width='4px'>-</td></tr>";
        tbl = tbl + ("<tr >");
        tbl = tbl + ("<td class='rep_data'>Total-</td>");
        tbl = tbl + ("<td class='rep_data' >");
        tbl = tbl + ((i1 - 1).ToString() + "</td>");
        tbl = tbl + ("<td class='middle13'>");

        tbl = tbl + "</tr>";

        tbl = tbl + ("</table>");
        tblgrid.InnerHtml = tbl;

    }
}
