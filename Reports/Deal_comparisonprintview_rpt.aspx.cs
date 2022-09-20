using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

public partial class Deal_comparisonprintview_rpt : System.Web.UI.Page
{
    int maxlimit = 4;
    int rowcounter = 0;
    string pdateformat = "";
    string all = "";
    string destination = "";
    string comp_code = "";
    string dateformat = "";
    string from_dt = "";
    string to_dt = "";
    string client = "";
    string product = "";
    string city = "";
    string agency = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string extra5 = "";
    string extra6 = "";
    int sr = 1;
    string rdate = "";
    string schemename = "";
    int chequecount = 0;
    string client_code = "";
    string product_code = "";
    string agency_code = "";
    Double total = 0;
    DataSet ds1 = new DataSet();
    Double rundate = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        pdateformat = Session["dateformat"].ToString();
        comp_code = Session["compcode"].ToString();
        dateformat = Session["dateformat"].ToString();
        destination = Request.QueryString["destination"].ToString();
        //dateformat = Session["dateformat"].ToString();
        from_dt = Request.QueryString["fromdate"].ToString();
        to_dt = Request.QueryString["todate"].ToString();
        product = Request.QueryString["product"].ToString();
        client = Request.QueryString["client"].ToString();
        //city = Request.QueryString["city"].ToString();
        agency = Request.QueryString["agency"].ToString();
        agency_code = Request.QueryString["agency_code"].ToString();
        product_code = Request.QueryString["product_code"].ToString();
        client_code = Request.QueryString["client_code"].ToString();

