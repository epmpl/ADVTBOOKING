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
using System.Globalization;
using System.IO;
using iTextSharp.text;

public partial class Advance_Deposit_Receipt : System.Web.UI.Page
{
    string ReportName = "", compname = "", qbccode = "", date = "", balance = "", dateformat = "";
    DataSet ds = new DataSet();
    StringBuilder TBL = new StringBuilder();
    StringBuilder Head = new StringBuilder();
    HtmlGenericControl div = new HtmlGenericControl();
    int TotalColSpan = 0, ColSpan1 = 0, ColSpan2 = 0, TotalColSpan1 = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        if (Session["compcode"] == null)
        {
            Response.Write("<script>alert('Your Session has been Expired!'); window.parent.location=\"login.aspx\";</script>)");
            return;
        }
        compname = Request.QueryString["compname"].ToString();
        qbccode = Request.QueryString["qbccode"].ToString();
        date = Request.QueryString["date"].ToString();
        balance = Request.QueryString["balance"].ToString();
        dateformat = Request.QueryString["dateformat"].ToString();

        ReportName = "Advance Deposit Receipt";

        TotalColSpan = 4;
        if (TotalColSpan % 2 == 0)
        {
            ColSpan1 = TotalColSpan / 2;
            ColSpan2 = ColSpan1;
        }
        else
        {
            ColSpan1 = (TotalColSpan - 1) / 2;
            ColSpan2 = ColSpan1 + 1;
        }

