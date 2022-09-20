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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;

public partial class Reports_case_register_rep_view : System.Web.UI.Page
{
    string compcode="";
    string adtype ="";
    string adcategory ="";
    string adsubcat ="";
    string fromdate ="";
    string todate ="";
    string publication="";
    string pubcenter ="";
    string edition ="";
    string printcent ="";
    string branch ="";
    string userid ="";
    string destination="";
    string basedon = "";
    string extra1 = "";
    string extra2 = "";
    string extra3 = "";
    string extra4 = "";
    string compname = "";
    string reportname = "";
    string rundate = "";
    string pubname = "";
    string editionname = "";
    string dateformat = "";
    protected void Page_Load(object sender, EventArgs e)
    {

         compname = Session["comp_name"].ToString();
         reportname = "Case Register Report";
         dateformat = Session["dateformat"].ToString();
        compcode = Request.QueryString["compcode"].ToString();
        adtype = Request.QueryString["adtype"].ToString();
        adcategory = Request.QueryString["adcategory"].ToString();
        adsubcat = Request.QueryString["adsubcat"].ToString();
        fromdate = Request.QueryString["fromdate"].ToString();
        todate = Request.QueryString["todate"].ToString();
        publication = Request.QueryString["publication"].ToString();
        edition = Request.QueryString["edition"].ToString();
        pubcenter = Request.QueryString["pubcenter"].ToString();
        printcent = Request.QueryString["printcent"].ToString();
        branch = Request.QueryString["branch"].ToString();
        userid = Request.QueryString["userid"].ToString();
        destination = Request.QueryString["destination"].ToString();
        basedon = Request.QueryString["basedon"].ToString();
        editionname = Request.QueryString["editionname"].ToString();

        pubname = Request.QueryString["pubname"].ToString();
        if (pubname == "0")
        {
            pubname = "";
        }
        if (branch == "0")
        {
            branch = "";
        }
        if (printcent == "0")
        {
            printcent = "";
        }
        if (adtype == "0")
        {
            adtype = "";
        }
        if (adcategory == "0")
        {
            adcategory = "";
        }

        if (adsubcat == "0")
        {
            adsubcat = "";
        }
        if (publication == "0")
        {
            publication = "";
        }
        if (edition == "0")
        {
            edition = "";
        }
        if (userid == "0")
        {
            userid = "";
        }
        if (pubname == "--Select Publication--")
        {
            pubname = "All";
        }
        else { 
            pubname = Request.QueryString["pubname"].ToString(); 
        }

        if (editionname == "--Select Edition Name--")
        {
            editionname = "All";
        }
        else
        {
            editionname = Request.QueryString["editionname"].ToString();
        }
        if (destination == "0" || destination == "1")
        {
            onscreen();
        }
        else if (destination == "4")
        {
            showexcel();
        }
        else
        {
          //  showpdf();
        
        }


    }


