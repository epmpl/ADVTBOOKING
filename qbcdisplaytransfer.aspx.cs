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
public partial class qbcdisplaytransfer : System.Web.UI.Page
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
      

        Ajax.Utility.RegisterTypeForAjax(typeof(qbcdisplaytransfer));

        hiddendateformat.Value = Session["dateformat"].ToString();
      

        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("xml/displaytransferrept.xml"));

        lbFromDate.Text = Request.QueryString["fromdate"].ToString();
        lbToDate.Text = Request.QueryString["todate"].ToString();

        lbldisplaymsb.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        //lblfromdate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        //lbltodate.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();

        if (!IsPostBack)
        {
            hiddencioid.Value = "cio_booking_id";
            hiddenascdesc.Value = Request.QueryString["order"].ToString();
            flag.Value = "0";
        }






        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            string fromdate = "";
            string todate = "";
            if (Session["dateformat"].ToString() == "dd/mm/yyyy")
            {
                fromdate = DMYToMDY(lbFromDate.Text);
                todate = DMYToMDY(lbToDate.Text);
            }


            else if (Session["dateformat"].ToString() == "yyyy/mm/dd")
            {
                fromdate = YMDToMDY(lbFromDate.Text);
                todate = YMDToMDY(lbToDate.Text);
            }
            NewAdbooking.Classes.Class1 getpubwidth = new NewAdbooking.Classes.Class1();
            ds = getpubwidth.griddisplay(fromdate,todate, hiddencioid.Value, hiddenascdesc.Value, Session["dateformat"].ToString(), Session["agency_name"].ToString());

        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.reportconfirm getpubwidth = new NewAdbooking.classesoracle.reportconfirm();
            ds = getpubwidth.griddisplay(lbFromDate.Text, lbToDate.Text, hiddencioid.Value, hiddenascdesc.Value,Session["dateformat"].ToString(),Session["agency_name"].ToString());

        }
        else
        {
            NewAdbooking.classmysql.transferreport bind = new NewAdbooking.classmysql.transferreport();
            ds = bind.griddisplay(lbFromDate.Text, lbToDate.Text, hiddencioid.Value, hiddenascdesc.Value);


        }


      
        string tblData = "";

        if (ds.Tables[0].Rows.Count > 0)
        {
            tblData += "<table cellpadding='5' cellspacing='0px'>";

            tblData += "<tr>";

            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";
            tblData += "<td class='middle4' width='4px'>-</td>";

            tblData += "</tr>";

            tblData += "<tr>";
            tblData += "<td class='middle31'>S. No.</td>";
            tblData += "<td class='middle3' id='tdag~1' onclick=sorting('cio_booking_id',this.id)>SAPId<img id='imgcioiddown' src='Images\\down.gif' style='display:block;'><img id='imgcioidup' src='Images\\up.gif' style='display:none;'></td>";
            tblData += "<td class='middle31'>Booking Date</td>";
            tblData += "<td class='middle31'>Schedule Date</td>";
            tblData += "<td class='middle3' id='tdag~4' onclick=sorting('Agency_name',this.id)>Agency<img id='imgagdown' src='Images\\down.gif' style='display:block;'><img id='imgagup' src='Images\\up.gif' style='display:none;'></td>";
            tblData += "<td class='middle3' id='tdag~5' onclick=sorting('client_name',this.id)>Client<img id='imgcldown' src='Images\\down.gif' style='display:block;'><img id='imgclup' src='Images\\up.gif' style='display:none;'></td>";
            tblData += "<td class='middle31'>UOM</td>";
            tblData += "<td class='middle31'>Category</td>";
            tblData += "<td class='middle31'>Sub Category</td>";
            tblData += "<td class='middle31'>Size</td>";
            tblData += "<td class='middle31'>Package</td>";
            tblData += "<td class='middle31'>Colour</td>";
            tblData += "<td class='middle31'>Card Rate</td>";
            tblData += "<td class='middle31'>Net Amount</td>";

            tblData += "</tr>";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tblData += "<tr>";
                tblData += "<td class='rep_data' align='center'>";
                tblData += i + 1;
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["SAPID"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += Convert.ToDateTime(ds.Tables[0].Rows[i]["creation_datetime"].ToString()).ToShortDateString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += Convert.ToDateTime(ds.Tables[0].Rows[i]["Insert_date"].ToString()).ToShortDateString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["Agency_name"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["client_name"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["uom_name"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["cat_name"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["subcat_name"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["total_area"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["package_code"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data'>";
                tblData += ds.Tables[0].Rows[i]["col_name"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data' align='center'>";
                tblData += ds.Tables[0].Rows[i]["card_rate"].ToString();
                tblData += "</td>";

                tblData += "<td class='rep_data' align='center'>";
                tblData += ds.Tables[0].Rows[i]["Gross_amount"].ToString();
                tblData += "</td>";

                tblData += "</tr>";
            }
            tblData += "</table>";
        }
      
            
        else
        {
            tblData += "<br />";
            tblData += "<table align='center'>";
            tblData += "<tr>";
            tblData += "<td>";
            tblData += " Transfered Booking Not Found Between " + lbFromDate.Text + "  and  " + lbToDate.Text;
            tblData += "</td>";
            tblData += "</tr>";
            tblData += "</table>";
        }
        tblgrid.InnerHtml = tblData;
    }
}
