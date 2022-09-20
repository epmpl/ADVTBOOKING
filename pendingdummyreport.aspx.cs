using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Text;
public partial class pendingdummyreport : System.Web.UI.Page
{
    int j = 1;
    string rundate = "";
    string rdate = "";
    string rdatefinalhdsmain="";
    string fromdate = "";
    string adtype = "";

    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        rundate = DateTime.Now.ToString();
        string[] tim = rundate.Split(' ');
        rdate = tim[0];
        string[] rdatehdsmaintds = rdate.Split(' ');
        string hdsmainhjrdate = rdatehdsmaintds[0];
        string[] hdsmainhjrdateS = hdsmainhjrdate.Split('/');
        string hdsmainhjrdate1 = hdsmainhjrdateS[0];
        string hdsmainhjrdate2 = hdsmainhjrdateS[1];
        string hdsmainhjrdate3 = hdsmainhjrdateS[2];
        rdatefinalhdsmain = hdsmainhjrdate2 + '/' + hdsmainhjrdate1 + '/' + hdsmainhjrdate3;
   
        ds = (DataSet)Session["pending_ds"];
        onscreen();
        lbldate.Text = rdatefinalhdsmain.ToString();
       // fromdate = Request.QueryString["fromdate"].ToString();
        //adtype = Request.QueryString["adtype"].ToString();
    }
    private void onscreen()
    {
        int cont = ds.Tables[0].Rows.Count;
        StringBuilder tbl = new StringBuilder();


        tbl.Append("<table width='100%'align='left' cellpadding='0' cellspacing='0' valign='top'>");

        tbl.Append(" <td class='middle31new' width='3%'>S.No</td><td  class='middle31new'  width='10%'>Booking ID</td><td  class='middle31new'  width='10%'>Booking Date</td><td  class='middle31new'  width='5%'>Insertion No.</td><td  class='middle31new'  width='8%'>Edition</td><td class='middle31new' width='8%'>Package Name</td><td  class='middle31new' width='8%'>Category</td><td class='middle31new' width='8%'>Reason</td><td  class='middle31new' width='12%'>Client Name</td><td  class='middle31new' width='12%'>Agency Name</td>");
 



         for (int i = 0; i < cont; i++)
         {

            tbl.Append("<tr >");


            tbl.Append("<td class='rep_data' align='left' width='3%'>");
            tbl.Append(j++.ToString()+ "</td>");

             
             tbl.Append("<td class='rep_data' align='left' width='10%'>");
             tbl.Append(ds.Tables[0].Rows[i]["BKID"] + "</td>");

             tbl.Append("<td class='rep_data' align='left' width='10%'>");
             tbl.Append(ds.Tables[0].Rows[i]["BK_DATE"] + "</td>");

             tbl.Append("<td class='rep_data' align='left'width='5%'>");
             tbl.Append(ds.Tables[0].Rows[i]["NOINSERT"] + "</td>");


             tbl.Append("<td class='rep_data' align='left' width='8%'>");
             tbl.Append(ds.Tables[0].Rows[i]["EDITION"] + "</td>");


             tbl.Append("<td class='rep_data' align='left' width='8%'>");
             tbl.Append(ds.Tables[0].Rows[i]["PACKAGE_NAME"] + "</td>");

             tbl.Append("<td class='rep_data' align='left' width='8%'>");
             tbl.Append(ds.Tables[0].Rows[i]["CAT_NAME"] + "</td>");

             tbl.Append("<td class='rep_data' align='left' width='8%'>");
             if (ds.Tables[0].Rows[i]["REASON_TYPE"].ToString() == "1")
             {
                 tbl.Append("UnApproval".ToString() + "</td>");
             }
             else if (ds.Tables[0].Rows[i]["REASON_TYPE"].ToString() =="2")
             {
                 tbl.Append("UnAudited".ToString() + "</td>");
           
             }
             else
             {
                 tbl.Append("Material not Upload".ToString() + "</td>");
           
             }

             tbl.Append("<td class='rep_data' align='left' width='12%'>");
             tbl.Append(ds.Tables[0].Rows[i]["CLIENT_NAME"] + "</td>");

             tbl.Append("<td class='rep_data' align='left' width='12%'>");
             tbl.Append(ds.Tables[0].Rows[i]["AGENCY_NAME"] + "</td>");
            
           tbl.Append("</tr>");
         }
        tbl.Append("</table>");
        report.InnerHtml = tbl.ToString();

    

    }
}
