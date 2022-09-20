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

public partial class Reports_Materialprint : System.Web.UI.Page
{
    string pdate = ""; string user = ""; string pcenter = "", destination = "";
    string username = ""; string pcentername = "";
    DataSet ds = new DataSet();
    System.Web.HttpBrowserCapabilities browser;
    double ver;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["dateformat"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            hiddendateformat.Value = Session["dateformat"].ToString();
        }

        browser = Request.Browser;

        ver = (float)(browser.MajorVersion + browser.MinorVersion);



        pdate = Request.QueryString["pubdate"].ToString();
        user = Request.QueryString["user"].ToString();
        pcenter = Request.QueryString["pubcenter"].ToString();

        pcentername = Request.QueryString["pubname"].ToString();
        username = Request.QueryString["username"].ToString();
       // destination = Request.QueryString["dest"].ToString();
        lblpdate.Text = pdate;
        lblpubcent.Text = pcentername;
        lbluser.Text = username;
        lblrdate.Text = DateTime.Now.ToShortDateString();
        cmpnyname.Text = Session["comp_name"].ToString();
        heading.Text = "Material Log";

        ds = (DataSet)Session["datamat"];
        Ajax.Utility.RegisterTypeForAjax(typeof(Reports_Materialprint));

        //lblcenter.Text = ds.Tables[1].Rows[0].ItemArray[3].ToString();
        if (!Page.IsPostBack)
        {
                           onscreen();
                           ScriptManager.RegisterClientScriptBlock(this, typeof(Reports_Materialprint), "sa", " window.print();", true);
        }

       
    }


    private void onscreen()
    {


        int i1 = 1;
        int cont = ds.Tables[0].Rows.Count;
        int maxlimit = 13;
        DataSet brk = new DataSet();
          brk.ReadXml(Server.MapPath("XML/materiallog.xml"));
        maxlimit = Convert.ToInt16(brk.Tables[0].Rows[0].ItemArray[6].ToString());
        int ct = 0;
        int fr = maxlimit;
        int rcount = ds.Tables[0].Rows.Count;
        int pagec = rcount % maxlimit;
        int pagecount = rcount / maxlimit;
        if (pagec > 0)
        {
            pagecount = pagecount + 1;
        }

        string tbl = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
        if (browser.Browser == "Firefox")
        {
            tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
        }
        else if (browser.Browser == "IE")
        {
            if ((ver == 7.0) || (ver == 8.0))
            {
                tbl = "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
            else if (ver == 6.0)
            {
                tbl = "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0' align='left' valign='top'>";
            }
        }


        for (int p = 0; p < pagecount; p++)
        {
            int s = p + 1;
            if (browser.Browser == "Firefox")
            {
                tbl = tbl + "</table></P>";
                if (p == pagecount - 1)
                    tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                else
                    tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
            }
            else if (browser.Browser == "IE")
            {
                if ((ver == 8.0) || (ver == 7.0))
                {
                    tbl = tbl + "</table></P>";
                    if (p == pagecount - 1)
                        tbl += "<P><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<P style='page-break-after :always;'><table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";

                }
                else if (ver == 6.0)
                {
                    tbl = tbl + "</table>";
                    if (p == pagecount - 1)
                        tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'   valign='top'>";
                    else
                        tbl += "<table width='100%' cellspacing='0px' cellpadding = '0px' border='0'  class='break' valign='top'>";
                }
            }

            

            tbl = tbl + ("<tr><td  class='middle31new' width='20px' >S.No&nbsp;</td><td class='middle31new'  align='left'>UserName</td><td class='middle31new'  align='left'>OrignalName</td><td class='middle31new'  align='left'>Generate</br>FileName</td><td class='middle31new'  align='left'>Publish </br>date</td><td class='middle31new'  align='left'>Publish </br>Name</td><td class='middle31new'  align='left'>Publish </br>date</td></tr>");
           
            for (int i = ct; i < ds.Tables[0].Rows.Count && i < fr; i++)
            {
                tbl = tbl + ("<tr>");


                tbl = tbl + ("<td class='rep_data'>");
                tbl = tbl + (i1++.ToString() + "</td>");

                string cioid1 = "";
                string rrr = ds.Tables[0].Rows[i]["USERNAME"].ToString();
                if (rrr.Length >= 10)
                {
                    cioid1 = rrr.Substring(0, 10);
                    if (rrr.Length - 10 < 10)
                        cioid1 += "</br>" + rrr.Substring(10, rrr.Length - 10);
                    else
                        cioid1 += "</br>" + rrr.Substring(10, 10);
                }
                else
                    cioid1 = rrr;



                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (cioid1 + "</td>");

                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["ORIGINALNAME"] + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (ds.Tables[0].Rows[i]["SAPNAME"] + "</td>");


                string INSDATE = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString();
                string rrr1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["INSDATE"].ToString()).ToShortDateString();





                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (INSDATE + "</td>");

                string client1 = "";
                string rrr2 = ds.Tables[0].Rows[i]["BKFOR_NAME"].ToString();
                if (rrr2.Length >= 16)
                {
                    client1 = rrr2.Substring(0, 16);
                    if (rrr2.Length - 16 < 16)
                        client1 += "</br>" + rrr2.Substring(16, rrr2.Length - 16);
                    else
                        client1 += "</br>" + rrr2.Substring(16, 16);
                }
                else
                    client1 = rrr2;




                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left'>");
                tbl = tbl + (client1 + "</td>");


                tbl = tbl + ("<td style=\"padding-left:4px\" class='rep_data' align='left' >");
                tbl = tbl + (Convert.ToDateTime(ds.Tables[0].Rows[i]["UPD_DATETIME"].ToString()).ToShortDateString() + "</td>");



                tbl = tbl + "</tr>";


                tblgrid.InnerHtml += tbl;
                tbl = "";

            }
            ct = ct + maxlimit;
            fr = fr + maxlimit;


         //   tbl = tbl + ("<tr >");



           

        }
        tbl = tbl + ("</table>");
        tblgrid.InnerHtml += tbl;
    }
}


}