    private void onscreen()
    {

        string TBL = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep obj = new NewAdbooking.Report.Classes.case_register_rep();
            ds = obj.onscreen_rep(compcode, branch, printcent, adtype, adcategory, adsubcat, fromdate, todate, publication, pubcenter, edition, basedon, userid, extra1, extra2, extra3, extra4, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            string[] parameterValueArray = new string[] { compcode, branch, printcent, adtype, adcategory, adsubcat, fromdate, todate, publication, pubcenter, edition, basedon, userid, extra1, extra2, extra3, extra4, dateformat };
            string procedureName = "ad_case_register_report";
            NewAdbooking.classesoracle.CommonClass exe = new NewAdbooking.classesoracle.CommonClass();
            ds = exe.DynamicBindProcedure(procedureName, parameterValueArray);
         //   NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
         //  ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
            string procedureName = "ad_case_register_report";
            string[] parameterValueArray = new string[] { compcode, branch, printcent, adtype, adcategory, adsubcat, fromdate, todate, publication, pubcenter, edition, basedon, userid, extra1, extra2, extra3, extra4, dateformat };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
         if (ds.Tables[0].Rows.Count > 0)
        {

            rundate = System.DateTime.Now.ToString();

            TBL += "<table cellspacing='0px' cellpadding = '0px'  border='0' width='100%'>";
            TBL += "<tr >";
            TBL += "<td style='font-family :Arial;font-size :20px;font-weight :bolder;color :Black;' align='right'>";
            TBL += compname + "</td>";
            TBL += "</tr>";
            TBL += "<tr>";
            TBL += "<td style='font-family :Arial;font-size :14px;font-weight :bolder;color :Black;'  align='right'>";
            TBL += reportname + "</td>";
            TBL += "</tr>";

            TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";

            TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";

            TBL += "<tr>";
            TBL += "<td    align='right' style='font-size:11px;font-family:arial' colspan='15'><b>";
            TBL += "Run Date : " + date_chk(rundate) + "</b></td>";
            TBL += "</tr>";

            TBL += "<tr colspan='6'>";
            TBL += "<td  colspan='3' style='font-size:11px;font-family:arial'> Publication : " + pubname + "</b></td>";

            TBL += "<td colspan='3' align='right' style='font-size:11px;font-family:arial'> From Date : " + fromdate + "</b></td>";
            
            TBL += "</tr>";
           

            TBL += "<tr colspan='6' style='border:1px solid black' >";
            TBL += "<td align='left' colspan='3' style='font-size:11px;font-family:arial'> Edition : " + editionname + "</b></td>";
            TBL += "<td colspan='3' align='right' style='font-size:11px;font-family:arial' >To Date : " + todate + "</b></td>";
            TBL += "</tr>";


            

            TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";


            TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";


            TBL += "</table>";
            TBL += "<table cellspacing='0px' cellpadding = '0px' border='0'  width='100%'>";
            TBL += "<tr ><td class='middle31new' align='left' width='10%'>Booking Id</td>";
            TBL += "<td class='middle31new' align='left' width='15%'>Publish Date</td>";
            TBL += "<td class='middle31new' align='left' width='10%'>Agency</td>";
            TBL += "<td class='middle31new' align='left' width='10%'>Package</td>";
            TBL += "<td class='middle31new' align='left' width='10%'>Edition</td>";
            TBL += "<td class='middle31new' align='left' width='10%'>Case No.</td>";
            TBL += "<td class='middle31new' align='left' width='15%'>Case Title</td>";
            TBL += "<td class='middle31new' align='left' width='20%'>Booked BY</td>";
            TBL += "</tr>";


            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {
                TBL += "<tr class='rep_data'  >";
                TBL += "<td class='rep_data' align='left' width='10%'  >";
                TBL += ds.Tables[0].Rows[m]["cio_booking_id"].ToString() + "</td>";

                TBL += "<td class='rep_data' align='left' width='15%'  >";
                TBL += ds.Tables[0].Rows[m]["Insert_date"].ToString() + "</td>";

                TBL += "<td class='rep_data' align='left' width='10%' >";
                TBL += ds.Tables[0].Rows[m]["agency_sub_code"].ToString() + "</td>";

                TBL += "<td class='rep_data' align='left' width='10%'  >";
                TBL += ds.Tables[0].Rows[m]["package_code"].ToString() + "</td>";

                TBL += "<td class='rep_data' align='left' colspan='1' width='5%'  >";
                TBL += ds.Tables[0].Rows[m]["Edition"].ToString() + "</td>";
               
                TBL += "<td class='rep_data' align='left' width='10%'  >";
                if (ds.Tables[0].Rows[m]["bill_remarks"].ToString() != "")
                {
                    TBL += ds.Tables[0].Rows[m]["bill_remarks"].ToString().Split('~')[0] + "</td>";
                }
                else
                {
                    TBL += "";
                }
                TBL += "<td class='rep_data' align='left' width='20%'  >";
                if (ds.Tables[0].Rows[m]["bill_remarks"].ToString() != "")
                {
                    TBL += ds.Tables[0].Rows[m]["bill_remarks"].ToString().Split('~')[1] + "</td>";
                }
                else
                { 
                TBL += "";
                }
                TBL += "<td class='rep_data' align='left' width='20%'  >";
                TBL += ds.Tables[0].Rows[m]["booked_by"].ToString() + "</td>";

                TBL += "</tr>";
            }
            TBL += "</table>";

            report.InnerHtml = TBL;

           // btnprint.Attributes.Add("onclick", "javascript:window.open('crm_subs_del_rpt_print.aspx?view=" + view + "&compcode=" + compcode + "&locid=" + locid + "&pub=" + pub + "&pubname=" + pubname + "&agcd=" + agcd + "&dpcd=" + dpcd + "&agency=" + agency + "&city=" + city + "&cityname=" + cityname + "&route=" + route + "&routename=" + routename + "&date=" + date + "&datef=" + datef + "')");
        }
         else
         {
             Response.Write("<script>alert('Searching Criteria Is Not Valid');window.close();</script>");
         }

        }


    private void showexcel()
    {

        Response.Clear();
        Response.ClearContent();
        Response.Charset = "UTF-8";
        Response.ContentType = "text/csv";
        Response.AppendHeader("content-disposition", "attachment; filename=Ex.xls");


        string TBL = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.case_register_rep obj = new NewAdbooking.Report.Classes.case_register_rep();
            ds = obj.onscreen_rep(compcode, branch, printcent, adtype, adcategory, adsubcat, fromdate, todate, publication, pubcenter, edition, basedon, userid, extra1, extra2, extra3, extra4, dateformat);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            //   NewAdbooking.Report.classesoracle.Class1 obj = new NewAdbooking.Report.classesoracle.Class1();
            //  ds = obj.barter_report(frmdt, todate, Session["compcode"].ToString(), clientname, agencyname, region, product, booktype, Session["dateformat"].ToString(), hiddencioid.Value.Trim(), hiddenascdesc.Value.Trim());
        }
        else
        {
            string procedureName = "ad_case_register_report";
            string[] parameterValueArray = new string[] { compcode, branch, printcent, adtype, adcategory, adsubcat, fromdate, todate, publication, pubcenter, edition, basedon, userid, extra1, extra2, extra3, extra4, dateformat };
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
         if (ds.Tables[0].Rows.Count > 0)
        {

        rundate = System.DateTime.Now.ToString();
        TBL += "<table cellspacing='0px' cellpadding = '0px' border='1'  width='100%'>";
        TBL += "<table cellspacing='0px'colspan='8' cellpadding = '0px'  border='1'>";
        TBL += "<tr >";
        TBL += "<td style='font-family :Arial;font-size :20px;font-weight :bolder;color :Black;' cellpadding='80px' align='center' colspan='8'>";
        TBL += compname + "</td>";
        TBL += "</tr>";
        TBL += "<tr>";
        TBL += "<td style='font-family :Arial;font-size :14px;font-weight :bolder;color :Black;' cellpadding='80px' align='center' colspan='8'>";
        TBL += reportname + "</td>";
        TBL += "</tr>";

        //TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";

        //TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";

        TBL += "<tr>";
        TBL += "<td    align='right' style='font-size:11px;font-family:arial' colspan='8'><b>";
        TBL += "Run Date : " + date_chk(rundate) + "</b></td>";
        TBL += "</tr>";

        TBL += "<tr colspan='6'>";
        TBL += "<td  colspan='3' style='font-size:11px;font-family:arial'> Publication : " + pubname + "</b></td>";

        TBL += "<td colspan='5' align='right' style='font-size:11px;font-family:arial'> From Date : " + fromdate + "</b></td>";

        TBL += "</tr>";


        TBL += "<tr colspan='6' style='border:1px solid black' >";
        TBL += "<td align='left' colspan='3' style='font-size:11px;font-family:arial'> Edition : " + editionname + "</b></td>";
        TBL += "<td colspan='5' align='right' style='font-size:11px;font-family:arial' >To Date : " + todate + "</b></td>";
        TBL += "</tr>";




        //TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";


        //TBL += "<tr><td><p></p><p></p><p></p><p></p></td></tr>";


        TBL += "</table>";
        TBL += "<table cellspacing='0px' cellpadding = '0px' border='1'  width='100%'>";
        TBL += "<tr ><td class='middle31new' align='left' width='10%'>Booking Id</td>";
        TBL += "<td class='middle31new' align='left' width='15%'>Publish Date</td>";
        TBL += "<td class='middle31new' align='left' width='10%'>Agency</td>";
        TBL += "<td class='middle31new' align='left' width='10%'>Package</td>";
        TBL += "<td class='middle31new' align='left' width='10%'>Edition</td>";
        TBL += "<td class='middle31new' align='left' width='10%'>Case No.</td>";
        TBL += "<td class='middle31new' align='left' width='15%'>Case Title</td>";
        TBL += "<td class='middle31new' align='left' width='20%'>Booked BY</td>";
        TBL += "</tr>";


        for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
        {
            TBL += "<tr class='rep_data'  >";
            TBL += "<td class='rep_data' align='left' width='10%'  >";
            TBL += ds.Tables[0].Rows[m]["cio_booking_id"].ToString() + "</td>";

            TBL += "<td class='rep_data' align='left' width='15%'  >";
            TBL += ds.Tables[0].Rows[m]["Insert_date"].ToString() + "</td>";

            TBL += "<td class='rep_data' align='left' width='10%' >";
            TBL += ds.Tables[0].Rows[m]["agency_sub_code"].ToString() + "</td>";

            TBL += "<td class='rep_data' align='left' width='10%'  >";
            TBL += ds.Tables[0].Rows[m]["package_code"].ToString() + "</td>";

            TBL += "<td class='rep_data' align='right' width='5%'  >";
            TBL += ds.Tables[0].Rows[m]["Edition"].ToString() + "</td>";

            TBL += "<td class='rep_data' align='left' width='10%'  >";
            if (ds.Tables[0].Rows[m]["bill_remarks"].ToString() != "")
            {
                TBL += ds.Tables[0].Rows[m]["bill_remarks"].ToString().Split('~')[0] + "</td>";
            }
            else
            {
                TBL += "";
            }
            TBL += "<td class='rep_data' align='left' width='20%'  >";
            if (ds.Tables[0].Rows[m]["bill_remarks"].ToString() != "")
            {
                TBL += ds.Tables[0].Rows[m]["bill_remarks"].ToString().Split('~')[1] + "</td>";
            }
            else
            {
                TBL += "";
            }

            TBL += "<td class='rep_data' align='left' width='20%'  >";
            TBL += ds.Tables[0].Rows[m]["booked_by"].ToString() + "</td>";

            TBL += "</tr>";
        }
        TBL += "</table>";

        report.InnerHtml = TBL;


        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        report.Visible = true;
        report.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();

        // btnprint.Attributes.Add("onclick", "javascript:window.open('crm_subs_del_rpt_print.aspx?view=" + view + "&compcode=" + compcode + "&locid=" + locid + "&pub=" + pub + "&pubname=" + pubname + "&agcd=" + agcd + "&dpcd=" + dpcd + "&agency=" + agency + "&city=" + city + "&cityname=" + cityname + "&route=" + route + "&routename=" + routename + "&date=" + date + "&datef=" + datef + "')");
        }
         else
         {
             Response.Write("<script>alert('Searching Criteria Is Not Valid');window.close();</script>");
         }

    }

    public string date_chk(string acc_date)
    {
        if (acc_date != "")
        {
            if (acc_date.IndexOf(" ") > -1)
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
            acc_date = mm + "/" + dd + "/" + yy;

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
            acc_date = dd + "/" + mm + "/" + yy;
        }


        return acc_date;
    }
}