        //if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        //{
        //    NewAdbooking.classesoracle.Roav_qbc obj = new NewAdbooking.classesoracle.Roav_qbc();
        //    ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
        //}
        //else
        //{
        //    NewAdbooking.Classes.Roav_qbc obj = new NewAdbooking.Classes.Roav_qbc();
        //    ds = obj.Modify_tal(mod_tablefields, mod_tablevalue, mod_tablename, mod_action, wherefield, date, extra1, extra2);
        //}
        //if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        //{
        //    Response.Write("<script>alert('Searching Criteria is not valid');window.close();</script>");
        //    return;
        //}
        //else
        //{
        //    GetReport();
        //}
        GetReport();
    }
    string ConvertDateAsDateformat(string date)
    {
        if (!string.IsNullOrEmpty(date))
        {
            if (dateformat.ToLower() == "dd/mm/yyyy")
            {
                date = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(date));
            }
            else if (dateformat.ToLower() == "mm/dd/yyyy")
            {
                date = string.Format("{0:MM/dd/yyyy}", DateTime.Parse(date));
            }
            else
            {
                date = string.Format("{0:yyyy/MM/dd}", DateTime.Parse(date));
            }
        }
        return date;
    }
    StringBuilder SSPHeader(int i)
    {
        Head = new StringBuilder();
        Head.Append("<table cellpadding='0' width='55%' cellspacing='0' style='margin: 0px 0px 0px 0px;'>");
        Head.Append("<tr ><td colspan='" + TotalColSpan + "' style='border-top:1px solid black;border-left:1px solid black;border-right:1px solid black;font-size:17px;font-family:Verdana;text-align:center;color:black;'><b>" + compname + "</b></td></tr>");
        Head.Append("<tr valign='top' style='height:30px; '><td colspan='" + TotalColSpan + "' style='border-bottom:1px solid black;border-left:1px solid black;border-right:1px solid black;font-size:15px;font-family:Verdana;text-align:center;color:black;'><b>" + ReportName + "</b></td></tr>");
        Head.Append("<tr valign='top' style='height:10px; '><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;'></td></tr>");
        Head.Append("<tr ><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;font-size:15px;font-family:Verdana;text-align:left;padding-left:10px;'><b>Agcode : </b></td></tr>");
        Head.Append("<tr ><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;font-size:15px;font-family:Verdana;text-align:left;'><b>Subcode : </b></td></tr>");
        Head.Append("<tr ><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;font-size:15px;font-family:Verdana;text-align:left;padding-left:23px;'><b>Name : </b></td></tr>");
        Head.Append("<tr ><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;font-size:15px;font-family:Verdana;text-align:left;padding-left:4px;'><b>Address : </b></td></tr>");
        Head.Append("<tr ><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;font-size:15px;font-family:Verdana;text-align:left;padding-left:40px;'><b>City : </b></td></tr>");
        Head.Append("<tr valign='top' style='height:10px; '><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;'></td></tr>");

        Head.Append("</table>");
        Head.Append("<table width='55%' cellpadding='0' cellspacing='0' border='1' style='margin: 0px 0px 0px 0px;'>");
        Head.Append("<tr class='imageclass1' style='height:35px;'>");
        Head.Append("<td style='width:6%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black;border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>Sr. No.</b></td>");
        Head.Append("<td style='width:19%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black;border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>Receipt No</b></td>");
        Head.Append("<td style='width:15%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black;border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;'><b>Receipt Date</b></td>");
        Head.Append("<td style='width:15%;text-align:center;font-size:11px;font-family:Arial, Helvetica, sans-serif;border-left:1px solid black;border-bottom:1px solid black;border-top:1px solid black;vertical-align:middle;border-right:1px solid black'><b>Amount</b></td>");
        Head.Append("</tr>");
        return Head;
    }
    void GetReport()
    {
        var sno = 1;
        TBL.Append(SSPHeader(0));
        for (var i = 0; i < 1; i++)//ds.Tables[0].Rows.Count
        {
            TBL.Append("<tr valign='top' style='height:25px;'>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-bottom:1px solid black;border-left:1px solid black;'>" + sno.ToString() + "</td>");
            TBL.Append("<td style='text-align:left;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-bottom:1px solid black;border-left:1px solid black;padding-left:2px;'>" + sno.ToString() + "</td>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-bottom:1px solid black;border-left:1px solid black;'>" + sno.ToString() + "</td>");
            TBL.Append("<td style='text-align:center;font-family: Arial, Helvetica, sans-serif ; color:black; font-weight:normal; font-size: 10px; vertical-align :middle ;border-bottom:1px solid black;border-left:1px solid black;border-right:1px solid black;'>" + sno.ToString() + "</td>");
            TBL.Append("</tr>");
            sno++;
        }
        TBL.Append("</table>");
        TBL.Append("<table width='55%' cellpadding='0' cellspacing='0' border='0' style='margin: 0px 0px 0px 0px;'>");
        TBL.Append("<tr valign='top' style='height:30px; '><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;'></td></tr>");
        TBL.Append("<tr ><td colspan='" + TotalColSpan + "'  style='border-left:1px solid black;border-right:1px solid black;font-size:13px;font-family:Verdana;text-align:left;'><b>Now Your Balance is : </b><b> </b><b>/-</b></td></tr>");
        TBL.Append("<tr ><td colspan='" + TotalColSpan + "'  style='border-left:1px solid black;border-right:1px solid black;font-size:13px;font-family:Verdana;text-align:left;'><b>Your Limit For Classified Advts : </b><b> </b><b>/-</b></td></tr>");
        TBL.Append("<tr valign='top' style='height:30px; '><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;'></td></tr>");
        TBL.Append("<tr ><td colspan='" + ColSpan1 + "'  style='border-left:1px solid black;font-size:13px;font-family:Verdana;text-align:left;'><b>Cashier Name : </b></td>");//" + cdpname + "
        TBL.Append("<td colspan='" + ColSpan2 + "' style='border-right:1px solid black;font-size:13px;font-family:Verdana;text-align:right;padding-right:20px;'><b>Signature</b></td>");
        TBL.Append("</tr>");
        TBL.Append("<tr valign='top' style='height:50px; '><td colspan='" + TotalColSpan + "' style='border-left:1px solid black;border-right:1px solid black;border-bottom:1px solid black;'></td></tr>");
        
        TBL.Append("</table>");
        view.InnerHtml = TBL.ToString();
    }
}
