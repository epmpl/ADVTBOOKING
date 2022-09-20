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
using System.Text.RegularExpressions;
public partial class displayadstatus : System.Web.UI.Page
{

    static string YMDToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new System.Text.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b",
            "${month}/${day}/${year}");
    }
    static string DMYToMDY(string input)
    {
        //System.Text.RegularExpressions Regex = new SystemText.RegularExpressions();
        return Regex.Replace(input,
            "\\b(?<day>\\d{1,2})/(?<month>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${month}/${day}/${year}");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string fromdate = Request.QueryString["fromdate"].ToString();
        string todate = Request.QueryString["todate"].ToString();
        string edition = Request.QueryString["edition"].ToString();
        string agency_name=Session["agency_name"].ToString();
        lbFromDate.Text = Request.QueryString["fromdate"].ToString();
        lbToDate.Text = Request.QueryString["todate"].ToString();
        DataSet ds=new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportconfirm clsconfirm = new NewAdbooking.classesoracle.reportconfirm();
            ds = clsconfirm.bindSapAdReport(fromdate, todate, edition, agency_name, Session["dateformat"].ToString());
        }
        else
        {
            if (Session["dateformat"].ToString() == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(fromdate);
                todate = DMYToMDY(todate);
            }


            else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(fromdate);
                todate = YMDToMDY(todate);
            }
            NewAdbooking.Classes.Class1 clsconfirm = new NewAdbooking.Classes.Class1();
            ds = clsconfirm.bindSapAdReport(fromdate, todate, edition, agency_name, Session["dateformat"].ToString());
        }
             string tblData = "";

             if (ds.Tables[0].Rows.Count > 0)
             {
                 tblData += "<table cellpadding='5px' cellspacing='0px' width='100%' align='left'>";

                 tblData += "<tr>";
                 tblData += "<td class='middle4'>-</td>";
                 tblData += "<td class='middle4'>-</td>";
                 tblData += "<td class='middle4'>-</td>";
                 tblData += "<td class='middle4'>-</td>";
                 tblData += "<td class='middle4'>-</td>";
                 tblData += "<td class='middle4'>-</td>";
                 tblData += "</tr>";

                 tblData += "<tr>";
                 tblData += "<td class='middle31'>SAP ID</td>";
                 tblData += "<td class='middle31'>Edition</td>";
                 tblData += "<td class='middle31'>Page No</td>";
                 tblData += "<td class='middle31'>Date</td>";
                 tblData += "<td class='middle31'>Category</td>";
                 tblData += "<td class='middle31'>Sub Category</td>";

                 tblData += "</tr>";
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     tblData += "<tr>";

                     tblData += "<td class='rep_data'>";
                     tblData += ds.Tables[0].Rows[i]["SAPID"].ToString();
                     tblData += "</td>";

                     tblData += "<td class='rep_data'>";
                     tblData += ds.Tables[0].Rows[i]["EDITION"].ToString();
                     tblData += "</td>";

                     tblData += "<td class='rep_data'>";
                     tblData += ds.Tables[0].Rows[i]["PAGE_NO"].ToString();
                     tblData += "</td>";

                     tblData += "<td class='rep_data'>";
                     tblData += ds.Tables[0].Rows[i]["PUB_DATE"].ToString();
                     tblData += "</td>";

                     tblData += "<td class='rep_data'>";
                     tblData += ds.Tables[0].Rows[i]["CATEGORY_CODE"].ToString();
                     tblData += "</td>";

                     tblData += "<td class='rep_data'>";
                     tblData += ds.Tables[0].Rows[i]["SUB_CATEGORY_CODE"].ToString();
                     tblData += "</td>";

                     tblData += "</tr>";
                 }
             }
             else
             {
                 tblData += "<table cellpadding='0' cellspacing='10px' align='center'>";

                 tblData += "<tr>";

                 tblData += "<td class='middle31'>";
                 tblData += "No Record Found Between " + lbFromDate.Text + "  and  " + lbToDate.Text;
                 tblData += "<td>";

                 tblData += "</tr>";

                 tblData += "</table>";
             }
             tblgrid.InnerHtml = tblData;
        
    }
}