        //txtcomp1.Value = Session["compcode"].ToString();    
        rdate = System.DateTime.Now.ToString();
        //schemename = Request.QueryString["schemename"].ToString();
        ds1.ReadXml(Server.MapPath("Xml/Deal_comparison_rpt.xml"));
        if (!Page.IsPostBack)
        {
            if (destination == "0" || destination == "1")
            {
                showreport();
            }

            if (destination == "2")
            {
                //showreportexcel();
            }

        }

    }
    public string createheader()
    {
        StringBuilder HEADER = new StringBuilder();
        HEADER.Append("<table cellspacing='0px' cellpadding = '0px' border='0' width='20%'>");
        HEADER.Append("<tr><td  class='newfont1' align='CENTER' style='font-size:16px;' ><b>" + "GUJRAAT" + "</b></td>");
        HEADER.Append("</tr>");
        //HEADER.Append("<tr><td>");
        HEADER.Append("</table>");
        HEADER.Append("<table>");
        //TBL.Append("<tr><td class='newfont1' width='400px' align='left' > LOCATION: " + Session["centername"].ToString() + "</td>");
        HEADER.Append("<tr>");
        HEADER.Append("<td class='middle312' width='200px' align='left' > FROM DATE: " + from_dt + "</td>");
        HEADER.Append("<td class='middle312' width='750px' align='right' > TO DATE: " + to_dt + "</td>");
        HEADER.Append("</tr>");
        HEADER.Append("</table>");
        HEADER.Append("<table>");
        HEADER.Append("<tr><td class='middle312' width='400px' align='left' > AGENCY :" + Request.QueryString["agency"].ToString() + "</TD>");
        //////TBL.Append("<td class='newfont1' width='200px' align='left' > FROM DATE: " + fromdate + "</td>");
        //TBL.Append("<td class='newfont1' width='600px' align='right' > RUN DATE :  " + date_chk(rundate) + "</td>");
        //HEADER.Append("</tr>");
        HEADER.Append("</table>");

        //HEADER.Append("</tr>");
        //HEADER.Append("</table>");
        //HEADER.Append("</td></tr>");

        //HEADER.Append("<tr><td>");
        //HEADER.Append("<table>");
        ////TBL.Append("<tr><td class='newfont1' width='400px' align='left' >PUBLICATION     : " + publicationname + "</td>");
        ////TBL.Append("<td class='newfont1' width='200px' align='center' > AGENCY:" + agency + "</td>");
        ////TBL.Append("<td class='newfont1' width='400px' align='right' > SUPPLY TYPE NAME  : " + supply_type_code + "</td>");
        //HEADER.Append("</tr>");
        //HEADER.Append("</table>");
        //HEADER.Append("</td></tr>");

        //HEADER.Append("</table>");
        HEADER.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:0px;margin-top:20px;' cellspacing='0px' cellpadding = '0px' border='0' width='20%'>");

        //TBL.Append("<tr ><td class='middle31' align='left' width='25%'>");
        //TBL.Append("S.No." + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("DEAL NUMBER" + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("AGENCY NAME" + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("CLIENT NAME" + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("PRODUCT NAME" + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("START DATE" + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("END DATE" + "</td>");
        HEADER.Append("<td class='middle31' align='left' width='10%'>");
        HEADER.Append("AMOUNT/SIZE" + "</td>");
        HEADER.Append("</tr>");
       

        return HEADER.ToString();
    
    }

    public string date_chk(string acc_date)
    {
        if (acc_date != "")
        {
            if (acc_date.IndexOf("") > -1)
            {
                string[] chk_str = acc_date.Split(' ');
                acc_date = chk_str[0];
            }
        }
        if (hiddendateformat.Value == "dd/mm/yyyy")
        {
            string[] arr = acc_date.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            if (arr[0].Length < 2)
                dd = "0" + arr[0];
            if (arr[1].Length < 2)
                mm = "0" + arr[1];
            acc_date = dd + "/" + mm + "/" + yy;

        }
        else
        {
            string[] arr = acc_date.Split('/');
            string dd = arr[0];
            string mm = arr[1];
            string yy = arr[2];
            if (arr[0].Length < 2)
                dd = "0" + arr[0];
            if (arr[1].Length < 2)
                mm = "0" + arr[1];
            acc_date = mm + "/" + dd + "/" + yy;
        }


        return acc_date;
    }


    public void showreport()
    {
        string mode = "";
        //rundate = System.DateTime.Now.ToString();
        int totalcopies = 0;
        int grandtotalcopies = 0;
        int m11 = 0;
        //StringBuilder TBL = new StringBuilder();
        DataSet ds = new DataSet();
        try
        {
            if (ConfigurationSettings.AppSettings["connectiontype"].ToString() == "orcl")
            {
                //NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print subreg = new NewAdbooking.classesoracle.crm_rpt_subscriber_register_walkin_print();
                //ds = subreg.rpt_sub_regprint(compcode, locid, publication, fromdate, todate, town, city, dateformat, extra1, extra2, extra3, extra4, extra5, extra6);
            }
            else
            {

                //NewAdbooking.Classes.dealcomp couprec = new NewAdbooking.Classes.dealcomp();
                //ds = couprec.rpt_imp_summary(comp_code, agency_code, product_code, client_code, from_dt, to_dt, pdateformat);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        
        StringBuilder TBL = new StringBuilder();
        double total = 0;
        string topheader = createheader();
        TBL.Append(createheader());

        int s_no = 1;

        if (ds.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");

            return;
        }
        //TBL.Append("<table cellspacing='0px' cellpadding = '0px' border='0' width='20%'>");
        //TBL.Append("<tr><td  class='newfont1' align='CENTER' style='font-size:16px;' ><b>" + "GUJRAAT" + "</b></td>");
        //TBL.Append("</tr>");
        //TBL.Append("<tr><td>");
        //TBL.Append("<table>");
        //TBL.Append("<table>");
        ////TBL.Append("<tr><td class='newfont1' width='400px' align='left' > LOCATION: " + Session["centername"].ToString() + "</td>");
        //TBL.Append("<td class='newfont1' width='200px' align='left' > FROM DATE: " + from_dt + "</td>");
        //TBL.Append("<td class='newfont1' width='750px' align='right' > TO DATE: " + to_dt + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");
        //TBL.Append("<table>");
        //TBL.Append("<tr><td class='newfont1' width='400px' align='left' > AGENCY :" + Request.QueryString["agency"].ToString() + "</TD>");
        //////TBL.Append("<td class='newfont1' width='200px' align='left' > FROM DATE: " + fromdate + "</td>");
        ////TBL.Append("<td class='newfont1' width='600px' align='right' > RUN DATE :  " + date_chk(rundate) + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");

        //TBL.Append("</tr>");
        //TBL.Append("</table>");
        //TBL.Append("</td></tr>");

        //TBL.Append("<tr><td>");
        //TBL.Append("<table>");
        ////TBL.Append("<tr><td class='newfont1' width='400px' align='left' >PUBLICATION     : " + publicationname + "</td>");
        ////TBL.Append("<td class='newfont1' width='200px' align='center' > AGENCY:" + agency + "</td>");
        ////TBL.Append("<td class='newfont1' width='400px' align='right' > SUPPLY TYPE NAME  : " + supply_type_code + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");
        //TBL.Append("</td></tr>");

        //TBL.Append("</table>");
        //TBL.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:0px;margin-top:20px;' cellspacing='0px' cellpadding = '0px' border='0' width='100%'>");

        ////TBL.Append("<tr ><td class='middle31' align='left' width='25%'>");
        ////TBL.Append("S.No." + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("DEAL NUMBER" + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("AGENCY NAME" + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("CLIENT NAME" + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("PRODUCT NAME" + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("START DATE" + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("END DATE" + "</td>");
        //TBL.Append("<td class='middle31' align='left' width='10%'>");
        //TBL.Append("AMOUNT/SIZE" + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");
      
        //TBL.Append("<table style ='margin-top:0px;'cellspacing='0px' cellpadding = '0px' border='0' width='100%'>");
        for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
        {
            if (rowcounter == maxlimit)
            {
                TBL.Append("</table>");
                TBL.Append("</br>");
                rowcounter = 0;
                TBL.Append("<p style='PAGE-BREAK-BEFORE: always'><table width='%'cellpadding='0' cellspacing='0' border='0'  margin='0'  vertical-align:top;>");
                string header = createheader();
                TBL.Append(header);
                header = "";
                s_no = 1;
            }

            //TBL.Append("<tr font-size='10' font-family='Verdana'>");
            //TBL.Append("<td class='newfont1'align='left' width='25%'>");
            //TBL.Append(s_no.ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["Deal_code"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["agency_name"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left' width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["cust_name"].ToString() + "</td>");

            TBL.Append("<td class='newfont1'align='left'  width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["product_code"].ToString() + "</td>");




            TBL.Append("<td class='newfont1'align='left' width='10%'>");


            if (ds.Tables[0].Rows[r]["from_date"].ToString() == "")
            {
                TBL.Append((ds.Tables[0].Rows[r]["from_date"].ToString()) + "</td>");
            }
            else
            {
                TBL.Append(date_chk(ds.Tables[0].Rows[r]["from_date"].ToString()) + "</td>");
            }
            TBL.Append("<td class='newfont1'align='left' width='10%'>");


            if (ds.Tables[0].Rows[r]["till_date"].ToString() == "")
            {
                TBL.Append((ds.Tables[0].Rows[r]["til_date"].ToString()) + "</td>");
            }
            else
            {
                TBL.Append(date_chk(ds.Tables[0].Rows[r]["till_date"].ToString()) + "</td>");
            }

            TBL.Append("<td class='newfont1'align='left'  width='10%'>");
            TBL.Append(ds.Tables[0].Rows[r]["contract_amount"].ToString() + "</td>");

            //total += Convert.ToDouble(ds.Tables[0].Rows[r]["COLONY"].ToString());

            TBL.Append("</tr>");
            s_no++;
            rowcounter++;
        }

        //TBL.Append("<tr><td colspan='4'>");
        //TBL.Append("<table class='newfont1' style='border-top:solid;border-bottom:solid; border-color:black;border-width:1px;margin-top:20px;'  width='100%'>");
        //TBL.Append("<tr font-size='10' font-family='Verdana'>");
        //TBL.Append("<td class='newfont1'align='left' width='30%'>");
        //TBL.Append("<b>Total Copy<b>" + "</td>");
        //TBL.Append("<td class='newfont1'align='right' style='padding-right:190px;' width='70%'>");
        //TBL.Append(total.ToString() + "</td>");
        //TBL.Append("</tr>");
        //TBL.Append("</table>");
       // TBL.Append("</td></tr>");
        TBL.Append("</table></p>");
        subregrepDiv.InnerHtml = TBL.ToString();
        //printbutton.Attributes.Add("onclick", "javascript:window.open('Deal_comparisonprintview_rpt.aspx?destination=" + destination + "&from_dt=" + from_dt + "&to_dt=" + to_dt + "&product=" + product + "&client=" + client + "&agency=" + agency + "&agency_code=" + agency_code + "&product_code=" + product_code + "&client_code=" + client_code + "')");
        // printbutton.Attributes.Add("onclick", "javascript:window.open('crm_rpt_subscriber_register_walkin_print1.aspx?destination=" + destination + "&fromdate=" + fromdate + "&locid=" + locid + "&publication=" + publication + "&city=" + city + "&town=" + town + "&todate=" + todate + "')");

    }

    

}
